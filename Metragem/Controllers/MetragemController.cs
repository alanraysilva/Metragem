using Metragem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Metragem.Controllers
{
    [RoutePrefix("api/metragem")]
    public class MetragemController : ApiController
    {
        [AcceptVerbs("POST")]
        [Route("CalculoMetroQuadrado")]
        public HttpResponseMessage CalculaMetragem([FromBody] ConsultaAmbiente mdl) 
        {
            if (mdl.Comprimento == 0 && mdl.Largura == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Erro na informação de valores");
            }

            try
            {
                Ambiente ambiente = new Ambiente();
                ambiente.Largura = mdl.Largura;
                ambiente.Comprimento = mdl.Comprimento;
                ambiente.Metragem = ambiente.calculaMetragem().ToString("F2");
                return Request.CreateResponse(HttpStatusCode.OK, ambiente);
            }
            catch (WebException we)
            {
                return Request.CreateResponse("Erro na execução da api: " + we.Message);
            }
            

        }
    }
}
