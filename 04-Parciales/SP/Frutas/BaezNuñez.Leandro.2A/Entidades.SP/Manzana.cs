using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.IO;

namespace Entidades.SP
{
    public class Manzana : Fruta, ISerializar, IDeserializar
    {
        protected string _provinciaOrigen;

        public string ProvinciaOrigen
        {
            get { return this._provinciaOrigen; }
            set { this._provinciaOrigen = value; }
        }

        public string Nombre { get { return "Manzana"; } }

        public Manzana() { }

        public Manzana(string color, double peso, string provincia) : base(color, peso)
        {
            this.ProvinciaOrigen = provincia;
        }

        public override bool TieneCarozo
        {
            get { return true; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("FRUTA: {0}\n", this.Nombre);
            sb.AppendFormat("{0}", base.FrutaToString());
            sb.AppendFormat("TIENE CAROZO: {0}\n", this.TieneCarozo);
            sb.AppendFormat("PROVINCIA ORIGEN: {0}\n", this.ProvinciaOrigen);

            return sb.ToString();
        }

        public bool Xml(string archivo)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Manzana));
                StreamWriter streamWriter = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo);
                xmlSerializer.Serialize(streamWriter, this);
                streamWriter.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        bool IDeserializar.Xml(string archivo, out Fruta fruta)
        {
            XmlSerializer xmlSerializer;
            StreamReader streamReader = null;

            try
            {
                xmlSerializer = new XmlSerializer(typeof(Manzana));
                streamReader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo);
                fruta = (Manzana)xmlSerializer.Deserialize(streamReader);
                streamReader.Close();
                return true;
            }
            catch (Exception)
            {
                fruta = default(Manzana);
                return false;
            }
        }
    }
}
