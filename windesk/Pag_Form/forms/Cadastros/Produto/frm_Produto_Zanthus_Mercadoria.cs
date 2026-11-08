using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.Cadastros.Produto
{
    public partial class frm_Produto_Zanthus_Mercadoria : Form
    {

        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.src.F0020_Produto._index F0020;
        public frm_Produto_Zanthus_Mercadoria(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            _Screen_load();

        }

        public frm_Produto_Zanthus_Mercadoria(Pag_Net.Models.modelSistemaUsuario _MyConnect, int pr_cdproduto, int prb_cdprodutobluesoft, string preg_cdbarra)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            txtcdproduto.Text = pr_cdproduto.ToString();
            txtcdprodutobluesoft.Text = prb_cdprodutobluesoft.ToString();
            txtpreg_cdbarra.Text = preg_cdbarra.ToString();
            _Screen_load();
        }       

        private void _Screen_load()
        {
            F0020 = new Pag_Net.src.F0020_Produto._index(MyConnect);
            UserTools._Screen_Form_Open(this);
            UserTools._Screen_ButtonImage(cmdsair, UserTools.PagButtonsIcons._Default_Sair);
            UserTools._Screen_ButtonImage(cmdConsultar, UserTools.PagButtonsIcons.Atualiza);
            UserTools._Screen_ButtonImage(cmdZanthusDetalheMercadoriaConsultar, UserTools.PagButtonsIcons.Efetiva_Seleciona);

            UserTools._Screen_Form_Format_DataGridView(dtgZ, true);
            UserTools._Screen_Form_Format_DataGridView(dtgREGRAICMS, true);
            UserTools._Screen_Form_Format_DataGridView(dtgMercadoriaTipoVenda, true);

            F0020.reports.PropertyChanged += _databinding;

       
        }

        private void _databinding(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "dbList_ZanthusMercadoria")
            {
                dtgZ.DataSource = F0020.reports.dbList_ZanthusMercadoria.List;
                UserTools._Screen_DataBinding_Set(lbl_preg_cdbarra, dtgZ.DataSource, "preg_cdbarra");
            }

            if (e.PropertyName == "dbList_ZanthusRegraICMS")
            {
                dtgREGRAICMS.DataSource = F0020.reports.dbList_ZanthusRegraICMS.List;
            }

            if (e.PropertyName == "dbList_ZanthusMercadoriaTipoVenda")
            {
                dtgMercadoriaTipoVenda.DataSource = F0020.reports.dbList_ZanthusMercadoriaTipoVenda.List;
            }
        }

        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);
                F0020.reports.FilterClear();


                if (txtpr_descricao.Text != "")
                    F0020.reports.filtro.pr_descricao = txtpr_descricao.Text.ToString().TrimEnd();

                if (txtpr_descricao.Text != "")
                    F0020.reports.filtro.prb_descricao = txtprb_descricao.Text.ToString().TrimEnd();


                if (txtcdproduto.Text.ToString().Trim() != "")
                    F0020.reports.filtro.pr_cdproduto = Convert.ToInt32(txtcdproduto.Text.Trim());

                if (txtcdprodutobluesoft.Text.ToString().Trim() != "")
                    F0020.reports.filtro.prb_cdprodutoBlueSoft = Convert.ToInt32(txtcdprodutobluesoft.Text.Trim());

                if (txtpreg_cdbarra.Text.Trim() != "")
                    F0020.reports.filtro.preg_cdbarra = txtpreg_cdbarra.Text.Trim();



                F0020.reports.Produto_ZanthusMercadoriaConsultar();
                UserTools._Screen_Wait(this);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdZanthusDetalheMercadoriaConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbl_preg_cdbarra.Text == "")
                {
                    UserTools._Screen_MessageBox(this, "Selecione um Cod de Mercadoria ZANTHUS");
                    return; 
                }
                UserTools._Screen_Wait(this);
                F0020.reports.Produto_ZanthusMercadoriaRegraICMSConsultar(lbl_preg_cdbarra.Text);
                F0020.reports.Produto_ZanthusMercadoriaTipoVendaConsultar(lbl_preg_cdbarra.Text);
                UserTools._Screen_Wait(this);
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void dtgZ_SelectionChanged(object sender, EventArgs e)
        {
            dtgClearSelection();
        }

        private void dtgClearSelection()
        {
            
        }
    
    }

}
