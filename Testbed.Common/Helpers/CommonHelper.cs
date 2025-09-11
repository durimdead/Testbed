using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Testbed.Common.Helpers
{
    public static class CommonHelper
    {

        /// <summary>
        /// Returns a list of all subClasses of a given parentClass
        /// </summary>
        /// <param name="parentClass">The parent class you're looking for children of</param>
        /// <param name="assemblyPartialName">OPTIONAL: if included, will filter the assemblies by <paramref name="assemblyPartialName"/>. If not included, will search ALL assemblies for the given type.</param>
        /// <returns>An array of Types based on the criteria being searched for</returns>
        public static Type[] GetAllSubClasses(Type parentClass, string assemblyPartialName = "")
        {
            List<Type> returnValue = new List<Type>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            //List the assemblies in the current application domain.
            foreach (Assembly assem in assemblies)
            {
                string assemblyName = assem.ToString();
                // search based on the partial or whole name of the assembly passed in
                if (assemblyName.Contains(assemblyPartialName) || assemblyPartialName == string.Empty)
                {
                    foreach (var currentType in assem.GetTypes())
                    {
                        // for each of the types in the assemblies, add it to the return value if it's a subClass of the parent type
                        if (currentType.IsSubclassOf(parentClass))
                        {
                            returnValue.Add(currentType);
                        }
                    }
                }
            }

            return returnValue.ToArray();
        }

        /// <summary>
        /// gets a single, random name from a list of 1000 names
        /// </summary>
        /// <returns>One, random name</returns>
        public static string GetRandomName()
        {
            string[] listOfNames = new string[1000] { "Ryann", "Jeremias", "Kate", "Rocky", "Aurora", "Eugene", "Elliott", "Cedric", "Makayla", "Jayson", "Mercy", "Max", "Freya", "Gerardo", "Kaylie", "Corey", "Juliette", "Kristian", "Zaylee", "Fernando", "Julieta", "Keaton", "Antonella", "Hamza", "Avery", "Zayne", "Andi", "Sutton", "Brylee", "Jay", "Maya", "Jaiden", "Scarlette", "Ryland", "Alana", "Ishaan", "Delilah", "Blaine", "Yasmin", "Francisco", "Justice", "Logan", "Sadie", "Canaan", "Judith", "Ayden", "Faye", "Quincy", "Iris", "Jair", "Miracle", "Jair", "Kensley", "Landyn", "Willa", "Raiden", "Gabriela", "Reid", "Denisse", "Jadiel", "Laney", "Parker", "Zendaya", "Omar", "Kadence", "Stetson", "Ariyah", "Deandre", "Lydia", "Truett", "Lylah", "Alberto", "Payton", "Damien", "Summer", "Enrique", "Promise", "Lian", "Ari", "Lennon", "Gwendolyn", "Maximilian", "Thalia", "Rayan", "Malayah", "Sawyer", "Iliana", "Jay", "Salem", "Aden", "Liliana", "Bruce", "Elliott", "Landyn", "Brielle", "Kelvin", "Milan", "Jamir", "Zara", "Theodore", "Paisley", "Noel", "Nicole", "Davion", "Lennon", "Tyson", "Riley", "Finnegan", "Alison", "Vincent", "Alejandra", "Salvador", "Bella", "Aryan", "Zendaya", "Esteban", "Marilyn", "Raul", "Kaitlyn", "Karter", "Juliana", "Connor", "Emerson", "Grady", "Iliana", "Everett", "Millie", "Judah", "Kairi", "Jad", "Cynthia", "Harrison", "Mira", "Jad", "Avalynn", "Apollo", "Charli", "Jakob", "Kimora", "Johan", "Thea", "Zayden", "Angel", "Deandre", "Thea", "Roy", "Sadie", "Ayan", "Londyn", "Conner", "Gabriela", "Alessandro", "Jayleen", "Valentin", "Isabelle", "Reid", "Ashlyn", "Louis", "Jovie", "Ephraim", "Lydia", "Kamdyn", "Bellamy", "Jorge", "Phoenix", "Rowen", "Jaelynn", "Scott", "Anais", "Steven", "Sariah", "Kylian", "Valery", "Casen", "Vivienne", "Oscar", "Karter", "Santino", "Artemis", "Julius", "Vivian", "Marco", "Maren", "Talon", "Karter", "Callen", "Ainsley", "Yosef", "Harlee", "Jericho", "Vivian", "Everett", "Aspen", "Bruce", "Ariella", "Demetrius", "Gemma", "Ishaan", "Kehlani", "Amari", "Aria", "Troy", "Ramona", "Kenneth", "Athena", "Joe", "Demi", "Clayton", "Zoe", "Sterling", "Madelyn", "Valentin", "Alaiya", "Emmanuel", "Imani", "Cullen", "Kassidy", "Brooks", "Zora", "Trey", "Hayley", "Cody", "Maren", "Abraham", "Emberly", "Kyree", "Michaela", "Sebastian", "Princess", "Jovanni", "Maci", "Samir", "Alexis", "Kameron", "Janelle", "Kaison", "Addison", "Ryker", "Lucy", "Harris", "Sarah", "Jake", "Analia", "Silas", "Anya", "Braylon", "Nylah", "Patrick", "Bristol", "Desmond", "Mina", "Richard", "Joyce", "Malakai", "Marisol", "Barrett", "Jessie", "Koa", "Simone", "Mario", "Anne", "Shane", "Carly", "Cason", "Isabelle", "Levi", "Aleena", "Sebastian", "Aubrie", "Dakota", "Ensley", "Carter", "Savannah", "Alfredo", "Angela", "Musa", "Braelynn", "Sebastian", "Mariam", "Kieran", "Margo", "Carmelo", "Serenity", "Gabriel", "Kynlee", "Adan", "Molly", "Johnathan", "Kylie", "Grant", "Guadalupe", "Colby", "Saoirse", "Allen", "Laylani", "Maxwell", "Lyric", "Zahir", "Andrea", "Asa", "Emmalynn", "Amir", "London", "Asher", "Eloise", "Isaias", "Kaiya", "Cory", "Katalina", "Jamie", "Denisse", "Eugene", "Jada", "Camilo", "Amira", "Leon", "Denise", "Dangelo", "Bonnie", "Amir", "Hayden", "Dakari", "Elliott", "Wade", "Daniella", "Fox", "Brittany", "Raul", "Lexi", "Lukas", "Winter", "Taylor", "Katherine", "Dustin", "Isabella", "Miguel", "Jimena", "Alexander", "Allie", "Legend", "Nayeli", "Boone", "Jenna", "Lachlan", "Jaylin", "Donald", "Kyla", "Kannon", "Phoebe", "Benjamin", "Laurel", "Cal", "Aylin", "Flynn", "Milan", "Michael", "Virginia", "Ryland", "Dylan", "Preston", "Amanda", "Castiel", "Adalee", "Jaxen", "Livia", "Myles", "Morgan", "Aron", "Livia", "Daniel", "Anahi", "Ahmed", "Mabel", "Connor", "Ailani", "Jakari", "Malayah", "Adonis", "Lilly", "Maison", "Allie", "Coen", "Guadalupe", "Heath", "Adele", "Blaze", "Ashlynn", "Maximilian", "Anne", "Lewis", "Cadence", "Musa", "Brynlee", "Lucas", "Blair", "Emery", "Ariah", "Braylon", "Itzel", "Cole", "Sloan", "Peyton", "Eleanor", "Malachi", "Izabella", "Colson", "Addilyn", "Zachariah", "Lacey", "Lionel", "Evelynn", "Duke", "Romina", "Blaze", "Zuri", "Brendan", "Coraline", "Jensen", "Jamie", "Kyng", "Mckenna", "Koda", "Alessia", "Marshall", "Ruby", "Duncan", "Alessia", "Jaime", "Teresa", "Kason", "Charli", "Jad", "Ainhoa", "Jimmy", "Noor", "Enzo", "Scarlet", "Memphis", "Rory", "Ethan", "Morgan", "Xzavier", "Aylin", "Noe", "Ryann", "Niko", "Sylvia", "Stefan", "Marlee", "Andrew", "Isabel", "Lachlan", "Hadassah", "Alvaro", "Harmoni", "Beckett", "Sky", "Emory", "Ava", "Arian", "Anahi", "Lucca", "Collins", "Alan", "Penelope", "Vincenzo", "Josephine", "Remi", "Alena", "Eric", "Andi", "Benicio", "Naomi", "Gage", "Ayla", "Ander", "Madilynn", "Wade", "Florence", "Zayne", "Adalynn", "Duncan", "Logan", "Damari", "Palmer", "Dexter", "Sienna", "Andrew", "Aspyn", "Samson", "Nancy", "Brayan", "Holly", "Armani", "Amirah", "Allan", "Liv", "Franco", "Julieta", "Ayaan", "Lilliana", "Moises", "Mara", "Briggs", "Olive", "Michael", "Bailee", "Roberto", "Ansley", "Oscar", "Chana", "Frank", "Raelynn", "Porter", "Navy", "Kristian", "Imani", "Darwin", "Elora", "Mario", "Scarlett", "Cyrus", "Amoura", "Ethan", "Daphne", "Jaziel", "Daniela", "Amir", "Lia", "Travis", "Malani", "Abner", "Nevaeh", "Josiah", "Heidi", "Duke", "Maeve", "Luka", "Anastasia", "Adrian", "Lilyana", "Seth", "Rosemary", "Jayceon", "Kamila", "Emory", "Raven", "Rayan", "Alaya", "Caiden", "Mikayla", "Cole", "Claire", "Juan", "Cleo", "Nova", "Anais", "Fabian", "Lorelei", "Nicolas", "Meghan", "Calum", "Brylee", "Mekhi", "Saige", "Quincy", "Aaliyah", "Larry", "Victoria", "Bjorn", "Denver", "Dillon", "Noah", "Devin", "Ruby", "Luke", "Violette", "Kenzo", "Deborah", "Landyn", "Amiyah", "Azariah", "Nora", "Terry", "Camille", "Johan", "Braelyn", "Nelson", "Sierra", "Ephraim", "Palmer", "Rowan", "Xiomara", "Arlo", "Andrea", "Owen", "Landry", "Declan", "Kali", "Roger", "Frankie", "Roland", "Coraline", "Spencer", "Dani", "Huxley", "Emmeline", "Kellen", "Kayla", "Juan", "Celine", "Rocky", "Emmy", "Wyatt", "Leilany", "Bentley", "Paris", "Xavier", "Rylie", "Vihaan", "Mavis", "Brennan", "Averi", "Korbyn", "Marisol", "Asher", "Kailey", "Ruben", "Alicia", "Major", "Zora", "Alex", "Bristol", "Rome", "Kora", "Andres", "Eden", "Ricardo", "Arabella", "Kamdyn", "Ainhoa", "King", "Bailee", "Tripp", "Adele", "Dexter", "Capri", "Kamari", "Celeste", "Foster", "Zoie", "Rocky", "Lola", "Layne", "Lucy", "Azariah", "Nathalie", "Major", "Anastasia", "Eric", "Kallie", "Frederick", "Deborah", "Bridger", "Scarlette", "Jedidiah", "Vera", "Eli", "Adriana", "Callen", "Ari", "Cash", "Daleyza", "Randy", "Amaya", "Luke", "Celia", "Crosby", "Rose", "Aiden", "Davina", "Dustin", "Della", "Jeremias", "Destiny", "Maxwell", "Morgan", "Tristan", "Cecelia", "Harold", "Kamilah", "Koa", "Mckenzie", "Misael", "Skye", "Koda", "Avalynn", "Jensen", "Lillie", "Jaime", "Hazel", "Alexander", "Autumn", "Samuel", "Octavia", "Samir", "Ariah", "Atticus", "Kamilah", "Marcos", "Hadley", "Ulises", "Emery", "Korbin", "Kinsley", "Oliver", "Bellamy", "Odin", "Sarai", "Isaiah", "Rosalia", "Vincenzo", "Mary", "Arjun", "Zainab", "Saint", "Catalina", "Alonzo", "Laurel", "Graham", "Leah", "Leif", "Gracelynn", "Gustavo", "Brylee", "Luke", "Ashlynn", "Manuel", "Elina", "Sage", "Teresa", "Joaquin", "Brooklyn", "Nicholas", "Anahi", "Sullivan", "Paisleigh", "Royce", "Ximena", "Cooper", "Kai", "Damir", "Kai", "Frank", "Bella", "Ernesto", "Rosalyn", "Griffin", "Isabelle", "Jaxtyn", "Daniella", "Beckham", "Milena", "August", "Davina", "Hank", "Zoey", "Archie", "Clara", "Louie", "Anahi", "Truett", "Lillian", "Dalton", "Payton", "Kylian", "Raelyn", "Maximo", "Lexie", "Noe", "Aubrie", "Jaxson", "Gemma", "Enrique", "Talia", "Henry", "Khloe", "Declan", "Aubrie", "Griffin", "Zora", "Wells", "Rory", "Tucker", "Thea", "Colton", "Emmy", "Ian", "Adele", "Grey", "Ryleigh", "Russell", "Luna", "Fisher", "Anais", "Tucker", "Brynlee", "Van", "Zelda", "Jameson", "Christina", "Sterling", "Remy", "Troy", "Adriana", "Armani", "Lylah", "Otis", "Stevie", "Pierce", "Kennedy", "Lennon", "Tiana", "Kameron", "Landry", "Branson", "Leila", "Leland", "Milana", "Seven", "Amalia", "Christopher", "Louisa", "Leandro", "Adaline", "Emory", "Ariel", "Jude", "Louisa", "Axel", "Raquel", "Jaime", "Lainey", "Aaron", "June", "Lyric", "Noemi", "Morgan", "Julia", "Dominik", "Rayne", "Sergio", "Alessia", "Valentin", "Kairi", "Maximiliano", "Zaria", "Judah", "Camila", "Leon", "Cataleya", "Maximiliano", "Teagan", "Diego", "Kora", "Gabriel", "Lylah", "Callen", "Gabriella", "Rene", "Zoe", "Nash", "Crystal", "Carson", "Kadence", "Noel", "Melanie", "Jesse", "Madelyn", "Adriel", "Aliyah", "Harris", "Theodora", "Magnus", "Laura", "Frederick", "Mikayla", "Miller", "Kayla", "Isaiah", "Emmalynn", "Ashton", "Amelie", "Zane", "Keira", "Jacoby", "Allie", "Abram", "Rosalie", "Devin", "Heaven", "Reid", "Azalea", "Jesse", "Leona", "Kellan", "Jocelyn", "Cairo", "Emmeline", "Shepherd", "Galilea", "Ace", "Makenna", "Cameron", "Emmy", "Zyaire", "Briar", "Trenton", "Daisy", "Parker", "Amaia", "Easton", "Sloan", "Ayan", "Denisse", "Gary", "Lila", "Tyler", "Emerie", "Barrett", "Adele", "Kase", "Rosemary", "Cullen", "Paisleigh", "Zavier", "Madilyn", "Blaze", "Mackenzie", "Nelson", "Valentina", "Clark", "Nataly", "Mylo", "Stephanie", "Orion", "Ruby", "Major", "Brynleigh", "Marcos", "Violeta", "Peyton", "Emmalyn", "Dorian", "Nyla", "Bellamy", "Erin", "Marlon", "Hayley", "Bentley", "Guadalupe", "Knox", "Malaya", "Kevin", "Madison", "Harry", "Anya", "Rory", "Noemi", "Lucian", "Andi", "Alvin", "Braylee", "Eliezer", "Esther", "Jonah", "Emani", "Kasen", "Elsie", "Quincy", "Livia", "Fernando", "Abby", "Elias", "Aspyn", "Nikolas", "Belle", "Ryker", "Robin", "Maximiliano", "Meghan", "Bobby", "Lucy", "Apollo", "Joelle", "Warren", "Demi", "Benson", "Deborah", "Sutton" };
            int randomNameIndex = RandomNumberGenerator.GetInt32(1000);
            return listOfNames[randomNameIndex];
        }

        /// <summary>
        /// Converts a Variable name to a sentence
        /// </summary>
        /// <param name="variableToConvert">the string to convert to a sentence</param>
        /// <param name="preserveAcronyms">true if you want multiple upper case letters in a row to stay together, otherwise false (default false)</param>
        /// <returns>the <paramref name="variableToConvert"/> as a sentence with spaces before each upper case letter</returns>
        public static string ConvertVariableNameToReadableString(string variableToConvert, bool preserveAcronyms = false)
        {
            string returnValue = string.Empty;
            if (!string.IsNullOrWhiteSpace(variableToConvert))
            {
                // add the first character and ensure it is upper case
                returnValue += variableToConvert[0];
                for (int index = 1; index < variableToConvert.Length; index++)
                {
                    if (char.IsUpper(variableToConvert[index]))
                    {
                        if (
                            (variableToConvert[index - 1] != ' ' && !char.IsUpper(variableToConvert[index - 1]))
                            || (preserveAcronyms && char.IsUpper(variableToConvert[index - 1])
                                && (index < variableToConvert.Length - 1 && !char.IsUpper(variableToConvert[index + 1])))
                            )
                        {
                            returnValue += " ";
                        }
                    }
                    returnValue += variableToConvert[index];
                }
            }
            return returnValue;
        }
    }
}
