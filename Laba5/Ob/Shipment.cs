using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    class Shipment
    {
        int number;
        public int Number
        {
            get { return number; }
        }

        string shiper;
        public string Shiper
        {
            get { return shiper; }
        }

        string productName;
        public string ProductName
        {
            get { return ProductName; }
        }

        DateTime produced;
        public DateTime Produced 
        {
            get { return produced; }
        }

        int daysLife;
        public int DaysLife 
        {
            get { return daysLife; }
        }

        string shelf;
        public string Shelf
        {
            get { return shelf; }
        }

        string howToCount;
        public string HowToCount 
        {
            get { return howToCount; }
        }

        int amount;
        public int Amount
        {
            get { return amount; }
        }

        //Стоимость одного
        double price;
        public double Price
        {
            get { return price; }
        }

        public Shipment(int _number, string _shiper, 
            string productname, DateTime _produced, int life, string _shelf,
            string tocount,
            int _amount, double _price)
        {
            Set(_number, _shiper, productname, _produced, life, _shelf,
             tocount,
             _amount, _price);
        }

        public void Set(int _number, string _shiper,
            string productname, DateTime _produced, int life, string _shelf,
            string tocount,
            int _amount, double _price)
        {
            number = _number;
            shiper = _shiper;
            productName = productname;
            produced = _produced;
            daysLife = life;
            shelf = _shelf;

            howToCount = tocount;

            amount = _amount;
            price = _price;
        }
    }
}
