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
    //      - Create a few more animal classes
    //      - Add in the ability to show how many "limbs" and the "type" of limbs they have (i.e. 2 wings vs 4 legs)
    //      - Use vector instead of array for names to avoid having to state how many names there are?
    //      - Create a way to organize the animals by attributes (name, limbs, height, weight, action being taken, etc)
    //      - List out how many judgemental animals we have
    
    private static void Main(string[] args)
    {
        MainEntry.Start();
    }
}