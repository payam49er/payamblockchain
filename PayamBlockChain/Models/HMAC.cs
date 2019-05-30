using System.Security.Cryptography;

namespace PayamBlockChain.Models
{
    public class HMAC
    {
        private const int KeySize = 64;

        public static byte[] GenerateKey()
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[KeySize];
                randomNumberGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }

        public static byte[] ComputeHmacsha256(byte[] toBeHashed, byte[] key)
        {
            using (var hmac = new HMACSHA512(key))
            {
                return hmac.ComputeHash(toBeHashed);
            }
        }
    }
}