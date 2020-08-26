using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace Entidades.SP
{
    public static class Extensora
    {
        public static bool EliminarFruta(this Cajon<Manzana> cajon, int id)
        {
            SqlConnection conexion;
            SqlCommand comando;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Conexion);
                comando = new SqlCommand("DELETE FROM frutas WHERE id = " + id);
                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
