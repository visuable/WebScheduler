using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebScheduler.Services;
using WebScheduler.Tasks;

namespace WebScheduler.Controllers
{
    public class TaskController : Controller
    {
        private ITaskContainer _container;
        public TaskController(ITaskContainer container)
        {
            _container = container;
        }

        [HttpGet]
        public IActionResult StartTasks()
        {
            _container.AddTask(new ConcreteTask());
            return Content("Scheduler started");
        }
    }
}
