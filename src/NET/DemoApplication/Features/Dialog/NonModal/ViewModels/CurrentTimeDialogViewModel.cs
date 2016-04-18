using System;
using System.Windows.Input;
using System.Windows.Threading;
using ReactiveUI;

namespace DemoApplication.Features.Dialog.NonModal.ViewModels
{
    public class CurrentTimeDialogViewModel : ReactiveObject
    {
        private readonly ReactiveCommand<object> startClockCommand;
        
// ReSharper disable once NotAccessedField.Local
        private DispatcherTimer timer;

        public CurrentTimeDialogViewModel()
        {
            startClockCommand = ReactiveCommand.Create();
            startClockCommand.Subscribe(_ => StartClock());
        }

        public ICommand StartClockCommand
        {
            get { return startClockCommand; }
        }

        public DateTime CurrentTime
        {
            get { return DateTime.Now; }
        }

        private void StartClock()
        {
            timer = new DispatcherTimer(
                TimeSpan.FromSeconds(1),
                DispatcherPriority.Normal,
                OnTick,
                Dispatcher.CurrentDispatcher);
        }

        private void OnTick(object sender, EventArgs e)
        {
// ReSharper disable once ExplicitCallerInfoArgument
            this.RaisePropertyChanged("CurrentTime");
        }
    }
}