using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SEW.Models
{
    public class Example : INotifyPropertyChanged
    {
        private int _ID;
        private string _InEnglish;
        private string _InRussian;
        private int _WordID;
        private Word _Word;


        public int ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
            }
        }
        public string InEnglish
        {
            get { return _InEnglish; }
            set
            {
                _InEnglish = value;
            }
        }
        public string InRussian
        {
            get { return _InRussian; }
            set
            {
                _InRussian = value;
            }
        }

        public int WordID
        {
            get { return _WordID; }
            set
            {
                _WordID = value;
            }
        }
        public Word Word
        {
            get { return _Word; }
            set
            {
                _Word = value;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
