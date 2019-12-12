using System.Collections.Generic;
using System.Collections.ObjectModel;
using SEW.Models;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SEW.Command;
using System.Windows;

namespace SEW.ViewModels
{
    public class CategoryViewModel : INotifyPropertyChanged
    {
        private Category selectedCategory { get; set; }
        public Category SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                if(SelectedCategory != null)Update();
                selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }

        public ObservableCollection<Category> Categories { get; set; }
        public CategoryViewModel()
        {
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

        public void Update()
        {
            using (SEWContext db = new SEWContext())
            {
                db.Entry(SelectedCategory).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged; // INotifyPropertyChanged
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            Update(); // Update a property when the property changes
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
        public List<Word> Words
        {
            get { return SelectedCategory.Words; }
            set
            {
                SelectedCategory.Words = value;
                OnPropertyChanged("Words");
            }
        }
        public bool Included
        {
            get { return SelectedCategory.Included; }
            set
            {
                SelectedCategory.Included = value;
                OnPropertyChanged("Included");
            }
        }
        public int WordCount
        {
            get => Words.Count;
        }
        #endregion
    }
}