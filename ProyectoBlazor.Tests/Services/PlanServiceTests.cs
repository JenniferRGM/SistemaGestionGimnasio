using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProyectoBlazor.Service;
using ProyectoBlazor.Repository;
using ProyectoBlazor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoBlazor.Tests.Services
{
    [TestClass]
    public class PlanServiceTests
    {
        private Mock<PlanRepository> mockPlanRepository;
        private PlanService planService;

        [TestInitialize]
        public void Setup()
        {
            // Configura el mock del repositorio
            mockPlanRepository = new Mock<PlanRepository>("fakeConnectionString");

            // Inicializa el servicio con el mock
            planService = new PlanService(mockPlanRepository.Object);
        }

        [TestMethod]
        public async Task ObtenerTodosLosPlanes_RetornaListaDePlanes()
        {
            // Arrange
            var planesEsperados = new List<Plan>
            {
                new Plan(1, "Plan Básico"),
                new Plan(2, "Plan Avanzado")
            };

            mockPlanRepository
                .Setup(repo => repo.ObtenerTodosLosPlanes())
                .ReturnsAsync(planesEsperados);

            // Act
            var result = await planService.ObtenerTodosLosPlanes();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Plan Básico", result[0].Nombre);
        }
    }
}

