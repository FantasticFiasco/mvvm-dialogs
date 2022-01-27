using System;
using System.ComponentModel;
using System.Reflection;
using NUnit.Framework;

namespace MvvmDialogs.DialogTypeLocators
{
    [TestFixture]
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

        [TestCase("TestAssembly.DialogViewModel", "TestAssembly.Dialog")]
        [TestCase("TestAssembly.ViewModels.DialogViewModel", "TestAssembly.Views.Dialog")]
        [TestCase("TestAssembly.ViewModels.Module.DialogViewModel", "TestAssembly.Views.Module.Dialog")]
        [TestCase("TestAssembly.Module.ViewModels.DialogViewModel", "TestAssembly.Module.Views.Dialog")]
        public void LocateDialogTypeSuccessful(string viewModelFullName, string viewFullName)
        {
            // Arrange
            var dialogTypeLocator = new NamingConventionDialogTypeLocator();
            Type viewModelType = testAssembly.GetType(viewModelFullName);
            Assert.IsNotNull(viewModelType);

            var viewModel = (INotifyPropertyChanged)Activator.CreateInstance(viewModelType);
            
            // Act
            Type dialogType = dialogTypeLocator.Locate(viewModel);

            // Assert
            Assert.That(dialogType.FullName, Is.EqualTo(viewFullName));
        }

        [TestCase("TestAssembly.ModuleWithoutViewNamespace.ViewModel.DialogViewModel")]
        [TestCase("TestAssembly.UnconventionalNamespace.DialogViewModel")]
        public void LocateDialogTypeUnsuccessful(string viewModelFullName)
        {
            // Arrange
            var dialogTypeLocator = new NamingConventionDialogTypeLocator();
            Type viewModelType = testAssembly.GetType(viewModelFullName);
            Assert.IsNotNull(viewModelType);

            var viewModel = (INotifyPropertyChanged)Activator.CreateInstance(viewModelType);

            // Assert
            Assert.Throws<TypeLoadException>(() => dialogTypeLocator.Locate(viewModel));
        }
    }
}
