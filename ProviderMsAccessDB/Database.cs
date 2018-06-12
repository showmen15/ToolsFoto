using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderMsAccessDB
{
    public class Database : IDisposable
    {
        private OleDbConnection conn { get; set; }
        public OleDbCommand cmd { get; set; }
        public OleDbTransaction tran { get; set; }

        public Database(string connectionString)
        {
            conn = new OleDbConnection(connectionString);
            conn.Open();

            cmd = new OleDbCommand("", conn);
        }

        public Database(ConnectionString connectionString)
        {
            conn = new OleDbConnection(connectionString.ConnectionStr);
            conn.Open();

            cmd = new OleDbCommand("", conn);
        }

        public Database(ConnectionString connectionString, bool withTransation)
        {
            conn = new OleDbConnection(connectionString.ConnectionStr);
            conn.Open();

            if (withTransation)
            {
                tran = conn.BeginTransaction();
                cmd = new OleDbCommand("", conn, tran);
            }
            else
                cmd = new OleDbCommand("", conn);
        }

        public void Commit()
        {
            if (tran != null)
                tran.Commit();
        }

        public void Rollback()
        {
            if (tran != null)
                tran.Rollback();
        }

        public void Dispose()
        {
            cmd.Cancel();
            cmd.Dispose();
            cmd = null;

            conn.Close();
            conn.Dispose();
            conn = null;
        }
    }
}
