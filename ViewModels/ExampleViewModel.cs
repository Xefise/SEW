using System.Collections.Generic;
using System.Collections.ObjectModel;
using SEW.Models;
using System.Linq;

namespace SEW.ViewModels
{
    public class ExampleViewModel : BaseVM
    {
        private Example selectedExample { get; set; }
        public Example SelectedExample
        {
            get { return selectedExample; }
            set
            {
                selectedExample = value;
                OnPropertyChanged("SelectedExapmle");
            }
        }

        public ObservableCollection<Example> Examples { get; set; }
        public ExampleViewModel()
        {
            Examples = new ObservableCollection<Example>();
            using (SEWContext db = new SEWContext())
            {
                List<Example> temp = db.Examples.ToList();
                foreach (var item in temp)
                {
                    Examples.Add(item);
                }
            }
        }

        #region Properties
        public long ID
        {
            get { return SelectedExample.ID; }
            set { SelectedExample.ID = value; }
        }
        public string InEnglish
        {
            get { return SelectedExample.InEnglish; }
            set
            {
                SelectedExample.InEnglish = value;
                OnPropertyChanged("InEnglish");
            }
        }
        public string InRussian
        {
            get { return SelectedExample.InRussian; }
            set
            {
                SelectedExample.InRussian = value;
                OnPropertyChanged("InRussian");
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
        public Word Word
        {
            get { return SelectedExample.Word; }
            set
            {
                SelectedExample.Word = value;
                OnPropertyChanged("Word");
            }
        }
        #endregion
    }
}
