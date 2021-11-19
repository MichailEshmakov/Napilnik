using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger fileLogger = new FileLogger();
            ILogger consoleLogger = new ConsoleLogger();

            Pathfinder filePathfinder = new Pathfinder(fileLogger);
            Pathfinder consolePathfinder = new Pathfinder(consoleLogger);
            Pathfinder fridayFilePathfinder = new FridayPathfinder(filePathfinder);
            Pathfinder fridayConsolePathfinder = new FridayPathfinder(consoleLogger);
            Pathfinder consoleAndFridayFilePathfinder = new Pathfinder(consoleLogger, fridayFilePathfinder);

            string message = "napilnik";

            filePathfinder.Find(message);
            consolePathfinder.Find(message);
            fridayFilePathfinder.Find(message);
            fridayConsolePathfinder.Find(message);
            consoleAndFridayFilePathfinder.Find(message);
            Console.ReadLine();
        }
    }

    interface ILogger
    {
        void Find(string message);
    }

    class FileLogger : ILogger
    {
        public void Find(string message)
        {
            File.WriteAllText("log.txt", message);
        }
    }

    class ConsoleLogger : ILogger
    {
        public void Find(string message)
        {
            Console.WriteLine(message);
        }
    }

    class Pathfinder : ILogger
    {
        public Pathfinder(ILogger logger, Pathfinder successor = null)
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            Logger = logger;
            Successor = successor;
        }

        protected ILogger Logger { get; private set; }
        protected Pathfinder Successor { get; private set; }

        public virtual void Find(string message)
        {
            Logger.Find(message);
            if (Successor != null)
                Successor.Find(message);
        }
    }

    class FridayPathfinder : Pathfinder
    {
        public FridayPathfinder(ILogger logger, Pathfinder successor = null) : base(logger, successor) { }

        public override void Find(string message)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
                Logger.Find(message);

            if (Successor != null)
                Successor.Find(message);
        }
    }
}
