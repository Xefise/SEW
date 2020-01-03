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
                List<Word> temp = db.Words.Where(c => c.CanBeDisplayedAt < DateTime.Now).ToList();
                foreach (var item in temp)
                {
                    Words.Enqueue(item);
                }
            }

            DisplayedWord = Words.Dequeue();
        }


    }
}
