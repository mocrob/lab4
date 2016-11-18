using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba5.Classes
{
    public class Address
    {
        string city;
        string street;

        int house;
        int apt;

        public Address()
        {
            city = "Default City";
            street = "54";
            house = 1;
            apt = 1;
        }
        public Address(string c, string s, int a, int h)
        {
            city = c;
            street = s;
            apt = a;
            house = h;
        }
        public Address(int h, int a, string c = "Default Town", string s = "Empty st.")
        {
            city = c;
            street = s;
            apt = a;
            house = h;
        }
        public Address(Address _a)
        {
            city = _a.city;
            street = _a.street;
            house = _a.house;
            apt = _a.apt;
        }

        public void Print(TextBox c, TextBox s, TextBox h, TextBox a)
        {
            c.Text = city.ToString();
            s.Text = street.ToString();
            h.Text = house.ToString();
            a.Text = apt.ToString();
        }
    }
}
