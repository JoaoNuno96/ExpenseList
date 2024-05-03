using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using ExpensesList.Entities;
using ExpensesList.Exceptions;

namespace ExpensesList.Entities
{
    class ListExpenses
    {
        public string Source { get; set; } = AppContext.BaseDirectory.Substring(0, 58);
        public List<Expense> ListExp { get; set; } = new List<Expense>();
        public ListExpenses() { }

        public void AddExp(Expense ex)
        {
            if (ex != null)
            {
                ListExp.Add(ex);
            }
            else
            {
                throw new AddExpenseException("Expense is empty");
            }

        }

        public void RemoveExp(Expense ex)
        {
            if (ex != null)
            {
                ListExp.Remove(ex);
            }
            else
            {
                throw new RemoveExpenseException("Can't remove an empty expense");
            }
        }

        public double AverageExPrice()
        {
            return ListExp.Select(x => x.Price)
                          .Average();
        }

        public double SumExPrice()
        {
            return ListExp.Select(x => x.Price)
                          .Sum();
        }

        public List<Expense> FilterExp(DateTime inicial, DateTime final)
        {
            List<Expense> listFilter = null;

            if (inicial == null)
            {
                throw new FilterException("Inicial Date not recognized");
            }

            if (final == null)
            {
                throw new FilterException("Final Date not recognized");
            }

            if (inicial != null && final != null)
            {
                listFilter = ListExp.Where(x => x.Date > inicial && x.Date < final)
                                    .ToList();
            }


            return listFilter;
        }

        public void ProcessListExpenseFile()
        {
            var Num = 0;
            var Path = Source + @$"Repository\lista{++Num}.txt";

            using (StreamWriter sw = File.CreateText(Path))
            {
                foreach (Expense ex in ListExp)
                {
                    sw.Write(ex);
                }
            }
        }


    }
}
