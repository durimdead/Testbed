using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Policy;
using Testbed.Common.Models.Animals;
using Testbed.Common.Models.Interfaces;
using Testbed.Common.Services.Animals;
using Testbed.Common.Services.Interfaces;
using Testbed.Console;
using static Testbed.Common.Enums.AnimalEnums;
internal class Program
{
    //TODO: 
    //      - Attributes to be added:
    //          - Add in the ability to show how many "limbs" and the "type" of limbs they have (i.e. 2 wings vs 4 legs)
    //          - Height
    //          - Weight
    //          - Age
    //          - IsTrained
    //          - IsDomesticated
    //      - Add in the ability to show how many "limbs" and the "type" of limbs they have (i.e. 2 wings vs 4 legs)
    //      - Create a way to organize the animals by attributes (name, limbs, height, weight, action being taken, etc)
    
    private static void Main(string[] args)
    {
        MainEntry.Start();
    }
}