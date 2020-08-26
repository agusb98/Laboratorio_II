using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;

namespace Entidades.SP
{
    public static class Extensora
    {
        public static string MostrarBD(this Producto producto)
        {
            SqlCommand comando = new SqlCommand("SELECT * FROM productos");
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.Conexion);
            comando.Connection = conexion;

            conexion.Open();

            SqlDataReader lector = comando.ExecuteReader();
            StringBuilder sb = new StringBuilder();

            while (lector.Read())
            {
                sb.AppendLine(string.Format("Nombre: {0} - Stock: {1}",lector["nombre"].ToString(), lector["stock"].ToString()));
            }

            conexion.Close();
            return sb.ToString();
        }
    }
}
