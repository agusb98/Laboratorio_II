using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region Campos

        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad de Escritura y Lectura para lista de Alumnos de la Jornada
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        /// <summary>
        /// Propiedad de Escritura y Lectura para la Clase de la Jornada
        /// </summary>
        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        /// <summary>
        /// Propiedad de Escritura y Lectura para lista de Profesores de la Jornada
        /// </summary>
        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor para los atributos de Jornada
        /// </summary>
        private Jornada() { this.alumnos = new List<Alumno>(); }

        /// <summary>
        /// Constructor para los atributos de Jornada
        /// </summary>
        public Jornada(Universidad.EClases clase, Profesor instructor): this()
        {
            Clase = clase;
            Instructor = instructor;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Guarda los datos de la Jornada en un archivo de texto "Jornada.txt".
        /// </summary>
        /// <param name="jornada">Instancia de Jornada a guardar.</param>
        /// <returns>Verdadero si pudo escribir el archivo. Falso si algo salió mal.</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            try
            {
                texto.Guardar("Jornada.txt", jornada.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Lee los datos del archivo "Jornada.txt".
        /// </summary>
        /// <returns>Una cadena de caracteres con los datos de la Jornada en el archivo.</returns>
        public static string Leer(Universidad.EClases clase, Profesor instructor)
        {
            Texto texto = new Texto();
            try
            {
                string datos;
                texto.Leer("Jornada.txt", out datos);
                return datos;
            }
            catch
            {
                return "Error al leer 'Jornada.txt'";
            }
        }

        /// <summary>
        /// Valida que el alumno se encuentre en la jornada
        /// </summary>
        /// <param name="j"></Jornada>
        /// <param name="a"></Alumno>
        /// <returns></True si Alumno se encuentra en Jornada, False si no>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach(Alumno alumno in j.Alumnos)
            {
                if (alumno == a)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Valida que el alumno se no encuentre en la jornada
        /// </summary>
        /// <param name="j"></Jornada>
        /// <param name="a"></Alumno>
        /// <returns></False si Alumno se encuentra en Jornada, True si no>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un Alumno en la Jornada
        /// </summary>
        /// <param name="j"></Jornada>
        /// <param name="a"></Alumno>
        /// <returns></Jornada>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j == a)
            {
                Console.WriteLine("{0} ya se encuentra en la Jornada\n", a.Nombre);
            }

            j.Alumnos.Add(a);

            return j;
        }

        /// <summary>
        /// Devuelve en formato de texto los datos de Jornada.
        /// </summary>
        /// <returns>Una cadena de caracteres que representa los datos de Jornada.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CLASE DE {0} POR ", this.Clase);
            sb.AppendFormat(this.Instructor.ToString());
            sb.AppendLine("ALUMNOS:");

            foreach (Alumno alumno in this.alumnos)
            {
                sb.AppendLine(alumno.ToString());
            }

            sb.Append("<------------------------------------------------>\n");
            return sb.ToString();
        }

        #endregion
    }
}
