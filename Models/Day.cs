using SEW.ViewModels.KindOfMagic;
using System;
using System.ComponentModel.DataAnnotations;

namespace SEW.Models
{
    public class Day : PropertyChangedMagic
    {
        [Key] public long ID { get; set; }
        public DateTime Date { get; set; }
        public int AlReadyKnown { get; set; }
        public int NewWords { get; set; } //memorized
        public int Reviewed { get; set; }
        //private int Learned;
        public int Score { get; set; } // _AlReadyKnown + _NewWords + _ReViewed //+ _Learned
    }
}
