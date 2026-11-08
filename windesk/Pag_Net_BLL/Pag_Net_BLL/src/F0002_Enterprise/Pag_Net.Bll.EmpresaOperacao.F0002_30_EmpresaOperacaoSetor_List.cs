using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Models;


namespace Pag_Net.Bll.F0002_Enterprise
{
    public class F0002_EmpresaOperacaoSetor
    {
   
        public int rh_funcionario_tipo_contrato_cd { get; set; }
        public int em_cdempresa { get; set;  }
        public int op_cdoperacao { get; set;  }
        public int operacao_setor_cd { get; set;  }

 
        public F0002_EmpresaOperacaoSetor()
        {
            em_cdempresa = 0;
            op_cdoperacao = 0;
            operacao_setor_cd = 0;
        }
        public F0002_EmpresaOperacaoSetor(
             int _em_cdempresa

            )
        {
            em_cdempresa = _em_cdempresa;
            op_cdoperacao = 0;
            operacao_setor_cd = 0;
        }

        private string _VERSION() { return "f0002_30_1011925_empresa_operacao_setor"; }
        public string sql_Get()
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() +
                    string.Format("({0}, {1}, {2})",
                    em_cdempresa.ToString(), 
                    op_cdoperacao.ToString(),
                    operacao_setor_cd.ToString()
                    
                    ));

                return SQL_POSTGRE;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
