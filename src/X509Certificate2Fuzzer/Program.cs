using System;
using System.Formats.Asn1;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using SharpFuzz;

namespace X509Certificate2Fuzzer;

public class Program
{
    public static void Main()
    {
        var certificateAsnTypeName = "System.Security.Cryptography.X509Certificates.Asn1.CertificateAsn";

        var certificateAsnType = typeof(X509Certificate2).Assembly.GetTypes()
            .Single(type => type.FullName == certificateAsnTypeName);

        var decodeMethod = certificateAsnType.GetMethod(
            "Decode",
            BindingFlags.NonPublic | BindingFlags.Static,
            new Type[] { typeof(ReadOnlyMemory<byte>), typeof(AsnEncodingRules) }
        );

        Fuzzer.LibFuzzer.Run(span =>
        {
            try
            {
                ReadOnlyMemory<byte> encoded = span.ToArray();
                decodeMethod.Invoke(null, new object[] { encoded, AsnEncodingRules.DER });
            }
            catch { }
        });
    }
}
