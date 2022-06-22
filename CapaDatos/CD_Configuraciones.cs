using CapaDatos;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace CapaDatos
{
    public class CD_Configuraciones
    {

        //Constructores
        public CD_Configuraciones()
        {

        }

        // ==================================================
        //  Backup
        // ==================================================
        private CD_Conexion conexion = new CD_Conexion();

        MySqlDataReader leer;
        DataTable tabla = new DataTable();
        MySqlCommand comando = new MySqlCommand();

        public string Backup()
        {
            string rpta = "";
            comando.Parameters.Clear();// si no ponerlo al comienzo de esta funcion
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_editar_cliente";

                MySqlParameter pIdCliente = new MySqlParameter();
                pIdCliente.ParameterName = "@pIdCliente";
                pIdCliente.MySqlDbType = MySqlDbType.Int32;
                // pIdEmpleado.Size = 60;
                pIdCliente.Value = Cliente.IdCliente;
                comando.Parameters.Add(pIdCliente);

                MySqlParameter pTransporte = new MySqlParameter();
                pTransporte.ParameterName = "@pTransporte";
                pTransporte.MySqlDbType = MySqlDbType.VarChar;
                pTransporte.Size = 60;
                pTransporte.Value = Cliente.Transporte;
                comando.Parameters.Add(pTransporte);

                MySqlParameter pTitular = new MySqlParameter();
                pTitular.ParameterName = "@pTitular";
                pTitular.MySqlDbType = MySqlDbType.VarChar;
                pTitular.Size = 30;
                pTitular.Value = Cliente.Titular;
                comando.Parameters.Add(pTitular);

                MySqlParameter pTelefono = new MySqlParameter();
                pTelefono.ParameterName = "@pTelefono";
                pTelefono.MySqlDbType = MySqlDbType.VarChar;
                pTelefono.Size = 15;
                pTelefono.Value = Cliente.Telefono;
                comando.Parameters.Add(pTelefono);

                rpta = comando.ExecuteScalar().ToString() == "Ok" ? "Ok" : "No se edito el Registro";

            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally
            {
                conexion.CerrarConexion();
            }
            comando.Parameters.Clear();
            return rpta;
        }

    }
}
