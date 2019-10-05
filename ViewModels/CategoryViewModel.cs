using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SEW
{
    public class CategoryViewModel : INotifyPropertyChanged
    {
        private Category _selectedCategory;

        public ObservableCollection<Category> Categories { get; set; }
        public Category selectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged("SelectedPhone");
            }
        }

        public CategoryViewModel()
        {
            Categories = new ObservableCollection<Category>
            {
                new Category {ID=1, Name="Animals"},
                new Category {ID=2, Name="Top 10"},
                new Category {ID=3, Name="Top 20"},
                new Category {ID=4, Name="Top 30"}
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}