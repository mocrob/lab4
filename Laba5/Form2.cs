using Laba5.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba5
{
    public partial class Form2 : Form
    {
        List<Library> libraries = new List<Library>();
        CSt<Library> libStack;

        Library CurLib;
        Library StLib;
        Library newl;
        Library NewLib;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            CurLib = new Library();
            NewLib = new Library("Im.Lenina", new Address("Novosib", "Lenina", 2, 1), 228);
            CurLib.add_book("Wtar Sars", "J.J. Ab", 2015, 200, 1, 1);

            libraries.Add(CurLib);
            libraries.Add(NewLib);
            CurLib.add_reader("Oleg", new Address("lsk", "Lenina", 3, 1), 245);


            libStack = new CSt<Library>(CurLib);




            RefillCombo();
        }



        void RefillCombo()
        {
            comboBox1.Items.Clear();
            foreach (Library st in libraries)
            {
                comboBox1.Items.Add(st.name);
            }

        }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CurLib = libraries.Find(delegate (Library s)
            { return s.name == ((ComboBox)sender).SelectedItem.ToString(); });

            CurLib.Print(textBox1, textBox2, textBox3, textBox4);

            panel1.Enabled = true;
            if (panel2.Enabled)
            {
                button3.Enabled = true;
                button2.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            newl = CurLib + StLib;
            newl.Print(textBox18, textBox10, textBox9, textBox8);
            panel3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            newl = CurLib - StLib;
            newl.Print(textBox18, textBox10, textBox9, textBox8);
            panel3.Enabled = true;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            StLib = libStack.pop();
            if (StLib != null)
            {
                StLib.Print(textBox12, textBox7, textBox6, textBox5);
                panel2.Enabled = true;
                if (panel1.Enabled)
                {
                    button3.Enabled = true;
                    button2.Enabled = true;
                }
            }

            else
            {
                panel2.Enabled = false;
                button3.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            libraries.Add(new Library(
                textBox1.Text,
                new Address(textBox3.Text, textBox4.Text, Convert.ToInt16(textBox5.Text),
                    Convert.ToInt16(textBox6.Text)), Convert.ToInt16(textBox2.Text)));
            comboBox1.Items.Add(textBox1.Text);
            comboBox1.SelectedItem = textBox1.Text;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Save sv = new Save();
            sv.SaveItem("test", libStack);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Save sv = new Save();
            libStack = sv.LoadItem("test");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            libStack = libStack.push(newl);
        }
    }
}
