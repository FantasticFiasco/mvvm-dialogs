namespace MvvmDialogs.FrameworkDialogs.FolderBrowser;

public class FolderBrowserDialogSettingsSyncTest
{
    [Fact]
    public void ToDialog()
    {
        // Arrange
        var dialog = new FolderBrowserDialog();
        var settings = new FolderBrowserDialogSettings();
        var sync = new FolderBrowserDialogSettingsSync(dialog, settings);

        settings.Description = "Some description";
        settings.RootFolder = Environment.SpecialFolder.ProgramFiles;
        settings.SelectedPath = @"C:\temp";
        settings.ShowNewFolderButton = !settings.ShowNewFolderButton;

        // Act
        sync.ToDialog();

        // Assert
        Assert.Equal(settings.Description, dialog.Description);
        Assert.Equal(settings.RootFolder, dialog.RootFolder);
        Assert.Equal(settings.SelectedPath, dialog.SelectedPath);
        Assert.Equal(settings.ShowNewFolderButton, dialog.ShowNewFolderButton);
    }

    [Fact]
    public void ToSettings()
    {
        // Arrange
        var dialog = new FolderBrowserDialog();
        var settings = new FolderBrowserDialogSettings();
        var sync = new FolderBrowserDialogSettingsSync(dialog, settings);

        dialog.SelectedPath = @"C:\temp";

        // Act
        sync.ToSettings();

        // Assert
        Assert.Equal(dialog.SelectedPath, settings.SelectedPath);
    }
}