using System.Collections.Generic;
using System.Collections.ObjectModel;
using SEW.Models;
using System.Linq;
using System;

namespace SEW.ViewModels
{
    public class WordViewModel : BaseVM
    {
        private Word selectedWord { get; set; }
        public Word SelectedWord
        {
            get { return selectedWord; }
            set
            {
                selectedWord = value;
                OnPropertyChanged("SelectedWord");
            }
        }

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

        #region Properties
        public long ID
        {
            get { return SelectedWord.ID; }
            set { SelectedWord.ID = value; }
        }
        public string InEnglish
        {
            get { return SelectedWord.InEnglish; }
            set
            {
                SelectedWord.InEnglish = value;
                OnPropertyChanged("InEnglish");
            }
        }
        public string InRussian
        {
            get { return SelectedWord.InRussian; }
            set
            {
                SelectedWord.InRussian = value;
                OnPropertyChanged("InRussian");
            }
        }
        public DateTime CanBeDisplayedAt
        {
            get { return SelectedWord.CanBeDisplayedAt; }
            set
            {
                SelectedWord.CanBeDisplayedAt = value;
                OnPropertyChanged("CanBeDisplayedAt");
            }
        }
        public byte Review
        {
            get { return SelectedWord.Review; }
            set
            {
                SelectedWord.Review = value;
                OnPropertyChanged("Review");
            }
        }

        public long CategoryID
        {
            get { return SelectedWord.CategoryID; }
            set
            {
                SelectedWord.CategoryID = value;
                OnPropertyChanged("CategoryID");
            }
        }
        public Category Category
        {
            get { return SelectedWord.Category; }
            set
            {
                SelectedWord.Category = value;
                OnPropertyChanged("Category");
            }
        }

        public string Transcription
        {
            get { return SelectedWord.Transcription; }
            set
            {
                SelectedWord.Transcription = value;
                OnPropertyChanged("Transcription");
            }
        }
        public string Status
        {
            get { return SelectedWord.Status; }
            set
            {
                SelectedWord.Status = value;
                OnPropertyChanged("Status");
            }
        }
        public List<Example> Examples
        {
            get { return SelectedWord.Examples; }
            set
            {
                SelectedWord.Examples = value;
                OnPropertyChanged("Examples");
            }
        }
#endregion
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
