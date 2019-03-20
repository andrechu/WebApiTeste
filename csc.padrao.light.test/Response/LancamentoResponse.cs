using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoatendimento.Test.Request
{
    public class LancamentoResponse
    {
        public int Id { get; set; }
        public int Id_Conta_Origem { get; set; }
        public int Id_Conta_Destino { get; set; }
        public ContaDTO ContaOrigem { get; set; }
        public ContaDTO ContaDestino { get; set; }
        public float valor { get; set; }
        public DateTime Data { get; set; }
    }
}
