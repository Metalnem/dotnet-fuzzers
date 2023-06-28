using System;
using System.Text;
using SharpFuzz;

namespace UriFuzzer;

public class Program
{
    public static void Main()
    {
        Fuzzer.LibFuzzer.Run(span =>
        {
            try
            {
                var s = Encoding.UTF8.GetString(span);
                Uri.TryCreate(s, UriKind.RelativeOrAbsolute, out _);
            }
            catch { }
        });
    }
}
