using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba5.Classes
{
    class Library
    {
        public string name;
        Address lib_adr;
        int phone;

        List<Book> books = new List<Book>();
        List<Reader> readers = new List<Reader>();
        List<Issue> issues = new List<Issue>();

        public Library()
        {
            lib_adr = new Address();
            name = "noname";
            phone = 0;
        }
        public Library(string n, Address adr, int ph)
        {
            name = n;
            lib_adr = adr;
            phone = ph;
        }
        public Library(Library l)
        {
            name = l.name;
            lib_adr = l.lib_adr;
            phone = l.phone;

            books = new List<Book>(l.books);
            readers = new List<Reader>(l.readers);
            issues = new List<Issue>(l.issues);
        }

        public void add_book(string name, string author, int year, int price, int ou, int quantity, int number)
        {
            books.Add(new Book(number, year, price, quantity, ou, name, author));
        }
        public void add_book(Book b)
        {
            books.Add(b);
        }
        public Book search_book(int number)
        {
            return books.Find(delegate (Book b) { return b.number == number; });
        }
        public Book search_book(Book b)
        {
            return books.Find(delegate (Book b1) { return b == b1; });
        }
        public void delete_book(int number)
        {
            books.RemoveAll(delegate (Book b) { return b.number == number; });
        }

        public void add_reader(int num, string name, Address adr, int phone)
        {
            readers.Add(new Reader(num, adr, phone, name));
        }
        public void add_reader(Reader r)
        {
            readers.Add(r);
        }
        public Reader search_reader(int number)
        {
            return readers.Find(delegate (Reader b) { return b.number == number; });
        }
        public void delete_reader(int number)
        {
            readers.RemoveAll(delegate (Reader r) { return r.number == number; });
        }

        //public void add_issue(int number, int num, int ex)
        //{
        //    issues.Add(new Issue(number, num, DateTime.Today, ex, DateTime.Today.AddDays(90)));  
        //}
        public void add_issue(int number, int num, int ex, DateTimePicker idate)
        {

            string date1 = idate.Value.ToString("dd.MM.yyyy");
            issues.Add(new Issue(number, num, DateTime.Today, ex, Convert.ToDateTime(date1)));
            search_reader(number).exem += ex;
            search_reader(number).BN = num;

        }
        public void add_issue(Issue iss)
        {
            issues.Add(iss);

        }
        public Issue search_issue(int number)
        {
            return issues.Find(delegate (Issue b) { return b.r_number == number; });
        }
        public void change_issue(int number, int num, int ex)
        {
            Issue i = issues.Find(delegate (Issue iss) { return iss.r_number == number; });
            i.Set(num, ex);
        }
        public void delete_issue(int num)
        {
            issues.RemoveAll(delegate (Issue i) { return i.r_number == num; });
        }

        public void printBooks(int number, TextBox _number, TextBox _name, TextBox _author, TextBox _year, TextBox _price,
            TextBox _quantity, TextBox _inuse)
        {
            Book b = search_book(number);
            b.Print(_number, _name, _author, _year, _price,
             _quantity, _inuse);
        }
        public void printIssues(int number, TextBox rn, TextBox bn, TextBox x, DateTimePicker o, DateTimePicker i)
        {
            Issue iss = search_issue(number);
            if (iss != null)
                iss.Print(rn, bn, x, o, i);
        }
        public void printReaders(int number, TextBox b, TextBox s, TextBox h, TextBox a, TextBox num, TextBox nam, TextBox ph)
        {
            Reader r = search_reader(number);
            r.Print(b, s, h, a, num, nam, ph);
        }

        public void fill(ComboBox CBook, ComboBox CRead, ComboBox CIssue)
        {
            CBook.Items.Clear();
            foreach (Book s in books)
                CBook.Items.Add(s.number.ToString());

            if (books.Count != 0)
                CBook.SelectedItem = CBook.Items[0];

            CRead.Items.Clear();
            foreach (Reader s in readers)
                CRead.Items.Add(s.number.ToString());

            if (readers.Count != 0)
                CRead.SelectedItem = CRead.Items[0];

            CIssue.Items.Clear();
            foreach (Issue s in issues)
                CIssue.Items.Add(s.r_number.ToString());

            if (issues.Count != 0)
                CIssue.SelectedItem = CIssue.Items[0];
        }

        public void Print(TextBox _name, TextBox _phone, TextBox c, TextBox s, TextBox h, TextBox a)
        {
            _name.Text = name;
            _phone.Text = phone.ToString();
            lib_adr.Print(c, s, h, a);
        }

        public void dolzhn(RichTextBox rt)
        {
            rt.Clear();
            foreach (Issue iss in issues)
                if (iss.Outdated() > TimeSpan.Zero)
                {
                    foreach (Reader r in readers)
                        if (r.number == iss.r_number)
                            rt.AppendText(r.Name + "   Долг: " + iss.Outdated().Days * iss.ex + " рублей. \n"); // возможно с минусом iss.Outdated().Days
                }
                else
                    rt.AppendText("Нет должников \n");
        }

        public void Miss(int num, RichTextBox rt1)
        {

            //delete_book(search_book(search_issue(num).BookN).number);
            if (issues != null && search_issue(num) != null && search_reader(num) != null && readers != null)
            {
                rt1.Clear();
                search_reader(num).paid += search_book(search_issue(num).BookN).price * search_issue(num).ex;
                delete_issue(num);
                rt1.AppendText(search_reader(num).Name + "   Долг: " + search_reader(num).paid + " рублей. \n");
            }

        }
        public void Ret(int num, RichTextBox rt1)
        {
            if (books != null && search_book(search_reader(num).BN) != null && search_reader(num) != null && readers != null)
            {
                rt1.Clear();
                search_reader(num).paid = 0;
                search_book(search_reader(num).BN).inuse -= search_reader(num).exem;
                search_book(search_reader(num).BN).quantity += search_reader(num).exem;
                search_reader(num).exem = 0;
                //delete_issue(num);
            }
        }

        public Library Merge(Library lib)
        {
            Library l = new Library("Merged", new Address(), 777);

            foreach (Book b in books)
                l.add_book(b);
            foreach (Book b in lib.books)
                l.add_book(b);

            foreach (Issue b in issues)
                l.add_issue(b);
            foreach (Issue b in lib.issues)
                l.add_issue(b);

            foreach (Reader b in readers)
                l.add_reader(b);
            foreach (Reader b in lib.readers)
                l.add_reader(b);

            return l;
        }

    }
}

