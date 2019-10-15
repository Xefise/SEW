using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SEW.Models
{
    public class Word : INotifyPropertyChanged
    {
        private int _ID;
        private string _InEnglish;
        private string _InRussian;
        private DateTime _CanBeDisplayedAt;
        private byte _Review;

        private int _CategoryID;
        private Category _Category;

        private string _Transcription;
        private string _Status;
        private List<Example> _Examples;


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
        public DateTime CanBeDisplayedAt
        {
            get { return _CanBeDisplayedAt; }
            set
            {
                _CanBeDisplayedAt = value;
            }
        }
        public byte Review
        {
            get { return _Review; }
            set
            {
                _Review = value;
            }
        }

        public int CategoryID
        {
            get { return _CategoryID; }
            set
            {
                _CategoryID = value;
            }
        }
        public Category Category
        {
            get { return _Category; }
            set
            {
                _Category = value;
            }
        }

        public string Transcription
        {
            get { return _Transcription; }
            set
            {
                _Transcription = value;
            }
        }
        public string Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
            }
        }
        public List<Example> Examples
        {
            get { return _Examples; }
            set
            {
                _Examples = value;
            }
        }
        
        public bool InProgress
        {
            get => CheckInProgress();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }


        private bool CheckInProgress()
        {
            if (Status != "New_word") return false;
            else return true;
        }
    }
}
