using System.Collections.Generic;
using System.Collections.ObjectModel;
using SEW.Models;
using System.Linq;

namespace SEW.ViewModels
{
    public class ExampleViewModel : BaseVM
    {
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


        Example example = new Example();

        public long ID
        {
            get { return example.ID; }
            set { example.ID = value; }
        }
        public string InEnglish
        {
            get { return example.InEnglish; }
            set
            {
                example.InEnglish = value;
                OnPropertyChanged("InEnglish");
            }
        }
        public string InRussian
        {
            get { return example.InRussian; }
            set
            {
                example.InRussian = value;
                OnPropertyChanged("InRussian");
            }
        }

        public long WordID
        {
            get { return example.WordID; }
            set
            {
                example.WordID = value;
                OnPropertyChanged("WordID");
            }
        }
        public Word Word
        {
            get { return example.Word; }
            set
            {
                example.Word = value;
                OnPropertyChanged("Word");
            }
        }
    }
}
