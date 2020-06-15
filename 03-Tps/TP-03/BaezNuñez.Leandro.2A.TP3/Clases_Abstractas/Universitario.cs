using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Campos

        private int legajo;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor para los atributos de Universitario
        /// </summary>
        public Universitario() : base() { }

        /// <summary>
        /// Constructor para los atributos de Universitario
        /// </summary>
        public Universitario(int legajo, string nombre, string apellido, string dni, Persona.ENacionalidad nacionalidad) :
            base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Verifica si el objeto es igual al argumento.
        /// </summary>
        /// <param name="obj">Argumento con el cual comparar.</param>
        /// <returns>Verdadero, si los objetis son iguales.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Universitario)
            {
                return (this == (Universitario)obj);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Devuelve en formato de texto los datos de la Universitario.
        /// </summary>
        /// <returns>Una cadena de caracteres que representa los datos de Universitario.</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            if (!(this is null))
            {
                sb.AppendFormat(base.ToString());
                sb.AppendFormat("\nLEGAJO: {0}\n", this.legajo);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Metodo abstracto, Muestra las clases en la que Universitario se encuentra
        /// </summary>
        /// <returns></string con los datos de la clases>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Compara dos instancias de Universitario.
        /// </summary>
        /// <param name="pg1">Primer Universitario.</param>
        /// <param name="pg2">Segundo Universitario.</param>
        /// <returns>Verdadero si tienen el mismo DNI o legajo.</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.GetType() == pg2.GetType() && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI);
        }

        /// <summary>
        /// Compara dos instancias de Universitario.
        /// </summary>
        /// <param name="pg1">Primer Universitario.</param>
        /// <param name="pg2">Segundo Universitario.</param>
        /// <returns>Falso si tienen el mismo DNI o legajo.</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion
    }
}
