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
    public partial class Form2 : Form
    {

        static int[,] matrix = new int[3,3];
        int jatekos = 1;
        int szam1 = 0, szam2 = 0;
        public string n1, n2;

        private string datum()
        {
            string ev, honap, nap, ora, perc, mperc, datum, nap2;

            ev = DateTime.Now.Year.ToString();

            honap = DateTime.Now.Month.ToString();

            switch (honap)
            {
                case "1": honap = "Január"; break;
                case "2": honap = "Február"; break;
                case "3": honap = "Március"; break;
                case "4": honap = "Április"; break;
                case "5": honap = "Május"; break;
                case "6": honap = "Június"; break;
                case "7": honap = "Július"; break;
                case "8": honap = "Augusztus"; break;
                case "9": honap = "Szeptember"; break;
                case "10": honap = "Október"; break;
                case "11": honap = "November"; break;
                case "12": honap = "December"; break;
            }

            nap = DateTime.Now.Day.ToString();
            ora = DateTime.Now.Hour.ToString();
            perc = DateTime.Now.Minute.ToString();
            mperc = DateTime.Now.Second.ToString();
            nap2 = DateTime.Now.DayOfWeek.ToString();

            switch (nap2)
            {
                case "Monday": nap2 = "Hétfő"; break;
                case "Tuesday": nap2 = "Kedd"; break;
                case "Wednesday": nap2 = "Szerda"; break;
                case "Thursday": nap2 = "Csütörtök"; break;
                case "Friday": nap2 = "Péntek"; break;
                case "Saturday": nap2 = "Szombat"; break;
                case "Sunday": nap2 = "Vasárnap"; break;
            }

            switch (perc)
            {
                case "1": perc = "01"; break;
                case "2": perc = "02"; break;
                case "3": perc = "03"; break;
                case "4": perc = "04"; break;
                case "5": perc = "05"; break;
                case "6": perc = "06"; break;
                case "7": perc = "07"; break;
                case "8": perc = "08"; break;
                case "9": perc = "09"; break;
            }

            switch (mperc)
            {
                case "1": mperc = "01"; break;
                case "2": mperc = "02"; break;
                case "3": mperc = "03"; break;
                case "4": mperc = "04"; break;
                case "5": mperc = "05"; break;
                case "6": mperc = "06"; break;
                case "7": mperc = "07"; break;
                case "8": mperc = "08"; break;
                case "9": mperc = "09"; break;
            }

            datum = (ev + "." + honap + "." + nap + " "+ nap2 + "  " + ora + ":" + perc + ":" + mperc);


            return datum;
        }

        Boolean ellenor1()
        {
            Boolean nyert = false;


            for (int i = 0; i < 3; i++) 
            {
                if ((matrix[i, 0] == matrix[i, 1]) && (matrix[i, 1] == matrix[i, 2]) && (matrix[i, 0] == 1)) nyert = true;
                if ((matrix[i, 0] == matrix[i, 1]) && (matrix[i, 1] == matrix[i, 2]) && (matrix[i, 0] == 1)) nyert = true;
            }

            for (int j = 0; j < 3; j++) 
            {
                if ((matrix[0, j] == matrix[1, j]) && (matrix[1, j] == matrix[2, j]) && (matrix[0, j] == 1)) nyert = true;
                if ((matrix[0, j] == matrix[1, j]) && (matrix[1, j] == matrix[2, j]) && (matrix[0, j] == 1)) nyert = true;
            }

            for (int l = 0; l < 3; l++)
                if ((matrix[0, 0] == matrix[1, 1]) && (matrix[1, 1] == matrix[2, 2]) && (matrix[0, 0] == 1)) nyert = true;

            for (int k = 0; k < 3; k++)
                if ((matrix[0, 2] == matrix[1, 1]) && (matrix[1, 1] == matrix[2, 0]) && (matrix[0, 2] == 1)) nyert = true;

            return nyert;
        }

        Boolean ellenor2()
        {
            Boolean nyert = false;


            for (int i = 0; i < 3; i++)
            {
                if ((matrix[i, 0] == matrix[i, 1]) && (matrix[i, 1] == matrix[i, 2]) && (matrix[i, 0] == 2)) nyert = true;
                if ((matrix[i, 0] == matrix[i, 1]) && (matrix[i, 1] == matrix[i, 2]) && (matrix[i, 0] == 2)) nyert = true;
            }
            for (int j = 0; j < 3; j++)
            {
                if ((matrix[0, j] == matrix[1, j]) && (matrix[1, j] == matrix[2, j]) && (matrix[0, j] == 2)) nyert = true;
                if ((matrix[0, j] == matrix[1, j]) && (matrix[1, j] == matrix[2, j]) && (matrix[0, j] == 2)) nyert = true;
            }

            for (int l = 0; l < 3; l++)
                if ((matrix[0, 0] == matrix[1, 1]) && (matrix[1, 1] == matrix[2, 2]) && (matrix[0, 0] == 2)) nyert = true;

            for (int k = 0; k < 3; k++)
                if ((matrix[0, 2] == matrix[1, 1]) && (matrix[1, 1] == matrix[2, 0]) && (matrix[0, 2] == 2)) nyert = true;

            return nyert;
        }

        Boolean ellenor3()
        {
            Boolean igaz = false;

            if (((matrix[0, 0] == 1) || (matrix[0, 0] == 2)) && ((matrix[0, 1] == 1) || (matrix[0, 1] == 2)) && ((matrix[0, 2] == 1) || (matrix[0, 2] == 2)) && ((matrix[1, 0] == 1) || (matrix[1, 0] == 2)) && ((matrix[1, 1] == 1) || (matrix[1, 1] == 2)) && ((matrix[1, 2] == 1) || (matrix[1, 2] == 2)) && ((matrix[2, 0] == 1) || (matrix[2, 0] == 2)) && ((matrix[2, 1] == 1) || (matrix[2, 1] == 2)) && ((matrix[2, 2] == 1) || (matrix[2, 2] == 2))) igaz = true;

            return igaz;
        }

        public Form2()
        {
            InitializeComponent();

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {


            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    e.Graphics.DrawRectangle(Pens.Black, 50 * i, 50 * j, 50, 50);
                    if (matrix[i, j] == 1) e.Graphics.FillEllipse(Brushes.Blue, i * 50, 50 * j, 50, 50);
                    if (matrix[i, j] == 2) e.Graphics.FillEllipse(Brushes.Red, i * 50, 50 * j, 50, 50);
                }

        }

        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }


        private void aJátékrólToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("A játék tervezője és programozója: Gencsi Mátyás (l2010c)\n                             Minden jog fentartva 2012!","Infó");
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {


            int sor = e.X/50;
            int oszlop = e.Y/50;
            

            if ((sor < 3) && (oszlop < 3))
                if (matrix[sor, oszlop] == 0)
                {
                    matrix[sor, oszlop] = jatekos;
                    if (jatekos == 1) jatekos = 2;
                    else jatekos = 1;
                    pictureBox1.Refresh();
                }

            if (ellenor1() == true)
            {
                szam1++;
                MessageBox.Show(n1 + " nyert!\nA nyertes kezdi a következő játékot!\nÁllás: |" + n1 + "  " + szam1 + "|  |" + n2 + "  " + szam2 + "|", "Üzenet");
                jatekos = 1;
                újJátékToolStripMenuItem_Click(sender, e);
            }
            

                if (ellenor2() == true)
                {
                    szam2++;
                    MessageBox.Show(n2 + " nyert!\nA nyertes kezdi a játékot!\nÁllás: |" + n1 + "  " + szam1 + "|  |" + n2 + "  " + szam2 + "|", "Üzenet");
                    jatekos = 2;
                    újJátékToolStripMenuItem_Click(sender, e);
                }

                if (ellenor3() == true)
                {
                    MessageBox.Show("A játék döntetlen lett! Az utóbbi nyertes kezdi a következő játékot!\nÁllás: |" + n1 + "  " + szam1 + "|  |" + n2 + "  " + szam2 + "|", "Üzenet");
                    újJátékToolStripMenuItem_Click(sender, e);
                }

            label3.Text = szam1.ToString();
            label5.Text = szam2.ToString();
 
        }

        private void újJátékToolStripMenuItem_Click(object sender, EventArgs e)
        {
             for (int i = 0; i < 3; i++)
                 for (int j = 0; j < 3; j++)
                 {
                     matrix[i, j] = 0;
                 }
             pictureBox1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result;

            result = MessageBox.Show("Biztos ki akarsz lépni?", "Kérdés", MessageBoxButtons.YesNo);

            if (result == DialogResult.No) return;
            if (result == DialogResult.Yes)
            {
                string nyertes;
                string utvonal = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                TextWriter tr = new StreamWriter(utvonal + "\\XO Játék Eredmények.txt", true);

                if (szam1 > szam2) nyertes = n1;
                else nyertes = n2;

                if (szam1 == szam2) nyertes = "A játék döntetlen lett";

                if ((nyertes == n1) || (nyertes == n2)) MessageBox.Show(nyertes + " a nyertes!\nJátszatok máskor is!\nAz eredményeket megtalálod a My Documents mappádban, az 'XO Játék Eredmények' elnevezésű txt fájlban!", "Üzenet");
                else MessageBox.Show(nyertes + "!" + "\nJátszatok máskor is!\nAz eredményeket megtalálod a My Documents mappádban, az 'XO Játék Eredmények' elnevezésű txt fájlban!", "Üzenet");

                tr.WriteLine(datum() + " Játékosok: " + n1 + " és " + n2 + " || Eredmény(nyertes vagy döntetlen): " + nyertes + "!");

                tr.Close();
                Close();
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void Form2_Activated(object sender, EventArgs e)
        {

        }

        private void Form2_Shown(object sender, EventArgs e)
        {
        }

        private void Form2_MouseHover(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = n1;
            label4.Text = n2;
        }

        private void eredményListaFeltöltéseFtpSzerverreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();

        }

        private void teljesenÚjJátékToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    matrix[i, j] = 0;
            label3.Text = "0";
            label5.Text = "0";
            szam1 = 0;
            szam2 = 0;
            pictureBox1.Refresh();
        }
    }
}
