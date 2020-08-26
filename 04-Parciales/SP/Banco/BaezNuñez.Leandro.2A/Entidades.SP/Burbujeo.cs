using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Entidades.SP
{
    public class Burbujeo
    {
        public static void MetodoClase()
        {
            try
            {
                new Burbujeo().MetodoInstancia();
            }

            catch (Exception ex)
            {
                ex.Data.Add("MetodoClase-" + DateTime.Now.ToString("HH:mm:ss"), 1);
                throw ex;
            }
        }

        public void MetodoInstancia()
        {
            StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\burbujeo.txt");
            
            sw.WriteLine("Funcion de INSTANCIA TirarExcepcion:");
            sw.WriteLine(DateTime.Now.ToString());
            sw.Close();

            throw new MiException("Aquí MiException de burbujeo");
        }
    }
}
