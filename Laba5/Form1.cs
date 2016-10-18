using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Laba5.Classes;

namespace StorP
{
    public partial class Form1 : Form
    {
        List<Library> libraries = new List<Library>();
        Library CurLib, NewLib;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            CurLib = new Library();
            CurLib.add_book("J.J. Ab", "Wtar Sars", 2015, 200,0 ,1, 1);

            NewLib = new Library("New library", new Address("Nsk", "Nim-Dan", 70, 5), 386784);
            NewLib.add_book("Narodnaya", "Kolobok", 1854, 300, 0, 1, 2);
            libraries.Add(CurLib);
            libraries.Add(NewLib);
            // Заполнить ещё библиотеки

          
            RefillCombo();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurLib = libraries.Find(delegate(Library s)
            { return s.name == ((ComboBox)sender).SelectedItem.ToString(); });
            panel1.Enabled = true;
            panel2.Enabled = true;
            panel3.Enabled = true;
            panel6.Enabled = true;
            CurLib.fill(CBook, CRead, CIssue);


            CurLib.Print(textBox1, textBox2, textBox3, textBox4, textBox5, textBox6);

            if (CBook.Items.Count != 0)
            {
                CBook.SelectedIndex = 0;
                CurLib.printBooks(Convert.ToInt16(CBook.SelectedItem.ToString()), textBox7, b1, b2, b3, b4, b5, b6);            
            }

            if (CIssue.Items.Count != 0)
            {
                CIssue.SelectedIndex = 0;
                CurLib.printIssues(Convert.ToInt16(CIssue.SelectedItem.ToString()), textBox10, textBox9, textBox11, dateTimePicker2, dateTimePicker3);
            }
            if (CRead.Items.Count != 0)
            {
                CRead.SelectedIndex = 0;
                CurLib.printReaders(Convert.ToInt16(CRead.SelectedItem.ToString()), r1, r2, r3, r4, r5, r6, r7);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

            CurLib.add_book(b1.Text, b2.Text, Convert.ToInt16(b3.Text), Convert.ToInt16(b4.Text),
                Convert.ToInt16(b5.Text), Convert.ToInt16(b6.Text), Convert.ToInt16(textBox7.Text));
            CurLib.fill(CBook, CRead, CIssue);
            CBook.SelectedItem = b1.Text;


            DelB.Enabled = true;
        }

        private void CSales_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurLib.printIssues(Convert.ToInt16(CIssue.SelectedItem.ToString()), textBox10, textBox9, textBox11, dateTimePicker2, dateTimePicker3);
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            libraries.Add(new Library(
                textBox1.Text,
                new Address(textBox3.Text, textBox4.Text, Convert.ToInt16(textBox5.Text),
                    Convert.ToInt16(textBox6.Text)), Convert.ToInt16(textBox2.Text)));
            comboBox1.Items.Add(textBox1.Text);
            comboBox1.SelectedItem = textBox1.Text;

            ChLib.Enabled = true;
            delLib.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CurLib.add_issue(Convert.ToInt16(textBox10.Text), Convert.ToInt16(textBox9.Text), Convert.ToInt16(textBox11.Text));

            CIssue.SelectedItem = textBox9.Text;
            CIssue.Items.Add(textBox9.Text);
            

            OkI.Enabled = true;
            DelI.Enabled = true;
        }

        private void CCash_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurLib.printBooks(Convert.ToInt16(CBook.SelectedItem.ToString()), textBox7, b1, b2, b3, b4, b5, b6);
           
        }

        private void CShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurLib.printReaders(Convert.ToInt16(CRead.SelectedItem.ToString()), r4, r5, r7, r6, r1, r2, r3);//1-7//4567123
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CurLib.add_reader(Convert.ToInt16(r1.Text), r2.Text, new Address(r4.Text, r5.Text, Convert.ToInt16(r6.Text), Convert.ToInt16(r7.Text)), Convert.ToInt16(r3.Text));
            CRead.Items.Add(r1.Text);
            CRead.SelectedItem = r1.Text;

            DelR.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            libraries.Remove(CurLib);
            CurLib = new Library(
                textBox1.Text,
                new Address(textBox3.Text, textBox4.Text, Convert.ToInt16(textBox5.Text),
                    Convert.ToInt16(textBox6.Text)), Convert.ToInt16(textBox2.Text));

            libraries.Add(CurLib);
            RefillCombo();
            comboBox1.SelectedItem = textBox1.Text;
        }

        void RefillCombo()
        {
            comboBox1.Items.Clear();
            foreach (Library st in libraries)
            {
                comboBox1.Items.Add(st.name);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (libraries.Count != 0)
            libraries.Remove(CurLib);
            RefillCombo();
            if (libraries.Count != 0)
                comboBox1.SelectedItem = comboBox1.Items[0];
            else {
                ChLib.Enabled = false;
                delLib.Enabled = false;
            }
        }

        private void DelCash_Click(object sender, EventArgs e)
        {
            CurLib.delete_book(Convert.ToInt16(CBook.SelectedItem.ToString()));
            CurLib.fill(CBook, CRead, CIssue);
            if (CBook.Items.Count != 0)
                CBook.SelectedItem = CBook.Items[0];
            else
            {
                DelB.Enabled = false;
            }
        }


        private void DelSh_Click(object sender, EventArgs e)
        {
            CurLib.delete_reader(Convert.ToInt16(CRead.SelectedItem.ToString()));
            CurLib.fill(CBook, CRead, CIssue);
            if (CRead.Items.Count != 0)
                CRead.SelectedItem = CRead.Items[0];
            else
            {
                DelR.Enabled = false;
            }
        }

        private void DelSal_Click(object sender, EventArgs e)
        {
            CurLib.delete_issue(Convert.ToInt16(CIssue.SelectedItem.ToString()));
            CurLib.fill(CBook, CRead, CIssue);
            if (CIssue.Items.Count != 0)
                CIssue.SelectedItem = CIssue.Items[0];
            else
            {
                OkI.Enabled = false;
                DelI.Enabled = false;
            }
        }

        private void OkSal_Click(object sender, EventArgs e)
        {
            CurLib.search_issue(Convert.ToInt16(textBox10.Text)).Set(Convert.ToInt16(textBox9.Text),Convert.ToInt16(textBox11.Text));
            CurLib.fill(CBook, CRead, CIssue);
            CIssue.SelectedItem = textBox9.Text;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CurLib.dolzhn(richTextBox1);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            CurLib.Miss(Convert.ToInt16(r1.Text));
            CurLib.fill(CBook, CRead, CIssue);
            if (CIssue.Items.Count != 0)
                CIssue.SelectedItem = CIssue.Items[0];
            else
            {
                OkI.Enabled = false;
                DelI.Enabled = false;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            libraries.Add(NewLib.Merge(libraries.Find(delegate(Library s)
            { return s.name == (comboBox1.Items[0].ToString());})));
            RefillCombo();
        }


    }

}
