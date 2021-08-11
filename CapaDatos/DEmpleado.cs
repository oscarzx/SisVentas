using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DEmpleado
    {
        private int idEmpleado;

        public int IdEmpleado
        {
            get { return idEmpleado; }
            set { idEmpleado = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string apellidos;

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        private string genero;

        public string Genero
        {
            get { return genero; }
            set { genero = value; }
        }

        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private string numeroDocumento;

        public string NumeroDocumento
        {
            get { return numeroDocumento; }
            set { numeroDocumento = value; }
        }

        private string direccion;

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        private string telefono;

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string acceso;

        public string Acceso
        {
            get { return acceso; }
            set { acceso = value; }
        }

        private string usuario;

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string textoBuscar;

        public string TextoBuscar
        {
            get { return textoBuscar; }
            set { textoBuscar = value; }
        }



        public DEmpleado()
        {

        }


        public DEmpleado(int _idempleado, string _nombre, string _apellido, string _genero,
            DateTime _fecha, string _numero_documento, string _direccion, string _telefono,
            string _email, string _acceso, string _usuario, string _password)
        {
            this.Acceso = _acceso;
            this.Apellidos = _apellido;
            this.Direccion = _direccion;
            this.Email = _email;
            this.Fecha = _fecha;
            this.Genero = _genero;
            this.IdEmpleado = _idempleado;
            this.Nombre = _nombre;
            this.NumeroDocumento = _numero_documento;
            this.Password = _password;
            this.Telefono = _telefono;
            this.Usuario = _usuario;
        }

        //Método Insertar
        public string Insertar(DEmpleado Empleado)
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
                Sqlcmd.CommandText = "spinsertar_empleado";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdEmpleado = new SqlParameter();
                ParIdEmpleado.ParameterName = "@idempleado";
                ParIdEmpleado.SqlDbType = SqlDbType.Int;
                ParIdEmpleado.Direction = ParameterDirection.Output;
                Sqlcmd.Parameters.Add(ParIdEmpleado);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 20;
                ParNombre.Value = Empleado.Nombre;
                Sqlcmd.Parameters.Add(ParNombre);

                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellidos";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 50;
                ParApellido.Value = Empleado.Apellidos;
                Sqlcmd.Parameters.Add(ParApellido);

                SqlParameter ParGenero = new SqlParameter();
                ParGenero.ParameterName = "@genero";
                ParGenero.SqlDbType = SqlDbType.VarChar;
                ParGenero.Size = 1;
                ParGenero.Value = Empleado.Genero;
                Sqlcmd.Parameters.Add(ParGenero);

                SqlParameter ParFechaNacimiento = new SqlParameter();
                ParFechaNacimiento.ParameterName = "@feha";
                ParFechaNacimiento.SqlDbType = SqlDbType.DateTime;
                ParFechaNacimiento.Value = Empleado.Fecha;
                Sqlcmd.Parameters.Add(ParFechaNacimiento);

                SqlParameter ParNumDocumento = new SqlParameter();
                ParNumDocumento.ParameterName = "@numero_documento";
                ParNumDocumento.SqlDbType = SqlDbType.VarChar;
                ParNumDocumento.Size = 12;
                ParNumDocumento.Value = Empleado.NumeroDocumento;
                Sqlcmd.Parameters.Add(ParNumDocumento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Empleado.Direccion;
                Sqlcmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 10;
                ParTelefono.Value = Empleado.Telefono;
                Sqlcmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Empleado.Email;
                Sqlcmd.Parameters.Add(ParEmail);

                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@acceso";
                ParAcceso.SqlDbType = SqlDbType.VarChar;
                ParAcceso.Size = 20;
                ParAcceso.Value = Empleado.Acceso;
                Sqlcmd.Parameters.Add(ParAcceso);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Empleado.Usuario;
                Sqlcmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 20;
                ParPassword.Value = Empleado.Password;
                Sqlcmd.Parameters.Add(ParPassword);

                //Ejecutamos nuestro comando
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

        public string Editar(DEmpleado Empleado)
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
                Sqlcmd.CommandText = "speditar_empleado";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdEmpleado = new SqlParameter();
                ParIdEmpleado.ParameterName = "@idempleado";
                ParIdEmpleado.SqlDbType = SqlDbType.Int;
                ParIdEmpleado.Value = Empleado.idEmpleado;
                Sqlcmd.Parameters.Add(ParIdEmpleado);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 20;
                ParNombre.Value = Empleado.Nombre;
                Sqlcmd.Parameters.Add(ParNombre);

                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellidos";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 50;
                ParApellido.Value = Empleado.Apellidos;
                Sqlcmd.Parameters.Add(ParApellido);

                SqlParameter ParGenero = new SqlParameter();
                ParGenero.ParameterName = "@genero";
                ParGenero.SqlDbType = SqlDbType.VarChar;
                ParGenero.Size = 1;
                ParGenero.Value = Empleado.Genero;
                Sqlcmd.Parameters.Add(ParGenero);

                SqlParameter ParFechaNacimiento = new SqlParameter();
                ParFechaNacimiento.ParameterName = "@feha";
                ParFechaNacimiento.SqlDbType = SqlDbType.DateTime;
                ParFechaNacimiento.Value = Empleado.Fecha;
                Sqlcmd.Parameters.Add(ParFechaNacimiento);

                SqlParameter ParNumDocumento = new SqlParameter();
                ParNumDocumento.ParameterName = "@numero_documento";
                ParNumDocumento.SqlDbType = SqlDbType.VarChar;
                ParNumDocumento.Size = 12;
                ParNumDocumento.Value = Empleado.NumeroDocumento;
                Sqlcmd.Parameters.Add(ParNumDocumento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Empleado.Direccion;
                Sqlcmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 10;
                ParTelefono.Value = Empleado.Telefono;
                Sqlcmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Empleado.Email;
                Sqlcmd.Parameters.Add(ParEmail);

                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@acceso";
                ParAcceso.SqlDbType = SqlDbType.VarChar;
                ParAcceso.Size = 20;
                ParAcceso.Value = Empleado.Acceso;
                Sqlcmd.Parameters.Add(ParAcceso);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Empleado.Usuario;
                Sqlcmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 20;
                ParPassword.Value = Empleado.Password;
                Sqlcmd.Parameters.Add(ParPassword);

                //Ejecutamos nuestro comando
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

        public string Eliminar(DEmpleado Empleado)
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
                Sqlcmd.CommandText = "speliminar_empleado";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdempleado = new SqlParameter();
                ParIdempleado.ParameterName = "@idempleado";
                ParIdempleado.SqlDbType = SqlDbType.Int;
                ParIdempleado.Value = Empleado.idEmpleado;
                Sqlcmd.Parameters.Add(ParIdempleado);

                //Ejecutamos nuestro comando
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
            DataTable DtResultado = new DataTable("Empleado");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_empleado";
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

        public DataTable BuscarEmpleado_Documento(DEmpleado Empleado)
        {
            DataTable DtResultado = new DataTable("Empleado");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_empleado_num_docmento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParEmpleadoDocumento = new SqlParameter();
                ParEmpleadoDocumento.ParameterName = "@textoBuscar";
                ParEmpleadoDocumento.SqlDbType = SqlDbType.VarChar;
                ParEmpleadoDocumento.Size = 50;
                ParEmpleadoDocumento.Value = Empleado.TextoBuscar;
                SqlCmd.Parameters.Add(ParEmpleadoDocumento);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;

            }
            return DtResultado;
        }

        public DataTable BuscarApellido_Empleado(DEmpleado Empleado)
        {
            DataTable DtResultado = new DataTable("Empleado");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_empleado_apellidos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Empleado.TextoBuscar;
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

        public DataTable Login(DEmpleado Empleado)
        {
            DataTable DtResultado = new DataTable("Empleado");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "splogin";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Empleado.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 20;
                ParPassword.Value = Empleado.Password;
                SqlCmd.Parameters.Add(ParPassword);

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
