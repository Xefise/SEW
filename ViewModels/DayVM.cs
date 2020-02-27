using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SEW.Models;
using Microsoft.EntityFrameworkCore;
using SEW.ViewModels.KindOfMagic;

namespace SEW.ViewModels
{
    public class DayVM : PropertyChangedMagic
    {
        public Day SelectedDay { get; set; }

        public ObservableCollection<Day> Days { get; set; }
        public DayVM()
        {
            Days = new ObservableCollection<Day>();
            using (SEWContext db = new SEWContext())
            {
                List<Day> temp = db.Days.ToList();
                foreach (var item in temp)
                {
                    Days.Add(item);
                }
            }
        }

        public void Update()
        {
            using (SEWContext db = new SEWContext())
            {
                db.Entry(SelectedDay).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        #region Properties
        public long ID { get; set; }
        public DateTime Date { get; set; }
        public int AlReadyKnown { get; set; }
        public int NewWords { get; set; }
        public int Reviewed { get; set; }
        //public int Learned{ get; set; }
        public int Score { get; set; }
        #endregion
    }
}
