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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listarInstrumentos_Click(object sender, EventArgs e)
        {
            ListarInstrumentos gui = new ListarInstrumentos();
            gui.Show();
        }

        private void listarGuitarra_Click(object sender, EventArgs e)
        {
            ListarGuitarra gui = new ListarGuitarra();
            gui.Show();
        }

        private void listarTeclado_Click(object sender, EventArgs e)
        {
            ListarTeclado gui = new ListarTeclado();
            gui.Show();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarGuitarra gui = new BuscarGuitarra();
            gui.Show();
        }

        private void agregarGuitarra_Click(object sender, EventArgs e)
        {
            AgregarGuitarra gui = new AgregarGuitarra();
            gui.Show();
        }

        private void agregarFundaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarFunda gui = new AgregarFunda();
            gui.Show();
        }

        private void actualizarFundaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActualizarFunda gui = new ActualizarFunda();
            gui.Show();
        }

        private void eliminarFundaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarFunda gui = new EliminarFunda();
            gui.Show();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActualizarGuitarra gui = new ActualizarGuitarra();
            gui.Show();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarGuitarra gui = new EliminarGuitarra();
            gui.Show();
        }

        private void agregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AgregarTeclado gui = new AgregarTeclado();
            gui.Show();
        }

        private void buscarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BuscarTeclado gui = new BuscarTeclado();
            gui.Show();
        }

        private void actualizartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActualizarTeclado gui = new ActualizarTeclado();
            gui.Show();
        }

        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EliminarTeclado gui = new EliminarTeclado();
            gui.Show();
        }
    }
}
