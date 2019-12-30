using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using SEW.Models;
using System.Data.Entity;

namespace SEW.ViewModels
{
    public class WordVM : INotifyPropertyChanged
    {
        private long categoryID; //categoryID that gets from constructor

        #region Commands
        public DelegateCommand AddItemCmd
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    AddItem();
                });
            }
        }
        public DelegateCommand RemoveItemCmd
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    RemoveItem();
                });
            }
        }
        //public DelegateCommand UpdateCmd
        //{
        //    get
        //    {
        //        return new DelegateCommand(() =>
        //        {
        //            Update();
        //        });
        //    }
        //}
        public DelegateCommand UpdateAllCmd
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    UpdateAll();
                });
            }
        }
        #endregion
        #region for commands
        private void AddItem()
        {
            Word word = new Word
            {
                CanBeDisplayedAt = DateTime.Now,
                Review = 0,
                CategoryID = categoryID
            };
            Words.Insert(0, word);
            using (SEWContext db = new SEWContext())
            {
                db.Words.Add(word);
                db.SaveChanges();
            }
            SelectedWord = word;
        }
        private void RemoveItem()
        {
            using (SEWContext db = new SEWContext())
            {
                if (selectedWord != null)
                {
                    db.Entry(selectedWord).State = EntityState.Deleted;
                    db.SaveChanges();
                    Words.Remove(selectedWord);
                }
            }
        }
        #endregion
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
        public WordVM(long catID)
        {
            categoryID = catID;
            Words = new ObservableCollection<Word>();
            using (SEWContext db = new SEWContext())
            {
                List<Word> temp = db.Words.Where(c => c.CategoryID == categoryID).ToList();
                foreach (var item in temp)
                {
                    Words.Add(item);
                }
            }
        }

        #region Update
        public void UpdateAll()
        {
            using (SEWContext db = new SEWContext())
            {
                foreach (var item in Words)
                {
                    db.Entry(item).State = EntityState.Modified;
                }
                db.SaveChanges();
            }
        }
        //public void Update() // 
        //{
        //    if (selectedWord == null) return;
        //    using (SEWContext db = new SEWContext())
        //    {
        //        db.Entry(selectedWord).State = EntityState.Modified;
        //        db.SaveChanges();
        //    }
        //}
        #endregion
        public event PropertyChangedEventHandler PropertyChanged; // INotifyPropertyChanged
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        #region Properties
        public long ID
        {
            get { return SelectedWord.ID; }
            set { SelectedWord.ID = value; }
        }
        public string English
        {
            get { return SelectedWord.English; }
            set
            {
                SelectedWord.English = value;
                OnPropertyChanged("English");
            }
        }
        public string Russian
        {
            get { return SelectedWord.Russian; }
            set
            {
                SelectedWord.Russian = value;
                OnPropertyChanged("Russian");
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
        public string ProgressColor
        {
            get => CheckProgressColor();
        }
        private string CheckProgressColor()
        {
            switch (Status)
            {
                case "new": return "#d63a2b";
                case "start": return "#ccce2a";
                case "learning": return "#fc9e11";
                case "almost": return "#b2d541";
                case "learned": return "#3dc450";
                default: return "#717171";
            }
        }

        public string ReviewString
        {
            get => $"Повторено {Review}/7 раз";
        }
    }
}
