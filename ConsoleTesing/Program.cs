using BusinessLogic;

namespace ConsoleTesing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BL logic = new BL();
            Console.WriteLine($"{logic.MaxScore}");
        }
    }
}