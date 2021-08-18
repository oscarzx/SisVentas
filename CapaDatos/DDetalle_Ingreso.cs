using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class DDetalle_Ingreso
    {
        private int idDetalle_ingreso;

        public int IdDetalle_ingreso
        {
            get { return idDetalle_ingreso; }
            set { idDetalle_ingreso = value; }
        }

        private int idIngreso;

        public int IdIngreso
        {
            get { return idIngreso; }
            set { idIngreso = value; }
        }

        private int idArticulo;

        public int IdArticulo
        {
            get { return idArticulo; }
            set { idArticulo = value; }
        }

        private decimal precio_compra;

        public decimal Precio_compra
        {
            get { return precio_compra; }
            set { precio_compra = value; }
        }

        private decimal precio_venta;

        public decimal Precio_venta
        {
            get { return precio_venta; }
            set { precio_venta = value; }
        }

        private float stock_inicial;

        public float Stock_inicial
        {
            get { return stock_inicial; }
            set { stock_inicial = value; }
        }

        private float stock_actual;

        public float Stock_actual
        {
            get { return stock_actual; }
            set { stock_actual = value; }
        }

        private DateTime fecha_produccion;

        public DateTime Fecha_produccion
        {
            get { return fecha_produccion; }
            set { fecha_produccion = value; }
        }

        private DateTime fecha_vencimiento;

        public DateTime Fecha_vencimiento
        {
            get { return fecha_vencimiento; }
            set { fecha_vencimiento = value; }
        }

        public DDetalle_Ingreso()
        {

        }

        public DDetalle_Ingreso(int _iddetalle_ingreso, int _idingreso, int _idarticulo,
            decimal _precio_compra, decimal _precio_venta, float _stock_inicial,
            float _stock_actual, DateTime _fecha_producccion, DateTime _fecha_vencimiento)
        {
            this.Fecha_produccion = _fecha_producccion;
            this.Fecha_vencimiento = _fecha_vencimiento;
            this.IdArticulo = _idarticulo;
            this.IdDetalle_ingreso = _iddetalle_ingreso;
            this.IdIngreso = _idingreso;
            this.Precio_compra = _precio_compra;
            this.Precio_venta = _precio_venta;
            this.Stock_actual = _stock_actual;
            this.Stock_inicial = _stock_inicial;
        }


        public string Insertar(DDetalle_Ingreso Detalle_Ingreso,
            ref SqlConnection SqlCon, ref SqlTransaction sqlTransaction)
        {
            string rpta = "";
            
            try
            {
                //Establecer comando
                SqlCommand Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = SqlCon;
                Sqlcmd.Transaction = sqlTransaction;
                Sqlcmd.CommandText = "spinsertar_detalle_ingreso";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDetalle = new SqlParameter();
                ParIdDetalle.ParameterName = "@iddetalle_ingreso";
                ParIdDetalle.SqlDbType = SqlDbType.Int;
                ParIdDetalle.Direction = ParameterDirection.Output;
                Sqlcmd.Parameters.Add(ParIdDetalle);

                SqlParameter ParIdIngreso = new SqlParameter();
                ParIdIngreso.ParameterName = "@idingreso";
                ParIdIngreso.SqlDbType = SqlDbType.Int;
                ParIdIngreso.Value = Detalle_Ingreso.IdIngreso;
                Sqlcmd.Parameters.Add(ParIdIngreso);

                SqlParameter ParIdArticulo = new SqlParameter();
                ParIdArticulo.ParameterName = "@idarticulo";
                ParIdArticulo.SqlDbType = SqlDbType.Int;
                ParIdArticulo.Value = Detalle_Ingreso.IdArticulo;
                Sqlcmd.Parameters.Add(ParIdArticulo);

                SqlParameter ParPrecioCompra = new SqlParameter();
                ParPrecioCompra.ParameterName = "@precio_compra";
                ParPrecioCompra.SqlDbType = SqlDbType.Money;
                ParPrecioCompra.Value = Detalle_Ingreso.Precio_compra;
                Sqlcmd.Parameters.Add(ParPrecioCompra);

                SqlParameter ParPrecioVenta = new SqlParameter();
                ParPrecioVenta.ParameterName = "@precio_venta";
                ParPrecioVenta.SqlDbType = SqlDbType.Money;
                ParPrecioVenta.Value = Detalle_Ingreso.Precio_venta;
                Sqlcmd.Parameters.Add(ParPrecioVenta);

                SqlParameter ParStockInicial = new SqlParameter();
                ParStockInicial.ParameterName = "@stock_inicial";
                ParStockInicial.SqlDbType = SqlDbType.Float;
                ParStockInicial.Value = Detalle_Ingreso.Stock_inicial;
                Sqlcmd.Parameters.Add(ParStockInicial);

                SqlParameter ParStockActual = new SqlParameter();
                ParStockActual.ParameterName = "@stock_actual";
                ParStockActual.SqlDbType = SqlDbType.Float;
                ParStockActual.Value = Detalle_Ingreso.Stock_actual;
                Sqlcmd.Parameters.Add(ParStockActual);

                SqlParameter ParFechaProduccion = new SqlParameter();
                ParFechaProduccion.ParameterName = "@fecha_produccion";
                ParFechaProduccion.SqlDbType = SqlDbType.Date;
                ParFechaProduccion.Value = Detalle_Ingreso.Fecha_produccion;
                Sqlcmd.Parameters.Add(ParFechaProduccion);

                SqlParameter ParFechaVencimiento = new SqlParameter();
                ParFechaVencimiento.ParameterName = "@fecha_vencimiento";
                ParFechaVencimiento.SqlDbType = SqlDbType.Date;
                ParFechaVencimiento.Value = Detalle_Ingreso.Fecha_vencimiento;//Esta fecha está como nchar en la db
                Sqlcmd.Parameters.Add(ParFechaVencimiento);

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
