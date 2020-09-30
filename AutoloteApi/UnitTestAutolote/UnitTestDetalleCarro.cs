using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoIndividual_2da_Tarea_.DomainService;
using ProyectoIndividual_2da_Tarea_.Modelos;

namespace UnitTestCarro
{
    [TestClass]
    public class UnitTestDetalleCarro
    {
        [TestMethod]
        public void PruebaParaValidarQueSeEncuentraUnCarro()
        {
            // Arrange
            var carro = new Carro();
            var detalleCarro = new DetalleCarro();
            var id = new int();
            detalleCarro = null;
            var autolote = new Autolote(carro, detalleCarro);
            // Act
            var detalleCarroDomainService = new DetalleCarroDomainService();
            var resultado = detalleCarroDomainService.GetDetalleCarroDomainService(detalleCarro);

            // Assert
            Assert.AreEqual("No existe el Detalle del Carro", resultado);
        }

        [TestMethod]
        public void Prueba2ParaValidarQueSeEncuentraUnCarro()
        {
            // Arrange
            var carro = new Carro();
            var detalleCarro = new DetalleCarro();
            detalleCarro = null;
            var autolote = new Autolote(carro, detalleCarro);
            // Act
            var detalleCarroDomainService = new DetalleCarroDomainService();
            var resultado = detalleCarroDomainService.DeleteDetalleCarroDomainService(detalleCarro);

            // Assert
            Assert.AreEqual("El Detalle del Carro no existe", resultado);
        }

    }
}

