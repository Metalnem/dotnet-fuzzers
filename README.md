# Fuzzing projects for .NET Core BCL

[![Build Status][build-shield]][build-link]
[![License][license-shield]][license-link]

[build-shield]: https://github.com/metalnem/dotnet-fuzzers/actions/workflows/dotnet.yml/badge.svg
[build-link]: https://github.com/Metalnem/dotnet-fuzzers/actions/workflows/dotnet.yml
[license-shield]: https://img.shields.io/badge/license-MIT-blue.svg?style=flat
[license-link]: https://github.com/metalnem/dotnet-fuzzers/blob/master/LICENSE

SharpFuzz fuzzing projects for the following .NET Core classes:

### [System.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

```powershell
.\fuzz.ps1 `
  -project .\src\DateTimeFuzzer\DateTimeFuzzer.csproj `
  -corpus .\src\DateTimeFuzzer\Testcases\ `
  -targetDlls System.Private.CoreLib.dll `
  -namespaces "System.DateTime,System.Globalization.DateTime"
```

### [System.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double)

```powershell
.\fuzz.ps1 `
  -project .\src\DoubleFuzzer\DoubleFuzzer.csproj `
  -corpus .\src\DoubleFuzzer\Testcases\ `
  -targetDlls System.Private.CoreLib.dll `
  -namespaces "System.Number"
```

### [System.IO.Compression.ZipArchive](https://learn.microsoft.com/en-us/dotnet/api/system.io.compression.ziparchive)

```powershell
.\fuzz.ps1 `
  -project .\src\ZipArchiveFuzzer\ZipArchiveFuzzer.csproj `
  -corpus .\src\ZipArchiveFuzzer\Testcases\ `
  -targetDlls System.IO.Compression.dll
```

### [System.Net.IPAddress](https://learn.microsoft.com/en-us/dotnet/api/system.net.ipaddress)

```powershell
.\fuzz.ps1 `
  -project .\src\IPAddressFuzzer\IPAddressFuzzer.csproj `
  -corpus .\src\IPAddressFuzzer\Testcases\ `
  -targetDlls System.Net.Primitives.dll
```

### [System.Numerics.BigInteger](https://learn.microsoft.com/en-us/dotnet/api/system.numerics.biginteger)

```powershell
.\fuzz.ps1 `
  -project .\src\BigIntegerFuzzer\BigIntegerFuzzer.csproj `
  -corpus .\src\BigIntegerFuzzer\Testcases\ `
  -targetDlls System.Runtime.Numerics.dll
```

### [System.Security.Cryptography.RSA](https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.rsa)

```powershell
.\fuzz.ps1 `
  -project .\src\RSAFuzzer\RSAFuzzer.csproj `
  -corpus .\src\RSAFuzzer\Testcases\ `
  -targetDlls System.Formats.Asn1.dll,System.Security.Cryptography.dll
```

### [System.Text.Json.JsonSerializer](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializer)

```powershell
.\fuzz.ps1 `
  -project .\src\JsonSerializerFuzzer\JsonSerializerFuzzer.csproj `
  -corpus .\src\JsonSerializerFuzzer\Testcases\ `
  -targetDlls System.Text.Json.dll `
  -dict .\dictionaries\json.dict
```

### [System.Uri](https://learn.microsoft.com/en-us/dotnet/api/system.uri)

```powershell
.\fuzz.ps1 `
  -project .\src\UriFuzzer\UriFuzzer.csproj `
  -corpus .\src\UriFuzzer\Testcases\ `
  -targetDlls System.Private.Uri.dll
```

### [System.Xml.XmlReader](https://learn.microsoft.com/en-us/dotnet/api/system.xml.xmlreader)

```powershell
.\fuzz.ps1 `
  -project .\src\XmlReaderFuzzer\XmlReaderFuzzer.csproj `
  -corpus .\src\XmlReaderFuzzer\Testcases\ `
  -targetDlls System.Private.Xml.dll `
  -dict .\dictionaries\xml.dict
```
