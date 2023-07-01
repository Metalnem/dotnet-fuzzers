using System;
using System.Collections.Generic;
using System.Text.Json;
using SharpFuzz;

namespace JsonSerializerFuzzer;

public class Item
{
    public byte A { get; set; }
    public int B { get; set; }
    public double C { get; set; }
    public DateTime D { get; set; }
    public string E { get; set; }
    public short[] F { get; set; }
    public Item G { get; set; }
    public Dictionary<string, int> H { get; set; }
}

public class Program
{
    public static void Main()
    {
        Fuzzer.LibFuzzer.RunAndIgnoreExceptions(span =>
        {
            JsonSerializer.Deserialize<Item>(span);
        });
    }
}
