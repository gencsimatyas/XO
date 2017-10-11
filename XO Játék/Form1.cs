using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace XO_Játék
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result;

            result = MessageBox.Show("Biztos ki akarsz lépni?", "Kérdés", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;
            if (result == DialogResult.Yes) Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if ((textBox1.Text == "") || (textBox2.Text == ""))
            {
                if ((textBox1.Text == "") && (textBox2.Text != "")) MessageBox.Show("Nem töltötte ki az első mezőt, egy játékos nevével!", "Hiba!");
                if ((textBox1.Text != "") && (textBox2.Text == "")) MessageBox.Show("Nem töltötte ki a második mezőt, egy játékos nevével!", "Hiba!");
                if ((textBox1.Text == "") && (textBox2.Text == "")) MessageBox.Show("Nem töltötte ki egyik mezőt sem, játékos névvel!", "Hiba!");
            }
            else
            {

                Form2 f2 = new Form2();
                f2.n1 = textBox1.Text;
                f2.n2 = textBox2.Text;
                MessageBox.Show(textBox1.Text + " játszik a kék ponttal!\n" + textBox2.Text + " játszik a piros ponttal!" + "\nJó Játékot kívánok " + textBox1.Text + " és " + textBox2.Text + "!" , "Üzenet!");
                Hide();
                f2.ShowDialog();
                Close();
                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
