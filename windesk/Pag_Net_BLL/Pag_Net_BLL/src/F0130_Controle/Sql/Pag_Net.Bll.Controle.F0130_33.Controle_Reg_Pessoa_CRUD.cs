using Pag_Net.Dal;
using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle
{
    public static class F0130_33_Controle_Reg_Pessoa_CRUD
    {
        private static string _VERSION() { return "f0130_33_1011922_controle_reg_pessoa_crud"; }
        public static string Post(
            Pag_Net.Models.modelSistemaUsuario MyConnect,
            BDCommandTypes BDCommnadType,
            TbControle_Reg_Pessoa TBCONTROLE_REG_PESSOA
            )
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() +
                    string.Format("('{0}', {1}, {2}, {3}, {4}, {5}, '{6}', '{7}', '{8}', '{9}', {10}, {11}, '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', {18}, {19})",
                    BDCommnadType.ToString(),
                      TBCONTROLE_REG_PESSOA.controle_reg_seq
                    , TBCONTROLE_REG_PESSOA.controle_pessoa_cd
                    , TBCONTROLE_REG_PESSOA.cdparticipante
                    , TBCONTROLE_REG_PESSOA.cdpessoabluesoft
                    , TBCONTROLE_REG_PESSOA.rh_funcionario_cd
                    , TBCONTROLE_REG_PESSOA.cpf_cnpj
                    , TBCONTROLE_REG_PESSOA.nome_razao
                    , TBCONTROLE_REG_PESSOA.documento_cnh
                    , TBCONTROLE_REG_PESSOA.documento_cnh_vencimento.ToString("yyyy-MM-dd")
                    , TBCONTROLE_REG_PESSOA.endereco_tipo_cd
                    , TBCONTROLE_REG_PESSOA.endereco_cep
                    , TBCONTROLE_REG_PESSOA.endereco_logradouro
                    , TBCONTROLE_REG_PESSOA.endereco_numero
                    , TBCONTROLE_REG_PESSOA.endereco_bairro
                    , TBCONTROLE_REG_PESSOA.endereco_municipio
                    , TBCONTROLE_REG_PESSOA.endereco_uf
                    , TBCONTROLE_REG_PESSOA.endereco_complmento
                    , TBCONTROLE_REG_PESSOA.celular_dd
                    , TBCONTROLE_REG_PESSOA.celular_numero			
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


