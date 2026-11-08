using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle
{
    public class model_controle_reg_documentofiscal_etapa : TbControle_Reg_DocumentoFiscal_Etapa
    {
        public model_controle_reg_documentofiscal_etapa()
        {
            this.controle_reg_seq = 0;
        }

        public model_controle_reg_documentofiscal_etapa(
              int _dfr_seq
            , int _controle_reg_seq
            , int _controle_reg_fila_seq
            , int _controle_reg_etapa_seq)
            : base(


                _dfr_seq
                , _controle_reg_seq
                , _controle_reg_fila_seq
                , _controle_reg_etapa_seq
                ) { }


        public model_controle_reg_documentofiscal_etapa(DataRow i)
            : base(i)
        {
            this.dfr_seq = Convert.ToInt32(i["dfr_seq"].ToString());
            this.controle_reg_etapa_seq = Convert.ToInt32(i["controle_reg_etapa_seq"].ToString());
            this.controle_reg_fila_seq = Convert.ToInt32(i["controle_reg_fila_seq"].ToString());
            this.controle_reg_seq = Convert.ToInt32(i["controle_reg_seq"].ToString());


        }


        public void Save(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                BDCommand.get_DataTable(MyConnect,
                    F0130_35_Controle_Reg_Documentofiscal_Etapa_CRUD.Post(MyConnect,
                                                            Models.BDCommandTypes.DBINSERT, this));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
