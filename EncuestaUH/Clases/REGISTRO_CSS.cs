using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace EncuestaUH.Clases
{
    public class REGISTRO_CSS
    {
        public int EncuestaID { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string CorreoElectronico { get; set; }
        public string Partido { get; set; }   


        public REGISTRO_CSS(string nombre, int edad, string correoElectronico, string partido)
        {

            Nombre = nombre;
            Edad = edad;
            CorreoElectronico = correoElectronico;
            Partido = partido;
        }
        public REGISTRO_CSS() { }
        public static int Agregar(string Nombre, int Edad, string CorreoElectronico, string Partido)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AGREGARENCUESTA", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Nombre", Nombre));
                    cmd.Parameters.Add(new SqlParameter("@Edad", Edad));
                    cmd.Parameters.Add(new SqlParameter("@CorreoElectronico", CorreoElectronico));
                    cmd.Parameters.Add(new SqlParameter("@Partido", Partido));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException )
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }



    }
}