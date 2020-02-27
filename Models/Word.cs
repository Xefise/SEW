using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SEW.ViewModels.KindOfMagic;

namespace SEW.Models
{
    public class Word : PropertyChangedMagic
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
                case "start": return "#fc9111"; //2
                case "learning": return "#fafc11"; //3-5
                case "almost": return "#ade61d"; //6
                case "learned": return "#3dc450"; //7
                case "already known": return "#7be1f0"; //7
                default: return "#717171"; // 0
            }
        }
        public string ReviewString
        {
            get => $"Повторено {Review}/7 раз";
        }

    }
}
