dotnet clean
dotnet publish -c Release -r win-x86 --self-contained true /p:PublishSingleFile=true /p:IncludeAllContentForSelfExtract=true
@REM /p:PublishTrimmed=true