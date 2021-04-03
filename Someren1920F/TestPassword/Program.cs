using PasswordEncryption;
using System;
using System.Security.Cryptography;

namespace TestPassword
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Start();
        }

        void Start()
        {
            PasswordWithSaltHasher pwHasher = new PasswordWithSaltHasher();
            HashWithSaltResult hashResultSha256 = pwHasher.HashWithSalt("testPassword", 64, SHA256.Create());
            HashWithSaltResult hashResultSha512 = pwHasher.HashWithSalt("anotherTestPassword", 64, SHA512.Create());

            Console.WriteLine(hashResultSha256.Salt);
            Console.WriteLine(hashResultSha256.Digest);
            Console.WriteLine();
            Console.WriteLine(hashResultSha512.Salt);
            Console.WriteLine(hashResultSha512.Digest);

            Console.ReadKey();
        }

        void Testing()
        {

        }
    }
}
