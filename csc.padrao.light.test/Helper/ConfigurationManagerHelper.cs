using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoatendimento.Test.Helper
{
    public static class ConfigurationManagerHelper
    {
        #region [Const]
        private const string WebAPIAddress = "WebAPIAddress";
        private const string WebApiLancamentoInserir = "WebApiLancamentoInserir";
        private const string DefaultLanguage = "DefaultLanguage";
        #endregion

        #region[Methods]

        #region [Address]
        public static string GetWebAPIAddress()
        {
            var value = ConfigurationManager.AppSettings[WebAPIAddress];
            return value;
        }

        public static string GetWebAPILancamentoInserir()
        {
            var value = ConfigurationManager.AppSettings[WebApiLancamentoInserir];
            return value;
        }

        #endregion [Address]

        public static string GetDefaultLanguage()
        {
            var value = ConfigurationManager.AppSettings[DefaultLanguage];
            return value;
        }
        #endregion [Methods]
    }
}
