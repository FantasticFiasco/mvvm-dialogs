using DemoApplication.Model;
using NUnit.Framework;

namespace DemoApplication.ViewModel
{
    [TestFixture]
    public class PersonViewModelTest
    {
        [Test]
        public void NameTest()
        {
            var person = new Person
            {
                Name = "Some name",
                Gender = Gender.Female
            };

            var viewModel = new PersonViewModel(person);

            Assert.That(viewModel.Name, Is.EqualTo(person.Name));
        }

        [Test]
        public void IsSelectedTest()
        {
            var person = new Person
            {
                Name = "Some name",
                Gender = Gender.Female
            };

            var viewModel = new PersonViewModel(person);

            Assert.That(viewModel.IsSelected, Is.False);

            viewModel.IsSelected = true;
            Assert.That(viewModel.IsSelected, Is.True);
        }

        [Test]
        public void PersonTest()
        {
            var person = new Person
            {
                Name = "Some name",
                Gender = Gender.Female
            };

            var viewModel = new PersonViewModel(person);

            Assert.That(person, Is.EqualTo(viewModel.Person));
        }
    }
}