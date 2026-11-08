using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Data.OleDb;
using System.Data.SqlClient;
using Pag_Net.Bll;
using Pag_Net.Bll.Tools;
using Pag_Net.Dal;
using Pag_Net.Models;
using Pag_Net.Tools.CryptFile;
using Pag_Net.Tools.CryptPassWord;
using Pag_Net.Tools;
using Pag_Net.Services;


/******************************* COMPLEMENTOS *********************************************/



namespace Pag_Net.Services.Bll.Postgre
{
    public static class Tab
    {
        public static List<Models.sistema_nucleo_procedimentos> List(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                /*RedShift BlueSoft SELECT */
                return Tab.List(MyConnect,1);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<Models.sistema_nucleo_procedimentos> List(Pag_Net.Models.modelSistemaUsuario MyConnect, int  Execucao_Manual)
        {
            string ErroInfo = "";
            try
            {
                /*RedShift BlueSoft SELECT */
                List<Models.sistema_nucleo_procedimentos> List = new List<Models.sistema_nucleo_procedimentos>();
                DataSet DX = new DataSet();
                DX = DbSelect.GetDataSet(MyConnect, Dal.DataBaseName.ODBCOXAN, Models.BD.Postgres.F9000_15_SistemaNucleoProcedimento_List_Get(Execucao_Manual), "");
                foreach (DataRow dr in DX.Tables[0].Rows)
                {
                    ErroInfo = "ID: " + dr["sis_nucleo_prc_cd"];
                    List.Add(new Models.sistema_nucleo_procedimentos(dr));
                }
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception("Pag.Net.Services.Bll.PostGre - Services: " + ErroInfo + " - " + ex.Message);
            }
        }        


    }

    public static class Procedimentos
    {
        public static void Execute(Pag_Net.Models.modelSistemaUsuario MyConnect, Models.sistema_nucleo_procedimentos Procedimento, bool UltimoProcessamento)
        {
            try
            {
                Execute(MyConnect, Procedimento.sis_nucleo_cd_fk, Procedimento.sis_nucleo_prc_cd, UltimoProcessamento);
            }
            catch (Exception EX)
            {
                throw new Exception(EX.Message);
            }
        }
        
        public static void Execute(Pag_Net.Models.modelSistemaUsuario MyConnect, Models.sistema_nucleo_procedimentos Procedimento)
        {
            try
            {
                Execute(MyConnect, Procedimento.sis_nucleo_cd_fk, Procedimento.sis_nucleo_prc_cd, false);
            }
            catch (Exception EX)
            {
                throw new Exception(EX.Message);
            }
        }
        
        public static void Execute(Pag_Net.Models.modelSistemaUsuario MyConnect, string sis_nucleo_cd_fk, int sis_nucleo_prc_cd)
        {
            try
            {
                Execute(MyConnect, sis_nucleo_cd_fk, sis_nucleo_prc_cd, false);
            }
            catch (Exception EX)
            {
                throw new Exception(EX.Message);
            }
        }

