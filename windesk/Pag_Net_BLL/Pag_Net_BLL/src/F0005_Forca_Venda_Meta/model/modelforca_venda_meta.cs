using Pag_Net.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.src.f0005_forca_venda_meta.model
{

    public class model_forca_venda_meta: tbs.tbforca_venda_meta
    {
        private string __label_nomevendedor;
        public string Label_NomeVendedor { get { return __label_nomevendedor;  } }
        public tbs.tbforca_venda_meta_vendedor RegistroMetaVendedor { get; set; }
        public tbs.tbforca_venda_meta_vendedor[] ListaMetaVendedor { get; set;  }

        public model_forca_venda_meta(Pag_Net.Models.modelSistemaUsuario MyConnect, int __fv_meta_cd, int __fv_meta_cdparticipantevendedor)
        {
            this.fv_meta_cd = __fv_meta_cd;
            this.__Consultar(MyConnect); 

            RegistroMetaVendedor = new tbs.tbforca_venda_meta_vendedor();

            if (__fv_meta_cdparticipantevendedor != 0)
            {
                string SqlConsultaVendedor = "Select     v.cdparticipante " +
                                             "         , c.nome_razao     " +
                                             " from       tbparticipante_vendedor v" +
                                             " inner join tbparticipante c on c.cdparticipante = v.cdparticipante " +
                                             " where 1 = 1 " +
                                             "  and  v.cdparticipante = " + __fv_meta_cdparticipantevendedor.ToString();

                DataTable BDVendedor = BDCommand.get_DataTable(MyConnect, SqlConsultaVendedor);
                if (BDVendedor.Rows.Count > 0)
                {
                    __label_nomevendedor = BDVendedor.Rows[0]["nome_razao"].ToString();
                }
                this.RegistroMetaVendedor.fv_meta_cdparticipantevendedor = __fv_meta_cdparticipantevendedor;
                this.RegistroMetaVendedor.fv_meta_cd = __fv_meta_cd;
                this.RegistroMetaVendedor.__Consultar(MyConnect);
                
            }
        }

        public void RegistroMetaVendedor_Atualizar(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                RegistroMetaVendedor.__Atualizar(MyConnect); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }

        public void Clonar(Pag_Net.Models.modelSistemaUsuario MyConnect, int __competencia_cd_clonagem)
        {
            try
            {
                if (this.fv_meta_cd == 0)
                {
                    throw new Exception("Favor indicar a Meta a se clonada");
                }

                /* Identificando a competencia destino */

                string sqlCompetenciaDestino = "SELECT competencia_cd, competencia_data_ini, competencia_data_fim from tbcompetencia where competencia_cd =  " + __competencia_cd_clonagem.ToString() + ";";
                DBDataTable DataCompetencia = new DBDataTable(BDCommand.get_DataTable(MyConnect, sqlCompetenciaDestino));

                if (DataCompetencia.Count != 1)
                {
                    throw new Exception("Registro de Competência não encontrado ou inválido");
                }

                string SQL_Clonagem = "SELECT * FROM " + scriptspg.f0005_50_fv_meta_clonar._VERSION() +
                                      "(   vfv_meta_cd_origem:= " + this.fv_meta_cd.ToString() +
                                      "  , vcompetencia_cd_destino:= " + __competencia_cd_clonagem.ToString() +
                                      ") ";
                DBDataTable DbDataTableClonagem = new DBDataTable(BDCommand.get_DataTable(MyConnect, SQL_Clonagem));
                //DataTable x = BDCommand.get_DataTable(MyConnect, SQL_Clonagem);

                if (DbDataTableClonagem.Count > 0)
                {
                    this.__Binding(DbDataTableClonagem.List.Rows[0]);
                }
                else
                {
                    throw new Exception("F0005 | ModelForcaVenda Errro: Não foi possível fazer a clonagem desta Meta");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); 
            }
                                  
            
        }
    }

}
