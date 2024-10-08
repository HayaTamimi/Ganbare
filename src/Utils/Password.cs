using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ganbare.src.Utils
{
    public class Password
    {
        public static void HashPassword(
            string originalPassword,
            out string hashedPassword,
            out byte[] salt
        )
        {
            var hasher = new HMACSHA256();
            salt = hasher.Key;
            hashedPassword = BitConverter.ToString(
                hasher.ComputeHash(Encoding.UTF8.GetBytes(originalPassword))
            );
        }

        public static bool VerifyPassword(string plainPassword, byte[] salt, string hashedPassword)
        {
            var hasher = new HMACSHA256();
            hasher.Key = salt;
            return BitConverter.ToString(hasher.ComputeHash(Encoding.UTF8.GetBytes(plainPassword)))
                == hashedPassword;
        }

    }
}