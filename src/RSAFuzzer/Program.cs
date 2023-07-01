using System.Security.Cryptography;
using SharpFuzz;

namespace RSAFuzzer;

public class Program
{
    public static void Main()
    {
        Fuzzer.LibFuzzer.RunAndIgnoreExceptions(span =>
        {
            using var rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(span, out _);
        });
    }
}
