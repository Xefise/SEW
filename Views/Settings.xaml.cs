using System.Windows.Controls;

namespace SEW
{
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();

            if (Properties.Settings.Default.Theme == "Dark") CBTheme.IsChecked = true;
            else CBTheme.IsChecked = false;
        }

        private void BSave_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (CBTheme.IsChecked == true) Properties.Settings.Default.Theme = "Dark";
            else Properties.Settings.Default.Theme = "Light";
            Properties.Settings.Default.Save();

            MainWindow.UpdateTheme();
        }
    }
}
