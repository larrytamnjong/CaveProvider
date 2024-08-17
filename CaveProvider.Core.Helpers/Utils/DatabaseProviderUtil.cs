using CaveProvider.Core.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveProvider.Core.Helpers.Utils
{
    public static class DatabaseProviderUtil
    {
        public static DataBaseProvider Set(string? providerName)
        {
            if (providerName == null)
            {
                return DataBaseProvider.SqlServer;
            }
            switch (providerName)
            {
                case "SqlServer":
                    {
                        return DataBaseProvider.SqlServer;
                    }
                case "Postgres":
                    {
                        return DataBaseProvider.Postgres;
                    }
                   
                default: return DataBaseProvider.SqlServer;
            }
        }
    }
}
 