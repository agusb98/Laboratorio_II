using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    public class Universidad
    {
        #region Campos

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad de Escritura y Lectura para lista de Alumnos de la Universidad
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        /// <summary>
        /// Propiedad de Escritura y Lectura para lista de Profesores de la Universidad
        /// </summary>
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        /// <summary>
        /// Propiedad de Escritura y Lectura para lista de Jornadas de la Universidad
        /// </summary>
        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }

        /// <summary>
        /// Propiedad de Escritura y Lectura para una det Jornada de la Universidad
        /// </summary>
        public Jornada this[int i]
        {
            get { return this.jornada[i]; }
            set { this.jornada[i] = value; }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor para los atributos de Universidad
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Guarda un archivo XML con los datos de la Universidad.
        /// </summary>
        /// <param name="uni">Universidad a serializar.</param>
        /// <returns>Verdadero si pudo escribir el archivo. Falso si algo salió mal.</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            try
            {
                xml.Guardar("Universidad.xml", uni);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Lee un archivo XML con los datos de una Universidad.
        /// </summary>
        /// <returns>Instancia de Universidad con los datos del archivo.</returns>
        public static Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            Universidad universidad;
            try
            {
                xml.Leer("Universidad.xml", out universidad);
            }
            catch
            {
                universidad = null;
            }
            return universidad;
        }

        /// <summary>
        /// Devuelve en formato de texto los datos de Universidad.
        /// </summary>
        /// <returns>Una cadena de caracteres que representa los datos de Universidad.</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");

            foreach (Jornada jornada in uni.Jornadas)
                sb.AppendLine(jornada.ToString());

            return sb.ToString();
        }

        /// <summary>
        /// Valida existencia de Alumno en Universidad
        /// </summary>
        /// <param name="g"></Universidad>
        /// <param name="a"></Alumno>
        /// <returns></True si Alumno está en Universidad, False si no>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == a)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Valida la no existencia de Alumno en Universidad
        /// </summary>
        /// <param name="g"></Universidad>
        /// <param name="a"></Alumno>
        /// <returns></False si Alumno está en Universidad, Ture si no>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Valida existencia de Profesor en Universidad
        /// </summary>
        /// <param name="g"></Universidad>
        /// <param name="a"></Profesor>
        /// <returns></True si Profesor está en Universidad, False si no>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor profesor in g.Instructores)
            {
                if (i == profesor)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Valida la no existencia de Profesor en Universidad
        /// </summary>
        /// <param name="g"></Universidad>
        /// <param name="a"></Profesor>
        /// <returns></False si Profesor está en Universidad, True si no>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Profesor operator ==(Universidad u, Universidad.EClases clase)
        {
            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor == clase)
                    return profesor;
            }

            throw new SinProfesorException();
        }

        public static Profesor operator !=(Universidad u, Universidad.EClases clase)
        {
            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor != clase)
                    return profesor;
            }
            return null;
        }

        /// <summary>
        /// Agrega una Clase a una Universidad, si este no está en la lista.
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Una instancia de Universidad con la Clase agregada.</returns>
        public static Universidad operator +(Universidad g, Universidad.EClases clase)
        {
            Jornada jornada = new Jornada(clase, g == clase);

            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == clase)
                    jornada.Alumnos.Add(alumno);
            }
            g.Jornadas.Add(jornada);

            return g;
        }

        /// <summary>
        /// Agrega un Profesor a una Universidad, si este no está en la lista.
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>Una instancia de Universidad con el Profesor agregado.</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u == i)
            {
                Console.WriteLine("{0} ya se encuentra en la Universidad\n", i.Nombre);
            }

            u.Instructores.Add(i);

            return u;
        }

        /// <summary>
        /// Agrega un Alumno a una Universidad, si este no está en la lista.
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Una instancia de Universidad con el Alumno agregado.</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u == a)
            {
                Console.WriteLine("{0} ya se encuentra en la Universidad\n", a.Nombre);
            }

            u.Alumnos.Add(a);

            return u;
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }

        #endregion

        #region Tipos Anidados

        /// <summary>
        /// Valores de estado de cuenta utilizados en la clase Universidad
        /// </summary>
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }

        #endregion
    }
}
