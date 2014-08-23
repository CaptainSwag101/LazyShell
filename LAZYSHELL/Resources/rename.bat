@echo off
setlocal enabledelayedexpansion

for /R %%F in (*.gif*) do (
    set name=%%~nxF
    set name=!name:.gif=.png!
    rename "%%~fF" "!name!"
)

exit /B 0