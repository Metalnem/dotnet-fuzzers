using System;
using System.Globalization;
using System.Text;
using SharpFuzz;

namespace DateTimeFuzzer;

public class Program
{
    public static void Main()
    {
        Fuzzer.LibFuzzer.Run(span =>
        {
            var s1 = Encoding.UTF8.GetString(span);

            if (DateTime.TryParse(s1, out var dt1))
            {
                var s2 = dt1.ToString("O");
                var dt2 = DateTime.Parse(s2, null, DateTimeStyles.RoundtripKind);

                if (dt1 != dt2)
                {
                    throw new Exception();
                }
            }
        });
    }
}
