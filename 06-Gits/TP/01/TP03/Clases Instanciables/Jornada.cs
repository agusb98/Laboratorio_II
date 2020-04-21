using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada : Texto, IArchivos<string>
    {
        List<Alumno> alumnos;
        Universidad.EClases clase;
        Profesor instructor;

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                switch (value)
                {
                    case Universidad.EClases.Programacion:
                    case Universidad.EClases.Laboratorio:
                    case Universidad.EClases.Legislacion:
                    case Universidad.EClases.SPD:
                        this.clase = value;
                        break;
                    default:
                        break;
                }
            }
        }
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set 
            {
                this.instructor = value;
            }
        }
        #endregion
        #region Metodos
        /// <summary>
        /// Genera un archivo de texto que contiene toda la información utilizada en el método ToString().
        /// </summary>
        /// <param name="jornada">Referencia que se usará como contenido del archivo de texto.</param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            return ((IArchivos<string>)texto).Guardar("Jornada.txt", jornada.ToString());
        }

        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        /// <summary>
        /// Lee de un archivo de texto la información de todas las jornadas de una Universidad.
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            Texto texto = new Texto();
            string retorno;
            ((IArchivos<string>)texto).Leer("Jornada.txt", out retorno);
            
            return retorno;
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno alumno in j.Alumnos)
            {
                if (alumno == a)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }
            return j;
        }

        /// <summary>
        /// Muestra toda la información de una jornada, incluyendo tipo de clase, el docente y los alumnos inscriptos.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CLASE DE " + this.Clase);
            sb.Append(" POR " + this.Instructor.ToString());
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno alumno in this.Alumnos)
            {
                sb.Append(alumno.ToString());
            }

            sb.AppendLine("<---------------------------------------->");

            return sb.ToString();
        }
        #endregion
    }
}
