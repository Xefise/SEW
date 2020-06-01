using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using SEW.Models;
using System.Threading;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using System.Speech.Synthesis;

namespace SEW
{
    // О, ещё вьюха без VM
    public partial class Remembering : Page
    {
        public ObservableCollection<Example> Examples { get; set; }
        public Queue<Word> Words;
        public Word DisplayedWord;
        SpeechSynthesizer reader = new SpeechSynthesizer();

        public Remembering()
        {
            InitializeComponent();
            DataContext = this;

            Words = new Queue<Word>();
            AddWords();
            ShowNewWord();

            Task.Run(() => UpdateWordsList());
        }

        #region Controls
        private void BCW_Click(object sender, RoutedEventArgs e) // "Проверить"
        { 
            CheckWords();
        }

        private void KeyboardIn(object sender, System.Windows.Input.KeyEventArgs e)// "Enter" на клавиатуре
        {
            if (e.Key == System.Windows.Input.Key.Enter) CheckWords();
        }

        private void BRW_Click(object sender, RoutedEventArgs e)
        {
            reader.SelectVoice(Properties.Settings.Default.Voice); //Голос по умолчанию
            reader.SpeakAsync(DisplayedWord.English); // Чтение английских слов
        }

        private void BYes_Click(object sender, RoutedEventArgs e) => Answer(true);
        private void BNo_Click(object sender, RoutedEventArgs e) => Answer(false);
        #endregion

        private void CheckWords()
        {
            #region Check
            if (DisplayedWord.Progress == 0)
            {
                //Правильный ответ
                if (DisplayedWord.Russian.ToLower().IndexOf(TBoxCW.Text.ToLower()) != -1 && TBoxCW.Text != "")
                {
                    TBlAnswer.Foreground = Brushes.Green;
                    TBlAnswer.Text = DisplayedWord.Russian;
                }
                //Неправильный ответ
                else
                {
                    TBlAnswer.Foreground = Brushes.Red;
                    TBlAnswer.Text = DisplayedWord.Russian;
                }
                //
                BYes.Content = "Пропустить";
                BNo.Content = "Изучать";
            }
            else
            {
                //Правильный ответ
                if (DisplayedWord.English.ToLower().IndexOf(TBoxCW.Text.ToLower()) != -1 && TBoxCW.Text != "")
                {
                    TBlAnswer.Foreground = Brushes.Green;
                    TBlAnswer.Text = DisplayedWord.English + DisplayedWord.Transcription;
                }
                //Неправильный ответ
                else
                {
                    TBlAnswer.Foreground = Brushes.Red;
                    TBlAnswer.Text = DisplayedWord.English + DisplayedWord.Transcription;
                }

                BYes.Content = "Запомнил(а)";
                BNo.Content = "Повторить";
            }
            TBoxCW.Text = "";
            #endregion
            #region Change visibility
            TBlAnswer.Visibility = Visibility.Visible;
            TBoxCW.Visibility = Visibility.Hidden;
            BCW.Visibility = Visibility.Hidden;
            BYes.Visibility = Visibility.Visible;
            BNo.Visibility = Visibility.Visible;
            BRW.Visibility = Visibility.Visible;
            if (Examples.Count != 0) DGExamples.Visibility = Visibility.Visible;

            DGExamples.IsReadOnly = true;
            #endregion
        }

