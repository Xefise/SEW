using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SEW.Models;

namespace SEW.ViewModels
{
    public class DayViewModel : BaseVM
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
        public DayViewModel()
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
