using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            
                // Create the dictionary
                Dictionary<string, string> dictionary = new Dictionary<string, string>();

                int choice = 0;

                // Loop until user chooses Exit
                while (choice != 4)
                {
                    Console.WriteLine("\n=====  KD's Knowledge =====");
                    Console.WriteLine("1. Add Word");
                    Console.WriteLine("2. Search Word");
                    Console.WriteLine("3. Display All Words");
                    Console.WriteLine("4. Exit");
                    Console.Write("Enter your choice: ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                    {
                        Console.Write("Enter word: ");
                        string word = Console.ReadLine();

                        Console.Write("Enter meaning: ");
                        string meaning = Console.ReadLine();

                        // Check if word already exists
                        if (!dictionary.ContainsKey(word))
                        {
                            dictionary.Add(word, meaning);
                            Console.WriteLine("Word added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Word already exists.");
                        }
                    }

                    else if (choice == 2)
                    {
                        Console.Write("Enter word to search: ");
                        string searchWord = Console.ReadLine();

                        // Check if word exists
                        if (dictionary.ContainsKey(searchWord))
                        {
                            Console.WriteLine("Meaning: " + dictionary[searchWord]);
                        }
                        else
                        {
                            Console.WriteLine("Word not found.");
                        }
                    }

                    else if (choice == 3)
                    {
                        Console.WriteLine("\n--- Dictionary Words ---");

                        if (dictionary.Count == 0)
                        {
                            Console.WriteLine("Dictionary is empty.");
                        }
                        else
                        {
                           
                            foreach (KeyValuePair<string, string> item in dictionary)
                            {
                                Console.WriteLine(item.Key + " = " + item.Value);
                            }
                        }
                    }

                    else if (choice == 4)
                    {
                        Console.WriteLine("Program exited.");
                    }

                    else
                    {
                        Console.WriteLine("Invalid choice. Try again.");
                    }
                }
            
        }





    }
}

