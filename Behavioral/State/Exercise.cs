using System;
using System.Collections.Generic;

namespace State
{
    public class CombinationLock
    {
        private enum PossibleStatuses
        {
            Locked, Open, Error, Other
        }

        private readonly int[] _combination;
        private List<int> enteredDigits;

        public CombinationLock(int[] combination)
        {
            Status = PossibleStatuses.Locked.ToString().ToUpper();
            _combination = new int[combination.Length];
            Array.Copy(combination, _combination, combination.Length);
            enteredDigits = new List<int>();
        }

        // you need to be changing this on user input
        public string Status;

        public void EnterDigit(int digit)
        {
            if (digit == _combination[enteredDigits.Count])
            {
                enteredDigits.Add(digit);
                Status = _combination.Length == enteredDigits.Count ? PossibleStatuses.Open.ToString().ToUpper() 
                                                                    : string.Join("", enteredDigits);
            }
            else
            {
                Status = PossibleStatuses.Error.ToString().ToUpper();
            }
        }
    }

}
