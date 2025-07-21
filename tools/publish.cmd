@echo off
setlocal enabledelayedexpansion

REM Bump version in notification-banner.csproj
set "csproj=..\notification-banner.csproj"
for /f "tokens=2 delims=> <" %%A in ('findstr /i "<Version>" %csproj%') do set version=%%A
for /f "tokens=1-4 delims=." %%a in ("!version!") do (
    set /a build=%%d+1
    set /a minor=%%c
    set /a patch=%%b
    set /a major=%%a
    if !build! gtr 9 (
        set /a build=0
        set /a patch+=1
    )
    REM If patch ever needs to roll over, add logic here
    set newversion=!major!.!patch!.!minor!.!build!
)
REM Update the csproj file
powershell -Command "(Get-Content %csproj%) -replace '<Version>.*</Version>', '<Version>!newversion!</Version>' | Set-Content %csproj%"

dotnet clean

dotnet publish -c Release -r win-x86 --self-contained true /p:PublishSingleFile=true /p:IncludeAllContentForSelfExtract=true
@REM /p:PublishTrimmed=true

set params=--message "Custom message" --title "Custom title" --time 5 --position center --image "https://github.com/kukuxx/HA-NotifyHelper/blob/master/doc/icon.png?raw=true"
bin\Release\net8.0-windows\win-x86\publish\banner.exe %params% 
@REM dotnet run -- %params% 