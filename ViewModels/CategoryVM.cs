using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SEW.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using SEW.ViewModels.KindOfMagic;

namespace SEW.ViewModels
{
    public class CategoryVM : PropertyChangedMagic
    {
        private MainWindow mainWindow;
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
                    DialogResult dialogResult = MessageBox.Show("Вы точно хотите удалить эту категорию?", "Подтверждение", MessageBoxButtons.YesNo);
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
        public DelegateCommand GoToCategoryWordsCmd
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    GoToCategoryWords();
                });
            }
        }
        #endregion
        #region for commands
        private void AddItem()
        {
            Category category = new Category();
            Categories.Insert(0, category);
            using (SEWContext db = new SEWContext())
            {
                db.Categories.Add(category);
                db.SaveChanges();
            }
            SelectedCategory = category;
        }
        private void RemoveItem()
        {
            using (SEWContext db = new SEWContext())
            {
                if (SelectedCategory != null)
                {
                    db.Entry(SelectedCategory).State = EntityState.Deleted;
                    db.SaveChanges();
                    Categories.Remove(SelectedCategory);
                }
            }
        }
        private void GoToCategoryWords() 
        {
            if (SelectedCategory == null) return;
            mainWindow.GoToWordsPage(SelectedCategory.ID); //ahaahah ahah ah...
        }
        #endregion

        public Category SelectedCategory { get; set; }

        public ObservableCollection<Category> Categories { get; set; }
        public CategoryVM(MainWindow main)
        {
            mainWindow = main; // WOW! We've main window! | For GoToCategoryWords()

            Categories = new ObservableCollection<Category>();
            using (SEWContext db = new SEWContext())
            {
                List<Category> temp = db.Categories.ToList();
                foreach (var item in temp)
                {
                    item.WordCount = db.Words.Where(c => c.CategoryID == item.ID).Count();
                    Categories.Add(item);
                }
            }
        }

        #region Update
        public void UpdateAll()
        {
            using (SEWContext db = new SEWContext())
            {
                foreach (var item in Categories)
                {
                    db.Entry(item).State = EntityState.Modified;
                }
                db.SaveChanges();
            }
        }
        //public void Update() // 
        //{
        //    if (selectedCategory == null) return;
        //    using (SEWContext db = new SEWContext())
        //    {
        //        db.Entry(selectedCategory).State = EntityState.Modified;
        //        db.SaveChanges();
        //    }
        //}
        #endregion


        #region Properties
        public long ID { get; set; }
        public string Name { get; set; }
        //public List<Word> Words{ get; set; }
        public bool Included { get; set; }
        public int? WordCount { get; set; }
        #endregion
    }
}