using SEW.ViewModels;
using System.Windows.Controls;

namespace SEW
{
    /// <summary>
    /// Interaction logic for Categories.xaml
    /// </summary>
    public partial class Categories : UserControl
    {
        public Categories()
        {
            InitializeComponent();

            DataContext = new CategoryViewModel();
        }
    }
}
