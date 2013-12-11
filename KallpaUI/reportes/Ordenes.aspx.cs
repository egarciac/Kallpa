<<<<<<< .mine
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using KallpaBusiness;
using KallpaEntities.General;

namespace KallpaUI.reportes
{
    public partial class Ordenes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
<<<<<<< .mine
            try
=======
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
                LoadTipoOperacion();

                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx");
            }
        }

        private void LoadTipoOperacion()
        {
            TipoOperacionDropDownList.DataValueField = "IdTipoOperacion";
            TipoOperacionDropDownList.DataTextField = "Descripcion";
            TipoOperacionDropDownList.DataSource = new Maestros().ConseguirTipoOperacion();
            TipoOperacionDropDownList.DataBind();
        }

        protected void VisualizarImageButton_Click(object sender, ImageClickEventArgs e)
        {
            DataTable dt = (DataTable)Session["SetValues"];
            int CodCavali = Convert.ToInt32(dt.Rows[0][2].ToString());
            var idCliente = Convert.ToInt32(Session["UserPKID"]);
            var tipoOperacion = Convert.ToInt32(TipoOperacionDropDownList.SelectedValue);
            var rango = new RangoFecha(DateTime.Parse(DesdeInput.Value), DateTime.Parse(HastaInput.Value));
            DataSet ds = null;
            ds=KallpaBusiness.Ordenes.getOrdenes(CodCavali, tipoOperacion, rango);
            gvOrdenes.DataSource = ds.Tables[0];
            gvOrdenes.DataBind();

        }
    }
}=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using KallpaBusiness;
using KallpaEntities.General;

namespace KallpaUI.reportes
{
    public partial class Ordenes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
>>>>>>> .r7
            {
                if (!IsPostBack)
                {
                DataTable dt = (DataTable)Session["SetValues"];
                lblNombre.Text = dt.Rows[0][0].ToString();
                lblDireccion.Text = dt.Rows[0][1].ToString();
                lblCavali.Text = dt.Rows[0][2].ToString();
                lblTrader.Text = dt.Rows[0][3].ToString();
                Session["SetValues"] = dt;
                LoadTipoOperacion();

                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx");
            }
        }

        private void LoadTipoOperacion()
        {
            TipoOperacionDropDownList.DataValueField = "IdTipoOperacion";
            TipoOperacionDropDownList.DataTextField = "Descripcion";
            TipoOperacionDropDownList.DataSource = new Maestros().ConseguirTipoOperacion();
            TipoOperacionDropDownList.DataBind();
        }

        protected void VisualizarImageButton_Click(object sender, ImageClickEventArgs e)
        {
            DataTable dt = (DataTable)Session["SetValues"];
            int CodCavali = Convert.ToInt32(dt.Rows[0][2].ToString());
            var idCliente = Convert.ToInt32(Session["UserPKID"]);
            var tipoOperacion = Convert.ToInt32(TipoOperacionDropDownList.SelectedValue);
            var rango = new RangoFecha(DateTime.Parse(DesdeInput.Value), DateTime.Parse(HastaInput.Value));
            DataSet ds = null;
            ds=KallpaBusiness.Ordenes.getOrdenes(CodCavali, tipoOperacion, rango);
            gvOrdenes.DataSource = ds.Tables[0];
            gvOrdenes.DataBind();

        }
    }
}>>>>>>> .r6
