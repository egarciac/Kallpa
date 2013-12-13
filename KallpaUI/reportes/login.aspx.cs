using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KallpaBusiness;
using System.Data;

namespace KallpaUI
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            CalcularBotones();
        }

        private void Loguear()
        {
            try
            {
                string strUsuario = null;
                string strPassword = null;
                DataSet ds = null;

                strUsuario = txtUsuario.Text;
                strPassword = txtPassword.Value;
                
                ds = Usuario.Validar(strUsuario, strPassword);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Key",
                            "alert('El usuario y clave ingresados son incorrectos.');window.location='login.aspx'", true);
                    //Response.Redirect("login.aspx");
                }
                else
                {
                    Session["SetValues"] = ds.Tables[0];
                    Session["UserPKID"] = Usuario.ObtenerID(ds.Tables[0].Rows[0][2].ToString());
                    Response.Redirect("login-bienvenida.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Key",
                "alert('There was an error processing your request.');window.location='login.aspx'", true);
            }

        }
        
        public void CalcularBotones()
        {

            int[] aux2 = new int[10];
            Random r2 = new Random();

            for (int i = 0; i < aux2.Length; i++)  //For para poner los valores en -1 del vector
                aux2[i] = -1;

            for (int i = 0; i < aux2.Length; i++)
            {
                int num = r2.Next(0, aux2.Length);
                for (int j = 0; j <= i; j++)
                {
                    if (aux2[j] == num)
                    {
                        num = r2.Next(0, aux2.Length);
                        j = -1;
                    }
                }
                aux2[i] = num;
            }
            for (int i = 0; i < 10; i++)
            {
                switch (i)
                {
                    case 0: btn0.Text = aux2[i].ToString(); break;
                    case 1: btn1.Text = aux2[i].ToString(); break;
                    case 2: btn2.Text = aux2[i].ToString(); break;
                    case 3: btn3.Text = aux2[i].ToString(); break;
                    case 4: btn4.Text = aux2[i].ToString(); break;
                    case 5: btn5.Text = aux2[i].ToString(); break;
                    case 6: btn6.Text = aux2[i].ToString(); break;
                    case 7: btn7.Text = aux2[i].ToString(); break;
                    case 8: btn8.Text = aux2[i].ToString(); break;
                    case 9: btn9.Text = aux2[i].ToString(); break;
                }
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Loguear();
            return;
        }
              

        //LoginWEB login = new LoginWEB(strUsuario, strPassword);
        //if (login is DBNull)
        //{
        //    lblMensaje.Text = "Usuario no Registrado";
        //}
        //else
        //{
        //    Session["Cliente"] = login.Cliente;
        //    Session["Tipo"] = login.Cliente.Tipo;
        //    Session["IDCliente"] = login.Cliente.ID;



    }


}