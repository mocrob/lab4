using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba5.Classes
{
    class Issue
    {
        public int r_number;/*номер билета*/

        int b_number;
        public int BookN
        { get { return b_number; } }
        DateTime out_date/*[3]*/;
        public int ex;
        DateTime in_date/*[3]*/;

        public Issue(int RN, int BN, DateTime odate, int x, DateTime idate)
        {
            r_number = RN;   // номер читателя
            b_number = BN;   // номер книги
            out_date = odate;  // дата выдачи
            ex = x;  // количество экземпляров
            in_date = idate; // дата возврата
        }

        public void Set(int BN, int x)
        {
            b_number = BN;
            ex = x;
        }

        public void Print(TextBox rn, TextBox bn, TextBox x, DateTimePicker o, DateTimePicker i)
        {
            rn.Text = r_number.ToString();
            bn.Text = b_number.ToString();
            x.Text = ex.ToString();

            o.Text = out_date.ToString();
            i.Text = in_date.ToString();
        }

        public TimeSpan Outdated()  // просрочка
        {
            return DateTime.Today.Subtract(in_date);
        }
    }
}
