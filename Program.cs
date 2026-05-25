using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    class Rental
    {
        public string CustomerName { get; set; }
        public string BookTitle { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string correctUsername = "admin";
            string correctPassword = "1234";

            int attempts = 3;
            bool isLoggedIn = false;

            while (attempts > 0)
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine();

                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                if (username == correctUsername && password == correctPassword)
                {
                    Console.WriteLine("\nLogin successful!\n");
                    isLoggedIn = true;
                    break;
                }
                else
                {
                    attempts--;
                    Console.WriteLine($"Wrong credentials. Attempts left: {attempts}\n");
                }
            }

            if (!isLoggedIn)
            {
                Console.WriteLine("Too many failed attempts. Program will exit.");
                return; 
            }

            Console.WriteLine("Welcome to the Library System!");

            Queue<Rental> rentalQueue = new Queue<Rental>();
            List<Rental> borrowedBooks = new List<Rental>();
            int choice;

            do
            {
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Serve Next Customer");
                Console.WriteLine("3. View Queue");
                Console.WriteLine("4. View Borrowed Books"); 
                Console.WriteLine("5. Return Book");         
                Console.WriteLine("6. Exit");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter customer name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter book to borrow: ");
                        string book = Console.ReadLine();

                        rentalQueue.Enqueue(new Rental
                        {
                            CustomerName = name,
                            BookTitle = book
                        });

                        Console.WriteLine("Customer added to queue!");
                        break;

                    case 2:
                        if (rentalQueue.Count > 0)
                        {
                            Rental served = rentalQueue.Dequeue();
                            borrowedBooks.Add(served); 
                            Console.WriteLine($"\n{served.CustomerName} borrowed \"{served.BookTitle}\"");
                        }
                        else
                        {
                            Console.WriteLine("Queue is empty.");
                        }
                        break;

                    case 3:
                        Console.WriteLine("\nCustomers in Queue:");
                        foreach (var r in rentalQueue)
                        {
                            Console.WriteLine($"{r.CustomerName} → {r.BookTitle}");
                        }
                        break ; 
                    
                    

                    case 4:
                        Console.WriteLine("\nBorrowed Books:");

                        if (borrowedBooks.Count == 0)
                        {
                            Console.WriteLine("No books are currently borrowed.");
                        }
                        else
                        {
                            foreach (var r in borrowedBooks)
                            {
                                Console.WriteLine($"{r.CustomerName} → {r.BookTitle}");
                            }
                        }
                        break;

                    case 5:

                    
                        Console.Write("Enter student name: ");
                        string returnName = Console.ReadLine();

                        Console.Write("Enter book to return: ");
                        string returnBook = Console.ReadLine();

                        Rental found = borrowedBooks.Find(r =>
                            r.CustomerName.ToLower() == returnName.ToLower() &&
                            r.BookTitle.ToLower() == returnBook.ToLower());

                        if (found != null)
                        {
                            borrowedBooks.Remove(found);
                            Console.WriteLine($"{returnName} returned \"{returnBook}\"");
                        }
                        else
                        {
                            Console.WriteLine("Record not found. Check name or book.");
                        }
                        break;

                }

            } while (choice != 6);

            Console.WriteLine("Program ended.");
        }
    }



}    
    

