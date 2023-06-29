using System.Net;
using System.Text;
using SharpFuzz;

namespace IPAddressFuzzer;

public class Program
{
    public static void Main(string[] args)
    {
        Fuzzer.LibFuzzer.Run(span =>
        {
            try
            {
                var s = Encoding.UTF8.GetString(span);
                IPAddress.Parse(s);
            }
            catch { }
        });
    }
}
