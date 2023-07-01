using System;
using System.Text;
using SharpFuzz;

namespace UriFuzzer;

public class Program
{
    public static void Main()
    {
        Fuzzer.LibFuzzer.RunAndIgnoreExceptions(span =>
        {
            var s = Encoding.UTF8.GetString(span);
            Uri.TryCreate(s, UriKind.RelativeOrAbsolute, out _);
        });
    }
}
