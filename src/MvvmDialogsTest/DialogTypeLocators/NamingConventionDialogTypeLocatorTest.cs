using System;
using System.ComponentModel;
using System.Reflection;
using NUnit.Framework;

namespace MvvmDialogs.DialogTypeLocators
{
    [TestFixture]
    public class NamingConventionDialogTypeLocatorTest
    {
        private Assembly testAssembly;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
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
            // ARRANGE
            Type viewModelType = testAssembly.GetType(viewModelFullName);
            Assert.IsNotNull(viewModelType);

            var viewModel = (INotifyPropertyChanged)Activator.CreateInstance(viewModelType);
            
            // ACT
            Type dialogType = NamingConventionDialogTypeLocator.LocateDialogType(viewModel);

            // ASSERT
            Assert.That(dialogType.FullName, Is.EqualTo(viewFullName));
        }

        [TestCase("TestAssembly.ModuleWithoutViewNamespace.ViewModel.DialogViewModel")]
        [TestCase("TestAssembly.UnconventionalNamespace.DialogViewModel")]
        public void LocateDialogTypeUnsuccessful(string viewModelFullName)
        {
            // ARRANGE
            Type viewModelType = testAssembly.GetType(viewModelFullName);
            Assert.IsNotNull(viewModelType);

            var viewModel = (INotifyPropertyChanged)Activator.CreateInstance(viewModelType);

            // ASSERT
            Assert.Throws<Exception>(() => NamingConventionDialogTypeLocator.LocateDialogType(viewModel));
        }
    }
}