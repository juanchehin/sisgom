using CapaPresentacion.Configuraciones;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class formConfiguraciones : Form
    {
        public formConfiguraciones()
        {
            InitializeComponent();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            formBackup frm = new formBackup();
            frm.Show();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            formImportacionBD frm = new formImportacionBD();
            frm.Show();
        }
    }
}
