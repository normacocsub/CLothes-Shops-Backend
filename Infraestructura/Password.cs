using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura
{
    public class Password
    {
        public static string GenerateHash(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                string hashString = BitConverter.ToString(hashBytes).Replace("-", "");
                return hashString;
            }
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            string hashedPassword = GenerateHash(password);
            return hashedPassword.Equals(storedHash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
