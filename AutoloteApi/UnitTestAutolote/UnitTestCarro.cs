using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoIndividual_2da_Tarea_.DomainService;
using ProyectoIndividual_2da_Tarea_.Modelos;

namespace UnitTestCarro
{
    [TestClass]
    public class UnitTestCarro
    {
        public void PruebaParaValidarQueSeEncuentraUnCarro()
        {
            // Arrange
            var carro = new Carro();
            var detalleCarro = new DetalleCarro();
            var id = new int();
            carro = null;
            var autolote = new Autolote(carro, detalleCarro);
            // Act
            var carroDomainService = new CarroDomainService();
            var resultado = carroDomainService.GetCarroDomainService(id, carro);

            // Assert
            Assert.AreEqual("El Carro no Existe", resultado);
        }

        [TestMethod]
        public void PruebaParaValidarQueElDetalleCarrroExiste()
        {
            // Arrange
            var carro = new Carro();
            var detalleCarro = new DetalleCarro();
            detalleCarro = null;
            var autolote = new Autolote(carro, detalleCarro);
            // Act
            var carroDomainService = new CarroDomainService();
            var resultado = carroDomainService.PostCarroDomainService(autolote);

            // Assert
            Assert.AreEqual("El Detalle del Carro no existe", resultado);

        }
        [TestMethod]
        public void PruebaParaValidarQueElAñoEsMayorA2008()
        {
            // Arrange
            var carro = new Carro();
            var detalleCarro = new DetalleCarro();
            detalleCarro.Fecha = 2008;
            var autolote = new Autolote(carro, detalleCarro);
            // Act
            var carroDomainService = new CarroDomainService();
            var resultado = carroDomainService.PostCarroDomainService(autolote);

            // Assert
            Assert.AreEqual("El Año del carro debe ser mayor de 2008 para ser ingresado", resultado);
        }

        [TestMethod]
        public void Prueba2ParaValidarQueElAñoEsMayorA2008()
        {
            // Arrange
            var carro = new Carro();
            var detalleCarro = new DetalleCarro();
            var id = new int();
            detalleCarro.Fecha = 2008;
            var autolote = new Autolote(carro, detalleCarro);
            // Act
            var carroDomainService = new CarroDomainService();
            var resultado = carroDomainService.PutCarroDomainService(id, autolote);

            // Assert
            Assert.AreEqual("El Año del carro debe ser mayor de 2008 para ser ingresado", resultado);

        }
        [TestMethod]
        public void Prueba2ParaValidarQueElDetalleCarrroExiste()
        {
            // Arrange
            var carro = new Carro();
            var detalleCarro = new DetalleCarro();
            var id = new int();
            detalleCarro = null;
            var autolote = new Autolote(carro, detalleCarro);
            // Act
            var carroDomainService = new CarroDomainService();
            var resultado = carroDomainService.PutCarroDomainService(id, autolote);

            // Assert
            Assert.AreEqual("El Detalle del Carro no existe", resultado);

        }

        [TestMethod]
        public void Prueba2ParaValidarQueSeEncuentraUnCarro()
        {
            // Arrange
            var carro = new Carro();
            var detalleCarro = new DetalleCarro();
            var id = new int();
            carro = null;
            var autolote = new Autolote(carro, detalleCarro);
            // Act
            var carroDomainService = new CarroDomainService();
            var resultado = carroDomainService.DeleteCarroDomainService(carro);

            // Assert
            Assert.AreEqual("No Existe el Carro", resultado);
        }

    }
}

