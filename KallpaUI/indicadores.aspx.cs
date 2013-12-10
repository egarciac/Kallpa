using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Xml;
using System.Net;

namespace KallpaUI
{
    public partial class indicadores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //Imagen y Título del Gráfico por Defecto
                    String Image1 = ConfigurationManager.AppSettings["ImagenUrl1"].ToString();
                    imagen.ImageUrl = Image1;
                    imagen.OnClientClick = "javascript:window.open('" + Image1 + "')";
                    lblIndiceTittle.Text = linkIndice1.Text;

                    //Datos de Indices
                    String URLString1 = ConfigurationManager.AppSettings["Indice1"].ToString();
                    String URLString2 = ConfigurationManager.AppSettings["Indice2"].ToString();
                    String URLString3 = ConfigurationManager.AppSettings["Indice3"].ToString();
                    String URLString4 = ConfigurationManager.AppSettings["Indice4"].ToString();
                    String URLString5 = ConfigurationManager.AppSettings["Indice5"].ToString();
                    String URLString6 = ConfigurationManager.AppSettings["Indice6"].ToString();
                    String URLString7 = ConfigurationManager.AppSettings["Indice7"].ToString();

                    //Obteniendo Info de Indices
                    string[] valores1 = getIndicesValues(URLString1);
                    lblValue1.Text = valores1[0];
                    lblChange1.Text = valores1[1];

                    string[] valores2 = getIndicesValues(URLString2);
                    lblValue2.Text = valores2[0];
                    lblChange2.Text = valores2[1];

                    string[] valores3 = getIndicesValues(URLString3);
                    lblValue3.Text = valores3[0];
                    lblChange3.Text = valores3[1];

                    string[] valores4 = getIndicesValues(URLString4);
                    lblValue4.Text = valores4[0];
                    lblChange4.Text = valores4[1];

                    string[] valores5 = getIndicesValues(URLString5);
                    lblValue5.Text = valores5[0];
                    lblChange5.Text = valores5[1];

                    string[] valores6 = getIndicesValues(URLString6);
                    lblValue6.Text = valores6[0];
                    lblChange6.Text = valores6[1];

                    string[] valores7 = getIndicesValues(URLString7);
                    lblValue7.Text = valores7[0];
                    lblChange7.Text = valores7[1];
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
                Response.Redirect("http://www.googleerror.com", true);
            }
        }

        private string[] getIndicesValues(string url)
        {
            XmlDocument archivoxml = new XmlDocument();
            archivoxml.Load(url);
            XmlNodeList LastPrice = archivoxml.GetElementsByTagName("LastTradePriceOnly");
            XmlNodeList Percent = archivoxml.GetElementsByTagName("PercentChange");
            string[] resultado = { LastPrice[0].InnerText, Percent[0].InnerText };
            return resultado;
        }

        protected void linkIndice1_Click1(Object sender, EventArgs e)
        {

            imagen.ImageUrl = ConfigurationManager.AppSettings["ImagenUrl1"].ToString();
            lblIndiceTittle.Text = "S&P 500";
            imagen.OnClientClick = "javascript:window.open" + imagen.ImageUrl + "')";
        }

        protected void linkIndice2_Click1(Object sender, EventArgs e)
        {
            imagen.ImageUrl = ConfigurationManager.AppSettings["ImagenUrl2"].ToString();
            lblIndiceTittle.Text = "TSX (CANADÁ)";
            imagen.OnClientClick = "javascript:window.open('" + imagen.ImageUrl + "')";
        }

        protected void linkIndice3_Click1(Object sender, EventArgs e)
        {
            imagen.ImageUrl = ConfigurationManager.AppSettings["ImagenUrl3"].ToString();
            lblIndiceTittle.Text = "EURO STOXX 50 (EUROPA)";
            imagen.OnClientClick = "javascript:window.open('" + imagen.ImageUrl + "')";
        }

        protected void linkIndice4_Click1(Object sender, EventArgs e)
        {
            imagen.ImageUrl = ConfigurationManager.AppSettings["ImagenUrl4"].ToString();
            lblIndiceTittle.Text = "DAX (ALEMANIA)";
            imagen.OnClientClick = "javascript:window.open('" + imagen.ImageUrl + "')";
        }

        protected void linkIndice5_Click1(Object sender, EventArgs e)
        {
            imagen.ImageUrl = ConfigurationManager.AppSettings["ImagenUrl5"].ToString();
            lblIndiceTittle.Text = "FTSE 100 (REINO UNIDO)";
            imagen.OnClientClick = "javascript:window.open('" + imagen.ImageUrl + "')";
        }

        protected void linkIndice6_Click1(Object sender, EventArgs e)
        {
            imagen.ImageUrl = ConfigurationManager.AppSettings["ImagenUrl6"].ToString();
            lblIndiceTittle.Text = "NIKKEI 225 (JAPÓN)";
            imagen.OnClientClick = "javascript:window.open('" + imagen.ImageUrl + "')";
        }

        protected void linkIndice7_Click1(Object sender, EventArgs e)
        {
            imagen.ImageUrl = ConfigurationManager.AppSettings["ImagenUrl7"].ToString();
            lblIndiceTittle.Text = "EPU (ETF-PERÚ)";
            imagen.OnClientClick = "javascript:window.open('" + imagen.ImageUrl + "')";
        }
    }
}