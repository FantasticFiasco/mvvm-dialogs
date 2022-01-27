using System;
using NUnit.Framework;

namespace MvvmDialogs.DialogTypeLocators
{
    [TestFixture]
    public class DialogTypeLocatorCacheTest
    {
        [Test]
        public void Add()
        {
            // Arrange
            var cache = new DialogTypeLocatorCache();

            // Act
            cache.Add(typeof(TestDialogViewModel), typeof(TestDialog));

            // Assert
            Assert.That(cache.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddSameTwice()
        {
            // Arrange
            var cache = new DialogTypeLocatorCache();
            cache.Add(typeof(TestDialogViewModel), typeof(TestDialog));

            // Assert
            Assert.Throws<ArgumentException>(() => cache.Add(typeof(TestDialogViewModel), typeof(TestDialog)));
        }

        [Test]
        public void Get()
        {
            // Arrange
            var cache = new DialogTypeLocatorCache();
            cache.Add(typeof(TestDialogViewModel), typeof(TestDialog));

            // Act
            Type? dialogType = cache.Get(typeof(TestDialogViewModel));

            // Assert
            Assert.That(dialogType, Is.EqualTo(typeof(TestDialog)));
        }

        [Test]
        public void Clear()
        {
            // Arrange
            var cache = new DialogTypeLocatorCache();
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
