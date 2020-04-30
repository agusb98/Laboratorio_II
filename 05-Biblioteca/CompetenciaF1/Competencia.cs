using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Competencia
    {
        #region Nested Types
        public enum TipoCompetencia
        {
            F1, MotoCross
        }

        #endregion

        #region Fields

        private short cantidadCompetidores;
        private short cantidadVueltas;
        private List<VehiculoDeCarreras> competidores;
        private TipoCompetencia tipo;

        #endregion

        #region Properties

        public short CantidadCompetidores
        {
            get
            {
                return this.cantidadCompetidores;
            }
            set
            {
                if (value > 0)
                    this.cantidadCompetidores = value;
            }
        }

        public short CantidadVueltas
        {
            get
            {
                return this.cantidadVueltas;
            }
            set
            {
                if (value > 0)
                    this.cantidadVueltas = value;
            }
        }

        public VehiculoDeCarreras this[int i]
        {
            get
            {
                return this[i];
            }
        }

        public TipoCompetencia Tipo
        {
            get
            {
                return this.tipo;
            }
            set
            {
                this.tipo = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Instancia nueva Competencia con atributos vacio
        /// </summary>
        private Competencia()
        {
            competidores = new List<VehiculoDeCarreras>();
        }

        /// <summary>
        /// Instancia nueva Competencia con atributos pasados por parametro
        /// </summary>
        /// <param name="cantidadVueltas"></param>
        /// <param name="cantidadCompetidores"></param>
        /// <param name="tipo"></param>
        public Competencia(short cantidadVueltas, short cantidadCompetidores, TipoCompetencia tipo)
            : this()
        {
            this.CantidadVueltas = cantidadVueltas;
            this.CantidadCompetidores = cantidadCompetidores;
            this.Tipo = tipo;
        }

        /// <summary>
        /// Muestra por pantalla los atributos de Competencia
        /// </summary>
        /// <returns></returns> Retorna string con los datos mostrados por pantalla
        public string MostrarDatos()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("Cantidad de Competidores: " + CantidadCompetidores);
            str.AppendLine("Cantidad de Vueltas: " + CantidadVueltas);
            str.AppendLine("Tipo de Competencia: " + Tipo);
            str.AppendLine("\n----------------------------------------------------------\n");

            for (int i = 0; i < this.competidores.Count; i++)
            {
                str.AppendLine(this.competidores[i].Mostrar());
            }

            str.AppendLine("----------------------------------------------------------");
            return str.ToString();
        }

        /// <summary>
        /// Agrega un Vehiculo de Carreras a la Competencia
        /// </summary>
        /// <param name="c"><Competencia/param>
        /// <param name="a"><Vehiculo de Carreras/param>
        /// <returns></returns>
        public static bool operator +(Competencia c, VehiculoDeCarreras a)
        {
            if (c.competidores.Count < c.cantidadCompetidores && c != a)
            {
                Random r = new Random();

                switch (c.Tipo)
                {
                    case TipoCompetencia.F1:
                        if (a is AutoF1)
                        {
                            a.CantidadCombustible = (short)r.Next(0, 15);
                            a.VueltasRestantes = c.cantidadVueltas;
                            a.EnCompetencia = true;
                            c.competidores.Add(a);
                            return true;
                        }
                        break;

                    case TipoCompetencia.MotoCross:
                        if (a is MotoCross)
                        {
                            a.EnCompetencia = true;
                            a.VueltasRestantes = c.CantidadVueltas;
                            a.CantidadCombustible = (short)new Random().Next(15, 100);
                            c.competidores.Add(a);
                            return true;
                        }
                        break;
                }
            }
            return false;
        }

        /// <summary>
        /// Remueve AutoF1 de la Competencia
        /// </summary>
        /// <param name="c"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator -(Competencia c, AutoF1 a)
        {
            if (c.competidores.Contains(a))
            {
                a.EnCompetencia = false;
                a.VueltasRestantes = 0;
                a.CantidadCombustible = 0;
                c.competidores.Remove(a);

                return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica igualdad entre los autos en Competencia y Vehiculo
        /// </summary>
        /// <param name="c"><Competencia/param>
        /// <param name="a"><Vehiculo de Carreras/param>
        /// <returns></returns>
        public static bool operator ==(Competencia c, VehiculoDeCarreras a)
        {
            return c.competidores.Contains(a);
        }

        /// <summary>
        /// Verifica desigualdad  entre los autos en Competencia y Vehiculo
        /// </summary>
        /// <param name="c"><Competencia/param>
        /// <param name="a"><Vehiculo de Carreras/param>
        /// <returns></returns>
        public static bool operator !=(Competencia c, VehiculoDeCarreras a)
        {
            return !(c == a);
        }
        #endregion
    }
}
