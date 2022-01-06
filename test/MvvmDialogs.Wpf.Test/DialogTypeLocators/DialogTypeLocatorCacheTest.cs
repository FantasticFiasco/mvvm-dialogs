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
            // Act
            cache.Add(typeof(TestDialogViewModel), typeof(TestDialog));

            // Assert
            Assert.That(cache.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddSameTwice()
        {
            // Arrange
            cache.Add(typeof(TestDialogViewModel), typeof(TestDialog));

            // Assert
            Assert.Throws<ArgumentException>(() => cache.Add(typeof(TestDialogViewModel), typeof(TestDialog)));
        }

        [Test]
        public void Get()
        {
            // Arrange
            cache.Add(typeof(TestDialogViewModel), typeof(TestDialog));

            // Act
            Type dialogType = cache.Get(typeof(TestDialogViewModel));

            // Assert
            Assert.That(dialogType, Is.EqualTo(typeof(TestDialog)));
        }

        [Test]
        public void Clear()
        {
            // Arrange
            cache.Add(typeof(TestDialogViewModel), typeof(TestDialog));

            // Act
            cache.Clear();

            // Assert
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
