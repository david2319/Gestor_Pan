namespace Pan {
    partial class Ayuda {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ayuda));
            this.tabsHelp = new System.Windows.Forms.TabControl();
            this.tabMenu = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.bHelpAyuda = new System.Windows.Forms.Button();
            this.bHelpConfiguracion = new System.Windows.Forms.Button();
            this.bHelpModificar = new System.Windows.Forms.Button();
            this.lHelp = new System.Windows.Forms.Label();
            this.rtHelpMenu = new System.Windows.Forms.RichTextBox();
            this.bHelpInsertar = new System.Windows.Forms.Button();
            this.tabInsertar = new System.Windows.Forms.TabPage();
            this.rtHelpInsertar = new System.Windows.Forms.RichTextBox();
            this.tabModificar = new System.Windows.Forms.TabPage();
            this.rtHelpModificar = new System.Windows.Forms.RichTextBox();
            this.bCerrarHelp = new System.Windows.Forms.Button();
            this.tabConfiguracion = new System.Windows.Forms.TabPage();
            this.picMenu = new System.Windows.Forms.PictureBox();
            this.picInsertar = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.rtHelpConfiguracion = new System.Windows.Forms.RichTextBox();
            this.tabsHelp.SuspendLayout();
            this.tabMenu.SuspendLayout();
            this.tabInsertar.SuspendLayout();
            this.tabModificar.SuspendLayout();
            this.tabConfiguracion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInsertar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabsHelp
            // 
            this.tabsHelp.Controls.Add(this.tabMenu);
            this.tabsHelp.Controls.Add(this.tabInsertar);
            this.tabsHelp.Controls.Add(this.tabModificar);
            this.tabsHelp.Controls.Add(this.tabConfiguracion);
            this.tabsHelp.Location = new System.Drawing.Point(2, 0);
            this.tabsHelp.Name = "tabsHelp";
            this.tabsHelp.SelectedIndex = 0;
            this.tabsHelp.Size = new System.Drawing.Size(844, 480);
            this.tabsHelp.TabIndex = 1;
            // 
            // tabMenu
            // 
            this.tabMenu.BackColor = System.Drawing.Color.LightGray;
            this.tabMenu.Controls.Add(this.label1);
            this.tabMenu.Controls.Add(this.bHelpAyuda);
            this.tabMenu.Controls.Add(this.bHelpConfiguracion);
            this.tabMenu.Controls.Add(this.bHelpModificar);
            this.tabMenu.Controls.Add(this.lHelp);
            this.tabMenu.Controls.Add(this.rtHelpMenu);
            this.tabMenu.Controls.Add(this.bHelpInsertar);
            this.tabMenu.Controls.Add(this.picMenu);
            this.tabMenu.Location = new System.Drawing.Point(4, 22);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.Padding = new System.Windows.Forms.Padding(3);
            this.tabMenu.Size = new System.Drawing.Size(836, 454);
            this.tabMenu.TabIndex = 0;
            this.tabMenu.Text = "Menu";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(128, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 27);
            this.label1.TabIndex = 5;
            this.label1.Text = "Pulsa un botón";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bHelpAyuda
            // 
            this.bHelpAyuda.BackColor = System.Drawing.Color.Goldenrod;
            this.bHelpAyuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bHelpAyuda.Location = new System.Drawing.Point(226, 228);
            this.bHelpAyuda.Name = "bHelpAyuda";
            this.bHelpAyuda.Size = new System.Drawing.Size(88, 23);
            this.bHelpAyuda.TabIndex = 5;
            this.bHelpAyuda.Tag = "ayuda";
            this.bHelpAyuda.Text = "Ayuda";
            this.bHelpAyuda.UseVisualStyleBackColor = false;
            this.bHelpAyuda.Click += new System.EventHandler(this.fHelp);
            // 
            // bHelpConfiguracion
            // 
            this.bHelpConfiguracion.BackColor = System.Drawing.Color.Gold;
            this.bHelpConfiguracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bHelpConfiguracion.Location = new System.Drawing.Point(111, 228);
            this.bHelpConfiguracion.Name = "bHelpConfiguracion";
            this.bHelpConfiguracion.Size = new System.Drawing.Size(88, 23);
            this.bHelpConfiguracion.TabIndex = 3;
            this.bHelpConfiguracion.Tag = "configuracion";
            this.bHelpConfiguracion.Text = "Configuración";
            this.bHelpConfiguracion.UseVisualStyleBackColor = false;
            this.bHelpConfiguracion.Click += new System.EventHandler(this.fHelp);
            // 
            // bHelpModificar
            // 
            this.bHelpModificar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.bHelpModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bHelpModificar.Location = new System.Drawing.Point(226, 176);
            this.bHelpModificar.Name = "bHelpModificar";
            this.bHelpModificar.Size = new System.Drawing.Size(88, 23);
            this.bHelpModificar.TabIndex = 3;
            this.bHelpModificar.Tag = "modificar";
            this.bHelpModificar.Text = "Modificar";
            this.bHelpModificar.UseVisualStyleBackColor = false;
            this.bHelpModificar.Click += new System.EventHandler(this.fHelp);
            // 
            // lHelp
            // 
            this.lHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lHelp.Location = new System.Drawing.Point(519, 95);
            this.lHelp.Name = "lHelp";
            this.lHelp.Size = new System.Drawing.Size(165, 27);
            this.lHelp.TabIndex = 4;
            this.lHelp.Text = "Insertar";
            this.lHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtHelpMenu
            // 
            this.rtHelpMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtHelpMenu.Location = new System.Drawing.Point(454, 127);
            this.rtHelpMenu.Name = "rtHelpMenu";
            this.rtHelpMenu.ReadOnly = true;
            this.rtHelpMenu.Size = new System.Drawing.Size(299, 220);
            this.rtHelpMenu.TabIndex = 3;
            this.rtHelpMenu.Text = "";
            // 
            // bHelpInsertar
            // 
            this.bHelpInsertar.BackColor = System.Drawing.Color.Lime;
            this.bHelpInsertar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bHelpInsertar.Location = new System.Drawing.Point(111, 176);
            this.bHelpInsertar.Name = "bHelpInsertar";
            this.bHelpInsertar.Size = new System.Drawing.Size(88, 23);
            this.bHelpInsertar.TabIndex = 2;
            this.bHelpInsertar.Tag = "insertar";
            this.bHelpInsertar.Text = "Insertar";
            this.bHelpInsertar.UseVisualStyleBackColor = false;
            this.bHelpInsertar.Click += new System.EventHandler(this.fHelp);
            // 
            // tabInsertar
            // 
            this.tabInsertar.BackColor = System.Drawing.Color.LightGray;
            this.tabInsertar.Controls.Add(this.rtHelpInsertar);
            this.tabInsertar.Controls.Add(this.picInsertar);
            this.tabInsertar.Location = new System.Drawing.Point(4, 22);
            this.tabInsertar.Name = "tabInsertar";
            this.tabInsertar.Padding = new System.Windows.Forms.Padding(3);
            this.tabInsertar.Size = new System.Drawing.Size(836, 454);
            this.tabInsertar.TabIndex = 1;
            this.tabInsertar.Text = "Insertar";
            // 
            // rtHelpInsertar
            // 
            this.rtHelpInsertar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtHelpInsertar.Location = new System.Drawing.Point(505, 71);
            this.rtHelpInsertar.Name = "rtHelpInsertar";
            this.rtHelpInsertar.Size = new System.Drawing.Size(331, 305);
            this.rtHelpInsertar.TabIndex = 1;
            this.rtHelpInsertar.Text = "";
            // 
            // tabModificar
            // 
            this.tabModificar.BackColor = System.Drawing.Color.LightGray;
            this.tabModificar.Controls.Add(this.rtHelpModificar);
            this.tabModificar.Controls.Add(this.pictureBox1);
            this.tabModificar.Location = new System.Drawing.Point(4, 22);
            this.tabModificar.Name = "tabModificar";
            this.tabModificar.Padding = new System.Windows.Forms.Padding(3);
            this.tabModificar.Size = new System.Drawing.Size(836, 454);
            this.tabModificar.TabIndex = 2;
            this.tabModificar.Text = "Modificar";
            // 
            // rtHelpModificar
            // 
            this.rtHelpModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtHelpModificar.Location = new System.Drawing.Point(505, 71);
            this.rtHelpModificar.Name = "rtHelpModificar";
            this.rtHelpModificar.Size = new System.Drawing.Size(331, 305);
            this.rtHelpModificar.TabIndex = 1;
            this.rtHelpModificar.Text = "";
            // 
            // bCerrarHelp
            // 
            this.bCerrarHelp.BackColor = System.Drawing.Color.Red;
            this.bCerrarHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCerrarHelp.Location = new System.Drawing.Point(366, 486);
            this.bCerrarHelp.Name = "bCerrarHelp";
            this.bCerrarHelp.Size = new System.Drawing.Size(75, 23);
            this.bCerrarHelp.TabIndex = 2;
            this.bCerrarHelp.Text = "Cerrar";
            this.bCerrarHelp.UseVisualStyleBackColor = false;
            this.bCerrarHelp.Click += new System.EventHandler(this.fCerrarHelp);
            // 
            // tabConfiguracion
            // 
            this.tabConfiguracion.BackColor = System.Drawing.Color.LightGray;
            this.tabConfiguracion.Controls.Add(this.rtHelpConfiguracion);
            this.tabConfiguracion.Controls.Add(this.pictureBox2);
            this.tabConfiguracion.Location = new System.Drawing.Point(4, 22);
            this.tabConfiguracion.Name = "tabConfiguracion";
            this.tabConfiguracion.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfiguracion.Size = new System.Drawing.Size(836, 454);
            this.tabConfiguracion.TabIndex = 3;
            this.tabConfiguracion.Text = "Configuración";
            // 
            // picMenu
            // 
            this.picMenu.Image = global::Pan.Properties.Resources.menu;
            this.picMenu.Location = new System.Drawing.Point(86, 127);
            this.picMenu.Name = "picMenu";
            this.picMenu.Size = new System.Drawing.Size(256, 220);
            this.picMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMenu.TabIndex = 0;
            this.picMenu.TabStop = false;
            // 
            // picInsertar
            // 
            this.picInsertar.Image = global::Pan.Properties.Resources.insertar;
            this.picInsertar.Location = new System.Drawing.Point(0, 0);
            this.picInsertar.Name = "picInsertar";
            this.picInsertar.Size = new System.Drawing.Size(505, 454);
            this.picInsertar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picInsertar.TabIndex = 0;
            this.picInsertar.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Pan.Properties.Resources.modificar;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(505, 454);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Pan.Properties.Resources.configuracion;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(548, 453);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // rtHelpConfiguracion
            // 
            this.rtHelpConfiguracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtHelpConfiguracion.Location = new System.Drawing.Point(546, 60);
            this.rtHelpConfiguracion.Name = "rtHelpConfiguracion";
            this.rtHelpConfiguracion.Size = new System.Drawing.Size(290, 305);
            this.rtHelpConfiguracion.TabIndex = 2;
            this.rtHelpConfiguracion.Text = "";
            // 
            // Ayuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 521);
            this.Controls.Add(this.bCerrarHelp);
            this.Controls.Add(this.tabsHelp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Ayuda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ayuda";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fSalirApp);
            this.tabsHelp.ResumeLayout(false);
            this.tabMenu.ResumeLayout(false);
            this.tabMenu.PerformLayout();
            this.tabInsertar.ResumeLayout(false);
            this.tabModificar.ResumeLayout(false);
            this.tabConfiguracion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInsertar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabsHelp;
        private System.Windows.Forms.TabPage tabMenu;
        private System.Windows.Forms.PictureBox picMenu;
        private System.Windows.Forms.TabPage tabInsertar;
        private System.Windows.Forms.Button bHelpInsertar;
        private System.Windows.Forms.RichTextBox rtHelpMenu;
        private System.Windows.Forms.Button bCerrarHelp;
        private System.Windows.Forms.Label lHelp;
        private System.Windows.Forms.Button bHelpModificar;
        private System.Windows.Forms.Button bHelpConfiguracion;
        private System.Windows.Forms.Button bHelpAyuda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picInsertar;
        private System.Windows.Forms.RichTextBox rtHelpInsertar;
        private System.Windows.Forms.TabPage tabModificar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox rtHelpModificar;
        private System.Windows.Forms.TabPage tabConfiguracion;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RichTextBox rtHelpConfiguracion;
    }
}