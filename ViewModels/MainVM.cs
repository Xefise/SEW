using DevExpress.Mvvm;
using SEW.Services;
using System.Windows.Controls;

namespace SEW.ViewModels
{
    public class MainVM
    {
        readonly PageService navigation;

        public Page CurrentPage { get; set; }

        public MainVM(PageService Navigation)
        {
            Navigation.OnPageChanged += page => CurrentPage = page;
            Navigation.Navigate(new Remembering());
            navigation = Navigation;
        }

        #region Commands
        #region GoToPage
        public DelegateCommand GoToCategories => new DelegateCommand(() =>
        {
            navigation.Navigate(new Categories());
        });

        public DelegateCommand GoToWordSearch => new DelegateCommand(() =>
        {
            navigation.Navigate(new WordSearch());
        });

        public DelegateCommand GoToRemembering => new DelegateCommand(() =>
        {
            navigation.Navigate(new Remembering());
        });

        public DelegateCommand GoToSettings => new DelegateCommand(() =>
        {
            navigation.Navigate(new Settings());
        });

        public DelegateCommand GoBack => new DelegateCommand(() =>
        {
            navigation.GoBack();
        }, () => navigation.CanGoBack);

        #endregion

        #endregion
    }
}
