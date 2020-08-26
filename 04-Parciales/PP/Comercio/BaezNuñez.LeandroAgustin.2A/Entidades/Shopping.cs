using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Shopping
    {
        #region Atributos

        private int _capacidad;
        private List<Comercio> _comercios;

        #endregion

        #region Propiedades

        public double PrecioDeExportadores
        {
            get
            {
                return this.ObtenerPrecio(EComercio.Exportador);
            }
        }

        public double PrecioDeImportadores
        {
            get
            {
                return this.ObtenerPrecio(EComercio.Importador);
            }
        }

        public double PrecioTotal
        {
            get
            {
                return this.ObtenerPrecio(EComercio.Ambos);
            }
        }

        #endregion

        #region Constructores
        private Shopping()
        {
            this._comercios = new List<Comercio>();
        }

        private Shopping(int capacidad) : this()
        {
            this._capacidad = capacidad;
        }
        #endregion

        #region Metodos

        public static implicit operator Shopping(int capacidad)
        {
            return new Shopping(capacidad);
        }

        public static string Mostrar(Shopping shopping)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("\n******************************************\n\n");
            sb.AppendFormat("Capacidad del Shopping: {0}\n", shopping._capacidad);
            sb.AppendFormat("Total por Importadores: ${0}\n", shopping.PrecioDeImportadores);
            sb.AppendFormat("Total por Exportadores: ${0}\n", shopping.PrecioDeExportadores);
            sb.AppendFormat("Total: ${0}\n", shopping.PrecioTotal);
            sb.AppendFormat("\n******************************************\n\n");

            foreach (Comercio comercio in shopping._comercios)
            {
                if (comercio is Exportador)
                {
                    sb.AppendFormat(((Exportador)comercio).Mostrar());
                }
                else if (comercio is Importador)
                {
                    sb.AppendFormat(((Importador)comercio).Mostrar());
                }

                sb.AppendFormat("\n\n");
            }
            sb.AppendFormat("\n******************************************\n");

            return sb.ToString();
        }

        public double ObtenerPrecio(EComercio tipoComercio)
        {
            double precioExportador = 0;
            double precioImportador = 0;
            double precioAmbos = 0;
            double retorno = 0;

            foreach (Comercio comercio in this._comercios)
            {
                if (comercio is Exportador)
                {
                    precioExportador += (Exportador)comercio;
                    precioAmbos += precioExportador;
                }
                else if (comercio is Importador)
                {
                    precioImportador += (Importador)comercio;
                    precioAmbos += precioImportador;
                }
            }
            switch (tipoComercio)
            {
                case EComercio.Exportador:
                    retorno = precioExportador;
                    break;
                case EComercio.Importador:
                    retorno = precioImportador;
                    break;
                case EComercio.Ambos:
                    retorno = precioAmbos;
                    break;
                default:
                    break;
            }
            return retorno;
        }

        /// <summary>
        /// Validad igualdad entre Shopping y Comercio
        /// </summary>
        /// <param name="s"></Shopping>
        /// <param name="c"></Comercio>
        /// <returns></returns>
        public static bool operator ==(Shopping s, Comercio c)
        {
            bool retorno = false;
            foreach (Comercio come in s._comercios)
            {
                if (come is Exportador && c is Exportador)
                {
                    if (((Exportador)come) == ((Exportador)c))
                    {
                        retorno = true;
                        break;
                    }
                    else if (come is Importador && c is Importador)
                    {
                        if (((Importador)come) == ((Importador)c))
                        {
                            retorno = true;
                            break;
                        }
                    }
                }
            }
            return retorno;
        }

        /// <summary>
        /// Valida desigualdad entre Shopping y Comercio
        /// </summary>
        /// <param name="s"></Shopping>
        /// <param name="c"></Comercio>
        /// <returns></returns>
        public static bool operator !=(Shopping s, Comercio c)
        {
            return !(s == c);
        }

        public static Shopping operator +(Shopping s, Comercio c)
        {
            if (s == c)
            { Console.WriteLine("El comercio ya se encuentra en el Shopping!"); }

            else
            {
                if (s._comercios.Count < s._capacidad)
                {
                    s._comercios.Add(c);
                }
                else
                {
                    Console.WriteLine("No hay mas lugar en el Shopping!");
                }
            }
            return s;
        }
        #endregion
    }
}
