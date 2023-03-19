using System;

namespace NullObject
{
    //Null Object patterni, uygulamamızı test etmek istediğimiz zaman interface'i implemente eden fake bir somut sınıf oluşturup
    //onun üzerinden testimizi yapmamıza olanak sağlayan tasarım desenidir.
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());
            customerManager.Save();
            Console.ReadLine();

        }
    }
    class CustomerManager
    {
        private ILogger _logger;

        public CustomerManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            Console.WriteLine("Saved!");
            _logger.Log();
        }
    }
    interface ILogger
    {
        void Log();
    }
    class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Log4Net");
        }
    }    
    class NLogLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with NLog");
        }
    }
    class StubLogger : ILogger
    {
        //Singleton pattern
        private static StubLogger _stubLogger;
        private static object _lockObject = new object();
        private StubLogger() { }

        public static StubLogger GetLogger()
        {
            lock(_lockObject)
            {
                if(_stubLogger==null)
                {
                    return new StubLogger(); 
                }               
            }
            return _stubLogger;
        }
        public void Log()
        {
          
        }
    }
    class CustomerManagerTests
    {
        public void SaveTest()
        {
            CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());
            customerManager.Save();
        }
    }
}
