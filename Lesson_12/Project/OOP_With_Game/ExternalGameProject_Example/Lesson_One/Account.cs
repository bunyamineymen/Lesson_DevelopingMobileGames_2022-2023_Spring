//Suppose you are designing a banking application that has different types of accounts, such as savings, checking, credit, etc. 
//You can use an interface to define the common operations that all accounts should support, such as deposit, withdraw, transfer, etc. 
//You can then use an abstract class to provide some common logic or state that all accounts share, such as balance, interest rate, transaction history, etc. 
//You can then have concrete classes that inherit from the abstract class and implement the interface to provide specific behavior or rules for each account type. 


// An interface that defines the common operations for all accounts
public interface IAccount
{
    void Deposit(double amount); // deposit money into the account
    void Withdraw(double amount); // withdraw money from the account
    void Transfer(double amount, IAccount other); // transfer money to another account
    double GetBalance(); // get the current balance of the account
}

// An abstract class that provides some common logic or state for all accounts
public abstract class Account : IAccount
{
    protected double _balance; // the current balance of the account
    protected double _interestRate; // the annual interest rate of the account
    protected List<string> _transactionHistory; // the history of transactions of the account

    public Account(double balance, double interestRate)
    {
        _balance = balance;
        _interestRate = interestRate;
        _transactionHistory = new List<string>();
    }

    public virtual void Deposit(double amount) // a virtual method that can be overridden by derived classes
    {
        if (amount > 0)
        {
            _balance += amount;
            _transactionHistory.Add("Deposited " + amount);
        }
    }

    public virtual void Withdraw(double amount) // a virtual method that can be overridden by derived classes
    {
        if (amount > 0 && amount <= _balance)
        {
            _balance -= amount;
            _transactionHistory.Add("Withdrew " + amount);
        }
    }

    public virtual void Transfer(double amount, IAccount other) // a virtual method that can be overridden by derived classes
    {
        if (other != null)
        {
            this.Withdraw(amount);
            other.Deposit(amount);
            _transactionHistory.Add("Transferred " + amount + " to " + other);
        }
    }

    public double GetBalance() // a non-virtual method that cannot be overridden by derived classes
    {
        return _balance;
    }

    public void ApplyInterest() // a non-virtual method that cannot be overridden by derived classes
    {
        double interest = _balance * _interestRate / 100;
        _balance += interest;
        _transactionHistory.Add("Applied interest " + interest);
    }

    public void PrintTransactionHistory() // a non-virtual method that cannot be overridden by derived classes
    {
        foreach (string transaction in _transactionHistory)
        {
            Console.WriteLine(transaction);
        }
    }
}

// A concrete class that inherits from the abstract class and implements the interface
public class SavingsAccount : Account
{
    public SavingsAccount(double balance, double interestRate) : base(balance, interestRate)
    {

    }

    public override void Withdraw(double amount) // an override method that provides a specific behavior for savings accounts
    {
        if (amount > 0 && amount <= _balance - 100) // savings accounts must have a minimum balance of 100
        {
            base.Withdraw(amount);
        }
    }
}

// Another concrete class that inherits from the abstract class and implements the interface
public class CreditAccount : Account
{
    private double _creditLimit; // the maximum amount of money that can be borrowed

    public CreditAccount(double balance, double interestRate, double creditLimit) : base(balance, interestRate)
    {
        _creditLimit = creditLimit;
    }

    public override void Withdraw(double amount) // an override method that provides a specific behavior for credit accounts
    {
        if (amount > 0 && amount <= _balance + _creditLimit) // credit accounts can have a negative balance up to the credit limit
        {
            base.Withdraw(amount);
        }
    }
}

//In this example, the IAccount interface defines the common operations for all accounts. 
//The Account abstract class implements that interface and provides some common logic or state for all accounts. 
//The SavingsAccount and CreditAccount classes inherit from the Account abstract class and implement the interface to provide specific behavior or rules for each account type.

//This way, you can use both interface and abstract class to achieve polymorphism and code reuse. 
//For example, you can have a method that takes an IAccount parameter and performs some operation on any account object, regardless of its concrete type. 
//You can also use the abstract class methods to access or modify the common state or logic of any account object, without having to duplicate the code in each derived class. 
//Here is an example of using polymorphism and code reuse with these classes:

class Program5
{
    static void Main(string[] args)
    {
        // A method that takes an Account parameter and prints its balance
        static void PrintBalance(Account account)
        {
            Console.WriteLine("The balance of the account is " + account.GetBalance());
        }

        // A method that takes an Account parameter and applies interest to it
        static void ApplyInterest(Account account)
        {
            account.ApplyInterest();
            Console.WriteLine("The interest has been applied to the account.");
        }

        // Creating different types of accounts
        Account savings = new SavingsAccount(1000, 5);
        Account credit = new CreditAccount(500, 10, 1000);

        // Using polymorphism to perform the same operation on different types of accounts
        PrintBalance(savings); // prints 1000
        PrintBalance(credit); // prints 500

        // Using code reuse to access the common logic of the abstract class
        ApplyInterest(savings); // prints "The interest has been applied to the account."
        ApplyInterest(credit); // prints "The interest has been applied to the account."

        // Checking the updated balances
        PrintBalance(savings); // prints 1050
        PrintBalance(credit); // prints 550
    }
}
