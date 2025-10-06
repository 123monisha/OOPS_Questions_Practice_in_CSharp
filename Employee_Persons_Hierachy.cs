using System;
namespace OOPS_Questions_Practice_in_CSharp
{
    interface IPromotable
    {
        void Promote();  // contract method
    }

    // Step 2: Base class Employee (abstract if you want)
    abstract class Employee
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public decimal Salary { get; set; }

        // Constructor
        public Employee(string name, int id, decimal salary)
        {
            Name = name;
            Id = id;
            Salary = salary;
        }

        // Abstract method → must be overridden
        public abstract void Work();

        // Virtual method for bonus → can be overridden
        public virtual decimal GetBonus()
        {
            return Salary * 0.1m; // 10% bonus by default
        }

        // Display info
        public void ShowInfo()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Salary: {Salary}");
        }
    }

    // Step 3: Manager class
    class Manager : Employee, IPromotable
    {
        public string Department { get; set; }

        public Manager(string name, int id, decimal salary, string department)
            : base(name, id, salary)
        {
            Department = department;
        }

        public override void Work()
        {
            Console.WriteLine($"{Name} is managing the {Department} department.");
        }

        public override decimal GetBonus()
        {
            return Salary * 0.2m;
        }

        public void ConductMeeting()
        {
            Console.WriteLine($"{Name} is conducting a meeting.");
        }

        public void Promote()
        {
            Salary += 5000;
            Console.WriteLine($"{Name} has been promoted! New salary: {Salary}");
        }
    }

    // Step 4: Developer class
    class Developer : Employee, IPromotable
    {
        public string ProgrammingLanguage { get; set; }

        public Developer(string name, int id, decimal salary, string language)
            : base(name, id, salary)
        {
            ProgrammingLanguage = language;
        }

        public override void Work()
        {
            Console.WriteLine($"{Name} is writing code in {ProgrammingLanguage}.");
        }

        public override decimal GetBonus()
        {
            return Salary * 0.15m;
        }

        public void Promote()
        {
            Salary += 3000;
            Console.WriteLine($"{Name} has been promoted! New salary: {Salary}");
        }
    }

    // Step 5: Tester class
    class Tester : Employee
    {
        public string Language { get; set; }

        public Tester(string name, int id, decimal salary, string language)
            : base(name, id, salary)
        {
            Language = language;
        }

        public override void Work()
        {
            Console.WriteLine($"{Name} is testing software using {Language}.");
        }

        public override decimal GetBonus()
        {
            return Salary * 0.5m;
        }

        public void Skill()
        {
            Console.WriteLine($"{Name} is skilled in {Language}.");
        }
    }

    internal class Employee_Persons_Hierachy
    {
        public static void Main(string[] args)
        {
            Manager mgr = new Manager("Alice", 101, 50000, "HR");
            Developer dev = new Developer("Bob", 102, 40000, "C#");
            Tester tester = new Tester("Charlie", 103, 30000, "Selenium");

            // Call methods for Manager
            mgr.ShowInfo();
            mgr.Work();
            Console.WriteLine("Bonus: " + mgr.GetBonus());
            mgr.ConductMeeting();
            mgr.Promote();
            Console.WriteLine();

            // Call methods for Developer
            dev.ShowInfo();
            dev.Work();
            Console.WriteLine("Bonus: " + dev.GetBonus());
            dev.Promote();
            Console.WriteLine();

            // Call methods for Tester
            tester.ShowInfo();
            tester.Work();
            Console.WriteLine("Bonus: " + tester.GetBonus());
            tester.Skill();
        }
    }
}
