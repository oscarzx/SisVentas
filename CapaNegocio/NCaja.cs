using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NCaja
    {
        public static string Insertar(string descripcion, string serialPC, string impresoraTicket,
            string impresoraA4)
        {
            DCaja obj = new DCaja();
            obj.Descripcion = descripcion;
            obj.ImpresoraA4 = impresoraA4;
            obj.ImpresoraTicket = impresoraTicket;
            obj.SerialPc = serialPC;
            return obj.InsertarCaja(obj);
        }

        public static string Editar(int idCaja, string descripcion, string serialPC, string impresoraTicket,
            string impresoraA4)
        {
            DCaja obj = new DCaja();
            obj.Descripcion = descripcion;
            obj.IdCaja = idCaja;
            obj.ImpresoraA4 = impresoraA4;
            obj.ImpresoraTicket = impresoraTicket;
            obj.SerialPc = serialPC;
            return obj.EditarCaja(obj);
        }

        public static string Eliminar(int idCaja)
        {
            DCaja obj = new DCaja();
            obj.IdCaja = idCaja;
            return obj.EliminarCaja(obj);
        }

        public static DataTable Mostrar()
        {
            return new DCaja().Mostrar();
        }

        public static DataTable BuscarCajaNombre(string nombreCaja)
        {
            DCaja obj = new DCaja();
            obj.Descripcion = nombreCaja;
            return obj.BuscarCajaNombre(obj);
        }

        public static DataTable MostrarListado()
        {
            return new DCaja().MostrarListado();
        }
    }
}
