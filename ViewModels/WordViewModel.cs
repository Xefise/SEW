using System.Collections.Generic;
using System.Collections.ObjectModel;
using SEW.Models;
using System.Linq;
using System;

namespace SEW.ViewModels
{
    public class WordViewModel : BaseVM
    {
        public ObservableCollection<Word> Words { get; set; }
        public WordViewModel()
        {
            Words = new ObservableCollection<Word>();
            using (SEWContext db = new SEWContext())
            {
                List<Word> temp = db.Words.ToList();
                foreach (var item in temp)
                {
                    Words.Add(item);
                }
            }
        }


        Word word = new Word();

        public long ID
        {
            get { return word.ID; }
            set { word.ID = value; }
        }
        public string InEnglish
        {
            get { return word.InEnglish; }
            set
            {
                word.InEnglish = value;
                OnPropertyChanged("InEnglish");
            }
        }
        public string InRussian
        {
            get { return word.InRussian; }
            set
            {
                word.InRussian = value;
                OnPropertyChanged("InRussian");
            }
        }
        public DateTime CanBeDisplayedAt
        {
            get { return word.CanBeDisplayedAt; }
            set
            {
                word.CanBeDisplayedAt = value;
                OnPropertyChanged("CanBeDisplayedAt");
            }
        }
        public byte Review
        {
            get { return word.Review; }
            set
            {
                word.Review = value;
                OnPropertyChanged("Review");
            }
        }

        public long CategoryID
        {
            get { return word.CategoryID; }
            set
            {
                word.CategoryID = value;
                OnPropertyChanged("CategoryID");
            }
        }
        public Category Category
        {
            get { return word.Category; }
            set
            {
                word.Category = value;
                OnPropertyChanged("Category");
            }
        }

        public string Transcription
        {
            get { return word.Transcription; }
            set
            {
                word.Transcription = value;
                OnPropertyChanged("Transcription");
            }
        }
        public string Status
        {
            get { return word.Status; }
            set
            {
                word.Status = value;
                OnPropertyChanged("Status");
            }
        }
        public List<Example> Examples
        {
            get { return word.Examples; }
            set
            {
                word.Examples = value;
                OnPropertyChanged("Examples");
            }
        }

        public bool InProgress
        {
            get => CheckInProgress();
        }

        private bool CheckInProgress()
        {
            if (Status != "New word") return false;
            else return true;
        }
    }
}
