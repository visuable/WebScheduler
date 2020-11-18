using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebScheduler;

namespace WebScheduler
{
    class DatabaseTaskContainer : ITaskContainer
    {
        private TasksContext context;
        public DatabaseTaskContainer(TasksContext context)
        {
            this.context = context;
        }
        public void AddTask(Task task)
        {
            context.Tasks.Add(task);
            context.SaveChanges();
        }

        public void UpdateTask(Task task)
        {
            context.Tasks.Update(task);
            context.SaveChanges();
        }
        public Task FindTask(TaskOptions options)
        {
            var t = context.Tasks.FirstOrDefault(x => x.On.Date == options.On.Date &&
                                              x.On.Hour == options.On.Hour &&
                                              x.On.Minute == options.On.Minute && x.IsDone == options.IsDone);
            return t;
        }
    }
}
