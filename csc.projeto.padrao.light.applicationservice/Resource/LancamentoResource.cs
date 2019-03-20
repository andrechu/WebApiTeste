using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC.PROJETO.PADRAO.LIGHT.APPLICATIONSERVICE.Resource
{
    public class LancamentoResource
    {
        #region Propriedades


        public LancamentoResource(ContaResource contaOrigem, ContaResource contaDestino, float valor)
        {
            this.Id_Conta_Origem = contaOrigem.Id;
            this.Conta_Origem = contaOrigem;

            this.Id_Conta_Destino = contaDestino.Id;
            this.Conta_Destino = contaDestino;

            this.Valor = valor;

        }

        public Int32 Id { get; set; }
        public Int32 Id_Conta_Origem { get; set; }
        public Int16 Id_Conta_Destino { get; set; }
        public float Valor { get; set; }
        public DateTime Data { get; set; }
        public ContaResource Conta_Origem { get; set; }
        public ContaResource Conta_Destino { get; set; }

        #endregion
    }
}
