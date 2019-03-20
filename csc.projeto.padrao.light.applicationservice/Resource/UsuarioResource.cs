using System;

namespace CSC.PROJETO.PADRAO.LIGHT.APPLICATIONSERVICE.Resource
{
    public class UsuarioResource
    {
        public int CodUsuario { get; set; }
        public string DesLoginUsuario { get; set; }
        public string DesNomeUsuario { get; set; }
        public string DesEmailUsuario { get; set; }
        public DateTime DatCadastroUsuario { get; set; }
        public int CodPerfil { get; set; }
    }
}
