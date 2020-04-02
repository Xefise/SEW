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
            Main.Content = new Categories(this);
            Main.Content = new WordSearch(this);
            Main.Content = new Remembering();
        }

        // It's okay that my main window doesn't have VM. Isn't it? :b
        public static void UpdateTheme()
        {
            ResourceDictionary resourceDict = Application.LoadComponent(new Uri($@"Themes/{Properties.Settings.Default.Theme}.xaml", UriKind.Relative)) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        public void GoToLastPage() => Main.GoBack();

        // MultiPages
        private void GoToLearnPage(object sender, RoutedEventArgs e) => Main.Content = new Remembering();
        private void GoToCategoriesPage(object sender, RoutedEventArgs e) => Main.Content = new Categories(this);
        private void GoToSearchPage(object sender, RoutedEventArgs e) => Main.Content = new WordSearch(this);
        private void GoToSettingsPage(object sender, RoutedEventArgs e) => Main.Content = new Settings();

        // *me* *<my gun*
        // *boom*
        public void GoToWordsPage(long ID) => Main.Content = new Words(this, ID);
        public void GoToExamplesPage(long ID) => Main.Content = new Examples(this, ID); // Damn, it's not funny anymore:d


    }
}
