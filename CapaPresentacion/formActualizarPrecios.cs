using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class formActualizarPrecios : Form
    {
        public formActualizarPrecios()
        {
            InitializeComponent();
            
        }
        private void formActualizarPrecios_Load(object sender, EventArgs e)
        {
            cbActualizarTodos.Checked = true;
            tbDesdeArticulo.ReadOnly = true;
            tbHastaArticulo.ReadOnly = true;
            tbLineal.ReadOnly = true;

            rbLineal.Checked = false;
            rbPorcentual.Checked = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();                        
        }

        private void rbLineal_CheckedChanged(object sender, EventArgs e)
        {
            tbPorcentual.ReadOnly = false;
            tbLineal.ReadOnly = true;
        }
        private void rbPorcentual_CheckedChanged(object sender, EventArgs e)
        {
            tbLineal.ReadOnly = false;
            tbPorcentual.ReadOnly = true;
        }

        private void cbActualizarTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbActualizarTodos.Checked)
            {
                tbDesdeArticulo.ReadOnly = false;
                tbHastaArticulo.ReadOnly = false;
            }
            else
            {
                tbDesdeArticulo.ReadOnly = true;
                tbHastaArticulo.ReadOnly = true;
            }
            
        }

        private void lblPorcentual_Click(object sender, EventArgs e)
        {
            tbLineal.ReadOnly = false;
            tbPorcentual.ReadOnly = true;
            rbPorcentual.Checked = true;
        }

        private void lblLineal_Click(object sender, EventArgs e)
        {
            tbPorcentual.ReadOnly = false;
            tbLineal.ReadOnly = true;
            rbLineal.Checked = true;
        }
    }
}
