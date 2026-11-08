using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.Comercial.Interface
{
    public static class UspInterfaceInfoArquivoGerar
    {
        public static void Gerar(Pag_Net.Bll.Comercial.Interface.UVWInterfaceInfoArquivo[] __arquivo)
        {
            string Arquivo = @__arquivo[0].PathArquivo + @"\" + __arquivo[0].NomeArquivo.ToString().Trim();
            ArrayList Linhas = new ArrayList();

            foreach(UVWInterfaceInfoArquivo item in __arquivo)
            {
                Linhas.Add(item.Linha);
            }

            
            if (__arquivo[0].SeqInterfaceInfo == 1)
            {
                Pag_Net.Tools.LogFile.Write(@Arquivo,"ARQUIVO",Linhas, System.IO.FileMode.Create, System.IO.FileAccess.Write,Encoding.UTF8);
            }

            if (__arquivo[0].SeqInterfaceInfo == 2)
            {
                Pag_Net.Tools.LogFile.Write(@Arquivo, "ARQUIVO", Linhas, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            }
            if (__arquivo[0].SeqInterfaceInfo == 5)
            {
                Pag_Net.Tools.LogFile.Write(@Arquivo, "ARQUIVO", Linhas, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            }

        }
    }
}
