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



        //public byte InProgress
        //{
        //    get => CheckInProgress();
        //}

        //private byte CheckInProgress()
        //{
        //    int InProgress = 0;
        //    foreach (int element in _Words)
        //    {
        //        if (_Words.Word.InProgress[element]) InProgress++;
        //    }
        //    return byte(InProgress / _Words.Count);
        //}
    }
}
