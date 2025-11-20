using GUICliente2.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUICliente2
{
    public partial class EliminarFunda : Form
    {

        private readonly ServicioInstrumento servicio;
        private string url = "http://localhost:8090/";

        public EliminarFunda()
        {
            InitializeComponent();
            servicio = new ServicioInstrumento(url);
        }

        private void AgregarFunda_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            string codigoGuitarra = textCGuitarra.Text.Trim();
            string codigoFunda = textCFunda.Text.Trim();

            if (string.IsNullOrEmpty(codigoGuitarra) || string.IsNullOrEmpty(codigoFunda))
            {
                MessageBox.Show("Por favor, ingresa ambos códigos (guitarra y funda).",
                                "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show($"¿Está seguro de eliminar la funda con código {codigoFunda} de la guitarra {codigoGuitarra}?",
                                                "Confirmar eliminación",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                bool eliminado = await servicio.EliminarFunda(codigoGuitarra, codigoFunda);

                if (eliminado)
                {
                    MessageBox.Show("Funda eliminada correctamente.",
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpia campos tras eliminación
                    textCFunda.Clear();
                    textNombre.Clear();
                    textPrecio.Clear();
                    textCGuitarra.Clear();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la funda.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la funda: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            string codigoGuitarra = textCGuitarra.Text.Trim();
            string codigoFunda = textCFunda.Text.Trim();

            if (string.IsNullOrEmpty(codigoGuitarra) || string.IsNullOrEmpty(codigoFunda))
            {
                MessageBox.Show("Por favor, ingresa ambos códigos (guitarra y funda).",
                                "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var funda = await servicio.buscarFunda(codigoGuitarra, codigoFunda);

                if (funda == null)
                {
                    MessageBox.Show("No se encontró la funda especificada.", "Sin resultados",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textNombre.Text = "";
                    textPrecio.Text = "";
                    return;
                }

                textNombre.Text = funda.Nombre;
                textPrecio.Text = funda.Precio.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar la funda: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
