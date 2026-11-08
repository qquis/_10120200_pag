using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0035_Ativo
{
    public class TbAtivoBlueSoft
    {

        public int at_bluesoft_patrimonio_item { get; set; }
        public int prb_cdprodutobluesoft { get; set; }
        public string at_bluesoft_descricao { get; set; }
        public string at_bluesoft_descricao_funcao_item { get; set; }
        public string at_bluesoft_chapa_key { get; set; }
        public string at_bluesoft_categoria { get; set; }
        public string at_bluesoft_grupo { get; set; }
        public string at_bluesoft_subgrupo { get; set; }
        public double at_bluesoft_valoraquisicao { get; set; }
        public double at_bluesoft_valor { get; set; }
        public int df_nf_seq_blue { get; set; }


        public TbAtivoBlueSoft()
        {
            try
            {
                TbAtivoBlueSoft_Binding();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void TbAtivoBlueSoft_Binding()
        {
            try
            {

                at_bluesoft_patrimonio_item = 0;
                prb_cdprodutobluesoft = 0;
                at_bluesoft_descricao = "";
                at_bluesoft_descricao_funcao_item = "";
                at_bluesoft_chapa_key = "";
                at_bluesoft_categoria = "";
                at_bluesoft_grupo = "";
                at_bluesoft_subgrupo = "";
                at_bluesoft_valoraquisicao = 0;
                at_bluesoft_valor = 0;
                df_nf_seq_blue = 0;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public void TbAtivoBlueSoft_DataBinding(DataRow row, DataColumnCollection colArr)
        {
            try
            {
                if (!row.HasErrors)
                {

                    for (int i = 0; i < colArr.Count; i++)
                    {
                        if (colArr[i].ColumnName == "at_bluesoft_patrimonio_item") at_bluesoft_patrimonio_item = Convert.ToInt32(row["at_bluesoft_patrimonio_item"].ToString());
                        if (colArr[i].ColumnName == "prb_cdprodutobluesoft") prb_cdprodutobluesoft = Convert.ToInt32(row["prb_cdprodutobluesoft"].ToString());
                        if (colArr[i].ColumnName == "at_bluesoft_descricao") at_bluesoft_descricao = row["at_bluesoft_descricao"].ToString();
                        if (colArr[i].ColumnName == "at_bluesoft_descricao_funcao_item") at_bluesoft_descricao = row["at_bluesoft_descricao_funcao_item"].ToString();
                        if (colArr[i].ColumnName == "at_bluesoft_chapa_key") at_bluesoft_chapa_key = row["at_bluesoft_chapa_key"].ToString();
                        if (colArr[i].ColumnName == "at_bluesoft_categoria") at_bluesoft_categoria = row["at_bluesoft_categoria"].ToString();
                        if (colArr[i].ColumnName == "at_bluesoft_grupo") at_bluesoft_grupo = row["at_bluesoft_grupo"].ToString();
                        if (colArr[i].ColumnName == "at_bluesoft_subgrupo") at_bluesoft_subgrupo = row["at_bluesoft_subgrupo"].ToString();
                        if (colArr[i].ColumnName == "at_bluesoft_valoraquisicao") at_bluesoft_valoraquisicao = Convert.ToDouble(row["at_bluesoft_valoraquisicao"].ToString());
                        if (colArr[i].ColumnName == "at_bluesoft_valor") at_bluesoft_valor = Convert.ToDouble(row["at_bluesoft_valor"].ToString());
                        if (colArr[i].ColumnName == "df_nf_seq_blue") df_nf_seq_blue = Convert.ToInt32(row["df_nf_seq_blue"].ToString());
                    }
                }
            }


            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void DBInsert(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                BDCommand.Execute(MyConnect, CRUD(BDCommandTypes.DBINSERT));
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string CRUD(BDCommandTypes BDCommnadType)
        {
            try
            {
                string SQL_CRUD = "SELECT " + f0035_15_AtivoBlueSoft_crud._VERSION() +
                            "( sqlcommand:= '" + BDCommnadType.ToString() + "'," +
                            " , vat_bluesoft_patrimonio_item:= " + this.at_bluesoft_patrimonio_item.ToString() + "," +
                            " , vprb_cdprodutobluesoft:= " + this.prb_cdprodutobluesoft.ToString() + "," +
                            " , vat_bluesoft_descricao:= '" + this.at_bluesoft_descricao.ToString() + "'," +
                            " , vat_bluesoft_descricao_funcao_item:= '" + this.at_bluesoft_descricao_funcao_item.ToString() + "'," +
                            " , vat_bluesoft_chapa_key:= '" + this.at_bluesoft_chapa_key.ToString() + "'," +
                            " , vat_bluesoft_categoria:= '" + this.at_bluesoft_categoria.ToString() + "'," +
                            " , vat_bluesoft_grupo:= '" + this.at_bluesoft_grupo.ToString() + "'," +
                            " , vat_bluesoft_subgrupo:= '" + this.at_bluesoft_subgrupo.ToString() + "'," +
                            " , vat_bluesoft_valoraquisicao:= " + this.at_bluesoft_valoraquisicao.ToString("0.00").Replace(".",",") + "," +
                            " , vat_bluesoft_valor:= " + this.at_bluesoft_valor.ToString("0.00").Replace(".", ",") + "," +
                            " , vdf_nf_seq_blue:= " + this.df_nf_seq_blue.ToString() + "," +
                            " , vcommand_api:= 'false'"  						
                            ;
                return SQL_CRUD;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        
        }
      
    }

}

  



    
