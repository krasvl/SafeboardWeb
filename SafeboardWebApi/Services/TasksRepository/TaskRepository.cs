using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeboardWebApi.Services.TasksRepository
{
    public class TaskRepository : ITaskRepository
    {
        private List<Task<string[]>> tasks = new List<Task<string[]>>();

        public void Add(Task<string[]> task) =>
            tasks.Add(task);

        public bool IsCompleted(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
                throw new KeyNotFoundException();
            else
                return task.Status == TaskStatus.RanToCompletion;
        }

        public string[] GetResult(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
                throw new KeyNotFoundException();
            else
                return task.Result;
        }
    }
}
