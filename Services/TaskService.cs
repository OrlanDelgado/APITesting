using System;
using System.Collections.Generic;
using System.Linq;
using TareasApi.Models;

namespace TareasApi.Services
{
    public class TaskService
    {
        private readonly List<TareasApi.Models.Task> _tasks = new List<TareasApi.Models.Task>();
        private int _nextId = 1;

        public IEnumerable<TareasApi.Models.Task> GetAll() => _tasks;

        public TareasApi.Models.Task GetById(int id) => _tasks.FirstOrDefault(t => t.Id == id);

        public TareasApi.Models.Task Create(TareasApi.Models.Task task)
        {
            task.Id = _nextId++;
            task.CreatedAt = DateTime.UtcNow;
            _tasks.Add(task);
            return task;
        }

        public void Update(int id, TareasApi.Models.Task updatedTask)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return;

            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.IsCompleted = updatedTask.IsCompleted;
        }

        public void Delete(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                _tasks.Remove(task);
            }
        }
    }
}
