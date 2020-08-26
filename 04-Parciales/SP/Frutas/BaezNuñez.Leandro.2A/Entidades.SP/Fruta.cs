using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.Xml;

namespace Entidades.SP
{
    [XmlInclude(typeof(Manzana))]
    public abstract class Fruta
    {
        protected string _color;
        protected double _peso;

        public abstract bool TieneCarozo { get; }
        public string Color
        {
            get { return this._color; }
            set { this._color = value; }
        }
        public double Peso
        {
            get { return this._peso; }
            set { this._peso = value; }
        }

        public Fruta() { }
        public Fruta(string color, double peso)
        {
            this.Color = color;
            this.Peso = peso;
        }

        public virtual string FrutaToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("COLOR: {0}\n", this.Color);
            sb.AppendFormat("PESO: {0}\n", this.Peso);

            return sb.ToString();
        }
    }
}
