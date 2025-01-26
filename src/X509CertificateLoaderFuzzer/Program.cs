using System.Security.Cryptography.X509Certificates;
using SharpFuzz;

namespace X509CertificateLoaderFuzzer;

public class Program
{
	public static void Main()
	{
		Fuzzer.LibFuzzer.RunAndIgnoreExceptions(span =>
		{
			X509CertificateLoader.LoadPkcs12(span, null);
		});
	}
}
