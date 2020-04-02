using SEW.ViewModels;
using System.Windows.Controls;

namespace SEW
{
    public partial class Examples : Page
    {
        public Examples(MainWindow window, long WordID)
        {
            DataContext = new ExampleVM(window, WordID);
            InitializeComponent();
        }
    }
}
