namespace CapaPresentacion
{
    partial class formActualizarPrecios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formActualizarPrecios));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbLineal = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPorcentual = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.rdLineal = new System.Windows.Forms.RadioButton();
            this.rbPorcentual = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDesdeArticulo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbHastaArticulo = new System.Windows.Forms.TextBox();
            this.cbActualizarTodos = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 57);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Actualizacion lineal:";
            // 
            // tbLineal
            // 
            this.tbLineal.Location = new System.Drawing.Point(190, 36);
            this.tbLineal.Name = "tbLineal";
            this.tbLineal.Size = new System.Drawing.Size(100, 20);
            this.tbLineal.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbPorcentual);
            this.groupBox1.Controls.Add(this.rdLineal);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbPorcentual);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbLineal);
            this.groupBox1.Location = new System.Drawing.Point(15, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 128);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de actualizacion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Actualizacion porcentual (%):";
            // 
            // tbPorcentual
            // 
            this.tbPorcentual.Location = new System.Drawing.Point(190, 70);
            this.tbPorcentual.Name = "tbPorcentual";
            this.tbPorcentual.Size = new System.Drawing.Size(100, 20);
            this.tbPorcentual.TabIndex = 7;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(403, 298);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(484, 298);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // rdLineal
            // 
            this.rdLineal.AutoSize = true;
            this.rdLineal.Location = new System.Drawing.Point(21, 39);
            this.rdLineal.Name = "rdLineal";
            this.rdLineal.Size = new System.Drawing.Size(14, 13);
            this.rdLineal.TabIndex = 4;
            this.rdLineal.TabStop = true;
            this.rdLineal.UseVisualStyleBackColor = true;
            // 
            // rbPorcentual
            // 
            this.rbPorcentual.AutoSize = true;
            this.rbPorcentual.Location = new System.Drawing.Point(21, 71);
            this.rbPorcentual.Name = "rbPorcentual";
            this.rbPorcentual.Size = new System.Drawing.Size(14, 13);
            this.rbPorcentual.TabIndex = 6;
            this.rbPorcentual.TabStop = true;
            this.rbPorcentual.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Desde articulo : ";
            // 
            // tbDesdeArticulo
            // 
            this.tbDesdeArticulo.Location = new System.Drawing.Point(244, 93);
            this.tbDesdeArticulo.Name = "tbDesdeArticulo";
            this.tbDesdeArticulo.Size = new System.Drawing.Size(100, 20);
            this.tbDesdeArticulo.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(357, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Hasta articulo : ";
            // 
            // tbHastaArticulo
            // 
            this.tbHastaArticulo.Location = new System.Drawing.Point(444, 92);
            this.tbHastaArticulo.Name = "tbHastaArticulo";
            this.tbHastaArticulo.Size = new System.Drawing.Size(100, 20);
            this.tbHastaArticulo.TabIndex = 3;
            // 
            // cbActualizarTodos
            // 
            this.cbActualizarTodos.AutoSize = true;
            this.cbActualizarTodos.Location = new System.Drawing.Point(12, 95);
            this.cbActualizarTodos.Name = "cbActualizarTodos";
            this.cbActualizarTodos.Size = new System.Drawing.Size(101, 17);
            this.cbActualizarTodos.TabIndex = 1;
            this.cbActualizarTodos.Text = "Actualizar todos";
            this.cbActualizarTodos.UseVisualStyleBackColor = true;
            // 
            // formActualizarPrecios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 333);
            this.Controls.Add(this.cbActualizarTodos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbHastaArticulo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbDesdeArticulo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formActualizarPrecios";
            this.Text = "Actualizacion de precios";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLineal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPorcentual;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.RadioButton rbPorcentual;
        private System.Windows.Forms.RadioButton rdLineal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDesdeArticulo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbHastaArticulo;
        private System.Windows.Forms.CheckBox cbActualizarTodos;
    }
}