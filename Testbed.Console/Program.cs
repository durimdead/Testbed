using Testbed.Common.Models;
using Testbed.Common.Models.Interfaces;
internal class Program
{
    private static void Main(string[] args)
    {
        IAnimal cat = new Cat("Sylvester");
        IAnimal dog = new Dog("Fido");

        List<IAnimal> animals = new List<IAnimal>() { cat, dog };
        animals.Add(new Dog("Sparky"));

        foreach(IAnimal currentAnimal in animals)
        {
            currentAnimal.Speak();
        }
    }
}