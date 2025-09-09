using Testbed.Common.Models;
using Testbed.Common.Models.Interfaces;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        IAnimal cat = new Cat();

        Console.WriteLine(cat.Speak());
    }
}