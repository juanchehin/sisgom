﻿using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.IO;
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
                //Hilo = new Thread(new ThreadStart(executa));
                this.executa();
                this.Close();
            }
            else
            {
                MessageBox.Show("Selecciona una ruta donde guardar las copias de seguridad", "SisGom", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRuta.Focus();
                txtRuta.BackColor = Color.FromArgb(255, 255, 192);
            }
        }

		public void executa()
		{
            string rpta = "";
			string miCarpeta = "backup_sisgom_" + DateTime.Now.Day + "_" + (DateTime.Now.Month) + "_" + DateTime.Now.Year + "_" + Convert.ToDateTime(DateAndTime.TimeOfDay).Hour + "_" + Convert.ToDateTime(DateAndTime.TimeOfDay).Minute;
			
			if (!Directory.Exists(txtRuta.Text + miCarpeta))
			{
				Directory.CreateDirectory(txtRuta.Text + miCarpeta);
			}

			string ruta_completa = txtRuta.Text + "\\" + miCarpeta;

            //string SubCarpeta = ruta_completa + "\\Respaldo_al_" + DateTime.Now.Day + "_" + Microsoft.VisualBasic.DateAndTime.MonthName(DateTime.Now.Month) + "_" + DateTime.Now.Year + "_" + Convert.ToDateTime(Microsoft.VisualBasic.DateAndTime.TimeOfDay).Hour + "_" + Convert.ToDateTime(Microsoft.VisualBasic.DateAndTime.TimeOfDay).Minute;


            try
            {
                string v_nombre_respaldo = ruta_completa + ".sql";

                if(CapaNegocio.CN_Configuracion.Backup(v_nombre_respaldo) == "Ok")
                {
                    MensajeOk("Backup creado con exito");
                }

            }
            catch (Exception ex)
            {
                MensajeError(ex.Message);
            }

		}

        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "SisGom", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "SisGom", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
