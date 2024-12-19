using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProyectoBlazor.Repository;
using ProyectoBlazor.Service;
using ProyectoBlazor.Modelos;

namespace ProyectoBlazor.Tests.Services
{
    [TestClass]
    public class ClaseServiceTests
    {
        private Mock<ClaseRepository> mockClaseRepository;
        private ClaseService claseService;

        [TestInitialize]
        public void Setup()
        {
            mockClaseRepository = new Mock<ClaseRepository>("fakeConnectionString");
            claseService = new ClaseService(mockClaseRepository.Object);
        }

        [TestMethod]
        public async Task ListarClasesPorEntrenador_RetornaClases()
        {
            // Arrange
            int entrenadorId = 1;
            var clasesEsperadas = new List<ClasesModel>
            {
                new ClasesModel(1, "Yoga", 101, "Juan"),
                new ClasesModel(2, "Pilates", 102, "Ana")
            };

            mockClaseRepository
                .Setup(repo => repo.ObtenerTodasLasClasesPorEntrenador(entrenadorId))
                .ReturnsAsync(clasesEsperadas);

            // Act
            var result = await claseService.listarClasesPorEntrenador(entrenadorId);

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Yoga", result[0].Nombre);
        }
    }
}
