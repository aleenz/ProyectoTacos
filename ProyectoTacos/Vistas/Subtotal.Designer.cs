namespace ProyectoTacos.Vistas
{
    partial class Subtotal
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTNPagar = new System.Windows.Forms.Button();
            this.LBLTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RDBCredito = new System.Windows.Forms.RadioButton();
            this.RDBDebito = new System.Windows.Forms.RadioButton();
            this.RDBEfectivo = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.BTNPagar);
            this.panel1.Controls.Add(this.LBLTotal);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 282);
            this.panel1.TabIndex = 0;
            // 
            // BTNPagar
            // 
            this.BTNPagar.Location = new System.Drawing.Point(331, 252);
            this.BTNPagar.Name = "BTNPagar";
            this.BTNPagar.Size = new System.Drawing.Size(75, 23);
            this.BTNPagar.TabIndex = 13;
            this.BTNPagar.Text = "Pagar";
            this.BTNPagar.UseVisualStyleBackColor = true;
            this.BTNPagar.Click += new System.EventHandler(this.BTNPagar_Click);
            // 
            // LBLTotal
            // 
            this.LBLTotal.AutoSize = true;
            this.LBLTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLTotal.Location = new System.Drawing.Point(75, 255);
            this.LBLTotal.Name = "LBLTotal";
            this.LBLTotal.Size = new System.Drawing.Size(18, 20);
            this.LBLTotal.TabIndex = 12;
            this.LBLTotal.Text = "0";
            this.LBLTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Total: $";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.Cantidad,
            this.Monto});
            this.dataGridView1.Location = new System.Drawing.Point(12, 87);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(394, 109);
            this.dataGridView1.TabIndex = 11;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Monto
            // 
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(97, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 26);
            this.label1.TabIndex = 10;
            this.label1.Text = "Subtotal";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::ProyectoTacos.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(12, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RDBEfectivo);
            this.groupBox1.Controls.Add(this.RDBDebito);
            this.groupBox1.Controls.Add(this.RDBCredito);
            this.groupBox1.Location = new System.Drawing.Point(12, 202);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 47);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Método de Pago";
            // 
            // RDBCredito
            // 
            this.RDBCredito.AutoSize = true;
            this.RDBCredito.Checked = true;
            this.RDBCredito.Location = new System.Drawing.Point(6, 20);
            this.RDBCredito.Name = "RDBCredito";
            this.RDBCredito.Size = new System.Drawing.Size(108, 17);
            this.RDBCredito.TabIndex = 0;
            this.RDBCredito.TabStop = true;
            this.RDBCredito.Text = "Tarjeta de crédito";
            this.RDBCredito.UseVisualStyleBackColor = true;
            // 
            // RDBDebito
            // 
            this.RDBDebito.AutoSize = true;
            this.RDBDebito.Location = new System.Drawing.Point(156, 20);
            this.RDBDebito.Name = "RDBDebito";
            this.RDBDebito.Size = new System.Drawing.Size(105, 17);
            this.RDBDebito.TabIndex = 0;
            this.RDBDebito.Text = "Tarjeta de débito";
            this.RDBDebito.UseVisualStyleBackColor = true;
            // 
            // RDBEfectivo
            // 
            this.RDBEfectivo.AutoSize = true;
            this.RDBEfectivo.Location = new System.Drawing.Point(324, 20);
            this.RDBEfectivo.Name = "RDBEfectivo";
            this.RDBEfectivo.Size = new System.Drawing.Size(64, 17);
            this.RDBEfectivo.TabIndex = 0;
            this.RDBEfectivo.Text = "Efectivo";
            this.RDBEfectivo.UseVisualStyleBackColor = true;
            // 
            // Subtotal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(441, 306);
            this.Controls.Add(this.panel1);
            this.Name = "Subtotal";
            this.Text = "Subtotal";
            this.Load += new System.EventHandler(this.Subtotal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LBLTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTNPagar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RDBEfectivo;
        private System.Windows.Forms.RadioButton RDBDebito;
        private System.Windows.Forms.RadioButton RDBCredito;
    }
}