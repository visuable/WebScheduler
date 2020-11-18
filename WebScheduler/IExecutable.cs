using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScheduler
{
    interface IExecutable
    {
        System.Threading.Tasks.Task Execute();
    }
}
