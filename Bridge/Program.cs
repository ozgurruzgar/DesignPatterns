using System;

namespace Bridge
{
    //Bridge patterni, Soyut sınıfımızdaki imzaların soyutlanıp alt sınıflarda implemente edildikten sonra soyut sınıfımızdaki imzayı
    //adeta bir köprü gibi kullanıp hangi alt sınıfı kullanabileceğimize karara verme imkanı sağlayan tasarım desenidir.
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.MessageSenderBase = new EMailSender();
            customerManager.UpdateCustomer();

            Console.ReadLine();
        }
    }
    abstract class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Message Saved");
        }

        public abstract void Send(Body body);
    }

    public class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }

    class SmsSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via SmsSender",body.Title);
        }
    }
    class EMailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via EMailSender", body.Title);
        }
    }

    class CustomerManager
    {
        public MessageSenderBase  MessageSenderBase{ get; set; }
        public void UpdateCustomer()
        {
            MessageSenderBase.Send(new Body {Title="About the Course" });
            Console.WriteLine("Customer Updated");
        }
    }
}
