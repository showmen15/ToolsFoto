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
            SunSpecData sun;// = new SunSpecData();

            using (StreamReader myReader = new StreamReader(@"C:\Users\szsz\Dropbox\Solar\WindowsFormsApplication3\sol\SunSpec20180611071240.txt", false))
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(SunSpecData));
                sun = (SunSpecData) mySerializer.Deserialize(myReader);
            }

            string ss = sun.Wh;

            /* SunSpecData sun = new SunSpecData();
            sun.v = "888";
            sun.deviceRecord.man = "test";
            sun.deviceRecord.mod = "r343";
            sun.deviceRecord.sn = "12456";
            sun.deviceRecord.t = "2018-06-08T10:25:50+02:00";
            */

            //sun.specData.moduls.Add(new Module());
            //sun.specData.moduls[0].ID = "1";

            //sun.specData.moduls.Add(new Module());
            // sun.specData.moduls[1].ID = "113";

            /* sun.specData.module1.ID = "1";
             sun.specData.module1.module.Add(new FroniusSymo.SunSpec.Properties { ID = "Mn", Value = "Fronius" });
             sun.specData.module1.module.Add(new FroniusSymo.SunSpec.Properties() { ID = "Md", Value = "Fronius Symo 3.7-3-M" });

             sun.specData.module113.ID = "113";
             sun.specData.module113.module.Add(new FroniusSymo.SunSpec.Properties { ID = "W", Value = "429.000000" });
             sun.specData.module113.module.Add(new FroniusSymo.SunSpec.Properties() { ID = "Md", Value = "Fronius Symo 3.7-3-M" });
             */

            // sun.specData.module113.Add(new FroniusSymo.SunSpec.Properties() { ID = "W", Value = "429.000000" });
            // sun.specData.module113.Add(new FroniusSymo.SunSpec.Properties() { ID = "Wh", Value = "1755508.000000" });

            /*    using (StreamWriter myWriter = new StreamWriter(".\\test.xml", false))
                {
                    XmlSerializer mySerializer = new XmlSerializer(typeof(SunSpecData));
                    mySerializer.Serialize(myWriter, sun);
                }*/
        }
    }
}
