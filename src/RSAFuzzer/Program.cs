using System.Security.Cryptography;
using SharpFuzz;

namespace RSAFuzzer;

public class Program
{
    public static void Main()
    {
        Fuzzer.LibFuzzer.Run(span =>
        {
            try
            {
                using var rsa = RSA.Create();
                rsa.ImportRSAPrivateKey(span, out _);
            }
            catch { }
        });
    }
}
