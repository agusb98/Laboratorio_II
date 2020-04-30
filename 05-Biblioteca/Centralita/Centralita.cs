using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class Centralita
    {
        #region Fields

        private List<Llamada> listaDeLlamadas;
        protected string razonSocial;


        #endregion

        #region Methods

        /// <summary>
        /// Recibe una llamada y la agrela en la lista de llamadas
        /// </summary>
        /// <param name="nuevaLlamada"></param>
        private void AgregarLlamada(Llamada nuevaLlamada)
        {
            if (!listaDeLlamadas.Contains(nuevaLlamada))
            {
                this.listaDeLlamadas.Add(nuevaLlamada);
            }
        }

        /// <summary>
        /// Instancia nueva Lista de Llamadas con atributos vacio
        /// </summary>
        private Centralita()
        {
            listaDeLlamadas = new List<Llamada>();
        }

        /// <summary>
        /// Instancia nueva Centralita
        /// </summary>
        /// <param name="nombreEmpresa"></param>
        public Centralita(string nombreEmpresa) : this()
        {
            this.razonSocial = nombreEmpresa;
        }

        /// <summary>
        /// Muestra por pantalla los atributos de Centralita
        /// </summary>
        /// <returns></returns> Retorna string con los datos mostrados por pantalla
        public string Mostrar()
        {
            StringBuilder str = new StringBuilder();

            if (!(this is null))
            {
                str.AppendLine("Razón Social: " + this.razonSocial);
                str.AppendLine("Cantidad de Llamadas: " + this.listaDeLlamadas.Count);
                str.AppendLine("Ganancias por Local: " + GananciasPorLocal);
                str.AppendLine("Ganancias por Provincia: " + GananciasPorProvincial);
                str.AppendLine("Ganancias por Total: " + GananciasPorTotal);
                str.AppendLine("\n----------------------------------------------------------\n");

                foreach (Llamada v in this.listaDeLlamadas)
                {
                    str.AppendLine(v.ToString());
                }

                str.AppendLine("----------------------------------------------------------");
            }

            return str.ToString();
        }

        /// <summary>
        /// Retorna Ganancia dependiendo el tipo de llamada
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        private float CalcularGanancia(Llamada.TipoLlamada tipo)
        {
            float acum = 0;

            switch (tipo)
            {
                case Llamada.TipoLlamada.Provincial:
                    acum = GananciasPorProvincial;
                    break;
                case Llamada.TipoLlamada.Local:
                    acum = GananciasPorLocal;
                    break;
                case Llamada.TipoLlamada.Todas:
                    acum = GananciasPorTotal;
                    break;
            }
            return acum;
        }

        /// <summary>
        /// Ordena Llamadas 
        /// </summary>
        public void OrdenarLlamadas()
        {
            this.listaDeLlamadas.Sort(Llamada.OrdenarPorDuracion);
        }

        /// <summary>
        /// Valida si Centralita contiene la Llamada
        /// </summary>
        /// <param name="c"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        public static bool operator ==(Centralita c, Llamada l)
        {
            foreach (Llamada v in c.listaDeLlamadas)
            {
                if (v == l)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Valida que Centralita no contiene la Llamada
        /// </summary>
        /// <param name="c"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        public static bool operator !=(Centralita c, Llamada l)
        {
            return !(c == l);
        }

        public static bool operator +(Centralita c, Llamada l)
        {
            if (c == l)
            {
                return false;
            }

            else
            {
                c.AgregarLlamada(l);
                return true;
            }
        }
        #endregion

        #region Properties

        /// <summary>
        /// Retorna ganancias acumuladas por Local
        /// </summary>
        public float GananciasPorLocal
        {
            get
            {
                float acum = 0;
                foreach (Llamada llamada in this.listaDeLlamadas)
                {
                    if (llamada is Local)
                    {
                        acum += ((Local)llamada).CostoLlamada;
                    }
                }
                return acum;
            }
        }

        /// <summary>
        /// Retorna ganancias acumuladas por Provincia
        /// </summary>
        public float GananciasPorProvincial
        {
            get
            {
                float acum = 0;
                foreach (Llamada llamada in this.listaDeLlamadas)
                {
                    if (llamada is Provincial)
                    {
                        acum += ((Provincial)llamada).CostoLlamada;
                    }
                }
                return acum;
            }
        }

        /// <summary>
        /// Retorna ganancias acumuladas por Total
        /// </summary>
        public float GananciasPorTotal
        {
            get { return GananciasPorProvincial + GananciasPorLocal; }
        }

        /// <summary>
        /// Retorna lista de Llamadas 
        /// </summary>
        public List<Llamada> Llamadas
        {
            get { return this.listaDeLlamadas; }
        }

        #endregion
    }
}
