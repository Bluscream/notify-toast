@echo off
echo Testing notification-banner with various argument combinations...
echo.

REM Check if /build argument was given
set BUILD_ARG=false
for %%A in (%*) do (
    if /I "%%A"=="/build" set BUILD_ARG=true
)

REM Get the path to the built executable
set EXE_NAME=banner.dll
set EXE_PATH=bin\Debug\net8.0-windows10.0.19041.0\%EXE_NAME%

if "%BUILD_ARG%"=="true" (
    taskkill /IM "%EXE_NAME%" /F >nul 2>&1
    taskkill /IM "dotnet.exe" /F >nul 2>&1
    echo Building project...
    dotnet build --nologo notification-banner.csproj
    if %ERRORLEVEL% neq 0 (
        echo Build failed!
        pause
        exit /b 1
    )
    REM Try to parse build time from output (optional, for pretty output)
    REM If you want to show "Build succeeded in Xs", you could parse the output here.
    echo Build successful!
    echo.
)

REM Helper: Start dotnet minimized/hidden
set START_CMD=start "" /min dotnet %EXE_PATH%
set DEFAULT_TIME=1

REM Allow user to jump to a specific test by passing /test:X or --test:X or -test:X
set "TEST_JUMP="
for %%A in (%*) do (
    set "ARG=%%A"
    call :CHECK_TEST_JUMP
)
goto :AFTER_TEST_JUMP_PARSE

:CHECK_TEST_JUMP
    setlocal enabledelayedexpansion
    set "A=!ARG!"
    if /I "!A:~0,6!"=="/test:" (
        endlocal & set "TEST_JUMP=!A:~6!" & goto :EOF
    )
    if /I "!A:~0,7!"=="--test:" (
        endlocal & set "TEST_JUMP=!A:~7!" & goto :EOF
    )
    if /I "!A:~0,6!"=="-test:" (
        endlocal & set "TEST_JUMP=!A:~6!" & goto :EOF
    )
    endlocal
    goto :EOF

:AFTER_TEST_JUMP_PARSE

REM Jump to the requested test if specified
if defined TEST_JUMP (
    call :CHECK_LABEL_EXISTS "TEST_%TEST_JUMP%"
    if errorlevel 1 (
        echo The test label TEST_%TEST_JUMP% does not exist.
        goto :END
    )
    goto TEST_%TEST_JUMP%
)

REM Helper to check if a label exists in this file
:CHECK_LABEL_EXISTS
    setlocal
    set "LABEL=%~1"
    set "FOUND=0"
    for /f "delims=:" %%L in ('findstr /b /c:":%LABEL%" "%~f0"') do (
        set "FOUND=1"
    )
    endlocal & if "%FOUND%"=="1" (exit /b 0) else (exit /b 1)

:TEST_1
REM Test 1: Basic notification
echo Test 1: Basic notification
start "" dotnet %EXE_PATH% --message "This is a basic test notification" --title "Basic Test" --time %DEFAULT_TIME%
timeout /t 3 /nobreak >nul
echo.

:TEST_3b
echo Test 3b: Top-center position
%START_CMD% --message "Top-center notification" --title "Position Test" --position topcenter --time %DEFAULT_TIME%
timeout /t 3 /nobreak >nul

:TEST_3c
echo Test 3c: Top-right position
%START_CMD% --message "Top-right notification" --title "Position Test" --position topright --time %DEFAULT_TIME%
timeout /t 3 /nobreak >nul

:TEST_3d
echo Test 3d: Bottom-left position
%START_CMD% --message "Bottom-left notification" --title "Position Test" --position bottomleft --time %DEFAULT_TIME%
timeout /t 3 /nobreak >nul

:TEST_3e
echo Test 3e: Bottom-center position
%START_CMD% --message "Bottom-center notification" --title "Position Test" --position bottomcenter --time %DEFAULT_TIME%
timeout /t 3 /nobreak >nul

:TEST_3f
echo Test 3f: Bottom-right position
%START_CMD% --message "Bottom-right notification" --title "Position Test" --position bottomright --time %DEFAULT_TIME%
timeout /t 3 /nobreak >nul

:TEST_3g
echo Test 3g: Center position
%START_CMD% --message "Center notification" --title "Position Test" --position center --time %DEFAULT_TIME%
timeout /t 3 /nobreak >nul
echo.

:TEST_5
REM Test 5: Long messages
echo Test 5: Long message test
%START_CMD% --message "This is a very long notification message that should wrap to multiple lines and test how the banner handles longer text content" --title "Long Message Test" --time %DEFAULT_TIME%
timeout /t 3 /nobreak >nul
echo.

