using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebScheduler
{
    public class Task
    {
        public bool IsDone { get; set; }
        public DateTime On { get; set; }
        public string Content { get; set; }
        public int Id { get; set; }
        public virtual System.Threading.Tasks.Task Execute()
        {
            throw new NotImplementedException();
        }
    }
}
