namespace MvvmDialogs.DialogTypeLocators
{
    public class DialogTypeLocatorCacheTest
    {
        [StaFact]
        public void Add()
        {
            // Arrange
            var cache = new DialogTypeLocatorCache();

            // Act
            cache.Add(typeof(TestDialogViewModel), typeof(TestDialog));

            // Assert
            Assert.Equal(1, cache.Count);
        }

        [StaFact]
        public void AddSameTwice()
        {
            // Arrange
            var cache = new DialogTypeLocatorCache();
            cache.Add(typeof(TestDialogViewModel), typeof(TestDialog));

            // Assert
            Assert.Throws<ArgumentException>(() => cache.Add(typeof(TestDialogViewModel), typeof(TestDialog)));
        }

        [StaFact]
        public void Get()
        {
            // Arrange
            var cache = new DialogTypeLocatorCache();
            cache.Add(typeof(TestDialogViewModel), typeof(TestDialog));

            // Act
            Type? dialogType = cache.Get(typeof(TestDialogViewModel));

            // Assert
            Assert.Equal(typeof(TestDialog), dialogType);
        }

        [StaFact]
        public void Clear()
        {
            // Arrange
            var cache = new DialogTypeLocatorCache();
            cache.Add(typeof(TestDialogViewModel), typeof(TestDialog));

            // Act
            cache.Clear();

            // Assert
            Assert.Equal(0, cache.Count);
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
