using System;
using System.IO;

namespace Napilnik
{
    class Program
    {
        static void Main(string[] args)
        {
            LogWritter fileLogger = new FileLogWritter();
            LogWritter consoleLogger = new ConsoleLogWritter();
            SecureLogWritter fridayFileLogger = new SecureLogWritter(fileLogger);
            SecureLogWritter fridayConsoleLogger = new SecureLogWritter(consoleLogger);
            LogWritter consoleAndFridayFileLogger = new ConsoleLogWritter(fridayFileLogger);


            Pathfinder filePathfinder = new Pathfinder(fileLogger);
            Pathfinder consolePathfinder = new Pathfinder(consoleLogger);
            Pathfinder fridayFilePathfinder = new Pathfinder(fridayFileLogger);
            Pathfinder fridayConsolePathfinder = new Pathfinder(fridayConsoleLogger);
            Pathfinder consoleAndFridayFilePathfinder = new Pathfinder(consoleAndFridayFileLogger);

            string message = "napilnik";

            filePathfinder.Find(message);
            consolePathfinder.Find(message);
            fridayFilePathfinder.Find(message);
            fridayConsolePathfinder.Find(message);
            consoleAndFridayFilePathfinder.Find(message);
            Console.ReadLine();
        }
    }

    class Pathfinder
    {
        readonly ILogger _logger;
        public Pathfinder(ILogger logger)
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            _logger = logger;
        }

        public void Find(string message)
        {
            _logger.WriteError(message);
        }
    }

    interface ILogger
    {
        void WriteError(string message);
    }

    abstract class LogWritter : ILogger
    {
        private readonly ILogger _next;

        public LogWritter(ILogger next = null)
        {
            _next = next;
        }

        public void WriteError(string message)
        {
            Log(message);
            if (_next != null)
                _next.WriteError(message);
        }

        protected abstract void Log(string message);
    }

    class SecureLogWritter : LogWritter
    {
        private readonly LogWritter _writter;

        public SecureLogWritter(LogWritter writter, ILogger next = null) : base(next)
        {
            if (writter == null)
                throw new ArgumentNullException(nameof(writter));

            _writter = writter;
        }

        protected override void Log(string message)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
                _writter.WriteError(message);
            }
        }
    }

    class ConsoleLogWritter: LogWritter
    {
        public ConsoleLogWritter(ILogger next = null) : base(next) { }

        protected override void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    class FileLogWritter : LogWritter
    {
        public FileLogWritter(ILogger next = null) : base(next) { }

        protected override void Log(string message)
        {
            File.WriteAllText("log.txt", message);
        }
    }
}
