using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pag_Net.Bll;
using Pag_Net.Models;

namespace WebInfo
{
    public partial class _Default : System.Web.UI.Page
    {
        ModelSystemUserInfoConnect MyConnect;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CMDTeste_Click(object sender, EventArgs e)
        {
            
            string _strUserInfo = "ELIAS"; //txtUserLogin.Text.ToString().ToUpper().Trim();
            string _strPassWordInfo = "+17jesusbom"; //txtSenhaLogin.Password.ToString();
            MyConnect = new bllPackageConnection("WPF", _strUserInfo, "PRD", "LAN", _strPassWordInfo, Server.MapPath(@"~/infox.dll"));

            Pag_Net.Bll.Cadastros.Fabricante f = new Pag_Net.Bll.Cadastros.Fabricante(MyConnect);
            

        }
    }
}
