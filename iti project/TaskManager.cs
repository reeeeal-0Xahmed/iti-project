using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    internal class TaskManager
    {
        private List<Task> tasks = new List<Task>();//list for tasks
        private const string FilePath = "tasks.txt";

        // Event for notifications
        public event Action<string> TaskUpdated;

        public TaskManager()
        {
            LoadTasks();
        }

        // Save tasks to file
        private void SaveTasks()
        {
            File.WriteAllLines(FilePath, tasks.Select(t => t.Name));
        }

        // Load tasks from file
        private void LoadTasks()
        {
            if (File.Exists(FilePath))
            {
                tasks = File.ReadAllLines(FilePath).Select(name => new Task(name)).ToList();
            }
        }

        // Add task
        public void AddTask(string taskName)
        {

            if (tasks.Exists(t => t.Name == taskName))
                throw new Exception("Task already exists!");

            Task newTask = new Task(taskName);
            tasks.Add(newTask);
            SaveTasks();
            TaskUpdated?.Invoke($"Task added: {taskName}");
        }

        // Edit task
        public void EditTask(string oldName, string newName)
        {
            var task = tasks.Find(t => t.Name == oldName);
            if (task == null)
                throw new Exception("Task not found!");

            task.Name = newName;
            SaveTasks();
            TaskUpdated?.Invoke($"Task updated: {oldName} to {newName}");
        }

        // Remove task
        public void RemoveTask(string taskName)
        {
            var task = tasks.Find(t => t.Name == taskName);
            if (task == null)
                throw new Exception("Task not found!");

            tasks.Remove(task);
            SaveTasks();
            TaskUpdated?.Invoke($"Task removed: {taskName}");
        }

        // Display tasks
        public void DisplayTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
            }
            else
            {
                Console.WriteLine("Current tasks:");
                foreach (var task in tasks)
                {
                    Console.WriteLine("- " + task.Name);
                }
            }
        }
    }


