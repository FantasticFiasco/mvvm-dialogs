using System.ComponentModel.Composition;
using MvvmDialogs.DialogTypeLocators;

namespace DemoApplication.DialogTypeLocators
{
    /// <summary>
    /// Class exporting the different <see cref="IDialogTypeLocator"/> implementations to MEF. Only
    /// one dialog type converter can be exported at any given time.
    /// </summary>
    public static class DialogTypeLocator
    {
        [Export]
        public static IDialogTypeLocator NameConventionDialogTypeLocator
        {
            get { return new NameConventionDialogTypeLocator(); }
        }

        //[Export]
        //public static IDialogTypeLocator MappedDialogTypeLocator
        //{
        //    get
        //    {
        //        var dialogTypeLocator = new MappedDialogTypeLocator();
        //        return dialogTypeLocator;
        //    }
        //}
    }
}