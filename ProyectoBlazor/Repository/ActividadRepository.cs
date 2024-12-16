using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SistemaGimnasio.Repository
{
    /// <summary>
    /// Proporciona acceso a los datos relacionados con las actividades en la base de datos.
    /// </summary>
    public class ActividadRepository
    {
        /// <summary>
        /// Cadena de conexión a la base de datos.
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ActividadRepository"/>.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión a la base de datos.</param>
        public ActividadRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


    }
}

