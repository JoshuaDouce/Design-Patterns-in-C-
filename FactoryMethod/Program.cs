using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            //In a larger program this would be done using dependency injection
            var factory = new SavingsAccountFactory() as ICreditUnionFactory;
            var citiAcct = factory.GetSavingsAccount("CITI-123");
            var nationalAcct = factory.GetSavingsAccount("NATIONAL-345");

            Console.WriteLine($"CitiAccount Balance: {citiAcct.Balance}");
            Console.WriteLine($"NationalAccount Balance: {nationalAcct.Balance}");
        }
    }

    //Product
    public abstract class ISavingsAccount {
        public decimal Balance { get; set; }
    }

    //Concrete Product
    public class CitiSavingsAccount : ISavingsAccount {
        public CitiSavingsAccount()
        {
            Balance = 5000;
        }
    }

    //Concrete Product
    public class NationalSavingsAccount : ISavingsAccount {
        public NationalSavingsAccount()
        {
            Balance = 2000;
        }
    }

    //Creator
    interface ICreditUnionFactory {
        ISavingsAccount GetSavingsAccount(string accountNumber);
    }

    //Concrete Creator - The essence of the factory method. Contains the logic of which type should be returned.
    //Create the correct tye behind the scenes
    public class SavingsAccountFactory : ICreditUnionFactory
    {
        public ISavingsAccount GetSavingsAccount(string accountNumber)
        {
            if (accountNumber.Contains("CITI"))
            {
                Console.WriteLine("Saving Account factory created new CitiSavingsAccount");
                return new CitiSavingsAccount();
            }
            else if (accountNumber.Contains("NATIONAL"))
            {
                Console.WriteLine("Saving Account factory created new NationalSavingsAccount");
                return new NationalSavingsAccount();
            }
            else {
                throw new ArgumentException("Invalid account number");
            }
        }
    }

}
