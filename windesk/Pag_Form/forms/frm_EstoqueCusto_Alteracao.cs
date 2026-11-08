using Pag_Net.Bll.EstoqueCusto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pag_Net.Bll.F0030_EstoqueCusto;

namespace Pag_Form.forms
{
    public partial class frm_EstoqueCusto_Alteracao : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;

        Pag_Net.Bll.F0030_EstoqueCusto.Wk WK;

        model_estoquecusto ProdutoCusto;
        model_EstoqueCusto_Receita ProdutoCusto_Receita_item;
        public frm_EstoqueCusto_Alteracao(
            Pag_Net.Models.modelSistemaUsuario _MyConnect,
            model_estoquecusto _Item
            )
        {
            InitializeComponent();

            cmdsair.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda.ico");
            cmdefetivar_precos_alterados.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\ok.ico");
            MyConnect = _MyConnect;

            WK = new Pag_Net.Bll.F0030_EstoqueCusto.Wk(MyConnect);
            ProdutoCusto = _Item;

            lbl_pr_cdproduto.Text = ProdutoCusto.pr_cdproduto.ToString();
            lbl_info_prb_cdprodutobluesoft.Text = ProdutoCusto.prb_cdprodutobluesoft.ToString();
            lbl_pr_descricao.Text = ProdutoCusto.pr_descricao.ToString();
            lbl_TIPO_CESTA.Text = ProdutoCusto.pr_cesta_char.ToString();
            lbl_valor_unitario.Text = ProdutoCusto.ec_valor_custo_precificacao.ToString("0.00");
            txtVl_Custo_de_Entrada.Text = ProdutoCusto.ec_valor_custo_precificacao.ToString("0.00");

            txtecr_valor_custo.GotFocus += new EventHandler(txtcusto_receita_custo_porcao__GotFocus);
            txtecr_valor_peso_por_embalagem.LostFocus += new EventHandler(txtecr_valor_peso_por_embalagem__LostFocus);

            UserTools._Screen_Form_Format_DataGridView(dtgProdutoPagReceitaAdm);

            _Cancelar_Pesquisa_Item_Receita();
            
            panel_CustoPor_Receita.DataBindings.Add("Enabled", optCUSTO_POR_RECEITA, "Checked");
            panel_CustoEntrada_Temporario.DataBindings.Add("Enabled", optCUSTO_TEMPORARIO, "Checked");

            ProdutoCusto.CustoReceita_DataBinding(MyConnect);
            dtgProdutoPagReceitaAdm.DataSource = ProdutoCusto.List_TbEstoqueCusto_Receita;
        }

        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdefetivar_precos_alterados_Click(object sender, EventArgs e)
        {
            
            try {

                if (optCUSTO_TEMPORARIO.Checked)
                {
                    if (txtVl_Custo_de_Entrada.Text == "" || txtVl_Custo_de_Entrada.Text == "0")
                    {
                        MessageBox.Show("Custo Inválido");
                        return;
                    }
                    int _pr_cdproduto = Convert.ToInt32(lbl_pr_cdproduto.Text);
                    double _valor = Convert.ToDouble(txtVl_Custo_de_Entrada.Text);
                    CustoEntrada.Atualizar(MyConnect, _pr_cdproduto, _valor);
                }

                if (optCUSTO_POR_RECEITA.Checked)
                {
                    ProdutoCusto._List_TbEstoqueCusto_Efetivar(MyConnect);
                }

                UserTools._Screen_MessageBox(this, "Custo Administrado via PAG efetivado");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmdConsultarItemReceita_Click(object sender, EventArgs e)
        {
            try
            {
                //model_EstoqueCusto_Receita ProdutoCusto_Receita_item = ProdutoCusto.CustoReceita_Item_new(MyConnect, ProdutoCusto.pr_cdproduto);
                UserTools._Screen_Wait(this);
                if (txtcusto_receita_cdproduto.Text.Trim().ToString() == "")
                {
                    UserTools._Screen_MessageBox(this, UserTools.PagTipoMessageBox.Atencao, "Favor indicar o código do item da Receita");
                    return;
                }
                ProdutoCusto_Receita_item = ProdutoCusto.CustoReceita_Item_new(MyConnect, Convert.ToInt32(txtcusto_receita_cdproduto.Text));
                if (ProdutoCusto_Receita_item.pr_cdproduto != 0)
                {
                    panel_RECEITA.Enabled = true;
                    txtcusto_receita_cdproduto.Enabled = false; 
                }
                else
                {
                    panel_RECEITA.Enabled = false;
                    txtcusto_receita_cdproduto.Enabled = true; 
                }

                lbl_descricao.Text = ProdutoCusto_Receita_item.pr_descricao;
                txtcusto_receita__peso.Text = ProdutoCusto_Receita_item.ecr_peso_total_item.ToString();
                txtcusto_receita_custocomercial.Text = ProdutoCusto_Receita_item.ecr_valor_custo_comercial.ToString("0.00");
                UserTools._Screen_Wait(this, false);
            } 
            catch (Exception ex)
            {
                UserTools._Screen_Wait(this, false);
                _Cancelar_Pesquisa_Item_Receita();
                UserTools._Screen_MessageBox(this,"Produto NÃO localizado ou INVÁLIDO: \n" + ex.Message);
            }
        }

        private void txtcusto_receita_custo_porcao__GotFocus(object sender, EventArgs e)
        {

        }

        private void txtecr_valor_peso_por_embalagem__LostFocus(object sender, EventArgs e)
        {
            _Calcular_Item();
        }

        private void cmdAdicionarItemReceita_Click(object sender, EventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);
                _Calcular_Item();
                if (txtcusto_receita_cdproduto.Text.Trim() == "")
                    new Exception("Informe o Código do Produto Item da Receita e clique em Consultar");

                if (txtcusto_receita__peso.Text.Trim() == "" )
                                    new Exception("Favor indicar o peso do Produto/Quantidade Unitária Base");

                if (txtecr_valor_peso_por_embalagem.Text.Trim() == "")
                    new Exception("Informe o peso proporcional que será utilizado na receita");
                
                ProdutoCusto_Receita_item.ecr_peso_total_item = Convert.ToDouble(txtcusto_receita__peso.Text);
                ProdutoCusto_Receita_item.ecr_valor_peso_por_embalagem = Convert.ToDouble(txtecr_valor_peso_por_embalagem.Text);
                ProdutoCusto_Receita_item.ecr_valor_custo = Convert.ToDouble(txtecr_valor_custo.Text);

                ProdutoCusto._List_TbEstoqueCusto_Receita_Add(ProdutoCusto_Receita_item);
                dtgProdutoPagReceitaAdm.DataSource = ProdutoCusto.List_TbEstoqueCusto_Receita;

                lblCusto_Receita_Total.Text = ProdutoCusto.List_TbEstoqueCusto_Receita_PRC_VALOR.ToString("0.00");

                _Cancelar_Pesquisa_Item_Receita();
                UserTools._Screen_Wait(this,false);

            }
            catch (Exception ex)
            {
                UserTools._Screen_Wait(this, false);
                UserTools._Screen_MessageBox(this, ex.Message);
            }
        }

