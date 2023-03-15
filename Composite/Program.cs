using System;
using System.Collections;
using System.Collections.Generic;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee{ Name = "Sedat Rüzgar"};
            Employee employee2= new Employee{ Name = "Özgür Rüzgar"};
            employee.AddSubordinate(employee2);

           Employee employee3 = new Employee { Name = "Engin Demiroğ" };
            employee.AddSubordinate(employee3);

            Contractor contractor = new Contractor { Name="Ali"};
            employee3.AddSubordinate(contractor);

            Employee employee4 = new Employee { Name = "Ahmet" };
            employee2.AddSubordinate(employee4);

            Console.WriteLine(employee.Name);
            foreach (Employee manager in employee)
            {
                Console.WriteLine("  {0}",manager.Name);
                foreach (IPerson employe in manager)
                {
                    Console.WriteLine("    {0}",employe.Name);
                }
            }
            Console.ReadLine();
        }
    }
    interface IPerson
    {
        string Name { get; set; }
    }
    class Contractor : IPerson
    {
        public string Name { get ; set ; }
    }
    class Employee : IPerson, IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();
        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }
        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }
        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }
        public string Name { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinates in _subordinates)
            {
                yield return subordinates;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
