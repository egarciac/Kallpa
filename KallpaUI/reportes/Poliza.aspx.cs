using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using KallpaBusiness;
using KallpaEntities.General;
using KallpaEntities.Reportes;
using System.Globalization;

namespace KallpaUI.reportes
{
    public partial class Poliza : Page
    {
        private decimal importeTotal = 0m;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    var dt = (DataTable)Session["SetValues"];
                    lblNombre.Text = dt.Rows[0][0].ToString();
                    lblDireccion.Text = dt.Rows[0][1].ToString();
                    lblCavali.Text = dt.Rows[0][2].ToString();
                    lblTrader.Text = dt.Rows[0][3].ToString();

                LoadAllControls();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx");
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

            var request = new ReportRequest
                {
                    IdCliente = idCliente,
                    Cavali = cavali,
                    TipoOperacion = tipoOperacion,
                    Moneda = moneda,
                    Valor = valor,
                    TipoPoliza = tipoPoliza,
                    Rango = rango
                };

            var polizas = new Reportes().ReportePolizas(request);

            var enumerable = polizas as IList<KallpaEntities.Reportes.Poliza> ?? polizas.ToList();
            PolizaSolesGridView.DataSource = enumerable.Where(p => p.MonedaBase).ToList();
            PolizaSolesGridView.DataBind();

            PolizaDolaresGridView.DataSource = enumerable.Where(p => !p.MonedaBase).ToList();
            PolizaDolaresGridView.DataBind();

            PolizaPanel.Visible = true;
        }

        protected void PolizaSolesGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var idPoliza = Convert.ToInt32(e.CommandArgument);
            var linkButton = e.CommandSource as LinkButton;
            var sqlReport = false;
            if (linkButton != null)
            {
                var hiddenField = linkButton.Parent.FindControl("sqlHiddenField") as HiddenField;
                if (hiddenField != null)
                {
                    sqlReport = Convert.ToBoolean(hiddenField.Value);
                }
            }
            switch (e.CommandName.ToLower())
            {
                case "detalle": DetallePoliza(idPoliza, sqlReport); break;
            }
        }

        private void DetallePoliza(int idPoliza, bool sqlReport)
        {
            MainPanel.Visible = false;
            DetallePolizaPanel.Visible = true;
            CargarDetalle(idPoliza, sqlReport);
        }

        private void CargarDetalle(int idPoliza, bool sqlReport)
        {
            var detallePoliza = new Reportes().ReporteDetallePoliza(idPoliza, sqlReport);
            var detallePolizas = detallePoliza as IList<DetallePoliza> ?? detallePoliza.ToList();
            CargarCabeceraDetalle(detallePolizas.FirstOrDefault());
            CargarGrillaDetalle(detallePolizas);
            CargarResumenDetalle(detallePolizas);
        }

        private void CargarCabeceraDetalle(DetallePoliza detallePoliza)
        {
            NumeroPolizaLabel.Text = detallePoliza.NumeroPoliza;
            FechaLabel.Text = detallePoliza.Fecha.ToShortDateString();
            NombreLabel.Text = string.Format("{0} {1}", detallePoliza.Cavali, detallePoliza.Nombre);
            DireccionLabel.Text = detallePoliza.Direccion;
            DNILabel.Text = detallePoliza.DocumentoIdentidad;
            CavaliLabel.Text = detallePoliza.Cavali;
        }

        private void CargarGrillaDetalle(IEnumerable<DetallePoliza> detallePoliza)
        {
            DetallePolizaGridView.DataSource = detallePoliza;
            DetallePolizaGridView.DataBind();
            var firstOrDefault = detallePoliza.FirstOrDefault();
            if (firstOrDefault != null)
                FechaLiquidacionLabel.Text = firstOrDefault.FechaLiquidacion.ToShortDateString();
        }

        private void CargarResumenDetalle(IEnumerable<DetallePoliza> detallePoliza)
        {
            var detallePolizas = detallePoliza as IList<DetallePoliza> ?? detallePoliza.ToList();
            ComisionSABLabel.Text = detallePolizas.Sum(d=>d.ComisionSAB).ToString("0,0.00", CultureInfo.InvariantCulture);
            ComisionCONASEVLabel.Text = detallePolizas.Sum(d=>d.ComisionCONASEV).ToString("0,0.00", CultureInfo.InvariantCulture);
            CuotaBVLLabel.Text = detallePolizas.Sum(d => d.ComisionBVL).ToString("0,0.00", CultureInfo.InvariantCulture);
            FondoGarantiaBVLLabel.Text = detallePolizas.Sum(d => d.ComisionFondoBVL).ToString("0,0.00", CultureInfo.InvariantCulture);
            RedistribucionCAVALILabel.Text = detallePolizas.Sum(d => d.ComisionCAVALI).ToString("0,0.00", CultureInfo.InvariantCulture);
            FondoGarantiaCAVALILabel.Text = detallePolizas.Sum(d => d.ComisionFondoCAVALI).ToString("0,0.00", CultureInfo.InvariantCulture);
            IGVLabel.Text = detallePolizas.Sum(d => d.IGV).ToString("0,0.00", CultureInfo.InvariantCulture);
            TotalLabel.Text = detallePolizas.Sum(d => d.Total).ToString("0,0.00", CultureInfo.InvariantCulture);
        }

        protected void RegresarLinkButton_Click(object sender, EventArgs e)
        {
            DetallePolizaPanel.Visible = false;
            MainPanel.Visible = true;
        }

        protected void DetallePolizaGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                importeTotal += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Importe"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[2].Text = "Total";
                e.Row.Cells[3].Text = importeTotal.ToString();
            }
        }
    }
}