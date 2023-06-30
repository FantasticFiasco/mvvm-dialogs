using System.ComponentModel;
using System.Reflection;

namespace MvvmDialogs.DialogTypeLocators;

public class NamingConventionDialogTypeLocatorTest
{
    private readonly Assembly testAssembly;

    public NamingConventionDialogTypeLocatorTest()
    {
        NamingConventionDialogTypeLocator.Cache.Clear();

        var assemblyBuilder = new TestAssemblyBuilder("TestAssembly");

        // Create types used in tests
        assemblyBuilder.CreateType("TestAssembly.DialogViewModel", typeof(ViewModelBase));
        assemblyBuilder.CreateType("TestAssembly.Dialog");

        assemblyBuilder.CreateType("TestAssembly.ViewModels.DialogViewModel", typeof(ViewModelBase));
        assemblyBuilder.CreateType("TestAssembly.Views.Dialog");

        assemblyBuilder.CreateType("TestAssembly.ViewModels.Module.DialogViewModel", typeof(ViewModelBase));
        assemblyBuilder.CreateType("TestAssembly.Views.Module.Dialog");

        assemblyBuilder.CreateType("TestAssembly.Module.ViewModels.DialogViewModel", typeof(ViewModelBase));
        assemblyBuilder.CreateType("TestAssembly.Module.Views.Dialog");

        assemblyBuilder.CreateType("TestAssembly.ModuleWithoutViewNamespace.ViewModel.DialogViewModel", typeof(ViewModelBase));

        assemblyBuilder.CreateType("TestAssembly.UnconventionalNamespace.DialogViewModel", typeof(ViewModelBase));

        // Create assembly
        testAssembly = assemblyBuilder.Build();
    }

    [Theory]
    [InlineData("TestAssembly.DialogViewModel", "TestAssembly.Dialog")]
    [InlineData("TestAssembly.ViewModels.DialogViewModel", "TestAssembly.Views.Dialog")]
    [InlineData("TestAssembly.ViewModels.Module.DialogViewModel", "TestAssembly.Views.Module.Dialog")]
    [InlineData("TestAssembly.Module.ViewModels.DialogViewModel", "TestAssembly.Module.Views.Dialog")]
    public void LocateDialogTypeSuccessful(string viewModelFullName, string viewFullName)
    {
        // Arrange
        var dialogTypeLocator = new NamingConventionDialogTypeLocator();
        var viewModelType = testAssembly.GetType(viewModelFullName);
        Assert.NotNull(viewModelType);

        var viewModel = (INotifyPropertyChanged)Activator.CreateInstance(viewModelType);

        // Act
        var dialogType = dialogTypeLocator.Locate(viewModel);

        // Assert
        Assert.Equal(viewFullName, dialogType.FullName);
    }

    [Theory]
    [InlineData("TestAssembly.ModuleWithoutViewNamespace.ViewModel.DialogViewModel")]
    [InlineData("TestAssembly.UnconventionalNamespace.DialogViewModel")]
    public void LocateDialogTypeUnsuccessful(string viewModelFullName)
    {
        // Arrange
        var dialogTypeLocator = new NamingConventionDialogTypeLocator();
        var viewModelType = testAssembly.GetType(viewModelFullName);
        Assert.NotNull(viewModelType);

        var viewModel = (INotifyPropertyChanged)Activator.CreateInstance(viewModelType);

        // Assert
        Assert.Throws<TypeLoadException>(() => dialogTypeLocator.Locate(viewModel));
    }
}