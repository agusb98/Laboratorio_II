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
        Queue<Universidad.EClases> clasesDelDia;
        static Random random;

        #region Metodos
        /// <summary>
        /// Método privado que asigna dos cursos al profesor de manera aleatoria.
        /// </summary>
        private void _randomClases()
        {
            const int cantidadDeCursos = 2;
            for (int i = 0; i < cantidadDeCursos; i++)
            {
                this.clasesDelDia.Enqueue((Universidad.EClases)(Profesor.random.Next(4)));
            }
        }

        /// <summary>
        /// Muestra el nombre, apellido, legajo y el curso que da.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            return i.clasesDelDia.Contains(clase);
        }
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Devuelve una cadena que indica los cursos que dicta el profesor.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DÍA:");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }

            return sb.ToString();
        }
        
        public Profesor() : base() { }
        
        /// <summary>
        /// Constructor estático que inicializa un objeto de la clase Random.
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }
        /* Constructor que llama a la clase base Universitario */
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        /// <summary>
        /// Llama al método privado MostrarDatos() para desplegar por pantalla toda la información del profesor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
