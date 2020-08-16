#load "utils.cake"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");

//////////////////////////////////////////////////////////////////////
// VARIABLES
//////////////////////////////////////////////////////////////////////

var solution = new FilePath("./../MvvmDialogs.sln");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Description("Clean all files")
    .Does(() =>
    {
        DeleteFiles("./../**/*.nupkg");
	    CleanDirectories("./../**/bin");
	    CleanDirectories("./../**/obj");
    });

Task("Restore")
    .Description("Restore NuGet packages")
    .IsDependentOn("Clean")
    .Does(() =>
    {
        NuGetRestore(solution);
    });

Task("Build")
    .Description("Build the solution")
    .IsDependentOn("Restore")
    .Does(() =>
    {
        MSBuild(
            solution,
            new MSBuildSettings
            {
                Configuration = "Release",
                MaxCpuCount = 0,            // Enable parallel build
            });
    });

Task("Pack")
    .Description("Create NuGet package")
    .IsDependentOn("Build")
    .Does(() =>
    {
        var versionPrefix = GetVersionPrefix("./../Directory.Build.props");
        var versionSuffix = GetVersionSuffix("./../Directory.Build.props");
        var isTag = EnvironmentVariable("APPVEYOR_REPO_TAG");

        // Unless this is a tag, this is a pre-release
        if (isTag != "true")
        {
            var sha = EnvironmentVariable("APPVEYOR_REPO_COMMIT");
            versionSuffix = $"sha-{sha}";
        }

        NuGetPack(
            "./../MvvmDialogs.nuspec",
            new NuGetPackSettings
            {
                Version = versionPrefix,
                Suffix = versionSuffix,
                Symbols = true,
                ArgumentCustomization = args => args.Append("-SymbolPackageFormat snupkg")
            });
    });

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Pack");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
