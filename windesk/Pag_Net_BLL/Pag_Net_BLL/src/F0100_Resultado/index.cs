using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pag_Net.src.F0100_Resultado;
using Pag_Net.src.F0100_Resultado.tbs;
using Pag_Net.Bll;

namespace Pag_Net.src.F0100_Resultado
{
    public class WK
    {
        public _indexReport REPORT;
        Pag_Net.Models.modelSistemaUsuario MyConnect;

        string sqlVinculo = "";

        public WK(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
            REPORT = new _indexReport(MyConnect);
        }
        public void Vinculo_ContaPag_ContaBlue_Add(int contrato_bluesoft_seq, int plc_conta_cd, int cdparticipante, tbs.tbresultado_conta contaPag)
        {
            try
            {
                string sql = " DELETE FROM tbresultado_conta_origem " +
                             " WHERE plc_conta_cd = " + plc_conta_cd.ToString() +
                             " AND contrato_bluesoft_seq = " + contrato_bluesoft_seq.ToString() +
                             " AND r_conta_origem_tipo_cd = 15 " +
                             " AND cdparticipante = " + cdparticipante.ToString() +
                             " AND r_conta_cd != " + contaPag.r_conta_cd.ToString() + ";" + 


                             " INSERT INTO tbresultado_conta_origem (r_conta_origem_tipo_cd, plc_conta_cd, contrato_bluesoft_seq, cdparticipante,  r_conta_cd ) " +
                                   " SELECT 15, " + plc_conta_cd + ", " + contrato_bluesoft_seq.ToString() + ","  + cdparticipante.ToString() + "," + contaPag.r_conta_cd + 
                                   " WHERE not exists (select 1 from tbresultado_conta_origem " + 
                                                       " where plc_conta_cd = " +  plc_conta_cd.ToString() +
                                                       "  and  r_conta_Cd = " + contaPag.r_conta_cd.ToString() + 
                                                       "  and  cdparticipante = " + cdparticipante.ToString() + 
                                                       "  and  contrato_bluesoft_seq = " + contrato_bluesoft_seq.ToString() + 
                                                       "  and  r_conta_origem_tipo_cd = 15 " + 
                                                       "); ";
                //BDCommand.Execute(MyConnect, sql);                                                               
                sqlVinculo += sql;
                                    
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Vinculo_ContaPag_ContaBlue_Processar()
        {
            try
            {
                BDCommand.Execute(MyConnect, sqlVinculo);
                sqlVinculo = "";

            }
            catch (Exception ex)
            {
                sqlVinculo = "";
                throw new Exception(ex.Message);
            }
        }

        public void Vinculo_ContaPag_ContaBlue_Cancelar() { sqlVinculo = ""; }
    }

    public static class Select
    {
        public static Pag_Net.src.F0100_Resultado.tbs.TbCompetencia[] Competencia_Collection_Get(Pag_Net.Models.modelSistemaUsuario Myconnect, int ano)
        {
            try
            {
                List<Pag_Net.src.F0100_Resultado.tbs.TbCompetencia> _LIST = new List<TbCompetencia>();
                _LIST.Add(new TbCompetencia());
                foreach(DataRow i in Competencia_DataTable_Get(Myconnect, ano).Rows  )
                {
                    _LIST.Add(new TbCompetencia(i));
                }
                return _LIST.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Competencia_DataTable_Get(Pag_Net.Models.modelSistemaUsuario Myconnect, int ano)
        {
            try
            {

                return BDCommand.get_DataTable(Myconnect, Pag_Net.src.F0100_Resultado.scripts.F0100_50_competencia_list.Get(ano));
            }
            
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


    }
}
