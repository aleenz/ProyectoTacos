﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoTacos.Beans;
using ProyectoTacos.Modelos;
using ProyectoTacos.Vistas;

namespace ProyectoTacos
{
    public partial class FRMAcceso : Form
    {

        Main parent;
        public FRMAcceso(Main parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            
        }









       


        private void clean()
        {
            this.TXTUsuario.Text = "";
            this.TXTContrasena.Text = "";
        }

        private void BTNAcceder_Click(object sender, EventArgs e)
        {

            UsuarioBeans usuario_beans = new UsuarioBeans();
            string usuario = TXTUsuario.Text;
            string contrasena = TXTContrasena.Text;


            if(usuario=="" || contrasena == "")
            {
                MessageBox.Show("Debe introducir un nombre de usuario y una contraseña");
                TXTUsuario.Focus();
            }
            else
            {
                if(usuario_beans.IniciarSesion(TXTUsuario.Text, TXTContrasena.Text))
                {
                    this.Close();
                    parent.cargar();
                }
                else
                {
                    MessageBox.Show("EW");

                }
            }
            
        }


        private void LBLCrear_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrarCliente form = new RegistrarCliente(this);
            form.Show();
        }

        private void TXTUsuario_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) BTNAcceder.PerformClick() ;

        }

        private void TXTUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXTContrasena_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
