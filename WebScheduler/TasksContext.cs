using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebScheduler
{
    public class TasksContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public TasksContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
