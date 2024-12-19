using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProyectoBlazor.Service;
using SistemaGimnasio.Repository;
using ProyectoBlazor.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoBlazor.Repository;

namespace ProyectoBlazor.Tests.Services
{
    [TestClass]
    public class MetricasProgresoServiceTests
    {
        private Mock<MetricasProgresoRepository> mockMetricasRepository;
        private MetricasProgresoService metricasProgresoService;

        [TestInitialize]
        public void Setup()
        {
            // Crear el mock del repositorio
            mockMetricasRepository = new Mock<MetricasProgresoRepository>();

            // Instanciar el servicio bajo prueba
            metricasProgresoService = new MetricasProgresoService(mockMetricasRepository.Object);
        }

        [TestMethod]
        public async Task ObtenerMetricasProgresoPorUsuarioId_DevuelveListaDeMetricas()
        {
            // Arrange
            int usuarioId = 123;
            var metricasEsperadas = new List<MetricasProgreso>
{
      new MetricasProgreso(1, usuarioId, DateTime.Now, "Piernas", 10),
    new MetricasProgreso(2, usuarioId, DateTime.Now, "Brazos", 15)

};

            mockMetricasRepository
                .Setup(repo => repo.ObtenerMetricasPorUsuarioId(usuarioId))
                .ReturnsAsync(metricasEsperadas);

            // Act
            var result = await metricasProgresoService.ObtenerMetricasProgresoPorUsuarioId(usuarioId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Piernas", result[0].parte);
            Assert.AreEqual(10, result[0].cantidad);
        }

        [TestMethod]
        public void CrearMetricaProgreso_CreaMetricaCorrectamente()
        {
            // Arrange
            int usuarioId = 123;
            string parte = "Espalda";
            int cantidad = 12;
            DateTime fecha = DateTime.Now;

            mockMetricasRepository
                .Setup(repo => repo.CrearMetricaProgreso(usuarioId, parte, cantidad, fecha))
                .Verifiable();

            // Act
            metricasProgresoService.CrearMetricaProgreso(usuarioId, parte, cantidad, fecha);

            // Assert
            mockMetricasRepository.Verify(repo => repo.CrearMetricaProgreso(usuarioId, parte, cantidad, fecha), Times.Once);
        }
    }
}

