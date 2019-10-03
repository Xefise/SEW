using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEW
{
    public class Category
    {
        private long _ID;
        private string _Name;
        private List<Word> _words;

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
        public List<Word> words
        {
            get { return _words; }
            set
            {
                _words = value;
            }
        }
    }
}
