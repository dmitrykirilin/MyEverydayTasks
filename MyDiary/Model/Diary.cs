using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.Model
{
    public class Diary : INotifyPropertyChanged
    {
        public DateTime Creation { get; set; } = DateTime.Now;

        private string task;

        private bool isDone;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Task
        {
            get { return task; }
            set
            {
                if (value == task)
                    return;
                task = value;
                OnPropertyChanged("Task");
            }
        }
        
        public bool IsDone
        {
            get { return isDone; }
            set
            {
                if (value == isDone)
                    return;
                isDone = value;
                OnPropertyChanged("IsDone");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
