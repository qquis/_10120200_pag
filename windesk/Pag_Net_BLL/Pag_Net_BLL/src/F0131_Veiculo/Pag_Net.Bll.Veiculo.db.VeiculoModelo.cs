using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0131_Veiculo
{

    public class TbVeiculoModelo
    {
        public int veiculo_modelo_cd { get; set; }
        public string veiculo_modelo_descricao { get; set; }

        public TbVeiculoModelo()
        {
            veiculo_modelo_cd = 0;
            veiculo_modelo_descricao = "DESCRIÇÃO MODELO VEÍCULO";
        }
        public TbVeiculoModelo
        (

            int _veiculo_modelo_cd,
            string _veiculo_modelo_descricao

        )
        {
            veiculo_modelo_cd = _veiculo_modelo_cd;
            veiculo_modelo_descricao = _veiculo_modelo_descricao;
        }

        public TbVeiculoModelo(DataRow i)
        {
            veiculo_modelo_cd = Convert.ToInt32(i["veiculo_modelo_cd"]);
            veiculo_modelo_descricao = i["veiculo_modelo_descricao"].ToString();

        }

    }


}
