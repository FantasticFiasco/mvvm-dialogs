using System;
using System.Windows.Input;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace Demo.NonModalCustomDialog
{
    public class CurrentTimeCustomDialogViewModel : ViewModelBase
    {
        // ReSharper disable once NotAccessedField.Local
        private DispatcherTimer timer;

        public CurrentTimeCustomDialogViewModel()
        {
            StartClockCommand = new RelayCommand(StartClock);
        }

        public ICommand StartClockCommand { get; }

        public DateTime CurrentTime => DateTime.Now;

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
            RaisePropertyChanged(() => CurrentTime);
        }
    }
}