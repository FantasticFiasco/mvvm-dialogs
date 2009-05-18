using System.Collections.Generic;
using System.Windows;
using Moq;
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
		private Person person1;
		private Person person2;
				

		[SetUp]
		public void SetUp()
		{
			person1 = new Person("Some name 1", Gender.Female);
			person1 = new Person("Some name 2", Gender.Male);
			
			dialogServiceMock = new Mock<IDialogService>();

			personServiceMock = new Mock<IPersonService>();
			personServiceMock
				.Setup(m => m.Get())
				.Returns(new List<Person> { person1, person2 });

			viewModel = new MainWindowViewModel(dialogServiceMock.Object, personServiceMock.Object);
		}


		[Test]
		public void PersonsTest()
		{
			Assert.That(viewModel.Persons.Count, Is.EqualTo(2));
			Assert.That(viewModel.Persons[0].Person, Is.EqualTo(person1));
			Assert.That(viewModel.Persons[1].Person, Is.EqualTo(person2));
		}


		[Test]
		public void CanShowInformationTest()
		{
			Assert.That(viewModel.SelectedPersons, Is.Empty);
			Assert.That(viewModel.ShowInformationCommand.CanExecute(null), Is.False);

			viewModel.Persons[0].IsSelected = true;
			Assert.That(viewModel.ShowInformationCommand.CanExecute(null), Is.True);

			viewModel.Persons[1].IsSelected = true;
			Assert.That(viewModel.ShowInformationCommand.CanExecute(null), Is.False);
		}


		[Test]
		public void ShowInformationTest()
		{
			viewModel.Persons[0].IsSelected = true;

			// Solely for coverage
			dialogServiceMock
				.Setup(m => m.ShowDialog<PersonDialog>(viewModel, It.IsAny<object>()))
				.Returns(false);
			viewModel.ShowInformationCommand.Execute(null);
		}


		[Test]
		public void CanDeleteTest()
		{
			Assert.That(viewModel.SelectedPersons, Is.Empty);
			Assert.That(viewModel.ShowInformationCommand.CanExecute(null), Is.False);

			viewModel.Persons[0].IsSelected = true;
			Assert.That(viewModel.ShowInformationCommand.CanExecute(null), Is.True);

			viewModel.Persons[1].IsSelected = true;
			Assert.That(viewModel.ShowInformationCommand.CanExecute(null), Is.False);
		}


		[Test]
		public void AbortDeleteTest()
		{
			int personCount = viewModel.Persons.Count;

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
			int personCount = viewModel.Persons.Count;

			dialogServiceMock.
				Setup(m => m.ShowMessageBox(viewModel, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<MessageBoxButton>(), It.IsAny<MessageBoxImage>())).
			  Returns(MessageBoxResult.Yes);

			viewModel.Persons[0].IsSelected = true;
			viewModel.DeleteCommand.Execute(null);
			Assert.That(viewModel.Persons.Count, Is.EqualTo(personCount - 1));
		}
	}
}
