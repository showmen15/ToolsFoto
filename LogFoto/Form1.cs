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

        private void button4_Click(object sender, EventArgs e)
        {
           // string sConnetionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\szsz\Dropbox\Tauron\Dane.xls; Extended Properties='Excel 8.0; HDR=NO'";

            string sConnetionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\szsz\Dropbox\Tauron\Dane.xls; Extended Properties=""Excel 12.0; IMEX=1; HDR=YES; TypeGuessRows=0; ImportMixedTypes=Text""";

           

           // string sConnetionString = @"provider = Microsoft.Jet.OLEDB.4.0; data source = C:\Users\szsz\Dropbox\Tauron\Dane2.xls;Extended Properties=""Excel 8.0; HDR = YES""";


            using (OleDbConnection conn = new OleDbConnection(sConnetionString))
            {
                conn.Open();


              //  System.Data.DataTable ExcelTables = new System.Data.DataTable();

              //  ExcelTables = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new Object[] { null, null, null, "TABLE" });


                using (OleDbCommand cmd = new OleDbCommand("", conn))
                {
                    cmd.CommandText = "SELECT * FROM  [Dane$]";


                   /* OleDbDataAdapter adp = new OleDbDataAdapter(cmd.CommandText, conn);

                    DataSet dsXLS = new DataSet();
                    adp.Fill(dsXLS);

                    DataView dvEmp = new DataView(dsXLS.Tables[0]);
                    dataGridView1.DataSource = dvEmp;
                    */

                     DataTable data = new DataTable();

                     data.Load(cmd.ExecuteReader());
                     
                    dataGridView1.DataSource = data;
                    

                   /* using (OleDbDataReader rdr = cmd.ExecuteReader())
                    {
                        while(rdr.Read())
                        {
                            object sst = rdr[1];

                            string ss = rdr["godzina"].ToString();
                            //string s1 = rdr["B"].ToString();

                        }

                    }
                    */

                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DateTime result =  ParseExact24h("2018-03-14 1");

            result = ParseExact24h("2018-03-24 24");

          /*  CultureInfo provider = CultureInfo.GetCultureInfo("en-US");
          //  Globalization.CultureInfo();

           // string form = "yyyy-MM-dd HH";

           // DateTime temp1 = DateTime.ParseExact("2018-03-14 24", form, provider);


            string[] format = new string[] { "yyyy-MM-dd h", "yyyy-MM-dd HH"};

        DateTime temp = DateTime.ParseExact("2018-03-14 1", format, provider,DateTimeStyles.None);
             temp = DateTime.ParseExact("2018-03-14 23", format, provider, DateTimeStyles.None);



    */
        }

        private DateTime ParseExact24h(string input)
        {
            string wrapped = Regex.Replace(input, @"\s{1}24", " 00");

            CultureInfo provider = CultureInfo.GetCultureInfo("en-US");
            string[] formats = new string[] { "yyyy-MM-dd h", "yyyy-MM-dd HH" };

            return DateTime.ParseExact(wrapped, formats, provider, DateTimeStyles.None);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Tauron.TauronLog log = new Tauron.TauronLog();
            var lista = log.GetTauronLogData(@"C:\Users\szsz\Dropbox\Tauron\Dane.xls");

        }

        private void button7_Click(object sender, EventArgs e)
        {
           // using (OpenFileDialog open = new OpenFileDialog())
            {
             //   if(open.ShowDialog(this) == DialogResult.OK)
                {
                    string sTauronLogFilePath = @"D:\Falownik\Tauron\Dane.xls"; //open.FileName; //@"D:\Falownik\Tauron\Dane.xls"

                    using (ProviderMsAccess prov = new ProviderMsAccess(@"C:\Users\Szymon\Documents\baza.accdb"))
                    {
                        Tauron.TauronLog log = new Tauron.TauronLog();
                        var lista = log.GetTauronLogData(sTauronLogFilePath);

                        prov.InsertTauronLog(lista);
                    }
                }
            }
        }
    }
}
