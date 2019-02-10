using System;
using System.Dynamic;
using ImpromptuInterface;
using static System.Console;

namespace NullObject
{
    /* A behavioral design pattern with no behaviors */

    /*
     * A mo-op object that conforms to the required interface,
     * satisfying a dependency requirement of some other object
     */

    public interface ILog
    {
        void Info(string msg);
        void Warn(string msg);
    }

    class ConsoleLog : ILog
    {
        public void Info(string msg)
        {
            WriteLine(msg);
        }

        public void Warn(string msg)
        {
            WriteLine(@"WARNING!!! " + msg);
        }
    }

    class BankAccount
    {
        private ILog log;

        private int balance;

        public BankAccount(ILog log)
        {
            this.log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public void Deposit(int amount)
        {
            balance += amount;
            log.Info($"Deposited {amount}, balance is now {balance}");
        }
    }

    public class NullLog : ILog
    {
        public void Info(string msg)
        {
        }

        public void Warn(string msg)
        {
        }
    }

    public class Null<TInterface> : DynamicObject where TInterface : class
    {
        public static TInterface Instance => new Null<TInterface>().ActLike<TInterface>();

        public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
        {
            result = Activator.CreateInstance(binder.ReturnType);
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var log = new ConsoleLog();
            var ba = new BankAccount(log);
            ba.Deposit(100);

            // throws exception
            var ba1 = new BankAccount(null);
            ba1.Deposit(100);

            var nullLog = new NullLog();
            var ba2 = new BankAccount(nullLog);
            ba2.Deposit(100);

            // using ImpromptuInterface
            var log1 = Null<ILog>.Instance;
            log1.Info("asdfasdf");
            var ba3 = new BankAccount(log1);
            ba3.Deposit(100);
        }
    }
}
