#addin "Cake.FileHelpers"

using System.Text.RegularExpressions;

public string GetAssemblyVersion(string filePath)
{
    var versionNumbers = FindRegexMatchesGroupsInFile(
        new FilePath(filePath),
        "<Version>(\\d+).(\\d+).(\\d+)</Version>",
        RegexOptions.Multiline);

    var major = versionNumbers[0][1];
    var minor = versionNumbers[0][2];
    var patch = versionNumbers[0][3];

    return $"{major}.{minor}.{patch}";
}
