using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EncuestaUH
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
                LlenarDropdownListEquipos();
            }
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Encuesta "))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            Registrodatagrid.DataSource = dt;
                            Registrodatagrid.DataBind();  // actualizar el grid view
                        }
                    }
                }
            }
        }

        protected void LlenarDropdownListEquipos()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Select TipoPartido from TiposPartidos"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            DropDownListPartido.DataSource = dt;

                            DropDownListPartido.DataTextField = dt.Columns["TipoPartido"].ToString();
                            DropDownListPartido.DataValueField = dt.Columns["TipoPartido"].ToString();
                            DropDownListPartido.DataBind();
                        }
                    }
                }
            }
        }

        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }



        protected void Agregar_Click(object sender, EventArgs e)
        {
            if (int.Parse(Edad.Text) >= 18 && int.Parse(Edad.Text) < 50)
            {
                if (Clases.REGISTRO_CSS.Agregar(Nombre.Text, int.Parse(Edad.Text), CorreoElectronico.Text, DropDownListPartido.SelectedValue) > 0)
                {
                    LlenarGrid();
                    alertas("Encuesta agregada con exito.");
                    Nombre.Text = ""; Edad.Text = ""; CorreoElectronico.Text = "";


                }
                else
                {
                    alertas("Error al agregar encuesta.");
                }
            }
            else
            {
                alertas("Para aplicar a la edad debe ser mayora de 18 años y menor a 50 años.");
            }

        }
    }
}