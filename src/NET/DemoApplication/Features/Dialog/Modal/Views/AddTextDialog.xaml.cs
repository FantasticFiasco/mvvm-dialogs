namespace DemoApplication.Features.Dialog.Modal.Views
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