using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Pag_Net.Bll;
using Pag_Net.Models;
using Pag_Net.Tools;
using System.IO;
using Pag_Net.Tools.CryptFile;
using System.Xml;
using Pag_Net.Tools.CryptPassWord;

namespace Pag_Form
{
    public partial class fm_Menu : Form
    {

        //private bllPackageConnection myConnect;
        public Pag_Net.Models.modelSistemaUsuario Myconnect;
        public String UsrCd = "";
        public String UsrEmail = "";
        public String UsrNome = "";
        public string CONFIG_PATH;
        public string CONFIG_PATH_ICONS;
        public string CONFIG_ENV = "PRD";
        public string CONFIG_FILE_ENV = "";
        public string CONFIG_FILE_CONNECTIONS_SQLSERVER = "";
        public string CONFIG_FILE_ZEBRA = "";
        string CONFIG_API = "";

        string erro_info = "";


        public fm_Menu()
        {
            try
            {
                InitializeComponent();
                _Screen_load();
                
                /* Abrindo arquivos de Configuração */
                _SetConfigFiles();

                /* Definindo Enviroments */
                _SetEnviroment();
                Myconnect = new modelSistemaUsuario();
                Myconnect.PAG_API = CONFIG_API;
                Myconnect.Path_Spool = @System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("Pag_Form.exe", "") + @"spool\";

                try
                {
                    //var result = Myconnect.getApi("/status");
                    //var result = Myconnect.apiGet("/status"); //RESTAPI.get(Myconnect, "/status", null);
                    //Pag_Net.src.F0001_Sistema.model.ModelBackEndStatus myBackEndStatus = new Pag_Net.src.F0001_Sistema.model.ModelBackEndStatus();

                    //myBackEndStatus = Pag_Net.src.F0001_Sistema.model.ModelBackEndStatus.getJson(result.ToString());
                    if (!Myconnect.getStatusBackend())
                        throw new Exception("");
                    

                }
                catch (Exception ex)
                {
                    string messageErro = "BackEnd Não está ativo, favor acionar o Suporte com Urgência!" + "\n" + ex.Message;

                    if (Myconnect.user_name.ToUpper() == "ELIAS" || Myconnect.user_name.ToUpper() == "JOCELIO")
                        messageErro = "BackEnd " + Myconnect.PAG_API.ToString() + "Não está ativo, favor acionar o Suporte com Urgência!" + "\n" + ex.Message;
                        
                    throw new Exception(messageErro);
                }

                if (CONFIG_ENV == "DES")
                {
                    //txtUsuario.Text = "jocelio";
                    //txtUsuarioPassWord.Text = "ADM@57895";
                    
                    //txtUsuario.Text = "elias";
                    //txtUsuarioPassWord.Text = "+17jesusbom";
                    //cmdPagLogin_Click(null, null);
                    //_enviroment_teste();
                }

            }
            catch (Exception ex)
            {
                lbl_error_backend.Visible = true;
                txtUsuario.Text = "";
                txtUsuarioPassWord.Text = "";
                txtUsuario.Enabled = false;
                txtUsuarioPassWord.Enabled = false;
                cmdPagLogin.Enabled = false;
                UserTools._Screen_MessageBox(this,ex);
            }
        }
        private void cmdPagLogin_Click(object sender, EventArgs e)
        {

            string _strUserInfo = txtUsuario.Text.ToString().ToUpper().Trim();
            string _strPassWordInfo = txtUsuarioPassWord.Text.Trim();
            try
            {
                if (_strUserInfo == "" || _strPassWordInfo == "")
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Favor informar usuário e senha");
                    return;
                }

                //Myconnect = new modelSistemaUsuario("3", CONFIG_ENV, txtUsuario.Text, txtUsuarioPassWord.Text);
                //Myconnect.PAG_API = CONFIG_API;
                //Myconnect.Path_Spool = @System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("Pag_Form.exe", "") + @"spool\";


                /*
                    1) Lembrar que a senha deve ser considerada apenas no campo passwd_web e que o login é feito efetivamente pelo backend
                    2) o backend gerar um uuid que é usado para buscar as permissões
                    3) no caso do desktop ele le esse uuid e ve se tem codigo de participante na mesma linha da tabela. Se não tiver da erro de acesso
                    
                */

                if (this.Myconnect.login("3", CONFIG_ENV, txtUsuario.Text, txtUsuarioPassWord.Text))
                {
                    login_screen_set();
                    login_menu_set();
                }
                else
                {
                    txtUsuarioPassWord.Text = "";
                    txtUsuario.Focus();
                    throw new Exception("");
                }
            }
            catch (Exception)
            {
                UserTools._Screen_MessageBox(this, "Usuário/Senha Não confere!");
            }
        }

