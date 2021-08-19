using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalle_venta
    {
        private int idDetalle_venta;

        public int IdDetalle_venta
        {
            get { return idDetalle_venta; }
            set { idDetalle_venta = value; }
        }

        private int idVenta;

        public int IdVenta
        {
            get { return idVenta; }
            set { idVenta = value; }
        }

        private int idDetalle_ingreso;

        public int IdDetalle_ingreso
        {
            get { return idDetalle_ingreso; }
            set { idDetalle_ingreso = value; }
        }

        private float cantidad;

        public float Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        private decimal precio_venta;

        public decimal Precio_venta
        {
            get { return precio_venta; }
            set { precio_venta = value; }
        }

        private decimal descuento;

        public decimal Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }


        public DDetalle_venta()
        {

        }

        public DDetalle_venta(int _idDetalle_venta, int _idVenta, int _idDetalle_ingreso, float _cantidad,
            decimal _precio_venta, decimal _descuento)
        {
            this.Cantidad = _cantidad;
            this.Descuento = _descuento;
            this.IdDetalle_ingreso = _idDetalle_ingreso;
            this.IdDetalle_venta = _idDetalle_venta;
            this.IdVenta = _idVenta;
            this.Precio_venta = _precio_venta;
        }


        //Método insertar
        public string Insertar(DDetalle_venta Detalle_venta,
            ref SqlConnection SqlCon, ref SqlTransaction sqlTransaction)
        {
            string rpta = "";

            try
            {
                //Establecer comando
                SqlCommand Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = SqlCon;
                Sqlcmd.Transaction = sqlTransaction;
                Sqlcmd.CommandText = "spinsertar_detalle_venta";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDetalle_venta = new SqlParameter();
                ParIdDetalle_venta.ParameterName = "@iddetalle_venta";
                ParIdDetalle_venta.SqlDbType = SqlDbType.Int;
                ParIdDetalle_venta.Direction = ParameterDirection.Output;
                Sqlcmd.Parameters.Add(ParIdDetalle_venta);

                SqlParameter ParIdventa = new SqlParameter();
                ParIdventa.ParameterName = "@idventa";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Value = Detalle_venta.IdVenta;
                Sqlcmd.Parameters.Add(ParIdventa);

                SqlParameter ParIdDetalle_ingreso = new SqlParameter();
                ParIdDetalle_ingreso.ParameterName = "@iddetalle_ingreso";
                ParIdDetalle_ingreso.SqlDbType = SqlDbType.Int;
                ParIdDetalle_ingreso.Value = Detalle_venta.IdDetalle_ingreso;
                Sqlcmd.Parameters.Add(ParIdDetalle_ingreso);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Float;
                ParCantidad.Value = Detalle_venta.cantidad;
                Sqlcmd.Parameters.Add(ParCantidad);

                SqlParameter ParPrecio_venta = new SqlParameter();
                ParPrecio_venta.ParameterName = "@precio_venta";
                ParPrecio_venta.SqlDbType = SqlDbType.Money;
                ParPrecio_venta.Value = Detalle_venta.Precio_venta;
                Sqlcmd.Parameters.Add(ParPrecio_venta);

                SqlParameter ParDescuento = new SqlParameter();
                ParDescuento.ParameterName = "@descuento";
                ParDescuento.SqlDbType = SqlDbType.Money;
                ParDescuento.Value = Detalle_venta.Descuento;
                Sqlcmd.Parameters.Add(ParDescuento);

                //Ejecutamos nuestro comando
                rpta = Sqlcmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingresó el registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }

    }
}
