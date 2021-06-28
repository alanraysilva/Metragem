using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metragem.Models
{
    public class Imovel
    {
        [JsonProperty("metragem")]
        public double Metragem { get; set; }
        [JsonProperty("valor")]
        public decimal Valor { get; set; }

        [JsonProperty("valormetro")]
        public string ValorMetro { get; set; }


        public double calculaValorMetro()
        {
            //return ((double)Valor / Metragem) * 1000;
            return ((double)Valor / Metragem) *1000;
        }

        public Imovel()
        {

        }
    }
}