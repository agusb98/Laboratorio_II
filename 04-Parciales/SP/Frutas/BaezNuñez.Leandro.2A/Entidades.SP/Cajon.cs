using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.IO;

namespace Entidades.SP
{
    public delegate void PrecioExcedido(double precio);
    public class Cajon<T>
    {
        protected int _capacidad;
        protected List<T> _elementos;
        protected double _precioUnitario;

        public event PrecioExcedido eventoPrecio;

        public List<T> Elementos { get { return this._elementos; } }

        public double PrecioTotal
        {
            get
            {
                return this._precioUnitario * this.Elementos.Count;
            }
        }

        Cajon() { this._elementos = new List<T>(this._capacidad); }

        public Cajon(double precio, int capacidad) : this()
        {
            this._capacidad = capacidad;
            this._precioUnitario = precio;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CAPACIDAD: {0}\n", this._capacidad);
            sb.AppendFormat("CANTIDAD TOTAL: {0}\n", this.Elementos.Count);
            sb.AppendFormat("PRECIO TOTAL: {0}\n", this.PrecioTotal);

            foreach (T fruta in this.Elementos)
            {
                sb.AppendFormat("\n{0}", fruta.ToString());
            }

            return sb.ToString();
        }

        public static Cajon<T> operator +(Cajon<T> cajon, T fruta)
        {
            if (cajon.Elementos.Count == cajon._capacidad)
            {
                throw new CajonLlenoException("Capacidad excedida!!!");
            }
            else
            {
                cajon.Elementos.Add(fruta);

                if (cajon.PrecioTotal > 55)
                {
                    cajon.eventoPrecio(cajon.PrecioTotal);
                }
            }

            return cajon;
        }

        public bool Xml(string path)
        {
            XmlSerializer xmlSerializer;
            StreamWriter streamWriter = null;

            try
            {
                xmlSerializer = new XmlSerializer(typeof(Cajon<T>));
                streamWriter = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + path);
                xmlSerializer.Serialize(streamWriter, this);
                streamWriter.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
