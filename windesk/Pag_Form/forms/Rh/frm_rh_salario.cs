using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pag_Form.forms.Rh
{
    public partial class frm_rh_salario : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.Bll.F0141_Rh.WKSalarioContratado WK;
        public frm_rh_salario(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            InitializeComponent();
            MyConnect = _MyConnect;
            WK = new Pag_Net.Bll.F0141_Rh.WKSalarioContratado(MyConnect);
            _Screen_load();
        }

        private void _Screen_load()
        {
            try
            {
                UserTools._Screen_ButtonImage(cmdsair, UserTools.PagButtonsIcons._Default_Sair);
                UserTools._Screen_ButtonImage(cmdConsultar, UserTools.PagButtonsIcons.Atualiza);
                UserTools._Screen_Form_Format_DataGridView(dtgFuncionario);
                UserTools._Screen_Form_Format_DataGridView(dtgS);
                UserTools._Screen_Form_Format_DataGridView(dtgc);

                cmbrh_tipo_contrato_descricao.ValueMember = "rh_tipo_contrato_cd";
                cmbrh_tipo_contrato_descricao.DisplayMember = "rh_tipo_contrato_descricao";
                cmbrh_tipo_contrato_descricao.DataSource = Pag_Net.Bll.F0141_Rh.MyComboBoxList.Tipo_Contratos(MyConnect, 0);


                cmbrh_setor_operacional_descricao.ValueMember = "rh_setor_operacional_cd";
                cmbrh_setor_operacional_descricao.DisplayMember = "rh_setor_operacional_descricao";
                cmbrh_setor_operacional_descricao.DataSource = Pag_Net.Bll.F0141_Rh.MyComboBoxList.Setor_Operacional(MyConnect);


                WK.PropertyChanged += __BindingList;
                dtgS.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(_dataGrid_ColumnHeaderMouseDoubleClick);
                dtgc.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(_dataGrid_ColumnHeaderMouseDoubleClick);
                dtgFuncionario.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(_dataGrid_ColumnHeaderMouseDoubleClick);

                
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        public void __BindingList(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                UserTools._Screen_Wait(this);
                dtgFuncionario.DataSource = WK.MyListFuncionarios.List;
                //dtgS.DataSource = WK.MySetorOperacional.List;
                dtgc.DataSource = WK.MyContrato.List;
                dtgS.DataSource = WK.MySetorOperacional.List;

                UserTools._Screen_DataBinding_Set(lbl_funcionario_cd, WK.MyListFuncionarios.List, "funcionario_cd");
                UserTools._Screen_DataBinding_Set(lbl_nome_razao, WK.MyListFuncionarios.List, "nome_razao");
                UserTools._Screen_DataBinding_Set(lbl_rh_tipo_contrato_descricao, WK.MyListFuncionarios.List, "rh_tipo_contrato_descricao");
                UserTools._Screen_DataBinding_Set(lbl_rh_setor_operacional_descricao, WK.MyListFuncionarios.List, "rh_setor_operacional_descricao");
                UserTools._Screen_DataBinding_Set(txt_rh_vl_contrato_bruto, WK.MyListFuncionarios.List, "rh_vl_contrato_bruto");
                UserTools._Screen_DataBinding_Set(txt_rh_vl_contrato_liq, WK.MyListFuncionarios.List, "rh_vl_contrato_liq");
                UserTools._Screen_DataBinding_Set(txt_rh_vl_folha_brt, WK.MyListFuncionarios.List, "rh_vl_folha_brt");
                UserTools._Screen_DataBinding_Set(txt_rh_vl_folha_liq, WK.MyListFuncionarios.List, "rh_vl_folha_liq");
                UserTools._Screen_DataBinding_Set(txt_rh_vl_pj, WK.MyListFuncionarios.List, "rh_vl_pj");
                UserTools._Screen_DataBinding_Set(txt_rh_vl_outros, WK.MyListFuncionarios.List, "rh_vl_outros");





                UserTools._Screen_Wait(this);
            }
            catch( Exception ex )
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                txtnome_razao.Text = txtnome_razao.Text.ToString().ToUpper();
                WK._Filter.nome = txtnome_razao.Text;
                WK.Get();
            }
            catch (Exception ex) { UserTools._Screen_MessageBox(this, ex); }

                

        }

        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbrh_tipo_contrato_descricao_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Pag_Net.Bll.F0141_Rh.TbRh_Tipo_Contrato TipoContratoSelecionado = ((Pag_Net.Bll.F0141_Rh.TbRh_Tipo_Contrato)cmbrh_tipo_contrato_descricao.SelectedItem);
                WK._Filter.rh_tipo_contrato_cd = TipoContratoSelecionado.rh_tipo_contrato_cd;
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void cmbrh_setor_operacional_descricao_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Pag_Net.Bll.F0141_Rh.TbRh_Setor_Operacional SetorOperacionalSelecionado = ((Pag_Net.Bll.F0141_Rh.TbRh_Setor_Operacional)cmbrh_setor_operacional_descricao.SelectedItem);
                WK._Filter.rh_setor_operacional_cd = SetorOperacionalSelecionado.rh_setor_operacional_cd;
            }
            catch (Exception ex)
            {
                UserTools._Screen_MessageBox(this, ex);
            }
        }

        private void _dataGrid_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                
                //MessageBox.Show(((DataGridView)sender).Name);
                /*
                if (((DataGridView)sender).Name == "dtgS")
                {

                    WK.MyListFuncionarios = WK.MyListFuncionarios.OrderBy(X => X.rh_vl_folha_brt).ToArray();

                    //WK.MyListOrderBy(WK.MySetorOperacional, ((DataGridView)sender).Columns[e.ColumnIndex].DataPropertyName);
                    dtgS.DataSource = null; 
                    dtgS.DataSource = WK.MySetorOperacional;



                }

                if (((DataGridView)sender).Name == "dtgc")
                {
                    WK.MyListOrderBy(WK.MyContrato, ((DataGridView)sender).Columns[e.ColumnIndex].DataPropertyName);
                    dtgc.DataSource = null;
                    dtgc.DataSource = WK.MyContrato;
                }

                if (((DataGridView)sender).Name == "dtgFuncionario")
                {
                    WK.MyListOrderBy(WK.MyListFuncionarios, ((DataGridView)sender).Columns[e.ColumnIndex].DataPropertyName);
                    dtgFuncionario.DataSource = null;
                    dtgFuncionario.DataSource = WK.MyListFuncionarios;

                }*/


                
            }
            catch (Exception ex) { UserTools._Screen_MessageBox(this, ex);  }
        }
    }
}
