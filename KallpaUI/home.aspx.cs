using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KallpaBusiness;

namespace KallpaUI
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //Getting Data from WebPage
            string strUsuario = txtUsuario.Text;
            string strClave = txtPassword.Text;

            //Validating not null 
            if (strUsuario.Length != 0 && strClave.Length != 0)
            {
                Response.Redirect("welcome.aspx", false);
                //Login()
            }
            else
            { 
                
            }
        }
    }
}