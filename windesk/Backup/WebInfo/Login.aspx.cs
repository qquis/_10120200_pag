using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Web.Security;
using Pag_Net.Bll;
using Pag_Net.Models;

namespace WebInfo
{
    public partial class Login : System.Web.UI.Page
    {
        private bllPackageConnection myConnect;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            FormsAuthentication.RedirectFromLoginPage("Administrador", false);
            string _strUserInfo = "ELIAS"; //txtUserLogin.Text.ToString().ToUpper().Trim();
            string _strPassWordInfo = "+17jesusbom"; //txtSenhaLogin.Password.ToString();
            myConnect = new bllPackageConnection("WPF", _strUserInfo, "PRD", "LAN", _strPassWordInfo, Server.MapPath(@"~/infox.dll"));
        }
    }
}
