using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0002_Enterprise
{
    public class TbOperacao_Setor
    {
        public int em_cdempresa { get; set; }
        public int op_cdoperacao { get; set; }
        public int operacao_setor_cd { get; set; }
        public string operacao_setor_descricao {get; set; }

        public TbOperacao_Setor()
        {
            em_cdempresa = 0;
            op_cdoperacao = 0;
            operacao_setor_cd = 0;
            operacao_setor_descricao = "Selecione o Setor de Operação";
        }
        public TbOperacao_Setor(
            int _em_cdempresa,
            int _op_cdoperacao,
            int _operacao_setor_cd,
            string _operacao_setor_descricao
            )
        {
            em_cdempresa = _em_cdempresa;
            op_cdoperacao = _op_cdoperacao;
            operacao_setor_cd = _operacao_setor_cd;
            operacao_setor_descricao = _operacao_setor_descricao;
        }

        public TbOperacao_Setor (DataRow i)
        {
            em_cdempresa = Convert.ToInt32(i["em_cdempresa"].ToString());
            op_cdoperacao = Convert.ToInt32(i["op_cdoperacao"].ToString());
            operacao_setor_cd = Convert.ToInt32(i["operacao_setor_cd"].ToString());
            operacao_setor_descricao = i["operacao_setor_descricao"].ToString();
        }


    }
}
