using System;
using MvvmDialogs.DialogTypeLocators.View;
using MvvmDialogs.DialogTypeLocators.ViewModel;
using NUnit.Framework;

namespace MvvmDialogs.DialogTypeLocators
{
    [TestFixture]
    public class NameConventionDialogTypeLocatorTest
    {
        private NameConventionDialogTypeLocator dialogTypeLocator;

        [SetUp]
        public void SetUp()
        {
            dialogTypeLocator = new NameConventionDialogTypeLocator();
        }

        [TearDown]
        public void TearDown()
        {
            NameConventionDialogTypeLocator.Cache.Clear();
        }
        
        [Test]
        public void Successful()
        {
            // ARRANGE
            var viewModel = new TestDialogViewModel();

            // ACT
            Type dialogType = dialogTypeLocator.LocateDialogTypeFor(viewModel);

            // ASSERT
            Assert.That(dialogType, Is.EqualTo(typeof(TestDialog)));
        }

        [Test]
        public void UnsuccessfulDueToMissingDialogType()
        {
            // ARRANGE
            var viewModel = new MissingDialogTypeViewModel();

            // ASSERT
            Assert.Throws<DialogTypeException>(() => dialogTypeLocator.LocateDialogTypeFor(viewModel));
        }

        [Test]
        public void UnsuccessfulDueToInvalidName()
        {
            // ARRANGE
            var viewModel = new InvalidNameVM();

            // ASSERT
            Assert.Throws<DialogTypeException>(() => dialogTypeLocator.LocateDialogTypeFor(viewModel));
        }

        [Test]
        public void NewDialogTypeUpdatesCache()
        {
            // ACT
            dialogTypeLocator.LocateDialogTypeFor(new TestDialogViewModel());

            // ASSERT
            Assert.That(NameConventionDialogTypeLocator.Cache.Count, Is.EqualTo(1));
        }

        [Test]
        public void KnownDialogTypeDoesNotUpdateCache()
        {
            // ACT
            dialogTypeLocator.LocateDialogTypeFor(new TestDialogViewModel());
            dialogTypeLocator.LocateDialogTypeFor(new TestDialogViewModel());

            // ASSERT
            Assert.That(NameConventionDialogTypeLocator.Cache.Count, Is.EqualTo(1));
        }
    }
}