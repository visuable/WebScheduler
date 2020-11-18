using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebScheduler.Tasks
{
    public class ConcreteTask : Task
    {
        public ConcreteTask()
        {
            On = DateTime.Now.AddMinutes(1);
        }
        public override async System.Threading.Tasks.Task Execute()
        {
            await File.WriteAllTextAsync("txt.txt", DateTime.Now.ToLongDateString());
        }
    }
}