        public static void Execute(Pag_Net.Models.modelSistemaUsuario MyConnect, string sis_nucleo_cd_fk, int sis_nucleo_prc_cd, bool UltimoProcessamento )
        {
            string Erro = string.Format("Erro na Execução do Script {0} / {1}", sis_nucleo_cd_fk, sis_nucleo_prc_cd);
            try
            {
                DateTime DataInicial = DateTime.Now.Add(new TimeSpan(-15, 0, 0, 0)).Date;
                DateTime DataFinal = DateTime.Now.Date;


                /*Nucleos revisados e ativos */

                if (sis_nucleo_cd_fk == "F0080") Pag_Net.src.F0080_Financeiro.batchs.start(MyConnect, sis_nucleo_prc_cd);


                if (sis_nucleo_cd_fk == "F0017" && sis_nucleo_prc_cd == 8) Pag_Net.F0017.Bll.Migration.FromRedShift.ToSqlPostGres(MyConnect);
                if (sis_nucleo_cd_fk == "F0018" && sis_nucleo_prc_cd == 9) Pag_Net.F0018.Bll.Migration.FromRedShift.ToSqlPostGres(MyConnect);
                if (sis_nucleo_cd_fk == "F0019" && sis_nucleo_prc_cd == 10) Pag_Net.F0019.Bll.Migration.FromRedShift.ToSqlPostGres(MyConnect);
                if (sis_nucleo_cd_fk == "F0020" && sis_nucleo_prc_cd == 11) Pag_Net.F0020.Bll.Migration.FromRedShift.ToSqlPostGres(MyConnect);
                if (sis_nucleo_cd_fk == "F0026" && sis_nucleo_prc_cd == 13) Pag_Net.F0026.Bll.Migration.FromRedShift.ToSqlPostGres(MyConnect);
                
                if (sis_nucleo_cd_fk == "OLD07" && sis_nucleo_prc_cd == 36) Pag_Net.Bll.Participante.BlueSoft_Import.Start(MyConnect);
                if (sis_nucleo_cd_fk == "OLD08" && sis_nucleo_prc_cd == 37) Pag_Net.Bll.Faturamento.BlueSoft_Import.Start(MyConnect, Convert.ToDateTime(DataInicial.ToShortDateString()), Convert.ToDateTime(DataFinal.ToShortDateString()));
                if (sis_nucleo_cd_fk == "OLD09" && sis_nucleo_prc_cd == 39) Pag_Net.CO03.Bll.FaturamentoBlue.Export.SqlServer(MyConnect);
                if (sis_nucleo_cd_fk == "F0070" && sis_nucleo_prc_cd == 42) Pag_Net.F0070.Bll.Migration.FromRedShift.ToSqlPostGres(MyConnect);
                if (sis_nucleo_cd_fk == "F0075" && sis_nucleo_prc_cd == 43) Pag_Net.F0075.Bll.Migration.FromRedShift.ToSqlPostGres(MyConnect);
                if (sis_nucleo_cd_fk == "F0110" && sis_nucleo_prc_cd == 48) Pag_Net.F0110.Bll.Migration.FromRedShift.ToSqlPostGres(MyConnect);
                if (sis_nucleo_cd_fk == "F0060" && sis_nucleo_prc_cd == 60) Pag_Net.Bll.F0060_DocumentoFiscal.BDBlueSoft_Import.start(MyConnect);
                if (sis_nucleo_cd_fk == "F0011" && sis_nucleo_prc_cd == 1103) Pag_Net.Bll.F0011_Participante.Service.F0011_1103.start(MyConnect);
                if (sis_nucleo_cd_fk == "F0012" && sis_nucleo_prc_cd == 1250) Pag_Net.Bll.F0012_GrupoEconomico.Service.F0012_1250.start(MyConnect);
                if (sis_nucleo_cd_fk == "F0021" && sis_nucleo_prc_cd == 2102) Pag_Net.Bll.F0021_ProdutoBlueSoft.Service.F0021_2102.start(MyConnect);
                if (sis_nucleo_cd_fk == "F0021" && sis_nucleo_prc_cd == 2190) Pag_Net.Bll.F0021_ProdutoBlueSoft.Service.F0021_2190.start(MyConnect);
                if (sis_nucleo_cd_fk == "F0030" && sis_nucleo_prc_cd == 3010) Pag_Net.Bll.F0030_EstoqueCusto.Service.F0030_10_EstoqueCustosDiario_Importar(MyConnect);
                if (sis_nucleo_cd_fk == "F0030" && sis_nucleo_prc_cd == 3090) Pag_Net.Bll.F0030_EstoqueCusto.Service.F0030_90_EstoqueCustosDiario_Processar(MyConnect);
                if (sis_nucleo_cd_fk == "F0030" && sis_nucleo_prc_cd == 3091) Pag_Net.Bll.F0030_EstoqueCusto.Service.F0030_91_EstoqueCustos_Processar(MyConnect);
                if (sis_nucleo_cd_fk == "F0049" && sis_nucleo_prc_cd == 4901) Pag_Net.Bll.NP0049_01_BancoContaBancaria.start(MyConnect);
                //if (sis_nucleo_cd_fk == "F0050" && sis_nucleo_prc_cd == 5001) Pag_Net.Bll.F0080_Financeiro.WKBlueSoft_Import.start(MyConnect);
                if (sis_nucleo_cd_fk == "F0055" && sis_nucleo_prc_cd == 5500) Pag_Net.Bll.NP0055_00_FaturamentoBlueSoft.start(MyConnect);
                if (sis_nucleo_cd_fk == "F0050" && sis_nucleo_prc_cd == 5001) Pag_Net.src.F0050_Faturamento_BlueSoft.service.F0050_5001.start(MyConnect);



                /*SERVIÇOS A SEREM REVISADOS */
                if (sis_nucleo_cd_fk == "F0011" && sis_nucleo_prc_cd == 1104) Pag_Net.Bll.NP0011_04_ParticipanteEndereco.start(MyConnect);
                if (sis_nucleo_cd_fk == "PSQ01" && sis_nucleo_prc_cd == 14) Pag_Net.Services.Bll.TEMP.Produto.Update(MyConnect, UltimoProcessamento);
                if (sis_nucleo_cd_fk == "PSQ02" && sis_nucleo_prc_cd == 15) Pag_Net.Services.Bll.TEMP.ProdutoEmbalagem.Update(MyConnect, UltimoProcessamento);
                if (sis_nucleo_cd_fk == "PSQ03" && sis_nucleo_prc_cd == 16) Pag_Net.Services.Bll.TEMP.ProdutoEmbalagem_Gtins.Update(MyConnect, UltimoProcessamento);
                if (sis_nucleo_cd_fk == "PSQ04" && sis_nucleo_prc_cd == 17) Pag_Net.Services.Bll.TEMP.ProdutoTributacao.Update(MyConnect, UltimoProcessamento);
                if (sis_nucleo_cd_fk == "PSQ05" && sis_nucleo_prc_cd == 18) Pag_Net.Services.Bll.TEMP.ProdutoBlueSoft.Update(MyConnect, UltimoProcessamento);
                if (sis_nucleo_cd_fk == "PSQ06" && sis_nucleo_prc_cd == 19) Pag_Net.Services.Bll.TEMP.EstoqueCusto.Update(MyConnect, UltimoProcessamento);
                if (sis_nucleo_cd_fk == "PSQ07" && sis_nucleo_prc_cd == 20) Pag_Net.Services.Bll.TEMP.EstoqueCustoBlueSoft.Update(MyConnect, UltimoProcessamento);
                if (sis_nucleo_cd_fk == "PSQ08" && sis_nucleo_prc_cd == 21) Pag_Net.Services.Bll.TEMP.ProdutoBlueSoft_Embalagem.Update(MyConnect, UltimoProcessamento);
                if (sis_nucleo_cd_fk == "F0006" && sis_nucleo_prc_cd == 22) Pag_Net.F0006.Bll.Migration.FromRedShift.ToSqlPostGres(MyConnect);
                if (sis_nucleo_cd_fk == "F0052" && sis_nucleo_prc_cd == 24) Pag_Net.F0052.Bll.Migration.FromRedShift.ToSqlPostGres(MyConnect);
                if (sis_nucleo_cd_fk == "F0053" && sis_nucleo_prc_cd == 25) Pag_Net.F0053.Bll.Migration.SqlServer.ToSqlPostGres(MyConnect);
                if (sis_nucleo_cd_fk == "P0020" && sis_nucleo_prc_cd == 26) Pag_Net.P0020.Bll.Process.Execute(MyConnect);
                if (sis_nucleo_cd_fk == "P0001" && sis_nucleo_prc_cd == 27) Pag_Net.P0001.Bll.Process.Execute(MyConnect);
                if (sis_nucleo_cd_fk == "F0061" && sis_nucleo_prc_cd == 41) Pag_Net.F0061.Bll.Migration.FromRedShift.ToSqlPostGres(MyConnect);
                if (sis_nucleo_cd_fk == "F0090" && sis_nucleo_prc_cd == 45) Pag_Net.F0090.Bll.Migration.FromRedShift.ToSqlPostGres(MyConnect);
                if (sis_nucleo_cd_fk == "F0100" && sis_nucleo_prc_cd == 46) Pag_Net.F0100.Bll.Migration.FromRedShift.ToSqlPostGres(MyConnect);
                //if (sis_nucleo_cd_fk == "F0023" && sis_nucleo_prc_cd == 47) Pag_Net.F0023.Bll.Migration.FromRedShift.ToSqlMicrosoft(MyConnect);
                if (sis_nucleo_cd_fk == "F0002" && sis_nucleo_prc_cd == 49) Pag_Net.F0002.Bll.Migration.FromRedShift.ToSqlPostGres(MyConnect);
                if (sis_nucleo_cd_fk == "F0115" && sis_nucleo_prc_cd == 50) Pag_Net.F0115.Bll.Migration.FromRedShift.ToSqlPostGres(MyConnect);
                if (sis_nucleo_cd_fk == "P0041" && sis_nucleo_prc_cd == 51) Pag_Net.P0041.Bll.Process.Execute(MyConnect);
                if (sis_nucleo_cd_fk == "P0001" && sis_nucleo_prc_cd == 101) p0001_01(MyConnect);
                if (sis_nucleo_cd_fk == "F0060" && sis_nucleo_prc_cd == 6001) Pag_Net.Bll.NP0060_01_DocumentoFiscal.start(MyConnect);
                if (sis_nucleo_cd_fk == "F0060" && sis_nucleo_prc_cd == 6002) Pag_Net.Bll.NP0060_02_DocumentoFiscalItem.start(MyConnect);
                if (sis_nucleo_cd_fk == "F0060" && sis_nucleo_prc_cd == 6004) Pag_Net.Bll.NP0060_04_DocumentoFiscalSeq.start(MyConnect);
                if (sis_nucleo_cd_fk == "F0136" && sis_nucleo_prc_cd == 1013601) Pag_Net.Bll.F0136_Contrato_Servico.BDBlueSoft_Import.start(MyConnect);
                if (sis_nucleo_cd_fk == "F0065" && sis_nucleo_prc_cd == 100650055) Pag_Net.Bll.F0065_Forca_Venda.Service.ImportaTabPrecos(MyConnect);
                if (sis_nucleo_cd_fk == "F0004" && sis_nucleo_prc_cd == 100040010) Pag_Net.Bll.F0004_Forca_Venda.BDBlueSoft_Import.start(MyConnect);

                



                //if (sis_nucleo_cd_fk == "OLD06" && sis_nucleo_prc_cd == 35) Pag_Net.Bll.Integration.RedShiftSqlServer.SPC5000TbDocumentosFiscais.Execute(MyConnect, new Pag_Net.Models.SPC5000TbDocumentosFiscais(0, 0, 0, 0, DataInicial, DataFinal));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static void p0001_01(Pag_Net.Models.modelSistemaUsuario MyConnect) { try { Pag_Net.Bll.BDCommand.Execute(MyConnect, BDCommand.Name.P0001_01); } catch (Exception ex) { throw new Exception(ex.Message); } }
        public static void p0010_01(Pag_Net.Models.modelSistemaUsuario MyConnect) { try { Pag_Net.Bll.BDCommand.Execute(MyConnect, BDCommand.Name.P0010_01); } catch (Exception ex) { throw new Exception(ex.Message); } }
        public static void p0010_02(Pag_Net.Models.modelSistemaUsuario MyConnect) { try { Pag_Net.Bll.BDCommand.Execute(MyConnect, BDCommand.Name.P0010_02); } catch (Exception ex) { throw new Exception(ex.Message); } }
        
    }


}

