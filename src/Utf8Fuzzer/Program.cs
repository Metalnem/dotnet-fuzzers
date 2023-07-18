using System.Runtime.InteropServices;
using System.Text.Unicode;
using SharpFuzz;

namespace Utf8Fuzzer;

public class Program
{
    public static void Main()
    {
        var maxSize = 10_000_000;

        var utf8 = new byte[maxSize];
        var utf16 = new char[maxSize];

        Fuzzer.LibFuzzer.RunAndIgnoreExceptions(span =>
        {
            var source = MemoryMarshal.Cast<byte, char>(span);

            int charsRead;
            int bytesWritten;

            Utf8.FromUtf16(source, utf8, out charsRead, out bytesWritten);
            Utf8.ToUtf16(span, utf16, out charsRead, out bytesWritten);
        });
    }
}
