using MVVM_Dialogs.Model;
using MVVM_Dialogs.ViewModel;
using NUnit.Framework;

namespace MVVM_DialogsTest.ViewModel
{
    [TestFixture]
    public class PersonViewModelTest
    {
        [Test]
        public void NameTest()
        {
            Person person = new Person
            {
                Name = "Some name",
                Gender = Gender.Female
            };

            PersonViewModel viewModel = new PersonViewModel(person);

            Assert.That(viewModel.Name, Is.EqualTo(person.Name));
        }
        
        [Test]
        public void IsSelectedTest()
        {
            Person person = new Person
            {
                Name = "Some name",
                Gender = Gender.Female
            };

            PersonViewModel viewModel = new PersonViewModel(person);

            Assert.That(viewModel.IsSelected, Is.False);

            viewModel.IsSelected = true;
            Assert.That(viewModel.IsSelected, Is.True);
        }
        
        [Test]
        public void PersonTest()
        {
            Person person = new Person
            {
                Name = "Some name",
                Gender = Gender.Female
            };

            PersonViewModel viewModel = new PersonViewModel(person);

            Assert.That(person, Is.EqualTo(viewModel.Person));
        }
    }
}