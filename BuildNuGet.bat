@echo off

rem Parameters
set PROJECT=src\MvvmDialogs\MvvmDialogs.csproj
set MSBUILD="%WINDIR%\Microsoft.NET\Framework\v4.0.30319\MsBuild.exe"
set NUGET=src\.nuget\NuGet.exe

rem Build project in all .NET versions
%MSBUILD% %PROJECT% /t:Rebuild /p:Configuration=Release;TargetFrameworkVersion=v3.5 /m
%MSBUILD% %PROJECT% /t:Rebuild /p:Configuration=Release;TargetFrameworkVersion=v4.0 /m
%MSBUILD% %PROJECT% /t:Rebuild /p:Configuration=Release;TargetFrameworkVersion=v4.5 /m

rem Create nuget package
%NUGET% pack -Prop Configuration=Release %PROJECT%

pause