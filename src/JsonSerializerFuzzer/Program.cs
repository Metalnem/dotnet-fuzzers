using System;
using System.Collections.Generic;
using System.Text.Json;
using SharpFuzz;

namespace JsonSerializerFuzzer;

public class Item
{
    public byte A { get; set; } = 123;
    public int B { get; set; } = 1024;
    public double C { get; set; } = 3.1415;
    public DateTime D { get; set; } = new DateTime(2010, 10, 15, 8, 45, 30, 875);
    public string E { get; set; } = "2.71828";
    public short[] F { get; set; } = new short[] { 1, 2, 3, 4 };
    public Item G { get; set; } = new Item { A = 1 };

    public Dictionary<string, int> H { get; set; } = new Dictionary<string, int>
    {
        ["10"] = 10,
        ["20"] = 20
    };
}

public class Program
{
    public static void Main()
    {
        Fuzzer.LibFuzzer.Run(span =>
        {
            try
            {
                JsonSerializer.Deserialize<Item>(span);
            }
            catch { }
        });
    }
}
