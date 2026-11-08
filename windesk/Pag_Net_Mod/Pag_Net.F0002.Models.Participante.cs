
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using Pag_Net.Models;
//using Pag_Net.F0011_01PC.Models;

namespace Pag_Net.F0002.Models
{
    public class Participante
    {



        public int      cdparticipante                  { get; set; }
        public string   cpf_cnpj                        { get; set; }
        public int      cdpessoabluesoft 			    { get; set; }
        public bool     bluesoftcliente 				{ get; set; }
        public bool     bluesoftvendedor 				{ get; set; }
        public bool     bluesoftfabricante 				{ get; set; }
        public bool     bluesoftfornecedor 				{ get; set; }
	    public int      cdparticipantevendedorbluesoft	{ get; set; }
	    public int      cdparticipantevendedor 			{ get; set; }
        public int      cdgrupoeconomico 				{ get; set; }
        public string   erptargetcdvend 				{ get; set; }
        public int      erptargetcdclien 				{ get; set; }

		public Participante(){}

        public Participante(System.Data.DataRow i)
        {
            string errorString = i[0].ToString();
            try
            {
                cdparticipante = Convert.ToInt32(i["cdparticipante"]);
                cpf_cnpj = i["cpf_cnpj"].ToString();
                cdpessoabluesoft = Convert.ToInt32(i["cdpessoabluesoft"]);
                bluesoftcliente = Convert.ToBoolean(i["bluesoftcliente"]);
                bluesoftvendedor = Convert.ToBoolean(i["bluesoftvendedor"]);
                bluesoftfabricante = Convert.ToBoolean(i["bluesoftfabricante"]);
                bluesoftfornecedor = Convert.ToBoolean(i["bluesoftfornecedor"]);
                cdparticipantevendedorbluesoft = Convert.ToInt32(i["cdparticipantevendedorbluesoft"]);
                cdparticipantevendedor = Convert.ToInt32(i["cdparticipantevendedor"]);
                cdgrupoeconomico = Convert.ToInt32(i["cdgrupoeconomico"]);
                erptargetcdvend = Convert.ToString(i["erptargetcdvend"]);
                erptargetcdclien = Convert.ToInt32(i["erptargetcdclien"]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " | " + errorString);
            }
        }
    }
}

