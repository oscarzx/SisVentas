using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NEmpleado
    {
        //Método Insertar que llama al método Insertar de la clase DEmpleado
        //de la CapaDatos
        public static string Insertar(string nombre, string apellido, string genero,
            DateTime fecha, string numerodocumento, string direccion, string telefono, 
            string email, string acceso, string usuario, string password)
        {
            DEmpleado Obj = new DEmpleado();
            Obj.Acceso = acceso;
            Obj.Apellidos = apellido;
            Obj.Direccion = direccion;
            Obj.Email = email;
            Obj.Fecha = fecha;
            Obj.Genero = genero;
            Obj.Nombre = nombre;
            Obj.NumeroDocumento = numerodocumento;
            Obj.Password = password;
            Obj.Telefono = telefono;
            Obj.Usuario = usuario;
            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DEmpleado
        //de la CapaDatos
        public static string Editar(int idempleado, string nombre, string apellido, string genero,
            DateTime fecha, string numerodocumento, string direccion, string telefono,
            string email, string acceso, string usuario, string password)
        {
            DEmpleado Obj = new DEmpleado();
            Obj.Acceso = acceso;
            Obj.Apellidos = apellido;
            Obj.Direccion = direccion;
            Obj.Email = email;
            Obj.Fecha = fecha;
            Obj.Genero = genero;
            Obj.IdEmpleado = idempleado;
            Obj.Nombre = nombre;
            Obj.NumeroDocumento = numerodocumento;
            Obj.Password = password;
            Obj.Telefono = telefono;
            Obj.Usuario = usuario;
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DEmpleado
        //de la CapaDatos
        public static string Eliminar(int idempleado)
        {
            DEmpleado Obj = new DEmpleado();
            Obj.IdEmpleado = idempleado;
            return Obj.Eliminar(Obj);
        }

        //Método mostrar que llama al método Mostrar de la clase DEmpleado
        //de la Capadatos
        public static DataTable Mostrar()
        {
            return new DEmpleado().Mostrar();
        }

        //Método BuscarNumero_documento que llama al método BuscarEmpleado_Documento
        //de la clase DEmpleado de la CapaDatos
        public static DataTable BuscarEmpleado_Documento(string textoBuscar)
        {
            DEmpleado Obj = new DEmpleado();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarEmpleado_Documento(Obj);
        }

        public static DataTable BuscarApellido(string textoBuscar)
        {
            DEmpleado Obj = new DEmpleado();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarApellido_Empleado(Obj);
        }

        public static DataTable Login(string usuario, string password)
        {
            DEmpleado Obj = new DEmpleado();
            Obj.Password = password;
            Obj.Usuario = usuario;
            return Obj.Login(Obj);
        }

    }
}
