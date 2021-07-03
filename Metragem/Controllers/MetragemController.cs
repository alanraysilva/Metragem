using Metragem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace Metragem.Controllers
{
    [RoutePrefix("api/metragem")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class MetragemController : ApiController
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        [AllowAnonymous]
        [ResponseType(typeof(ConsultaValorMetro))]
        [AcceptVerbs("POST")]
        [Route("CalculaValorMetro")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public IHttpActionResult CalculaValorMetro([FromBody] ConsultaValorMetro mdl)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            if (ModelState.IsValid)
            {                
                if (mdl.Metragem == 0 && mdl.VlImovel == 0)
                {                    
                   return BadRequest("Erro na informação de valores. Não é possível calcular valores zerados.");
                }
                else if (mdl.VlImovel == 0)
                {                 
                    return BadRequest("Erro na informação de valores. Não é possível calcular, pois o valor do imovel está zerado ou nulo.");
                }
                else if (mdl.Metragem == 0)
                {
                    return BadRequest("Erro na informação de valores. Não é possível calcular, pois o valor do metragem está zerada ou nulo.");
                }
                else
                {
                    try
                    {
                        Imovel imovel = new Imovel();
                        imovel.Metragem = mdl.Metragem;
                        imovel.Valor = mdl.VlImovel;
                        imovel.ValorMetro = imovel.calculaValorMetro().ToString("F2");
                        return Ok(imovel);
                    }
                    catch (WebException we)
                    {                        
                        return BadRequest("Erro na execução da api: " + we.Message);
                    }
                }


            }
            else
            {
                return BadRequest("Não existem dados inseridos na chamada.");
            }


        }

        [AllowAnonymous]
        [ResponseType(typeof(ConsultaValorImovel))]
        [AcceptVerbs("POST")]
        [Route("CalculaValorImovel")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public IHttpActionResult CalculaValorImovel([FromBody] ConsultaValorImovel mdl)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            if (ModelState.IsValid)
            {
                if (mdl.MetroQuadrado == 0 && mdl.VlMetro == 0)
                {
                    return BadRequest("Erro na informação de valores. Não é possível calcular valores zerados.");
                }
                else if (mdl.VlMetro == 0)
                {
                    return BadRequest("Erro na informação de valores. Não é possível calcular, pois o valor do metro quadrado está zerado ou nulo.");
                }
                else if (mdl.MetroQuadrado == 0)
                {
                    return BadRequest("Erro na informação de valores. Não é possível calcular, pois o metro quadrado está zerado  ou nulo.");
                }
                else
                {
                    try
                    {
                        Imovel imovel = new Imovel();
                        imovel.Metragem = mdl.MetroQuadrado;
                        imovel.Valor = mdl.VlMetro;
                        imovel.ValorMetro = Math.Round(imovel.CalculaValorImovel(), MidpointRounding.ToEven).ToString("F2");
                        return Ok(imovel);
                    }
                    catch (WebException we)
                    {
                        return BadRequest("Erro na execução da api: " + we.Message);
                    }
                }
            }
            else
            {
                return BadRequest("Não existem dados inseridos na chamada.");
            }


        }

    }
}
