namespace DemoApplication.Features.Dialog.Views
{
    public partial class AddTextDialog
    {
        public AddTextDialog()
        {
            InitializeComponent();

            Loaded += (sender, e) => textTextBox.Focus();
        }
    }
}