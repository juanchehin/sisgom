// Agregados
using CapaDatos;


namespace CapaNegocio
{
    public class CN_Configuracion
    {
        public static string Backup(string file)
        {

            CD_Configuraciones Obj = new CD_Configuraciones();

            return Obj.Backup(file);
        }


    }
}
