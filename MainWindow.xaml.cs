using System;
using System.Windows;

namespace SEW
{
    public partial class MainWindow : Window
    {
        Categories cateroriesPage;
        WordSearch wordSearchPage;
        Remembering rememberingPage;
        Settings settingsPage;

        public MainWindow()
        {
            InitializeComponent();
            UpdateTheme();
            cateroriesPage = new Categories(this);
            wordSearchPage = new WordSearch(this); // I dunno for what
            rememberingPage = new Remembering();
            settingsPage = new Settings(this);
            Main.Content = rememberingPage;
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
        private void GoToLearnPage(object sender, RoutedEventArgs e) => Main.Content = rememberingPage;
        private void GoToCategoriesPage(object sender, RoutedEventArgs e) => Main.Content = cateroriesPage;
        private void GoToSearchPage(object sender, RoutedEventArgs e) => Main.Content = wordSearchPage;
        private void GoToSettingsPage(object sender, RoutedEventArgs e) => Main.Content = settingsPage;

        // *me* *<my gun*
        // *boom*
        // I hope nobody would create 312434254 pages:D
        public void GoToWordsPage(long ID) => Main.Content = new Words(this, ID);
        public void GoToExamplesPage(long ID) => Main.Content = new Examples(this, ID); // Damn, it's not funny anymore:d


    }
}
