using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

using System.Collections.Generic;

using System.IO;
using System.Management;
using System.Xml;
using Microsoft.VisualBasic;

namespace CapaPresentacion
{
    public partial class formBackup : Form
    {
        public formBackup()
        {
            InitializeComponent();
        }
		private Thread Hilo;
		private void textBox1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = ofd.SelectedPath;
            }
        }

        private void btnGenerarBackup_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRuta.Text))
            {
                Hilo = new Thread(new ThreadStart(executa));
                txtRuta.BackColor = Color.White;
                //PictureBox1.Visible = true;
                //Panel1.Enabled = false;
                //lbldirectorio.Visible = false;
                //Panel2.Visible = false;
                //Hilo.Start();
                //acaba = false;
                //Timer1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Selecciona una Ruta donde Guardar las Copias de Seguridad", "Seleccione Ruta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRuta.Focus();
                txtRuta.BackColor = Color.FromArgb(255, 255, 192);
            }
        }

		public void executa()
		{
			//LeerXML_Nombre_De_software();
			//LeerXML_base_de_datos();
			string miCarpeta = "backup_sisgom" + DateTime.Now.Day + "_" + (DateTime.Now.Month) + "_" + DateTime.Now.Year + "_" + Convert.ToDateTime(DateAndTime.TimeOfDay).Hour + "_" + Convert.ToDateTime(DateAndTime.TimeOfDay).Minute;
			MessageBox.Show($"miCarpeta executa() es : {miCarpeta}");
			if (!Directory.Exists(txtRuta.Text + miCarpeta))
			{
				Directory.CreateDirectory(txtRuta.Text + miCarpeta);
			}

			string ruta_completa = txtRuta.Text + "\\" + miCarpeta;

            //string SubCarpeta = ruta_completa + "\\Respaldo_al_" + DateTime.Now.Day + "_" + Microsoft.VisualBasic.DateAndTime.MonthName(DateTime.Now.Month) + "_" + DateTime.Now.Year + "_" + Convert.ToDateTime(Microsoft.VisualBasic.DateAndTime.TimeOfDay).Hour + "_" + Convert.ToDateTime(Microsoft.VisualBasic.DateAndTime.TimeOfDay).Minute;


            try
            {
                string v_nombre_respaldo = miCarpeta + ".bak";

                CapaNegocio.CN_Configuracion.Backup();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

		}
	}
}
