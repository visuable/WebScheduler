using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScheduler
{
    public class Task : IExecutable
    {
        public bool IsDone { get; set; }
        public DateTime On { get; set; }
        public string Content { get; set; }
        public int Id { get; set; }
        public System.Threading.Tasks.Task Execute()
        {
            return System.Threading.Tasks.Task.CompletedTask;
        }
    }
}
