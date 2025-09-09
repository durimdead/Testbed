using Testbed.Common.Models;
using Testbed.Common.Models.Interfaces;
internal class Program
{
    private static void Main(string[] args)
    {
        Animal cat = new Cat("Sylvester");
        Animal dog = new Dog("Fido");

        List<Animal> animals = new List<Animal>() { cat, dog };
        animals.Add(new Dog("Sparky"));

        foreach(IAnimal currentAnimal in animals)
        {
            currentAnimal.Interact();
        }
    }
}