using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Xml;
using System.Security.Principal;
using System.Security.Permissions;
using System.Runtime.InteropServices;

namespace XO_Játék
{
    public partial class Form3 : Form
    {
        string utvonal = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string felhasznalo = "", jelszo = "", cim = "";

        public Form3()
        {
            InitializeComponent();
        }

        public void FTP()
        {
            FtpWebRequest request;

            felhasznalo = textBox2.Text;
            jelszo = textBox3.Text;
            cim = textBox1.Text;

            if (felhasznalo == "") MessageBox.Show("Nem adta meg a felhasználónevet!", "Üzenet");
            if (cim == "") MessageBox.Show("Nem adta meg az FTP szerver címét!", "Üzenet");
            if (jelszo == "") MessageBox.Show("Nem adta meg a jelszavat!", "Üzenet");
            
            if ((felhasznalo != "")&&(cim != "")&&(jelszo != ""))
            {
                try
                {
                     request = (FtpWebRequest)FtpWebRequest.Create(cim);
                     request.Method = WebRequestMethods.Ftp.AppendFile;
                     request.Credentials = new NetworkCredential(felhasznalo, jelszo);
                     request.UsePassive = true;
                     request.UseBinary = true;
                     request.KeepAlive = false;

                     //FTP file upload

                     FileStream stream = File.OpenRead(utvonal + "\\XO Játék Eredmények.txt");
                     byte[] buffer = new byte[stream.Length];

                     stream.Read(buffer, 0, buffer.Length);
                     stream.Close();

                     Stream reqStream = request.GetRequestStream();
                     reqStream.Write(buffer, 0, buffer.Length);
                     reqStream.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Hibásan adott meg valamit!","Üzenet");
                    return;
                }


                MessageBox.Show("Az Eredménylista sikeresen fel lett töltve a megadott FTP szerverre", "Üzenet");
                Close();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
             DialogResult result;

            result = MessageBox.Show("Biztos vissza akarsz lépni?", "Kérdés", MessageBoxButtons.YesNo);

            if (result == DialogResult.No) return;
            if (result == DialogResult.Yes) Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FTP();
            
        }
    }
}
