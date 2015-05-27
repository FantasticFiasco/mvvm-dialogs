using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using DemoApplication.TabItemInfrastructure;
using MvvmFoundation.Wpf;

namespace DemoApplication
{
    /// <summary>
    /// Acts as view model for <see cref="MainWindow"/>.
    /// </summary>
    [Export]
    public class MainWindowViewModel : ObservableObject
    {
        private readonly ObservableCollection<TabItemViewModel> items;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        [ImportingConstructor]
        public MainWindowViewModel([ImportMany] IEnumerable<Lazy<TabItemViewModel, ITabItemPriority>> tabItems)
        {
            IEnumerable<TabItemViewModel> orderedTabItems = tabItems
                .OrderBy(tabItem => tabItem.Metadata.Priority)
                .Select(tabItem => tabItem.Value);

            items = new ObservableCollection<TabItemViewModel>(orderedTabItems);
        }

        public ObservableCollection<TabItemViewModel> Items
        {
            get { return items; }
        }
    }
}