using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using SEW.Models;
using Microsoft.EntityFrameworkCore;

namespace SEW.ViewModels
{
    public class DayVM : INotifyPropertyChanged
    {
        private Day selectedDay { get; set; }
        public Day SelectedDay
        {
            get { return selectedDay; }
            set
            {
                selectedDay = value;
                OnPropertyChanged("SelectedDay");
            }
        }

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
                db.Entry(selectedDay).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged; // INotifyPropertyChanged
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            Update(); // Update a property when the property changes
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        #region Properties
        public long ID
        {
            get { return SelectedDay.ID; }
            set { SelectedDay.ID = value; }
        }
        public DateTime Date
        {
            get { return SelectedDay.Date; }
            set
            {
                SelectedDay.Date = value;
                OnPropertyChanged("Date");
            }
        }
        public int AlReadyKnown
        {
            get { return SelectedDay.AlReadyKnown; }
            set
            {
                SelectedDay.AlReadyKnown = value;
                OnPropertyChanged("AlReadyKnown");
            }
        }
        public int NewWords
        {
            get { return SelectedDay.NewWords; }
            set
            {
                SelectedDay.NewWords = value;
                OnPropertyChanged("NewWords");
            }
        }
        public int Reviewed
        {
            get { return SelectedDay.Reviewed; }
            set
            {
                SelectedDay.Reviewed = value;
                OnPropertyChanged("Reviewed");
            }
        }
        //public int Learned
        //{
        //    get { return SelectedDay.Learned; }
        //    set
        //    {
        //        SelectedDay.Learned = value;
        //        OnPropertyChanged("Learned");
        //    }
        //}
        public int Score
        {
            get { return SelectedDay.Score; }
            set
            {
                SelectedDay.Score = value;
                OnPropertyChanged("Score");
            }
        }
        #endregion
    }
}
