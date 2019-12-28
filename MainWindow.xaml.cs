using System;
using System.Windows;

namespace SEW
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateTheme();
        }

        // Ну ничего же страшного что у меня главная страница без VM? :b
        public static void UpdateTheme()
        {
            ResourceDictionary resourceDict = Application.LoadComponent(new Uri($@"Themes/{Properties.Settings.Default.Theme}.xaml", UriKind.Relative)) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        // MultiPages
        private void GoToLearnPage(object sender, RoutedEventArgs e) => Main.Content = new Categories();
        private void GoToCategoriesPage(object sender, RoutedEventArgs e) => Main.Content = new Categories();
        private void GoToStatsPage(object sender, RoutedEventArgs e) => Main.Content = new Categories();
        private void GoToSettingsPage(object sender, RoutedEventArgs e) => Main.Content = new Categories();
    }
}
