using System;


namespace OOPS_Questions_Practice_in_CSharp
{
    class BankAccount
    {
        private decimal balance;//encapsulated the data means hide its not visble or accessbible
        public BankAccount(decimal initialBalance)
        {
            balance = initialBalance;
        }


        public void Deposit(decimal amount)
        {
            if(amount>0)
            {
                balance += amount;

            }
            else
            {
                Console.WriteLine("the amount value must be positive");
            }

        }
        public virtual void WithDraw(decimal amount)
        {
            if(amount>0 && balance>=amount)
            {
                balance -= amount;
            }
            else
            {
                Console.WriteLine("Insuffiecint balance");
            }

        }
        public decimal GetBalance()
        {
            return balance;
        }


    }
    class SavingsAccount:BankAccount//inheritance concept here
    {
        private decimal InterestRate;
        
        public SavingsAccount(decimal initialBalance, decimal rate): base(initialBalance)   // call base constructor to initialize 
        {
            InterestRate = rate;     // initialize interest rate
        }
        public void AddInterest()
        {
            decimal interest = GetBalance() * InterestRate / 100;
            Deposit(interest);//here because of inheritance it can access the parent method
        }

        public override void WithDraw(decimal amount)//polymorphism concept here
        {
            if(amount<=GetBalance()-100)
            {
                base.WithDraw(amount);
            }
            else
            {
                Console.WriteLine("u cannot draw!balance must keep minimum 100");
            }
            
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount a = new BankAccount(500);
            a.GetBalance();
            a.Deposit(200);
            a.WithDraw(100);
            a.GetBalance();

            SavingsAccount s = new SavingsAccount(1000,5);
            s.AddInterest();
            s.GetBalance();
            s.WithDraw(500);
            s.WithDraw(1000);
            s.GetBalance();


        }
    }
}
