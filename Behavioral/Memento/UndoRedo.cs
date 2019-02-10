using System.Collections.Generic;

namespace Memento
{
    public class BankAccountExtended : BankAccount
    {
        private List<Memento> changes = new List<Memento>();
        private int current;

        public BankAccountExtended(int balance) : base(balance)
        {
            changes.Add(new Memento(balance));
        }

        public override Memento Deposit(int amount)
        {
            var m = base.Deposit(amount);
            changes.Add(m);
            ++current;
            return m;
        }

        public Memento Restore(Memento m)
        {
            if (m != null)
            {
                balance = m.Balance;
                changes.Add(m);
                return m;
            }

            return null;
        }

        public Memento Undo()
        {
            if (current > 0)
            {
                var m = changes[--current];
                balance = m.Balance;
                return m;
            }

            return null;
        }

        public Memento Redo()
        {
            if (current + 1 < changes.Count)
            {
                var m = changes[++current];
                balance = m.Balance;
                return m;
            }

            return null;
        }
    }
}
