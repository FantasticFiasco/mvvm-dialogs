using System.ComponentModel.Composition;

namespace DemoApplication
{
    /// <summary>
    /// Main window of the application.
    /// </summary>
    [Export]
    public partial class MainWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}