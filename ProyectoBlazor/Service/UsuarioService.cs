using ProyectoBlazor.Modelos;
using ProyectoBlazor.Repository;

namespace ProyectoBlazor.Service
{
    /// <summary>
    /// Servicio para gestionar operaciones relacionadas con los usuarios.
    /// </summary>
    public class UsuarioService
    {
       
        private UsuarioRepository usuarioRepository;

        /// <summary>
        /// Constructor para inicializar el servicio de usuarios.
        /// </summary>
        /// <param name="usuarioRepository">Instancia del repositorio de usuarios.</param>
        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Obtiene una lista de todos los usuarios con el rol de cliente.
        /// </summary>
        /// <returns>Lista de usuarios que son clientes.</returns>
        public async Task<List<Usuario>> ObtenerTodosLosClientes()
        {
            return await usuarioRepository.ObtenerTodosLosClientes();
        }


    }
}
