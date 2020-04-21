using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        static SqlCommand comando;
        static SqlConnection conexion;

        /// <summary>
        /// Ejecuta un comando INSERT de los datos del paquete a una base de datos.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            try
            {
                comando.CommandText = string.Format("INSERT INTO Paquetes(direccionEntrega, trackingID, alumno) values('{0}', '{1}', '{2}')",
                    p.DireccionEntrega, p.TrackingID, "Lorenzo.Cea.2D");
                conexion.Open();
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        static PaqueteDAO()
        {
            string connectionString = "Data Source=.\\SQLEXPRESS; Initial Catalog=correo-sp-2017; Integrated Security=True";
            comando = new SqlCommand();
            conexion = new SqlConnection(connectionString);

            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
        }
    }
}
