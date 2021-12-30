using System;
using System.Text.Json;

namespace JanID
{
    class Program
    {
        static void Main(string[] args) 
        {
            welcomeMsg();
            
            string fileName = "data.json";
            Food food = getJSON(fileName);
            
            //Console.WriteLine($"Meals: {food.Meals[0]}");
            //Console.WriteLine()

            Console.WriteLine($"{Environment.NewLine}Press any key to begin!");
            Console.ReadKey(true);

            //Console.WriteLine($"{Environment.NewLine}Would you like a meal or ")

            string[] options = {"Meal", "Food"};
            string mealOrFood = promptOptions("Would you like a meal or a specific food?", options);

            if (mealOrFood == "Meal") {
                Console.WriteLine($"{Environment.NewLine}{randomItem(food.Meals)}");
            } else {
                string[] foodOptions = {"Vegatables", "Nuts and seeds", "Meat", "Seafood", "Beans"};
                string category = promptOptions("Choose a category of food!", foodOptions);

                if (category == "Nuts and seeds") {
                    category = "Nuts_and_seeds";
                }

                Console.WriteLine($"{Environment.NewLine}{randomItem(food.Categories[category])}");

                if (category == "Vegatables") {
                    Console.WriteLine($"{Environment.NewLine}Heads-up! Some dark, leafy greens contain oxalates, which inhibit iron absorption. Try to incorporate other sources of iron as well!");
                    Console.WriteLine("Another way to counteract this effect is to consume Vitamin C, which will increase iron absorption.");
                    //Console.WriteLine("Would you like a recommendation for a fruit that contains Vitamin C?");

                    string[] yesNo = {"Yes", "No"};
                    string fruit = promptOptions("Would you like a recommendation for a fruit that contains Vitamin C?", yesNo);
                    //string[] jsonFruits = 
                    if (fruit == "Yes") {
                        Console.WriteLine($"{Environment.NewLine}{randomItem(food.Categories["Fruits"])}");
                    } else {

                    }
                    
                }

                if (category == "Meat") {
                    Console.WriteLine($"{Environment.NewLine}Great choice! Meat contains heme iron, which is much easier to absorb than its counterpart, non-heme iron!");
                    Console.WriteLine("Keep in mind, red meat has the highest amount of iron, while poultry and chicken have lower amounts.");
                }

                if (category == "Beans") {
                    Console.WriteLine($"{Environment.NewLine}Heads-up! Beans contain phylates, which can inhibit iron absorption! Be sure to include other sources of iron in your diet!");
                }
            }
        }

        static void welcomeMsg()    
        {
            string title = "Jan's Personal Anemia Slayer";
            Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);
            Console.WriteLine(title);

            Console.WriteLine($"{Environment.NewLine}HEWWO my tubby cutie!");
            Console.WriteLine($"{Environment.NewLine}I built this to hopefully help you find yummy foods that are high in iron!");
            Console.WriteLine($"{Environment.NewLine}We will combat and prevail against your anemia.");

        }

        static Food getJSON(string fileName) 
        {
            string jsonString = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<Food>(jsonString);
        }

        static string promptOptions(string question, string[] options) 
        {
            Console.WriteLine($"{Environment.NewLine}{question}");
            Console.WriteLine("Select an option by typing the number and pressing \"Enter\"");

            string allOptions = "";
            for (int i = 0; i < options.Length; i++) {
                allOptions += $"{i + 1}. {options[i]}  ";
            }

            Console.WriteLine(allOptions);
            
            int optionChosen = int.Parse(Console.ReadLine());
            string stringOption = options[optionChosen - 1];

            return stringOption;

        }

        static string randomItem(string[] items) {
            return items[new Random().Next(0, items.Length)];
        }
    }
}
