using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DemoApplication.TabItemInfrastructure;
using ReactiveUI;

namespace DemoApplication
{
    /// <summary>
    /// Acts as view model for <see cref="MainWindow"/>.
    /// </summary>
    public class MainWindowViewModel : ReactiveObject
    {
        private readonly ObservableCollection<TabItemViewModel> items;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel(IEnumerable<TabItemViewModel> tabItems)
        {
            IEnumerable<TabItemViewModel> orderedTabItems = tabItems
                .OrderBy(tabItem => tabItem.Priority)
                .Select(tabItem => tabItem);

            items = new ObservableCollection<TabItemViewModel>(orderedTabItems);
        }

        public ObservableCollection<TabItemViewModel> Items
        {
            get { return items; }
        }
    }
}