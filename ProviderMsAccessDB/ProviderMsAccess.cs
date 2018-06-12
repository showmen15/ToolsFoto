using FroniusSymo.Production2;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderMsAccessDB
{
    public class ProviderMsAccess: IDisposable
    {
        private ConnectionString connection;

        public ProviderMsAccess(string dbLocation)
        {
            connection = new ConnectionString(dbLocation);
        }

        public void Dispose() {}

        public void InsertProduction2(IEnumerable<Production2> data)
        {
            using (Database db = new Database(connection))
            {
                db.cmd.CommandText = "INSERT INTO Production2(InsertTimeStamp,E_Day,E_Year,E_Total) VALUES(@InsertTimeStamp, @E_Day, @E_Year, @E_Total)";

                db.cmd.Parameters.Add("@InsertTimeStamp", OleDbType.Date);
                db.cmd.Parameters.AddWithValue("@E_Day", OleDbType.Double);
                db.cmd.Parameters.AddWithValue("@E_Year", OleDbType.Double);
                db.cmd.Parameters.AddWithValue("@E_Total", OleDbType.Double);

                foreach (var item in data)
                {
                    db.cmd.Parameters["@InsertTimeStamp"].Value = item.timestamp.Value;
                    db.cmd.Parameters["@E_Day"].Value = item.E_Day;
                    db.cmd.Parameters["@E_Year"].Value = item.E_Year;
                    db.cmd.Parameters["@E_Total"].Value = item.E_Total;

                    db.cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
