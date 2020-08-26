using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.Xml;

namespace Entidades.SP
{
    public class DepositoHeredado : Deposito, IDeserializar
    {
        public DepositoHeredado() : base() { }

        public bool Xml(string path)
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8);
                XmlSerializer seri = new XmlSerializer(typeof(DepositoHeredado));
                seri.Serialize(writer, this);
                writer.Close();
                return true;
            }
            catch (XmlException e)
            {
                return false;
            }
        }

        bool IDeserializar.Xml(string path, out DepositoHeredado deposito)
        {
            try
            {
                XmlTextReader reader = new XmlTextReader(path);
                XmlSerializer seri = new XmlSerializer(typeof(DepositoHeredado));
                deposito = (DepositoHeredado)seri.Deserialize(reader);
                reader.Close();
                return true;
            }
            catch (XmlException)
            {
                deposito = null;
                return false;
            }
        }
    }
}
