using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using SEW.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;

namespace SEW.ViewModels
{
    public class SearchWordVM : INotifyPropertyChanged
    {
        private MainWindow mainWindow;
        private string searchText { get; set; }
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyChanged("Search");
            }
        }

        #region Commands
        public DelegateCommand RemoveItemCmd
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    DialogResult dialogResult = MessageBox.Show("Вы точно хотите удалить это слово?", "Подтверждение", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        RemoveItem();
                    }
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
        public DelegateCommand GoToWordExamplesCMD
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    GoToWordExamples();
                });
            }
        }
        public DelegateCommand ResetWordCmd
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    ResetWord();
                });
            }
        }
        public DelegateCommand SearchWordsCMD
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    SearchWords();
                });
            }
        }
        #endregion
        #region for commands
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
        private void GoToWordExamples()
        {
            if (SelectedWord == null) return;
            mainWindow.GoToExamplesPage(SelectedWord.ID);
        }
        private void ResetWord()
        {
            if (SelectedWord == null) return;

            SelectedWord.Review = 0;
            SelectedWord.Status = "";
            SelectedWord.CanBeDisplayedAt = DateTime.Now;

            if (Properties.Settings.Default.TTResetShowed == false)
            {
                System.Windows.MessageBox.Show("Прогресс сброшен! (Это сообщение больше не появится)");
                Properties.Settings.Default.TTResetShowed = true;
            }

            using (SEWContext db = new SEWContext())
            {
                db.Entry(SelectedWord).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        private void SearchWords()
        {
            Words.Clear();

            using (SEWContext db = new SEWContext())
            {
                List<Word> temp = db.Words.ToList();
                foreach (var item in temp)
                {
                    if(item.English.ToLower().Contains(SearchText.ToLower()) || item.Russian.ToLower().Contains(SearchText.ToLower()))
                    Words.Add(item);
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
        public SearchWordVM(MainWindow main)
        {
            mainWindow = main;

            Words = new ObservableCollection<Word>();
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
    }
}
