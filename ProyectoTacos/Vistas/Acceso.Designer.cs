namespace ProyectoTacos
{
    partial class FRMAcceso
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
            this.TXTUsuario = new System.Windows.Forms.TextBox();
            this.TXTContrasena = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LBLCrear = new System.Windows.Forms.Label();
            this.BTNAcceder = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TXTUsuario
            // 
            this.TXTUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TXTUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TXTUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTUsuario.Location = new System.Drawing.Point(13, 27);
            this.TXTUsuario.Name = "TXTUsuario";
            this.TXTUsuario.Size = new System.Drawing.Size(226, 22);
            this.TXTUsuario.TabIndex = 0;
            this.TXTUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TXTUsuario.TextChanged += new System.EventHandler(this.TXTUsuario_TextChanged);
            this.TXTUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TXTUsuario_KeyPress);
            // 
            // TXTContrasena
            // 
            this.TXTContrasena.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TXTContrasena.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TXTContrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTContrasena.Location = new System.Drawing.Point(13, 73);
            this.TXTContrasena.Name = "TXTContrasena";
            this.TXTContrasena.PasswordChar = '■';
            this.TXTContrasena.Size = new System.Drawing.Size(226, 22);
            this.TXTContrasena.TabIndex = 1;
            this.TXTContrasena.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TXTContrasena.TextChanged += new System.EventHandler(this.TXTContrasena_TextChanged);
            this.TXTContrasena.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TXTUsuario_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nombre de usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Contraseña";
            // 
            // LBLCrear
            // 
            this.LBLCrear.AutoSize = true;
            this.LBLCrear.Location = new System.Drawing.Point(77, 131);
            this.LBLCrear.Name = "LBLCrear";
            this.LBLCrear.Size = new System.Drawing.Size(101, 13);
            this.LBLCrear.TabIndex = 7;
            this.LBLCrear.Text = "Crear cuenta nueva";
            this.LBLCrear.Click += new System.EventHandler(this.LBLCrear_Click);
            // 
            // BTNAcceder
            // 
            this.BTNAcceder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNAcceder.Location = new System.Drawing.Point(90, 103);
            this.BTNAcceder.Name = "BTNAcceder";
            this.BTNAcceder.Size = new System.Drawing.Size(75, 23);
            this.BTNAcceder.TabIndex = 6;
            this.BTNAcceder.Text = "Acceder";
            this.BTNAcceder.UseVisualStyleBackColor = true;
            this.BTNAcceder.Click += new System.EventHandler(this.BTNAcceder_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.LBLCrear);
            this.panel2.Controls.Add(this.TXTContrasena);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.TXTUsuario);
            this.panel2.Controls.Add(this.BTNAcceder);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 128);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(252, 155);
            this.panel2.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::ProyectoTacos.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(76, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(252, 120);
            this.panel1.TabIndex = 6;
            // 
            // FRMAcceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(275, 295);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRMAcceso";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox TXTUsuario;
        private System.Windows.Forms.TextBox TXTContrasena;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTNAcceder;
        private System.Windows.Forms.Label LBLCrear;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
    }
}

