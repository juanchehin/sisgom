﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;
using CapaNegocio;
using System.Data;

namespace CapaPresentacion
{
    public partial class formTrabajosEmpleado : Form
    {
        private int parametroTE;    // IdEmpleado
        private int total = 0;
        CN_TrabajosEmpleado objetoCN = new CN_TrabajosEmpleado();
        CN_Empleados objetoCN_emp = new CN_Empleados();
        private DateTime FechaFin = DateTime.Today; // Fecha actual
        private DateTime FechaInicio = DateTime.Today.AddDays(-7);// Una semana antes

        private string imprimirFechaInicio;
        private string imprimirFechaFin;


        private int IdEmpleado;
        private string Nombre;
        private string Apellidos;
        private string DNI;
        private string Direccion;
        private string Telefono;

        public formTrabajosEmpleado(int parametro)
        {
            InitializeComponent();
            this.parametroTE = parametro;
            dtFechaFin.Value = DateTime.Today;
            dtFechaInicio.Value = DateTime.Today.AddDays(-7);
            this.btnRefrescar.Focus();
        }
        private void formTrabajosEmpleado_Load(object sender, EventArgs e)
        {
            this.FechaInicio = dtFechaInicio.Value;
            this.FechaFin = dtFechaFin.Value;
            //MostrarTrabajosEmpleado(this.parametroTE, this.FechaInicio, this.FechaFin);
            CargarDatos(this.parametroTE);
            // dtFechaInicio.Focus();
        }

        // =========================================================
        //  MOSTRAR EMPLEADOS - Carga los trabajos en el DataGridView
        // =========================================================

        private void MostrarTrabajosEmpleado(int IdEmpleado, DateTime FechaInicio,DateTime FechaFin)
        {
            var añoInicio = FechaInicio.Year;
            var mesInicio = FechaInicio.Month;
            var diaInicio = FechaInicio.Day;
            var fechaInicio = añoInicio + "-" + mesInicio + "-" + diaInicio;


            var añoFin = FechaFin.Year;
            var mesFin = FechaFin.Month;
            var diaFin = FechaFin.Day;
            var fechaFin = añoFin + "-" + mesFin + "-" + diaFin;

            dataListadoTrabajosEmpleado.DataSource = objetoCN.MostrarTrabajosEmpleado(IdEmpleado, fechaInicio, fechaFin);
            if(dataListadoTrabajosEmpleado.DataSource == null)
            {
                MensajeError("El empleado no posee trabajos");
                this.Close();
                return;
            }

            // Seteo estos valores para usarlo mas abajo en metodo DVPrintDocument_PrintPage
            this.imprimirFechaInicio = fechaInicio;
            this.imprimirFechaFin = fechaFin;

            if (dataListadoTrabajosEmpleado.RowCount <= 0)
            {
                dataListadoTrabajosEmpleado.DataSource = null;
                MensajeOk("El empleado no posee trabajos en este rango de fechas");
                return;
            }

            // Multiplico cantidad * PrecioUnitario para obtener el total de i-esima fila
            foreach (DataGridViewRow row in dataListadoTrabajosEmpleado.Rows)
            {
                row.Cells[0].Value = Convert.ToInt32(row.Cells[6].Value) * Convert.ToInt32(row.Cells[7].Value);
                this.total = this.total + Convert.ToInt32(row.Cells[0].Value);
            }
            dataListadoTrabajosEmpleado.Columns["Total"].DisplayIndex = 7;  // Muevo la columna a la posicion de la derecha
            // Oculto el IdProducto al usuario. Lo puedo seguir usando como parametro de eliminacion
            lblApellidoNombre.Text = dataListadoTrabajosEmpleado.Rows[0].Cells[2].Value.ToString() + " , " + dataListadoTrabajosEmpleado.Rows[0].Cells[1].Value.ToString();
            lblDireccion.Text = dataListadoTrabajosEmpleado.Rows[0].Cells[3].Value.ToString();
            lblTelefono.Text = dataListadoTrabajosEmpleado.Rows[0].Cells[4].Value.ToString();

            dataListadoTrabajosEmpleado.Columns[1].Visible = false;
            dataListadoTrabajosEmpleado.Columns[2].Visible = false;
            dataListadoTrabajosEmpleado.Columns[3].Visible = false;
            dataListadoTrabajosEmpleado.Columns[4].Visible = false;

            // Nota : Nombre es row.Cells[1].Value
            this.lblTotal.Text = this.total.ToString();
        }

