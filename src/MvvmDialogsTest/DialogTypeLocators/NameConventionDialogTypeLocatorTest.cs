using System;
using System.ComponentModel;
using System.Reflection;
using NUnit.Framework;

namespace MvvmDialogs.DialogTypeLocators
{
    [TestFixture]
    public class NameConventionDialogTypeLocatorTest
    {
        private NameConventionDialogTypeLocator dialogTypeLocator;
        private Assembly testAssembly;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            dialogTypeLocator = new NameConventionDialogTypeLocator();
            var assemblyBuilder = new TestAssemblyBuilder("TestAssembly");

            // Create types used in tests
            assemblyBuilder.CreateType("TestAssmebly.ViewModel.DialogViewModel", typeof(ViewModelBase));
            assemblyBuilder.CreateType("TestAssmebly.View.Dialog");

            assemblyBuilder.CreateType("TestAssmebly.ViewModels.DialogViewModel", typeof(ViewModelBase));
            assemblyBuilder.CreateType("TestAssmebly.Views.Dialog");

            assemblyBuilder.CreateType("TestAssmebly.ViewModel.Module.DialogViewModel", typeof(ViewModelBase));
            assemblyBuilder.CreateType("TestAssmebly.View.Module.Dialog");

            assemblyBuilder.CreateType("TestAssmebly.ViewModels.Module.DialogViewModel", typeof(ViewModelBase));
            assemblyBuilder.CreateType("TestAssmebly.Views.Module.Dialog");

            assemblyBuilder.CreateType("TestAssmebly.Module.ViewModel.DialogViewModel", typeof(ViewModelBase));
            assemblyBuilder.CreateType("TestAssmebly.Module.View.Dialog");

            assemblyBuilder.CreateType("TestAssmebly.Module.ViewModels.DialogViewModel", typeof(ViewModelBase));
            assemblyBuilder.CreateType("TestAssmebly.Module.Views.Dialog");

            assemblyBuilder.CreateType("TestAssmebly.ModuleWithoutViewNamespace.ViewModel.DialogViewModel", typeof(ViewModelBase));

            assemblyBuilder.CreateType("TestAssmebly.UnconventionalNamespace.DialogViewModel", typeof(ViewModelBase));

            // Create assembly
            testAssembly = assemblyBuilder.Build();
        }

        [TestCase("TestAssmebly.ViewModel.DialogViewModel", "TestAssmebly.View.Dialog")]
        [TestCase("TestAssmebly.ViewModels.DialogViewModel", "TestAssmebly.Views.Dialog")]
        [TestCase("TestAssmebly.ViewModel.Module.DialogViewModel", "TestAssmebly.View.Module.Dialog")]
        [TestCase("TestAssmebly.ViewModels.Module.DialogViewModel", "TestAssmebly.Views.Module.Dialog")]
        [TestCase("TestAssmebly.Module.ViewModel.DialogViewModel", "TestAssmebly.Module.View.Dialog")]
        [TestCase("TestAssmebly.Module.ViewModels.DialogViewModel", "TestAssmebly.Module.Views.Dialog")]
        public void LocateDialogTypeSuccessful(string viewModelFullName, string viewFullName)
        {
            // ARRANGE
            Type viewModelType = testAssembly.GetType(viewModelFullName);
            Assert.IsNotNull(viewModelType);

            var viewModel = (INotifyPropertyChanged)Activator.CreateInstance(viewModelType);
            
            // ACT
            Type dialogType = dialogTypeLocator.LocateDialogTypeFor(viewModel);

            // ASSERT
            Assert.That(dialogType.FullName, Is.EqualTo(viewFullName));
        }

        [TestCase("TestAssmebly.ModuleWithoutViewNamespace.ViewModel.DialogViewModel")]
        [TestCase("TestAssmebly.UnconventionalNamespace.DialogViewModel")]
        public void LocateDialogTypeUnsuccessful(string viewModelFullName)
        {
            // ARRANGE
            Type viewModelType = testAssembly.GetType(viewModelFullName);
            Assert.IsNotNull(viewModelType);

            var viewModel = (INotifyPropertyChanged)Activator.CreateInstance(viewModelType);

            // ASSERT
            Assert.Throws<DialogTypeException>(() => dialogTypeLocator.LocateDialogTypeFor(viewModel));
        }
    }
}