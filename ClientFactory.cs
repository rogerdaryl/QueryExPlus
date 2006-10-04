using System;

namespace QueryExPlus
{
    static class DbClientFactory
    {
        public static DbClient GetDBClient(ConnectionSettings conSettings)
        {
            switch (conSettings.Type)
            {
                case ConnectionSettings.ConnectionType.SqlConnection:
                    return new SqlDBClient(conSettings);
                case ConnectionSettings.ConnectionType.OleDb:
                    return new OleDbClient(conSettings);
                case ConnectionSettings.ConnectionType.Oracle:
                    return new OracleDbClient(conSettings);
                default:
                    throw new ArgumentOutOfRangeException("conSettings.Type");
            }
        }
        
        public static IBrowser GetBrowser(DbClient client)
        {
            if ((client as SqlDBClient) != null)
            {
                return new SqlBrowser(client);
            }
            if ((client as OleDbClient) != null)
            {
                return new OleDbBrowser(client);
            }
            throw new ApplicationException("Unknown connection type");
        }
    }
}
