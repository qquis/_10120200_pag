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
    public partial class frm_DR_Consulta : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.Bll.Bll_DemonstrativoResultado BLL;
        int _VCENTRODR_TIPO_CD = 0;
        int _VCENTRODR_RESUMO_TIPO_CD = 0;
        public frm_DR_Consulta(Pag_Net.Models.modelSistemaUsuario _myConnect)
        {
            InitializeComponent();
            MyConnect = _myConnect;
            BLL = new Pag_Net.Bll.Bll_DemonstrativoResultado(MyConnect);
            _Screen_load();
        }

      
        private void _Screen_load()
        {
            try
            {
                cmdsair.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda.ico");
                cmdAtualiza.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\atualiza.ico");

                dtgcentrodr_fechamento_tipo.AutoGenerateColumns = false;


                dtgcentrodr_fechamento.AutoGenerateColumns = false;
                dtgcentrodr_fechamento.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DG_CellFormatting);
                dtgcentrodr_fechamento.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(DG_ColumnHeaderMouseClick);
                dtgcentrodr_fechamento.SelectionChanged += new System.EventHandler(this.DG_SelectionChanged);
                dtgcentrodr_fechamento.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellEndEdit);

                foreach (DataGridViewColumn column in dtgcentrodr_fechamento.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }


                foreach (DataGridViewColumn column in dtgcentrodr_fechamento_tipo.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }



                lbl_Mapeamento_Resumo_cd.TextChanged += new System.EventHandler(_Screen_changed);
                
                dtgDespesaResumo.SelectionChanged += new System.EventHandler(this.DG_SelectionChanged);
                

                dtgDespesaResumo.AutoGenerateColumns = false;
                dtgDespesaMapa.AutoGenerateColumns = false;


                

                cmbOperacao.TextChanged += new EventHandler(_Screen_changed);
                cmbOperacao.ValueMember = "op_cdoperacao";
                cmbOperacao.DisplayMember = "op_descricao";
                cmbOperacao.DataSource = BLL.ConsultaOperacoes();
                cmbOperacao.SelectedIndex = 0;

                

                cmbdr_subgrupo.TextChanged += new EventHandler(_Screen_changed);
                cmbdr_subgrupo.ValueMember = "cdr_subgrupo_cd";
                cmbdr_subgrupo.DisplayMember = "cdr_subgrupo_descricao";
                cmbdr_subgrupo.DataSource = BLL.Consultar_Centrodr_SubGrupo();
                cmbdr_subgrupo.SelectedIndex = 0;

                cmbCompetencia.TextChanged += new EventHandler(_Screen_changed);
                cmbCompetencia.ValueMember = "competencia_cd";
                cmbCompetencia.DisplayMember = "competencia_descricao";
                cmbCompetencia.DataSource = BLL.Competencias();
                _databinding_CentroDr_SubrGrupo();
                cmbCompetencia.SelectedIndex = 0;


                CmbCdr_tipo_descricao.TextChanged += new System.EventHandler(this._Screen_changed);
                CmbCdr_tipo_descricao.ValueMember = "cdr_tipo_cd";
                CmbCdr_tipo_descricao.DisplayMember = "cdr_tipo_descricao";
                CmbCdr_tipo_descricao.DataSource = BLL.Consultar_CentroDr_Tipo(0);

                cmbcentrodr_resumo_tipo.TextChanged += new System.EventHandler(this._Screen_changed);
                cmbcentrodr_resumo_tipo.ValueMember = "centrodr_resumo_tipo_cd";
                cmbcentrodr_resumo_tipo.DisplayMember = "centrodr_resumo_tipo_descricao";
                cmbcentrodr_resumo_tipo.DataSource = BLL.Consultar_CentroDR_Resumo_Tipo();

                lbl_cdr_fechamento_Cd.TextChanged += new System.EventHandler(this._Screen_changed);

            }
            catch (Exception ex )
            {
                MessageBox.Show("Erro: " + ex.Message);
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
        private void _Screen_changed(object sender, EventArgs e)
        {
            try
            {
                if (sender.GetType().Name == "ComboBox")
                {
                    switch (((ComboBox)sender).Name)
                    {


  
                        case "cmbcentrodr_resumo_tipo":
                            _VCENTRODR_RESUMO_TIPO_CD = Convert.ToInt32(cmbcentrodr_resumo_tipo.SelectedValue);
                            _databinding_Mapemaento_Resumo();
                            break;
                        case "CmbCdr_tipo_descricao":
                            _VCENTRODR_TIPO_CD = Convert.ToInt32(CmbCdr_tipo_descricao.SelectedValue);
                            _databinding_Mapemaento_Resumo();
                            break;

                        case "cmbOperacao":
                            BLL.Op_CdOperacao_SELECIONADO = Convert.ToInt32(cmbOperacao.SelectedValue);
                            _databinding_CentroDr_SubrGrupo();
                            if (Convert.ToInt32(cmbOperacao.SelectedValue) == 0)
                            {
                                cmbdr_subgrupo.Enabled = false;
                                BLL.Centrodr_SubGrupo_SELECIONADO = 0;
                            }
                            else 
                            {
                                cmbdr_subgrupo.Enabled = true;
                            }
                            break;
                        case "cmbdr_subgrupo":
                            BLL.Centrodr_SubGrupo_SELECIONADO = Convert.ToInt32(cmbdr_subgrupo.SelectedValue);
                            break;
                        case "cmbCompetencia":
                            BLL.CompetenciaCD_SELECIONADA = Convert.ToInt32(cmbCompetencia.SelectedValue);
                            break;
                    }

                }


                if (sender.GetType().Name == "Label")
                {
                    if (((Label)sender).Text != "")
                    {
                        switch ((((Label)sender).Name))
                        {
                            case "lbl_Mapeamento_Resumo_cd":
                                dtgDespesaMapa.DataSource = BLL.ConsultaDemonstrativoResultado_Lancamento_Mapa(Convert.ToInt32(((Label)sender).Text), 0);
                                break;
                            case "lbl_cdr_fechamento_Cd":
                                dtgcentrodr_fechamento_tipo.DataSource = BLL.CentroDrFechamento_BY_Tipo(Convert.ToInt32(lbl_cdr_fechamento_Cd.Text));
                                break;
                        }

                    }
                }
            }
            catch (Exception ErroMessage)
            {
                MessageBox.Show(ErroMessage.Message);
            }
   

        }
        private void _screen_clear_lbl_valor()
        {
            lbl_Valor_CMV.Text = "";
        }
        
        private void _pesquisar()
        {
            try
            {
                _Screen_wait(cmdAtualiza, true);
                _screen_clear_lbl_valor();
                _databinding_fechamento();
                _databinding_Mapemaento_Resumo();
                _Screen_wait(cmdAtualiza, false);

                string _FORMAT = "#,###,##0.00";

                lbl_Valor_A_ReceitaBrutaFaturamento.Text = BLL.Valor_A_ReceitaBrutaFaturamento.ToString(_FORMAT);
                lbl_Valor_CMV.Text = BLL.Valor_CMV.ToString(_FORMAT);                               
                lbl_Valor_B_ReceitaSemCMV.Text = BLL.Valor_B_ReceitaSemCMV.ToString(_FORMAT);

                lbl_Valor_B_ReceitaSemCMV_MG.Text = (BLL.Valor_B_ReceitaSemCMV / BLL.Valor_A_ReceitaBrutaFaturamento * 100).ToString(_FORMAT);

                lbl_Valor_C_ReceitaSemImpostos.Text = BLL.Valor_C_ReceitaSemImpostos.ToString(_FORMAT);
                lbl_Valor_C_ReceitaSemImpostos_MG.Text = (BLL.Valor_C_ReceitaSemImpostos / BLL.Valor_A_ReceitaBrutaFaturamento * 100).ToString(_FORMAT);


                lbl_Valor_D_ReceitaSemDescontosFinanceiros.Text = BLL.Valor_D_ReceitaSemDescontosFinanceiros.ToString(_FORMAT);
                lbl_Valor_D_ReceitaSemDescontosFinanceiros_MG.Text = (BLL.Valor_D_ReceitaSemDescontosFinanceiros / BLL.Valor_A_ReceitaBrutaFaturamento * 100).ToString(_FORMAT);

                lbl_Valor_E_ReceitaComAcordosComerciais.Text = BLL.Valor_E_ReceitaComAcordosComerciais.ToString(_FORMAT);
                lbl_Valor_E_ReceitaComAcordosComerciais_MG.Text = (BLL.Valor_E_ReceitaComAcordosComerciais / BLL.Valor_A_ReceitaBrutaFaturamento * 100).ToString(_FORMAT);


                lbl_Valor_F_ReceitaSemDespesasVariaveis.Text = BLL.Valor_F_ReceitaSemDespesasVariaveis.ToString(_FORMAT);
                lbl_Valor_F_ReceitaSemDespesasVariaveis_MG.Text = (BLL.Valor_F_ReceitaSemDespesasVariaveis / BLL.Valor_A_ReceitaBrutaFaturamento * 100).ToString(_FORMAT);

                
                lbl_Valor_G_ReceitaSemCustosFixosDiretos.Text = BLL.Valor_G_ReceitaSemCustosFixosDiretos.ToString(_FORMAT);
                lbl_Valor_G_ReceitaSemCustosFixosDiretos_MG.Text = (BLL.Valor_G_ReceitaSemCustosFixosDiretos / BLL.Valor_A_ReceitaBrutaFaturamento * 100).ToString(_FORMAT);

                lbl_Valor_H_ReceitaSemCustosFixosIndiretos.Text = BLL.Valor_H_ReceitaSemCustosFixosIndiretos.ToString(_FORMAT);
                lbl_Valor_H_ReceitaSemCustosFixosIndiretos_MG.Text = (BLL.Valor_H_ReceitaSemCustosFixosIndiretos / BLL.Valor_A_ReceitaBrutaFaturamento * 100).ToString(_FORMAT);


                lbl_Valor_DESPESAS_GERAIS.Text = BLL.Valor_DESPESAS_GERAIS.ToString(_FORMAT);
                lbl_Valor_DESPESAS_LOJA.Text = BLL.Valor_DESPESAS_LOJA.ToString(_FORMAT);
                lbl_Valor_DESPESAS_DISTRIBUICAO.Text = BLL.Valor_DESPESAS_DISTRIBUICAO.ToString(_FORMAT);
                
                lbl_Valor_RESULTADO.Text = BLL.Valor_RESULTADO.ToString(_FORMAT);
                lbl_Valor_RESULTADO_MG.Text = (BLL.Valor_RESULTADO / BLL.Valor_A_ReceitaBrutaFaturamento * 100).ToString(_FORMAT);
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void _databinding_fechamento()
        {
            string format = "#,###,##0.00";
            dtgcentrodr_fechamento.DataSource = BLL.ConsultaDemonstrativoFechamento();
            lbl_Valor_CMV.Text = BLL.Valor_CMV.ToString(format);

            lbl_cdr_fechamento_Cd.DataBindings.Clear();
            lbl_cdr_fechamento_Cd.DataBindings.Add("Text", dtgcentrodr_fechamento.DataSource, "cdr_fechamento_cd");


        }
        private void _databinding_DemonstrativoResultado()
        {
            
        }
        private void _databinding_Mapemaento_Resumo()
        {
            DataTable DataTableDespesaResumo = BLL.ConsultaDemonstrativoResultado_Resumo(_VCENTRODR_TIPO_CD, _VCENTRODR_RESUMO_TIPO_CD);
            lbl_total_referencias.Text = "Total de Referências: " + DataTableDespesaResumo.Rows.Count.ToString();
            dtgDespesaResumo.DataSource = DataTableDespesaResumo;
            lbl_Mapeamento_Resumo_cd.DataBindings.Clear();
            lbl_Mapeamento_Resumo_cd.DataBindings.Add("Text", dtgDespesaResumo.DataSource, "centrodr_resumo_cd");
            lbl_Mapeamento_Descricao.DataBindings.Clear();
            lbl_Mapeamento_Descricao.DataBindings.Add("Text", dtgDespesaResumo.DataSource, "centrodr_resumo_descricao");
            dtgcentrodr_lancamento_by_tipo.DataSource = BLL.ConsultaDemonstrativoResultado_PorTIPO(_VCENTRODR_TIPO_CD, _VCENTRODR_RESUMO_TIPO_CD);
        }
      
        private void _databinding_CentroDr_SubrGrupo()
        {
            try
            {
                cmbdr_subgrupo.DataSource = BLL.Consultar_Centrodr_SubGrupo();
                cmbdr_subgrupo.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DG_CellFormatting(object sender, System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            if (((DataGridView)sender).Name == "dtgcentrodr_fechamento")
            {

                if (((DataGridView)sender).Columns[e.ColumnIndex].DataPropertyName.Equals("cdr_fechamento_linha_resumo"))
                {
                    if (Convert.ToInt32(e.Value) ==  1)
                    {
                        dtgcentrodr_fechamento.Rows[e.RowIndex].Cells[0].Style.BackColor = Color.SlateGray;
                        dtgcentrodr_fechamento.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.SlateGray;
                        dtgcentrodr_fechamento.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.SlateGray;
                        dtgcentrodr_fechamento.Rows[e.RowIndex].Cells[3].Style.BackColor = Color.SlateGray;
                        dtgcentrodr_fechamento.Rows[e.RowIndex].Cells[4].Style.BackColor = Color.SlateGray;
                        dtgcentrodr_fechamento.Rows[e.RowIndex].Cells[1].Style.ForeColor = Color.White;
                        dtgcentrodr_fechamento.Rows[e.RowIndex].Cells[2].Style.ForeColor = Color.White;
                        dtgcentrodr_fechamento.Rows[e.RowIndex].Cells[3].Style.ForeColor = Color.White;
                        dtgcentrodr_fechamento.Rows[e.RowIndex].Cells[4].Style.ForeColor = Color.White;
                        
                        

                        //e.CellStyle.BackColor = Color.Red;
                    }
                }
            }
        }
        private void DG_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
 
        }
        private void DG_SelectionChanged(object sender, EventArgs e)
        {
          
        }
        private void DG_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
 
        }
        private void cmdAtualiza_Click(object sender, EventArgs e)
        {
            try
            {
                _Screen_wait(cmdAtualiza, true);
                _pesquisar();
                _Screen_wait(cmdAtualiza, false);
            }
            catch (Exception ex)
            {
                _Screen_wait(cmdAtualiza, false);
                MessageBox.Show(ex.Message);
            }
        }
        private void cmdsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

   


       

    }
}



					