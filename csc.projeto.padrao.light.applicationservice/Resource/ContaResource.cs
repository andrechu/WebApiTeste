﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC.PROJETO.PADRAO.LIGHT.APPLICATIONSERVICE.Resource
{
    public class ContaResource
    {
        #region Propriedades

        public Int16 Id { get; set; }
        public string Banco { get; set; }
        public Int16 Agencia { get; set; }
        public Int16 CC { get; set; }
        public Int16 Digito { get; set; }
        public string Nome { get; set; }
        #endregion
    }
}