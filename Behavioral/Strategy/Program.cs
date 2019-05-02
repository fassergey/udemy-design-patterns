namespace Strategy
{
    /* System bahavior partially specified at runtime */

    /*
     * Enables the exact behavior of a system to be selected
     * either at run-time (dynamic) or compile-time (static).
     */

    class Program
    {
        static void Main(string[] args)
        {
            DynamicStrategy.Run();

            StaticStrategy.Run();
        }
    }
}
