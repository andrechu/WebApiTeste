using csc.padrao.light.core.model.entities.bases;
using System.Configuration;

namespace csc.padrao.light.core.model.data.contexts
{
    public class DBServerContext : BaseContext
    {
        private string ConnectionStringName
        {
            get
            {
                return "ConnDBServer";

            }
        }

        public DBServerContext()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
        }
    }
}
