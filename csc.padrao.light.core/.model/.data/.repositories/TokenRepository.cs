using csc.padrao.light.core.model.entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csc.padrao.light.core.model.data.repositories
{
    public class TokenRepository
    {
        public static IEnumerable<Usuario> Usuarios()
        {
            return new List<Usuario>
            {
                new Usuario { DesLoginUsuario = ConfigurationManager.AppSettings["USUARIOVALIDATION"].ToString(), DesSenhaUsuario = ConfigurationManager.AppSettings["SENHAVALIDATION"].ToString() }
            };
        }
    }
}