using FroniusSymo;
using ProviderMsAccessDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogFoto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sDirectoryPath = @"D:\Falownik\Inputs\";


            using (ProviderMsAccess prov = new ProviderMsAccess(@"C:\Users\Szymon\Documents\baza.accdb"))
            {
                FroniusSymoLog log = new FroniusSymoLog();

                var temp = log.GetProduction2(sDirectoryPath);

                prov.InsertProduction2(temp);
            }            
        }
    }
}
