using System.Collections.Generic;
using System.Collections.ObjectModel;
using SEW.Models;
using System.Linq;

namespace SEW.ViewModels
{
    public class CategoryViewModel : BaseVM
    {
        private Category selectCategory { get; set; }
        public Category SelectCategory
        {
            get { return selectCategory; }
            set
            {
                selectCategory = value;
                OnPropertyChanged("SelectCategory");
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
                db.Entry(selectCategory).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        #region Properties
        public long ID
        {
            get { return SelectCategory.ID; }
            set { SelectCategory.ID = value; }
        }
        public string Name
        {
            get { return SelectCategory.Name; }
            set
            {
                SelectCategory.Name = value;
                OnPropertyChanged("Name");
            }
        }
        public List<Word> Words
        {
            get { return SelectCategory.Words; }
            set
            {
                SelectCategory.Words = value;
                OnPropertyChanged("Words");
            }
        }
        public bool Included
        {
            get { return SelectCategory.Included; }
            set
            {
                SelectCategory.Included = value;
                OnPropertyChanged("Included");
            }
        }
        #endregion
    }
}