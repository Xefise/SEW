using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace SEW
{
    public class Example : INotifyPropertyChanged
    {
        private string _InEnglish;
        private string _InRussian;
        private Word _word;

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
        public Word word
        {
            get { return _word; }
            set
            {
                _word = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
