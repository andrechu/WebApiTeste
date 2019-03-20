using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC.PROJETO.PADRAO.LIGHT.Logger
{
    public class Logger
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Info(string message, object request, object response)
        {
            ResolveAditionalFields(request, response);
            Log.Info(message);
        }

        public static void Error(string message, Exception exception)
        {
            Log.Error(message, exception);
        }

        private static void ResolveAditionalFields(object request, object response)
        {
            ThreadContext.Properties["Request"] = request;
            ThreadContext.Properties["Response"] = response;
        }
    }
}
