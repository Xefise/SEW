using System.ComponentModel.DataAnnotations;

namespace SEW.Models
{
    public class Example
    {
        [Key] public long ID { get; set; }
        public string InEnglish { get; set; }
        public string InRussian { get; set; }

        public long WordID { get; set; }
        public Word Word { get; set; }
    }
}
