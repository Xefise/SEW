using SEW.Models;
using System;
using System.Data.Entity;
using System.Windows;

namespace SEW
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateTheme();
            Main.Content = new Categories(this);
            Main.Content = new Remembering();
        }

        // Ну ничего же страшного что у меня главная страница без VM? :b
        public static void UpdateTheme()
        {
            ResourceDictionary resourceDict = Application.LoadComponent(new Uri($@"Themes/{Properties.Settings.Default.Theme}.xaml", UriKind.Relative)) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        // MultiPages
        private void GoToLearnPage(object sender, RoutedEventArgs e) => Main.Content = new Remembering();
        private void GoToCategoriesPage(object sender, RoutedEventArgs e) => Main.Content = new Categories(this);
        private void GoToStatsPage(object sender, RoutedEventArgs e) => Main.Content = new Categories(this);
        private void GoToSettingsPage(object sender, RoutedEventArgs e) => Main.Content = new Categories(this);

        // *me* *<my gun*
        // *boom*
        public void GoToWordsPage(long ID) => Main.Content = new Words(this, ID);
        public void GoToExamplesPage(long ID) => Main.Content = new Examples(ID); // Чёрт, это уже не смешно..
    }
}
