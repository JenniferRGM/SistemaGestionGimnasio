using ProyectoBlazor.Modelos;
using ProyectoBlazor.Repository;

namespace ProyectoBlazor.Service
{
    public class UsuarioService
    {

        private UsuarioRepository usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public async Task<List<Usuario>> ObtenerTodosLosClientes()
        {
            return await usuarioRepository.ObtenerTodosLosClientes();
        }


    }
}
