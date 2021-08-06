using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class NCliente
    {
        //Método Insertar que llama al método Insertar de la clase DCliente
        //de la CapaDatos
        public static string Insertar(string nombre, string apellido, string genero,
            DateTime fecha, string tipodocumento, string numerodocumento,
            string direccion, string telefono, string email)
        {
            DCliente Obj = new DCliente();
            Obj.Apellido = apellido;
            Obj.Direccion = direccion;
            Obj.Email = email;
            Obj.Fecha = fecha;
            Obj.Genero = genero;
            Obj.Nombre = nombre;
            Obj.NumeroDocumento = numerodocumento;
            Obj.Telefono = telefono;
            Obj.TipoDocumento = tipodocumento;
            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DCliente
        //de la CapaDatos
        public static string Editar(int idcliente, string nombre, string apellido, string genero,
            DateTime fecha, string tipodocumento, string numerodocumento,
            string direccion, string telefono, string email)
        {
            DCliente Obj = new DCliente();
            Obj.Apellido = apellido;
            Obj.Direccion = direccion;
            Obj.Email = email;
            Obj.Fecha = fecha;
            Obj.Genero = genero;
            Obj.IdCliente = idcliente;
            Obj.Nombre = nombre;
            Obj.NumeroDocumento = numerodocumento;
            Obj.Telefono = telefono;
            Obj.TipoDocumento = tipodocumento;
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DCliente
        //de la CapaDatos
        public static string Eliminar(int idcliente)
        {
            DCliente Obj = new DCliente();
            Obj.IdCliente = idcliente;
            return Obj.Eliminar(Obj);
        }

        //Método mostrar que llama al método Mostrar de la clase DCliente
        //de la Capadatos
        public static DataTable Mostrar()
        {
            return new DCliente().Mostrar();
        }

        //Método BuscarNumero_documento que llama al método BuscarCliente_Documento
        //de la clase DCliente de la CapaDatos
        public static DataTable BuscarCliente_Documento(string textoBuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarCliente_Documento(Obj);
        }

        public static DataTable BuscarApellido(string textoBuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarApellido(Obj);
        }
    }
}
