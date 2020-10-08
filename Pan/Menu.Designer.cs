namespace Pan
{
    partial class Menu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.bInsertar = new System.Windows.Forms.Button();
            this.bModificar = new System.Windows.Forms.Button();
            this.bConfiguracion = new System.Windows.Forms.Button();
            this.bSalir = new System.Windows.Forms.Button();
            this.bAyuda = new System.Windows.Forms.Button();
            this.lVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bInsertar
            // 
            this.bInsertar.BackColor = System.Drawing.Color.Lime;
            this.bInsertar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bInsertar.Location = new System.Drawing.Point(26, 21);
            this.bInsertar.Name = "bInsertar";
            this.bInsertar.Size = new System.Drawing.Size(88, 23);
            this.bInsertar.TabIndex = 0;
            this.bInsertar.Tag = "insertarMenu";
            this.bInsertar.Text = "Insertar";
            this.bInsertar.UseVisualStyleBackColor = false;
            this.bInsertar.Click += new System.EventHandler(this.fMenu);
            // 
            // bModificar
            // 
            this.bModificar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.bModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bModificar.Location = new System.Drawing.Point(141, 21);
            this.bModificar.Name = "bModificar";
            this.bModificar.Size = new System.Drawing.Size(88, 23);
            this.bModificar.TabIndex = 1;
            this.bModificar.Tag = "modificarMenu";
            this.bModificar.Text = "Modificar";
            this.bModificar.UseVisualStyleBackColor = false;
            this.bModificar.Click += new System.EventHandler(this.fMenu);
            // 
            // bConfiguracion
            // 
            this.bConfiguracion.BackColor = System.Drawing.Color.Gold;
            this.bConfiguracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bConfiguracion.Location = new System.Drawing.Point(26, 73);
            this.bConfiguracion.Name = "bConfiguracion";
            this.bConfiguracion.Size = new System.Drawing.Size(88, 23);
            this.bConfiguracion.TabIndex = 2;
            this.bConfiguracion.Tag = "configuracionMenu";
            this.bConfiguracion.Text = "Configuración";
            this.bConfiguracion.UseVisualStyleBackColor = false;
            this.bConfiguracion.Click += new System.EventHandler(this.fMenu);
            // 
            // bSalir
            // 
            this.bSalir.BackColor = System.Drawing.Color.Red;
            this.bSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSalir.Location = new System.Drawing.Point(83, 157);
            this.bSalir.Name = "bSalir";
            this.bSalir.Size = new System.Drawing.Size(88, 23);
            this.bSalir.TabIndex = 3;
            this.bSalir.Text = "Salir";
            this.bSalir.UseVisualStyleBackColor = false;
            this.bSalir.Click += new System.EventHandler(this.fSalir);
            // 
            // bAyuda
            // 
            this.bAyuda.BackColor = System.Drawing.Color.Goldenrod;
            this.bAyuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAyuda.Location = new System.Drawing.Point(141, 73);
            this.bAyuda.Name = "bAyuda";
            this.bAyuda.Size = new System.Drawing.Size(88, 23);
            this.bAyuda.TabIndex = 4;
            this.bAyuda.Tag = "ayudaMenu";
            this.bAyuda.Text = "Ayuda";
            this.bAyuda.UseVisualStyleBackColor = false;
            this.bAyuda.Click += new System.EventHandler(this.fMenu);
            // 
            // lVersion
            // 
            this.lVersion.AutoSize = true;
            this.lVersion.Location = new System.Drawing.Point(210, 171);
            this.lVersion.Name = "lVersion";
            this.lVersion.Size = new System.Drawing.Size(0, 13);
            this.lVersion.TabIndex = 5;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 193);
            this.Controls.Add(this.lVersion);
            this.Controls.Add(this.bAyuda);
            this.Controls.Add(this.bSalir);
            this.Controls.Add(this.bConfiguracion);
            this.Controls.Add(this.bModificar);
            this.Controls.Add(this.bInsertar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fExitApp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bInsertar;
        private System.Windows.Forms.Button bModificar;
        private System.Windows.Forms.Button bConfiguracion;
        private System.Windows.Forms.Button bSalir;
        private System.Windows.Forms.Button bAyuda;
        private System.Windows.Forms.Label lVersion;
    }
}

