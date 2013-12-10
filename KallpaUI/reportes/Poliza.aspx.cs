using System;
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
    public partial class Poliza : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = (DataTable)Session["SetValues"];

                lblNombre.Text = dt.Rows[0][0].ToString();
                lblDireccion.Text = dt.Rows[0][1].ToString();
                lblCavali.Text = dt.Rows[0][2].ToString();
                lblTrader.Text = dt.Rows[0][3].ToString();

                LoadAllControls();
            }
        }

        private void LoadAllControls()
        {
            LoadMoneda();
            LoadTipoOperacion();
            LoadValor();
            LoadTipoPoliza();
        }        

        private void LoadMoneda()
        {
            MonedaDropDownList.DataValueField = "IdMoneda";
            MonedaDropDownList.DataTextField = "Descripcion";
            MonedaDropDownList.DataSource = new Maestros().ConseguirMoneda();
            MonedaDropDownList.DataBind();
        }

        private void LoadTipoOperacion()
        {
            TipoOperacionDropDownList.DataValueField = "IdTipoOperacion";
            TipoOperacionDropDownList.DataTextField = "Descripcion";
            TipoOperacionDropDownList.DataSource = new Maestros().ConseguirTipoOperacion();
            TipoOperacionDropDownList.DataBind();
        }

        private void LoadValor()
        {
            ValorDropDownList.DataValueField = "IdValor";
            ValorDropDownList.DataTextField = "Descripcion";
            ValorDropDownList.DataSource = new Maestros().ConseguirValor();
            ValorDropDownList.DataBind();
        }

        private void LoadTipoPoliza()
        {
            TipoPolizaDropDownList.DataValueField = "IdTipoPoliza";
            TipoPolizaDropDownList.DataTextField = "Detalle";
            TipoPolizaDropDownList.DataSource = new Maestros().ConseguirTipoPoliza();
            TipoPolizaDropDownList.DataBind();
        }

        protected void VisualizarImageButton_Click(object sender, ImageClickEventArgs e)
        {            
            var idCliente = Convert.ToInt32(Session["UserPKID"]);
            var cavali = Convert.ToInt32(lblCavali.Text);

            var tipoOperacion = Convert.ToInt32(TipoOperacionDropDownList.SelectedValue);
            var moneda = Convert.ToInt32(MonedaDropDownList.SelectedValue);
            var valor = Convert.ToInt32(ValorDropDownList.SelectedValue);
            var tipoPoliza = Convert.ToInt32(TipoPolizaDropDownList.SelectedValue);
            var rango = new RangoFecha(DateTime.Parse(DesdeInput.Value), DateTime.Parse(HastaInput.Value));

            var polizas = new Reportes().ReportePolizas(idCliente, cavali, tipoOperacion, moneda, valor, tipoPoliza, rango);

            PolizaSolesGridView.DataSource = polizas.Where(p => p.MonedaBase).ToList();
            PolizaSolesGridView.DataBind();

            PolizaDolaresGridView.DataSource = polizas.Where(p => !p.MonedaBase).ToList();
            PolizaDolaresGridView.DataBind();

            PolizaPanel.Visible = true;
        }

        protected void PolizaSolesGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Detalle": DetallePoliza(Convert.ToInt32(e.CommandArgument)); break;
            }
        }

        private void DetallePoliza(int idPoliza)
        {
            MainPanel.Visible = false;
            DetallePolizaPanel.Visible = true;
        }

        protected void RegresarLinkButton_Click(object sender, EventArgs e)
        {
            DetallePolizaPanel.Visible = false;
            MainPanel.Visible = true;
        }
    }
}