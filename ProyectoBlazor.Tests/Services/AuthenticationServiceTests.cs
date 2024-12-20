using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProyectoBlazor.Repository;
using ProyectoBlazor.Service;
using ProyectoBlazor.Modelos; 

namespace ProyectoBlazor.Tests.Services
{
    [TestClass]
    public class AuthenticationServiceTests
    {
        private Mock<UsuarioRepository> mockUsuarioRepository;
        private AuthenticationService authService;

        [TestInitialize]
        public void Setup()
        {
            mockUsuarioRepository = new Mock<UsuarioRepository>("fakeConnectionString");
            authService = new AuthenticationService(mockUsuarioRepository.Object);
        }

        [TestMethod]
        public async Task Authenticate_UsuarioInvalido_RetornaNull()
        {
            // Arrange
            string username = "user1";
            string password = "pass123";

            mockUsuarioRepository
                .Setup(repo => repo.obtenerUsuarioPorNombreUsuario(username))
                .ReturnsAsync(() => null); // Retorna null directamente

            // Act
            var result = await authService.Authenticate(username, password);

            // Assert
            Assert.IsNull(result);
        }
    }
}




