using System.Security.Cryptography.X509Certificates;
using System.Text;
using SharpFuzz;

namespace X509Certificate2Fuzzer;

public class Program
{
    public static void Main()
    {
        Fuzzer.LibFuzzer.Run(span =>
        {
            try
            {
                var s = Encoding.ASCII.GetString(span);
                X509Certificate2.CreateFromPem(s);
            }
            catch { }
        });
    }
}
