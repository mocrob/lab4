using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store
{

    class Store
    {
        private string Name;
        string LicenseNumber;
        string Adress;
        string PhoneNumber;

        double Income;

        string BIC; //Реквизиты банка
        double AllOfMoney;

        int CashiersCount;
        List<Cashier> cashiers;

        int ShipmentsCount;
        List<Shipment> shipmets;

        int SalesCount;
        List<Sales> sales;

        public Store(
            string _Name = "DefaultName",
            string _LicenseN = "000",
            string _Adr = "Streety Street",
            string _PhoneN = "66-66-07",
            string _BIC = "098765431",
            double _money = 256)
        {
            Name = _Name;
            LicenseNumber = _LicenseN;
            Adress = _Adr;
            PhoneNumber = _PhoneN;
            BIC = _BIC;
            AllOfMoney = _money;

            cashiers = new List<Cashier>();
            sales = new List<Sales>();
            shipmets = new List<Shipment>();
        }

        public Store(Store store)
        {
            Name = store.Name;
            LicenseNumber = store.LicenseNumber;
            Adress = store.Adress;
            PhoneNumber = store.PhoneNumber;
            BIC = store.BIC;
            AllOfMoney = store.AllOfMoney;
        }
        //Добавить продавца
        public void AddCashier(string FIO, int BoxNumber)
        {
            cashiers.Add(new Cashier(FIO, BoxNumber));
        }

        //Добавить продавца
        public void AddCashier(Cashier c)
        {
            cashiers.Add(c);
        }

        //Удалить продавца
        public void DelCashier(string FIO, int number)
        {
            foreach (Cashier cashier in cashiers)
                if (cashier.FullName == FIO && cashier.BoxNumber == number)
                    cashiers.Remove(cashier);
            //Cashier c = new Cashier(FIO, number)
            //cashiers.Remove(c);
        }

        //Вывести на интерфейс имнформацию о продавце
        public void printCashiers(Cashier cashier, TextBox FIO, TextBox BoxNumber)
        {
            //.Find
            FIO.Text = cashier.FullName;
            BoxNumber.Text = cashier.BoxNumber.ToString();
        }

        //Добавление партии
        public void AddShipment(int number, string shiper,
            string productname, DateTime produced, int life, string shelf,
            string tocount,
            int amount, double price)
        {
            shipmets.Add(new Shipment(number, shiper, productname, produced, life, shelf, tocount, amount, price));
        }

        public void AddShipment(Shipment s)
        {
            shipmets.Add(s);
        }


        //Изменение параметров партии
        public void ChangeShipment(int number, string shiper,
            string productname, DateTime produced, int life, string shelf,
            string tocount,
            int amount, double price)
        {
            shipmets.FindLast(delegate(Shipment sh) { return sh.Number == number; }).Set(number, shiper,
             productname, produced, life, shelf,
             tocount,
             amount, price);
        }

        //Вывести на интерфейс информацию о партии
        public void printShipment(Shipment shipment,
            TextBox number, TextBox shiper,
            TextBox productname, TextBox produced, TextBox life, TextBox shelf,
            TextBox tocount,
            TextBox amount, TextBox price)
        {
            number.Text = shipment.Number.ToString();
            shiper.Text = shipment.Shiper;
            productname.Text = shipment.ProductName;
            produced.Text = shipment.Produced.ToString();
            life.Text = shipment.DaysLife.ToString();
            shelf.Text = shipment.Shelf;
            tocount.Text = shipment.HowToCount;
            amount.Text = shipment.Amount.ToString();
            price.Text = shipment.Price.ToString();
        }

        //Удалить просроченные партии
        public void Outdated(DateTime today)
        {
            shipmets.RemoveAll(delegate(Shipment sh) { return (sh.Produced.AddDays(sh.DaysLife) < today); });
        }

        //Добавление продажи
        public void AddSales(int sold, int number, string cashier, DateTime date, double price)
        {
            sales.Add(new Sales(sold, number, cashier, date, price));
        }

        public void AddSales(Sales s)
        {
            sales.Add(s);
        }

        //Вывести на интерфейс информацию о продаже
        public void printSales(Sales sales,
            TextBox sold, TextBox number, TextBox cashier, TextBox date)
        {
            sold.Text = sales.AmountSold.ToString();
            number.Text = sales.Number.ToString();
            cashier.Text = sales.CashierName;
            date.Text = sales.Date.ToString();
        }

        //Подсчёт выручки
        public void Calculate()
        {
            foreach (Sales sale in sales)
            {
                if (sale.WasCounted == false)
                {
                    Income = (sale.Price - shipmets.FindLast(delegate(Shipment sh) { return sh.Number == sale.Number; }).Price) * sale.AmountSold;
                    sale.WasCounted = true;
                }
            }
        }

        //Зачисление выручки на счёт
        public void AddIncome()
        {
            Calculate();
            AllOfMoney += Income;
        }

        //Печать выручки
        public void PrintIncome(TextBox income)
        {
            income.Text = Income.ToString();
        }

        public Store Merging(Store aStore, string _Name = "DefaultName",
            string _LicenseN = "000",
            string _Adr = "Streety Street",
            string _PhoneN = "66-66-07",
            string _BIC = "098765431",
            double _money = 256)
        {
            Store newStore = new Store(_Name, _LicenseN, _Adr, _PhoneN, _BIC, _money);
            
            foreach (Cashier c in cashiers)
                newStore.AddCashier(c);
            foreach (Cashier c in aStore.cashiers)
                newStore.AddCashier(c);

            foreach (Shipment c in shipmets)
                newStore.AddShipment(c);
            foreach (Shipment c in aStore.shipmets)
                newStore.AddShipment(c);

            foreach (Sales c in sales)
                newStore.AddSales(c);
            foreach (Sales c in aStore.sales)
                newStore.AddSales(c);

            newStore.AllOfMoney = AllOfMoney + aStore.AllOfMoney;

            return newStore;
        }

        public void minusStore(Store bStore)
        {
            AllOfMoney -= bStore.AllOfMoney;

            foreach (Cashier c in bStore.cashiers)
            { 
                //TODO;
            }
        }
    }
}
