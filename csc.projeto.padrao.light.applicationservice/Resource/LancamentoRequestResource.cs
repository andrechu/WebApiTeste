using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC.PROJETO.PADRAO.LIGHT.APPLICATIONSERVICE.Resource
{
    public class LancamentoRequestResource
    {
        #region Propriedades

        public ContaResource ContaOrigem { get; set; }
        public ContaResource ContaDestino { get; set; }
        public float valor { get; set; }

        #endregion
    }
}
