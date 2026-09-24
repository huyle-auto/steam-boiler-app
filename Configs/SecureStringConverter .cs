using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SteamBoilerApp.Configs
{
    public class SecureStringConverter : JsonConverter<SecureString>
    {
        public override SecureString Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? stringValue = reader.GetString();
            if (stringValue == null) return null;

            var secureString = new SecureString();
            foreach (char c in stringValue)
            {
                secureString.AppendChar(c);
            }

            // It is recommended to make the SecureString read-only immediately after creation
            secureString.MakeReadOnly();
            return secureString;
        }

        public override void Write(Utf8JsonWriter writer, SecureString value, JsonSerializerOptions options)
        {
            // Warning: Exporting a SecureString back to plaintext JSON exposes sensitive data in memory!
            throw new NotSupportedException("Serialization of SecureString is disabled for security reasons.");
        }
    }
}
