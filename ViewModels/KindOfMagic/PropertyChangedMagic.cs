using System.ComponentModel;

namespace SEW.ViewModels.KindOfMagic
{
    [Magic]
    public abstract class PropertyChangedMagic : INotifyPropertyChanged
    {
        protected virtual void RaisePropertyChanged(string propName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
