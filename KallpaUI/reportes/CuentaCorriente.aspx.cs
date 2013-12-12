using System;
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
    public partial class CuentaCorriente : Page
    {
        protected void Page_Load(object sender, EventArgs e)
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

        private void LoadAllControls()
        {
            LoadMoneda();
        }        

        private void LoadMoneda()
        {
            MonedaDropDownList.DataValueField = "IdMoneda";
            MonedaDropDownList.DataTextField = "Descripcion";
            MonedaDropDownList.DataSource = new Maestros().ConseguirMoneda();
            MonedaDropDownList.DataBind();
        }

        protected void VisualizarImageButton_Click(object sender, ImageClickEventArgs e)
        {
            var idCliente = Convert.ToInt32(Session["UserPKID"]);
            var cavali = Convert.ToInt32(lblCavali.Text);

            var moneda = Convert.ToInt32(MonedaDropDownList.SelectedValue);
            var rango = new RangoFecha(DateTime.Parse(DesdeInput.Value), DateTime.Parse(HastaInput.Value));

            var cuentasCorrientes = new Reportes().ReporteCuentaCorriente(idCliente, cavali, rango, moneda);
            var datosGrillas =
                cuentasCorrientes.Where(
                    c => c.TipoInformacion.Equals("Operaciones", StringComparison.InvariantCultureIgnoreCase));

            var cuentaCorrientes = datosGrillas as IList<KallpaEntities.Reportes.CuentaCorriente> ?? datosGrillas.ToList();
            CuentaCorrienteVSolesGridView.DataSource =
                cuentaCorrientes.Where(
                    d =>
                    d.IdMoneda == 1 &&
                    d.TipoOperacion.Equals("Operaciones Vencidas", StringComparison.InvariantCultureIgnoreCase))
                                .ToList();
            CuentaCorrientePVSolesGridView.DataSource =
                cuentaCorrientes.Where(
                    d =>
                    d.IdMoneda == 1 &&
                    d.TipoOperacion.Equals("Operaciones por Vencer", StringComparison.InvariantCultureIgnoreCase))
                                .ToList();
            CuentaCorrienteVDolaresGridView.DataSource = cuentaCorrientes.Where(
                    d =>
                    d.IdMoneda == 2 &&
                    d.TipoOperacion.Equals("Operaciones Vencidas", StringComparison.InvariantCultureIgnoreCase))
                                .ToList();
            CuentaCorrientePVDolaresGridView.DataSource = cuentaCorrientes.Where(
                    d =>
                    d.IdMoneda == 2 &&
                    d.TipoOperacion.Equals("Operaciones por Vencer", StringComparison.InvariantCultureIgnoreCase))
                                .ToList();

            CuentaCorrienteVSolesGridView.DataBind();
            CuentaCorrientePVSolesGridView.DataBind();
            CuentaCorrienteVDolaresGridView.DataBind();
            CuentaCorrientePVDolaresGridView.DataBind();

            CuentaCorrientePanel.Visible = true;
        }
    }
}