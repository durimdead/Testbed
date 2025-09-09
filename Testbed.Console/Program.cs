using Testbed.Common.Models;
using Testbed.Common.Models.Interfaces;
internal class Program
{
    private static void Main(string[] args)
    {
        IAnimal cat = new Cat("Sylvester");
        string animalType = cat.GetType().ToString().Split(".").Last().ToLower();
        Console.WriteLine(cat.Name + " the " + animalType + " says " + cat.Speak());
    }
}