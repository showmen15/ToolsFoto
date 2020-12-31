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
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Security.Permissions;

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

        private void button4_Click(object sender, EventArgs e)
        {


            //FroniusSymoLog log = new FroniusSymoLog();
            //var tt = log.DailySumProduction(DateTime.Now.AddDays(-2));

            //string values = Properties.Resources.String1;

            //Value temp = new Value();
            //temp.n1 = 333;
            //temp.n2 = 33355;
            //temp.str = "dupa";


            //temp.Values.Add(new KeyValuePair<string, int>("3232", 333));
            //temp.Values.Add(new KeyValuePair<string, int>("3232", 333));



            //temp.Values = new Lookup<string, int>();

            //temp.Values.Add(new KeyValuePair<string, int>("22", 33));

            //temp.Values = new List<Tuple<string, int>>();
            //temp.Values.Add(new Tuple<string, int>("3232", 22));

            //temp.ValuesDic = new Dictionary<string, int>();
            //temp.ValuesDic.Add("3232", 44);
            ////temp.ValuesDic.Add("3232", 44);
            //temp.ValuesDic.Add("33", 44);

            //temp.End = DateTime.Now;
            //temp.Testowa = new KeyValuePair<string, double>("12121", 2323.44);


            Inverter inver = new Inverter();
            
            var jsonString = JsonConvert.SerializeObject(inver);

            jsonString = Properties.Resources.String1;

            var obj = JsonConvert.DeserializeObject<Inverter>(jsonString);
        }

        public class Inverter
        {
            public Value Values { get; set; }

            public Inverter()
            {
                Values = new Value();                
            }
        }

        [Serializable]
        public class Value : ISerializable
        {
            private List<KeyValuePair<string, double>> Values = new List<KeyValuePair<string, double>>();

            public Value()
            {
                Values.Add(new KeyValuePair<string, double>("-333", 33232));
                Values.Add(new KeyValuePair<string, double>("-22", 22));
                Values.Add(new KeyValuePair<string, double>("-33", 33));
            }

            protected Value(SerializationInfo info, StreamingContext context)
            {
                SerializationInfoEnumerator serializationInfo = info.GetEnumerator();

                while (serializationInfo.MoveNext())
                    Values.Add(new KeyValuePair<string, double>(serializationInfo.Current.Name, Convert.ToDouble(serializationInfo.Current.Value)));               
            }

            [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
            public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                foreach (var item in Values)
                    info.AddValue(item.Key, item.Value);
            }
        }

    }
}
