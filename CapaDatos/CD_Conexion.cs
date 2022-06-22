using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CapaDatos
{
    public class CD_Conexion
    {
        MySqlConnection Con = new MySqlConnection("datasource =localhost;username = root;password = '';database=sisgom");

        public CD_Conexion()
        {
            AbrirConexion();
        }
        public MySqlConnection AbrirConexion()
        {
            try
            {
                Con.Open();
                return Con;
            }
            catch
            {
                return Con;
            }
        }

        public MySqlConnection CerrarConexion()
        {
            try
            {
                Con.Close();
                return Con;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return Con;
            }
        }
    }

}
