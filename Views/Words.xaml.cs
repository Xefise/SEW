using SEW.ViewModels;
using System.Windows.Controls;

namespace SEW
{
    public partial class Words : Page
    {
        public Words(MainWindow main, long CategoryID)
        {
            DataContext = new WordVM(main, CategoryID);
            InitializeComponent();
        }
    }
}
