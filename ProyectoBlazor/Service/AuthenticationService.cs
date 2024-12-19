using ProyectoBlazor.Modelos;
using ProyectoBlazor.Repository;


namespace ProyectoBlazor.Service
{
    /// <summary>
    /// Servicio para la autenticación de usuarios.
    /// </summary>
    public class AuthenticationService
    {
        /// <summary>
        /// Repositorio para acceder a los datos de los usuarios.
        /// </summary>
        private UsuarioRepository usuarioRepository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AuthenticationService"/>.
        /// </summary>
        /// <param name="usuarioRepository">Repositorio de usuarios.</param>
        public AuthenticationService(UsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Lista de usuarios de ejemplo para pruebas locales.
        /// </summary>
        private readonly List<Usuario> users = new()

        {
        new Usuario ("asdsad", "asdsad"),
        new Usuario ("asdsad2", "asdsad2")
    };
        /// <summary>
        /// Autentica un usuario verificando sus credenciales.
        /// </summary>
        /// <param name="username">Nombre de usuario o correo electrónico.</param>
        /// <param name="password">Contraseña del usuario.</param>
        /// <returns>
        /// Una instancia de <see cref="Usuario"/> si las credenciales son correctas, 
        /// de lo contrario, <see langword="null"/>.
        /// </returns>
        async public Task<Usuario?> Authenticate(string username, string password)
        {
            // Busca el usuario en la base de datos
            Usuario usuario = await usuarioRepository.obtenerUsuarioPorNombreUsuario(username);

            // Si no se encuentra el usuario, retorna null
            if (usuario == null)
            {
                return null;
            }
            // Verifica si la contraseña coincide
            if (usuario.Contraseña == password)
            {
                return usuario;// Credenciales correctas
            }

            return null;// Credenciales incorrectas
        }

    }


}

