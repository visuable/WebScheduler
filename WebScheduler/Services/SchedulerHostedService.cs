using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace WebScheduler.Services
{
    public class SchedulerHostedService : IHostedService
    {
        private ITaskContainer _container;
        private System.Threading.Tasks.Task executing;
        private CancellationTokenSource source;

        public SchedulerHostedService(ITaskContainer container)
        {
            _container = container;
            source = new CancellationTokenSource();
        }

        public System.Threading.Tasks.Task StartAsync(CancellationToken cancellationToken)
        {
            executing = ExecuteTask(cancellationToken);
            if (executing.IsCompleted)
            {
                return executing;
            }

            return System.Threading.Tasks.Task.CompletedTask;
        }

        public async System.Threading.Tasks.Task StopAsync(CancellationToken cancellationToken)
        {
            if (executing == null)
            {
                return;
            }
            try
            {
                source.Cancel();
            }
            finally
            {
                await System.Threading.Tasks.Task.WhenAny(executing, System.Threading.Tasks.Task.Delay(Timeout.Infinite,
                    cancellationToken));
            }
        }

        private async System.Threading.Tasks.Task ExecuteTask(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var task = _container.FindTask(new TaskOptions()
                {
                    IsDone = false,
                    On = DateTime.Now
                });
                if (task != null)
                {
                    await (task as IExecutable)?.Execute();
                }
                Thread.Sleep(500);
            }
        }
    }
}
