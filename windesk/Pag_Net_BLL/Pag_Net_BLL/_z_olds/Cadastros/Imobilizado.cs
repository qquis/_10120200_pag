using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.Cadastros
{
    
    public class Imobilizado
    {
        private Models.modelSistemaUsuario MyConnect;
        public USPEmpresa Empresa;
        public UspAtivoImobilizado Ativos;
        public UspAtivoImobilizadoInformacao Informacao;

        public Imobilizado( Models.modelSistemaUsuario __myConnect )
        {
            MyConnect = __myConnect;
            Empresa = new USPEmpresa(MyConnect);
            Ativos = new UspAtivoImobilizado(MyConnect);
            Informacao = new UspAtivoImobilizadoInformacao(MyConnect);
        }

        public UVWAtivoImobilizado[] Componentes(int __seqAtivoImobilizado)
        {
            UspAtivoImobilizado AtivosItem = new UspAtivoImobilizado(MyConnect);
            AtivosItem.Parametros.SeqAtivoComponente = __seqAtivoImobilizado;
            AtivosItem.Parametros.SelecionaTipoComponentes = true;
            AtivosItem.Select();
            return (UVWAtivoImobilizado[])AtivosItem.ViewData;

        }
    }
}
