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
    public class ProviderMsAccess : IDisposable
    {
        private ConnectionString connection;

        public ProviderMsAccess(string dbLocation)
        {
            connection = new ConnectionString(dbLocation);
        }

        public void Dispose() { }

        public void InsertProduction2(IEnumerable<Production2> data)
        {
            using (Database db = new Database(connection))
            {
                db.cmd.CommandText = "INSERT INTO Production2(InsertTimeStamp,InsertDate,E_Day,E_Year,E_Total) VALUES(@InsertTimeStamp, @InsertDate, @E_Day, @E_Year, @E_Total)";

                db.cmd.Parameters.Add("@InsertTimeStamp", OleDbType.Date);
                db.cmd.Parameters.Add("@InsertDate", OleDbType.Date);
                db.cmd.Parameters.Add("@E_Day", OleDbType.Double);
                db.cmd.Parameters.Add("@E_Year", OleDbType.Double);
                db.cmd.Parameters.Add("@E_Total", OleDbType.Double);

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
                db.cmd.Parameters.Add("@Wats", OleDbType.Double);
                db.cmd.Parameters.Add("@Wh", OleDbType.Double);

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
                db.cmd.Parameters.Add("@PAC", OleDbType.Integer);
                db.cmd.Parameters.Add("@DAY_ENERGY", OleDbType.Integer);
                db.cmd.Parameters.Add("@YEAR_ENERGY", OleDbType.Integer);
                db.cmd.Parameters.Add("@TOTAL_ENERGY", OleDbType.Integer);

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
                db.cmd.Parameters.Add("@InsertTimeStamp", OleDbType.Date);
                db.cmd.Parameters.Add("@InsertDate", OleDbType.Date);
                db.cmd.Parameters.Add("@PowerConsumption", OleDbType.Double);
                db.cmd.Parameters.Add("@PowerProduction", OleDbType.Double);
                db.cmd.Parameters.Add("@CurrentTemperature", OleDbType.Double);

                foreach (var item in data)
                {
                    db.cmd.Parameters["@InsertTimeStamp"].Value = item.InsertTimeStamp;
                    db.cmd.Parameters["@InsertDate"].Value = item.InsertTimeStamp.Date;
                    db.cmd.Parameters["@PowerConsumption"].Value = item.PowerConsumption;
                    db.cmd.Parameters["@PowerProduction"].Value = item.PowerProduction;
                    db.cmd.Parameters["@CurrentTemperature"].Value = item.CurrentTemperature;

                    db.cmd.CommandText = @"SELECT 1 FROM TauronLog WHERE InsertTimeStamp = @InsertTimeStamp";
                    int result = db.cmd.ExecuteScalar().GetValue<int>(0);

                    if (result == 0)
                    {
                        db.cmd.CommandText = @"INSERT INTO TauronLog(InsertTimeStamp, InsertDate, PowerConsumption,PowerProduction,CurrentTemperature) VALUES(@InsertTimeStamp, @InsertDate, @PowerConsumption, @PowerProduction, @CurrentTemperature)";
                        db.cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void DailySumProduction(DateTime dateSelected, double dailyProduction)
        {
            using (Database db = new Database(connection))
            {
                db.cmd.Parameters.Add("@InsertDate", OleDbType.Date);
                db.cmd.Parameters.Add("@Wh", OleDbType.Double);

                db.cmd.Parameters["@InsertDate"].Value = dateSelected.Date;
                db.cmd.Parameters["@Wh"].Value = dailyProduction;

                db.cmd.CommandText = @"INSERT INTO FroniusProduction(InsertDate, Wh) VALUES(@InsertDate, @Wh)";
                db.cmd.ExecuteNonQuery();
            }
        }

        public DateTime GetFroniusProductionBeginDate()
        {
            DateTime result = DateTime.Now;

            using (Database db = new Database(connection))
            {
                db.cmd.CommandText = @"SELECT MAX(InsertDate) FROM FroniusProduction";
                result = db.cmd.ExecuteScalar().GetValue<DateTime>(DateTime.Now);
            }

            return result;
        }
    }
}
