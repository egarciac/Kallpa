<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="KallpaUI.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta charset="utf-8">
    <title>Kallpa Securities SAB</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="../css/style.css">
    <script src="../js/vendor/modernizr-2.6.2.min.js"></script>
    <script type="text/javascript">
        function comprueba(anchor) {
            var num = anchor.value;
            var input = document.getElementById("txtPassword");
            input.value += num;
            return false;
        }

        function limpiar() {
            document.getElementById("txtPassword" == "" ? idPass : "txtPassword").value = "";
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <header class="section">
      <div class="group">
        <div class="col span-4-of-12" style="font-size: 0;">
          <a href="../index.aspx"><img src="../img/logo.jpg" alt="Kallpa Securities SAB" class="img-full" border="0"></a>
        </div>
        <nav class="col span-8-of-12">
          <ul class="list-inline website-links">
            <li><a href="#">Favoritos</a></li><!--
            --><li><a href="#">Recomendar</a></li><!--
            --><li><a href="#">Mapa</a></li><!--
            --><li><a href="#">WebMail</a></li><!--
            --><li><img src="../img/idioma.jpg" alt="Idioma"></li>
          </ul>
          <ul class="list-inline main-links">
            <li>
              <a href="#">nosotros</a>
              <div class="sub-links">
                <ul class="list">
                  <li><a href="../nosotros.html">- La empresa</a></li>
                  <li><a href="../nosotros-que-ofrecemos.html">- Que ofrecemos</a></li>
                  <li><a href="../nosotros-nuestros-expertos.html">- Nuestros expertos</a></li>
                </ul>
              </div>
            </li><!--
            --><li>
              <a href="#">nuestros productos</a>
              <!--div class="sub-links">
                <ul class="list">
                  <li><a href="#">Lorem ipsum</a></li>
                  <li><a href="#">Lorem ipsum dolor</a></li>
                  <li><a href="#">Lorem</a></li>
                  <li><a href="#">Lorem ipsum</a></li>
                </ul>
              </div-->
            </li><!--
            --><li>
              <a href="#">research</a>
              <div class="sub-links">
                <ul class="list">
                  <li><a href="../informes-periodicos.html">- Informes Periódicos</a></li>
                  <li><a href="../reportes-valorizacion.html">- Reportes de Valorización</a></li>
                  <li><a href="../presentaciones.html">- Presentaciones</a></li>
                  <li><a href="../research-medios.html">- Research en medios</a></li>
                </ul>
              </div>
            </li><!--
            --><li>
              <a href="#">contactenos</a>
              <div class="sub-links">
                <ul class="list">
                  <li><a href="../contacto-telefono.html">- Teléfonos</a></li>
                  <li><a href="../contacto-direcciones.html">- Dirección</a></li>
                  <li><a href="../contacto-oportunidades.html">- Oportunidades</a></li>
                </ul>
              </div>
            </li><!--
            --><li>
              <a href="#">sea nuestro cliente</a>
              <div class="sub-links">
                <ul class="list">
                  <li><a href="#">- Nosotros</a></li>
                  <li><a href="#">- Personas naturales</a></li>
                  <li><a href="#">- Personas jurídicas</a></li>
                </ul>
              </div>
            </li>
          </ul>
        </nav>
      </div>
    </header>
    <!-- Kallpa - body 
============================================ -->
    <section class="section internal-page login">
      <div class="group header">
        <div class="col span-12-of-12">
          <nav class="nav-bar">
            <ul class="list-inline">
              <li><a href="#">Ingrese a su cuenta</a></li>
            </ul>
          </nav>
        </div>
      </div>
      <div class="group body">
        <div class="col no-margin">
          <img src="../img/login1.jpg" alt="" class="img-full">
          <img src="../img/login2.png" alt="" class="img-full">
        </div>
        <div class="col no-margin">
          <div class="background">
            <img src="../img/login3.jpg" alt="" class="img-full">
            <img src="../img/login4.png" alt="" class="img-full">
          </div>
          <div class="content">
            <h1>Iniciar sesión</h1>
            <div class="group">
              <label for="user" style="float: left; width: 30%; font-weight: 700; color: #ddd; ">Usuario</label>
              <asp:TextBox ID="txtUsuario" runat="server" style="float: left; width: 66%; padding: .5em 2%; border: 0; -webkit-border-radius: 5px;-moz-border-radius: 5px;border-radius: 5px;"></asp:TextBox>
              <asp:RequiredFieldValidator ID="requiredUsuario" runat="server" ControlToValidate="txtUsuario" ErrorMessage="&nbsp;*"></asp:RequiredFieldValidator>
            </div>
            <div class="group">
              <label for="password" style="float: left; width: 30%; font-weight: 700; color: #ddd;">Clave</label>
              <input type="password" ID="txtPassword" runat="server" readonly="readonly" style="float: left; width: 66%; padding: .5em 2%; border: 0; -webkit-border-radius: 5px;-moz-border-radius: 5px;border-radius: 5px;" />
              
            </div>
            <h3>Ingrese su clave con el teclado virtual</h3>
            <%--<ul class="list-inline keyboard">--%>
            <table>
            <tr>
                <td>
                <table>
                <tr>
                    <td>
                    <asp:Button ID="btn0" runat="server" Text="Button" OnClientClick="return comprueba(this);" 
                            UseSubmitBehavior="false" BackColor="#76ac32" BorderColor="#76ac32" Width="30px" Height="30px" CssClass="display:inline-block; zoom:1; box-sizing:border-box;"
                            ForeColor="White"/>
                    </td>
                    <td>
                    <asp:Button ID="btn1" runat="server" Text="Button" OnClientClick="return comprueba(this);" 
                            UseSubmitBehavior="false" BackColor="#76ac32" BorderColor="#76ac32" Width="30px" Height="30px" CssClass="display:inline-block; zoom:1; box-sizing:border-box;"
                            ForeColor="White"/>
                    </td>
                    <td>
                    <asp:Button ID="btn2" runat="server" Text="Button" OnClientClick="return comprueba(this);" 
                            UseSubmitBehavior="false" BackColor="#76ac32" BorderColor="#76ac32" Width="30px" Height="30px" CssClass="display:inline-block; zoom:1; box-sizing:border-box;"
                            ForeColor="White"/>
                    </td>
                    <td>
                    <asp:Button ID="btn3" runat="server" Text="Button" OnClientClick="return comprueba(this);" 
                            UseSubmitBehavior="false" BackColor="#76ac32" BorderColor="#76ac32" Width="30px" Height="30px" CssClass="display:inline-block; zoom:1; box-sizing:border-box;"
                            ForeColor="White"/>
                    </td>
                    <td>
                    <asp:Button ID="btn4" runat="server" Text="Button" OnClientClick="return comprueba(this);" 
                            UseSubmitBehavior="false" BackColor="#76ac32" BorderColor="#76ac32" Width="30px" Height="30px" CssClass="display:inline-block; zoom:1; box-sizing:border-box;"
                            ForeColor="White"/>
                    </td>
                </tr>
                <tr>
                    <td>
                    <asp:Button ID="btn5" runat="server" Text="Button" OnClientClick="return comprueba(this);" 
                            UseSubmitBehavior="false" BackColor="#76ac32" BorderColor="#76ac32" Width="30px" Height="30px" CssClass="display:inline-block; zoom:1; box-sizing:border-box;"
                            ForeColor="White"/>
                    </td>
                    <td>
                    <asp:Button ID="btn6" runat="server" Text="Button" OnClientClick="return comprueba(this);" 
                            UseSubmitBehavior="false" BackColor="#76ac32" BorderColor="#76ac32" Width="30px" Height="30px" CssClass="display:inline-block; zoom:1; box-sizing:border-box;"
                            ForeColor="White"/>
                    </td>
                    <td>
                    <asp:Button ID="btn7" runat="server" Text="Button" OnClientClick="return comprueba(this);" 
                            UseSubmitBehavior="false" BackColor="#76ac32" BorderColor="#76ac32" Width="30px" Height="30px" CssClass="display:inline-block; zoom:1; box-sizing:border-box;"
                            ForeColor="White"/>
                    </td>
                    <td>
                    <asp:Button ID="btn8" runat="server" Text="Button" OnClientClick="return comprueba(this);" 
                            UseSubmitBehavior="false" BackColor="#76ac32" BorderColor="#76ac32" Width="30px" Height="30px" CssClass="display:inline-block; zoom:1; box-sizing:border-box;"
                            ForeColor="White"/>
                    </td>
                    <td>
                    <asp:Button ID="btn9" runat="server" Text="Button" OnClientClick="return comprueba(this);" 
                            UseSubmitBehavior="false" BackColor="#76ac32" BorderColor="#76ac32" Width="30px" Height="30px" CssClass="display:inline-block; zoom:1; box-sizing:border-box;"
                            ForeColor="White"/>
                    </td>
                </tr>
                </table>
            </td>
            <td>
            <div class="buttons">
                <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" 
                Width="120px" Height="30px" onclick="btnIngresar_Click"/><br/>
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClientClick="return limpiar();"  
                Width="120px" Height="30px"/>
            </div>
            </td>
            </tr>
            </table>
            <!--</ul>-->
          </div>
        </div>
      </div>
    </section>
    <!-- Kallpa - footer 
============================================ -->
    <footer class="section">
      <div class="wrapper group">
        <div class="col span-4-of-12 copyright">Todos los derechos reservados © Kallpa Securities SAB</div>
        <div class="col span-8-of-12 address">Central telefónica: (511) 630-7500 - contacto@kallpasab.com - Av. La Encalada 1388 of. 802. Surco, Lima</div>
      </div>
    </footer>
    <!-- Kallpa - javascript  
============================================ -->
    <script src="../js/vendor/jquery-1.10.2.min.js"></script>
    <script src="../js/vendor/jquery.easing.1.3.js"></script>
    <script src="../js/main.js"></script>
    </form>
</body>
</html>
