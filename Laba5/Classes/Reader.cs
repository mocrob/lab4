using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba5.Classes
{
    class Reader
    {
        string name; /*ФИО*/
        public string Name
        {
            get { return name; } 
        }

        public int number; /*номер билета*/
        Address adr;
        int phone;

        public Reader()
        {
            number = 7;
            adr = new Address();
            name = "Human";
            phone = 777;
        }

        public Reader(int num, Address ad, int ph, string r = "Human")
        {
            number = num;
            adr = ad;
            name = r;
            phone = ph;
        }


        public Reader(Reader red)
        {
            number = red.number;
            adr = red.adr;
            name = red.name;
            phone = red.phone;
        }

        public void Print(TextBox b, TextBox s, TextBox h, TextBox a, TextBox num, TextBox nam, TextBox ph)
        {
            adr.Print(b, s, h, a);
            num.Text = number.ToString();
            nam.Text = name.ToString();
            ph.Text = phone.ToString();
        }

    }
}
