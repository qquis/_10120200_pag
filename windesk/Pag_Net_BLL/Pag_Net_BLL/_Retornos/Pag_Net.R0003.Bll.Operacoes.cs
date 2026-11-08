using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;


namespace Pag_Net.Bll.R0003
{
    public static class Select  
    {
        public static DataTable _0001_Operacoes(
                  Pag_Net.Models.modelSistemaUsuario MyConnect
                , int em_empresa
            
            )

        {

            try
            {
                ///select * from r0020_0001_produto(0,0,true, '2021-01-01', '2021-01-31', '','','0','0'  );
                string SQL_POSTGRE = string.Format("select * from r0003_0001_Operacoes({0})",
                                                      em_empresa 
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

namespace Pag_Net.R0003.Models
{
    public class r0003_Operacoes
    {
        public int op_cdoperacao { get; set; }
        public string op_descricao { get; set; }

        public r0003_Operacoes() { }

        public r0003_Operacoes(
                 int _op_cdoperacao
             , string _op_descricao
           
            )
        {
            op_cdoperacao = _op_cdoperacao;
            op_descricao = _op_descricao;
        }

        public r0003_Operacoes(DataRow i)
        {
            op_cdoperacao = Convert.ToInt32(i["op_cdoperacao"]);

            op_descricao = i["op_descricao"].ToString();
        }

    }

}



