using SEW.ViewModels;
using System.Windows.Controls;

namespace SEW
{
    public partial class WordSearch : Page
    {
        public WordSearch(MainWindow main)
        {
            DataContext = new WordSearchVM(main);
            InitializeComponent();
        }
    }
}
