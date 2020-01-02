using SEW.ViewModels;
using System.Windows.Controls;

namespace SEW
{
    public partial class Examples : Page
    {
        public Examples(long WordID)
        {
            DataContext = new ExampleVM(WordID);
            InitializeComponent();
        }
    }
}
