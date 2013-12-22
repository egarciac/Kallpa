using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using KallpaBusiness;
using System.Globalization;

namespace KallpaUI
{
    public partial class Portafolio : System.Web.UI.Page
    {
        int Valorizacion1, Valorizacion2, ECTOT1, ECTOT2 = 0;

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
            catch(Exception ex)
                {
                Response.Redirect("Error.aspx");
                }
        }

        protected void visualizar_Click(object sender, ImageClickEventArgs e)
        {
            DataTable dt = (DataTable)Session["SetValues"];
            CR.Visible = true;
            var idCliente = Convert.ToInt32(Session["UserPKID"]);
            int idCavali = Int32.Parse(dt.Rows[0][2].ToString());
            var fecha = DesdeInput.Value;
            decimal TipoCambio = Usuario.ObtenerTipoCambio(fecha);


            DataSet dsDolares = KallpaBusiness.Portafolio.getPortafolio(fecha, idCliente, "US $");
            gvDolares.DataSource = dsDolares.Tables[0];
            gvDolares.DataBind();

            DataSet dsSoles = KallpaBusiness.Portafolio.getPortafolio(fecha, idCliente, "S/.");
            gvSoles.DataSource = dsSoles.Tables[0];
            gvSoles.DataBind();

            lblTotal.Text = (Valorizacion1 + Valorizacion2*TipoCambio).ToString("0,0.00", CultureInfo.InvariantCulture);

            lblTipoCambio.Text = "Tipo de Cambio: " + TipoCambio.ToString();


            DataSet dsReportado = KallpaBusiness.Portafolio.getRpteTptdoSQL(fecha, idCliente, "REPORTADO");
            gvReportado.DataSource = dsReportado.Tables[0];
            gvReportado.DataBind();

            DataSet dsReportante = KallpaBusiness.Portafolio.getRpteTptdoSQL(fecha, idCliente, "REPORTANTE");
            gvReportante.DataSource = dsReportante.Tables[0];
            gvReportante.DataBind();

            DataSet dsMargen = KallpaBusiness.Portafolio.getMargen(fecha, idCliente);
            gvMargen.DataSource = dsMargen.Tables[0];
            gvMargen.DataBind();
            
        }

        protected void gvDolares_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Cantidad += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Cantidad"));
                //Invertido += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Invertido"));
                Valorizacion1 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Valorizacion"));
                //Rentabilidad += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Rentabilidad"));
                //RentPerc += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "RentPerc"));
                ECTOT1 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ECTOT"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //e.Row.Cells[0].Text = "Total:";
                //e.Row.Cells[1].Text = Cantidad.ToString() + " Acciones";
                //e.Row.Cells[5].Text = "SubTotal";
                e.Row.Cells[6].Text = "US$";
                //e.Row.Cells[7].Text = Invertido.ToString();
                e.Row.Cells[7].Text = Valorizacion1.ToString("0,0.00", CultureInfo.InvariantCulture);
                //e.Row.Cells[9].Text = Rentabilidad.ToString();
                //e.Row.Cells[10].Text = RentPerc.ToString();
                e.Row.Cells[8].Text = ECTOT1.ToString() + " %";
            }
        }

        protected void gvSoles_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Cantidad += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Cantidad"));
                //Invertido += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Invertido"));
                Valorizacion2 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Valorizacion"));
                //Rentabilidad += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Rentabilidad"));
                //RentPerc += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "RentPerc"));
                ECTOT2 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ECTOT"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //e.Row.Cells[0].Text = "Total:";
                //e.Row.Cells[1].Text = Cantidad.ToString() + " Acciones";
                //e.Row.Cells[5].Text = "SubTotal";
                e.Row.Cells[6].Text = "S/.";
                //e.Row.Cells[7].Text = Invertido.ToString();
                e.Row.Cells[7].Text = Valorizacion2.ToString("0,0.00", CultureInfo.InvariantCulture);
                //e.Row.Cells[9].Text = Rentabilidad.ToString();
                //e.Row.Cells[10].Text = RentPerc.ToString();
                e.Row.Cells[8].Text = ECTOT2.ToString() + " %";
            }
        }

    }
}