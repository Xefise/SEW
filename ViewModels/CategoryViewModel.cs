using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SEW.Models;
using System.Linq;

namespace SEW.ViewModels
{
    public class CategoryViewModel : INotifyPropertyChanged
    {
        //private Category _selectedCategory;
        
        //public Category selectedCategory
        //{
        //    get { return _selectedCategory; }
        //    set
        //    {
        //        _selectedCategory = value;
        //        OnPropertyChanged("SelectedPhone");
        //    }
        //}
        
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


        Category category = new Category();

        public long ID
        {
            get { return category.ID; }
            set { category.ID = value; }
        }
        public string Name
        {
            get { return category.Name; }
            set
            {
                category.Name = value;
                OnPropertyChanged("Name");
            }
        }
        public List<Word> Words
        {
            get { return category.Words; }
            set
            {
                category.Words = value;
                OnPropertyChanged("Words");
            }
        }
        public bool Included
        {
            get { return category.Included; }
            set
            {
                category.Included = value;
                OnPropertyChanged("Included");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}