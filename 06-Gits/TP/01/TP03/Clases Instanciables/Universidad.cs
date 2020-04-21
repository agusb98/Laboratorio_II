using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Universidad : Xml<Universidad>, IArchivos<Universidad>
    {
        List<Alumno> alumnos;
        List<Jornada> jornada;
        List<Profesor> profesores;

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

        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Genera un archivo en disco en formato XML que contiene la información de la Universidad.
        /// </summary>
        /// <param name="uni">Objeto que se guardará en el archivo, en formato XML.</param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return ((IArchivos<Universidad>)xml).Guardar("Universidad.xml", uni);
        }
        /// <summary>
        /// Lee objetos Universidad contenidos en un archivo XML.
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            Universidad uni = new Universidad();
            ((IArchivos<Universidad>)xml).Leer("Universidad.xml", out uni);

            return uni;
        }

        /// <summary>
        /// Muestra cada jornada de la Universidad.
        /// </summary>
        /// <param name="uni">Objeto al que hará referencia.</param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            foreach (Jornada jornada in uni.Jornadas)
            {
                sb.AppendLine(jornada.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Llama al método estático privado MostrarDatos, revelando todos los datos de las jornadas.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }
        #endregion

        #region Operadores
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == a)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor instructor in g.Instructores)
            {
                if (instructor == i)
                {
                    return true;
                }
            }
            return false;
        }
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor instructor in g.Instructores)
            {
                if (instructor == clase)
                {
                    return instructor;
                }
            }

            throw new SinProfesorException();
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor instructor in g.Instructores)
            {
                if (instructor != clase)
                {
                    return instructor;
                }
            }

            throw new SinProfesorException();
        }

        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g.Alumnos.Add(a);
                return g;
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
        }
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.Instructores.Add(i);
            }
            return g;
        }
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor instructor = (g == clase);
            Jornada jornada = new Jornada(clase, instructor);
            foreach (Alumno estudiante in g.Alumnos)
            {
                if (estudiante == clase)
                {
                    jornada += estudiante;
                }
            }
            g.Jornadas.Add(jornada);

            return g;
        }
        #endregion
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
    }
}
