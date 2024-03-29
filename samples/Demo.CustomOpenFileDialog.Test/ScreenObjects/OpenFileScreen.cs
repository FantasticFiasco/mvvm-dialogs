﻿using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using FlaUI.Core.WindowsAPI;
using TestBaseClasses;

namespace Demo.CustomOpenFileDialog.ScreenObjects;

public class OpenFileScreen : Screen
{
    public OpenFileScreen(Window window)
        : base(window)
    {
    }

    private ComboBox FileNameComboBox => ElementByAutomationId<ComboBox>("1148");

    public string FileName
    {
        set => FileNameComboBox.EditableText = value;
    }

    public void ClickOpen()
    {
        Keyboard.Press(VirtualKeyShort.ENTER);
    }

    public void ClickCancel()
    {
        DefaultCancelButton.Click();
    }
}