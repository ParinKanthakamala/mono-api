using System;
using System.Security.Cryptography;

namespace Shared.Libraries
{
    public class PasswordHash
    {
        
        public const int SALT_BYTES = 24;
        public const int HASH_BYTES = 24;
        public const int PBKDF2_ITERATIONS = 1000;

        public const int ITERATION_INDEX = 1;
        public const int SALT_INDEX = 2;
        public const int PBKDF2_INDEX = 3;

        public static string CreateHash(string password)
        {
            // Generate a random salt
            var csprng = new RNGCryptoServiceProvider();
            var salt = new byte[SALT_BYTES];
            csprng.GetBytes(salt);

            // Hash the password and encode the parameters
            var hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTES);
            return "sha1:" + PBKDF2_ITERATIONS + ":" +
                   Convert.ToBase64String(salt) + ":" +
                   Convert.ToBase64String(hash);
        }

        public static bool ValidatePassword(string password, string goodHash)
        {
            // Extract the parameters from the hash
            char[] delimiter = {':'};
            var split = goodHash.Split(delimiter);
            var iterations = int.Parse(split[ITERATION_INDEX]);
            var salt = Convert.FromBase64String(split[SALT_INDEX]);
            var hash = Convert.FromBase64String(split[PBKDF2_INDEX]);

            var testHash = PBKDF2(password, salt, iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }
 
        private static bool SlowEquals(byte[] a, byte[] b)
        {
            var diff = (uint) a.Length ^ (uint) b.Length;
            for (var i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint) (a[i] ^ b[i]);
            return diff == 0;
        }

        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }
    }
}