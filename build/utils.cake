#addin "Cake.FileHelpers"

using System.Text.RegularExpressions;

public string GetVersionPrefix(string filePath)
{
    var matches = FindRegexMatchesGroupsInFile(
        new FilePath(filePath),
        "<VersionPrefix>(\\d+).(\\d+).(\\d+)</VersionPrefix>",
        RegexOptions.Multiline);

    var major = matches[0][1];
    var minor = matches[0][2];
    var patch = matches[0][3];

    return $"{major}.{minor}.{patch}";
}

public string GetVersionSuffix(string filePath)
{
    var matches = FindRegexMatchesGroupsInFile(
        new FilePath(filePath),
        "<VersionSuffix>(.*)</VersionSuffix>",
        RegexOptions.Multiline);

    return $"{matches[0][1]}";
}