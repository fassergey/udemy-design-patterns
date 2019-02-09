using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Mediator
{
    /* Facilitates communication between components */

    /*
     * A component that facilitates communication
     * between other components without them necessarily
     * being aware of each other or having direct
     * (reference) access to each other
     */

    public class Person
    {
        public string Name;
        public ChatRoom Room;
        private List<string> chatLog = new List<string>();

        public Person(string name)
        {
            Name = name;
        }

        public void Say(string message)
        {
            Room.Broadcast(Name, message);
        }

        public void PrivateMessage(string who, string message)
        {
            Room.Message(Name, who, message);
        }

        public void Receive(string sender, string message)
        {
            string s = $"{sender}: '{message}'";
            chatLog.Add(s);
            WriteLine($"[{Name}'s chat session] {s}");
        }
    }

    // Mediator
    public class ChatRoom
    {
        private List<Person> People = new List<Person>();

        public void Join(Person p)
        {
            string joinMsg = $"{p.Name} joins the chart";
            Broadcast("room", joinMsg);
            p.Room = this;
            People.Add(p);
        }

        public void Broadcast(string source, string message)
        {
            foreach (var p in People)
            {
                if (p.Name != source)
                    p.Receive(source, message);
            }
        }

        public void Message(string source, string destination, string message)
        {
            People.FirstOrDefault(p => p.Name == destination)?.Receive(source, message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var room = new ChatRoom();

            var john = new Person("John");
            var jane = new Person("Jane");

            room.Join(john);
            room.Join(jane);

            john.Say("hi");
            jane.Say("oh, hey John");

            var simon = new Person("Simon");
            room.Join(simon);
            simon.Say("hi everyone!");

            jane.PrivateMessage("Simon", "glad you could join us!");
        }
    }
}
