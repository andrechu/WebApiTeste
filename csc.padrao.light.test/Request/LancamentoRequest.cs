using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoatendimento.Test.Request
{
    public class LancamentoRequest
    {
        public ContaDTO ContaOrigem { get; set; }
        public ContaDTO ContaDestino { get; set; }
        public float valor { get; set; }
    }
}
