using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle
{
    public class model_controle_reg_transporte : TbControle_Reg_Transporte
    {

        public Pag_Net.Bll.F0131_Veiculo.TbVeiculo Veiculo;
        public model_controle_reg_transporte()
            : base()
        {
            Veiculo = new F0131_Veiculo.TbVeiculo();
        }
        public model_controle_reg_transporte(int _controle_reg_seq, int _controle_reg_transp_seq, int _veiculo_seq, int _pallet_qtde, double _pallet_valor_unitario)
            : base(_controle_reg_seq, _controle_reg_transp_seq, _veiculo_seq, _pallet_qtde, _pallet_valor_unitario) { }

        public model_controle_reg_transporte(DataRow i) : base(i) { }

        public void Binding_Veiculo(Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                Pag_Net.Bll.F0131_Veiculo.Wk __WKVeiculo = new F0131_Veiculo.Wk(MyConnect);
                Veiculo = __WKVeiculo.CRUD(Models.BDCommandTypes.DBSELECT, Veiculo);
                if (this.veiculo_seq == 0)
                {
                    this.veiculo_seq = Veiculo.veiculo_seq;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Save(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                BDCommand.get_DataTable(MyConnect,
                    F0130_36_Controle_Reg_Transporte_CRUD.Post(MyConnect,
                                                            Models.BDCommandTypes.DBINSERT, this));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
