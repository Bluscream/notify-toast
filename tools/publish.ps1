# PowerShell script to bump version, publish, and run the app
$csproj = "notification-banner.csproj"
$arch = "win-x86"
$bin = "bin/Release/net8.0-windows/$arch/publish/banner.exe"

function Bump-Version {
    param([string]$csproj)
    [xml]$projXml = Get-Content $csproj
    $versionNode = $projXml.Project.PropertyGroup | Where-Object { $_.Version } | Select-Object -First 1
    if (-not $versionNode) {
        Write-Error "No <Version> property found in any <PropertyGroup> in $csproj"
        exit 1
    }
    $version = $versionNode.Version
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
    Write-Host "Bumped Version: $newVersion"
    return @{ Xml = $projXml; VersionNode = $versionNode; NewVersion = $newVersion }
}
function Set-Version {
    param(
        [xml]$projXml,
        $versionNode,
        [string]$newVersion,
        [string]$csproj
    )
    $versionNode.Version = $newVersion
    $projXml.Save($csproj)
    Write-Host "Updated version to $newVersion"
}

# Bump version and update csproj
$result = Bump-Version -csproj $csproj
# Set-Version -projXml $result.Xml -versionNode $result.VersionNode -newVersion $result.NewVersion -csproj $csproj
Set-Version -projXml $result.Xml -versionNode $result.VersionNode -newVersion "3.0.0.0" -csproj $csproj




# Kill running app if needed
Get-Process banner -ErrorAction SilentlyContinue | Stop-Process -Force

# Clean and publish
dotnet clean
dotnet publish -c Release -r "$arch" --self-contained true /p:PublishSingleFile=true /p:IncludeAllContentForSelfExtract=true

Copy-Item -Path $bin -Destination "D:\Scripts\banner.exe" -Force

# Run the published app with test params
$params = @('--message', 'Custom message', '--title', 'Custom title', '--time', '5', '--position', 'center', '--image', 'https://github.com/kukuxx/HA-NotifyHelper/blob/master/doc/icon.png?raw=true')
& $bin @params 