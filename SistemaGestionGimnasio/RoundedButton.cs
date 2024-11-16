using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SistemaGestionGimnasio
{
    public class RoundedButton : Button
    {
        public Color BorderColor { get; set; } = Color.DodgerBlue;
        public int BorderRadius { get; set; } = 8;
        public int BorderThickness { get; set; } = 1;

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            // Configurar el gráfico para bordes redondeados
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, BorderRadius, BorderRadius, 180, 90);
            path.AddArc(Width - BorderRadius, 0, BorderRadius, BorderRadius, 270, 90);
            path.AddArc(Width - BorderRadius, Height - BorderRadius, BorderRadius, BorderRadius, 0, 90);
            path.AddArc(0, Height - BorderRadius, BorderRadius, BorderRadius, 90, 90);
            path.CloseAllFigures();

            this.Region = new Region(path);

            // Dibujar borde
            using (Pen pen = new Pen(BorderColor, BorderThickness))
            {
                pen.Alignment = PenAlignment.Inset;
                pevent.Graphics.DrawPath(pen, path);
            }
        }
    }
}
