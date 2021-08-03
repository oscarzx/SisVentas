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
    public class NProveedor
    {
        //Método Insertar que llama al método Insertar de la clase DProveedor
        //de la CapaDatos
        public static string Insertar(string razon_social, string sector_comercial,
            string tipo_documento, string num_documento, string direccion, string telefono,
            string email, string url)
        {
            DProveedor Obj = new DProveedor();
            Obj.Direccion = direccion;
            Obj.Email = email;
            Obj.Num_Documento = num_documento;
            Obj.Razon_Social = razon_social;
            Obj.Sector_Comercial = sector_comercial;
            Obj.Telefono = telefono;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Url = url;
            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DProveedor
        //de la CapaDatos
        public static string Editar(int idproveedor, string razon_social, string sector_comercial,
            string tipo_documento, string num_documento, string direccion, string telefono,
            string email, string url)
        {
            DProveedor Obj = new DProveedor();
            Obj.Direccion = direccion;
            Obj.Email = email;
            Obj.Idproveedor = idproveedor;
            Obj.Num_Documento = num_documento;
            Obj.Razon_Social = razon_social;
            Obj.Sector_Comercial = sector_comercial;
            Obj.Telefono = telefono;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Url = url;
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DProveedor
        //de la CapaDatos
        public static string Eliminar(int idproveedor)
        {
            DProveedor Obj = new DProveedor();
            Obj.Idproveedor = idproveedor;
            return Obj.Eliminar(Obj);
        }

        //Método mostrar que llama al método Mostrar de la clase DProveedor
        //de la Capadatos
        public static DataTable Mostrar()
        {
            return new DProveedor().Mostrar();
        }

        //Método BuscarRazon_social que llama al método BuscarRazon_Social
        //de la clase DProveedor de la CapaDatos
        public static DataTable BuscarRazon_Social(string textoBuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarRazon_Social(Obj);
        }

        public static DataTable BuscarNum_Documento(string textoBuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNum_Documento(Obj);
        }
    }
}
