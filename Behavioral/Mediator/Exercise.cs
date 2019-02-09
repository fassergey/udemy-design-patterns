using System;
using System.Collections.Generic;
using System.Linq;

namespace Mediator
{
    public class Participant
    {
        private Mediator Mediator { get; set; }
        public int Value { get; set; }
        public string Identity { get; set; }

        public Participant(Mediator mediator)
        {
            Mediator = mediator;
            Mediator.Participants.Add(this);
            Identity = Guid.NewGuid().ToString();
        }

        public void Say(int n)
        {
            Mediator.IncreaseValues(Identity, n);
        }
    }

    public class Mediator
    {
        public IList<Participant> Participants = new List<Participant>();

        public void IncreaseValues(string sender, int value)
        {
            foreach (var p in Participants.Where(x => !string.Equals(sender, x.Identity)))
            {
                p.Value += value;
            }
        }
    }
}
