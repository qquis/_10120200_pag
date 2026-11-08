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
    public partial class frm_Recebimento_Comando_DocumentosFiscais : Form
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;

        Pag_Net.Bll.DocumentoFiscalRegistro.Pool BLL;
        //Pag_Net.Bll.DocumentoFiscalRegistro.TbDocumentoFiscalRegistro DocumentoFiscal_Inicial;


        // Pag_Net.Bll.Controle.tbcontrole _CONTROLE;
        int _CONTROLE_REG_SEQ = 0;


        Pag_Form.user_control.frmUC_DocumentoFiscalRegistro frmUC_DocumentoFiscalRegistro;

        public frm_Recebimento_Comando_DocumentosFiscais(Pag_Net.Models.modelSistemaUsuario _myConnect, int __CONTROLE_REG_SEQ, int __CONTROLE_NUMERO)
        {

            InitializeComponent();

            MyConnect = _myConnect;
            /*USER CONTROL*/
            frmUC_DocumentoFiscalRegistro = new Pag_Form.user_control.frmUC_DocumentoFiscalRegistro(MyConnect, false, false);

            _CONTROLE_REG_SEQ = __CONTROLE_REG_SEQ;
            BLL = new Pag_Net.Bll.DocumentoFiscalRegistro.Pool(MyConnect);

            _Screen_load();
            lbl_controle_reg_numero.Text = __CONTROLE_NUMERO.ToString();
        }

        private void _Screen_load()
        {
            cmdsair.Image = Image.FromFile(Pag_Net.Models.PagInfo.GetPathIco + @"\esquerda.ico");
            /*USER CONTROL*/
            frmUC_DocumentoFiscalRegistro.BackColor = System.Drawing.Color.LightSteelBlue;
            frmUC_DocumentoFiscalRegistro.Location = new System.Drawing.Point(1, 1);
            frmUC_DocumentoFiscalRegistro.Name = "frmUC_DocumentoFiscalRegistro";
            frmUC_DocumentoFiscalRegistro.Size = new System.Drawing.Size(782, 373);
            frmUC_DocumentoFiscalRegistro.TabIndex = 0;
            tabRecebimento.Controls.Add(frmUC_DocumentoFiscalRegistro);
            frmUC_DocumentoFiscalRegistro.EventHanlder_Incluir_Nota_Fiscal_No_Grid += new EventHandler(_Consulta_Numero_Notas_Fiscais);
            frmUC_DocumentoFiscalRegistro.EventHandler_Confirma_Lista += new EventHandler(_Efetiva_Lista);
            frmUC_DocumentoFiscalRegistro.__CONTROLE_REG_SEQ = _CONTROLE_REG_SEQ;
            frmUC_DocumentoFiscalRegistro.__CONTROLE_ETAPA_CD = 6;


        }

        private void _Consulta_Numero_Notas_Fiscais(object sender, EventArgs e)
        {
            lblnf_registrada_reg.Text = frmUC_DocumentoFiscalRegistro.WKDocumentoFiscal.ListaDeDocumentosFiscais.Count().ToString();
        }

        private void _Efetiva_Lista(object sender, EventArgs e)
        {
            MessageBox.Show("LISTA EFETIVADA");
        }

        private void cmdEfetivar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                frmUC_DocumentoFiscalRegistro.Efetivar();
                this.Cursor = Cursors.Arrow;
                MessageBox.Show("Lista efetivada com sucesso");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
