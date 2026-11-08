using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pag_Net.Models;
using Pag_Net.Bll.Comercial.PedidoCompra;
namespace Pag_Wpf.Comercial.Compras
{
    public partial class frmPedidoCompraEmail : Form
    {
        //string FormularioMenu = "m2411";
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        Pag_Net.Bll.Comercial.PedidoCompra.UVWComercialPedidoCompra PedidoCompraSelecionado;

        public frmPedidoCompraEmail(modelSistemaUsuario __myConnect, UVWComercialPedidoCompra __pedidoCompraSelecionado)
        {
            try
            {
                InitializeComponent();
                MyConnect = __myConnect;
                if (__pedidoCompraSelecionado == null )
                {
                    throw new Exception("Pedido de Compra não informado");

                }
                PedidoCompraSelecionado = __pedidoCompraSelecionado;
                TXTFornecedor.Text = PedidoCompraSelecionado.NomeParticipante;
                TXTPedidoCompra.Text = PedidoCompraSelecionado.NumeroPedido.ToString();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CMDEfetiva_Click(object sender, EventArgs e)
        {
            try
            {
                if (TXTemail.Text.Trim() == "")
                {
                    MessageBox.Show("Informe um e-mail");
                    return;
                }
                Pag_Net.Bll.Comercial.PedidoCompra.UspComercialPedidoCompraEmail.Enviar(MyConnect, PedidoCompraSelecionado.NumeroPedido, TXTemail.Text.ToString());
                MessageBox.Show("E-mail enviado");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CMDCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
