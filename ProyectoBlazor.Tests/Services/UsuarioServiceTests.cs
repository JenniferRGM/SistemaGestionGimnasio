using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProyectoBlazor.Repository;
using ProyectoBlazor.Service;
using ProyectoBlazor.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoBlazor.Tests.Services
{
    [TestClass]
    public class UsuarioServiceTests
    {
        private Mock<UsuarioRepository> _mockRepository;
        private UsuarioService _usuarioService;

        [TestInitialize]
        public void Setup()
        {
            // Configura un mock del repositorio
            _mockRepository = new Mock<UsuarioRepository>("fakeConnectionString");
            _usuarioService = new UsuarioService(_mockRepository.Object);
        }

        [TestMethod]
        public async Task ObtenerTodosLosClientes_RetornaListaDeClientes()
        {
            // Arrange: Configura el comportamiento del mock
            var listaUsuarios = new List<Usuario>
            {
                new Usuario { Id = 1, Nombre = "Juan Pérez", Tipo = "Cliente" },
                new Usuario { Id = 2, Nombre = "Ana Gómez", Tipo = "Cliente" }
            };

            _mockRepository.Setup(repo => repo.ObtenerTodosLosClientes())
                           .ReturnsAsync(listaUsuarios);

            // Act: Llama al método del servicio
            var resultado = await _usuarioService.ObtenerTodosLosClientes();

            // Assert: Valida el resultado
            Assert.IsNotNull(resultado, "La lista no debe ser nula.");
            Assert.AreEqual(2, resultado.Count, "La cantidad de usuarios debe ser 2.");
            Assert.AreEqual("Juan Pérez", resultado[0].Nombre, "El primer usuario no coincide.");
        }
    }
}

