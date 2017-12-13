using System;
using NUnit.Framework;

namespace MvvmDialogs.DialogTypeLocators
{
    [TestFixture]
    public class DialogTypeLocatorCacheTest
    {
        private DialogTypeLocatorCache cache;

        [SetUp]
        public void SetUp()
        {
            cache = new DialogTypeLocatorCache();
        }

        [Test]
        public void Add()
        {
            // ACT
            cache.Add(typeof(TestDialogViewModel), typeof(TestDialog));

            // ASSERT
            Assert.That(cache.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddSameTwice()
        {
            // ARRANGE
            cache.Add(typeof(TestDialogViewModel), typeof(TestDialog));

            // ASSERT
            Assert.Throws<ArgumentException>(() => cache.Add(typeof(TestDialogViewModel), typeof(TestDialog)));
        }

        [Test]
        public void Get()
        {
            // ARRANGE
            cache.Add(typeof(TestDialogViewModel), typeof(TestDialog));

            // ACT
            Type dialogType = cache.Get(typeof(TestDialogViewModel));

            // ASSERT
            Assert.That(dialogType, Is.EqualTo(typeof(TestDialog)));
        }

        [Test]
        public void Clear()
        {
            // ARRANGE
            cache.Add(typeof(TestDialogViewModel), typeof(TestDialog));

            // ACT
            cache.Clear();

            // ASSERT
            Assert.That(cache.Count, Is.EqualTo(0));
        }

        #region Helper classes

        private class TestDialogViewModel : ViewModelBase
        {
        }

        private class TestDialog
        {
        }

        #endregion
    }
}