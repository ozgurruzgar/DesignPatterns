using System;

namespace ChainOfResponsibility
{
    //Chain of Responsibility patterni, uygulamamızı şirketimizdeki hiyerarşiye tasarlayıp o hiyerarşiye göre kullanmamıza olanak sağlayan 
    //tasarım desenidir.
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            VicePresident vicePresident = new VicePresident();
            President president = new President();

            manager.SetSuccessor(vicePresident);
            vicePresident.SetSuccessor(president);

            Expense expense = new Expense {Detail="Training",Amount=1100 };
            manager.HandleExpense(expense);

            Console.ReadLine();
        }
    }
    class Expense
    {
        public string Detail { get; set; }
        public decimal Amount { get; set; }
    }

    abstract class ExpenseHandlerBase
    {
        protected ExpenseHandlerBase Successor;
        public abstract void HandleExpense(Expense expense);
        public void SetSuccessor(ExpenseHandlerBase successor)
        {
            Successor = successor;
        }
    }
    class Manager : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if(expense.Amount<=100)
            {
                Console.WriteLine("Manager handled the expense!");
            }
            else if(Successor!=null)
            {
                Successor.HandleExpense(expense);
            }
        }
    }    
    class VicePresident : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount >= 100 && expense.Amount <=1000)
            {
                Console.WriteLine("Vice President handled the expense!");
            }
            else if (Successor != null)
            {
                Successor.HandleExpense(expense);
            }
        }
    }

    class President : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 1000)
            {
                Console.WriteLine("President handled the expense!");
            }
            else if (Successor != null)
            {
                Successor.HandleExpense(expense);
            }
        }
    }
}
