using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace KallpaUI.reportes
{
    public partial class detalle_operaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try 
            {
                if (!IsPostBack)
                {
                    DataTable dt = (DataTable)Session["SetValues"];
                    lblNombre.Text = dt.Rows[0][0].ToString();
                    lblDireccion.Text = dt.Rows[0][1].ToString();
                    lblCavali.Text = dt.Rows[0][2].ToString();
                    lblTrader.Text = dt.Rows[0][3].ToString();
                    Session["SetValues"] = dt;
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx");
            }
        }
    }
}