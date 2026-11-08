using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models;

namespace Pag_Net.Bll.Comercial.Interface
{
    public class CollectionClass
    {
        public UspInterfaceInfo Cadastro;
        public UspInterfaceEstoqueInfoItemPosicao Estoque;
        public UspInterfaceEstoqueInfoItem EstoqueDetalhes;
        public UspInterfaceFaturamentoInfoArquivos FaturamentoArquivos;
        public UspInterfaceFaturamentoInfo FaturamentoItens;
        public UspInterfaceInfoArquivo Arquivos;
        

        
        public CollectionClass(modelSistemaUsuario __myConnect)
        {
            
            Estoque = new UspInterfaceEstoqueInfoItemPosicao(__myConnect);
            EstoqueDetalhes = new UspInterfaceEstoqueInfoItem(__myConnect);
            Cadastro = new UspInterfaceInfo(__myConnect);
            FaturamentoArquivos = new UspInterfaceFaturamentoInfoArquivos(__myConnect);
            FaturamentoItens = new UspInterfaceFaturamentoInfo(__myConnect);
            Arquivos = new UspInterfaceInfoArquivo(__myConnect);
        }

    }
}
