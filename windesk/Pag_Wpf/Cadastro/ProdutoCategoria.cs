using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pag_Net.Bll;
using Pag_Net.Models;

namespace Pag_Wpf.Cadastro
{
    public partial class ProdutoCategoria : Form
    {
        private Pag_Net.Bll.Cadastros.Produto _BLL;
        private int SeqProdutoCategoria;
        public ProdutoCategoria(modelSistemaUsuario __myConnect, Pag_Net.Bll.Cadastros.VWProdutoCategoria __vWCategoriaSelecionada)
        {
            InitializeComponent();
            _BLL = new Pag_Net.Bll.Cadastros.Produto(__myConnect);
            SeqProdutoCategoria = __vWCategoriaSelecionada.SeqProdutoCategoria;
            LBLSeqProdutoCategoria.Text = SeqProdutoCategoria.ToString("000000");

            if (SeqProdutoCategoria != 0)
            {
                _BLL.Categoria.Parametros.SeqProdutoCategoria = SeqProdutoCategoria;
                _BLL.Categoria.Select();
                TXTDescricao.Text = __vWCategoriaSelecionada.Descricao.ToString();
                if (((Pag_Net.Bll.Cadastros.VWProdutoCategoria)_BLL.Categoria.ViewData[0]).StatusProdutoCategoria == true)
                {
                    CHKStatusProdutoCategoria.Checked = true;
                }
                else
                {
                    CHKStatusProdutoCategoria.Checked = false;
                }

            }

        }

        private void CMDEfetiva_Click(object sender, EventArgs e)
        {
            _BLL.Categoria.Parametros.Descricao = TXTDescricao.Text;
            if (CHKStatusProdutoCategoria.Checked)
            {
                _BLL.Categoria.Parametros.StatusProdutoCategoria = true;
            }
            else
            {
                _BLL.Categoria.Parametros.StatusProdutoCategoria = false;
            }

            if (SeqProdutoCategoria == 0)
            {

                _BLL.Categoria.Insert();
            }
            else
            {
                _BLL.Categoria.Update();
            }

            MessageBox.Show("Atualização realizada com sucesso!");
            this.Close();
        
            
        }

        private void CMDCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
