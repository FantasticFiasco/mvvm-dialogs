using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using DemoApplication.View;
using DemoApplication.ViewModel.Dialog;
using DemoApplication.ViewModel.FolderBrowserDialog;
using DemoApplication.ViewModel.MessageBox;
using DemoApplication.ViewModel.OpenFileDialog;
using DemoApplication.ViewModel.SaveFileDialog;
using GalaSoft.MvvmLight;

namespace DemoApplication.ViewModel
{
    /// <summary>
    /// Acts as view model for <see cref="MainWindow"/>.
    /// </summary>
    [Export]
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ObservableCollection<TabItemViewModel> items;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
        {
            items = new ObservableCollection<TabItemViewModel>
            {
                new ImplicitDialogTabItemViewModel(),
                new ExplicitDialogTabItemViewModel(),
                new MessageBoxTabItemViewModel(),
                new OpenFileTabItemViewModel(),
                new SaveFileTabItemViewModel(),
                new FolderBrowserTabItemViewModel()
            };
        }

        public ObservableCollection<TabItemViewModel> Items
        {
            get { return items; }
        }
    }
}