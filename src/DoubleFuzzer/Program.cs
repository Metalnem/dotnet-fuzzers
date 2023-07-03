using System;
using System.Globalization;
using System.Text;
using SharpFuzz;

namespace DoubleFuzzer;

public class Program
{
    public static void Main()
    {
        Fuzzer.LibFuzzer.Run(span =>
        {
            string s1 = Encoding.UTF8.GetString(span);

            if (!double.TryParse(s1, NumberStyles.Any, null, out var d1) || double.IsNaN(d1))
            {
                return;
            }

            var s2 = d1.ToString("R");
            var d2 = double.Parse(s2);

            if (d1 != d2)
            {
                throw new Exception();
            }
        });
    }
}
