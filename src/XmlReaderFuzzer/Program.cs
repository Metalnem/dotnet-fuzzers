using System.IO;
using System.Xml;
using SharpFuzz;

namespace XmlReaderFuzzer;

public class Program
{
    public static void Main(string[] args)
    {
        Fuzzer.LibFuzzer.Run(span =>
        {
            try
            {
                using var stream = new MemoryStream(span.ToArray());
                using var xml = XmlReader.Create(stream);

                while (xml.Read())
                {
                    if (xml.NodeType == XmlNodeType.Text)
                    {
                        _ = xml.Value;
                    }
                    else if (xml.NodeType == XmlNodeType.Element && xml.HasAttributes)
                    {
                        while (xml.MoveToNextAttribute())
                        {
                            _ = xml.Value;
                        }

                        xml.MoveToElement();
                    }
                }
            }
            catch { }
        });
    }
}
