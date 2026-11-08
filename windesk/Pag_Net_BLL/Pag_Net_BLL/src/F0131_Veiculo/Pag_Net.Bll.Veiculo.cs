using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0131_Veiculo
{
    public class Wk
    {
        public Pag_Net.Models.modelSistemaUsuario MyConnect;
        public Pag_Net.Bll.F0131_Veiculo.TbVeiculoModelo[] Veiculos_Modelo;

        public Wk(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
        }
  

        public TbVeiculo CRUD(Models.BDCommandTypes _TypeCommand, TbVeiculo item)
        {
            try
            {
                return new TbVeiculo(Pag_Net.Bll.BDCommand.get_DataTable(MyConnect, F0131_Veiculo.f0131_01_veiculo_modelo_CRUD.Get(item)).Rows[0]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Pag_Net.Bll.F0131_Veiculo.TbVeiculoModelo[] VeiculoModelos_Get ()
        {
            try
            {
                List<Pag_Net.Bll.F0131_Veiculo.TbVeiculoModelo> LstVeiculoModelo = new List<TbVeiculoModelo>();
                
                foreach( DataRow i in Pag_Net.Bll.BDCommand.get_DataTable(MyConnect, F0131_Veiculo.f0131_30_veiculo_modelo_list.Get()).Rows)
                {
                    LstVeiculoModelo.Add(new TbVeiculoModelo(i));
                }
                Veiculos_Modelo = LstVeiculoModelo.ToArray();
                return Veiculos_Modelo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
