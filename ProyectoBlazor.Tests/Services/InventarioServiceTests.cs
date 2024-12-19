using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProyectoBlazor.Service;
using ProyectoBlazor.Modelos;
using SistemaGimnasio.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoBlazor.Repository;

namespace ProyectoBlazor.Tests.Services
{
    [TestClass]
    public class InventarioServiceTests
    {
        private Mock<InventarioRepository> mockInventarioRepository;
        private InventarioService inventarioService;

        [TestInitialize]
        public void Setup()
        {
            var fakeConnectionString = "Server=fakeServer;Database=fakeDB;";
            mockInventarioRepository = new Mock<InventarioRepository>(fakeConnectionString);
            inventarioService = new InventarioService(mockInventarioRepository.Object);
        }

        [TestMethod]
        public async Task ObtenerEquipoPorId_RetornaEquipoCorrecto()
        {
            // Arrange
            var equipoId = 1;
            var equipoEsperado = new InventarioModel
            {
                Id = equipoId,
                NombreEquipo = "Equipo A",
                FechaAdquisicion = DateTime.Now,
                Estado = "Activo",
                VidaUtilDias = 365
            };

            mockInventarioRepository
                .Setup(repo => repo.ObtenerEquipoPorId(equipoId))
                .ReturnsAsync(equipoEsperado);

            // Act
            var result = await inventarioService.ObtenerEquipoPorId(equipoId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(equipoId, result.Id);
            Assert.AreEqual("Equipo A", result.NombreEquipo);
            Assert.AreEqual("Activo", result.Estado);
        }
    }
}

