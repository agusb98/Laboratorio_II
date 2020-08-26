using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.IO;

namespace Entidades.SP
{
    //Lapiz-> color:ConsoleColor(publico); trazo:ETipoTrazo(enum {Fino, Grueso, Medio}; publico); PreciosCuidados->true; 
    //Reutilizar UtilesToString en ToString() (mostrar todos los valores).

    public class Lapiz : Utiles, ISerializa, IDeserializa
    {

        public ConsoleColor color;
        public ETipoTrazo trazo;

        public Lapiz()
        {

        }
        public Lapiz(ConsoleColor color, ETipoTrazo trazo, string marca, double precio)
            : base(marca, precio)
        {
            this.color = color;
            this.trazo = trazo;
        }

        public override bool PreciosCuidados
        {
            get { return true; }
        }

        public string Path
        {
            get { return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ baeznuñez.leandro.lapiz.xml"; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0}", base.UtilesToString());
            sb.AppendFormat("COLOR: {0}\n", this.color);
            sb.AppendFormat("TRAZO: {0}\n", this.trazo);
            sb.AppendFormat("PRECIOS CUIDADOS: {0}\n", this.PreciosCuidados);

            return sb.ToString();
        }

        public bool Xml()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Lapiz));
                StreamWriter streamWriter = new StreamWriter(this.Path);
                xmlSerializer.Serialize(streamWriter, this);
                streamWriter.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        bool IDeserializa.Xml(out Lapiz lapiz)
        {
            Lapiz aux;

            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Lapiz));
                StreamReader streamReader = new StreamReader(this.Path);
                aux = (Lapiz)xmlSerializer.Deserialize(streamReader);
                lapiz = aux;
                streamReader.Close();
                return true;
            }
            catch (Exception)
            {
                lapiz = default(Lapiz);
                return false;
            }
        }


    }
        public enum ETipoTrazo
        {
            Fino,
            Grueso,
            Medio
        }
}
