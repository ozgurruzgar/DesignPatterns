using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
            Console.ReadLine();
        }
    }
    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    internal interface ILogging
    {
        void Log();
    }

    class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    internal interface ICaching
    {
        void Cache();
    }

    class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User Checked");
        }
    }

    internal interface IAuthorize
    {
        void CheckUser();
    }

    class CustomerManager
    {
        CrossCuttingConcernsFacade _crossCuttingConcernsFacade;

        public CustomerManager()
        {
            _crossCuttingConcernsFacade = new CrossCuttingConcernsFacade();
        }


        public void Save()
        {
            _crossCuttingConcernsFacade.Logging.Log();
            _crossCuttingConcernsFacade.Caching.Cache();
            _crossCuttingConcernsFacade.Authorize.CheckUser();
            Console.WriteLine("Saved");
        }
    }
    class CrossCuttingConcernsFacade
    {
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;
        public CrossCuttingConcernsFacade()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorize = new Authorize();
        }
    }

}