        private void cmdCancelarItemPesquisado_Click(object sender, EventArgs e)
        {
            _Cancelar_Pesquisa_Item_Receita();
        }

        private void _Cancelar_Pesquisa_Item_Receita()
        {
            try
            {
                txtcusto_receita_cdproduto.Enabled = true;
                txtcusto_receita_cdproduto.Text = "";
                panel_RECEITA.Enabled = false;
                txtcusto_receita__peso.Text = "";
                txtcusto_receita_custocomercial.Text = "";
                txtecr_valor_peso_por_embalagem.Text = "";
                txtecr_valor_custo.Text = "";
            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void _Calcular_Item()
        {
            try
            {
                if (txtecr_valor_peso_por_embalagem.Text == "")
                    return;

                if (txtcusto_receita_custocomercial.Text == "")
                    return;

                if (txtcusto_receita__peso.Text == "")
                    return;


                if (Convert.ToDouble(txtecr_valor_peso_por_embalagem.Text) == 0)
                    throw new Exception("Valor no Campo <Peso Por Embalagem> deve ser maior que ZERO!");

                if (Convert.ToDouble(txtcusto_receita_custocomercial.Text) == 0)
                    throw new Exception("O Item está sem custo, não será possível adicioná-lo à Receita!");


                if (Convert.ToDouble(txtecr_valor_peso_por_embalagem.Text) == 0)
                    throw new Exception("Informe o Peso/Unidade por Embalagem final!");


                if (Convert.ToDouble(txtcusto_receita_custocomercial.Text) > 0 && Convert.ToDouble(txtecr_valor_peso_por_embalagem.Text) > 0)
                {
                    txtecr_valor_custo.Text = (Convert.ToDouble(txtcusto_receita_custocomercial.Text) / Convert.ToDouble(txtcusto_receita__peso.Text) * Convert.ToDouble(txtecr_valor_peso_por_embalagem.Text)).ToString("0.00");
                }

                if (Convert.ToDouble(txtecr_valor_custo.Text) == 0)
                {
                    throw new Exception("Erro no Cálculo do Custo!");
                }

            }

            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, "Erro no cálculo do custo do Item da Receita PAG \n" + ex.Message);
            }
        }



    }
}
