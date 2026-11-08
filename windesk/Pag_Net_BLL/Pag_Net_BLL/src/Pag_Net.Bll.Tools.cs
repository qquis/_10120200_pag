using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.Tools
{
    public static class ImportTXT
    {
        public static int get(Pag_Net.Models.modelSistemaUsuario MyConnect, string FilePathName)
        {
            string linhaRead;
            linhaRead = "";
            if (File.Exists(FilePathName))
            {

                Pag_Net.Tools.ManagerFileInfo Arquivo = new Pag_Net.Tools.ManagerFileInfo();
                Pag_Net.Tools.ManagerFile _ManagerFile = new Pag_Net.Tools.ManagerFile();

                System.IO.FileInfo _OpenFILE = new FileInfo(FilePathName);
                _OpenFILE.Open(FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
                Arquivo = _ManagerFile.FileOut(_OpenFILE);

                int SEQNOVOARQUIVO = Pag_Net.Bll.F001001.Postgres.getKey(MyConnect,DateTime.Now,FilePathName);

                int i = 0;
                string[] linhas = Pag_Net.Tools.LogFile.ReadLine(Arquivo.FileName);
                int time = 0; 

                for (i = 0; i < linhas.Count() -1; i++)
                {
                    linhaRead = linhas[i].ToString();
                    Pag_Net.Bll.F001002.Postgres.CRUD(MyConnect, SEQNOVOARQUIVO, i, linhaRead);
                    time = time + 1;
                    if (time > 15)
                    {
                        System.Threading.Thread.Sleep(2000);
                        time = 0;

                    }
                }



                /*Postgre INSERT 
                DbUpdate BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                BDExecute.Begin(DataBaseName.ODBCOXAN);
                int x = 1;
                int seq = 0;
                int count = List.Count();
                foreach (Models.Db item in List)
                {
                    if (x == 0)
                    {
                        BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                    }

                    ErroInfo = "ID: " + item.df_nf_seq_blue.ToString();
                    BDExecute.Execute(Pag_Net.F0061.Bll.Postgres.StringCRUD(item), null, DataBaseName.ODBCOXAN);

                    x = x + 1;
                    seq = seq + 1;

                    if (x > 10000)
                    {
                        x = 0;
                        BDExecute.Close(DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(2000);
                    }

                    if (seq >= count)
                    {
                        x = -1;
                        BDExecute.Close(DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(1000);
                    }
                }*/
                //BDExecute.Commit(DataBaseName.ODBCOXAN);

                return SEQNOVOARQUIVO;
            }
            else
            {
                throw new Exception("Erro: Pag_Net.Bll.Tools | Get: File Not Exists [LINHA: " + linhaRead.ToString() + "]");

            }
        }
    }
}
