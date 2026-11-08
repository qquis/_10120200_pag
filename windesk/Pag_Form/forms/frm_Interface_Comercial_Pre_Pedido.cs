using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms
{
    public partial class frm_Interface_Comercial_Pre_Pedido : Form
    {   
        
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.Bll.Interface.Comercial.PrePedido BLL;
        int __FABRICANTE_CDPESSOABLUESOFT;
        int __FAT_RES_SEQ;
        int __FV_FABRICANTE_DIVISAO_CD = 0;

        public frm_Interface_Comercial_Pre_Pedido(
            Pag_Net.Models.modelSistemaUsuario _myConnect,
            Pag_Net.Bll.Interface.Comercial.tbcomercial_pre_pedido_item[] _arraydatagridview_dtgsugestaocompra,
            int fabricante_cdpessoabluesoft , 
            string fv_fabricante_nome,
            int _fat_res_seq
            
            )
        {
            InitializeComponent();
            MyConnect = _myConnect;
            __FABRICANTE_CDPESSOABLUESOFT = fabricante_cdpessoabluesoft;
            __FAT_RES_SEQ = _fat_res_seq;

            BLL = new Pag_Net.Bll.Interface.Comercial.PrePedido(MyConnect);
            BLL.list_tbcomercial_pre_pedido_item = _arraydatagridview_dtgsugestaocompra;
            
            

            txtfabricante_cdpessoabluesoft.Text = __FABRICANTE_CDPESSOABLUESOFT.ToString();
            txtFabricante_descricao.Text = fv_fabricante_nome;
            _Screen_load();

        }
        private void _Screen_load()
        {
            cmdsair.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda.ico");
            cmdeftivar.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\ok.ico");
            dtgSugestaoCompra.AutoGenerateColumns = false;
            dtgSugestaoCompra.DataSource = BLL.list_tbcomercial_pre_pedido_item;
            foreach (DataGridViewColumn i in dtgSugestaoCompra.Columns)
            {
                i.ReadOnly = true;
            }


            DataTable Datatable_PesquisarCodigoDivisao = Pag_Net.Bll.Cadastros_Gerais.Poll.Get_DataTable_Fabricantes_Distribuicao(MyConnect, __FABRICANTE_CDPESSOABLUESOFT);
            if (Datatable_PesquisarCodigoDivisao.Rows.Count > 0)
                __FV_FABRICANTE_DIVISAO_CD = Convert.ToInt32(Datatable_PesquisarCodigoDivisao.Rows[0]["fv_fabricante_divisao_cd"].ToString());



            BLL.__tbcomercial_pre_pedido = 
            Pag_Net.Bll.Interface.Comercial.Tool.Pre_pedido_Inserir(
                MyConnect
                , new Pag_Net.Bll.Interface.Comercial.tbcomercial_pre_pedido(0, 0, DateTime.Now, __FABRICANTE_CDPESSOABLUESOFT, __FAT_RES_SEQ, 0 )
                );

            lbl_cm_pre_ped_seq.Text = BLL.__tbcomercial_pre_pedido.cm_pre_ped_seq.ToString();

            _DtgSugestaoCompra_databinding();
        }
        private void _DtgSugestaoCompra_databinding()
        {
            dtgSugestaoCompra.DataSource = BLL.list_tbcomercial_pre_pedido_item;
        }
        private void _list_item(DataGridViewRow[] _arraydatagridview_dtgsugestaocompra)
        {
            List<Pag_Net.Bll.Interface.Comercial.tbcomercial_pre_pedido_item> __list = new List<Pag_Net.Bll.Interface.Comercial.tbcomercial_pre_pedido_item>();
            int __count = _arraydatagridview_dtgsugestaocompra.Count() - 1;
            for (int i = 0; i <= __count; i++)
            {

                if (Convert.ToDouble(_arraydatagridview_dtgsugestaocompra[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde"].Value.ToString()) > 0)
                {
                    Pag_Net.Bll.Interface.Comercial.tbcomercial_pre_pedido_item item = new Pag_Net.Bll.Interface.Comercial.tbcomercial_pre_pedido_item();
                    item.cm_pre_ped_seq = 0;
                    item.cm_pre_ped_seq_item = 0;
                    item.pr_cdproduto = Convert.ToInt32(_arraydatagridview_dtgsugestaocompra[i].Cells["dtgSugestaoCompra_pr_cdproduto"].Value.ToString());
                    item.prb_cdprodutobluesoft = Convert.ToInt32(_arraydatagridview_dtgsugestaocompra[i].Cells["dtgSugestaoCompra_prb_cdprodutobluesoft"].Value.ToString());
                    item.prb_embalagemestoque = _arraydatagridview_dtgsugestaocompra[i].Cells["dtgSugestaoCompra_prb_embalagemestoque"].Value.ToString();
                    item.prb_cdprodutobluesoft_compra = Convert.ToInt32(_arraydatagridview_dtgsugestaocompra[i].Cells["dtgSugestaoCompra_prb_cdprodutobluesoft_compra"].Value.ToString());
                    item.prb_embalagemcompra = _arraydatagridview_dtgsugestaocompra[i].Cells["dtgSugestaoCompra_prb_embalagemcompra"].Value.ToString();
                    item.prb_fatorestoque = Convert.ToDouble(_arraydatagridview_dtgsugestaocompra[i].Cells["dtgSugestaoCompra_prb_fatorestoque"].Value.ToString());

                    item.ec_embalagemcompra_qtde = Convert.ToDouble(_arraydatagridview_dtgsugestaocompra[i].Cells["dtgSugestaoCompra_ec_embalagemcompra_qtde"].Value.ToString());
                    item.ec_embalagemestoque_qtde = Convert.ToDouble(_arraydatagridview_dtgsugestaocompra[i].Cells["dtgSugestaoCompra_ec_embalagemestoque_qtde"].Value.ToString());

                    item.cm_pre_ped_item_embalagemestoque_qtde = Convert.ToDouble(_arraydatagridview_dtgsugestaocompra[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_embalagemestoque_qtde"].Value.ToString());
                    item.cm_pre_ped_item_embalagemcompra_qtde = Convert.ToDouble(_arraydatagridview_dtgsugestaocompra[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_embalagemcompra_qtde"].Value.ToString());
                    item.cm_pre_ped_item_valor = Convert.ToDouble(_arraydatagridview_dtgsugestaocompra[i].Cells["dtgSugestaoCompra_cm_pre_ped_item_valor"].Value.ToString());
                    item.pr_descricao = _arraydatagridview_dtgsugestaocompra[i].Cells["dtgSugestaoCompra_pr_descricao"].Value.ToString();
                    __list.Add(item);
                }
            }
            BLL.list_tbcomercial_pre_pedido_item = __list.ToArray();
        }

        private void cmdeftivar_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.efetivar_pedido();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void _Screen_wait(Button cmd, bool ON)
        {
            if (ON)
            {
                cmd.Enabled = false;
                _Screen_wait(ON);
            }
            else
            {
                _Screen_wait(ON);
                cmd.Enabled = true;
            }
        }
        private void _Screen_wait(bool ON)
        {
            if (ON)
            {
                this.Cursor = Cursors.WaitCursor;
                this.Refresh();
            }
            else
            {
                this.Cursor = Cursors.Arrow;
                this.Refresh();
            }
        }

    }
}
