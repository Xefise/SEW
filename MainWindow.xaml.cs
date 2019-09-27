using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace SEW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateTheme();
        }

        public static void UpdateTheme()
        {
            //if (!Properties.Settings.Default.DarkTheme) Theme = "Light"; else Theme = "Dark";
            ResourceDictionary resourceDict = Application.LoadComponent(new Uri($"Themes/Dark.xaml", UriKind.Relative)) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
    }
}
