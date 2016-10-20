using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    class Sales
    {

        bool counted;
        public bool WasCounted
        {
            get { return counted; }
            set { counted = value; }
        }

        DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        string cashierName;
        public string CashierName
        {
            get { return cashierName; }
            set { cashierName = value; }
        }

        int number;
        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        int amountSold;
        public int AmountSold
        {
            get { return amountSold; }
            set { amountSold = value; }
        }

        //Стоимость одного
        double price;
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public Sales (int _sold, int _number, string _cashier, DateTime _date, double _price)
            {

                Set(_sold, _number, _cashier, _date, _price);
            }

        public void Set(int _sold, int _number, string _cashier, DateTime _date, double _price)
        {
           amountSold = _sold;
           number = _number;
           cashierName = _cashier;
           date = _date;
        }
    }
}
