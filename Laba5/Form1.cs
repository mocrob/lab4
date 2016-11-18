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
            CurLib.add_book("Wtar Sars", "J.J. Ab", 2017, 200, 0, 1, 1);

            NewLib = new Library("New library", new Address("Nsk", "Nim-Dan", 70, 5), 386784);
            NewLib.add_book("Kolobok", "Narodnaya", 1854, 300, 0, 1, 2);
            libraries.Add(CurLib);
            libraries.Add(NewLib);
            // Заполнить ещё библиотеки


            RefillCombo();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurLib = libraries.Find(delegate (Library s)
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
                CurLib.printBooks(Convert.ToInt32(CBook.SelectedItem.ToString()), textBox7, b1, b2, b3, b4, b5, b6);
            }

            if (CIssue.Items.Count != 0)
            {
                CIssue.SelectedIndex = 0;
                CurLib.printIssues(Convert.ToInt32(CIssue.SelectedItem.ToString()), textBox10, textBox9, textBox11, dateTimePicker2, dateTimePicker3);

            }
            if (CRead.Items.Count != 0)
            {
                CRead.SelectedIndex = 0;
                CurLib.printReaders(Convert.ToInt32(CRead.SelectedItem.ToString()), r4, r5, r6, r7, r1, r2, r3);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (b1.Text != "" && b2.Text != "" && b3.Text != "" && b4.Text != "" && b5.Text != "" && b6.Text != "" && textBox7.Text != "" && CurLib.search_book(Convert.ToInt32(textBox7.Text)) == null)
            {

                CurLib.add_book(b1.Text, b2.Text, Convert.ToInt32(b3.Text), Convert.ToInt32(b4.Text),
                Convert.ToInt32(b6.Text), Convert.ToInt32(b5.Text), Convert.ToInt32(textBox7.Text));
                CurLib.fill(CBook, CRead, CIssue);
                CBook.SelectedItem = b1.Text;

                DelB.Enabled = true;


            }
            else
            {
                MessageBox.Show("Ошибка добавлении книги", "ОШИБКА", MessageBoxButtons.OK);
            }

        }

        private void CSales_SelectedIndexChanged(object sender, EventArgs e)
        {

            CurLib.printIssues(Convert.ToInt32(CIssue.SelectedItem.ToString()), textBox10, textBox9, textBox11, dateTimePicker2, dateTimePicker3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {

                if (comboBox1.FindString(textBox1.Text) == -1)
                {

                    libraries.Add(new Library(
                    textBox1.Text,
                    new Address(textBox3.Text, textBox4.Text, Convert.ToInt32(textBox6.Text),
                        Convert.ToInt32(textBox5.Text)), Convert.ToInt32(textBox2.Text)));
                    comboBox1.Items.Add(textBox1.Text);
                    comboBox1.SelectedItem = textBox1.Text;

                    ChLib.Enabled = true;
                    delLib.Enabled = true;

                }
                else
                {
                    MessageBox.Show("Библиотека с таким названием уже существует", "ОШИБКА", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все данные о библиотеке", "ОШИБКА", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox10.Text != "" && textBox11.Text != "" && textBox9.Text != "" && CurLib.search_issue(Convert.ToInt32(textBox10.Text)) == null && CurLib.search_reader(Convert.ToInt32(textBox10.Text)) != null && CurLib.search_book(Convert.ToInt32(textBox9.Text)) != null && Convert.ToInt32(textBox11.Text) <= CurLib.search_book(Convert.ToInt32(textBox9.Text)).quantity)
            {

                CurLib.add_issue(Convert.ToInt32(textBox10.Text), Convert.ToInt32(textBox9.Text), Convert.ToInt32(textBox11.Text), dateTimePicker3);

                CIssue.Items.Add(textBox10.Text);
                CIssue.SelectedItem = textBox10.Text;

                Book star = CurLib.search_book(Convert.ToInt32(textBox9.Text));
                star.quantity -= Convert.ToInt32(textBox11.Text);
                star.inuse += Convert.ToInt32(textBox11.Text);

                OkI.Enabled = true;
                DelI.Enabled = true;


            }
            else
            {
                MessageBox.Show("Ошибка добавления выдачи", "ОШИБКА", MessageBoxButtons.OK);
            }
        }

        private void CCash_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurLib.printBooks(Convert.ToInt32(CBook.SelectedItem.ToString()), textBox7, b1, b2, b3, b4, b5, b6);//123456

        }

        private void CShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurLib.printReaders(Convert.ToInt32(CRead.SelectedItem.ToString()), r4, r5, r6, r7, r1, r2, r3); //4567123

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (r1.Text != "" && r2.Text != "" && r3.Text != "" && r4.Text != "" && r5.Text != "" && r6.Text != "" && r7.Text != "" && CurLib.search_reader(Convert.ToInt32(r1.Text)) == null)
            {

                CurLib.add_reader(Convert.ToInt32(r1.Text), r2.Text, new Address(r4.Text, r5.Text, Convert.ToInt32(r7.Text), Convert.ToInt32(r6.Text)), Convert.ToInt32(r3.Text));
                CRead.Items.Add(r1.Text);
                CRead.SelectedItem = r1.Text;

                DelR.Enabled = true;


            }
            else
            {
                MessageBox.Show("Ошибка добавления читателя", "ОШИБКА", MessageBoxButtons.OK);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                libraries.Remove(CurLib);
                CurLib = new Library(
                    textBox1.Text,
                    new Address(textBox3.Text, textBox4.Text, Convert.ToInt32(textBox6.Text),
                        Convert.ToInt32(textBox5.Text)), Convert.ToInt32(textBox2.Text));

                libraries.Add(CurLib);
                RefillCombo();
                comboBox1.SelectedItem = textBox1.Text;
            }
            else
            {
                MessageBox.Show("Невозможно изменить данные о библиотеке", "ОШИБКА", MessageBoxButtons.OK);
            }
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
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                if (libraries.Count != 0)
                    libraries.Remove(CurLib);
                RefillCombo();
                if (libraries.Count != 0)
                    comboBox1.SelectedItem = comboBox1.Items[0];
                else
                {
                    ChLib.Enabled = false;
                    delLib.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Невозможно удалить библиотеку", "ОШИБКА", MessageBoxButtons.OK);
            }
        }

        private void DelCash_Click(object sender, EventArgs e)
        {
            if (b1.Text != "" && b2.Text != "" && b3.Text != "" && b4.Text != "" && b5.Text != "" && b6.Text != "" && textBox7.Text != "")
            {
                CurLib.delete_book(Convert.ToInt32(CBook.SelectedItem.ToString()));
                CurLib.fill(CBook, CRead, CIssue);
                if (CBook.Items.Count != 0)
                    CBook.SelectedItem = CBook.Items[0];
                else
                {
                    DelB.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Невозможно удалить книгу", "ОШИБКА", MessageBoxButtons.OK);
            }
        }


        private void DelSh_Click(object sender, EventArgs e)
        {
            if (r1.Text != "" && r2.Text != "" && r3.Text != "" && r4.Text != "" && r5.Text != "" && r6.Text != "" && r7.Text != "")
            {
                CurLib.delete_reader(Convert.ToInt32(CRead.SelectedItem.ToString()));
                CurLib.fill(CBook, CRead, CIssue);
                if (CRead.Items.Count != 0)
                    CRead.SelectedItem = CRead.Items[0];
                else
                {
                    DelR.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Невозможно удалить читателя", "ОШИБКА", MessageBoxButtons.OK);
            }
        }

        private void DelSal_Click(object sender, EventArgs e)
        {
            if (textBox10.Text != "" && textBox11.Text != "" && textBox9.Text != "")
            {
                CurLib.delete_issue(Convert.ToInt32(CIssue.SelectedItem.ToString()));
                CurLib.fill(CBook, CRead, CIssue);

                Book star = CurLib.search_book(Convert.ToInt32(textBox9.Text));
                star.quantity += Convert.ToInt32(textBox11.Text);
                star.inuse -= Convert.ToInt32(textBox11.Text);

                if (CIssue.Items.Count != 0)
                    CIssue.SelectedItem = CIssue.Items[0];
                else
                {
                    OkI.Enabled = false;
                    DelI.Enabled = false;
                }

            }
            else
            {
                MessageBox.Show("Невозможно удалить выдачу", "ОШИБКА", MessageBoxButtons.OK);
            }
        }

        private void OkSal_Click(object sender, EventArgs e)
        {
            if (textBox10.Text != "" && textBox11.Text != "" && textBox9.Text != "")
            {

                CurLib.search_issue(Convert.ToInt32(textBox10.Text)).Set(Convert.ToInt32(textBox9.Text), Convert.ToInt32(textBox11.Text));
                CurLib.fill(CBook, CRead, CIssue);
                CIssue.SelectedItem = textBox9.Text;
            }
            else
            {
                MessageBox.Show("Невозможно изменить выдачу", "ОШИБКА", MessageBoxButtons.OK);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CurLib.dolzhn(richTextBox1);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (r1.Text != "")
            {
                CurLib.Miss(Convert.ToInt32(r1.Text), richTextBox2);
                CurLib.fill(CBook, CRead, CIssue);
                if (CIssue.Items.Count != 0)
                    CIssue.SelectedItem = CIssue.Items[0];
                else
                {
                    OkI.Enabled = false;
                    DelI.Enabled = false;
                }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (r1.Text != "")
            {
                CurLib.Ret(Convert.ToInt32(r1.Text), richTextBox2);
                CurLib.fill(CBook, CRead, CIssue);
                if (CIssue.Items.Count != 0)
                    CIssue.SelectedItem = CIssue.Items[0];
                else
                {
                    OkI.Enabled = false;
                    DelI.Enabled = false;
                }
            }
        }

        private void Panic_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Лень настигла тебя", "АГААААА", MessageBoxButtons.OK);
            r1.Text = "9";
            r2.Text = "имя";
            r3.Text = "1234567";
            r4.Text = "город";
            r5.Text = "улица";
            r6.Text = "12";
            r7.Text = "123";
            textBox10.Text = "9";
            textBox9.Text = "1";
            textBox11.Text = "1";

        }

        private void num_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8) //Если символ, введенный с клавы - не цифра (IsDigit), 
            {
                e.Handled = true;// то событие не обрабатывается. ch!=8 (8 - это Backspace) 
            }
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count == 2)
            {
                libraries.Add(NewLib.Merge(libraries.Find(delegate (Library s)
                { return s.name == (comboBox1.Items[0].ToString()); })));
                RefillCombo();
            }
            else
            {
                MessageBox.Show("Неверное количество библиотек", "ОШИБКА", MessageBoxButtons.OK);
            }

        }


    }

}
