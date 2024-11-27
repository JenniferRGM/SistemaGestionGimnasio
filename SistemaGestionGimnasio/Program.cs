using SistemaGestionGimnasio.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaGestionGimnasio.FormulariosUsuarios;
using SistemaGestionGimnasio.DataHandler;

namespace SistemaGestionGimnasio
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IDataHandler dataHandler = new FileDataHandler();
            Application.Run(new Login(dataHandler));
        }
    }
}
