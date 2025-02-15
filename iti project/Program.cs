using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


// Task model

// Task manager

class Program
{
    static void Main()
    {
        TaskManager manager = new TaskManager();

        // Add multiple handlers (Delegate Chains)
        manager.TaskUpdated += message => Console.WriteLine("Notification: " + message);
        manager.TaskUpdated += message => Console.WriteLine("Sending email: " + message);

        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Edit Task");
            Console.WriteLine("3. Remove Task");
            Console.WriteLine("4. View Tasks");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();
            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter task name: ");
                        string addTask = Console.ReadLine();
                        manager.AddTask(addTask);
                        break;
                    case "2":
                        Console.Write("Enter old task name: ");
                        string oldName = Console.ReadLine();
                        Console.Write("Enter new task name: ");
                        string newName = Console.ReadLine();
                        manager.EditTask(oldName, newName);
                        break;
                    case "3":
                        Console.Write("Enter task name to remove: ");
                        string removeTask = Console.ReadLine();
                        manager.RemoveTask(removeTask);
                        break;
                    case "4":
                        manager.DisplayTasks();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            //end of main function
        }
    }
}
