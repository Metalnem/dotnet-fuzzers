param (
    [Parameter(Mandatory = $true)]
    [string]$project,
    [Parameter(Mandatory = $true)]
    [string]$corpus,
    [Parameter(Mandatory = $true)]
    [string[]]$targetDlls,
    [string]$namespaces = $null,
    [string]$dict = $null,
    [int]$timeout = 10
)

Set-StrictMode -Version Latest

$libFuzzer = "libfuzzer-dotnet-windows.exe"
$uri = "https://github.com/metalnem/libfuzzer-dotnet/releases/latest/download/$libFuzzer"

Invoke-WebRequest -Uri $uri -OutFile $libFuzzer

$outputDir = "bin"

if (Test-Path $outputDir) {
    Remove-Item -Recurse -Force $outputDir
}

dotnet tool install --global SharpFuzz.CommandLine
dotnet publish $project -c release -o $outputDir --self-contained

$projectName = (Get-Item $project).BaseName
$project = Join-Path $outputDir $projectName

$env:SHARPFUZZ_INSTRUMENT_MIXED_MODE_ASSEMBLIES = 1

foreach ($targetDll in $targetDlls) {
    $fuzzingTarget = Join-Path $outputDir $targetDll
    Write-Output "Instrumenting $fuzzingTarget"

    if ($namespaces) {
        sharpfuzz $fuzzingTarget $namespaces
    }
    else {
        sharpfuzz $fuzzingTarget
    }

    if ($LastExitCode -ne 0) {
        Write-Error "An error occurred while instrumenting $fuzzingTarget"
        exit 1
    }
}

Write-Output "$dict"

if ($dict) {
    & "./$libFuzzer" -timeout="$timeout" -dict="$dict" --target_path=$project $corpus
}
else {
    & "./$libFuzzer" -timeout="$timeout" --target_path=$project $corpus
}
