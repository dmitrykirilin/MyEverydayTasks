using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.Model
{
    public class Diary
    {
        public DateTime Creation { get; set; } = DateTime.Now;

        private string task;

        public string Task
        {
            get { return task; }
            set { task = value; }
        }

        private bool isDone;

        public bool IsDone
        {
            get { return isDone; }
            set { isDone = value; }
        }

    }
}
