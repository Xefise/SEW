﻿using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SEW.Models;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Data.Entity;

namespace SEW.ViewModels
{
    public class CategoryVM : INotifyPropertyChanged
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
                if (selectedCategory != null)
                {
                    db.Entry(selectedCategory).State = EntityState.Deleted;
                    db.SaveChanges();
                    Categories.Remove(selectedCategory);
                }
            }
        }
        private void GoToCategoryWords()
        {
            if (SelectedCategory == null) return;
            Properties.Settings.Default.CategoryID = SelectedCategory.ID;
            Properties.Settings.Default.Save();
            mainWindow.GoToWordsPage(SelectedCategory.ID);
        }
        #endregion

        private Category selectedCategory { get; set; }
        public Category SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }

        public ObservableCollection<Category> Categories { get; set; }
        public CategoryVM(MainWindow main)
        {
            mainWindow = main;
            Categories = new ObservableCollection<Category>();
            using (SEWContext db = new SEWContext())
            {
                List<Category> temp = db.Categories.ToList();
                foreach (var item in temp)
                {
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

        public event PropertyChangedEventHandler PropertyChanged; // INotifyPropertyChanged
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }



        #region Properties
        public long ID
        {
            get { return SelectedCategory.ID; }
            set { SelectedCategory.ID = value; }
        }
        public string Name
        {
            get { return SelectedCategory.Name; }
            set
            {
                SelectedCategory.Name = value;
                OnPropertyChanged("Name");
                MessageBox.Show("Name");
            }
        }
        //public List<Word> Words
        //{
        //    get { return SelectedCategory.Words; }
        //    set
        //    {
        //        SelectedCategory.Words = value;
        //        OnPropertyChanged("Words");
        //    }
        //}
        public bool Included
        {
            get { return SelectedCategory.Included; }
            set
            {
                SelectedCategory.Included = value;
                OnPropertyChanged("Included");
            }
        }
        //public int WordCount
        //{
        //    get => Words.Count;
        //}
        #endregion
    }
}