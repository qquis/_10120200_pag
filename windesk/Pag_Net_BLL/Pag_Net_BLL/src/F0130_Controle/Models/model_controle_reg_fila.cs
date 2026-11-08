using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle
{
    public class model_controle_reg_fila : TbControle_Reg_Fila
    {

        public model_controle_reg_fila() : base() { }
        public model_controle_reg_fila(TbControle_Fila _controle_fila) : base() { }

        public model_controle_reg_fila(DataRow i) : base(i) { }
        public void Save(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                model_controle_reg_fila _NEW_FILA = new model_controle_reg_fila(BDCommand.get_DataTable(MyConnect,
                    F0130_32_Controle_Reg_Fila_CRUD.Post(MyConnect, Models.BDCommandTypes.DBINSERT, this)).Rows[0]);

                this.controle_reg_fila_seq = _NEW_FILA.controle_reg_fila_seq;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
