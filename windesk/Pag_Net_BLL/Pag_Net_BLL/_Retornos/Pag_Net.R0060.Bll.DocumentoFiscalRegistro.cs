using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;


namespace Pag_Net.Bll.R0060
{
    public static class Select  
    {
        public static DataTable _0001_DocumentoFiscalRegistro(
                  Pag_Net.Models.modelSistemaUsuario MyConnect
                , int           _DocumentoFiscalProcessado
                , int           _DocumentoFiscalRecebido
                , int           _StatusNfManifestacao 
                , DateTime      _Data_Inicial_Registro
                , DateTime      _Data_Final_Registro
            
            )

        {

            try
            {
                ///select * from r0020_0001_produto(0,0,true, '2021-01-01', '2021-01-31', '','','0','0'  );
                string SQL_POSTGRE = string.Format("select * from r0060_0001_DocumentoFiscalRegistro({0}, {1}, {2}, '{3}', '{4}')",
                                                            _DocumentoFiscalProcessado
                                                       ,     _DocumentoFiscalRecebido
                                                       ,     _StatusNfManifestacao 
                                                       ,     _Data_Inicial_Registro.ToString("yyyy-MM-dd")
                                                       , _Data_Final_Registro.ToString("yyyy-MM-dd")
                                                      );

                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, DataBaseName.ODBCOXAN, SQL_POSTGRE, "");
                return DX.Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
  
        }
      
    }
}



