using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SsitemaSeguridad
{
    internal class DbGeneral
    {
        
        public MySqlConnection ObtenerConexion()
        {
            MySqlConnection conectar = new MySqlConnection("server=127.0.0.1; database=db_seguridad; Uid=root; pwd=;");
            try
            {
                conectar.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al conectar con la DB");
            }
            return conectar;
        }

        
        public bool BuscarUsuario(string usuario, string password)
        {
            bool usuarioValido = false;
            try
            {
                
                MySqlCommand _comando = new MySqlCommand(string.Format("SELECT * FROM usuarios WHERE usuario = '{0}' AND password = '{1}'", usuario, password), this.ObtenerConexion());
                MySqlDataReader _reader = _comando.ExecuteReader();

                if (_reader.HasRows) 
                {
                    usuarioValido = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al verificar las credenciales en la DB");
            }
            return usuarioValido;
        }

        
        public int AgregarUsuario(string usuario, string password)
        {
            try
            {
                int retorno = 0;
                MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO usuarios(usuario, password) VALUES('{0}', '{1}')", usuario, password), this.ObtenerConexion());
                retorno = comando.ExecuteNonQuery();
                return retorno;
            }
            catch (Exception)
            {
                return -1; 
            }
        }

        
        public int ActualizarUsuario(string usuario, string password)
        {
            int retorno = 0;
            MySqlConnection conexion = this.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("UPDATE usuarios SET password = '{0}' WHERE usuario = '{1}'", password, usuario), conexion);
            retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }

       
        public int EliminarUsuario(string usuario)
        {
            int retorno = 0;
            MySqlConnection conexion = this.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("DELETE FROM usuarios WHERE usuario = '{0}'", usuario), conexion);
            retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }
    }
}
