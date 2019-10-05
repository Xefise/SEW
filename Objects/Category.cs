using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SEW
{
    public class Category : INotifyPropertyChanged
    {
        private long _ID;
        private string _Name;
        private List<Word> _Words;

        public long ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
                OnPropertyChanged("ID");
            }
        }
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }
        public List<Word> Words
        {
            get { return _Words; }
            set
            {
                _Words = value;
                OnPropertyChanged("words");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
