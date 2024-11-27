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
using SistemaGestionGimnasio.DataHandler;

namespace SistemaGestionGimnasio.FormulariosUsuarios
{
    public partial class GestionFacturasForm : Form
    {
        private readonly IDataHandler dataHandler;

        private List<Factura> listaFacturas = new List<Factura>();
        public GestionFacturasForm(IDataHandler dataHandler)
        {
            InitializeComponent();

            CmbEstado.Items.AddRange(new string[] { "Pagada", "Pendiente" });
            CargarFacturas();
            ActualizarListaFacturas();
            this.dataHandler = dataHandler;
        }

        private void BtnGenerarFactura(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtCliente.Text) || string.IsNullOrWhiteSpace(TxtMonto.Text) || CmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crea la nueva factura
            int numeroFactura = listaFacturas.Count + 1;
            DateTime fechaEmision = DateTime.Now;
            string cliente = TxtCliente.Text.Trim();
            double monto = double.Parse(TxtMonto.Text);
            string estado = CmbEstado.SelectedItem.ToString();

            Factura nuevaFactura = new Factura(numeroFactura, fechaEmision, cliente, monto, estado);
            listaFacturas.Add(nuevaFactura);

            GuardarFacturaEnArchivo(nuevaFactura, dataHandler);

            MessageBox.Show("Factura generada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpia campos
            TxtCliente.Clear();
            TxtMonto.Clear();
            CmbEstado.SelectedIndex = -1;

            // Actualiza la lista
            ActualizarListaFacturas();
        }

        private void CargarFacturas()
        {
            string rutaArchivo = "facturas.csv";

            if (!dataHandler.FileExists(rutaArchivo))
            {
                MessageBox.Show("No se encontraron facturas previas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                listaFacturas.Clear();
                foreach (var linea in dataHandler.ReadAllLines(rutaArchivo))
                {
                    string[] datos = linea.Split(',');

                    if (datos.Length >= 5)
                    {
                        int numeroFactura = int.Parse(datos[0]);
                        DateTime fechaEmision = DateTime.Parse(datos[1], System.Globalization.CultureInfo.InvariantCulture);
                        string cliente = datos[2];
                        double monto = double.Parse(datos[3]);
                        string estado = datos[4];

                        listaFacturas.Add(new Factura(numeroFactura, fechaEmision, cliente, monto, estado));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las facturas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarListaFacturas()
        {
            DgvFacturas.Rows.Clear();

            foreach (var factura in listaFacturas)
            {
                DgvFacturas.Rows.Add(factura.NumeroFactura, factura.FechaEmision.ToShortDateString(), factura.Cliente, factura.Estado);
            }
        }

        private static void GuardarFacturaEnArchivo(Factura factura, IDataHandler dataHandler)
        {
            string rutaArchivo = "facturas.csv";

            try
            {
                string nuevaLinea = $"{factura.NumeroFactura},{factura.FechaEmision},{factura.Cliente},{factura.Monto},{factura.Estado}";
                dataHandler.AppendLine(rutaArchivo, nuevaLinea);
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
