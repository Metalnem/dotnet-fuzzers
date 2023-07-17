using System;
using System.Globalization;
using System.Linq;
using System.Text;
using SharpFuzz;

namespace DoubleFuzzer;

public class Program
{
    public static void Main()
    {
        var formats = new string[] { "C", "E", "F", "G", "N", "P", "R" };
        var digits = Enumerable.Range(0, 10);

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

            foreach (var format in formats)
            {
                foreach (var digit in digits)
                {
                    try
                    {
                        d1.ToString($"{format}{digit}");
                    }
                    catch { }
                }
            }
        });
    }
}
