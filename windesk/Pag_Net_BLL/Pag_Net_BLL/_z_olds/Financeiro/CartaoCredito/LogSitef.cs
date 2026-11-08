using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Bll.Financeiro.CartaoCredito;

namespace Pag_Net.Bll.Financeiro.CartaoCredito
{
    public class LogSitef
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
        public LogSitefImportacaoArquivo Importar;
        public SitefLogArquivos ArquivosImportados;
        public SitefLogArquivosRegistros Registros;

        public LogSitef(Models.modelSistemaUsuario _myConnect)
        {
            Importar = new LogSitefImportacaoArquivo(_myConnect);
            ArquivosImportados = new SitefLogArquivos(_myConnect);
            Registros = new SitefLogArquivosRegistros(_myConnect);
        }

    }
}
