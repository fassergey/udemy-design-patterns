namespace Memento
{
    public class Memento
    {
        public int Balance { get; set; }

        public Memento(int balance)
        {
            Balance = balance;
        }
    }

    public class BankAccount
    {
        protected int balance;

        public BankAccount(int balance)
        {
            this.balance = balance;
        }

        public virtual Memento Deposit(int amount)
        {
            balance += amount;
            return new Memento(balance);
        }

        public void Restore(Memento m)
        {
            balance = m.Balance;
        }

        public override string ToString()
        {
            return $"{nameof(balance)}: {balance}";
        }
    }
}
