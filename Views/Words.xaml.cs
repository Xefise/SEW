using SEW.ViewModels;
using System.Windows.Controls;

namespace SEW
{
    public partial class Words : Page
    {
        public Words(long CategoryID)
        {
            DataContext = new WordVM(CategoryID);
            InitializeComponent();
        }
    }
}
