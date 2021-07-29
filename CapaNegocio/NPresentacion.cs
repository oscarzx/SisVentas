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
    public class NPresentacion
    {
        //Método Insertar que llama al método Insertar de la clase DPresentación
        //de la CapaDatos
        public static string Insertar(string nombre, string descripcion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DPresentación
        //de la CapaDatos
        public static string Editar(int idPresentacion, string nombre, string descripcion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.IdPresentacion = idPresentacion;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DProducto
        //de la CapaDatos
        public static string Eliminar(int idPresentacion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.IdPresentacion = idPresentacion;
            return Obj.Eliminar(Obj);
        }

        //Método mostrar que llama al método Mostrar de la clase DPresentacion
        //de la Capadatos
        public static DataTable Mostrar()
        {
            return new DPresentacion().Mostrar();
        }

        //Método BuscarNombre que llama al método BuscarNombre
        //de la clase DPresentación de la CapaDatos
        public static DataTable BuscarNombre(string textoBuscar)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
