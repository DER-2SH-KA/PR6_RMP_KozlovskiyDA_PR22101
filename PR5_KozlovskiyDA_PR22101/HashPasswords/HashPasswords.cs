using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashPasswords
{
    public class HashPasswords
    {
        public static string toHashSHA256(string password) 
        {
            string result = "";

            try
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] sourceBytePassword = Encoding.UTF8.GetBytes(password);
                    byte[] hashByPass = sha256.ComputeHash(sourceBytePassword);
                    result = BitConverter.ToString(hashByPass).Replace("-", String.Empty);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            if (result == "" || result == null)
            {
                result = "Не удалось вычислить Hash";
            }

            return result;
        }
    }
}
