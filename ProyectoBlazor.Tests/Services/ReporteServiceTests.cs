using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProyectoBlazor.Service;
using SistemaGimnasio.Repository;
using System.Threading.Tasks;

namespace ProyectoBlazor.Tests.Services
{
    [TestClass]
    public class ReporteServiceTests
    {
        private Mock<ReporteRepository> mockReporteRepository;
        private Mock<FacturacionService> mockFacturacionService;
        private ReporteService reporteService;

        [TestInitialize]
        public void Setup()
        {
            // Configura los mocks necesarios
            mockReporteRepository = new Mock<ReporteRepository>("fakeConnectionString");
            mockFacturacionService = new Mock<FacturacionService>(null, null);

            // Inicializa el servicio
            reporteService = new ReporteService(mockReporteRepository.Object, mockFacturacionService.Object);
        }

        [TestMethod]
        public async Task GenerarReportePdf_RetornaBytesNoNulos()
        {
            // Act
            var result = await reporteService.GenerarReportePdf();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0);
        }
    }
}

