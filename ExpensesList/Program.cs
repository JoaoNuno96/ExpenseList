using System;
using System.Globalization;
using System.Collections.Generic;
using ExpensesList.Entities;
using System.Collections;
using ExpensesList.Exceptions;

namespace ExpensesList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("______________________________EXPENSES LIST_________________________________");
            Console.WriteLine("This is a simple program, which lets you save all your expenses into a list.");
            Console.WriteLine("");
            Console.WriteLine("____________________________________________________________________________");

            bool execute = true;
            ListExpenses listExp = new ListExpenses();

            while (execute)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("Add an expense?(e) ");
                Console.WriteLine("Show current list ?(l) ");
                Console.WriteLine("Filter the list by dates ?(f) ");
                Console.WriteLine("Turn Off Application? (s) ");

                char Choice = char.Parse(Console.ReadLine());

                try
                {
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
                            double Price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                            Console.Write("Date: ");
                            DateTime Date = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

                            var ex = new Expense(Price, Date);
                            ex.Nome = Name;
                            listExp.AddExp(ex);
                            //listExp.ProcessListExpenseFile();

                            Console.WriteLine("Expense add with success!");
                            Console.WriteLine("____________________________________________________________________________");

                        }
                    }

                    if (Choice == 'l' || Choice == 'L')
                    {
                        Console.WriteLine();

                        if (listExp == null)
                        {
                            Console.WriteLine("____________________________________________________________________________");
                            Console.WriteLine("No expense registered.");
                            Console.WriteLine("____________________________________________________________________________");
                        }
                        else
                        {
                            Console.WriteLine("____________________________________________________________________________");
                            Console.WriteLine("LIST OF EXPENSES:");
                            foreach (Expense ex in listExp.ListExp)
                            {
                                Console.WriteLine(ex);
                            }

                            Console.WriteLine("");
                            Console.WriteLine($"Average Price (per Expense): {listExp.AverageExPrice()}$");
                            Console.WriteLine($"Total Spend: {listExp.SumExPrice()}$");
                            Console.WriteLine("____________________________________________________________________________");
                        }
                        Console.WriteLine("");

                    }

                    if(Choice == 'f' || Choice == 'F')
                    {
                        Console.WriteLine();
                        if (listExp == null)
                        {
                            Console.WriteLine("____________________________________________________________________________");
                            Console.WriteLine("No expense registered.");
                            Console.WriteLine("____________________________________________________________________________");
                        }
                        else
                        {
                            Console.WriteLine("____________________________________________________________________________");
                            Console.WriteLine("Inicial Date (dd-MM-yyyy):");
                            DateTime dateInitial = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                            Console.WriteLine("Final Date (dd-MM-yyyy):");
                            DateTime dateFinal = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);


                        }
                    }

                }
                catch(ExpenseException ex)
                {
                    Console.WriteLine(ex.Message + ", " + ex.Source);
                }
                catch (AddExpenseException ax)
                {
                    Console.WriteLine(ax.Message + ", " + ax.Source);
                }
                catch (RemoveExpenseException rx)
                {
                    Console.WriteLine(rx.Message + ", " + rx.Source);
                }
                catch (FilterException fx)
                {
                    Console.WriteLine(fx.Message + ", " + fx.Source);
                }



            }
            
            Console.WriteLine("____________________________________________________________________________");
            Console.WriteLine("Application Shut Down!");
            Console.WriteLine("____________________________________________________________________________");

        }
    }


}