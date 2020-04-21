using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Competencia
    {
        #region Fields

        private short cantidadCompetidores;
        private List<AutoF1> competidores;
        private short cantidadVueltas;

        #endregion

        #region Methods

        private Competencia()
        {
            competidores = new List<AutoF1>();
        }

        public Competencia(short cantidadCompetidores, short cantidadVueltas)
            : this()
        {
            this.cantidadCompetidores = cantidadCompetidores;
            this.cantidadVueltas = cantidadVueltas;
        }

        public string Mostrar()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("Cantidad de Competidores: " + this.cantidadCompetidores + " Cantidad de Vueltas: " + this.cantidadVueltas);
            str.AppendLine("\n----------------------------------------------------------");

            for (int i = 0; i < this.competidores.Count; i++)
            {
                str.AppendLine(this.competidores[i].Mostrar());
            }

            return str.ToString();
        }

        public static bool operator +(Competencia c, AutoF1 a)
        {
            if (c.competidores.Count < c.cantidadCompetidores && !c.competidores.Contains(a))
            {
                Random r = new Random();

                a.CantidadCombustible = (short)r.Next(0, 15);
                a.VueltasRestantes = c.cantidadVueltas;
                a.EnCompetencia = true;

                c.competidores.Add(a);
                return true;
            }

            return false;
        }

        public static bool operator -(Competencia c, AutoF1 a)
        {
            if (c.competidores.Contains(a))
            {
                return c.competidores.Remove(a);
            }

            return false;
        }

        #endregion
    }
}
