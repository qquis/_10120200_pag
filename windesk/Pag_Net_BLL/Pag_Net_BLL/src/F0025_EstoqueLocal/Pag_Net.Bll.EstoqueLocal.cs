using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0025_EstoqueLocal;

namespace Pag_Net.Bll.F0025_EstoqueLocal
{
    public class WK
    {
        public Pag_Net.Models.modelSistemaUsuario MyConnect;
        public WK (Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
        }
        public void EstoqueLocal_Mov_Registrar(int pr_cdproduto, string pr_EmbalagemEstoque, double estlocal_mov_embalagemestoque_qtde)
        {
            try
            {
                tbestoquelocal_mov Item = new tbestoquelocal_mov();
                Item.pr_cdproduto = pr_cdproduto;
                Item.pr_embalagemestoque = pr_EmbalagemEstoque;
                Item.estlocal_mov_embalagemestoque_qtde = estlocal_mov_embalagemestoque_qtde;
                Item = new tbestoquelocal_mov(BDCommand.get_DataTable(MyConnect, F0025_05_EstoqueLocal_Mov_CRUD.Post(MyConnect, Item)).Rows[0]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
