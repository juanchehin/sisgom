using CapaDatos;
using System.Data;


namespace CapaNegocio
{
    public class CN_Productos
    {
        private CD_Productos objetoCD = new CD_Productos();

        //Método Insertar que llama al método Insertar de la clase DArticulo
        //de la CapaDatos
        public static string Insertar(string nombre, string Codigo, string PrecioCompra, string PrecioVenta, string Descripcion, string Stock)
        {
            // Console.WriteLine("En insertar , nombre es " + nombre);

            CD_Productos Obj = new CD_Productos();
            Obj.Producto = nombre;
            Obj.Descripcion = Descripcion;
            Obj.Codigo = Codigo;
            Obj.PrecioCompra = PrecioCompra;
            Obj.PrecioVenta = PrecioVenta;
            Obj.Stock = Stock;

            return Obj.Insertar(Obj);
        }

        public DataTable MostrarProd()
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        // Devuelve solo un producto
        public DataTable MostrarProducto(int IdProducto)
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarProducto(IdProducto);
            return tabla;
        }
        public static string Eliminar(int IdProducto)
        {
            CD_Productos Obj = new CD_Productos();
            Obj.IdProducto = IdProducto;
            return Obj.Eliminar(Obj);
        }


        public static string Editar(int IdProducto, string Producto, string Codigo, string PrecioCompra, string PrecioVenta, string Descripcion, string Stock)
        {
            // Console.WriteLine("Produco.IdProducto es 2 : " + IdProducto);
            CD_Productos Obj = new CD_Productos();
            Obj.IdProducto = IdProducto;

            Obj.Producto = Producto;
            Obj.Codigo = Codigo;
            Obj.PrecioCompra = PrecioCompra;
            Obj.PrecioVenta = PrecioVenta;
            Obj.Descripcion = Descripcion;
            Obj.Stock = Stock;

            return Obj.Editar(Obj);
        }

        public DataTable BuscarProducto(string textobuscar)
        {
            CD_Productos Obj = new CD_Productos();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarProducto(Obj);
        }

        public static string ActualizacionPorcentual(decimal pPorcentaje,int desde,int hasta)
        {
            CD_Productos Obj = new CD_Productos();

            return Obj.ActualizacionPorcentual(pPorcentaje,desde,hasta);
        }

        public static string ActualizacionLineal(decimal pValor, int desde, int hasta)
        {
            CD_Productos Obj = new CD_Productos();

            return Obj.ActualizacionLineal(pValor,desde,hasta);
        }

    }
}
