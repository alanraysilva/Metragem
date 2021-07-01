using Metragem.Controllers;
using Metragem.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Http.Results;

namespace MetragemTest
{
    [TestClass]
    public class TestValorMetro
    {
        [TestMethod]
        public void CalculoValorMetro_ValorCorreto()
        {            
            ConsultaValorMetro consulta = new ConsultaValorMetro() { Metragem = 65, VlImovel = 180000 };
            var controller = new MetragemController();
            var result = controller.CalculaValorMetro(consulta);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<Imovel>));
        }

        [TestMethod]
        public void CalculoValorMetro_TodosValoresVazio()
        {
            ConsultaValorMetro consulta = new ConsultaValorMetro() { Metragem = 0, VlImovel = 0 };
            var controller = new MetragemController();
            var result = controller.CalculaValorMetro(consulta);
            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void CalculoValorMetro_ValorMetragemVazio()
        {
            ConsultaValorMetro consulta = new ConsultaValorMetro() { Metragem = 65, VlImovel = 0 };
            var controller = new MetragemController();
            var result = controller.CalculaValorMetro(consulta);
            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void CalculoValorMetro_ValorImovelVazio()
        {
            ConsultaValorMetro consulta = new ConsultaValorMetro() { Metragem = 0, VlImovel = 180000 };
            var controller = new MetragemController();
            var result = controller.CalculaValorMetro(consulta);
            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }
    }
}