namespace Pag_Net.F0002.Models.BD
{
    public static class SqlServer
    {
        public static string SqlProcedureName()
        {
            return "F0002_02RL_tbparticipante";
        }
        public static ParameterQuey[] sp_F0002_02RL_tbparticipante(Pag_Net.F0002.Models.Participante item, Pag_Net.Models.BDCommandTypes _Type)
        {
            _Type = BDCommandTypes.DBSELECT;
            string LinhaEmExecucao = "";
            try
            {
                List<ParameterQuey> SQLParametros = new List<ParameterQuey>();
                SQLParametros.Add(new ParameterQuey("SQLCommand", SqlDbType.VarChar, false, BDTools.SqlCommandType(_Type)));
                return SQLParametros.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " | " + LinhaEmExecucao);
            }

        }

    }

    public static class Postgres
    {
        public static string fn_SELECT_F0002_01PC_tbparticipante(Participante item, Pag_Net.Models.BDCommandTypes _Type)
        {
            /* Postgresql - function F0002_01PC_tbparticipante */
            return string.Format("SELECT F0002_01PC_tbparticipante ( '{0}',{1},'{2}',{3},'{4}','{5}','{6}','{7}',{8},{9},{10},'{11}',{12})", 
                                BDTools.SqlCommandType(_Type),
                                item.cdparticipante,
                                item.cpf_cnpj,
                                item.cdpessoabluesoft, 
                                item.bluesoftcliente,
                                item.bluesoftvendedor,
                                item.bluesoftfabricante,
                                item.bluesoftfornecedor,
                                item.cdparticipantevendedorbluesoft,
                                item.cdparticipantevendedor,
                                item.cdgrupoeconomico,
                                item.erptargetcdvend,
                                item.erptargetcdclien
                                )
                                
                ;
        }

   }

    public static class RedShift
    {
        public static string Select()
        {
            string SQL = " SELECT " +
            "                       convert(int,0)                                     as cdparticipante " +
            "                   ,   lpad(ps.cpf_cnpj,14,'0')                           as cpf_cnpj " +
            "                   ,   PS.PESSOA_KEY                                      AS cdpessoabluesoft " +
            "                   ,   CASE WHEN ISNULL(CL.PESSOA_KEY,0)     > 0 THEN 'true' ELSE 'false'  END AS bluesoftcliente " +
            "                   ,   CASE WHEN ISNULL(VE.PESSOA_KEY,0)     > 0 THEN 'true' ELSE 'false'  END AS bluesoftvendedor " +
            "                   ,   CASE WHEN ISNULL(FA.FABRICANTE_KEY,0) > 0 THEN 'true' ELSE 'false'  END AS bluesoftfabricante  " +
            "                   ,   CASE WHEN ISNULL(FO.FORNECEDOR_KEY,0) > 0 THEN 'true' ELSE 'false'  END AS bluesoftfornecedor " +
            "                   ,   ISNULL(GV.VENDEDOR_EXTERNO_KEY,0)                  AS cdparticipantevendedorbluesoft " +
            "                   ,   convert(int,0)                                     as cdparticipantevendedor " +
            "                   ,   ISNULL(CG.GRUPO_ECONOMICO_KEY,0)                   AS cdgrupoeconomico " +
            "                   ,   'VXXXX'                                            as erptargetcdvend  " +
            "                   ,   convert(int,0)                                     as erptargetcdclien " +
            " FROM          PESSOA      PS " +
            " LEFT JOIN     CLIENTE     CL ON CL.PESSOA_KEY = PS.PESSOA_KEY  " +
            " LEFT JOIN     (   SELECT     VE.VENDEDOR_EXTERNO_KEY  PESSOA_KEY  " +
            "                   FROM GRUPO_ECONOMICO_COMISSAO VE " +
            "                   INNER JOIN PESSOA                   PS ON PS.PESSOA_KEY = VE.VENDEDOR_EXTERNO_KEY " +
            "                   GROUP BY   VENDEDOR_EXTERNO_KEY, PS.NOME_RAZAO " +
            "               )   VE ON VE.PESSOA_KEY = PS.PESSOA_KEY  " +
            " LEFT JOIN     FABRICANTE FA ON FA.FABRICANTE_KEY = PS.PESSOA_KEY               " +
            " LEFT JOIN     ( SELECT fornecedor_key FROM fornecedor_produto group by fornecedor_key  ) FO ON FO.FORNECEDOR_KEY = PS.PESSOA_KEY  " +
            " LEFT JOIN     CLIENTE_GRUPO_ECONOMICO CG ON CG.CLIENTE_KEY = PS.PESSOA_KEY  " +
            " LEFT JOIN     (  " +
            "                   SELECT     CR.GRUPO_ECONOMICO_KEY      AS GRUPO_ECONOMICO_KEY " +
            "                           ,  GV.VENDEDOR_EXTERNO_KEY     AS VENDEDOR_EXTERNO_KEY " +
            "                           ,  GV.VENDEDOR                 AS VENDEDOR_NOME  " +
            "                   FROM       PESSOA                   PS  " +
            "                   INNER JOIN CLIENTE_GRUPO_ECONOMICO  CR ON CR.CLIENTE_KEY = PS.PESSOA_KEY  " +
            "                   INNER JOIN GRUPO_ECONOMICO          GR ON GR.GRUPO_ECONOMICO_KEY = CR.GRUPO_ECONOMICO_KEY  " +
            "                   INNER JOIN ( SELECT    MAX(X.VENDEDOR_EXTERNO_KEY)  VENDEDOR_EXTERNO_KEY  " +
            "                                   ,  X.GRUPO_ECONOMICO_KEY        GRUPO_ECONOMICO_KEY " +
            "                                FROM      GRUPO_ECONOMICO_COMISSAO   X " +
            "                                GROUP BY  X.GRUPO_ECONOMICO_KEY " +
            "                               ) GX ON GX.GRUPO_ECONOMICO_KEY  = GR.GRUPO_ECONOMICO_KEY  " +
            "                   INNER JOIN GRUPO_ECONOMICO_COMISSAO GV ON GV.GRUPO_ECONOMICO_KEY = GX.GRUPO_ECONOMICO_KEY AND GV.VENDEDOR_EXTERNO_KEY = GX.VENDEDOR_EXTERNO_KEY " +
            "                   GROUP BY   CR.GRUPO_ECONOMICO_KEY " +
            "                           ,  GV.VENDEDOR_EXTERNO_KEY  " +
            "                           ,  GV.VENDEDOR   " +
            "               ) GV ON GV.GRUPO_ECONOMICO_KEY = CG.GRUPO_ECONOMICO_KEY ";
            //" WHERE         PS.NOME_RAZAO LIKE 'ELIAS DA SILVA'             ";




            return SQL;
        }
    }

}



