using System;
using System.Windows.Threading;
using ReactiveUI;

namespace DemoApplication.Features.Dialog.ViewModels
{
    public class CurrentTimeDialogViewModel : ReactiveObject
    {
        private readonly DispatcherTimer timer;

        public CurrentTimeDialogViewModel()
        {
            timer = new DispatcherTimer(
                TimeSpan.FromSeconds(1),
                DispatcherPriority.Normal,
                OnTick,
                Dispatcher.CurrentDispatcher);
        }

        public DateTime CurrentTime
        {
            get { return DateTime.Now; }
        }

        private void OnTick(object sender, EventArgs e)
        {
// ReSharper disable once ExplicitCallerInfoArgument
            this.RaisePropertyChanged("CurrentTime");
        }
    }
}