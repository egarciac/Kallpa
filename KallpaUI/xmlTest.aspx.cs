using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Configuration;
using System.Net;

namespace KallpaUI
{
    public partial class xmlTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            String Image1 = ConfigurationManager.AppSettings["SP500Imagen"].ToString();
            imagen.ImageUrl = Image1;

            String URLString = ConfigurationManager.AppSettings["SP500"].ToString();
            XmlDocument archivoxml = new XmlDocument();
            archivoxml.Load(URLString);
            XmlNodeList LastPrice = archivoxml.GetElementsByTagName("LastTradePriceOnly");
            XmlNodeList Percent = archivoxml.GetElementsByTagName("PercentChange");
            lblValue1.Text = LastPrice[0].InnerText;
            lblChange1.Text = Percent[0].InnerText;

                            
            
                    
         }
    }
}