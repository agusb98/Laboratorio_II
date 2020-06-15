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
        #region Campos

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor para los atributos de Alumno
        /// </summary>
        public Alumno() : base() { }

        /// <summary>
        /// Constructor para los atributos de Alumno
        /// </summary>
        public Alumno(int id, string nombre, string apellido, string dni, Persona.ENacionalidad nacionalidad, Universidad.EClases clasesQueToma) :
            base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = clasesQueToma;
        }

        /// <summary>
        /// Constructor para los atributos de Alumno
        /// </summary>
        public Alumno(int id, string nombre, string apellido, string dni, Persona.ENacionalidad nacionalidad, Universidad.EClases clasesQueToma, EEstadoCuenta estadoCuenta) :
            this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Devuelve en formato de texto los datos de Alumno.
        /// </summary>
        /// <returns>Una cadena de caracteres que representa los datos de Alumno.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            if (!(this is null))
            {
                sb.AppendFormat(base.MostrarDatos());
                sb.AppendFormat("\n{0}", ParticiparEnClase());
                sb.AppendFormat("ESTADO DE CUENTA: {0}\n", this.estadoCuenta);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Metodo abstracto, Muestra las clases en la que Alumno se encuentra
        /// </summary>
        /// <returns></string con los datos de la clases>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            if (!(this is null))
            {
                sb.AppendFormat("TOMA CLASE DE {0}\n", this.claseQueToma);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Valida si Alumno participa en una clase
        /// </summary>
        /// <param name="a">Alumno.</param>
        /// <param name="clase">Clase.</param>
        /// <returns>Verdadero si Alumno se encuentra en la clase.</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return a.estadoCuenta != EEstadoCuenta.Deudor && clase == a.claseQueToma;
        }

        /// <summary>
        /// Valida si Alumno no participa en una clase
        /// </summary>
        /// <param name="a">Alumno.</param>
        /// <param name="clase">Clase.</param>
        /// <returns>Falso si Alumno se encuentra en la clase.</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma != clase;
        }

        /// <summary>
        /// Devuelve en formato de texto los datos de Alumno.
        /// </summary>
        /// <returns>Una cadena de caracteres que representa los datos de Alumno.</returns>
        public override string ToString()
        {
            return MostrarDatos();
        }

        #endregion

        #region Tipos Anidados

        /// <summary>
        /// Valores de estado de cuenta utilizados en la clase Alumno
        /// </summary>
        public enum EEstadoCuenta { AlDia, Deudor, Becado }

        #endregion
    }
}
