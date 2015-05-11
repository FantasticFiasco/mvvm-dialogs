using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using DemoApplication.Model;
using DemoApplication.Service;
using DemoApplication.View;
using Moq;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using NUnit.Framework;

namespace DemoApplication.ViewModel
{
    [TestFixture]
    public class MainWindowViewModelTest
    {
        private MainWindowViewModel viewModel;
        private Mock<IDialogService> dialogServiceMock;
        private Mock<IPersonService> personServiceMock;
        private Person femalePerson;
        private Person malePerson;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            femalePerson = new Person
            {
                Name = "Jane Doe",
                Gender = Gender.Female
            };

            malePerson = new Person
            {
                Name = "John Doe",
                Gender = Gender.Male
            };

            dialogServiceMock = new Mock<IDialogService>();
            personServiceMock = new Mock<IPersonService>();
            personServiceMock
                .Setup(m => m.Load(It.IsAny<string>()))
                .Returns(
                    new List<Person>
                    {
                        femalePerson,
                        malePerson
                    });
        }

        [SetUp]
        public void SetUp()
        {
            viewModel = new MainWindowViewModel(
                dialogServiceMock.Object,
                personServiceMock.Object);
        }

        [Test]
        public void CanLoadPersons()
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
            Assert.That(viewModel.Persons[0].Person, Is.EqualTo(femalePerson));
            Assert.That(viewModel.Persons[1].Person, Is.EqualTo(malePerson));
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
            // Simulate loading persons
            dialogServiceMock
                .Setup(m => m.ShowOpenFileDialog(viewModel, It.IsAny<OpenFileDialogViewModel>()))
                .Returns(DialogResult.OK);
            viewModel.LoadPersonsCommand.Execute(null);
        }

        #endregion
    }
}