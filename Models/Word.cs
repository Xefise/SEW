using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEW.Models
{
    public class Word
    {
        [Key] public long ID;
        public string InEnglish;
        public string InRussian;
        public DateTime CanBeDisplayedAt;
        public byte Review;

        public long CategoryID;
        public Category Category;

        public string Transcription;
        public string Status;
        public List<Example> Examples;
    }
}
