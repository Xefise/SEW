using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEW.Models
{
    public class Word
    {
        [Key] public long ID { get; set; }
        public string InEnglish { get; set; }
        public string InRussian { get; set; }
        public DateTime CanBeDisplayedAt { get; set; }
        public byte Review { get; set; }

        public long CategoryID { get; set; }
        public Category Category { get; set; }

        public string Transcription { get; set; }
        public string Status { get; set; }
        public List<Example> Examples { get; set; }
    }
}
