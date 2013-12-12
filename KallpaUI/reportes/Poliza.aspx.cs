﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using KallpaBusiness;
using KallpaEntities.General;
using KallpaEntities.Reportes;

namespace KallpaUI.reportes
{
    public partial class Poliza : Page
    {
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

            var polizas = new Reportes().ReportePolizas(idCliente, cavali, tipoOperacion, moneda, valor, tipoPoliza, rango);

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
            CargarCabeceraDetalle(detallePoliza);
            CargarGrillaDetalle(detallePoliza);
            CargarResumenDetalle(detallePoliza);
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

        private void CargarGrillaDetalle(DetallePoliza detallePoliza)
        {
            ValorLabel.Text = detallePoliza.Valor;
            CantidadLabel.Text = detallePoliza.Cantidad.ToString();
            PrecioLabel.Text = detallePoliza.Precio.ToString();
            ImporteLabel.Text = detallePoliza.Importe.ToString();
            ImporteTotalLabel.Text = detallePoliza.Importe.ToString();
            FechaLiquidacionLabel.Text = detallePoliza.FechaLiquidacion.ToShortDateString();
        }

        private void CargarResumenDetalle(DetallePoliza detallePoliza)
        {
            ComisionSABLabel.Text = detallePoliza.ComisionSAB.ToString();
            ComisionCONASEVLabel.Text = detallePoliza.ComisionCONASEV.ToString();
            CuotaBVLLabel.Text = detallePoliza.ComisionBVL.ToString();
            FondoGarantiaBVLLabel.Text = detallePoliza.ComisionFondoBVL.ToString();
            RedistribucionCAVALILabel.Text = detallePoliza.ComisionCAVALI.ToString();
            FondoGarantiaCAVALILabel.Text = detallePoliza.ComisionFondoCAVALI.ToString();
            IGVLabel.Text = detallePoliza.IGV.ToString();
            TotalLabel.Text = detallePoliza.Total.ToString();
        }

        protected void RegresarLinkButton_Click(object sender, EventArgs e)
        {
            DetallePolizaPanel.Visible = false;
            MainPanel.Visible = true;
        }
    }
}