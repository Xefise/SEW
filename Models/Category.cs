using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEW.Models
{
    public class Category
    {
        [Key] public long ID { get; set; }
        public string Name { get; set; }
        public List<Word> Words { get; set; }
        public bool Included { get; set; }
        public int? WordCount { get; set; }

        public string WCDisplay
        {
            get => MakeWCDisplay();
        }


        private string MakeWCDisplay()
        {
            return $"{WordCount} слов";
        }
    }
}
