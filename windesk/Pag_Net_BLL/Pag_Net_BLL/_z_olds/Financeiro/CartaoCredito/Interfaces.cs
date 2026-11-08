using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models;

namespace Pag_Net.Bll.Financeiro.CartaoCredito
{
    public class Interfaces
    {
        private int _SeqArquivoSelecionado;
        public int SeqArquivoSelecionado
        {
            get
            {
                return _SeqArquivoSelecionado;
            }
            set
            {
                if (value != null)
                {
                    _SeqArquivoSelecionado = value;

                }
            }
        }
        public UspFCCInterfacesImportadasArquivos Arquivos { get; set; }
        public UspFCCInterfacesImportadasLancamentos Lancamentos { get; set; }
        public UspFCCInterfacesImportadasRO ResumoInterface { get; set; }
        public Interfaces(modelSistemaUsuario _myConnect)
        {
            Arquivos = new UspFCCInterfacesImportadasArquivos(_myConnect);
            Lancamentos = new UspFCCInterfacesImportadasLancamentos(_myConnect);
            ResumoInterface = new UspFCCInterfacesImportadasRO(_myConnect);
            
        }
        public void Select()
        {
            if (SeqArquivoSelecionado != 0)
            {
                Lancamentos.Filtros.SeqArquivo = SeqArquivoSelecionado;
                ResumoInterface.Filtros.SeqArquivo = SeqArquivoSelecionado;
                Lancamentos.Select();
                ResumoInterface.Select();
            }
            else
            {
                throw new Exception("Informe o Sequencial do Arquivo");
            }
        }

    }

}
