using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace universidadUH
{
    public partial class CatUser : System.Web.UI.Page
    {
        private string strconnstring;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listadodeusuarios();
            }

        }
        protected void listadodeusuarios()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["UHUNIVERSIDADConnectionString3"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand command = new SqlCommand("SP_ConsultarUsuario", con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void bagregar_Click(object sender, EventArgs e)
        {
            ClsUsuario.Setnombre(tusuario.Text);
            ClsUsuario.SetClave(tclave.Text);
            if (ClsUsuario.AgregarUsuario())
            {
                listadodeusuarios();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notificación: Usuario no ingresado');", true);
            }
        }
        public void Agregar()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["UHUNIVERSIDADConnectionString3"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand command = new SqlCommand("sp_AgregarUsuario", con);
            command.Parameters.Add(new SqlParameter("@nombre", tusuario.Text));
            command.Parameters.Add(new SqlParameter("@clave", tclave.Text));
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            listadodeusuarios();
        }
        protected void consultarfiltro()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["UHUNIVERSIDADConnectionString3"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand command = new SqlCommand("sp_Consultarusuario_filtro", con);
            command.Parameters.Add(new SqlParameter("@nombre", tusuario.Text));
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void Bconsultar_Click(object sender, EventArgs e)
        {
            consultarfiltro();
        }

        protected void bborrar_Click(object sender, EventArgs e)
        {
            ClsUsuario.SetCodigo(Convert.ToInt32(tcodigo.Text));

            if (ClsUsuario.borrarUsuario())
            {
                listadodeusuarios();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notificación: Usuario borrado);", true);

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notificación: Usuario no borrado);", true);
            }
        }

        protected void bmodificar_Click(object sender, EventArgs e)
        {
            ClsUsuario.SetCodigo(Convert.ToInt32(tcodigo.Text));

            if (ClsUsuario.modificar())
            {
                listadodeusuarios();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notificación: Usuario no actualizado');", true);
            }
        }
    }
}