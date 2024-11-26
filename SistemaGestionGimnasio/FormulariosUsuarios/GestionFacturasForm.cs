using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaGestionGimnasio.Modelos;

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class GestionFacturasForm : Form
    {
        private List<Factura> listaFacturas = new List<Factura>();
        public GestionFacturasForm()
        {
            InitializeComponent();

            CmbEstado.Items.AddRange(new string[] { "Pagada", "Pendiente" });
            ActualizarListaFacturas();
        }

        private void BtnGenerarFactura(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtCliente.Text) || string.IsNullOrWhiteSpace(TxtMonto.Text) || CmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Crea la nueva factura
            int numeroFactura = listaFacturas.Count + 1;
            DateTime fechaEmision = DateTime.Now;
            string cliente = TxtCliente.Text.Trim();
            double monto = double.Parse(TxtMonto.Text);
            string estado = CmbEstado.SelectedItem.ToString();

            Factura nuevaFactura = new Factura(numeroFactura, fechaEmision, cliente, monto, estado);
            listaFacturas.Add(nuevaFactura);

            GuardarFacturaEnArchivo(nuevaFactura);

            MessageBox.Show("Factura generada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Limpia campos
            TxtCliente.Clear();
            TxtMonto.Clear();
            CmbEstado.SelectedIndex = -1;

            //Actualiza la lista
            ActualizarListaFacturas();

        }

        private void ActualizarListaFacturas()
        {
            DgvFacturas.Rows.Clear();

            foreach (var factura in listaFacturas)
            {
                DgvFacturas.Rows.Add(factura.NumeroFactura, factura.FechaEmision.ToShortDateString(), factura.Cliente, factura.Estado);
            }
        }

        private static void GuardarFacturaEnArchivo(Factura factura)
        {
            string rutaArchivo = "facturas.csv";

            try
            {
                using (StreamWriter escritor = new StreamWriter(rutaArchivo, true))
                {
                    escritor.WriteLine($"{factura.NumeroFactura},{factura.FechaEmision},{factura.Cliente},{factura.Monto},{factura.Estado}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la factura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnEmitirFacturasMensuales_Click(object sender, EventArgs e)
        {
            var facturasPendientes = listaFacturas.Where(f => f.Estado == "Pendiente" && f.FechaEmision.Month == DateTime.Now.Month).ToList();
            foreach (var factura in facturasPendientes)
            {
                factura.Estado = "Emitida";
            }

            MessageBox.Show($"Se han emitido {facturasPendientes.Count} facturas para este mes.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ActualizarListaFacturas();
        }
    }
    
}
