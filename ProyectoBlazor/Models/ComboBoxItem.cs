using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionGimnasio.Modelos
{
    /// <summary>
    /// Representa un elemento que se utiliza en un ComboBox, asociando un texto de visualización con una clase.
    /// </summary>
    public class ComboBoxItem
    {
        public string DisplayText { get; set; }
        public ClasesModel Clase { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ComboBoxItem"/>.
        /// </summary>
        /// <param name="displayText">Texto que se mostrará en el ComboBox.</param>
        /// <param name="clase">Instancia de la clase asociada.</param>
        public ComboBoxItem(string displayText, ClasesModel clase)
        {
            DisplayText = displayText;
            Clase = clase;
        }

        /// <summary>
        /// Devuelve el texto de visualización como representación en cadena del objeto.
        /// </summary>
        /// <returns>El texto de visualización asociado al elemento.</returns>
        public override string ToString()
        {
            return DisplayText;
        }
    }
}
