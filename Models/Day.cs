using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SEW.Models
{
    public class Day : INotifyPropertyChanged
    {
        private long _ID;
        private DateTime _Data;
        private int _AlReadyKnown;
        private int _NewWords; //memorized
        private int _Reviewed;
        //private int _Learned;
        private int _Score; // _AlReadyKnown + _NewWords + _ReViewed //+ _Learned


        public long ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
            }
        }
        public DateTime Data
        {
            get { return _Data; }
            set
            {
                _Data = value;
            }
        }
        public int AlReadyKnown
        {
            get { return _AlReadyKnown; }
            set
            {
                _AlReadyKnown = value;
            }
        }
        public int NewWords
        {
            get { return _NewWords; }
            set
            {
                _NewWords = value;
            }
        }
        public int Reviewed
        {
            get { return _Reviewed; }
            set
            {
                _Reviewed = value;
            }
        }
        //public int Learned
        //{
        //    get { return _Learned; }
        //    set
        //    {
        //        _Learned = value;
        //    }
        //}
        public int Score
        {
            get { return _Score; }
            set
            {
                _Score = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
