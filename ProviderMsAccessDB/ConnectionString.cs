using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderMsAccessDB
{
    public class ConnectionString
    {
        public string ConnectionStr { get; private set; }

        public ConnectionString(string sInitialCatalog)
        {
            ConnectionStr = string.Format("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = {0}; Persist Security Info = False; ", sInitialCatalog);
        }
    }
}
