using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProyectoBlazor.Service;
using SistemaGimnasio.Repository;
using System.Threading.Tasks;

namespace ProyectoBlazor.Tests.Services
{
    [TestClass]
    public class ReservaServiceTests
    {
        private Mock<ReservaRepository> mockReservaRepository; 
        private Mock<EspacioService> mockEspacioService;       
        private ReservaService reservaService;

        [TestInitialize]
        public void Setup()
        {
            // Configuración del mock de EspacioService
            mockEspacioService = new Mock<EspacioService>(null, null);

            // Configuración del mock de ReservaRepository
            mockReservaRepository = new Mock<ReservaRepository>("fakeConnectionString", mockEspacioService.Object);

            // Inicializa el servicio bajo prueba
            reservaService = new ReservaService(mockReservaRepository.Object);
        }

        [TestMethod]
        public async Task RegistrarReserva_CreaReservaYActualizaCupos()
        {
            // Arrange
            int claseEspacioId = 1;
            int clienteId = 1;

            // Configuración de los métodos del mock
            mockReservaRepository.Setup(repo => repo.CrearReserva(claseEspacioId, clienteId)).ReturnsAsync(true);
            mockReservaRepository.Setup(repo => repo.RestarCupo(claseEspacioId)).ReturnsAsync(true);

            // Act
            await reservaService.RegistrarReserva(claseEspacioId, clienteId);

            // Assert
            mockReservaRepository.Verify(repo => repo.CrearReserva(claseEspacioId, clienteId), Times.Once);
            mockReservaRepository.Verify(repo => repo.RestarCupo(claseEspacioId), Times.Once);
        }
    }
}

