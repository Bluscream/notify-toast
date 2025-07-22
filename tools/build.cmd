@echo off
set PROJECT_NAME=notification-banner
set EXE_NAME=banner.dll

taskkill /IM "%EXE_NAME%" /F >nul 2>&1
taskkill /IM "dotnet.exe" /F >nul 2>&1
echo Building project...
dotnet build --nologo %PROJECT_NAME%.csproj
if %ERRORLEVEL% neq 0 (
    echo Build failed!
    pause
    exit /b 1
)
echo Build successful!