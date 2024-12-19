using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProyectoBlazor.Repository;
using ProyectoBlazor.Service;
using ProyectoBlazor.Modelos;
using ProyectoBlazor.Models;

namespace ProyectoBlazor.Tests.Services
{
    [TestClass]
    public class EspacioServiceTests
    {
        private Mock<EspacioRepository> mockEspacioRepository;
        private Mock<ClaseService> mockClaseService;
        private EspacioService espacioService;

        [TestInitialize]
        public void Setup()
        {
            mockEspacioRepository = new Mock<EspacioRepository>("fakeConnectionString");
            mockClaseService = new Mock<ClaseService>(null);
            espacioService = new EspacioService(mockEspacioRepository.Object, mockClaseService.Object);
        }

        [TestMethod]
        public async Task ListarEspaciosPorClaseId_RetornaEspacios()
        {
            // Arrange
            int claseId = 1;
            var espaciosEsperados = new List<EspacioModel>
            {
                new EspacioModel(1, claseId, DateTime.Now, "Clase 1", 10),
                new EspacioModel(2, claseId, DateTime.Now, "Clase 2", 5)
            };

            mockEspacioRepository
                .Setup(repo => repo.ListarEspaciosPorClaseId(claseId))
                .ReturnsAsync(espaciosEsperados);

            // Act
            var result = await espacioService.ListarEspaciosPorClaseId(claseId);

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(10, result[0].Cupos);
        }
    }
}

