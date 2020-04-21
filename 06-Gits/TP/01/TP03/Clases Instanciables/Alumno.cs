using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        Universidad.EClases claseQueToma;
        EEstadoCuenta estadoCuenta;

        #region Metodos
        public Alumno() : base() { }

        /* Llama al constructor base de Universitario */
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Muestra el nombre, apellido, legajo, estado de cuenta y la clase en la que asiste.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.AppendLine("ESTADO DE CUENTA: " + this.estadoCuenta);
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor;
        }
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a.claseQueToma == clase);
        }

        /// <summary>
        /// Devuelve una cadena que indica la clase en la que participa el alumno.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this.claseQueToma;
        }

        /// <summary>
        /// Llama al método privado MostrarDatos() para desplegar por pantalla toda la información del alumno.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
    }

}
