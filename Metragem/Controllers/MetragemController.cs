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
        [Route("CalculaValorMetro")]
        public IHttpActionResult CalculaValorMetro([FromBody] ConsultaValorMetro mdl)
        {
            if (ModelState.IsValid)
            {                
                if (mdl.Metragem == 0 && mdl.VlImovel == 0)
                {                    
                   return BadRequest("Erro na informação de valores. Não é possível calcular valores zerados.");
                }
                else if (mdl.VlImovel == 0)
                {                 
                    return BadRequest("Erro na informação de valores. Não é possível calcular, pois o valor do metro está zerado.");
                }
                else if (mdl.Metragem == 0)
                {
                    return BadRequest("Erro na informação de valores. Não é possível calcular, pois o valor do metro está zerado.");
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

        [AcceptVerbs("POST")]
        [Route("CalculaValorImovel")]
        public IHttpActionResult CalculaValorImovel([FromBody] ConsultaValorImovel mdl)
        {
            if (ModelState.IsValid)
            {
                if (mdl.MetroQuadrado == 0 && mdl.VlMetro == 0)
                {
                    return BadRequest("Erro na informação de valores. Não é possível calcular valores zerados.");
                }
                else if (mdl.VlMetro == 0)
                {
                    return BadRequest("Erro na informação de valores. Não é possível calcular, pois o valor do metro está zerado.");
                }
                else if (mdl.MetroQuadrado == 0)
                {
                    return BadRequest("Erro na informação de valores. Não é possível calcular, pois o valor do metro está zerado.");
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
