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
    public partial class frm_Recebimento_Comando_Pgto : Form
    {
        int _CONTROLE_REG_SEQ = 0; 
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.Bll.Controle.tbcontrole_reg_pgto _TBCONTROLE_REG_PGTO;
        public frm_Recebimento_Comando_Pgto(Pag_Net.Models.modelSistemaUsuario _myConnect, int _controle_reg_seq)
        {
            InitializeComponent();
            MyConnect = _myConnect;
            _CONTROLE_REG_SEQ = _controle_reg_seq;
            _Screen_load();
        }

        private void _Screen_load()
        {
            cmdsair.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda.ico");
            txtcontrole_reg_numero_pallet.LostFocus += new EventHandler(_lostfocus);
            

            DataTable Dt =  Pag_Net.Bll.Controle.Pool.Controle_etapa_atual_list(MyConnect, 0, 0, 0, _CONTROLE_REG_SEQ, 0, Convert.ToDateTime("1900-01-01"));

            _TBCONTROLE_REG_PGTO = Pag_Net.Bll.Controle.Pool.Controle_Pgto_Registrar(MyConnect, new Pag_Net.Bll.Controle.tbcontrole_reg_pgto(
                            _CONTROLE_REG_SEQ,
                            0,
                            Convert.ToInt32(Dt.Rows[0]["controle_reg_numero_pallet"].ToString()),
                            0,
                            0,
                            0,
                            0,
                            0
                ));



            lbl_controle_etapa_cd.Text = Dt.Rows[0]["controle_etapa_cd"].ToString();
            lbl_controle_etapa_descricao.Text = Dt.Rows[0]["controle_etapa_descricao"].ToString();
            lblFILA_DESCRICAO.Text = Dt.Rows[0]["controle_fila_descricao"].ToString();



            if (_TBCONTROLE_REG_PGTO.controle_reg_numero_pallet == 0)
            {
                lbl_controle_reg_numero.Text = Dt.Rows[0]["controle_reg_numero"].ToString();
            }
            else
            {
                lbl_controle_reg_numero.Text = _TBCONTROLE_REG_PGTO.controle_reg_numero_pallet.ToString();
            }



            lbl_controle_reg_seq.Text = Dt.Rows[0]["controle_reg_seq"].ToString();
            lbl_vcontrole_reg_fila_seq.Text = Dt.Rows[0]["controle_reg_fila_seq"].ToString();
            lbl_controle_etapa_cd.Text = Dt.Rows[0]["controle_etapa_cd"].ToString(); 


            txtControle_Reg_Transportadora_CNPJ.Text = Dt.Rows[0]["controle_reg_transportadora_cnpj"].ToString();
            txtControle_Reg_Transportadora_RazaoSocial.Text = Dt.Rows[0]["controle_reg_transportadora_razao_social"].ToString();
            txtcontrole_reg_numero_pallet_vl_total.Text = _TBCONTROLE_REG_PGTO.controle_reg_numero_pallet_vl_total.ToString("0.00");
            txtcontrole_reg_numero_pallet_vl_unit.Text = _TBCONTROLE_REG_PGTO.controle_reg_numero_pallet_vl_unit.ToString("0.00");
            txtcontrole_reg_numero_pallet.Text = _TBCONTROLE_REG_PGTO.controle_reg_numero_pallet.ToString();

            
        }

        private void _lostfocus(object sender, EventArgs e)
        {
            if (txtcontrole_reg_numero_pallet.Text.Trim() == "") txtcontrole_reg_numero_pallet.Text = "0";
            if (txtcontrole_reg_numero_pallet_vl_unit.Text.Trim() == "") txtcontrole_reg_numero_pallet_vl_unit.Text = "0";
            int _NUMERO_DE_PALLET = Convert.ToInt32(txtcontrole_reg_numero_pallet.Text);

            if ( Convert.ToDouble(txtcontrole_reg_numero_pallet_vl_unit.Text) > 0)
            {
                txtcontrole_reg_numero_pallet_vl_total.Text = (Convert.ToDouble(txtcontrole_reg_numero_pallet_vl_unit.Text) * _NUMERO_DE_PALLET).ToString("0.00"); 
            }
        }

        private void cmdefetivar_pgto_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcontrole_reg_numero_pallet.Text.Trim() == "") txtcontrole_reg_numero_pallet.Text = "0";
                if (txtcontrole_reg_numero_pallet_vl_recebido.Text.Trim() == "") txtcontrole_reg_numero_pallet_vl_recebido.Text = "0";
                int _NUMERO_DE_PALLET = Convert.ToInt32(txtcontrole_reg_numero_pallet.Text);
                _TBCONTROLE_REG_PGTO.controle_reg_numero_pallet = _NUMERO_DE_PALLET;
                _TBCONTROLE_REG_PGTO.controle_reg_numero_pallet_vl_recebido = Convert.ToDouble(txtcontrole_reg_numero_pallet_vl_recebido.Text);


                if (Convert.ToDouble(txtcontrole_reg_numero_pallet_vl_recebido.Text) < Convert.ToDouble(txtcontrole_reg_numero_pallet_vl_total.Text))
                {
                    MessageBox.Show("Valor recebido menor do que o total a receber, favor conferir!");
                    return;
                }

                Pag_Net.Bll.Controle.Pool.Controle_Pgto_Registrar(MyConnect, _TBCONTROLE_REG_PGTO);

                MessageBox.Show("Pagamento registrado com sucesso!");
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
