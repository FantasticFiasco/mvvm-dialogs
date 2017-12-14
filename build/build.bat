set SOLUTION=MvvmDialogs.sln
set NUSPEC=MvvmDialogs.nuspec
set NETPROJECT=src\net\MvvmDialogs.csproj
set UNIVERSALPROJECT=src\universal\MvvmDialogs.csproj
set LOGGER=C:\Program Files\AppVeyor\BuildAgent\Appveyor.MSBuildLogger.dll

nuget restore %SOLUTION%
  
rem Build solution in default configuration
msbuild %SOLUTION% /t:Rebuild /p:Configuration=Release /m /logger:"%LOGGER%"

rem Build .NET project in additional versions
msbuild %NETPROJECT% /t:Rebuild /p:Configuration=Release;TargetFrameworkVersion=v4.0 /m /logger:"%LOGGER%"
msbuild %NETPROJECT% /t:Rebuild /p:Configuration=Release;TargetFrameworkVersion=v3.5 /m /logger:"%LOGGER%"

if not %APPVEYOR_REPO_BRANCH%==master set VERSION_SUFFIX=-beta
nuget pack %NUSPEC% -version %APPVEYOR_BUILD_VERSION%%VERSION_SUFFIX%