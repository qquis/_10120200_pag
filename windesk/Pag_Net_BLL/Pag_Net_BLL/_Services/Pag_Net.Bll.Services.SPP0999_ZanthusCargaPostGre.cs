using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Dal;
using System.Data;

namespace Pag_Net.SPP0999.Bll
{
    public static class SqlServer
    {
        public static void Execute(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";

            try
            {
                DbUpdate BDExecute = new DbUpdate(MyConnect, DataBaseName.DBAMAINADM);
                string SQL_SQLSERVER = string.Format("EXEC SPP0999_ZanthusCargaPostGre");
                BDExecute.Execute(SQL_SQLSERVER, null, DataBaseName.DBAMAINADM, true);
            }

            catch (Exception ex)
            {
                throw new Exception(ErroInfo + ex.Message);
            }
        }


        public static void SPP0999_ZanthusCargaPostGre_01_tbpostgre_Tab_Mercadoria(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            //string ErroInfo = "";

            try
            {
                DbUpdate BDExecute_log = new DbUpdate(MyConnect,  DataBaseName.ODBCOXAN);
                Pag_Net.Bll.Log.register(MyConnect, 0, "CARGALOJA", "SPP0999_ZanthusCargaPostGre_01_tbpostgre_Tab_Mercadoria _ INI");

                //Pag_Net.Bll.Log.register(MyConnect, 0, "CARGALOJA", "Processo Inicializado...");

                DbUpdate BDExecute = new DbUpdate(MyConnect, DataBaseName.DBAMAINADM);
                string SQL_SQLSERVER = string.Format("EXEC SPP0999_ZanthusCargaPostGre_01_tbpostgre_Tab_Mercadoria @processamento_total = 1");
                BDExecute.Execute(SQL_SQLSERVER, null, DataBaseName.DBAMAINADM, true);

                //Pag_Net.Bll.Log.register(MyConnect, BDExecute_log, 0, "CARGALOJA", "SPP0999_ZanthusCargaPostGre_01_tbpostgre_Tab_Mercadoria _ FIM");
                //BDExecute_log.Close();

            }

            catch (Exception ex)
            {
                throw new Exception("Pag_Net.SPP0999.Bll \n "
                                    + "EXEC SPP0999_ZanthusCargaPostGre_01_tbpostgre_Tab_Mercadoria @processamento_total = 1" + "\n"
                                    + ex.Message);
            }   
        }


        public static void SPP0999_ZanthusCargaPostGre_02_tbpostgre_TabTributacao(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            //string ErroInfo = "";

            try
            {
                DbUpdate BDExecute = new DbUpdate(MyConnect, DataBaseName.DBAMAINADM);
                Pag_Net.Bll.Log.register(MyConnect, 0, "CARGALOJA", "SPP0999_ZanthusCargaPostGre_02_tbpostgre_TabTributacao _ INI");
                string SQL_SQLSERVER = string.Format("EXEC SPP0999_ZanthusCargaPostGre_02_tbpostgre_TabTributacao @processamento_total = 1");
                BDExecute.Execute(SQL_SQLSERVER, null, DataBaseName.DBAMAINADM, true);
                Pag_Net.Bll.Log.register(MyConnect, 0, "CARGALOJA", "SPP0999_ZanthusCargaPostGre_02_tbpostgre_TabTributacao _ FIM");
            }

            catch (Exception ex)
            {
                throw new Exception("Pag_Net.SPP0999.Bll \n "
                                    + "EXEC SPP0999_ZanthusCargaPostGre_02_tbpostgre_TabTributacao @processamento_total = 1" + "\n"
                                    + ex.Message);
            }
        }

        public static void SPP0999_ZanthusCargaPostGre_03_tbpostgre_Tab_Regra_Icms(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
         

            try
            {
                DbUpdate BDExecute = new DbUpdate(MyConnect, DataBaseName.DBAMAINADM);
                Pag_Net.Bll.Log.register(MyConnect, 0, "CARGALOJA", "SPP0999_ZanthusCargaPostGre_03_tbpostgre_Tab_Regra_Icms _ INI");
                string SQL_SQLSERVER = string.Format("EXEC SPP0999_ZanthusCargaPostGre_03_tbpostgre_Tab_Regra_Icms @processamento_total = 1");
                BDExecute.Execute(SQL_SQLSERVER, null, DataBaseName.DBAMAINADM, true);
                Pag_Net.Bll.Log.register(MyConnect, 0, "CARGALOJA", "SPP0999_ZanthusCargaPostGre_03_tbpostgre_Tab_Regra_Icms _ FIM");
            }

            catch (Exception ex)
            {
                throw new Exception("Pag_Net.SPP0999.Bll \n "
                                    + "EXEC SPP0999_ZanthusCargaPostGre_03_tbpostgre_Tab_Regra_Icms @processamento_total = 1" + "\n"
                                    + ex.Message);
            }
        }

