using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUICliente2.Service;
using GUICliente2.Model;
using GUICliente2.View;


namespace GUICliente2
{
    public partial class ListarInstrumentos : Form
    {
        
        private readonly ServicioInstrumento _servicio;
        private string url = "http://localhost:8090/";


        public ListarInstrumentos()
        {
            InitializeComponent();
            _servicio = new ServicioInstrumento(url);
        }

        private async void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = false;

                var instrumentos = await _servicio.ListarInstrumentos();


                dataGridView1.DataSource = instrumentos;

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.AutoResizeColumns();

                if (instrumentos.Count == 0)
                {
                    MessageBox.Show("No se encontraron instrumentos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los instrumentos:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                button1.Enabled = true;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnFiltros_Click(object sender, EventArgs e)
        {
            Filtros gui = new();
            gui.Show();
        }
    }
}
