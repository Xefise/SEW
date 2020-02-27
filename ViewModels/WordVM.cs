using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SEW.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using SEW.ViewModels.KindOfMagic;

namespace SEW.ViewModels
{
    public class WordVM : PropertyChangedMagic
    {
        private MainWindow mainWindow;
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
        #endregion
        #region for commands
        private void AddItem()
        {
            Word word = new Word
            {
                English = "new word",
                Russian = "новое слово",
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
                if (SelectedWord != null)
                {
                    db.Entry(SelectedWord).State = EntityState.Deleted;
                    db.SaveChanges();
                    Words.Remove(SelectedWord);
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
        #endregion

        public Word SelectedWord { get; set; }

        public ObservableCollection<Word> Words { get; set; }
        public WordVM(MainWindow main, long catID)
        {
            mainWindow = main;
            categoryID = catID;

            Words = new ObservableCollection<Word>();
            using (SEWContext db = new SEWContext())
            {
                List<Word> temp = db.Words.Where(c => c.CategoryID == categoryID).OrderByDescending(c => c.Review).ToList();
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

        #region Properties
        public long ID { get; set; }
        public string English { get; set; }
        public string Russian { get; set; }
        public DateTime CanBeDisplayedAt { get; set; }
        public byte Review { get; set; }

        public long CategoryID { get; set; }
        public Category Category { get; set; }

        public string Transcription { get; set; }
        public string Status { get; set; }
        public List<Example> Examples { get; set; }
        #endregion
    }
}
