using System.Globalization;
using System.Numerics;
using System.Text;
using SharpFuzz;

namespace BigIntegerFuzzer;

public class Program
{
    public static void Main()
    {
        Fuzzer.LibFuzzer.RunAndIgnoreExceptions(span =>
        {
            var s = Encoding.UTF8.GetString(span);
            BigInteger.TryParse(s, NumberStyles.Any, null, out var result);
        });
    }
}
