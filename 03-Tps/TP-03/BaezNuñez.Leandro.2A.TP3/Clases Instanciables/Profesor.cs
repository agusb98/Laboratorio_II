using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        #region Campos

        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor para los atributos estaticos de Profesor
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// Constructor para los atributos de Profesor
        /// </summary>
        public Profesor() : base() { }

        /// <summary>
        /// Constructor para los atributos de Profesor
        /// </summary>
        public Profesor(int id, string nombre, string apellido, string dni, Persona.ENacionalidad nacionalidad) :
            base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Asigna dos clases aleatorias al profesor.
        /// </summary>
        private void _randomClases()
        {
            Array aux = Enum.GetValues(typeof(Universidad.EClases));

            for (byte i = 0; i < 2; i++)
                this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, aux.Length));
        }

        /// <summary>
        /// Devuelve en formato de texto los datos de Profesor.
        /// </summary>
        /// <returns>Una cadena de caracteres que representa los datos de Profesor.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            if (!(this is null))
            {
                sb.AppendFormat(base.MostrarDatos());
                sb.AppendFormat("{0}\n", ParticiparEnClase());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Metodo abstracto, Muestra las clases en la que Profesor se encuentra
        /// </summary>
        /// <returns></string con los datos de la clases>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            if (!(this is null))
            {
                sb.AppendFormat("CLASES DEL DÍA:\n");
                foreach (Universidad.EClases c in this.clasesDelDia)
                {
                    sb.AppendFormat(c.ToString() + "\n");
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Verifica si el Profesor participa de la clase.
        /// </summary>
        /// <param name="i">Un profesor.</param>
        /// <param name="clase">Una clase.</param>
        /// <returns>Verdadero si es profesor de esa clase.</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach(Universidad.EClases c in i.clasesDelDia)
            {
                if (c == clase)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Verifica si el Profesor no participa de la clase.
        /// </summary>
        /// <param name="i">Un profesor.</param>
        /// <param name="clase">Una clase.</param>
        /// <returns>Falso si es profesor de esa clase.</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Devuelve en formato de texto los datos de Profesor.
        /// </summary>
        /// <returns>Una cadena de caracteres que representa los datos de Profesor.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
