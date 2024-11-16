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
    public class CustomTextBox : TextBox
    {
        public Color BorderColor { get; set; } = Color.DodgerBlue;
        public int BorderRadius { get; set; } = 8;
        public int BorderThickness { get; set; } = 1;

        public CustomTextBox()
        {
            // Quita el borde estándar para que el borde personalizado se muestre correctamente
            this.BorderStyle = BorderStyle.None;
            this.Padding = new Padding(BorderThickness); 
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Dibujar borde redondeado
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Crear rectángulo del borde
            Rectangle rectBorder = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            using (GraphicsPath path = GetRoundedRectanglePath(rectBorder, BorderRadius))
            using (Pen penBorder = new Pen(BorderColor, BorderThickness))
            {
                graphics.DrawPath(penBorder, path);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate(); 
        }

        private static GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
