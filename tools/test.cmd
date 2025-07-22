@echo off
echo Testing notification-banner with various argument combinations...
echo.

REM Check if /build argument was given
set BUILD_ARG=false
for %%A in (%*) do (
    if /I "%%A"=="/build" set BUILD_ARG=true
)

if "%BUILD_ARG%"=="true" (
    echo Building project...
    dotnet build --nologo notification-banner.csproj
    if %ERRORLEVEL% neq 0 (
        echo Build failed!
        pause
        exit /b 1
    )
    echo Build successful!
    echo.
)

REM Get the path to the built executable
set EXE_NAME=banner.dll
set EXE_PATH=bin\Debug\net8.0-windows10.0.19041.0\%EXE_NAME%

REM Helper: Start dotnet minimized/hidden
set START_CMD=start "" /min dotnet %EXE_PATH%

REM Test 1: Basic notification
echo Test 1: Basic notification
start "" dotnet %EXE_PATH% --message "This is a basic test notification" --title "Basic Test" --time 2
timeout /t 3 /nobreak >nul
echo.

REM Test 2: Notification with custom time
echo Test 2: Notification with 5 second timeout
%START_CMD% --message "This notification will show for 5 seconds" --title "Timeout Test" --time 5
timeout /t 6 /nobreak >nul
echo.

REM Test 3: Different positions
echo Test 3: Top-left position
%START_CMD% --message "Top-left notification" --title "Position Test" --position topleft --time 2
timeout /t 3 /nobreak >nul

echo Test 3b: Top-center position
%START_CMD% --message "Top-center notification" --title "Position Test" --position topcenter --time 2
timeout /t 3 /nobreak >nul

echo Test 3c: Top-right position
%START_CMD% --message "Top-right notification" --title "Position Test" --position topright --time 2
timeout /t 3 /nobreak >nul

echo Test 3d: Bottom-left position
%START_CMD% --message "Bottom-left notification" --title "Position Test" --position bottomleft --time 2
timeout /t 3 /nobreak >nul

echo Test 3e: Bottom-center position
%START_CMD% --message "Bottom-center notification" --title "Position Test" --position bottomcenter --time 2
timeout /t 3 /nobreak >nul

echo Test 3f: Bottom-right position
%START_CMD% --message "Bottom-right notification" --title "Position Test" --position bottomright --time 2
timeout /t 3 /nobreak >nul

echo Test 3g: Center position
%START_CMD% --message "Center notification" --title "Position Test" --position center --time 2
timeout /t 3 /nobreak >nul
echo.

REM Test 4: Exit after notification (moved to end)
echo Test 4: Exit after notification test (will run last)
echo.

REM Test 5: Long messages
echo Test 5: Long message test
%START_CMD% --message "This is a very long notification message that should wrap to multiple lines and test how the banner handles longer text content" --title "Long Message Test" --time 2
timeout /t 3 /nobreak >nul
echo.

REM Test 6: Special characters (simplified)
echo Test 6: Special characters test
%START_CMD% --message "Special chars: !@#^$%%^&*()_+-=[]{}^|;':^\",./^<^>?" --title "Special Chars" --time 2
timeout /t 3 /nobreak >nul
echo.

REM Test 7: Unicode characters
echo Test 7: Unicode characters test
%START_CMD% --message "Unicode: 你好世界 🌍 🚀 ⭐" --title "Unicode Test" --time 2
timeout /t 3 /nobreak >nul
echo.

REM Test 7b: Base64 encoded image
echo Test 7b: Base64 encoded image test
set /p BASE64_IMAGE=<tools\test.image.b64
%START_CMD% --message "This notification has a base64 encoded image" --title "Base64 Image Test" --image "%BASE64_IMAGE%" --time 2
timeout /t 3 /nobreak >nul
echo.

REM Test 7c: Image URL test
echo Test 7c: Image URL test
%START_CMD% --message "This notification has an image from URL" --title "Image URL Test" --image "https://raw.githubusercontent.com/microsoft/fluentui-system-icons/main/assets/Info/SVG/ic_fluent_info_24_regular.svg" --time 2
timeout /t 3 /nobreak >nul
echo.

REM Test 8: Multiple notifications (should queue)
echo Test 8: Multiple notifications (should queue)
%START_CMD% --message "First notification" --title "Queue Test 1" --time 2
timeout /t 1 /nobreak >nul
%START_CMD% --message "Second notification" --title "Queue Test 2" --time 2
timeout /t 1 /nobreak >nul
%START_CMD% --message "Third notification" --title "Queue Test 3" --time 2
timeout /t 5 /nobreak >nul
echo.

REM Test 9: Command line arguments (positional)
echo Test 9: Positional arguments
%START_CMD% "This is a message" "This is a title" --time 2
timeout /t 3 /nobreak >nul
echo.

REM Test 10: Minimal arguments
echo Test 10: Minimal arguments (just message)
%START_CMD% --message "Minimal notification" --time 2
timeout /t 3 /nobreak >nul
echo.

REM Test 11: Different time formats
echo Test 11: Very short timeout
%START_CMD% --message "Very short notification" --title "Short Timeout" --time 1
timeout /t 2 /nobreak >nul

echo Test 11b: Long timeout
%START_CMD% --message "Long timeout notification" --title "Long Timeout" --time 15
timeout /t 5 /nobreak >nul
echo.

REM Test 12: Error cases
echo Test 12: No message (should show error)
%START_CMD% --title "No Message Test" --time 2
timeout /t 2 /nobreak >nul
echo.

REM Test 13: Exit after notification (final test)
echo Test 13: Exit after notification (should exit immediately)
%START_CMD% --message "This notification should exit the app" --title "Exit Test" --exit --time 2
timeout /t 2 /nobreak >nul
echo.

REM Test 13b: notification after exit (should spawn new process)
echo Test 13b: Notification after exit
%START_CMD% --message "this is after exit" --title "After Exit Test" --time 2
timeout /t 3 /nobreak >nul
echo.

REM Kill any remaining NotificationBanner processes (cleanup)
taskkill /IM "%EXE_NAME%" /F >nul 2>&1
taskkill /IM "dotnet.exe" /F >nul 2>&1
REM (dotnet.exe may be used by other apps; this is a broad cleanup for test context)

echo All tests completed!
echo.
pause 