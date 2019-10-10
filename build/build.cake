#load "utils.cake"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

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
        MSBuild(solution, settings => settings
            .SetConfiguration(configuration)
            .SetMaxCpuCount(0));    // Enable parallel build
    });

Task("Pack")
    .Description("Create NuGet package")
    .IsDependentOn("Build")
    .Does(() =>
    {
        var version = GetAssemblyVersion("./../Directory.Build.props");
        var isTag = EnvironmentVariable("APPVEYOR_REPO_TAG");

        // Unless this is a tag, this is a pre-release
        if (isTag != "true")
        {
            var sha = EnvironmentVariable("APPVEYOR_REPO_COMMIT");
            version += $"-sha-{sha}";
        }

        NuGetPack(
            "./../MvvmDialogs.nuspec",
            new NuGetPackSettings
            {
                Version = version,
                Symbols = true
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
