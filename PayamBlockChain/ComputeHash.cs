using System;
using System.Security.Cryptography;
using System.Text;

namespace PayamBlockChain
{
    public class ComputeHash:IComputeHash
    {
        public byte[] ComputeHashSha256(byte[] toBeHashed)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(toBeHashed);
            }
        }

        public byte[] ComputeHashSha512(byte[] toBeHashed)
        {
            using (var sha256 = SHA512.Create())
            {
                return sha256.ComputeHash(toBeHashed);
            }
        }

        public string GetHash256(string toBeHashed, string key)
        {
            var keyToUse = Encoding.UTF8.GetBytes(key);
            var message = Encoding.UTF8.GetBytes(toBeHashed);
            using (var hmac = new HMACSHA256(keyToUse))
            {
                return Convert.ToBase64String(hmac.ComputeHash(message));
            }
        }

        public string GetHash512(string toBeHashed, string key)
        {
            var keyToUse = Encoding.UTF8.GetBytes(key);
            var message = Encoding.UTF8.GetBytes(toBeHashed);
            using (var hmac = new HMACSHA512(keyToUse))
            {
                return Convert.ToBase64String(hmac.ComputeHash(message));
            }
        }  
    }
}