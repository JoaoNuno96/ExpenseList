using System;
using System.Globalization;
using System.Collections.Generic;
using ExpensesList;
using System.Runtime.CompilerServices;

namespace ExpensesList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("______________________________EXPENSES LIST_________________________________");
            Console.WriteLine("This is a simple program, which lets you save all your expenses into a list.");
            Console.WriteLine("");
            Console.WriteLine("____________________________________________________________________________");

            bool execute = true;

            while (execute)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("Do you want to add an expense?(e) ");
                Console.WriteLine("Do you want to show current list ?(l) ");
                Console.WriteLine("Turn Off Application? (s) ");

                char Choice = char.Parse(Console.ReadLine());

                Expense Despesa = new Expense();
                List<Expense> ExList = new List<Expense>();

                if (Choice == 's' || Choice == 'S')
                {
                    execute = false;

                }

                if (Choice == 'e' || Choice == 'E')
                {
                    Console.WriteLine("");
                    Console.Write("How many expenses will you add? ");
                    int Nr = int.Parse(Console.ReadLine());

                    for (int i = 1; i <= Nr; i++)
                    {
                        Console.WriteLine("____________________________________________________________________________");
                        Console.WriteLine("Expense #" + i);
                        Console.Write("Name: ");
                        string Name = Console.ReadLine();
                        Console.Write("Price: ");
                        double Price = double.Parse(Console.ReadLine());

                        Despesa = new Expense(Name, Price);
                        ExList.Add(Despesa);
                        Console.WriteLine("Expense add with success!");
                        Console.WriteLine("____________________________________________________________________________");

                    }
                }

                if(Choice == 'l' || Choice == 'L')
                {
                    Console.WriteLine("");
                    double Gastos = 0;

                    if (ExList.Count() == 0)
                    {
                        Console.WriteLine("____________________________________________________________________________");
                        Console.WriteLine("No expense registered.");
                        Console.WriteLine("____________________________________________________________________________");
                    }
                    else
                    {
                        Console.WriteLine("____________________________________________________________________________");
                        Console.WriteLine("LIST OF EXPENSES:");
                        foreach (Expense ex in ExList)
                        {
                            
                            Console.Write($" ----> ");
                            Console.WriteLine(ex.ToString());
                            Gastos += ex.Price;

                        }

                        Console.WriteLine("");
                        Console.WriteLine($"Total Spend: {Gastos}$");
                        Console.WriteLine("____________________________________________________________________________");
                    }
                    Console.WriteLine("");

                }

            }
            Console.WriteLine("____________________________________________________________________________");
            Console.WriteLine("Application Shut Down!");
            Console.WriteLine("____________________________________________________________________________");

        }
    }


}