        #region Methods
        private void Answer(bool Reply)
        {
            if (Reply) 
            {
                switch (DisplayedWord.Progress)
                {
                    case 0:
                        DisplayedWord.Progress = 7;
                        DisplayedWord.CanBeDisplayedAt = DateTime.MaxValue;
                        DisplayedWord.Status = "already known";
                        break;
                    case 1:
                        DisplayedWord.Progress = 2;
                        DisplayedWord.CanBeDisplayedAt = DateTime.Now.AddMinutes(20);
                        if(DisplayedWord.Status != "learning") DisplayedWord.Status = "start";
                        break;
                    case 2:
                        DisplayedWord.Progress = 3;
                        DisplayedWord.CanBeDisplayedAt = DateTime.Now.AddDays(1);
                        DisplayedWord.Status = "learning";
                        break;
                    case 3:
                        DisplayedWord.Progress = 4;
                        DisplayedWord.CanBeDisplayedAt = DateTime.Now.AddDays(2);
                        break;
                    case 4:
                        DisplayedWord.Progress = 5;
                        DisplayedWord.CanBeDisplayedAt = DateTime.Now.AddDays(14);
                        break;
                    case 5:
                        DisplayedWord.Progress = 6;
                        DisplayedWord.CanBeDisplayedAt = DateTime.Now.AddDays(60);
                        DisplayedWord.Status = "almost";
                        break;
                    case 6:
                        DisplayedWord.Progress = 7;
                        DisplayedWord.CanBeDisplayedAt = DateTime.MaxValue;
                        DisplayedWord.Status = "learned";
                        break;
                }
            }
            else
            {
                if(DisplayedWord.Progress == 0)
                {
                    DisplayedWord.Progress = 1;
                    DisplayedWord.CanBeDisplayedAt = DateTime.Now.AddMinutes(2);
                    DisplayedWord.Status = "new";
                }
                else
                {
                    DisplayedWord.Progress = 1;
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
        private async void ShowNewWord()
        {
            #region Change visibility
            TBlAnswer.Visibility = Visibility.Hidden;
            TBoxCW.Visibility = Visibility.Visible;
            BCW.Visibility = Visibility.Visible;
            BYes.Visibility = Visibility.Hidden;
            BNo.Visibility = Visibility.Hidden;
            DGExamples.Visibility = Visibility.Hidden;
            BRW.Visibility = Visibility.Hidden;
            #endregion

            if (Words.Count == 0)
            {
                using (SEWContext db = new SEWContext())
                {
                    AddWords();
                }

                if (Words.Count == 0) // Если ничего нового не нашло
                {
                    TBoxCW.Visibility = Visibility.Hidden;
                    BCW.Visibility = Visibility.Hidden;
                    BRW.Visibility = Visibility.Hidden;
                    TBoxCW.IsEnabled = false;
                    BCW.IsEnabled = false;
                    BRW.IsEnabled = false;
                    TBlWord.Visibility = Visibility.Visible;

                    TBlWord.Text = "Слова для повторения закончились.\nДобавьте новые или отдохните";
                    await Task.Run(() => WaitingForNewWords());
                    ShowNewWord();
                    return;
                }
            }
            DisplayedWord = Words.Dequeue();
            Examples = new ObservableCollection<Example>();
            DGExamples.IsReadOnly = false;
            using (SEWContext db = new SEWContext())
            {
                List<Example> temp = db.Examples.Where(c => c.WordID == DisplayedWord.ID).ToList();
                foreach (var item in temp)
                {
                    Examples.Add(item);
                }
            }

            if (DisplayedWord.Progress == 0) TBlWord.Text = DisplayedWord.English + DisplayedWord.Transcription;
            else TBlWord.Text = DisplayedWord.Russian;
        }
        
        void WaitingForNewWords()
        {
            while (true)
            {
                Thread.Sleep(1000);
                AddWords();
                if (Words.Count != 0) // Если наконец нашло
                {
                    break;
                }
            }
        }

        void AddWords()
        {
            using (SEWContext db = new SEWContext())
            {
                List<Word> temp = db.Words.Where(c => c.CanBeDisplayedAt < DateTime.Now).Where(c => c.Category.Included == true).OrderByDescending(c => c.Progress).ToList();
                foreach (var item in temp)
                {
                    Words.Enqueue(item);
                }
            }
        }

        void UpdateWordsList() // Пересобираем список каждые ~2min
        {
            Thread.Sleep(111111);

            Words.Clear();
            using (SEWContext db = new SEWContext())
            {
                List<Word> temp = db.Words.Where(c => c.CanBeDisplayedAt < DateTime.Now).Where(c => c.Category.Included == true).OrderByDescending(c => c.Progress).ToList();
                foreach (var item in temp)
                {
                    Words.Enqueue(item);
                }
            }
        }

        #endregion

        
    }
}