        private void login_screen_set()
        {
            pag_status_SPOOL.Text = Myconnect.Path_Spool.ToString();
            pag_status_User_Seq.Text = "User Seq: " + Myconnect.sis_us_seq.ToString();
            pag_status_User_Name.Text = "Login: " + txtUsuario.Text.ToString();
            pag_status_User_Acessos.Text = "List : " + this.Myconnect.Acessos.Count().ToString();
            pag_status_LINK_USER.Text = "Ref " + Pag_Net.Models.PagInfo.Version_description + " | Env: " + Myconnect.User_environment.ToString();
            pag_status_LINK_API.Text = "API _" + Myconnect.PAG_API;

            if (Myconnect.User_environment.ToString() == "DES")
            {
                pag_Menu.BackColor = Color.Red;
                lbl_desenvolvimento_INFO.Visible = true;
                lbl_desenvolvimento_INFO.BackColor = Color.Red;
                lbl_Label_USER.Text = "DESENVOL | USER";
                lbl_Label_SENHA.Text = "DESENVOL | PASSWORD";
                lbl_desenvolvimento_INFO.Text = "-> Ambiente de Desenvolvimento";

            }
            if (Myconnect.User_environment.ToString() == "HOM")
            {
                pag_Menu.BackColor = Color.Blue;
                lbl_desenvolvimento_INFO.Visible = true;
                lbl_desenvolvimento_INFO.BackColor = Color.Blue;
                lbl_Label_USER.Text = "HOMOLOG | USER";
                lbl_Label_SENHA.Text = "HOMOLOG | PASSWORD";
                lbl_desenvolvimento_INFO.Text = "Ambiente de Homologação";
            }
            if (Myconnect.User_environment.ToString() == "PRD")
            {
                lbl_desenvolvimento_INFO.Visible = false;

            }

            pag_Menu.Visible = true;
            pag_Menu.Enabled = true;
            GrpLogin.Visible = false;
            _SetConfigZebraImpressora();
        }
        private void login_menu_set()
        {
            try
            {
                for (int i = 0; i <= this.Myconnect.Acessos.Count() - 1; i++)
                {
                    switch (this.Myconnect.Acessos[i].sis_ac_menu.Trim().ToUpper())
                    {
                        case "M1111":
                            m1000.Enabled = true;
                            m1100.Enabled = true;
                            m1110.Enabled = true;
                            m1111.Enabled = true;
                            break;
                        case "M1112":
                            m1000.Enabled = true;
                            m1100.Enabled = true;
                            m1110.Enabled = true;
                            m1112.Enabled = true;
                            break;
                        case "M1113":
                            m1000.Enabled = true;
                            m1100.Enabled = true;
                            m1110.Enabled = true;
                            m1113.Enabled = true;
                            break;

                        case "M1130":
                            m1000.Enabled = true;
                            m1100.Enabled = true;
                            m1130.Enabled = true;
                            break;

                        case "M1141":
                            m1000.Enabled = true;
                            m1100.Enabled = true;
                            m1140.Enabled = true;
                            m1141.Enabled = true;
                            break;

                        case "M1911":
                            m1000.Enabled = true;
                            m1900.Enabled = true;
                            m1910.Enabled = true;
                            m1911.Enabled = true;
                            break;

                        case "M2100":
                            m2000.Enabled = true;
                            m2100.Enabled = true;
                            break;

                        case "M2300":
                            m2000.Enabled = true;
                            m2300.Enabled = true;
                            break;

                        case "M1510":
                            m1500.Enabled = true;
                            m1510.Enabled = true;
                            break;

                        case "M1511":
                            m1500.Enabled = true;
                            m1511.Enabled = true;
                            break;

                        case "M2200":
                            m2000.Enabled = true;
                            m2200.Enabled = true;
                            break;
                        case "M3100":
                            m3000.Enabled = true;
                            m3100.Enabled = true;
                            break;

                        case "M4110":
                            m4000.Enabled = true;
                            m4100.Enabled = true;
                            m4110.Enabled = true;
                            break;

                        case "M4120":
                            m4000.Enabled = true;
                            m4100.Enabled = true;
                            m4120.Enabled = true;
                            break;


                        case "M4130":
                            m4000.Enabled = true;
                            m4100.Enabled = true;
                            m4130.Enabled = true;
                            break;

                        case "M4141":
                            m4000.Enabled = true;
                            m4100.Enabled = true;
                            m4140.Enabled = true;
                            m4141.Enabled = true;
                            break;

                        case "M4150":
                            m4000.Enabled = true;
                            m4100.Enabled = true;
                            m4150.Enabled = true;
                            break;

                        case "M4161":
                            m4000.Enabled = true;
                            m4160.Enabled = true;
                            m4161.Enabled = true;
                            break;

                        case "M4162":
                            m4000.Enabled = true;
                            m4160.Enabled = true;
                            m4162.Enabled = true;
                            break;

                        case "M4163":
                            m4000.Enabled = true;
                            m4160.Enabled = true;
                            m4163.Enabled = true;
                            break;

                        case "M4210":
                            m4000.Enabled = true;
                            m4200.Enabled = true;
                            m4210.Enabled = true;
                            break;

                        case "M4351":
                            m4000.Enabled = true;
                            m4300.Enabled = true;
                            m4350.Enabled = true;
                            m4351.Enabled = true;
                            break;

                        case "M4352":
                            m4000.Enabled = true;
                            m4300.Enabled = true;
                            m4350.Enabled = true;
                            m4352.Enabled = true;
                            break;

                        case "M4391":
                            m4000.Enabled = true;
                            m4300.Enabled = true;
                            m4390.Enabled = true;
                            m4391.Enabled = true;
                            break;

                        case "M4410":
                            m4000.Enabled = true;
                            m4400.Enabled = true;
                            m4410.Enabled = true;
                            break;

                        case "M4510":
                            m4000.Enabled = true;
                            m4500.Enabled = true;
                            m4510.Enabled = true;
                            break;

                        case "M4520":
                            m4000.Enabled = true;
                            m4500.Enabled = true;
                            m4520.Enabled = true;
                            break;

                        case "M4541":
                            m4000.Enabled = true;
                            m4540.Enabled = true;
                            m4541.Enabled = true;
                            break;

                        case "M4610":
                            m4000.Enabled = true;
                            m4600.Enabled = true;
                            m4610.Enabled = true;
                            break;


                        case "M4421":
                            m4000.Enabled = true;
                            m4400.Enabled = true;
                            m4420.Enabled = true;
                            m4421.Enabled = true;
                            break;

                        case "M4310":
                            m4000.Enabled = true;
                            m4300.Enabled = true;
                            m4310.Enabled = true;
                            break;

                        case "M4321":
                            m4000.Enabled = true;
                            m4300.Enabled = true;
                            m4320.Enabled = true;
                            m4321.Enabled = true;
                            break;

                        case "M4331":
                            m4000.Enabled = true;
                            m4300.Enabled = true;
                            m4330.Enabled = true;
                            m4331.Enabled = true;
                            break;
                        case "M4332":
                            m4000.Enabled = true;
                            m4300.Enabled = true;
                            m4330.Enabled = true;
                            m4332.Enabled = true;
                            break;
                        case "M4340":
                            m4000.Enabled = true;
                            m4300.Enabled = true;
                            m4340.Enabled = true;
                            break;
                        case "M4811":
                            m4800.Enabled = true;
                            m4810.Enabled = true;
                            m4811.Enabled = true;
                            break;
                        case "M4821":
                            m4800.Enabled = true;
                            m4820.Enabled = true;
                            m4821.Enabled = true;
                            break;

                        case "M4831":
                            m4800.Enabled = true;
                            m4830.Enabled = true;
                            m4831.Enabled = true;
                            break;

                        case "M4832":
                            m4800.Enabled = true;
                            m4830.Enabled = true;
                            m4832.Enabled = true;
                            break;

                        case "M4910":
                            m4000.Enabled = true;
                            m4900.Enabled = true; 
                            m4910.Enabled = true;
                            break;




                        case "M5111":
                            m5000.Enabled = true;
                            m5100.Enabled = true;
                            m5110.Enabled = true;
                            m5111.Enabled = true;
                            break;

                        case "M5112":
                            m5000.Enabled = true;
                            m5100.Enabled = true;
                            m5110.Enabled = true;
                            m5112.Enabled = true;
                            break;


                        case "M5121":
                            m5000.Enabled = true;
                            m5100.Enabled = true;
                            m5120.Enabled = true;
                            //m5121.Enabled = true;
                            break;
                        case "M5210":
                            m5000.Enabled = true;
                            m5200.Enabled = true;
                            m5210.Enabled = true;
                            break;
                        case "M5220":
                            m5000.Enabled = true;
                            m5200.Enabled = true;
                            m5220.Enabled = true;
                            break;

                        case "M5300":
                            m5000.Enabled = true;
                            m5300.Enabled = true;
                            break;
                        case "M5400":
                            m5000.Enabled = true;
                            m5400.Enabled = true;
                            break;

                        case "M5510":
                            m5000.Enabled = true;
                            m5500.Enabled = true;
                            m5510.Enabled = true;
                            break;

                        case "M6110":
                            m6000.Enabled = true;
                            m6100.Enabled = true;
                            m6110.Enabled = true;
                            break;

                        case "M6911":
                            m6900.Enabled = true;
                            m6910.Enabled = true;
                            m6911.Enabled = true;
                            break;

                        case "M6912":
                            m6900.Enabled = true;
                            m6910.Enabled = true;
                            m6912.Enabled = true;
                            break;

                        case "M6913":
                            m6900.Enabled = true;
                            m6910.Enabled = true;
                            m6913.Enabled = true;
                            break;

                        case "M6914":
                            m6900.Enabled = true;
                            m6910.Enabled = true;
                            m6914.Enabled = true;
                            break;

                        case "M6915":
                            m6900.Enabled = true;
                            m6910.Enabled = true;
                            m6911.Enabled = true;
                            break;

                        case "M4710":
                            m4000.Enabled = true;
                            m4700.Enabled = true;
                            m4710.Enabled = true;
                            break;


                        case "M9210":
                            m9000.Enabled = true;
                            m9200.Enabled = true;
                            m9210.Enabled = true;
                            break;
                        case "M9230":
                            m9000.Enabled = true;
                            m9200.Enabled = true;
                            m9230.Enabled = true;
                            break;
                        case "M9231":
                            m9000.Enabled = true;
                            m9200.Enabled = true;
                            m9231.Enabled = true;
                            break;
                        case "M9410":
                            m9000.Enabled = true;
                            m9400.Enabled = true;
                            m9410.Enabled = true;
                            break;

                    }
                }
            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
        private void menu_click(object sender, EventArgs e)
        {
            try
            {
                string nomeMenu = ((ToolStripMenuItem)sender).Name.ToString();
                switch (nomeMenu)
                {
                    case "m1111": Pag_Form.forms.Cadastros.Produto.frm_Produto _m1111 = new Pag_Form.forms.Cadastros.Produto.frm_Produto(Myconnect); _m1111.MdiParent = this; _m1111.Show(); break;
                    case "m1112": Pag_Form.forms.Cadastros.ProdutoBluesoft.frm_ProdutoBluesoft _m1112 = new Pag_Form.forms.Cadastros.ProdutoBluesoft.frm_ProdutoBluesoft(Myconnect); _m1112.MdiParent = this; _m1112.Show(); break;
                    case "m1113": Pag_Form.forms.Cadastros.ProdutoBluesoft.frm_ProdutoBlueSoftTributacao _m1113 = new Pag_Form.forms.Cadastros.ProdutoBluesoft.frm_ProdutoBlueSoftTributacao(Myconnect); _m1113.MdiParent = this; _m1113.Show(); break;
                    case "m1130": Pag_Form.forms.Integracao.Produto.frm_IntegracaoProduto _m1130 = new forms.Integracao.Produto.frm_IntegracaoProduto(Myconnect); _m1130.MdiParent = this; _m1130.Show(); break;
                    case "m1141": Pag_Form.forms.Cadastros.Produto.frm_Produto_Zanthus_Mercadoria _m1141 = new forms.Cadastros.Produto.frm_Produto_Zanthus_Mercadoria(Myconnect); _m1141.MdiParent = this; _m1141.Show(); break;
                    case "m1911": Pag_Form.forms.Cadastros.Visualizacao.Notificacao.m1911_Notificacao _m1911 = new forms.Cadastros.Visualizacao.Notificacao.m1911_Notificacao(Myconnect); _m1911.MdiParent = this; _m1911.Show(); break;

                    case "m2100": Pag_Form.forms.Loja.Preco.frm_ProdutoPreco _m2100 = new Pag_Form.forms.Loja.Preco.frm_ProdutoPreco(Myconnect); _m2100.MdiParent = this; _m2100.Show(); break;
                    case "m2200": Pag_Form.forms.Loja.Preco.frm_ProdutoPreco_Listagem _m2200 = new Pag_Form.forms.Loja.Preco.frm_ProdutoPreco_Listagem(Myconnect); _m2200.MdiParent = this; _m2200.Show(); break;
                    case "m2300": Pag_Form.forms.Loja.Preco.frm_ProdutoPrecoLog _m2300 = new forms.Loja.Preco.frm_ProdutoPrecoLog(Myconnect); _m2300.MdiParent = this; _m2300.Show(); break;
                    case "m1510": Pag_Form.forms.frm_Pessoa_List _m1510 = new forms.frm_Pessoa_List(Myconnect); _m1510.MdiParent = this; _m1510.Show(); break;
                    case "m1511": Pag_Form.forms.Participantes.frm_GrupoEconomico _m1511 = new forms.Participantes.frm_GrupoEconomico(Myconnect); _m1511.MdiParent = this; _m1511.Show(); break;
                    case "m3100": Pag_Form.forms.frm_EstoqueCusto _m3100 = new forms.frm_EstoqueCusto(Myconnect); _m3100.MdiParent = this; _m3100.Show(); break;
                    case "m4110": Pag_Form.forms.frm_Loja_Atualizacao _m4110 = new forms.frm_Loja_Atualizacao(Myconnect); _m4110.MdiParent = this; _m4110.Show(); break;
                    case "m4120": Pag_Form.forms.frm_Loja_Etiqueta_Gondola _m4120 = new forms.frm_Loja_Etiqueta_Gondola(Myconnect); _m4120.MdiParent = this; _m4120.Show(); break;
                    case "m4130": Pag_Form.forms.frm_Loja_Voucher _m4130 = new forms.frm_Loja_Voucher(Myconnect); _m4130.MdiParent = this; _m4130.Show(); break;
                    case "m4141": Pag_Form.forms.frm_Loja_CupomConsulta _m4141 = new forms.frm_Loja_CupomConsulta(Myconnect); _m4141.MdiParent = this; _m4141.Show(); break;
                    case "m4150": Pag_Form.forms.Loja.frm_Loja_Controle _m4150 = new forms.Loja.frm_Loja_Controle(Myconnect); _m4150.MdiParent = this; _m4150.Show(); break;
                    case "m4210": Pag_Form.forms.frm_portaria _m4210 = new forms.frm_portaria(Myconnect); _m4210.MdiParent = this; _m4210.Show(); break;
                    case "m4310": Pag_Form.forms.Administrativo.frm_Controle _m4310 = new Pag_Form.forms.Administrativo.frm_Controle(Myconnect); _m4310.MdiParent = this; _m4310.Show(); break;
                    case "m4321": Pag_Form.forms.frm_Transporte_Ctrl _m4321 = new forms.frm_Transporte_Ctrl(Myconnect); _m4321.MdiParent = this; _m4321.Show(); break;
                    case "m4340": Pag_Form.forms.frm_Cartao_Acesso _m4330 = new forms.frm_Cartao_Acesso(Myconnect); _m4330.MdiParent = this; _m4330.Show(); break;
                    case "m4351": Pag_Form.forms.Ativo.frm_ativo_list _m4351 = new forms.Ativo.frm_ativo_list(Myconnect); _m4351.MdiParent = this; _m4351.Show(); break;
                    case "m4352": Pag_Form.forms.Ativo.frm_Ativo_Veiculo _m4352 = new forms.Ativo.frm_Ativo_Veiculo(Myconnect); _m4352.MdiParent = this; _m4352.Show(); break;
                    case "m4331": Pag_Form.forms.frm_Servico _m4331 = new forms.frm_Servico(Myconnect); _m4331.MdiParent = this; _m4331.Show(); break;
                    case "m4332": Pag_Form.forms.frm_Servico_Execucao_Ctrl _m4332 = new forms.frm_Servico_Execucao_Ctrl(Myconnect); _m4332.MdiParent = this; _m4332.Show(); break;
                    case "m4391": Pag_Form.forms.frm_DocumentoFiscalRegistro _m4391 = new forms.frm_DocumentoFiscalRegistro(Myconnect); _m4391.MdiParent = this; _m4391.Show(); break;
                    case "m4410": Pag_Form.forms.frm_Recebimento_Comando _m4410 = new forms.frm_Recebimento_Comando(Myconnect); _m4410.MdiParent = this; _m4410.Show(); break;
                    case "m4510": Pag_Form.forms.Rh.M4510_Rh_Cadastro_Manutencao _m4510 = new Pag_Form.forms.Rh.M4510_Rh_Cadastro_Manutencao(Myconnect); _m4510.MdiParent = this; _m4510.Show(); break;
                    case "m4520": Pag_Form.forms.Rh.frm_rh_Controle _m4520 = new forms.Rh.frm_rh_Controle(Myconnect); _m4520.MdiParent = this; _m4520.Show(); break;
                    case "m4541": Pag_Form.forms.Rh.frm_rh_salario _m4541 = new forms.Rh.frm_rh_salario(Myconnect); _m4541.MdiParent = this; _m4541.Show(); break;
                    case "m4610": Pag_Form.forms.frm_SerraSol_Ticket _m4610 = new forms.frm_SerraSol_Ticket(Myconnect); _m4610.MdiParent = this; _m4610.Show(); break;
                    case "m4710": Pag_Form.forms.frm_Recepcao _m4710 = new forms.frm_Recepcao(Myconnect); _m4710.MdiParent = this; _m4710.Show(); break;
                    case "m4811": Pag_Form.forms.Distribuicao.frm_FV_Comissao_Controle _m4811 = new Pag_Form.forms.Distribuicao.frm_FV_Comissao_Controle(Myconnect); _m4811.MdiParent = this; _m4811.Show(); break;
                    case "m4821": Pag_Form.forms.frm_FV_Frete_Controle _m4821 = new forms.frm_FV_Frete_Controle(Myconnect); _m4821.MdiParent = this; _m4821.Show(); break;
                    case "m4831": Pag_Form.forms.Distribuicao.Forca_Venda_Meta.frm_fv_meta_tipo _m4831 = new Pag_Form.forms.Distribuicao.Forca_Venda_Meta.frm_fv_meta_tipo(Myconnect); _m4831.MdiParent = this; _m4831.Show(); break;
                    case "m4832": Pag_Form.forms.Distribuicao.Forca_Venda_Meta.frm_fv_meta _m4832 = new Pag_Form.forms.Distribuicao.Forca_Venda_Meta.frm_fv_meta(Myconnect); _m4832.MdiParent = this; _m4832.Show(); break;
                    case "m4910": Pag_Form.forms.Operacoes.Faturamento.m4910_faturamentoBluesoft _m4910 = new forms.Operacoes.Faturamento.m4910_faturamentoBluesoft(Myconnect); _m4910.MdiParent = this; _m4910.Show(); break;
                    case "m5111": Pag_Form.forms.demontrativo.faturamento.Operacional.Frm_Faturamento_Analise_Basica _m5111 = new Pag_Form.forms.demontrativo.faturamento.Operacional.Frm_Faturamento_Analise_Basica(Myconnect); _m5111.MdiParent = this; _m5111.Show(); break;
                    case "m5112": Pag_Form.forms.demontrativo.faturamento.Operacional.m5112_Faturamento_Consulta_Listagem _m5112 = new Pag_Form.forms.demontrativo.faturamento.Operacional.m5112_Faturamento_Consulta_Listagem(Myconnect); _m5112.MdiParent = this; _m5112.Show(); break;
                    case "m5121": Pag_Form.forms.frm_DR_Consulta _m5121 = new forms.frm_DR_Consulta(Myconnect); _m5121.MdiParent = this; _m5121.Show(); break;
                    case "m5210": Pag_Form.forms.frm_DR_fpgto_setor_operacional _m5210 = new forms.frm_DR_fpgto_setor_operacional(Myconnect); _m5210.MdiParent = this; _m5210.Show(); break;
                    case "m5220": Pag_Form.forms.Financeiro.frmConsultarPosicaoFinanceira _m5220 = new Pag_Form.forms.Financeiro.frmConsultarPosicaoFinanceira(Myconnect); _m5220.MdiParent = this; _m5220.Show(); break;
                    case "m5300": Pag_Form.forms.frm_DR_Mapa _m5300 = new forms.frm_DR_Mapa(Myconnect); _m5300.MdiParent = this; _m5300.Show(); break;
                    case "m5400": Pag_Form.forms.frm_DR_Processamento _m5400 = new forms.frm_DR_Processamento(Myconnect); _m5400.MdiParent = this; _m5400.Show(); break;
                    case "m5510": Pag_Form.forms.demontrativo.resultado.frm_despesa _m5510 = new Pag_Form.forms.demontrativo.resultado.frm_despesa(Myconnect); _m5510.MdiParent = this; _m5510.Show(); break;
                    case "m6110": Pag_Form.forms.frm_Interface_Comercial_sugestao_pedido _m6110 = new forms.frm_Interface_Comercial_sugestao_pedido(Myconnect); _m6110.MdiParent = this; _m6110.Show(); break;
                    case "m4421": Pag_Form.forms.frm_EstoqueLocal_Mov _m4421 = new forms.frm_EstoqueLocal_Mov(Myconnect); _m4421.MdiParent = this; _m4421.Show(); break;
                    case "m9210": Pag_Form.forms.frm_Sistema_Integracoes _m9210 = new forms.frm_Sistema_Integracoes(Myconnect); _m9210.MdiParent = this; _m9210.Show(); break;
                    case "m9230": Pag_Form.forms.Sistema.frm_Sistema_Batchs_Manager _m9230 = new Pag_Form.forms.Sistema.frm_Sistema_Batchs_Manager(Myconnect); _m9230.MdiParent = this; _m9230.Show(); break;
                    case "m9231": Pag_Form.forms.Sistema.frm_Sistema_Log _m9231 = new Pag_Form.forms.Sistema.frm_Sistema_Log(Myconnect); _m9231.MdiParent = this; _m9231.Show(); break;
                    case "m9410": Pag_Form.forms.Sistema.notificacoes.m9410_notificacao_log _m9410 = new Pag_Form.forms.Sistema.notificacoes.m9410_notificacao_log(Myconnect); _m9410.MdiParent = this; _m9410.Show(); break;

                }
                pag_status_forms.Text = "Forms: " + MdiChildren.Length.ToString();
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Error, "Erro", ex);
            }

        }

        private void _SetConfigFiles()
        {
            try
            {

                CONFIG_PATH = @System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("Pag_Form.exe", "") + @"Configs\";
                CONFIG_PATH_ICONS = CONFIG_PATH + @"\Ico\";
                CONFIG_FILE_ENV = @System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("Pag_Form.exe", "") + @"Configs\ENVS.XML";
                CONFIG_FILE_CONNECTIONS_SQLSERVER = @System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("Pag_Form.exe", "") + @"Configs\infox.dll";
                CONFIG_FILE_ZEBRA = @System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("Pag_Form.exe", "") + @"Configs\infom.dll";

            }
            catch (Exception ex)
            {
                throw new Exception("SetConfigFiles | " + ex.Message);
            }
        }
        private void _SetEnviroment()
        {
            try
            {
                XmlDocument MyXml = new XmlDocument();
                MyXml.LoadXml(Pag_Net.Tools.PagToolsFileTxt.open(CONFIG_FILE_ENV));
                XmlNodeList x = MyXml.GetElementsByTagName("ENV");
                CONFIG_ENV = x.Item(0).Attributes["Environment"].Value.ToString();
                CONFIG_API = x.Item(0).Attributes["PAG_API"].Value.ToString();

            }
            catch (Exception ex)
            {
                throw new Exception("_SetEnviroment | " + ex.Message);
            }

        }
        private void _SetConfigZebraImpressora()
        {
            try
            {
                Myconnect.ZEBRA = "1";
                //String FileMenuAmbienteZebra = @System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("Pag_Wpf.exe", "") + @"\infoM.dll";
                if (File.Exists(CONFIG_FILE_ZEBRA))
                {
                    Cryptf PagToolCrypt = new Cryptf();
                    string XMLConnection = PagToolCrypt.FileDecryptToString(CONFIG_FILE_ZEBRA);
                    XmlDocument MyXml = new XmlDocument();
                    MyXml.LoadXml(XMLConnection);
                    XmlNodeList x = MyXml.GetElementsByTagName("CONFIG");
                    foreach (XmlNode attr in x)
                    {
                        Myconnect.ZEBRA = attr.Attributes["ZEBRA"].Value.ToString();
                        Myconnect.ZEBRACMD = attr.Attributes["ZEBRACMD"].Value.ToString();
                        Myconnect.ZEBRACMDL = attr.Attributes["ZEBRACMDL"].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("SetConfigFiles | " + ex.Message);
            }

        }
        private void _enviroment_teste()
        {
            //Pag_Form.forms.frm_Pessoa_List x = new forms.frm_Pessoa_List(Myconnect);
            //x.ShowDialog();
        }
        private void _Screen_load()
        {
            try
            {
                this.Text = "PRIME | " + Pag_Net.Models.PagInfo.VERSAO_ECOSYSTEM + "." +  Pag_Net.Models.PagInfo.VERSAO;
                pag_Menu.Visible = false;
                pag_Menu.Enabled = false;



                m1000.Enabled = false;
                m1100.Enabled = false;
                m1110.Enabled = false;
                m1111.Enabled = false;

                m1000.Enabled = false;
                m1900.Enabled = false;
                m1910.Enabled = false;
                m1911.Enabled = false;

                m1112.Enabled = false;
                m1113.Enabled = false;
                m1120.Enabled = false;
                m1130.Enabled = false;
                m1140.Enabled = false;
                m1141.Enabled = false;
                m1500.Enabled = false;
                m1510.Enabled = false;
                m1511.Enabled = false;
                m2000.Enabled = false;
                m2100.Enabled = false;
                m2200.Enabled = false;
                m2300.Enabled = false;
                m3000.Enabled = false;
                m3100.Enabled = false;
                m3200.Enabled = false;


                m4000.Enabled = false;
                m4100.Enabled = false;
                m4110.Enabled = false;
                m4120.Enabled = false;
                m4130.Enabled = false;
                m4150.Enabled = false;
                m4110.Enabled = false;
                m4160.Enabled = false;
                m4161.Enabled = false;
                m4162.Enabled = false;



                m4200.Enabled = false;
                m4210.Enabled = false;
                m4220.Enabled = false;
                m4230.Enabled = false;

                m4300.Enabled = false;
                m4321.Enabled = false;
                m4330.Enabled = false;
                m4331.Enabled = false;
                m4332.Enabled = false;
                m4350.Enabled = false;
                m4351.Enabled = false;
                m4352.Enabled = false;

                m4300.Enabled = false;
                m4390.Enabled = false;
                m4391.Enabled = false;

                m4310.Enabled = false;
                m4400.Enabled = false;
                m4410.Enabled = false;
                m4500.Enabled = false;
                m4510.Enabled = false;
                m4520.Enabled = false;
                m4530.Enabled = false;
                m4540.Enabled = false;
                m4541.Enabled = false;
                m4610.Enabled = false;
                m4710.Enabled = false;
                m4421.Enabled = false;
                m4600.Enabled = false;
                m4700.Enabled = false;

                m4710.Enabled = false;


                m4800.Enabled = false;
                m4810.Enabled = false;
                m4811.Enabled = false;
                m4820.Enabled = false;
                m4821.Enabled = false;


                m4830.Enabled = false;
                m4831.Enabled = false;
                m4832.Enabled = false;
                m4910.Enabled = false;


                m5000.Enabled = false;
                m5100.Enabled = false;
                m5110.Enabled = false;
                m5111.Enabled = false;
                m5120.Enabled = false;
                m5112.Enabled = false;

                m5200.Enabled = false;
                m5120.Enabled = false;
                m5210.Enabled = false;
                m5220.Enabled = false;
                m5230.Enabled = false;
                m5240.Enabled = false;
                m5300.Enabled = false;
                m5400.Enabled = false;
                m5500.Enabled = false;
                m5510.Enabled = false;
                m5520.Enabled = false;
                m6000.Enabled = false;
                m6100.Enabled = false;
                m6110.Enabled = false;
                m6900.Enabled = false;
                m6910.Enabled = false;
                m6911.Enabled = false;
                m6912.Enabled = false;
                m6913.Enabled = false;
                m6914.Enabled = false;
                m6915.Enabled = false;
                m9000.Enabled = false;
                m9200.Enabled = false;
                m9210.Enabled = false;
                m9230.Enabled = false;
                m9231.Enabled = false;
                m9410.Enabled = false;




                m1000.Click += new EventHandler(menu_click);
                m1100.Click += new EventHandler(menu_click);
                m1110.Click += new EventHandler(menu_click);
                m1111.Click += new EventHandler(menu_click);


                m1000.Click += new EventHandler(menu_click);
                m1900.Click += new EventHandler(menu_click);
                m1910.Click += new EventHandler(menu_click);
                m1911.Click += new EventHandler(menu_click);

                m1112.Click += new EventHandler(menu_click);
                m1113.Click += new EventHandler(menu_click);
                m1140.Click += new EventHandler(menu_click);
                m1141.Click += new EventHandler(menu_click);

                m1120.Click += new EventHandler(menu_click);
                m1130.Click += new EventHandler(menu_click);
                m1510.Click += new EventHandler(menu_click);
                m1511.Click += new EventHandler(menu_click);
                m2000.Click += new EventHandler(menu_click);
                m2100.Click += new EventHandler(menu_click);
                m2200.Click += new EventHandler(menu_click);
                m2300.Click += new EventHandler(menu_click);

                m3000.Click += new EventHandler(menu_click);
                m3100.Click += new EventHandler(menu_click);
                m3200.Click += new EventHandler(menu_click);

                m4100.Click += new EventHandler(menu_click);
                m4110.Click += new EventHandler(menu_click);
                m4120.Click += new EventHandler(menu_click);
                m4130.Click += new EventHandler(menu_click);
                m4140.Click += new EventHandler(menu_click);
                m4141.Click += new EventHandler(menu_click);
                m4150.Click += new EventHandler(menu_click);
                m4160.Click += new EventHandler(menu_click);
                m4161.Click += new EventHandler(menu_click);
                m4162.Click += new EventHandler(menu_click);
                m4163.Click += new EventHandler(menu_click);

                m4200.Click += new EventHandler(menu_click);
                m4210.Click += new EventHandler(menu_click);
                m4220.Click += new EventHandler(menu_click);
                m4230.Click += new EventHandler(menu_click);
                m4300.Click += new EventHandler(menu_click);
                m4340.Click += new EventHandler(menu_click);
                m4391.Click += new EventHandler(menu_click);
                m4410.Click += new EventHandler(menu_click);
                m4331.Click += new EventHandler(menu_click);
                m4332.Click += new EventHandler(menu_click);
                m4350.Click += new EventHandler(menu_click);
                m4351.Click += new EventHandler(menu_click);
                m4352.Click += new EventHandler(menu_click);
                m4510.Click += new EventHandler(menu_click);
                m4541.Click += new EventHandler(menu_click);
                m4520.Click += new EventHandler(menu_click);
                m4610.Click += new EventHandler(menu_click);

                m4421.Click += new EventHandler(menu_click);
                m4310.Click += new EventHandler(menu_click);
                m4321.Click += new EventHandler(menu_click);
                m4821.Click += new EventHandler(menu_click);
                m4830.Click += new EventHandler(menu_click);
                m4831.Click += new EventHandler(menu_click);
                m4832.Click += new EventHandler(menu_click);
                m4910.Click += new EventHandler(menu_click);


                m5000.Click += new EventHandler(menu_click);
                m5100.Click += new EventHandler(menu_click);
                m5110.Click += new EventHandler(menu_click);
                m5111.Click += new EventHandler(menu_click);
                m5112.Click += new EventHandler(menu_click);
                m5120.Click += new EventHandler(menu_click);
                //m5121.Click += new EventHandler(menu_click);
                m5200.Click += new EventHandler(menu_click);
                m5210.Click += new EventHandler(menu_click);
                m5220.Click += new EventHandler(menu_click);
                m5300.Click += new EventHandler(menu_click);
                m5400.Click += new EventHandler(menu_click);
                m5500.Click += new EventHandler(menu_click);
                m5510.Click += new EventHandler(menu_click);
                m6000.Click += new EventHandler(menu_click);
                m6100.Click += new EventHandler(menu_click);
                m6110.Click += new EventHandler(menu_click);
                m6900.Click += new EventHandler(menu_click);
                m6910.Click += new EventHandler(menu_click);
                m6911.Click += new EventHandler(menu_click);
                m6912.Click += new EventHandler(menu_click);
                m6913.Click += new EventHandler(menu_click);
                m6914.Click += new EventHandler(menu_click);
                m6915.Click += new EventHandler(menu_click);
                m4710.Click += new EventHandler(menu_click);
                m4811.Click += new EventHandler(menu_click);

                m9200.Click += new EventHandler(menu_click);
                m9200.Click += new EventHandler(menu_click);
                m9210.Click += new EventHandler(menu_click);
                m9230.Click += new EventHandler(menu_click);
                m9231.Click += new EventHandler(menu_click);
                m9410.Click += new EventHandler(menu_click);
            }
            catch (Exception ex)
            {
                throw new Exception("Screen_load | " + ex.Message);
            }



        }
    }


    
}

