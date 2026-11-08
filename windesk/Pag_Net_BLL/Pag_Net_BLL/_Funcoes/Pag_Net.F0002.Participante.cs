using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;
using Pag_Net.F0002;

namespace Pag_Net.F0002.Bll.Migration
{
    public static class FromRedShift
    {
        public static void ToSqlPostGres(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {

            string ErroInfo = "";

            try
            {

                List<Models.Participante> RedShiftBaseParticipante;
                RedShiftBaseParticipante = new List<Models.Participante>();

                /*Buscando o código de participante da tabela no SQL - Que será desativada em breve*/
                DataSet DataSqlServer = new DataSet();
                DataSqlServer = DbSelect.GetDataSet(MyConnect,
                    Dal.DataBaseName.DBAMAINADM,
                    Pag_Net.F0002.Models.BD.SqlServer.SqlProcedureName(),
                    Pag_Net.F0002.Models.BD.SqlServer.sp_F0002_02RL_tbparticipante(null, Pag_Net.Models.BDCommandTypes.DBSELECT)
                    );
                DataTable SqlServerListParticipante = DataSqlServer.Tables[0];
                DataColumn[] columnsprimarykey = new DataColumn[1];
                columnsprimarykey[0] = SqlServerListParticipante.Columns["cpf_cnpj"];
                SqlServerListParticipante.PrimaryKey = columnsprimarykey;
                foreach (DataRow dr in SqlServerListParticipante.Rows)
                {
                    ErroInfo = "Migration _ Leitura Redshift CdPessoaBlueSoft: " + dr["CdPessoaBlueSoft"];
                    RedShiftBaseParticipante.Add(new Models.Participante(dr));
                }

                /*Fazendo a leitura na base PostgreSQL*/
                DataSet DataRedshift = new DataSet();
                DataRedshift = DbSelect.GetDataSet(MyConnect, Dal.DataBaseName.ODBCBI32, Models.BD.RedShift.Select(), "");
                
                foreach (DataRow dr in DataRedshift.Tables[0].Rows)
                {
                    ErroInfo = "Migration _ Leitura Redshift CdPessoaBlueSoft: " + dr["CdPessoaBlueSoft"];
                    int index = RedShiftBaseParticipante.FindIndex(x => x.cpf_cnpj == dr["cpf_cnpj"].ToString());

                    if (index > 0) 
                    {
                        RedShiftBaseParticipante[index].cdpessoabluesoft = Convert.ToInt32(dr["cdpessoabluesoft"].ToString());
                        RedShiftBaseParticipante[index].bluesoftcliente = Convert.ToBoolean(dr["bluesoftcliente"].ToString());
                        RedShiftBaseParticipante[index].bluesoftvendedor = Convert.ToBoolean(dr["bluesoftvendedor"].ToString());
                        RedShiftBaseParticipante[index].bluesoftfabricante = Convert.ToBoolean(dr["bluesoftfabricante"].ToString());
                        RedShiftBaseParticipante[index].bluesoftfornecedor = Convert.ToBoolean(dr["bluesoftfornecedor"].ToString());
                        RedShiftBaseParticipante[index].cdparticipantevendedorbluesoft = Convert.ToInt32(dr["cdparticipantevendedorbluesoft"].ToString());
                        RedShiftBaseParticipante[index].cdparticipantevendedor = Convert.ToInt32(dr["cdparticipantevendedor"].ToString());
                        RedShiftBaseParticipante[index].cdgrupoeconomico = Convert.ToInt32(dr["cdgrupoeconomico"].ToString());

                    }
                }

                /*Inserindo na base PostrGreSQL*/
                DbUpdate BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                //BDExecute.Begin(DataBaseName.ODBCOXAN);
                foreach (Models.Participante item in RedShiftBaseParticipante)
                {
                    ErroInfo = "Migration _ Inserindo na Base Postgresql - " + item.cdparticipante.ToString();
                    //DataRow SqlCdParticipante = SqlServerListParticipante.Rows.Find(item);

                    BDExecute.Execute(Models.BD.Postgres.fn_SELECT_F0002_01PC_tbparticipante(item, Pag_Net.Models.BDCommandTypes.DBINSERT), null, DataBaseName.ODBCOXAN);
                }
                //BDExecute.Commit(DataBaseName.ODBCOXAN);
            }

            catch (Exception ex)
            {
                throw new Exception("F0002 | " + ErroInfo + " - " + ex.Message);
            }

        }
 
    }
}

