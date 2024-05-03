using System;
using System.Globalization;
using System.Collections.Generic;
using ExpensesList.Exceptions;


namespace ExpensesList.Entities
{
    class Expense
    {
        public string Name { get; set; }
        public double Price { get; private set; }
        public DateTime Date { get; set; }

        public Expense() { }

        public Expense(double price, DateTime dt)
        {
            Price = price;
            Date = dt;
        }

        public string Nome
        {
            set
            {
                if (value.Length > 3 && value.Length < 20)
                {
                    Name = value;
                }
                else
                {
                    throw new ExpenseException("Expense's name must have 3 to 20 characters");
                }
            }
        }

        public override string ToString()
        {
            return $"Nome: {Name}, Preço: {Price}, Date: {Date.ToShortDateString()}";
        }


    }
}
