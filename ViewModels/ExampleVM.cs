using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using SEW.Models;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace SEW.ViewModels
{
    public class ExampleVM : INotifyPropertyChanged
    {
        private long wordID;

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
        #region For commands
        private void AddItem()
        {
            Example example = new Example
            {
                WordID = wordID
            };
            Examples.Insert(0, example);
            using (SEWContext db = new SEWContext())
            {
                db.Examples.Add(example);
                db.SaveChanges();
            }
            SelectedExample = example;
        }
        private void RemoveItem()
        {
            using (SEWContext db = new SEWContext())
            {
                if (selectedExample != null)
                {
                    db.Entry(selectedExample).State = EntityState.Deleted;
                    db.SaveChanges();
                    Examples.Remove(selectedExample);
                }
            }
        }
        #endregion

        private Example selectedExample { get; set; }
        public Example SelectedExample
        {
            get { return selectedExample; }
            set
            {
                selectedExample = value;
                OnPropertyChanged("SelectedExample");
            }
        }

        public ObservableCollection<Example> Examples { get; set; }
        public ExampleVM(long wordid)
        {
            wordID = wordid;

            Examples = new ObservableCollection<Example>();
            using (SEWContext db = new SEWContext())
            {
                List<Example> temp = db.Examples.Where(c => c.WordID == wordID).ToList();
                foreach (var item in temp)
                {
                    Examples.Add(item);
                }
            }
        }

        #region Update
        public void UpdateAll()
        {
            using (SEWContext db = new SEWContext())
            {
                foreach (var item in Examples)
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
            get { return SelectedExample.ID; }
            set { SelectedExample.ID = value; }
        }
        public string English
        {
            get { return SelectedExample.English; }
            set
            {
                SelectedExample.English = value;
                OnPropertyChanged("English");
            }
        }
        public string Russian
        {
            get { return SelectedExample.Russian; }
            set
            {
                SelectedExample.Russian = value;
                OnPropertyChanged("Russian");
            }
        }

        public long WordID
        {
            get { return SelectedExample.WordID; }
            set
            {
                SelectedExample.WordID = value;
                OnPropertyChanged("WordID");
            }
        }
        //public Word Word
        //{
        //    get { return SelectedExample.Word; }
        //    set
        //    {
        //        SelectedExample.Word = value;
        //        OnPropertyChanged("Word");
        //    }
        //}
        #endregion
    }
}