        public static void SPP0999_ZanthusCargaPostGre_04_tbpostgre_Tab_Mercadoria_Tipo_Venda(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            //string ErroInfo = "";

            try
            {
                DbUpdate BDExecute = new DbUpdate(MyConnect, DataBaseName.DBAMAINADM);
                Pag_Net.Bll.Log.register(MyConnect, 0, "CARGALOJA", "SPP0999_ZanthusCargaPostGre_04_tbpostgre_Tab_Mercadoria_Tipo_Venda _ INI");
                string SQL_SQLSERVER = string.Format("EXEC SPP0999_ZanthusCargaPostGre_04_tbpostgre_Tab_Mercadoria_Tipo_Venda @processamento_total = 1");
                BDExecute.Execute(SQL_SQLSERVER, null, DataBaseName.DBAMAINADM, true);
                Pag_Net.Bll.Log.register(MyConnect, 0, "CARGALOJA", "SPP0999_ZanthusCargaPostGre_04_tbpostgre_Tab_Mercadoria_Tipo_Venda _ FIM");
            }

            catch (Exception ex)
            {
                throw new Exception("Pag_Net.SPP0999.Bll \n "
                                    + "EXEC SPP0999_ZanthusCargaPostGre_04_tbpostgre_Tab_Mercadoria_Tipo_Venda @processamento_total = 1" + "\n"
                                    + ex.Message);
            }
        }


        public static void SPP0999_ZanthusCargaPostGre_05_tbpostgre_tab_produto_decomposicao(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            //string ErroInfo = "";

            try
            {
                DbUpdate BDExecute = new DbUpdate(MyConnect, DataBaseName.DBAMAINADM);
                Pag_Net.Bll.Log.register(MyConnect, 0, "CARGALOJA", "SPP0999_ZanthusCargaPostGre_05_tbpostgre_tab_produto_decomposicao _ INI");
                string SQL_SQLSERVER = string.Format("EXEC SPP0999_ZanthusCargaPostGre_05_tbpostgre_tab_produto_decomposicao @processamento_total = 1");
                BDExecute.Execute(SQL_SQLSERVER, null, DataBaseName.DBAMAINADM, true);
                Pag_Net.Bll.Log.register(MyConnect, 0, "CARGALOJA", "SPP0999_ZanthusCargaPostGre_05_tbpostgre_tab_produto_decomposicao _ FIM");
            }

            catch (Exception ex)
            {
                throw new Exception("Pag_Net.SPP0999.Bll \n "
                                    + "EXEC SPP0999_ZanthusCargaPostGre_05_tbpostgre_tab_produto_decomposicao @processamento_total = 1" + "\n"
                                    + ex.Message);
            }
        }

        public static void SPP0999_ZanthusCargaPostGre_50_zeusretail_update(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";

            try
            {
                DbUpdate BDExecute = new DbUpdate(MyConnect, DataBaseName.DBAMAINADM);
                Pag_Net.Bll.Log.register(MyConnect, 0, "CARGALOJA", "SPP0999_ZanthusCargaPostGre_50_zeusretail_update _ INI");
                string SQL_SQLSERVER = string.Format("EXEC SPP0999_ZanthusCargaPostGre_50_zeusretail_update @processamento_total = 1");
                BDExecute.Execute(SQL_SQLSERVER, null, DataBaseName.DBAMAINADM, true);
                Pag_Net.Bll.Log.register(MyConnect, 0, "CARGALOJA", "SPP0999_ZanthusCargaPostGre_50_zeusretail_update _ FIM");
            }

            catch (Exception ex)
            {
                throw new Exception("Pag_Net.SPP0999.Bll \n "
                                    + "EXEC SPP0999_ZanthusCargaPostGre_50_zeusretail_update @processamento_total = 1" + "\n"
                                    + ex.Message);
            }
        }
    }
}
