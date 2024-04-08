using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesList.Entities
{
    class Expense
    {
        public string Name { get; set; }
        public double Price { get; private set; }
        public DateTime Date { get; set; }

        public Expense() { }

        public Expense(string n, double price)
        {
            Nome = n;
            Price = price;
            Date = DateTime.Now;
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
                    Name = "";
                }
            }
        }

        public override string ToString()
        {
            return $"Nome: {Name}, Preço: {Price}, Date: {Date.ToShortDateString()}";
        }


    }
}
