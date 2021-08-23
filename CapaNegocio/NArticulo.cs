using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio
{
    public class NArticulo
    {
        //Método Insertar que llama al método Insertar de la clase DArticulo
        //de la CapaDatos
        public static string Insertar(string codigo, string nombre, string descripcion, 
            byte[] imagen, int idCategoria, int idPresentacion)
        {
            DArticulo Obj = new DArticulo();
            Obj.Codigo = codigo;
            Obj.Descripcion = descripcion;
            Obj.IdCategoria = idCategoria;
            Obj.IdPresentacion = idPresentacion;
            Obj.Imagen = imagen;
            Obj.Nombre = nombre;
            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DArticulo
        //de la CapaDatos
        public static string Editar(int idArticulo, string codigo, string nombre, string descripcion, 
            byte[] imagen, int idCategoria, int idPresentacion)
        {
            DArticulo Obj = new DArticulo();
            Obj.Codigo = codigo;
            Obj.Descripcion = descripcion;
            Obj.IdArticulo = idArticulo;
            Obj.IdCategoria = idCategoria;
            Obj.IdPresentacion = idPresentacion;
            Obj.Imagen = imagen;
            Obj.Nombre = nombre;
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DArticulo
        //de la CapaDatos
        public static string Eliminar(int idArticulo)
        {
            DArticulo Obj = new DArticulo();
            Obj.IdArticulo = idArticulo;
            return Obj.Eliminar(Obj);
        }

        //Método mostrar que llama al método Mostrar de la clase DArticulo
        //de la Capadatos
        public static DataTable Mostrar()
        {
            return new DArticulo().Mostrar();
        }

        //Método BuscarNombre que llama al método BuscarNombre
        //de la clase DArticulo de la CapaDatos
        public static DataTable BuscarNombre(string textoBuscar)
        {
            DArticulo Obj = new DArticulo();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNombre(Obj);
        }

        public static DataTable StockArticulos()
        {
            return new DArticulo().StockArticulo();
        }
    }
}
