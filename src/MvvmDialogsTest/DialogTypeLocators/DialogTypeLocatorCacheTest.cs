using System;
using MvvmDialogs.DialogTypeLocators.View;
using MvvmDialogs.DialogTypeLocators.ViewModel;
using NUnit.Framework;

namespace MvvmDialogs.DialogTypeLocators
{
    [TestFixture]
    public class DialogTypeLocatorCacheTest
    {
        [TearDown]
        public void TearDown()
        {
            DialogTypeLocatorCache.Clear();
        }

        [Test]
        public void Add()
        {
            // ACT
            DialogTypeLocatorCache.Add(typeof(TestDialogViewModel), typeof(TestDialog));
            
            // ASSERT
            Assert.That(DialogTypeLocatorCache.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddSameTwice()
        {
            // ACT
            DialogTypeLocatorCache.Add(typeof(TestDialogViewModel), typeof(TestDialog));
            DialogTypeLocatorCache.Add(typeof(TestDialogViewModel), typeof(TestDialog));

            // ASSERT
            Assert.That(DialogTypeLocatorCache.Count, Is.EqualTo(1));
        }

        [Test]
        public void Get()
        {
            // ARRANGE
            DialogTypeLocatorCache.Add(typeof(TestDialogViewModel), typeof(TestDialog));

            // ACT
            Type dialogType = DialogTypeLocatorCache.Get(typeof(TestDialogViewModel));

            // ASSERT
            Assert.That(dialogType, Is.EqualTo(typeof(TestDialog)));
        }
    }
}