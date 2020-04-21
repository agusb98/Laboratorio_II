using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        int legajo;

        #region Metodos
        public Universitario() : base() { }

        /* Llama al constructor correspondiente de Persona */
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        /// <summary>
        /// Verifica que el objeto en cuestión y la referencia por parámetro sean ambos Alumno o Profesor.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this.GetType() == obj.GetType();
        }

        /// <summary>
        /// Llama a la función base y muestra además el número de legajo.
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("LEGAJO NÚMERO: " + this.legajo);

            return sb.ToString();
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2) && (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo);
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Muestra el curso al que asiste la entidad.
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        #endregion
    }
}
