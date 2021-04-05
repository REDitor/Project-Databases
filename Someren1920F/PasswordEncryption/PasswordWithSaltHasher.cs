using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace PasswordEncryption
{
    public class PasswordWithSaltHasher
    {
        public HashWithSaltResult HashWithSalt(string password, int saltLength)
        {
            HashAlgorithm hashAlgo = SHA256.Create();

            RNG rng = new RNG();

            byte[] saltBytes = rng.GenerateRandomCryptographicBytes(saltLength);
            byte[] passwordAsBytes = Encoding.UTF8.GetBytes(password);
            List<byte> passwordWithSaltBytes = new List<byte>();

            passwordWithSaltBytes.AddRange(passwordAsBytes);
            passwordWithSaltBytes.AddRange(saltBytes);

            byte[] digestBytes = hashAlgo.ComputeHash(passwordWithSaltBytes.ToArray());

            return new HashWithSaltResult(Convert.ToBase64String(saltBytes), Convert.ToBase64String(digestBytes));
        }

        public HashWithSaltResult SaltedHashInput(string password, string salt)
        {
            HashAlgorithm hashAlgo = SHA256.Create();

            byte[] passwordAsBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltAsBytes = Convert.FromBase64String(salt);
            List<byte> passwordWithSaltBytes = new List<byte>();

            passwordWithSaltBytes.AddRange(passwordAsBytes);
            passwordWithSaltBytes.AddRange(saltAsBytes);

            byte[] digestBytes = hashAlgo.ComputeHash(passwordWithSaltBytes.ToArray());

            return new HashWithSaltResult(Convert.ToBase64String(saltAsBytes), Convert.ToBase64String(digestBytes));
        }
    }
}
