using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SEW.Models;

namespace SEW.ViewModels
{
    public class DayViewModel : INotifyPropertyChanged
    {
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


        Day day = new Day();

        public long ID
        {
            get { return day.ID; }
            set { day.ID = value; }
        }
        public DateTime Date
        {
            get { return day.Date; }
            set
            {
                day.Date = value;
                OnPropertyChanged("Date");
            }
        }
        public int AlReadyKnown
        {
            get { return day.AlReadyKnown; }
            set
            {
                day.AlReadyKnown = value;
                OnPropertyChanged("AlReadyKnown");
            }
        }
        public int NewWords
        {
            get { return day.NewWords; }
            set
            {
                day.NewWords = value;
                OnPropertyChanged("NewWords");
            }
        }
        public int Reviewed
        {
            get { return day.Reviewed; }
            set
            {
                day.Reviewed = value;
                OnPropertyChanged("Reviewed");
            }
        }
        //public int Learned
        //{
        //    get { return _Learned; }
        //    set
        //    {
        //        _Learned = value;
        //        OnPropertyChanged("Learned");
        //    }
        //}
        public int Score
        {
            get { return day.Score; }
            set
            {
                day.Score = value;
                OnPropertyChanged("Score");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