:TEST_6
REM Test 6: Special characters (simplified)
echo Test 6: Special characters test
%START_CMD% --message "Special chars: !@#^$%%^&*()_+-=[]{}^|;':^\",./^<^>?" --title "Special Chars" --time %DEFAULT_TIME%
timeout /t 3 /nobreak >nul
echo.

:TEST_7
REM Test 7: Unicode characters
echo Test 7: Unicode characters test
%START_CMD% --message "Unicode: 你好世界 🌍 🚀 ⭐" --title "Unicode Test" --time %DEFAULT_TIME%
timeout /t 3 /nobreak >nul
echo.

:TEST_7b
REM Test 7b: Base64 encoded image
echo Test 7b: Base64 encoded image test
set /p BASE64_IMAGE=<tools\test.image.b64
%START_CMD% --message "This notification has a base64 encoded image" --title "Base64 Image Test" --image "%BASE64_IMAGE%" --time %DEFAULT_TIME%
timeout /t 3 /nobreak >nul
echo.

:TEST_7c
REM Test 7c: Image URL test
echo Test 7c: Image URL test
%START_CMD% --message "This notification has an image from URL" --title "Image URL Test" --image "https://raw.githubusercontent.com/microsoft/fluentui-system-icons/main/assets/Info/SVG/ic_fluent_info_24_regular.svg" --time %DEFAULT_TIME%
timeout /t 3 /nobreak >nul
echo.

:TEST_8
REM Test 8: Multiple notifications (should queue)
echo Test 8: Multiple notifications (should queue)
%START_CMD% --message "First notification" --title "Queue Test 1" --time %DEFAULT_TIME%
timeout /t 1 /nobreak >nul
%START_CMD% --message "Second notification" --title "Queue Test 2" --time %DEFAULT_TIME%
timeout /t 1 /nobreak >nul
%START_CMD% --message "Third notification" --title "Queue Test 3" --time %DEFAULT_TIME%
timeout /t 5 /nobreak >nul
echo.

:TEST_9
REM Test 9: Command line arguments (positional)
echo Test 9: Positional arguments
%START_CMD% "This is a message" "This is a title" --time %DEFAULT_TIME%
timeout /t 3 /nobreak >nul
echo.

:TEST_10
REM Test 10: Minimal arguments
echo Test 10: Minimal arguments (just message)
%START_CMD% --message "Minimal notification" --time %DEFAULT_TIME%
timeout /t 3 /nobreak >nul
echo.

:TEST_11
REM Test 11: Different time formats
echo Test 11: Very short timeout
%START_CMD% --message "Very short notification" --title "Short Timeout" --time 1
timeout /t 2 /nobreak >nul

:TEST_11b
echo Test 11b: Long timeout
%START_CMD% --message "Long timeout notification" --title "Long Timeout" --time 15
timeout /t 5 /nobreak >nul
echo.

:TEST_12
REM Test 12: Error cases
echo Test 12: No message (should show error)
%START_CMD% --title "No Message Test" --time %DEFAULT_TIME%
timeout /t 2 /nobreak >nul
echo.

:TEST_14a
REM Test 14: Color and opacity tests
echo Test 14a: Fully opaque black
%START_CMD% --message "Opaque black" --title "Color Test" --color "#FF000000" --time %DEFAULT_TIME%
timeout /t 3 /nobreak >nul
echo.

:TEST_14b
echo Test 14b: Fully opaque white
%START_CMD% --message "Opaque white" --title "Color Test" --color "#FFFFFFFF" --time %DEFAULT_TIME%
timeout /t 3 /nobreak >nul
echo.

:TEST_14c
echo Test 14c: 50% transparent red
%START_CMD% --message "50%% transparent red" --title "Color Test" --color "#80FF0000" --time %DEFAULT_TIME%
timeout /t 3 /nobreak >nul
echo.

:TEST_14d
echo Test 14d: 25% transparent green
%START_CMD% --message "25%% transparent green" --title "Color Test" --color "#40FF00FF" --time %DEFAULT_TIME%
timeout /t 3 /nobreak >nul
echo.

:TEST_14e
echo Test 14e: Fully transparent (should be invisible)
%START_CMD% --message "Fully transparent" --title "Color Test" --color "#00000000" --time %DEFAULT_TIME%
timeout /t 3 /nobreak >nul
echo.

:TEST_13
REM Test 13: Exit after notification (final test)
echo Test 13: Exit after notification (should exit immediately)
%START_CMD% --message "This notification should exit the app" --title "Exit Test" --exit --time %DEFAULT_TIME%
timeout /t 2 /nobreak >nul
echo.

:TEST_13b
REM Test 13b: notification after exit (should spawn new process)
echo Test 13b: Notification after exit
%START_CMD% --message "this is after exit" --title "After Exit Test" --time %DEFAULT_TIME%
timeout /t 3 /nobreak >nul
echo.

:END
echo All tests completed!
echo.
pause 
goto :EOF