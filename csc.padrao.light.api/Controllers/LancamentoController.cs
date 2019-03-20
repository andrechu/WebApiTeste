using CSC.PROJETO.PADRAO.LIGHT.APPLICATIONSERVICE.Resource;
using CSC.PROJETO.PADRAO.LIGHT.APPLICATIONSERVICE.Services;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace csc.padrao.light.api.Controllers
{
    public class LancamentoController : ApiController
    {
        private LancamentoApplicationService lancamentoApp = new LancamentoApplicationService();

        [HttpPost]
        [Route("api/lancamento/inserir")]
        [Authorize]
        public HttpResponseMessage Inserir(LancamentoRequestResource request)
        {
           
            try
            {
                var ret = lancamentoApp.InserirLancamento(request);
               
                return Request.CreateResponse(HttpStatusCode.OK, ret);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro: " + ex.Message.ToString());
            }
        }

    }
}
