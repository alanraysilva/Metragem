using Metragem.Controllers;
using Metragem.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Http.Results;

namespace MetragemTest
{
    [TestClass]
    public class TestValorImovel
    {
        [TestMethod]
        public void CalculoValorImovel_ValorCorreto()
        {
            ConsultaValorImovel consulta = new ConsultaValorImovel() {MetroQuadrado = 65, VlMetro = 2769.23M };
            var controller = new MetragemController();
            var result = controller.CalculaValorImovel(consulta);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<Imovel>));
        }

        [TestMethod]
        public void CalculoValorImovel_TodosValoresVazio()
        {
            ConsultaValorImovel consulta = new ConsultaValorImovel() { MetroQuadrado = 0, VlMetro = 0 };
            var controller = new MetragemController();
            var result = controller.CalculaValorImovel(consulta);
            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void CalculoValorImovel_ValorMetragemVazio()
        {
            ConsultaValorImovel consulta = new ConsultaValorImovel() { MetroQuadrado = 65, VlMetro = 0 };
            var controller = new MetragemController();
            var result = controller.CalculaValorImovel(consulta);
            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void CalculoValorImovel_ValorImovelVazio()
        {
            ConsultaValorImovel consulta = new ConsultaValorImovel() { MetroQuadrado = 0, VlMetro = 2769.23M };
            var controller = new MetragemController();
            var result = controller.CalculaValorImovel(consulta);
            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }
    }
}
