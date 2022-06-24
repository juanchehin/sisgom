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

        private CD_Conexion conexion = new CD_Conexion();

        // ==================================================
        //  Backup
        // ==================================================
        public string Backup(string file)
        {
            string rpta = "";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(conexion.dame_cadena()))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(file);
                            conn.Close();
                        }
                    }
                }
                rpta = "Ok";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return rpta;
        }
        // ==================================================
        //  Restaurar BD
        // ==================================================
        public string Restore(string ruta)
        {
            string rpta = "";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(conexion.dame_cadena()))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ImportFromFile(ruta);
                            conn.Close();
                        }
                    }
                }
                rpta = "Ok";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return rpta;
        }

    }
}
