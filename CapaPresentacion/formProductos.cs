﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Agregados
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class formProductos : Form
    {
        CN_Productos objetoCN = new CN_Productos();

        private int  IdProducto;

        public formProductos()
        {
            InitializeComponent();
            MostrarProductos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }
        public void MostrarProductos()
        {
            dataListadoProductos.DataSource = objetoCN.MostrarProd();
            lblTotalProductos.Text = "Total de Registros: " + Convert.ToString(dataListadoProductos.Rows.Count);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BuscarProducto();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "SisGom", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "SisGom", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar el producto", "SisGom", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    CN_Productos.Eliminar(this.IdProducto);
                    this.MostrarProductos();
                    this.MensajeOk("Se elimino de forma correcta el producto");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            // this.Close();
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            formNuevoEditarProducto frm = new formNuevoEditarProducto(this.IdProducto,true);
            frm.MdiParent = this.MdiParent;
            frm.Show();
            // this.Close();
        }

        private void botonEditarListado_Click(object sender, EventArgs e)
        {
            formNuevoEditarProducto frm = new formNuevoEditarProducto(this.IdProducto,false);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void dataListadoProductos_SelectionChanged(object sender, EventArgs e)
        {

            if (dataListadoProductos.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataListadoProductos.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataListadoProductos.Rows[selectedrowindex];
                this.IdProducto = Convert.ToInt32(selectedRow.Cells["IdPRoducto"].Value);
            }
        }

        private void BuscarProducto()
        {
            this.dataListadoProductos.DataSource = objetoCN.BuscarProducto(this.txtBuscar.Text);
            lblTotalProductos.Text = "Total de Registros: " + Convert.ToString(dataListadoProductos.Rows.Count);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            this.MostrarProductos();
        }

        private void btnActualizarPrecios_Click(object sender, EventArgs e)
        {
            formActualizarPrecios frm = new formActualizarPrecios();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
    }
}
