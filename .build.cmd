@echo off

echo Clean.
call rd-s-q bin
call rd-s-q obj

echo Build.
call msbuild Common.Utils.csproj /t:Rebuild /p:Configuration=Release

if %errorlevel% NEQ 0 (
	call check-error-level
	exit 1 /B
)

echo Copy to Flipdog libs.
set DIR=bin\Release
set DEST=c:\Flipdog\C#-Projects
copy /Y /B %DIR%\Common.Utils.dll %DEST%
copy /Y /B %DIR%\Common.Utils.xml %DEST%

echo Clean.
call rd-s-q bin
call rd-s-q obj