using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SEW.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using SEW.ViewModels.KindOfMagic;

namespace SEW.ViewModels
{
    public class ExampleVM : PropertyChangedMagic
    {
        private long wordID;
        private MainWindow Window;

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
                    DialogResult dialogResult = MessageBox.Show("Вы точно хотите удалить этот пример?", "Подтверждение", MessageBoxButtons.YesNo);
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
        public DelegateCommand GoBackCmd
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    GoBack();
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
                if (SelectedExample != null)
                {
                    db.Entry(SelectedExample).State = EntityState.Deleted;
                    db.SaveChanges();
                    Examples.Remove(SelectedExample);
                }
            }
        }
        private void GoBack() => Window.GoToLastPage();
        #endregion

        public Example SelectedExample { get; set; }

        public ObservableCollection<Example> Examples { get; set; }
        public ExampleVM(MainWindow window, long wordid)
        {
            wordID = wordid;
            Window = window;

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

        #region Properties
        public long ID { get; set; }
        public string English { get; set; }
        public string Russian { get; set; }

        public long WordID { get; set; }
        //public Word Word { get; set; }
        #endregion
    }
}
