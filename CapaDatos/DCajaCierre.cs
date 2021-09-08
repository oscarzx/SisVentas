using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCajaCierre
    {
        private int idCajaCierre;

        public int IdCajaCierre
        {
            get { return idCajaCierre; }
            set { idCajaCierre = value; }
        }

        private int idCaja;

        public int IdCaja
        {
            get { return idCaja; }
            set { idCaja = value; }
        }

        private DateTime fechaInicio;

        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }

        private DateTime fechaFin;

        public DateTime FechaFin
        {
            get { return fechaFin; }
            set { fechaFin = value; }
        }

        private DateTime fechaCierre;

        public DateTime FechaCierre
        {
            get { return fechaCierre; }
            set { fechaCierre = value; }
        }

        private decimal ingresos;

        public decimal Ingresos
        {
            get { return ingresos; }
            set { ingresos = value; }
        }

        private decimal egresos;

        public decimal Egresos
        {
            get { return egresos; }
            set { egresos = value; }
        }

        private decimal saldo;

        public decimal Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }

        private int idEmpleado;

        public int IdEmpleado
        {
            get { return idEmpleado; }
            set { idEmpleado = value; }
        }

        private decimal totalCalculado;

        public decimal TotalCalculado
        {
            get { return totalCalculado; }
            set { totalCalculado = value; }
        }

        private decimal totalReal;

        public decimal TotalReal
        {
            get { return totalReal; }
            set { totalReal = value; }
        }

        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private decimal diferencia;

        public decimal Diferencia
        {
            get { return diferencia; }
            set { diferencia = value; }
        }

        public DCajaCierre()
        {
            
        }

        public DCajaCierre(int _idCajaCierre, int _idCaja, DateTime _fechaInicio, DateTime _fechaFin,
            DateTime _fechaCierre, decimal _ingresos, decimal _egresos, decimal _saldo, int _idEmpleado,
            decimal _totalCalculado, decimal _totalReal, string _estado, decimal _diferencia)
        {
            this.Diferencia = _diferencia;
            this.Egresos = _egresos;
            this.Estado = _estado;
            this.FechaCierre = _fechaCierre;
            this.FechaFin = _fechaFin;
            this.FechaInicio = _fechaInicio;
            this.IdCaja = _idCaja;
            this.IdCajaCierre = _idCajaCierre;
            this.IdEmpleado = _idEmpleado;
            this.Ingresos = _ingresos;
            this.Saldo = _saldo;
            this.TotalCalculado = _totalCalculado;
            this.TotalReal = _totalReal;
        }

        public string Insertar(DCajaCierre CajaCierre)
        {

        }
    }
}
