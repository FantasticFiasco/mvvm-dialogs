using DemoApplication.Model;
using NUnit.Framework;

namespace DemoApplication.ViewModel
{
    [TestFixture]
    public class PersonDialogViewModelTest
    {
        [Test]
        public void NameTest()
        {
            var person = new Person
            {
                Name = "Some name",
                Gender = Gender.Female
            };

            var viewModel = new PersonDialogViewModel(person);

            Assert.That(viewModel.Name, Is.EqualTo(person.Name));
        }

        [Test]
        public void GenderTest()
        {
            var person = new Person
            {
                Name = "Some name",
                Gender = Gender.Female
            };

            var viewModel = new PersonDialogViewModel(person);

            Assert.That(viewModel.Gender, Is.EqualTo(person.Gender));
        }
    }
}