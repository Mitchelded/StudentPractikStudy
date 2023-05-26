using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    internal class StudentContext : DbContext
    {
        public StudentContext() : base("userconnect")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Student> Students { get; set; }

    }
}
