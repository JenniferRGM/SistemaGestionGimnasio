using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProyectoBlazor.Modelos;
using ProyectoBlazor.Models;
using ProyectoBlazor.Service;
using SistemaGimnasio.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoBlazor.Tests.Services
{
    [TestClass]
    public class FacturacionServiceTests
    {
        private Mock<FacturaRepository> mockFacturaRepository;
        private Mock<MembresiaRepository> mockMembresiaRepository; // Nuevo mock
        private MembresiaService membresiaService; // Instancia válida de MembresiaService
        private FacturacionService facturacionService;

        [TestInitialize]
        public void Setup()
        {
            // Configuración del mock para FacturaRepository
            mockFacturaRepository = new Mock<FacturaRepository>("fakeConnectionString");

            // Configuración del mock para MembresiaRepository
            mockMembresiaRepository = new Mock<MembresiaRepository>("fakeConnectionString");

            // Creación de una instancia válida de MembresiaService usando el mock
            membresiaService = new MembresiaService(mockMembresiaRepository.Object);

            // Inicializa el FacturacionService con los mocks
            facturacionService = new FacturacionService(mockFacturaRepository.Object, membresiaService);
        }

        [TestMethod]
        public async Task CrearFacturaAsync_CreaFacturaCorrectamente()
        {
            // Arrange
            var factura = new Factura
            {
                NumeroFactura = "FAC-12345",
                FechaEmision = DateTime.Now,
                FechaVencimiento = DateTime.Now.AddDays(30),
                Total = 100.0m,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var facturaItems = new List<FacturaItem>
            {
                new FacturaItem
                {
                    Descripcion = "Servicio de prueba",
                    Cantidad = 1,
                    PrecioUnitario = 100.0m,
                    TotalItem = 100.0m,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            };

            // Configura el comportamiento del mock
            mockFacturaRepository.Setup(repo => repo.CrearFacturaAsync(It.IsAny<Factura>()))
                                 .ReturnsAsync(1); // Retorna un ID ficticio de factura

            mockFacturaRepository.Setup(repo => repo.CrearFacturaItemsAsync(It.IsAny<List<FacturaItem>>()))
                                 .Returns(Task.CompletedTask); // Simula que no hace nada

            // Act
            var result = await facturacionService.CrearFacturaAsync(factura, facturaItems);

            // Assert
            Assert.AreEqual(1, result);
            mockFacturaRepository.Verify(repo => repo.CrearFacturaAsync(It.IsAny<Factura>()), Times.Once);
            mockFacturaRepository.Verify(repo => repo.CrearFacturaItemsAsync(It.IsAny<List<FacturaItem>>()), Times.Once);
        }
    }
}


