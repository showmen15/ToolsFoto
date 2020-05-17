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
using System.Globalization;
using System.Text.RegularExpressions;

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
            //string sDirectoryPath = @"G:\Fotowoltaika\";

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
            //string sDirectoryPath = @"G:\Fotowoltaika\";

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
            //string sDirectoryPath = @"G:\Fotowoltaika\";

            using (ProviderMsAccess prov = new ProviderMsAccess(@"C:\Users\Szymon\Documents\baza.accdb"))
            {
                FroniusSymoLog log = new FroniusSymoLog();

                var temp = log.GetProduction(sDirectoryPath);

                prov.InsertProduction(temp);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog())
            {
                if(open.ShowDialog(this) == DialogResult.OK)
                {
                    string sTauronLogFilePath = open.FileName; //@"D:\Falownik\Tauron\Dane.xls"

                    using (ProviderMsAccess prov = new ProviderMsAccess(@"C:\Users\Szymon\Documents\baza.accdb"))
                    {
                        Tauron.TauronLog log = new Tauron.TauronLog();
                        var lista = log.GetTauronLogData(sTauronLogFilePath);

                        prov.InsertTauronLog(lista);
                    }
                }
            }

            MessageBox.Show(this, "Import zakończone!!", "Import Tauron", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            using (ProviderMsAccess prov = new ProviderMsAccess(@"C:\Users\Szymon\Documents\baza.accdb"))
            {
                FroniusSymoLog log = new FroniusSymoLog();

                DateTime beginDate = prov.GetFroniusProductionBeginDate();

                for (beginDate = beginDate.AddDays(1); beginDate < DateTime.Now.Date; beginDate = beginDate.AddDays(1))
                {
                    double dailyProduction = log.DailySumProduction(beginDate);
                    prov.DailySumProduction(beginDate, dailyProduction);
                }
            }

            MessageBox.Show(this, "Pobranie zakończone!!", "Komunikacja falowanik", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
