using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace EncuestaUH.Clases
{

        public class REPORTES_CSS
        {
            public int EncuestaID { get; set; }
            public string Nombre { get; set; }
            public int Edad { get; set; }
            public string CorreoElectronico { get; set; }
            public string Partido { get; set; }


            public REPORTES_CSS(string nombre, int edad, string correoElectronico, string partido)
            {

                Nombre = nombre;
                Edad = edad;
                CorreoElectronico = correoElectronico;
                Partido = partido;
            }
            public REPORTES_CSS() { }

            public static int Borrar(int EncuestaID)
            {
                int retorno = 0;

                SqlConnection Conn = new SqlConnection();
                try
                {
                    using (Conn = DBconn.obtenerConexion())
                    {
                        SqlCommand cmd = new SqlCommand("BORRARENCUESTA", Conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        cmd.Parameters.Add(new SqlParameter("@EncuestaID", EncuestaID));



                        retorno = cmd.ExecuteNonQuery();
                    }
                }
                catch (System.Data.SqlClient.SqlException)
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