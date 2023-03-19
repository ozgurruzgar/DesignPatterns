using Ninject;
using System;

namespace DependencyInjection
{
    class Program
    {
        //Dependency Injection patterni, uygulamamızdaki bağımlılıkları gevşek hale getirerek uygulamamızı gelecek teknolojilere
        //kolayca adapte edebilmemize olanak sağlar. Günümüzde IoC Container denilen kutular vasıtasıyla kullanılırlar.
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IProductDal>().To<EfProductDal>();

            ProductManager productManager = new ProductManager(kernel.Get<IProductDal>());
            productManager.Save();
            Console.ReadLine();
        }
    }
    interface IProductDal
    {
        void Save();
    }
    class EfProductDal:IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with EF");
        }
    }   
    class NhProductDal:IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with NH");
        }
    }
    class ProductManager
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Save()
        {
            _productDal.Save();
        }
    }
}
