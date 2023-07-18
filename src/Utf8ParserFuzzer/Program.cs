using System;
using System.Buffers.Text;
using SharpFuzz;

namespace Utf8ParserFuzzer;

public class Program
{
    public static void Main()
    {
        var destination = new byte[10_000_000];

        Fuzzer.LibFuzzer.RunAndIgnoreExceptions(span =>
        {
            int bytesConsumed;
            int bytesWritten;

            Utf8Parser.TryParse(span, out bool v1, out bytesConsumed);
            Utf8Formatter.TryFormat(v1, destination, out bytesWritten);

            Utf8Parser.TryParse(span, out byte v2, out bytesConsumed);
            Utf8Formatter.TryFormat(v2, destination, out bytesWritten);

            Utf8Parser.TryParse(span, out DateTime v3, out bytesConsumed);
            Utf8Formatter.TryFormat(v3, destination, out bytesWritten);

            Utf8Parser.TryParse(span, out DateTimeOffset v4, out bytesConsumed);
            Utf8Formatter.TryFormat(v4, destination, out bytesWritten);

            Utf8Parser.TryParse(span, out decimal v5, out bytesConsumed);
            Utf8Formatter.TryFormat(v5, destination, out bytesWritten);

            Utf8Parser.TryParse(span, out double v6, out bytesConsumed);
            Utf8Formatter.TryFormat(v6, destination, out bytesWritten);

            Utf8Parser.TryParse(span, out Guid v7, out bytesConsumed);
            Utf8Formatter.TryFormat(v7, destination, out bytesWritten);

            Utf8Parser.TryParse(span, out short v8, out bytesConsumed);
            Utf8Formatter.TryFormat(v8, destination, out bytesWritten);

            Utf8Parser.TryParse(span, out int v9, out bytesConsumed);
            Utf8Formatter.TryFormat(v9, destination, out bytesWritten);

            Utf8Parser.TryParse(span, out long v10, out bytesConsumed);
            Utf8Formatter.TryFormat(v10, destination, out bytesWritten);

            Utf8Parser.TryParse(span, out sbyte v11, out bytesConsumed);
            Utf8Formatter.TryFormat(v11, destination, out bytesWritten);

            Utf8Parser.TryParse(span, out float v12, out bytesConsumed);
            Utf8Formatter.TryFormat(v12, destination, out bytesWritten);

            Utf8Parser.TryParse(span, out TimeSpan v13, out bytesConsumed);
            Utf8Formatter.TryFormat(v13, destination, out bytesWritten);

            Utf8Parser.TryParse(span, out ushort v14, out bytesConsumed);
            Utf8Formatter.TryFormat(v14, destination, out bytesWritten);

            Utf8Parser.TryParse(span, out uint v15, out bytesConsumed);
            Utf8Formatter.TryFormat(v15, destination, out bytesWritten);

            Utf8Parser.TryParse(span, out ulong v16, out bytesConsumed);
            Utf8Formatter.TryFormat(v16, destination, out bytesWritten);
        });
    }
}
