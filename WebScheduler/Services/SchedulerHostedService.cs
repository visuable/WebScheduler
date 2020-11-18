using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebScheduler.Services
{
    public class SchedulerHostedService : BackgroundService
    {
        private IServiceScopeFactory _factory;

        public SchedulerHostedService(IServiceScopeFactory factory)
        {
            _factory = factory;
        }

        protected override async System.Threading.Tasks.Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await DoWork(stoppingToken);
        }

        private async System.Threading.Tasks.Task DoWork(CancellationToken stoppingToken)
        {
            using var scope = _factory.CreateScope();
            _ = scope.ServiceProvider.GetRequiredService<TasksContext>();
            var container = scope.ServiceProvider.GetRequiredService<ITaskContainer>();
            while (!stoppingToken.IsCancellationRequested)
            {
                var task = container.FindTask(new TaskOptions()
                {
                    IsDone = false,
                    On = DateTime.Now
                });
                if (task != null)
                {
                    await task.Execute();
                    task.IsDone = true;
                    container.UpdateTask(task);
                }

                await System.Threading.Tasks.Task.Delay(500, stoppingToken);
            }
        }
    }
}
