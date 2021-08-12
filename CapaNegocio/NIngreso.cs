using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NIngreso
    {
        public static string Insertar(int idempleado, int idproveedor, DateTime fecha,
            string tipodocumento, string serie, string correlativo, decimal iva, string estado
            ,DataTable dtDetalles)
        {
            DIngreso Obj = new DIngreso();
            Obj.Correlativo = correlativo;
            Obj.Estado = estado;
            Obj.Fecha = fecha;
            Obj.IdEmpleado = idempleado;
            Obj.IdProveedor = idproveedor;
            Obj.Iva = iva;
            Obj.Serie = serie;
            Obj.Tipo_comprobante = tipodocumento;

            List<DDetalle_Ingreso> misDetalles = new List<DDetalle_Ingreso>();

            foreach (DataRow row in dtDetalles.Rows)
            {
                DDetalle_Ingreso detalle = new DDetalle_Ingreso();
                detalle.IdArticulo = Convert.ToInt32(row["IdArticulo"].ToString());
                detalle.Precio_compra = Convert.ToDecimal(row["Precio_compra"].ToString());
                detalle.Precio_venta = Convert.ToDecimal(row["Precio_venta"].ToString());
                detalle.Stock_inicial = float.Parse(row["Stock_inicial"].ToString());
                detalle.Stock_actual = float.Parse(row["Stock_actual"].ToString());
                detalle.Fecha_produccion = Convert.ToDateTime(row["Fecha_produccion"].ToString());
                detalle.Fecha_vencimiento = Convert.ToDateTime(row["Fecha_vencimiento"].ToString());
                misDetalles.Add(detalle);
            }
            return Obj.Insertar(Obj, misDetalles);
        }

        public static string Anular(int idingreso)
        {
            DIngreso Obj = new DIngreso();
            Obj.IdIngreso = idingreso;
            return Obj.Anular(Obj);
        }

        
        public static DataTable Mostrar()
        {
            return new DIngreso().Mostrar();
        }


        public static DataTable BuscarFechas(string textoBuscar, string textoBuscar2)
        {
            DIngreso Obj = new DIngreso();
            return Obj.BuscarFechas(textoBuscar, textoBuscar2);
        }

        public static DataTable MostrarDetalle(string textoBuscar)
        {
            DIngreso Obj = new DIngreso();
            return Obj.MostrarDetalle(textoBuscar);
        }
    }
}
