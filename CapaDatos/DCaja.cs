using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DCaja
    {
        private int idCaja;

        public int IdCaja
        {
            get { return idCaja; }
            set { idCaja = value; }
        }

        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private string serialPc;

        public string SerialPc
        {
            get { return serialPc; }
            set { serialPc = value; }
        }

        private string impresoraTicket;

        public string ImpresoraTicket
        {
            get { return impresoraTicket; }
            set { impresoraTicket = value; }
        }

        private string impresoraA4;

        public string ImpresoraA4
        {
            get { return impresoraA4; }
            set { impresoraA4 = value; }
        }


        public DCaja()
        {

        }

        public DCaja(int _idCaja, string _descripcion, string _serialPc, string _impresoraTicket,
            string _impresoraA4)
        {
            this.Descripcion = _descripcion;
            this.IdCaja = _idCaja;
            this.ImpresoraA4 = _impresoraA4;
            this.ImpresoraTicket = _impresoraTicket;
            this.SerialPc = _serialPc;
        }

        public string InsertarCaja(DCaja Caja)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = SqlCon;
                Sqlcmd.CommandText = "spInsertar_caja";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdArticulo = new SqlParameter();
                parIdArticulo.ParameterName = "@idcaja";
                parIdArticulo.SqlDbType = SqlDbType.Int;
                parIdArticulo.Direction = ParameterDirection.Output;
                Sqlcmd.Parameters.Add(parIdArticulo);

                SqlParameter parDescripcion = new SqlParameter();
                parDescripcion.ParameterName = "@descripcion";
                parDescripcion.SqlDbType = SqlDbType.VarChar;
                parDescripcion.Size = 50;
                parDescripcion.Value = Caja.Descripcion;
                Sqlcmd.Parameters.Add(parDescripcion);

                SqlParameter parSerialPC = new SqlParameter();
                parSerialPC.ParameterName = "@serial_pc";
                parSerialPC.SqlDbType = SqlDbType.VarChar;
                parSerialPC.Size = 50;
                parSerialPC.Value = Caja.SerialPc;
                Sqlcmd.Parameters.Add(parSerialPC);

                SqlParameter parImpresoraTicket = new SqlParameter();
                parImpresoraTicket.ParameterName = "@impresora_ticket";
                parImpresoraTicket.SqlDbType = SqlDbType.VarChar;
                parImpresoraTicket.Size = 100;
                parImpresoraTicket.Value = Caja.ImpresoraTicket;
                Sqlcmd.Parameters.Add(parImpresoraTicket);

                SqlParameter parImpresoraA4 = new SqlParameter();
                parImpresoraA4.ParameterName = "@impresora_a4";
                parImpresoraA4.SqlDbType = SqlDbType.VarChar;
                parImpresoraA4.Size = 100;
                parImpresoraA4.Value = Caja.ImpresoraA4;
                Sqlcmd.Parameters.Add(parImpresoraA4);

                rpta = Sqlcmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingresó el registro";
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

        public string EditarCaja(DCaja Caja)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = SqlCon;
                Sqlcmd.CommandText = "spEditar_caja";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdArticulo = new SqlParameter();
                parIdArticulo.ParameterName = "@idcaja";
                parIdArticulo.SqlDbType = SqlDbType.Int;
                parIdArticulo.Value = Caja.IdCaja;
                Sqlcmd.Parameters.Add(parIdArticulo);

                SqlParameter parDescripcion = new SqlParameter();
                parDescripcion.ParameterName = "@descripcion";
                parDescripcion.SqlDbType = SqlDbType.VarChar;
                parDescripcion.Size = 50;
                parDescripcion.Value = Caja.Descripcion;
                Sqlcmd.Parameters.Add(parDescripcion);

                SqlParameter parSerialPC = new SqlParameter();
                parSerialPC.ParameterName = "@serial_pc";
                parSerialPC.SqlDbType = SqlDbType.VarChar;
                parSerialPC.Size = 50;
                parSerialPC.Value = Caja.SerialPc;
                Sqlcmd.Parameters.Add(parSerialPC);

                SqlParameter parImpresoraTicket = new SqlParameter();
                parImpresoraTicket.ParameterName = "@impresora_ticket";
                parImpresoraTicket.SqlDbType = SqlDbType.VarChar;
                parImpresoraTicket.Size = 100;
                parImpresoraTicket.Value = Caja.ImpresoraTicket;
                Sqlcmd.Parameters.Add(parImpresoraTicket);

                SqlParameter parImpresoraA4 = new SqlParameter();
                parImpresoraA4.ParameterName = "@impresora_a4";
                parImpresoraA4.SqlDbType = SqlDbType.VarChar;
                parImpresoraA4.Size = 100;
                parImpresoraA4.Value = Caja.ImpresoraA4;
                Sqlcmd.Parameters.Add(parImpresoraA4);

                rpta = Sqlcmd.ExecuteNonQuery() == 1 ? "OK" : "No se actualizó el registro";
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

        public string EliminarCaja(DCaja Caja)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = SqlCon;
                Sqlcmd.CommandText = "spEliminar_caja";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdArticulo = new SqlParameter();
                parIdArticulo.ParameterName = "@idcaja";
                parIdArticulo.SqlDbType = SqlDbType.Int;
                parIdArticulo.Value = Caja.IdCaja;
                Sqlcmd.Parameters.Add(parIdArticulo);

                rpta = Sqlcmd.ExecuteNonQuery() == 1 ? "OK" : "No se eliminó el registro";
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

        public DataTable Mostrar()
        {
            DataTable dtResultado = new DataTable("Caja");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.Cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "spMostrar_caja";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                adapter.Fill(dtResultado);
            }
            catch (Exception)
            {
                dtResultado = null;
            }
            return dtResultado;
        }

        public DataTable BuscarCajaNombre(DCaja Caja)
        {
            DataTable dtResultado = new DataTable("Caja");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.Cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "spMostrar_caja_nombre";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parBuscarCaja = new SqlParameter();
                parBuscarCaja.ParameterName = "@nombreCaj";
                parBuscarCaja.SqlDbType = SqlDbType.VarChar;
                parBuscarCaja.Size = 50;
                parBuscarCaja.Value = Caja.Descripcion;
                sqlCmd.Parameters.Add(parBuscarCaja);

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                adapter.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }
            return dtResultado;
        }

        public DataTable MostrarListado()
        {
            DataTable DtResultado = new DataTable("Caja");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spMostrar_Cajas_lista";
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
    }
}
