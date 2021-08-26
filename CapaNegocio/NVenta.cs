using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NVenta
    {
        public static string Insertar(int idcliente, int idempleado, DateTime fecha,
            string tipo_comprobante, string serie, string correlativo, decimal iva,
            DataTable dtDetalles)
        {
            DVenta Obj = new DVenta();
            Obj.Correlativo = correlativo;
            Obj.Fecha = fecha;
            Obj.IdCliente = idcliente;
            Obj.IdEmpleado = idempleado;
            Obj.Iva = iva;
            Obj.Serie = serie;
            Obj.Tipo_comprobante = tipo_comprobante;

            List<DDetalle_venta> misDetalles = new List<DDetalle_venta>();

            foreach (DataRow row in dtDetalles.Rows)
            {
                DDetalle_venta detalle = new DDetalle_venta();
                detalle.IdDetalle_ingreso = Convert.ToInt32(row["IdDetalle_ingreso"].ToString());
                detalle.Cantidad = float.Parse(row["Cantidad"].ToString());
                detalle.Precio_venta = Convert.ToDecimal(row["Precio_venta"].ToString());
                detalle.Descuento = Convert.ToDecimal(row["Descuento"].ToString());
                misDetalles.Add(detalle);
            }
            return Obj.Insertar(Obj, misDetalles);
        }

        public static string Eliminar(int idventa)
        {
            DVenta Obj = new DVenta();
            Obj.IdVenta = idventa;
            return Obj.Eliminar(Obj);
        }


        public static DataTable Mostrar()
        {
            return new DVenta().Mostrar();
        }


        public static DataTable BuscarFechas(string textoBuscar, string textoBuscar2)
        {
            DVenta Obj = new DVenta();
            return Obj.BuscarFechas(textoBuscar, textoBuscar2);
        }

        public static DataTable MostrarDetalle(string textoBuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarDetalle(textoBuscar);
        }

        public static DataTable MostrarArticulo_Venta_Nombre(string textoBuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarArticulo_venta_nombre(textoBuscar);
        }

        public static DataTable MostrarArticulo_Venta_Codigo(string textoBuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarArticulo_venta_codigo(textoBuscar);
        }

        //public static DataTable MostrarArticulo_venta_nombre(string textoBuscar)
        //{
        //    DVenta Obj = new DVenta();
        //    return Obj.MostrarArticulo_venta_nombre(textoBuscar);
        //}
    }
}
