using System;
using MvvmDialogs.DialogTypeLocators.View;
using MvvmDialogs.DialogTypeLocators.ViewModel;
using NUnit.Framework;

namespace MvvmDialogs.DialogTypeLocators
{
    [TestFixture]
    public class MappableDialogTypeLocatorTest
    {
        private MappedDialogTypeLocator dialogTypeLocator;

        [SetUp]
        public void SetUp()
        {
            dialogTypeLocator = new MappedDialogTypeLocator();
        }

        [Test]
        public void Successful()
        {
            // ARRANGE
            var viewModel = new TestDialogViewModel();

            dialogTypeLocator.Map(typeof(TestDialogViewModel), typeof(TestDialog));

            // ACT
            Type dialogType = dialogTypeLocator.LocateDialogTypeFor(viewModel);

            // ASSERT
            Assert.That(dialogType, Is.EqualTo(typeof(TestDialog)));
        }

        [Test]
        public void Unsuccessful()
        {
            // ARRANGE
            var viewModel = new TestDialogViewModel();

            // ASSERT
            Assert.Throws<DialogTypeException>(() => dialogTypeLocator.LocateDialogTypeFor(viewModel));
        }
    }
}