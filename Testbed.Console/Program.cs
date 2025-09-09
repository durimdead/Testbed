using System.Diagnostics.CodeAnalysis;
using System.Security.AccessControl;
using System.Security.Cryptography;
using Testbed.Common.Models;
using Testbed.Common.Models.Interfaces;
using static Testbed.Common.Enums.AnimalEnums;
internal class Program
{
    private const int V = 1;

    private static void Main(string[] args)
    {
        //Animal cat = new Cat("Sylvester");
        //Animal dog = new Dog("Fido");

        //List<Animal> animals = new List<Animal>() { cat, dog };
        //animals.Add(new Dog("Sparky"));
        //animals.Add(new Cat(""));

        var randomAnimals = CreateRandomSetOfAnimals();

        foreach (IAnimal currentAnimal in randomAnimals)
        {
            currentAnimal.Interact();
        }
    }

    private static List<Animal> CreateRandomSetOfAnimals()
    {
        List<Animal> returnValue = new List<Animal>();
        // create at least 1 animal
        int numberOfAnimals = RandomNumberGenerator.GetInt32(20) + 1;

        for (int counter = 0; counter < numberOfAnimals; counter++)
        {
            Type[] animalTypes = new Type[] { typeof(Cat), typeof(Dog), typeof(Bird) };
            int randomizeAnimalType = RandomNumberGenerator.GetInt32(animalTypes.Length);
            Animal newAnimal = (Animal)Activator.CreateInstance(animalTypes[randomizeAnimalType]);
            returnValue.Add(newAnimal);
        }
        return returnValue;
    }
}