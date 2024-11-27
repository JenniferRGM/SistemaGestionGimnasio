using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionGimnasio.Modelos
{
    public class ComboBoxItem
    {
        public string DisplayText { get; set; }
        public Clases Clase { get; set; }

        public ComboBoxItem(string displayText, Clases clase)
        {
            DisplayText = displayText;
            Clase = clase;
        }

        public override string ToString()
        {
            return DisplayText;
        }
    }
}
