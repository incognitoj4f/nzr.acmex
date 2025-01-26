using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PersonalInformationApp
{
    class Program
    {
        // Define a class to hold personal information
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string Address { get; set; }
            public string Occupation { get; set; }
        }

        static void Main(string[] args)
        {
            // Initialize a new Person object
            Person person = new Person();

            // Welcome the user
            Console.WriteLine("Welcome to the Personal Information App!");

            // Collect user information using Console.ReadLine
            person.FirstName = AskForInput("Please enter your first name:");
            person.LastName = AskForInput("Please enter your last name:");
            person.Age = AskForAge("Please enter your age:");
            person.Email = AskForInput("Please enter your email address:");
            person.PhoneNumber = AskForInput("Please enter your phone number:");
            person.Address = AskForInput("Please enter your address:");
            person.Occupation = AskForInput("Please enter your occupation:");

            // Create a dictionary for additional information (could be extended)
            var additionalInfo = new Dictionary<string, string>
            {
                { "Hobbies", AskForInput("Please enter your hobbies:") },
                { "Favorite Color", AskForInput("Please enter your favorite color:") },
                { "Favorite Food", AskForInput("Please enter your favorite food:") }
            };

            // Output the information in JSON format
            Console.WriteLine("\nYour information in JSON format:");
            string jsonOutput = JsonConvert.SerializeObject(new { person, additionalInfo }, Formatting.Indented);
            Console.WriteLine(jsonOutput);

            // Wait for user input before exiting
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        // Method to ask for user input with validation
        static string AskForInput(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();

            // Basic validation for empty input
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty. " + prompt);
                input = Console.ReadLine();
            }

            return input;
        }

        // Method to ask for a valid age input
        static int AskForAge(string prompt)
        {
            int age;
            bool validAge = false;

            // Loop until a valid age is entered
            while (!validAge)
            {
                Console.WriteLine(prompt);
                string ageInput = Console.ReadLine();

                // Try parsing the age input
                validAge = int.TryParse(ageInput, out age) && age > 0;

                // If invalid, prompt again
                if (!validAge)
                {
                    Console.WriteLine("Please enter a valid age (positive number).");
                }
            }

            return age;
        }
    }
}
