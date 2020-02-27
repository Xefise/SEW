using System.ComponentModel.DataAnnotations;
using SEW.ViewModels.KindOfMagic;

namespace SEW.Models
{
    public class Example : PropertyChangedMagic
    {
        [Key] public long ID { get; set; }
        public string English { get; set; }
        public string Russian { get; set; }

        public long WordID { get; set; }
        public Word Word { get; set; }
    }
}
