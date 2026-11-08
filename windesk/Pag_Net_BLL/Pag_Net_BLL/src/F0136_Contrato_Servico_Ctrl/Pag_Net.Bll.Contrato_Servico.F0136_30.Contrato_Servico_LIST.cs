using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0136_Contrato_Servico
{
    public class F0136_30_Contrato_Servico_List
    {
        public string   contrato_bluesoft_descritivo      { get; set; }
        public string   cpf_cnpj                          { get; set; }
        public string   nome_razao                        { get; set; }
        public int      contrato_servico_seq                 { get; set; }
        public int      contrato_servico_permite_execucao    { get; set; }
        public F0136_30_Contrato_Servico_List()
        {
            contrato_bluesoft_descritivo    = ""; 
            cpf_cnpj                        = "";     
            nome_razao                           = "";
            contrato_servico_seq = 0;
            contrato_servico_permite_execucao = 0;
        }
        public F0136_30_Contrato_Servico_List(
             string _contrato_bluesoft_descritivo  ,
             string _cpf_cnpj                      ,
             string _nome_razao                    ,
             int    _contrato_servico_seq             ,
             int    _contrato_servico_permite_execucao
            )
        {
            contrato_bluesoft_descritivo            = _contrato_bluesoft_descritivo     ;
            cpf_cnpj                                = _cpf_cnpj                         ;
            nome_razao                              = _nome_razao                       ;
            contrato_servico_seq                    = _contrato_servico_seq             ;
            contrato_servico_permite_execucao = _contrato_servico_permite_execucao;
        }
        
        private string _VERSION() { return "f0136_30_1011920_contrato_servico_list"; }
        public string sql_Get()
        {
            try
            {
                string SQL_POSTGRE = "";
                SQL_POSTGRE = string.Format("SELECT * FROM " + _VERSION() +
                    string.Format("('{0}', '{1}', '{2}', {3}, {4})",
                    contrato_bluesoft_descritivo.ToString(),
                    cpf_cnpj.ToString(),
                    nome_razao.ToString(),
                    contrato_servico_seq.ToString(),
                    contrato_servico_permite_execucao.ToString()
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
