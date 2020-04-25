using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.Model
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("DBConnection") { }
       
        public DbSet<Diary> Notes { get; set; }

    }
}
