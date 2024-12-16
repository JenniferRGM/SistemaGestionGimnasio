﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace SistemaGestionGimnasio.Modelos
{
    /// <summary>
    /// Representa una membresía asignada a un usuario dentro del sistema de gestión del gimnasio.
    /// </summary>
    public class Membresia
    {
        public int id { get; set; }
        public int usuarioId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Membresia"/>.
        /// </summary>
        /// <param name="id">Identificador único de la membresía.</param>
        /// <param name="usuarioId">Identificador del usuario asociado.</param>
        /// <param name="fechaInicio">Fecha de inicio de la membresía.</param>
        /// <param name="fechaFin">Fecha de finalización de la membresía.</param>
        public Membresia(int id, int usuarioId, DateTime fechaInicio, DateTime fechaFin)
        {
            this.id = id;
            this.usuarioId = usuarioId;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
        }




        //public Membresia(DateTime fechaInicio, DateTime fechaVencimiento)
        //{
        //    FechaInicio = fechaInicio;
        //    FechaVencimiento = fechaVencimiento;
        //}

        //public int DiasRestantes()
        //{
        //    return (FechaVencimiento - DateTime.Now).Days;
        //}

        //public bool EstaPorVencer()
        //{
        //    return DiasRestantes() <= 5;
        //}

        //public static Membresia ObtenerMembresia(string usuario)
        //{
        //    string rutaArchivo = Path.Combine("Assets", "membresias.csv");

        //    if (!File.Exists(rutaArchivo))
        //    {
        //        MessageBox.Show($"El archivo {rutaArchivo} no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return null;
        //    }

        //    using (StreamReader lector = new StreamReader(rutaArchivo))
        //    {
        //        string linea;
        //        bool esPrimeraLinea = true;

        //        while ((linea = lector.ReadLine()) != null)
        //        {
        //            if (esPrimeraLinea)
        //            {
        //                esPrimeraLinea = false;
        //                continue;
        //            }

        //            string[] datos = linea.Split(',');
        //            if (datos.Length >= 3 && datos[0] == usuario)
        //            {
        //                if (DateTime.TryParseExact(datos[1].Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaInicio) &&
        //           DateTime.TryParseExact(datos[2].Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaVencimiento))
        //                {
        //                    return new Membresia(fechaInicio, fechaVencimiento);
        //                }
        //                else
        //                {
        //                    MessageBox.Show($"Error en el formato de las fechas para el usuario {usuario}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    return null;
        //                }
        //            }
        //        }
        //    }

        //    return null; 
        //}
    }
}
