@echo off
echo ============================================
echo    Calculator xUnit Test Runner
echo ============================================
echo.

echo Running all tests...
echo.
dotnet test --verbosity normal --logger "console;verbosity=detailed"

echo.
echo ============================================
echo Test run completed!
echo ============================================
pause
