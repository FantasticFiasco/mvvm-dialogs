using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using Moq;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using MVVM_Dialogs.Model;
using MVVM_Dialogs.Service;
using MVVM_Dialogs.View;
using MVVM_Dialogs.ViewModel;
using NUnit.Framework;

namespace MVVM_DialogsTest.ViewModel
{
    [TestFixture]
    public class MainWindowViewModelTest
    {
        private MainWindowViewModel viewModel;
        private Mock<IDialogService> dialogServiceMock;
        private Mock<IPersonService> personServiceMock;
        private OpenFileDialogViewModel openFileDialog;
        private Person person1;
        private Person person2;
        
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            person1 = new Person
            {
                Name = "Some name 1",
                Gender = Gender.Female
            };
            person2 = new Person
            {
                Name = "Some name 2",
                Gender = Gender.Male
            };

            dialogServiceMock = new Mock<IDialogService>();
            openFileDialog = new OpenFileDialogViewModel();
            personServiceMock = new Mock<IPersonService>();
            personServiceMock
                .Setup(m => m.Load(It.IsAny<string>()))
                .Returns(
                    new List<Person>
                    {
                        person1,
                        person2
                    });
        }
        
        [SetUp]
        public void SetUp()
        {
            viewModel = new MainWindowViewModel(
                dialogServiceMock.Object,
                personServiceMock.Object,
                () => openFileDialog);
        }
        
        [Test]
        public void CanLoadPersonsTest()
        {
            // Make sure list is empty, thus making it possible to load the persons from start
            Assert.That(viewModel.Persons, Is.Empty);
            Assert.That(viewModel.LoadPersonsCommand.CanExecute(null), Is.True);

            // Load persons but cancel
            dialogServiceMock
                .Setup(m => m.ShowOpenFileDialog(viewModel, It.IsAny<OpenFileDialogViewModel>()))
                .Returns(DialogResult.Cancel);
            viewModel.LoadPersonsCommand.Execute(null);
            Assert.That(viewModel.LoadPersonsCommand.CanExecute(null), Is.True);

            // Load persons
            LoadPersons();
            Assert.That(viewModel.LoadPersonsCommand.CanExecute(null), Is.False);
        }
        
        [Test]
        public void LoadPersonsTest()
        {
            // Make sure list is empty
            Assert.That(viewModel.Persons, Is.Empty);

            // Loading person
            LoadPersons();
            Assert.That(viewModel.Persons.Count, Is.EqualTo(2));
            Assert.That(viewModel.Persons[0].Person, Is.EqualTo(person1));
            Assert.That(viewModel.Persons[1].Person, Is.EqualTo(person2));
            //openFileDialogMock.VerifySet(m => m.FileName = It.IsAny<string>());
            //openFileDialogMock.VerifySet(m => m.Filter = It.IsAny<string>());
            //openFileDialogMock.VerifySet(m => m.InitialDirectory = It.IsAny<string>());
            //openFileDialogMock.VerifySet(mock => mock.Title = It.IsAny<string>());
        }
        
        [Test]
        public void CanShowInformationTest()
        {
            LoadPersons();

            // No person selected
            Assert.That(viewModel.SelectedPersons, Is.Empty);
            Assert.That(viewModel.ShowInformationCommand.CanExecute(null), Is.False);

            // One person selected
            viewModel.Persons[0].IsSelected = true;
            Assert.That(viewModel.ShowInformationCommand.CanExecute(null), Is.True);

            // Two persons selected
            viewModel.Persons[1].IsSelected = true;
            Assert.That(viewModel.ShowInformationCommand.CanExecute(null), Is.False);
        }
        
        [Test]
        public void ShowInformationTest()
        {
            LoadPersons();

            // One person selected
            viewModel.Persons[0].IsSelected = true;

            // Solely for coverage since the dialog doesn't return anything
            dialogServiceMock
                .Setup(m => m.ShowDialog<MainWindow>(viewModel, It.IsAny<INotifyPropertyChanged>()))
                .Returns(false);
            viewModel.ShowInformationCommand.Execute(null);
            dialogServiceMock
                .Verify(m => m.ShowDialog<MainWindow>(viewModel, It.IsAny<PersonDialogViewModel>()));
        }
        
        [Test]
        public void CanDeleteTest()
        {
            LoadPersons();

            // No person selected
            Assert.That(viewModel.SelectedPersons, Is.Empty);
            Assert.That(viewModel.ShowInformationCommand.CanExecute(null), Is.False);

            // One person selected
            viewModel.Persons[0].IsSelected = true;
            Assert.That(viewModel.ShowInformationCommand.CanExecute(null), Is.True);

            // Two persons selected
            viewModel.Persons[1].IsSelected = true;
            Assert.That(viewModel.ShowInformationCommand.CanExecute(null), Is.False);
        }
        
        [Test]
        public void CancelDeleteTest()
        {
            LoadPersons();

            // Remember current person count
            int personCount = viewModel.Persons.Count;

            // Cancel when prompt
            dialogServiceMock.
                Setup(m => m.ShowMessageBox(viewModel, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<MessageBoxButton>(), It.IsAny<MessageBoxImage>())).
                Returns(MessageBoxResult.No);

            viewModel.Persons[0].IsSelected = true;
            viewModel.DeleteCommand.Execute(null);
            Assert.That(viewModel.Persons.Count, Is.EqualTo(personCount));
        }
        
        [Test]
        public void ConfirmDeleteTest()
        {
            LoadPersons();

            // Remember current person count
            int personCount = viewModel.Persons.Count;

            // Accept when prompt
            dialogServiceMock.
                Setup(m => m.ShowMessageBox(viewModel, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<MessageBoxButton>(), It.IsAny<MessageBoxImage>())).
                Returns(MessageBoxResult.Yes);

            viewModel.Persons[0].IsSelected = true;
            viewModel.DeleteCommand.Execute(null);
            Assert.That(viewModel.Persons.Count, Is.EqualTo(personCount - 1));
        }
        
        #region Utility methods

        private void LoadPersons()
        {
            // Simulte loading persons
            dialogServiceMock
                .Setup(m => m.ShowOpenFileDialog(viewModel, It.IsAny<OpenFileDialogViewModel>()))
                .Returns(DialogResult.OK);
            viewModel.LoadPersonsCommand.Execute(null);
        }

        #endregion
    }
}