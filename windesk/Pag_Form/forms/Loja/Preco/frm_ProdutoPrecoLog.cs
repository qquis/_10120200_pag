using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.Loja.Preco
{
    public partial class frm_ProdutoPrecoLog : Form
    {
        public Pag_Net.Models.modelSistemaUsuario MyConnect;

        Pag_Net.src.F0045_Preco.reports._indexReport F0045_PRECO;

        public frm_ProdutoPrecoLog(Pag_Net.Models.modelSistemaUsuario _Myconnect)
        {
            InitializeComponent();
            MyConnect = _Myconnect;
            _Screen_load();
        }

        public frm_ProdutoPrecoLog(Pag_Net.Models.modelSistemaUsuario _Myconnect, int pr_cdproduto)
        {
            InitializeComponent();
            MyConnect = _Myconnect;
            if (pr_cdproduto != 0)
                txtcdproduto.Text = pr_cdproduto.ToString(); 

            _Screen_load();
        }

        private void _Screen_load()
        {

            F0045_PRECO = new Pag_Net.src.F0045_Preco.reports._indexReport(MyConnect);

            UserTools._Screen_Form_Open(this);
            UserTools._Screen_ButtonImage(cmdAtualiza, UserTools.PagButtonsIcons.Atualiza);
            UserTools._Screen_ButtonImage(cmdAtualizaBlueSoftD1, UserTools.PagButtonsIcons.Efetiva_Seleciona);
            UserTools._Screen_ButtonImage(cmdAtualizaBlueSoftGeral, UserTools.PagButtonsIcons.Efetiva_Seleciona);
            UserTools._Screen_Form_Format_DataGridView(dtgPrecoLog);

            cmbTabelaPrecificacao.DisplayMember = "tab_pre_descricao";
            cmbTabelaPrecificacao.ValueMember = "tab_pre_cd";
            cmbTabelaPrecificacao.DataSource = Pag_Net.Bll.Precos.TabelasdePrecos.Get(MyConnect);

            cmbTabelaPrecificacao.SelectedIndex = 0;
            F0045_PRECO.PropertyChanged += _databinding;

        }

        private void _databinding(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "dbList_PrecoLog")
            {
                dtgPrecoLog.DataSource = F0045_PRECO.dbList_PrecoLog.List;
            }

        }

        private void cmdAtualiza_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);

                F0045_PRECO.filterClear(); 

                if (txtcdproduto.Text != "")
                    F0045_PRECO.filtro.cdproduto = Convert.ToInt32(txtcdproduto.Text);

                if (txtcdprodutobluesoft.Text != "")
                    F0045_PRECO.filtro.cdprodutobluesoft = Convert.ToInt32(txtcdprodutobluesoft.Text);

                if (txtdescricao.Text != "")
                    F0045_PRECO.filtro.descricao = txtdescricao.Text;



                F0045_PRECO.filtro.tab_pre_cd = Convert.ToInt32(cmbTabelaPrecificacao.SelectedValue);
                F0045_PRECO.filtro.dt_data_aplicacao_ini = dtpData_Aplicacao_Ini.Value;
                F0045_PRECO.filtro.dt_data_aplicacao_fim = dtpData_Aplicacao_Fim.Value;
                F0045_PRECO.PrecoLogConsultar();
                UserTools._Screen_Wait(this);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void cmdAtualizaBlueSoftD1_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserTools._Screen_MessageBox_OkCancel(this, "Confirma geração de batch para atualização de preços na BlueSoft (Produtos alterados de ontem para hoje)?"))
                {
                    UserTools._Screen_Wait(this);
                    Pag_Net.Bll.F0045_Preco.Wk WKPRECO = new Pag_Net.Bll.F0045_Preco.Wk(MyConnect);
                    WKPRECO.BlueSoft_Update(45011,2);
                    UserTools._Screen_Wait(this);
                }
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdAtualizaBlueSoftGeral_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserTools._Screen_MessageBox_OkCancel(this, "Confirma geração de batch para atualização de preços GERAIS (Todos os Produtos)?"))
                {
                    UserTools._Screen_Wait(this);
                    Pag_Net.Bll.F0045_Preco.Wk WKPRECO = new Pag_Net.Bll.F0045_Preco.Wk(MyConnect);
                    WKPRECO.BlueSoft_Update(45021,3);
                    UserTools._Screen_Wait(this);
                }
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }
    }
}
