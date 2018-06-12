using FroniusSymo;
using FroniusSymo.SunSpec;
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

using System;
using System.Data;
using System.Data.OleDb;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;

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

        private void button2_Click(object sender, EventArgs e)
        {
            string sDirectoryPath = @"D:\Falownik\Inputs\";

            using (ProviderMsAccess prov = new ProviderMsAccess(@"C:\Users\Szymon\Documents\baza.accdb"))
            {
                FroniusSymoLog log = new FroniusSymoLog();

                var temp = log.GetSunSpecData(sDirectoryPath);

                prov.InsertSunSpecData(temp);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sDirectoryPath = @"D:\Falownik\Inputs\";

            using (ProviderMsAccess prov = new ProviderMsAccess(@"C:\Users\Szymon\Documents\baza.accdb"))
            {
                FroniusSymoLog log = new FroniusSymoLog();

                var temp = log.GetProduction(sDirectoryPath);

                prov.InsertProduction(temp);
            }
        }
    }
}
