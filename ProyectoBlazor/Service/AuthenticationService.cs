using ProyectoBlazor.Modelos;
using ProyectoBlazor.Repository;
using SistemaGestionGimnasio.Modelos;
using SistemaGimnasio.Repository;

namespace ProyectoBlazor.Service
{
    /// <summary>
    /// Servicio responsable de manejar la autenticación de usuarios.
    /// </summary>
    public class AuthenticationService
    {
        /// <summary>
        /// Repositorio de usuarios para acceder a los datos de usuario.
        /// </summary>
        private UsuarioRepository usuarioRepository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AuthenticationService"/>.
        /// </summary>
        /// <param name="usuarioRepository">Instancia del repositorio de usuarios.</param>
        public AuthenticationService(UsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        private readonly List<Usuario> users = new()

        {
        new Usuario ("asdsad", "asdsad"),
        new Usuario ("asdsad2", "asdsad2")
    };

        /// <summary>
        /// Autentica un usuario verificando su nombre de usuario y contraseña.
        /// </summary>
        /// <param name="username">Nombre de usuario.</param>
        /// <param name="password">Contraseña del usuario.</param>
        /// <returns>Instancia de <see cref="Usuario"/> si la autenticación es exitosa, de lo contrario null.</returns>
        async public Task<Usuario?> Authenticate(string username, string password)
        {
            // Busca el usuario por nombre de usuario en la base de datos
            Usuario usuario = await usuarioRepository.obtenerUsuarioPorNombreUsuario(username);

            if (usuario == null)
            {
                return null;// Usuario no encontrado
            }
            // Verifica si la contraseña coincide
            if (usuario.Contraseña == password)
            {
                return usuario;// Autenticación exitosa
            }

            return null;// Contraseña incorrecta
        }

    }


}

