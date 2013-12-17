using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KallpaBusiness;
using KallpaEntities.General;
using KallpaEntities.Reportes;
using KallpaUI.reportes.ViewModel;
using System.Data;

namespace KallpaUI.reportes
{
    public partial class DetalleOperaciones : System.Web.UI.Page
    {
        private IEnumerable<DetalleOperacion> _mainData;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = (DataTable)Session["SetValues"];
                lblNombre.Text = dt.Rows[0][0].ToString();
                lblDireccion.Text = dt.Rows[0][1].ToString();
                lblCavali.Text = dt.Rows[0][2].ToString();
                //dt.Rows[0][2] = "283780";
                lblTrader.Text = dt.Rows[0][3].ToString();
                Session["SetValues"] = dt;
            }
        }

        protected void VisualizarImageButton_Click(object sender, ImageClickEventArgs e)
        {
            //var idCliente = 247615;
            var idCliente = Convert.ToInt32(Session["UserPKID"]);
            //dt.Rows[0][2].ToString();

            var rango = new RangoFecha(DateTime.Parse(DesdeInput.Value), DateTime.Parse(HastaInput.Value));
            var request = new ReportRequest
                {
                    IdCliente = idCliente,
                    Rango = rango
                };
            _mainData = new Reportes().ReportDetalleOperaciones(request);
            ResultPanel.Visible = true;
            LoadMoneyData(_mainData);
        }

        private void LoadMoneyData(IEnumerable<DetalleOperacion> data)
        {
            var moneyData = data
                .GroupBy(g => new
                    {
                        g.EsMoneda, g.Moneda
                    }, (k, gr) => new MoneyHeaderViewModel
                    {
                        EsMoneda = k.EsMoneda,
                        Moneda = k.Moneda
                    }).OrderByDescending(o => o.EsMoneda);
            MoneyRepeater.DataSource = moneyData;
            MoneyRepeater.DataBind();
        }

        protected void MoneyRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) return;
            var innerRepeater = (Repeater)e.Item.FindControl("ValueNestedRepeater");
            var moneyHeader = e.Item.DataItem as MoneyHeaderViewModel;
            if (moneyHeader == null) return;
            var money = moneyHeader.EsMoneda;
            var valueSubtotalData = _mainData
                .Where(d => d.EsMoneda == money)
                .GroupBy(d => d.Valor)
                .Select(g => new ValueSubtotalViewModel
                    {
                        Header = "Total",
                        EsMoneda = g.First().EsMoneda,
                        Valor = g.Key,
                        MontoCompra = g.Sum(c => c.TotalCompra.GetValueOrDefault(0m)),
                        MontoVenta = g.Sum(v => v.TotalVenta.GetValueOrDefault(0m))
                    }).OrderBy(o => o.Valor);
            innerRepeater.DataSource = valueSubtotalData;
            innerRepeater.DataBind();
        }

        protected void ValueNestedRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) return;
            var innerRepeater = (Repeater)e.Item.FindControl("DataNestedRepeater");
            var valueSubtotal = e.Item.DataItem as ValueSubtotalViewModel;
            if (valueSubtotal == null) return;
            var money = valueSubtotal.EsMoneda;
            var valor = valueSubtotal.Valor;
            var detailData = _mainData
                .Where(d => d.EsMoneda == money && d.Valor.Equals(valor, StringComparison.InvariantCultureIgnoreCase));
            innerRepeater.DataSource = detailData;
            innerRepeater.DataBind();
        }
    }
}