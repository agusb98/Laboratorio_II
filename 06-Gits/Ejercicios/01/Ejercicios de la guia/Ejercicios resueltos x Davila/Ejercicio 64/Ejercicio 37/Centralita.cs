﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ejercicio_37
{
    public class Centralita : IGuardar<string>
    {
        #region Atributos
        private List<Llamada> listaDeLlamadas;
        protected string razonSocial;
        private string rutaDeArchivo;
        #endregion

        #region Propiedades
        public float GananciasPorLocal 
        { 
            get 
            { 
                return this.CalcularGanancia(Llamada.TipoLlamada.Local); 
            } 
        }

        public float GananciasPorProvincial 
        { 
            get 
            { 
                return this.CalcularGanancia(Llamada.TipoLlamada.Provincial); 
            } 
        }

        public float GananciasPorTotal 
        { 
            get 
            { 
                return this.CalcularGanancia(Llamada.TipoLlamada.Todas); 
            } 
        }

        public List<Llamada> Llamadas 
        {
            get 
            {
                return this.listaDeLlamadas; 
            }
        }

        public string RutaDeArchivo
        {
            get
            {
                return this.rutaDeArchivo;
            }
            set
            {
                this.rutaDeArchivo = value;
            }
        }
        #endregion

        #region Constructores
        public Centralita() 
        {        
            this.listaDeLlamadas = new List<Llamada>();
            this.RutaDeArchivo = "bitacora.txt";
        }

        public Centralita(string nombreEmpresa)
            : this()
        {
            this.razonSocial = nombreEmpresa;
        }
        #endregion

        #region Sobrecargas
        public static bool operator ==(Centralita c, Llamada llamada)
        {
            bool retorno = false;
            foreach (Llamada l in c.listaDeLlamadas)
            {
                if (l == llamada)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public static bool operator !=(Centralita c, Llamada llamada)
        {
            return !(c == llamada);
        }

        public static Centralita operator +(Centralita c, Llamada nuevaLlamada)
        {
            if (c != nuevaLlamada)
            {
                c.AgregarLlamada(nuevaLlamada);
                if (c.Guardar() == false)
                {
                    throw new FallaLogException("No se pudo guardar.", "Centralita", "Operator +");
                }
            }
            else
            {
                throw new CentralitaException("Ya existe la llamada", c.GetType().Name, "Operator +");
            }
            return c;
        }
        #endregion

        #region Métodos
        private string Mostrar()
        {
            StringBuilder salida = new StringBuilder();
            salida.AppendFormat("\nRazon Social: {0}", this.razonSocial);
            salida.AppendFormat("\nGanancia Total: {0}", this.GananciasPorTotal);
            salida.AppendFormat("\nGanancia Local: {0}", this.GananciasPorLocal);
            salida.AppendFormat("\nGanancia Provincial: {0}", this.GananciasPorProvincial);
            salida.Append("\nLLAMADAS:");
            foreach (Llamada llamada in this.listaDeLlamadas)
            {
                salida.Append("\n---------------------------------------");
                salida.Append(llamada.ToString());
            }

            return salida.ToString();
        }

        public override string ToString()
        {
 	         return this.Mostrar();
        }

        private float CalcularGanancia(Llamada.TipoLlamada tipo)
        {
            float ganancia = 0;
            foreach(Llamada llamada in this.listaDeLlamadas)
            {
                switch (tipo)
                { 
                    case Llamada.TipoLlamada.Local:
                        if(llamada is Local)
                        {
                            ganancia = ganancia + llamada.CostoLlamada;
                        }
                        break;

                    case Llamada.TipoLlamada.Provincial:
                        if (llamada is Provincial)
                        {
                            ganancia = ganancia + llamada.CostoLlamada;
                        }
                        break;

                    case Llamada.TipoLlamada.Todas:
                        if (llamada is Local)
                        {
                            ganancia = ganancia + llamada.CostoLlamada;
                        }
                        else if (llamada is Provincial)
                        {
                            ganancia = ganancia + llamada.CostoLlamada;
                        }

                        break;
                }
            }

            return ganancia;
        }

        public void OrdenarLlamadas()
        {
            this.listaDeLlamadas.Sort(Llamada.OrdenarPorDuracion);
        }

        private void AgregarLlamada(Llamada nuevaLlamada){
            this.listaDeLlamadas.Add(nuevaLlamada);        
        }

        public bool Guardar()
        {
            try
            {
                StreamWriter file = new StreamWriter(this.RutaDeArchivo);
                file.WriteLine(this.Mostrar());
                file.Close();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public string Leer()
        {
            StreamReader file = new StreamReader(this.RutaDeArchivo);
            string retorno = file.ReadToEnd();
            file.Close();
            return retorno;
        }
        #endregion       
    }
}
