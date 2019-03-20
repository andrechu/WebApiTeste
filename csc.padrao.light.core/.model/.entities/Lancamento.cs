using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csc.padrao.light.core.model.entities
{
    public class Lancamento
    {
        #region Propriedades

        public Int32 Id { get; set; }
        public Int32 Id_Conta_Origem { get; set; }
        public Int16 Id_Conta_Destino { get; set; }      
	    public float Valor { get; set; }
        public Int16 Digito { get; set; }
        public DateTime Data { get; set; }

        #endregion
    }
}
