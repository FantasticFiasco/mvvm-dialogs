using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using DemoApplication.Features.Dialog.ViewModels;
using DemoApplication.Features.FolderBrowserDialog.ViewModels;
using DemoApplication.Features.MessageBox.ViewModels;
using DemoApplication.Features.OpenFileDialog.ViewModels;
using DemoApplication.Features.SaveFileDialog.ViewModels;
using GalaSoft.MvvmLight;

namespace DemoApplication
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