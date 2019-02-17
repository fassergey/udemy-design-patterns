namespace Visitor
{
    /* Typically a tool for structure traversal rather than anything else. */

    /*
     * A pattern where a component (visitor) is allowed to traverse the entire
     * inheritance hierarchy. Implemented by propagating a single visit() method
     * throughout the entire hierarchy.
     */

    class Program
    {
        static void Main(string[] args)
        {
            Intrusive.Intrusive.Run();
            Reflective.Reflective.Run();
            Classic.Classic.Run();
            Dynamic.Dynamic.Run();
            Acyclic.Acyclic.Run();
        }
    }
}
