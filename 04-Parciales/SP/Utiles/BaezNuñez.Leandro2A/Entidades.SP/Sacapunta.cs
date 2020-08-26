using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{

    //Sacapunta-> deMetal:bool(publico); 
    //Reutilizar UtilesToString en ToString() (mostrar todos los valores).

    public class Sacapunta : Utiles
    {

        public bool deMetal;

        public Sacapunta(bool deMetal, double precio, string marca)
            : base(marca, precio)
        {
            this.deMetal = deMetal;
        }

        public override bool PreciosCuidados
        {
            get { return false; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0}", base.UtilesToString());
            sb.AppendFormat("METALICO: {0}\n", this.deMetal);
            sb.AppendFormat("PRECIOS CUIDADOS: {0}\n", this.PreciosCuidados);

            return sb.ToString();
        }
    }
}
