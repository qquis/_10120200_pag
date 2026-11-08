using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0035_Ativo
{
    public class TbAtivoProduto
    {

        public int       at_produto_seq                     {get ; set ;}
        public int       prb_cdprodutobluesoft                      {get ; set ;}

        public TbAtivoProduto()
        {
            try
            {
                TbAtivoProduto_Binding();
            }
            catch( Exception ex )
            {
                throw new Exception(ex.Message);
            }
        }

        public void TbAtivoProduto_Binding()
        {
            try
            {
                at_produto_seq = 0;
                prb_cdprodutobluesoft = 0;
  
            }
            catch( Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public void TbAtivoProduto_DataBinding(DataRow row, DataColumnCollection colArr)
        {
            try
            {


                if (!row.HasErrors)
                {

                    for (int i = 0; i < colArr.Count; i++)
                    {

                        if (colArr[i].ColumnName == "at_produto_seq") at_produto_seq = Convert.ToInt32(row["at_produto_seq"].ToString());
                        if (colArr[i].ColumnName == "prb_cdprodutobluesoft") at_produto_seq = Convert.ToInt32(row["prb_cdprodutobluesoft"].ToString());
                    }
                }
            }


            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


    }
    }
