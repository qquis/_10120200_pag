using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;


namespace Pag_Net.Bll.R0020
{
    public static class Select  
    {
        public static DataTable _0001_Produto(Pag_Net.Models.modelSistemaUsuario MyConnect, F0020_Produto.Defaut_Filter _Filters)
        {

            try
            {
                ///select * from r0020_0001_produto(0,0,true, '2021-01-01', '2021-01-31', '','','0','0'  );
                string SQL_POSTGRE = string.Format("select * from r0020_01_1011858_produto({0} , {1} ,'{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}' )",
                                                      _Filters.CdProduto.ToString(),
                                                      _Filters.CdProdutoBluesoft.ToString(),
                                                      _Filters.Seleciona_Data_Cadastro.ToString(),
                                                      _Filters.Dt_cadastro_ini.ToString("yyyy-MM-dd"),
                                                      _Filters.Dt_cadastro_fim.ToString("yyyy-MM-dd"),
                                                      _Filters.Descricao,
                                                      _Filters.Descricao_Fiscal,
                                                      _Filters.Status_Ativo.ToString(),
                                                      _Filters.Status_Inativo.ToString(),
                                                      _Filters.Codigo_de_Barra.ToString()
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
        public static DataTable _0002_Produto_Embalagem(Pag_Net.Models.modelSistemaUsuario MyConnect, F0020_Produto.Defaut_Filter _Filters)
        {

            try
            {
                string SQL_POSTGRE = string.Format("select * from r0020_02_1011846_produto_embalagem({0} , {1})",
                                                      _Filters.CdProduto.ToString(),
                                                      _Filters.CdProdutoBluesoft.ToString()
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
        public static DataTable _0002_Produto_Embalagem_Gtins(Pag_Net.Models.modelSistemaUsuario MyConnect, F0020_Produto.Defaut_Filter _Filters)
        {
            try
            {
                string SQL_POSTGRE = string.Format("select * from r0020_0003_produto_embalagem_cdbarra({0} , {1})",
                                                      _Filters.CdProduto.ToString(),
                                                      _Filters.CdProdutoBluesoft.ToString()
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


