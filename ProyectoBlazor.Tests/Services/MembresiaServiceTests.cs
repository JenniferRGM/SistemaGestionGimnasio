using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SistemaGimnasio.Repository;
using ProyectoBlazor.Service;
using ProyectoBlazor.Modelos;
using System;
using System.Threading.Tasks;

namespace ProyectoBlazor.Tests.Services
{
    [TestClass]
    public class MembresiaServiceTests
    {
        private Mock<MembresiaRepository> mockMembresiaRepository;
        private MembresiaService membresiaService;

        [TestInitialize]
        public void Setup()
        {
            // Configura el mock del repositorio con un constructor válido
            mockMembresiaRepository = new Mock<MembresiaRepository>("fakeConnectionString");
            membresiaService = new MembresiaService(mockMembresiaRepository.Object);
        }

        [TestMethod]
        public async Task ObtenerDiasRestantesMembresia_SinMembresia_RetornaNull()
        {
            // Arrange
            int usuarioId = 1;

            mockMembresiaRepository
                .Setup(repo => repo.ObtenerMembresiaPorUsuarioIdAsync(usuarioId))
                .ReturnsAsync((Membresia)null);

            // Act
            var resultado = await membresiaService.ObtenerDiasRestantesMembresia(usuarioId);

            // Assert
            Assert.IsNull(resultado, "El resultado debe ser null si no existe membresía.");
        }

        [TestMethod]
        public async Task ObtenerDiasRestantesMembresia_ConMembresia_RetornaDias()
        {
            // Arrange
            int usuarioId = 1;
            var fechaFin = DateTime.Now.AddDays(10);
            var membresia = new Membresia(1, usuarioId, DateTime.Now, fechaFin);

            mockMembresiaRepository
                .Setup(repo => repo.ObtenerMembresiaPorUsuarioIdAsync(usuarioId))
                .ReturnsAsync(membresia);

            // Act
            var resultado = await membresiaService.ObtenerDiasRestantesMembresia(usuarioId);

            // Assert
            Assert.AreEqual(10, resultado, "Debe devolver los días restantes de la membresía.");
        }
    }
}

