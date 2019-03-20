using csc.padrao.light.core.model.entities.bases;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace csc.padrao.light.core.model.entities
{
    public class Usuario
    {
        #region Propriedades

   
        public string DesLoginUsuario { get; set; }
        public string DesSenhaUsuario { get; set; }

        #endregion
    }
}
