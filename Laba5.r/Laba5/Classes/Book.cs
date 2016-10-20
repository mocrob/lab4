using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba5.Classes
{
    class Book
    {
        public int number;

        string author;
        string name;
        int year;

       public int price; /*необходимо будет учитывать, что последние два символа - ком/цент/итд*/
       public int quantity; /*количество*/
       public int inuse; /*количество выданых*/

        public Book()
        {
            number = 1;
            name = "Empty Book";
            author = "Nobody";
            year = 0;
            price = 100;
            quantity = 1;
        }
        public Book(int num, int y, int pr, int quan, int i, string b = "Empty Book", string a = "Nobodys")
        {
            number = num;
            name = b;
            author = a;
            year = y;
            price = pr;
            quantity = quan;
            inuse = i;
        }
        public Book(Book b)
        {
            number = b.number;
            name = b.name;
            author = b.author;
            year = b.year;
            quantity = b.quantity;
            inuse = b.inuse;
            price = b.price;
        }

        public int DecQuantity(int d)
        {
            if (quantity > 0)
            {
                quantity -= d;
                return 1;
            }
            else
                return 0;
        }
        public void IncQuantity(int d)
        {
            quantity += d;
        }

        public void Print(TextBox _number, TextBox _name, TextBox _author, TextBox _year, TextBox _price,
            TextBox _quantity, TextBox _inuse)
        {
            _number.Text = number.ToString();
            _name.Text = name.ToString();
            _author.Text = author.ToString();
            _year.Text = year.ToString();
            _price.Text = price.ToString();
            _quantity.Text = quantity.ToString();
            _inuse.Text = inuse.ToString();
        }

        public override bool Equals(object obj)
        {
            Book b = obj as Book;
            if (b != null)
            {
                if (number == b.number)
                    return true;
            }
            return base.Equals(obj);
        }
    }
}
