using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Collections.ObjectModel;
using SEW.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data.Entity;
using System.Threading;

namespace SEW
{
    // О, ещё вьюха без VM
    public partial class Remembering : Page
    {
        public Queue<Word> Words;
        public Word DisplayedWord;

        public Remembering()
        {
            InitializeComponent();

            Words = new Queue<Word>();

            using (SEWContext db = new SEWContext())
            {
                List<Word> temp = db.Words.Where(c => c.CanBeDisplayedAt < DateTime.Now).Where(c => c.Category.Included == true).ToList();
                foreach (var item in temp)
                {
                    Words.Enqueue(item);
                }
            }

            DisplayedWord = Words.Dequeue();
            if (DisplayedWord.Review == 0) TBlWord.Text = DisplayedWord.English;
            else TBlWord.Text = DisplayedWord.Russian;
        }

        private void BCW_Click(object sender, RoutedEventArgs e)
        {
            #region Check
            if (DisplayedWord.Review == 0) 
            {
                if (TBoxCW.Text == DisplayedWord.Russian)
                {
                    TBlAnswer.Foreground = Brushes.Green;
                    TBlAnswer.Text = DisplayedWord.Russian;
                }
                else
                {
                    TBlAnswer.Foreground = Brushes.Red;
                    TBlAnswer.Text = DisplayedWord.Russian;
                }
            }
            else
            {
                if (TBoxCW.Text == DisplayedWord.English)
                {
                    TBlAnswer.Foreground = Brushes.Green;
                    TBlAnswer.Text = DisplayedWord.English;
                }
                else
                {
                    TBlAnswer.Foreground = Brushes.Red;
                    TBlAnswer.Text = DisplayedWord.English;
                }
            }
            TBoxCW.Text = "";
            #endregion
            #region Change visibility
            TBlAnswer.Visibility = Visibility.Visible;
            TBoxCW.Visibility = Visibility.Hidden;
            BCW.Visibility = Visibility.Hidden;
            BYes.Visibility = Visibility.Visible;
            BNo.Visibility = Visibility.Visible;

            TBlAnswer.IsEnabled = true;
            TBoxCW.IsEnabled = false;
            BCW.IsEnabled = false;
            BYes.IsEnabled = true;
            BNo.IsEnabled = true;
            #endregion
        }

        private void BYes_Click(object sender, RoutedEventArgs e) => Answer(true);
        private void BNo_Click(object sender, RoutedEventArgs e) => Answer(false);


        #region Methods
        private void Answer(bool Reply)
        {
            if (Reply) 
            {
                switch (DisplayedWord.Review)
                {
                    case 0:
                        DisplayedWord.Review = 7;
                        DisplayedWord.CanBeDisplayedAt = DateTime.MaxValue;
                        DisplayedWord.Status = "already known";
                        break;
                    case 1:
                        DisplayedWord.Review = 2;
                        DisplayedWord.CanBeDisplayedAt = DateTime.Now.AddMinutes(20);
                        if(DisplayedWord.Status != "learning") DisplayedWord.Status = "start";
                        break;
                    case 2:
                        DisplayedWord.Review = 3;
                        DisplayedWord.CanBeDisplayedAt = DateTime.Now.AddDays(1);
                        DisplayedWord.Status = "learning";
                        break;
                    case 3:
                        DisplayedWord.Review = 4;
                        DisplayedWord.CanBeDisplayedAt = DateTime.Now.AddDays(2);
                        break;
                    case 4:
                        DisplayedWord.Review = 5;
                        DisplayedWord.CanBeDisplayedAt = DateTime.Now.AddDays(14);
                        break;
                    case 5:
                        DisplayedWord.Review = 6;
                        DisplayedWord.CanBeDisplayedAt = DateTime.Now.AddDays(60);
                        DisplayedWord.Status = "almost";
                        break;
                    case 6:
                        DisplayedWord.Review = 7;
                        DisplayedWord.CanBeDisplayedAt = DateTime.MaxValue;
                        DisplayedWord.Status = "learned";
                        break;
                }
            }
            else
            {
                if(DisplayedWord.Review == 0)
                {
                    DisplayedWord.Review = 1;
                    DisplayedWord.CanBeDisplayedAt = DateTime.Now.AddMinutes(2);
                    DisplayedWord.Status = "new";
                }
                else
                {
                    DisplayedWord.Review = 1;
                    DisplayedWord.CanBeDisplayedAt = DateTime.Now.AddMinutes(2);
                    DisplayedWord.Status = "learning";
                }
            }

            using (SEWContext db = new SEWContext()) //Save
            {
                db.Entry(DisplayedWord).State = EntityState.Modified;
                db.SaveChanges();
            }

            ShowNewWord();
        }
        private void ShowNewWord()
        {
            #region Change visibility
            TBlAnswer.Visibility = Visibility.Hidden;
            TBoxCW.Visibility = Visibility.Visible;
            BCW.Visibility = Visibility.Visible;
            BYes.Visibility = Visibility.Hidden;
            BNo.Visibility = Visibility.Hidden;

            TBlAnswer.IsEnabled = false;
            TBoxCW.IsEnabled = true;
            BCW.IsEnabled = true;
            BYes.IsEnabled = false;
            BNo.IsEnabled = false;
            #endregion

            DisplayedWord = Words.Dequeue();
            if(DisplayedWord == null)
            {
                using (SEWContext db = new SEWContext())
                {
                    List<Word> temp = db.Words.Where(c => c.CanBeDisplayedAt < DateTime.Now).Where(c => c.Category.Included == true).ToList();
                    foreach (var item in temp)
                    {
                        Words.Enqueue(item);
                    }
                }

                DisplayedWord = Words.Dequeue();
                if (DisplayedWord == null) // Если ничего нового не нашло
                {
                    TBlWord.Text = "Слова для повторения закончились.\nДобавьте новые или отдохните";
                    Task WaitingForNewWords = Task.Factory.StartNew(() => 
                    {
                        while (true)
                        {
                            Thread.Sleep(1000);
                            using (SEWContext db = new SEWContext())
                            {
                                List<Word> temp = db.Words.Where(c => c.CanBeDisplayedAt < DateTime.Now).Where(c => c.Category.Included == true).ToList();
                                foreach (var item in temp)
                                {
                                    Words.Enqueue(item);
                                }
                            }
                            DisplayedWord = Words.Dequeue();
                            if (DisplayedWord != null) // Если наконец нашло
                            {
                                ShowNewWord();
                                break;
                            }
                        }
                    });
                }
            }
            else
            {
                if(DisplayedWord.Review == 0) TBlWord.Text = DisplayedWord.English;
                else TBlWord.Text = DisplayedWord.Russian;
            }
        }
        #endregion
    }
}