        // Carga los datos (apellido,nombre,direccion) en el formulario
        private void CargarDatos(int IdEmpleado)
        {

            var respuesta = objetoCN_emp.MostrarEmpleado(IdEmpleado);


            foreach (DataRow row in respuesta.Rows)
            {
                IdEmpleado = Convert.ToInt32(row["IdEmpleado"]);
                Nombre = Convert.ToString(row["Nombre"]);
                Apellidos = Convert.ToString(row["Apellidos"]);
                DNI = Convert.ToString(row["DNI"]);
                Direccion = Convert.ToString(row["Direccion"]);
                Telefono = Convert.ToString(row["Telefono"]);
                
                lblApellidoNombre.Text = Apellidos + " , " + Nombre;
                lblDireccion.Text = Direccion;
                lblTelefono.Text = Telefono;
                lblDNI.Text = DNI;

            }

        }
        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            this.FechaInicio = dtFechaInicio.Value;
            this.FechaFin = dtFechaFin.Value;
            MostrarTrabajosEmpleado(this.parametroTE, this.FechaInicio,this.FechaFin);

        }

        private void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            DialogResult Opcion;
            Opcion = MessageBox.Show("Realmente Desea Eliminar el/los trabajos", "SisGom", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (Opcion == DialogResult.OK)
            {
                string Codigo;
                string Rpta = "";

                foreach (DataGridViewRow row in dataListadoTrabajosEmpleado.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        Codigo = Convert.ToString(row.Cells[1].Value);
                        Rpta = CN_Productos.Eliminar(Convert.ToInt32(Codigo));

                        if (Rpta.Equals("OK"))
                        {
                            this.MensajeOk("Se Eliminó Correctamente el/los trabajo del empleado");
                        }
                        else
                        {
                            this.MensajeError(Rpta);
                        }

                    }
                }
                // this.MostrarTrabajosEmpleado(this.parametroTE);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message + ex.StackTrace);
        }
    }

        private void lblApellidoNombre_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            DVPrintDocument.Print();
        }
        PrintDocument pd = new PrintDocument();
        private void btnVistaPreviaImprimir_Click(object sender, EventArgs e)
        {
            DVPrintPreviewDialog.Document = DVPrintDocument;
            DVPrintPreviewDialog.ShowDialog();
        }
        private int j= 5,i = 0;
        private int posicionAlto = 300;
        private int posicionAncho = 25;
        private int posicionAnchoBarra = 25;

        private void DVPrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bmp = Properties.Resources.logo_reducido;
            Image newImage = bmp;
            e.Graphics.DrawImage(newImage, 25 ,25, newImage.Width,newImage.Height);
            e.Graphics.DrawString("Apellidos y Nombres : " + lblApellidoNombre.Text, new  Font("Arial",20,FontStyle.Regular),Brushes.Black,new Point(25,100));
            e.Graphics.DrawString("Direccion : " + lblDireccion.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(25, 130));
            e.Graphics.DrawString("Telefono : " + lblTelefono.Text, new Font("Arial", 20,FontStyle.Regular), Brushes.Black, new Point(25, 160));

            e.Graphics.DrawString("______________________________________________________________________________", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 200));
            e.Graphics.DrawString("Trabajos realizados", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 230));  // + 90
            e.Graphics.DrawString("Precio Unitario", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(250, 230));
            e.Graphics.DrawString("Cantidad", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(400, 230));
            e.Graphics.DrawString("Total", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(600, 230));
            e.Graphics.DrawString("______________________________________________________________________________", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 250));
            e.Graphics.DrawString("______________________________________________________________________________", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 1030));
            e.Graphics.DrawString("Total : " + this.total, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(650, 1060));
            e.Graphics.DrawString("______________________________________________________________________________", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 1100));


            foreach (DataGridViewRow row in dataListadoTrabajosEmpleado.Rows)
            {
                // Mientras no exceda el maximo largo de la pagina, 1150
                if (this.posicionAlto < 1150)
                {
                    for (j = 5; j < 8; j++)
                    {
                        switch (j)
                        {
                            case 5:
                                this.posicionAncho = 25;
                                break;
                            case 6:
                                this.posicionAncho = 250;
                                break;
                            case 7:
                                this.posicionAncho = 410;
                                break;
                            case 8:
                                this.posicionAncho = 610;
                                break;
                        }
                        e.Graphics.DrawString(Convert.ToString(row.Cells[j].Value), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(this.posicionAncho, this.posicionAlto));
                    }
                    e.Graphics.DrawString(Convert.ToString(row.Cells[0].Value), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(610, this.posicionAlto)); // Total
                }
                  this.posicionAlto = this.posicionAlto + 40;
             this.posicionAncho = 25;
            }
        }

        private void btnImprimir_MouseHover(object sender, EventArgs e)
        {
            this.ttImprimir.SetToolTip(btnImprimir, "Imprimir");
        }

        private void btnVistaPreviaImprimir_MouseHover(object sender, EventArgs e)
        {
            this.ttPreviaImpresion.SetToolTip(btnVistaPreviaImprimir, "Vista Previa Impresion");
        }
    }
}
