using System.IO;
using System.IO.Compression;
using SharpFuzz;

namespace ZipArchiveFuzzer;

public class Program
{
    public static void Main(string[] args)
    {
        Fuzzer.LibFuzzer.RunAndIgnoreExceptions(span =>
        {
            using var stream = new MemoryStream(span.ToArray());
            using var archive = new ZipArchive(stream, ZipArchiveMode.Read);

            foreach (var entry in archive.Entries)
            {
                using var source = entry.Open();
                using var destination = new MemoryStream();

                source.CopyTo(destination);
            }
        });
    }
}
