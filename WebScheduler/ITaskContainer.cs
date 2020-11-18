using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScheduler
{
    public interface ITaskContainer
    {
        void AddTask(Task task);
        void UpdateTask(Task task);
        Task FindTask(TaskOptions options);
    }
}
