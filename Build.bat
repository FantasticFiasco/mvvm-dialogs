@echo off

rem Parameters
set SOLUTION=src\MvvmDialogs.sln
set PROJECT=src\MvvmDialogs\MvvmDialogs.csproj
set MSBUILD="%WINDIR%\Microsoft.NET\Framework\v4.0.30319\MsBuild.exe"
set NUGET=src\.nuget\NuGet.exe

rem Build solution
%MSBUILD% %SOLUTION% /t:Rebuild /p:Configuration=Release /m

REM Create nuget package
%NUGET% pack -Prop Configuration=Release %PROJECT%

pause