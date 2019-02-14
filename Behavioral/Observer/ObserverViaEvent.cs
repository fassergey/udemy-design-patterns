using System;

namespace Observer
{
    public class FallIllEventArgs : EventArgs
    {
        public string Address;
    }

    public class Person
    {
        public event EventHandler<FallIllEventArgs> FallsIll;

        public void CatchACold()
        {
            //FallsIll?.Invoke(this, EventArgs.Empty);
            FallsIll?.Invoke(this, new FallIllEventArgs() { Address = "123 London Road" }); ;
        }
    }
}
