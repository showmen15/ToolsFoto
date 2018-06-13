using FroniusSymo.Production2;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FroniusSymo.SunSpec;
using FroniusSymo.Production;
using Tauron;

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
                db.cmd.CommandText = "INSERT INTO Production2(InsertTimeStamp,InsertDate,E_Day,E_Year,E_Total) VALUES(@InsertTimeStamp, @InsertDate, @E_Day, @E_Year, @E_Total)";

                db.cmd.Parameters.Add("@InsertTimeStamp", OleDbType.Date);
                db.cmd.Parameters.Add("@InsertDate", OleDbType.Date);
                db.cmd.Parameters.AddWithValue("@E_Day", OleDbType.Double);
                db.cmd.Parameters.AddWithValue("@E_Year", OleDbType.Double);
                db.cmd.Parameters.AddWithValue("@E_Total", OleDbType.Double);

                foreach (var item in data)
                {
                    db.cmd.Parameters["@InsertTimeStamp"].Value = item.timestamp.Value;
                    db.cmd.Parameters["@InsertDate"].Value = item.timestamp.Value.Date;                   
                    db.cmd.Parameters["@E_Day"].Value = item.E_Day;
                    db.cmd.Parameters["@E_Year"].Value = item.E_Year;
                    db.cmd.Parameters["@E_Total"].Value = item.E_Total;

                    db.cmd.ExecuteNonQuery();
                }
            }
        }

        public void InsertSunSpecData(IEnumerable<SunSpecData> data)
        { 
            using (Database db = new Database(connection))
            {
                db.cmd.CommandText = "INSERT INTO SunSpec(InsertTimeStamp,InsertDate,Wats,Wh) VALUES(@InsertTimeStamp, @InsertDate, @Wats, @Wh)";

                db.cmd.Parameters.Add("@InsertTimeStamp", OleDbType.Date);
                db.cmd.Parameters.Add("@InsertDate", OleDbType.Date);
                db.cmd.Parameters.AddWithValue("@Wats", OleDbType.Double);
                db.cmd.Parameters.AddWithValue("@Wh", OleDbType.Double);

                foreach (var item in data)
                {
                    db.cmd.Parameters["@InsertTimeStamp"].Value = item.Timestamp.Value;
                    db.cmd.Parameters["@InsertDate"].Value = item.Timestamp.Value.Date;
                    db.cmd.Parameters["@Wats"].Value = item.W;
                    db.cmd.Parameters["@Wh"].Value = item.Wh;                    

                    db.cmd.ExecuteNonQuery();
                }
            }
        }

        public void InsertProduction(IEnumerable<Production> data)
        {
            using (Database db = new Database(connection))
            {
                db.cmd.CommandText = "INSERT INTO Production(InsertTimeStamp, InsertDate, PAC,DAY_ENERGY,YEAR_ENERGY,TOTAL_ENERGY) VALUES(@InsertTimeStamp, @InsertDate, @PAC, @DAY_ENERGY, @YEAR_ENERGY,@TOTAL_ENERGY)";

                db.cmd.Parameters.Add("@InsertTimeStamp", OleDbType.Date);
                db.cmd.Parameters.Add("@InsertDate", OleDbType.Date);
                db.cmd.Parameters.AddWithValue("@PAC", OleDbType.Integer);
                db.cmd.Parameters.AddWithValue("@DAY_ENERGY", OleDbType.Integer);
                db.cmd.Parameters.AddWithValue("@YEAR_ENERGY", OleDbType.Integer);
                db.cmd.Parameters.AddWithValue("@TOTAL_ENERGY", OleDbType.Integer);            

                foreach (var item in data)
                {
                    db.cmd.Parameters["@InsertTimeStamp"].Value = item.timestamp.Value;
                    db.cmd.Parameters["@InsertDate"].Value = item.timestamp.Value.Date;
                    db.cmd.Parameters["@PAC"].Value = item.Pac;
                    db.cmd.Parameters["@DAY_ENERGY"].Value = item.DayEnergy;
                    db.cmd.Parameters["@YEAR_ENERGY"].Value = item.YearEnergy;
                    db.cmd.Parameters["@TOTAL_ENERGY"].Value = item.TotalEnergy;

                    db.cmd.ExecuteNonQuery();
                }
            }
        }


        public void InsertTauronLog(IEnumerable<TauronLogItem> data)
        {
            using (Database db = new Database(connection))
            {
                //If NOT EXISTS(SELECT Null FROM TableName WHERE Field1 = 'Value1' AND Field2 = 'Value2')
//INSERT INTO TableName(Field1, Field2) VALUES('Value1', 'Value2')


                     db.cmd.CommandText = @"

If NOT EXISTS(SELECT 1 FROM TauronLog FROM InsertTimeStamp = @InsertTimeStamp)
BEGIN
INSERT INTO TauronLog(InsertTimeStamp, InsertDate, PowerConsumption,PowerProduction,CurrentTemperature) VALUES(@InsertTimeStamp, @InsertDate, @PowerConsumption, @PowerProduction, @CurrentTemperature)
END";

                // db.cmd.CommandText = "INSERT INTO Production(InsertTimeStamp, InsertDate, PowerConsumption,PowerProduction,CurrentTemperature) VALUES(@InsertTimeStamp, @InsertDate, @PowerConsumption, @PowerProduction, @CurrentTemperature)";

                db.cmd.Parameters.Add("@InsertTimeStamp", OleDbType.Date);
                db.cmd.Parameters.Add("@InsertDate", OleDbType.Date);
                db.cmd.Parameters.AddWithValue("@PowerConsumption", OleDbType.Double);
                db.cmd.Parameters.AddWithValue("@PowerProduction", OleDbType.Double);
                db.cmd.Parameters.AddWithValue("@CurrentTemperature", OleDbType.Double);

                foreach (var item in data)
                {
                    db.cmd.Parameters["@InsertTimeStamp"].Value = item.InsertTimeStamp;
                    db.cmd.Parameters["@InsertDate"].Value = item.InsertTimeStamp.Date;
                    db.cmd.Parameters["@PowerConsumption"].Value = item.PowerConsumption;
                    db.cmd.Parameters["@PowerProduction"].Value = item.PowerProduction;
                    db.cmd.Parameters["@CurrentTemperature"].Value = item.CurrentTemperature;

                    db.cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
