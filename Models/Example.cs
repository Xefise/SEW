using System.ComponentModel.DataAnnotations;

namespace SEW.Models
{
    public class Example
    {
        [Key] public long ID { get; set; }
        public string English { get; set; }
        public string Russian { get; set; }

        public long WordID { get; set; }
        public Word Word { get; set; }
    }
}
