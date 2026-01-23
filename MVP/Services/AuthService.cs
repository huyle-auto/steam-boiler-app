using SteamBoilerApp.Models;
using SteamBoilerApp.MVP.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace SteamBoilerApp.MVP.Services
{
    public class AuthService : IAuthService
    {
        // PBKDF2 settings
        private const int SaltSize = 16;          // 128 bits
        private const int KeySize = 32;           // 256 bits
        private const int Iterations = 100000;    // secure + fast enough

        public async Task<bool> ValidateUserAsync(string username, string password)
        {
            using var db = new ProductionDbContext();

            var user = await db.AppUsers
                .Where(u => u.Username == username)
                .FirstOrDefaultAsync();

            if (user == null)
                return false;

            bool ok = VerifyPassword(password, user.PasswordSalt, user.HashedPassword);

            if (!ok)
                return false;

            // Update login time
            user.LastLogin = DateTime.Now;
            await db.SaveChangesAsync();

            return true;
        }

        // ------------------------------
        // PUBLIC: Create new user
        // ------------------------------
        public async Task<bool> CreateUserAsync(string username, string password)
        {
            using var db = new ProductionDbContext();

            if (await db.AppUsers.AnyAsync(u => u.Username == username))
                return false; // Username exists

            var salt = GenerateSalt();
            var hash = HashPassword(password, salt);

            db.AppUsers.Add(new AppUser
            {
                Username = username,
                PasswordSalt = salt,
                HashedPassword = hash,
                LastLogin = null
            });

            await db.SaveChangesAsync();
            return true;
        }

        // ------------------------------
        // PBKDF2 IMPLEMENTATION BELOW
        // ------------------------------

        private static string GenerateSalt()
        {
            byte[] saltBytes = new byte[SaltSize];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }

        private static string HashPassword(string password, string saltBase64)
        {
            var salt = Convert.FromBase64String(saltBase64);

            using var pbkdf2 = new Rfc2898DeriveBytes(
                password,
                salt,
                Iterations,
                HashAlgorithmName.SHA256);

            var key = pbkdf2.GetBytes(KeySize);

            return Convert.ToBase64String(key);
        }

        private static bool VerifyPassword(string password, string saltBase64, string storedHashBase64)
        {
            string hash = HashPassword(password, saltBase64);
            return SlowEquals(storedHashBase64, hash);
        }

        // Timing-safe comparison
        private static bool SlowEquals(string a, string b)
        {
            var aBytes = Encoding.UTF8.GetBytes(a);
            var bBytes = Encoding.UTF8.GetBytes(b);

            uint diff = (uint)aBytes.Length ^ (uint)bBytes.Length;

            for (int i = 0; i < aBytes.Length && i < bBytes.Length; i++)
                diff |= (uint)(aBytes[i] ^ bBytes[i]);

            return diff == 0;
        }

    }
}
