using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Common.Infrastructure.Encryptors
{
    public class PasswordEncryptor
    {
        public static string Encrypt(string password)
        {
            using var md5 = MD5.Create();
            
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var hashBytes = md5.ComputeHash(passwordBytes);

            return Convert.ToHexString(hashBytes);
        }
    }
}
