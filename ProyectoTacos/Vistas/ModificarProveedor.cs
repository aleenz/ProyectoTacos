﻿using System;
using ProyectoTacos.Beans;
using ProyectoTacos.Modelos;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTacos.Vistas
{
    public partial class ModificarProveedor : Form
    {
        provedoor prove;
        ProveedorBeans provedorbeans = new ProveedorBeans();
        public ModificarProveedor()
        {
            InitializeComponent();
        }
        public ModificarProveedor(provedoor pv) : this()
        {
            this.prove = pv;
            this.provedorbeans.Provedor.Idproveedo = prove.Idproveedo;
            provedorbeans.buscarid();
            prove = provedorbeans.Provedor;

            textid.Text = Convert.ToString(prove.Idproveedo);
            textnombre.Text = prove.Nombre;
            textrfc.Text = prove.Rfc;
            textcorreo.Text = prove.Correo;
            texttel.Text = Convert.ToString(prove.Telefono);
            textmateria.Text = prove.Materiap;
            textcolonia.Text = prove.Colonia;
            textcalle.Text = prove.Calle;
            textnumero.Text = Convert.ToString(prove.Numero);
            textcp.Text = Convert.ToString(prove.Cp);


        }
        public void carga_reg()
        {
            this.provedorbeans.Provedor.Nombre = textnombre.Text;
            this.provedorbeans.Provedor.Rfc = textrfc.Text;
            this.provedorbeans.Provedor.Correo = textcorreo.Text;
            this.provedorbeans.Provedor.Telefono = Convert.ToInt32(texttel.Text);
            this.provedorbeans.Provedor.Materiap = textmateria.Text;
            this.provedorbeans.Provedor.Calle = textcalle.Text;
            this.provedorbeans.Provedor.Colonia = textcolonia.Text;
            this.provedorbeans.Provedor.Cp = Convert.ToInt32(textcp.Text);
            this.provedorbeans.Provedor.Numero = Convert.ToInt32(textnumero.Text);
            this.provedorbeans.Provedor.Status = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textnombre.Text == "" || textmateria.Text == "" || textcalle.Text == ""
               || textcp.Text == "" || textcolonia.Text == "" || textcorreo.Text == ""
               || textnumero.Text == "" || textrfc.Text == "" || texttel.Text == "")
            {
                MessageBox.Show("Debe llenar todos los campos");
            }

            else
            {
                carga_reg();
                provedorbeans.modificar();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
