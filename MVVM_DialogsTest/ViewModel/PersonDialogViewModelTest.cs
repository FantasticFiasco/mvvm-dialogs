using MVVM_Dialogs.Model;
using MVVM_Dialogs.ViewModel;
using NUnit.Framework;

namespace MVVM_DialogsTest.ViewModel
{
	[TestFixture]
	public class PersonDialogViewModelTest
	{
		[Test]
		public void NameTest()
		{
			Person person = new Person("Some name", Gender.Female);
			PersonDialogViewModel viewModel = new PersonDialogViewModel(person);

			Assert.That(viewModel.Name, Is.EqualTo(person.Name));
		}


		[Test]
		public void GenderTest()
		{
			Person person = new Person("Some name", Gender.Female);
			PersonDialogViewModel viewModel = new PersonDialogViewModel(person);

			Assert.That(viewModel.Gender, Is.EqualTo(person.Gender));
		}
	}
}
