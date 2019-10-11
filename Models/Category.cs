using System.Collections.Generic;

namespace SEW.Models
{
    public class Category
    {
        private long _ID;
        private string _Name;
        //private List<Word> _Words;

        public long ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
            }
        }
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
            }
        }
        //public List<Word> Words
        //{
        //    get { return _Words; }
        //    set
        //    {
        //        _Words = value;
        //    }
        //}
    }
}
