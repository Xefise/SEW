using System.ComponentModel;

namespace SEW.ViewModels.KindOfMagic
{
    [Magic] // MAGIC! A magic stick *wave* -> *4-7 lines of code for each variable blowed up* Oh, it's pretty funny:D
    public abstract class PropertyChangedMagic : INotifyPropertyChanged // I've won you!
    {
        protected virtual void RaisePropertyChanged(string propName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName)); // lambda + ?.Invoke power

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
