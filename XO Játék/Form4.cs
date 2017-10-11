using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XO_Játék
{
    public partial class Form4 : Form
    {
        private string utvonal = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public Form4()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            Image newImage = Image.FromFile(utvonal +"\\1.jpg");
            Point point = new Point(0,0);
            e.Graphics.DrawImage(newImage, point);
        }
    }
}
