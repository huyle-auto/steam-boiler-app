using System;
using System.Collections.Generic;

namespace SteamBoilerApp.Models;

public partial class AppUser
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string HashedPassword { get; set; } = null!;

    public string PasswordSalt { get; set; } = null!;

    public DateTime? LastLogin { get; set; }

    public string Role { get; set; } = null!;
}
