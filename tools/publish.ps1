# PowerShell script to bump version, publish, and run the app
$csproj = "notification-banner.csproj"

# Extract current version robustly
[xml]$projXml = Get-Content $csproj
$versionNode = $projXml.Project.PropertyGroup | Where-Object { $_.Version } | Select-Object -First 1
if (-not $versionNode) {
    Write-Error "No <Version> property found in any <PropertyGroup> in $csproj"
    exit 1
}
$version = $versionNode.Version

# Parse version
$parts = $version -split '\.'
$major = [int]$parts[0]
$minor = [int]$parts[1]
$patch = [int]$parts[2]
$build = [int]$parts[3]

$build++
if ($build -gt 9) {
    $build = 0
    $patch++
}
# If patch ever needs to roll over, add logic here
$newVersion = "$major.$minor.$patch.$build"

# Update the csproj file
$versionNode.Version = $newVersion
$projXml.Save($csproj)
Write-Host "Updated version to $newVersion"

# Kill running app if needed
Get-Process banner -ErrorAction SilentlyContinue | Stop-Process -Force

# Clean and publish
dotnet clean
dotnet publish -c Release -r win-x86 --self-contained true /p:PublishSingleFile=true /p:IncludeAllContentForSelfExtract=true

# Run the published app with test params
$params = @('--message', 'Custom message', '--title', 'Custom title', '--time', '5', '--position', 'center', '--image', 'https://github.com/kukuxx/HA-NotifyHelper/blob/master/doc/icon.png?raw=true')
& "bin/Release/net8.0-windows/win-x86/publish/banner.exe" @params 