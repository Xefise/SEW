using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEW.Models
{
    public class Word
    {
        [Key] public long ID { get; set; }
        public string English { get; set; }
        public string Russian { get; set; }
        public DateTime CanBeDisplayedAt { get; set; }
        public byte Review { get; set; }

        public long CategoryID { get; set; }
        public Category Category { get; set; }

        public string Transcription { get; set; }
        public string Status { get; set; }
        public List<Example> Examples { get; set; }

        public string ProgressColor
        {
            get => CheckProgressColor();
        }
        private string CheckProgressColor()
        {
            switch (Status)
            {
                case "new": return "#d63a2b"; //1
                case "start": return "#ffca00"; //2
                case "learning": return "#fafc11"; //3-5
                case "almost": return "#ccff00"; //6
                case "learned": return "#3dc450"; //7
                case "already known": return "#7be1f0"; //7
                default: return "#717171"; // 0
            }
        }
        public string ReviewString
        {
            get => $"Повторено {Review}/6 раз";
        }

    }
}
