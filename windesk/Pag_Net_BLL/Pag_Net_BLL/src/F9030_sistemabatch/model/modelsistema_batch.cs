using Pag_Net.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.F9030_sistemabatch.model
{
    public class modelsistema_batch : tbs.tbsistema_batch
    {

        
        public tbs.tbsistema_batch_time sistema_batch_time { get; set;}
        public tbs.tbsistema_batch_run sistema_batch_run { get; set; }

        public modelsistema_batch() : base() { modelConstructor(); }

        public void modelConstructor()
        {
            sistema_batch_run = new tbs.tbsistema_batch_run();
            sistema_batch_time = new tbs.tbsistema_batch_time(); 
        }

        public void modelDataBinding(DataRow i)
        {
            try
            {
                this.sis_batch_cd = Convert.ToInt32(i["sis_batch_cd"].ToString());
                this.sis_batch_descricao = i["sis_batch_descricao"].ToString(); 
                sistema_batch_run.__Binding(i); 
            }
            catch (Exception ex)
            {
                throw new Exception("Class TbRecurso_Ctrl - Error: \n" + ex.Message);
            }
        }

        public void modelNewRun(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                if (this.sis_batch_cd == 0)
                {
                    throw new Exception("código do batch Não definido");
                }
                
                this.sistema_batch_run.sis_batch_cd = this.sis_batch_cd;
                this.sistema_batch_run.sis_batch_run_seq = 0;
                this.sistema_batch_run.sis_batch_run_status_cd = 10;
                /*INFORMANDO O NUMERO DO SEQ TIME*/
                this.sistema_batch_run.sis_batch_time_seq = this.sistema_batch_time.sis_batch_time_seq;
                this.sistema_batch_run.__Atualizar(MyConnect); 
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void modelExecutarRun(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                if (this.sistema_batch_run.sis_batch_run_status_cd == 10)
                {
                    this.sistema_batch_run.sis_batch_run_status_cd = 20;
                    this.sistema_batch_run.__Atualizar(MyConnect); 

                }
            }

            catch ( Exception ex )
            {
                throw new Exception(ex.Message);
            }
        }

        public void modelFinalizarRun(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                if (this.sistema_batch_run.sis_batch_run_status_cd == 20)
                {
                    this.sistema_batch_run.sis_batch_run_status_cd = 30;
                    this.__Atualizar(MyConnect);

                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void modelFinalizarRunError(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {

                this.sistema_batch_run.sis_batch_run_status_cd = 99;
                this.sistema_batch_run.__Atualizar(MyConnect);

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void modelFinalizarRunUser(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {

                this.sistema_batch_run.sis_batch_run_status_cd = 90;
                this.sistema_batch_run.__Atualizar(MyConnect);

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void BindingFromRun(Pag_Net.Models.modelSistemaUsuario MyConnect, int sis_batch_run_seq)
        {
            try
            {
                
                
                
                DBDataTable MyDBDataTable = Pag_Net.src.F9030_sistemabatch.report.DBDataTables.SistemaBatchRun(MyConnect, 0, 0, sis_batch_run_seq);
                this.modelDataBinding(MyDBDataTable.List.Rows[0]); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); 
            }
        }
    }
}
