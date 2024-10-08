﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DIngreso
    {
        private int idIngreso;

        public int IdIngreso
        {
            get { return idIngreso; }
            set { idIngreso = value; }
        }

        private int idEmpleado;

        public int IdEmpleado
        {
            get { return idEmpleado; }
            set { idEmpleado = value; }
        }

        private int idProveedor;

        public int IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }

        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private string tipo_comprobante;

        public string Tipo_comprobante
        {
            get { return tipo_comprobante; }
            set { tipo_comprobante = value; }
        }

        private string serie;

        public string Serie
        {
            get { return serie; }
            set { serie = value; }
        }

        private string correlativo;

        public string Correlativo
        {
            get { return correlativo; }
            set { correlativo = value; }
        }

        private decimal iva;

        public decimal Iva
        {
            get { return iva; }
            set { iva = value; }
        }

        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public DIngreso()
        {

        }

        public DIngreso(int _idingreso, int _idempleado, int _idproveedor, DateTime _fecha,
            string _tipo_comprobante, string _serie, string _correlativo, decimal _iva,
            string _estado)
        {
            this.Correlativo = _correlativo;
            this.Estado = _estado;
            this.Fecha = _fecha;
            this.IdEmpleado = _idempleado;
            this.IdIngreso = _idingreso;
            this.IdProveedor = _idproveedor;
            this.Iva = _iva;
            this.Serie = _serie;
            this.Tipo_comprobante = _tipo_comprobante;
        }


        //Método Insertar
        public string Insertar(DIngreso Ingreso, List<DDetalle_Ingreso> Detalle)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                //Establecer la transacción
                SqlTransaction sqlTransaction = SqlCon.BeginTransaction();

                //Establecer comando
                SqlCommand Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = SqlCon;
                Sqlcmd.Transaction = sqlTransaction;
                Sqlcmd.CommandText = "spinsertar_ingreso";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdIngreso = new SqlParameter();
                ParIdIngreso.ParameterName = "@idingreso";
                ParIdIngreso.SqlDbType = SqlDbType.Int;
                ParIdIngreso.Direction = ParameterDirection.Output;
                Sqlcmd.Parameters.Add(ParIdIngreso);

                SqlParameter ParIdEmpleado = new SqlParameter();
                ParIdEmpleado.ParameterName = "@idempleado";
                ParIdEmpleado.SqlDbType = SqlDbType.Int;
                ParIdEmpleado.Value = Ingreso.IdEmpleado;
                Sqlcmd.Parameters.Add(ParIdEmpleado);

                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idproveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Ingreso.IdProveedor;
                Sqlcmd.Parameters.Add(ParIdProveedor);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Ingreso.Fecha;
                Sqlcmd.Parameters.Add(ParFecha);

                SqlParameter ParTipoComprobante = new SqlParameter();
                ParTipoComprobante.ParameterName = "@tipo_comprobante";
                ParTipoComprobante.SqlDbType = SqlDbType.VarChar;
                ParTipoComprobante.Size = 20;
                ParTipoComprobante.Value = Ingreso.Tipo_comprobante;
                Sqlcmd.Parameters.Add(ParTipoComprobante);

                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@serie";
                ParSerie.SqlDbType = SqlDbType.VarChar;
                ParSerie.Size = 4;
                ParSerie.Value = Ingreso.Serie;
                Sqlcmd.Parameters.Add(ParSerie);

                SqlParameter ParCorrelativo = new SqlParameter();
                ParCorrelativo.ParameterName = "@correlativo";
                ParCorrelativo.SqlDbType = SqlDbType.VarChar;
                ParCorrelativo.Size = 7;
                ParCorrelativo.Value = Ingreso.Correlativo;
                Sqlcmd.Parameters.Add(ParCorrelativo);

                SqlParameter ParIva = new SqlParameter();
                ParIva.ParameterName = "@iva";
                ParIva.SqlDbType = SqlDbType.Decimal;
                ParIva.Precision = 4;
                ParIva.Scale = 2;
                ParIva.Value = Ingreso.Iva;
                Sqlcmd.Parameters.Add(ParIva);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 7;
                ParEstado.Value = Ingreso.Estado;
                Sqlcmd.Parameters.Add(ParEstado);

                //Ejecutamos nuestro comando
                rpta = Sqlcmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingresó el registro";

                if (rpta.Equals("OK"))
                {
                    //Obtener el código del ingreso generado
                    this.IdIngreso = Convert.ToInt32(Sqlcmd.Parameters["@idingreso"].Value);

                    foreach (DDetalle_Ingreso item in Detalle)
                    {
                        item.IdIngreso = this.IdIngreso;
                        //Llamar al método insertar de la clase DDetalle_ingreso
                        rpta = item.Insertar(item, ref SqlCon, ref sqlTransaction);

                        if (!rpta.Equals("OK"))
                        {
                            break;
                        }
                    }
                }
                if (rpta.Equals("OK"))
                {
                    sqlTransaction.Commit();
                }
                else
                {
                    sqlTransaction.Rollback();
                }

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }


        public string Anular(DIngreso Ingreso)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                //Establecer comando
                SqlCommand Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = SqlCon;
                Sqlcmd.CommandText = "spanular_ingreso";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdingreso = new SqlParameter();
                ParIdingreso.ParameterName = "@idingreso";
                ParIdingreso.SqlDbType = SqlDbType.Int;
                ParIdingreso.Value = Ingreso.IdIngreso;
                Sqlcmd.Parameters.Add(ParIdingreso);

                //Ejecutamos nuestro comando
                rpta = Sqlcmd.ExecuteNonQuery() == 1 ? "OK" : "No se anuló el registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }


        //Buscar Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Ingreso");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;

            }
            return DtResultado;
        }

        //Buscar Fechas
        public DataTable BuscarFechas(string _textobuscar, string _textobuscar2)
        {
            DataTable DtResultado = new DataTable("Ingreso");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_ingreso_fecha";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 20;
                ParTextoBuscar.Value = _textobuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlParameter ParTextoBuscar2 = new SqlParameter();
                ParTextoBuscar2.ParameterName = "@textobuscar2";
                ParTextoBuscar2.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar2.Size = 20;
                ParTextoBuscar2.Value = _textobuscar2;
                SqlCmd.Parameters.Add(ParTextoBuscar2);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;

            }
            return DtResultado;
        }


        public DataTable MostrarDetalle(string _textobuscar)
        {
            DataTable DtResultado = new DataTable("Detalle_ingreso");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_detalle_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 20;
                ParTextoBuscar.Value = _textobuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;

            }
            return DtResultado;
        }



    }
}
