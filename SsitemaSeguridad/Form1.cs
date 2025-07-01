using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SsitemaSeguridad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtContraseña.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            

           
            string usuario = txtUsuario.Text;
            string password = txtContraseña.Text;

            
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Por favor, ingrese un usuario y contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DbGeneral db = new DbGeneral();

            
            bool esValido = db.BuscarUsuario(usuario, password);

            
            if (esValido)
            {
                
                MessageBox.Show("Empleado verificado correctamente.", "Acceso autorizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                
                MessageBox.Show("Empleado no encontrado", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtContraseña.Text;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ContieneCaracterEspecial(password))
            {
                MessageBox.Show("La contraseña debe contener al menos un carácter especial (!, @, #, $, %, etc.).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DbGeneral db = new DbGeneral();

            int resultado = db.AgregarUsuario(usuario, password);

            if (resultado > 0)
            {
                
                MessageBox.Show("Visitante agregado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                
                MessageBox.Show("Por favor, ingrese usuario y contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }
        private bool ContieneCaracterEspecial(string password)
        {
           
            var regex = new System.Text.RegularExpressions.Regex(@"[^a-zA-Z0-9]");
            return regex.IsMatch(password);
        }
    }
    
}
