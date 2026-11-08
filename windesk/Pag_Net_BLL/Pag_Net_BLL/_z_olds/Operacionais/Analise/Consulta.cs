using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models;


namespace Pag_Net.Bll.Operacionais.Analise
{
    public class Consulta
    {

        public Pag_Net.Bll.Cadastros.Gerais Cadastros;
        public Pag_Net.Bll.Operacionais.Analise.UspOperacionalAnaliseFaturamento Faturamento;
        public Pag_Net.Bll.Operacionais.Analise.UspOperacionalAnaliaseRegistroProduto RegistroProduto;
        public Consulta(Models.modelSistemaUsuario _myConnect)
        {
            Cadastros = new Cadastros.Gerais(_myConnect);
            
            Faturamento = new UspOperacionalAnaliseFaturamento(_myConnect);
            RegistroProduto = new UspOperacionalAnaliaseRegistroProduto(_myConnect);
            
        }
        public void Select()
        {

        }

    }
}
