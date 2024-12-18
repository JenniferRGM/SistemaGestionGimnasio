using ProyectoBlazor.Modelos;
using ProyectoBlazor.Repository;
using SistemaGimnasio.Repository;

namespace ProyectoBlazor.Service
{
    public class AuthenticationService
    {
        private UsuarioRepository usuarioRepository;

        public AuthenticationService(UsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        private readonly List<Usuario> users = new()

        {
        new Usuario ("asdsad", "asdsad"),
        new Usuario ("asdsad2", "asdsad2")
    };

        async public Task<Usuario?> Authenticate(string username, string password)
        {
            Usuario usuario = await usuarioRepository.obtenerUsuarioPorNombreUsuario(username);

            if (usuario == null)
            {
                return null;
            }

            if (usuario.Contraseña == password)
            {
                return usuario;
            }

            return null;
        }

    }


}

