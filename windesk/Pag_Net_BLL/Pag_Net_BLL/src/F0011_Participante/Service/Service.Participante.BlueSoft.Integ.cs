using Pag_Net.Dal;
using Pag_Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0011_Participante.Service
{
    public static class Participante_BlueSoft
    {
        public static void Integ(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            string ErroInfo = "";
            try
            {

                int _sis_nucleo_prc_cd = 1103;
                string _Command_All = "";
                int _SEQ_UPDATE = 0;
                int _SEQ_COUNT = 0;
                int _COUNT = 0;


                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);

                /*RedShift BlueSoft SELECT */
                DataSet DX = new DataSet();

                Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "Participante", string.Format("RedShift - Leitura inicial", DateTime.Now.ToShortTimeString(), _SEQ_COUNT, _COUNT));

                DX = DbSelect.GetDataSet
                    (MyConnect, Dal.DataBaseName.ODBCBI32, RedShift_DBSelect(), "");

                _COUNT = DX.Tables[0].Rows.Count;

                foreach (DataRow dr in DX.Tables[0].Rows)
                {
                    ErroInfo = "ID: " + dr[1].ToString();

                    Pag_Net.Bll.F0011_Participante.ModelParticipante ITEM = new ModelParticipante();
                    ITEM._Binding_BaseBlueSoft(dr);

                    _Command_All = _Command_All + PostGre_DBInsert(Models.BDCommandTypes.DBINSERT, ITEM) + ";";
                    _SEQ_UPDATE = _SEQ_UPDATE + 1;
                    _SEQ_COUNT = _SEQ_COUNT + 1;
                    if (_SEQ_UPDATE > 250 || _SEQ_COUNT >= _COUNT)
                    {
                        Pag_Net.Bll.Log.register(MyConnect, BDExecute, _sis_nucleo_prc_cd, "Participante", string.Format("Participante {0}: {1}/{2}", DateTime.Now.ToShortTimeString(), _SEQ_COUNT, _COUNT));
                        BDExecute.Execute(_Command_All, null, DataBaseName.ODBCOXAN);
                        System.Threading.Thread.Sleep(250);
                        _Command_All = ""; _SEQ_UPDATE = 0;
                    }
                }
                DX.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("NP0011_03_PessoaBlueSoft | " + ErroInfo + " - " + ex.Message);
            }

        }
        private static string RedShift_DBSelect()
        {

            string SQL = "  SELECT                                PS.PESSOA_KEY                                                                                     as cdpessoabluesoft " +
                              "                            ,     PS.CPF_CNPJ                                                                                       as cpf_cnpj " +
                              "                            ,     PS.NOME_RAZAO                                                                                     as nome_razao " +
                              "                            ,     PS.NOME_ABREVIADO                                                                                 as nome_abreviado " +
                              "                            ,     CASE WHEN COALESCE(PS.FISICA,'0') = 0 THEN 1 ELSE 0 END                                           as pessoajuridica " +
                              "                            ,     left(ISNULL(email_comercial, ''),60)                                                              as email_main " +
                              "                            ,     COALESCE(PS.DATA_CADASTRO, '1900-01-01')                                                          AS bluesoftpessoa_data_cadastro " +

                              "                            ,     CASE WHEN TRIM(COALESCE(sexo,'M')) = '' THEN 'M' ELSE COALESCE(sexo,'M') END                      as sexo  " +
                              "                            ,     COALESCE(data_nascimento, '1900-01-01')                                                           as data_nascimento " +

                              "                            ,     COALESCE(PS.CEP, 0 )                                                                              AS endereco_cep " +
                              "                            ,     COALESCE(PS.ENDERECO_RUA, '' )                                                                    AS endereco_logradouro " +
                              "                            ,     COALESCE(PS.ENDERECO_NUMERO, '0')                                                                 AS endereco_numero " +
                              "                            ,     COALESCE(PS.ENDERECO_COMPLEMENTO, '' )                                                            AS endereco_complemento " +
                              "                            ,     COALESCE(PS.BAIRRO, '' )                                                                          AS endereco_bairro " +
                              "                            ,     COALESCE(PS.MUNICIPIO, '' )                                                                       AS endereco_municipio " +
                              "                            ,     COALESCE(PS.ESTADO_SIGLA, '' )                                                                    AS endereco_uf " +
                              "                            ,     ISNULL(latitude,0)                                                                                as endereco_latitude " +
                              "                            ,     ISNULL(longitude,0)                                                                               as endereco_longitude        " +


                              "                            ,     CASE WHEN COALESCE(CL.CLIENTE_KEY,0) <> 0 THEN 1 else 0    end                                    as bluesoftcliente  " +
                              "                            ,     CASE WHEN COALESCE(VE.VENDEDOR_EXTERNO_KEY,0) <> 0 THEN 1 else 0 end                              as bluesoftvendedor      " +
                              "                            ,     CASE WHEN COALESCE(FO.FORNECEDOR_KEY,0) <> 0 THEN 1 else 0 end                                    as bluesoftfornecedor " +
                              "                            ,     CASE WHEN COALESCE(FA.FABRICANTE_KEY,0) <> 0 THEN 1 else 0 end                                    as bluesoftfabricante" +
                              "                            ,     COALESCE(GRUPO_ECONOMICO.GRUPO_ECONOMICO_KEY,0)                                                   AS cdgrupoeconomico " +
                              "                            ,     COALESCE(CLIENTE.VENDEDOR_EXTERNO_KEY,0)                                                          AS cdpessoabluesoft_vendedor" +
                              "                            ,     COALESCE(CL.bluesoftclientestatus,0)                                                              as bluesoftclientestatus " +
                              "                            ,     COALESCE(PS.STATUS,0)                                                                             AS bluesoftpessoastatus " +
                              "                            ,     COALESCE(CL.bluesoftcliente_creditolimite_valor,0)                                                AS bluesoftcliente_creditolimite_valor " +
                              "                            ,     COALESCE(CL.bluesoftcliente_creditolimite_valor_reservado,0)                                      AS bluesoftcliente_creditolimite_valor_reservado " +
                              "                            ,     COALESCE(CL.bluesoftcliente_creditostatus_cd,0)                                                   AS bluesoftcliente_creditostatus_cd " +
                              "                            ,     COALESCE(CL.bluesoftcliente_ramoatividade_cd,0)                                                   AS bluesoftcliente_ramoatividade_cd " +



                              "                    FROM        PESSOA PS" +
                              "                    LEFT JOIN   (     SELECT    FORNECEDOR_KEY        AS FORNECEDOR_KEY " +
                              "                                      FROM      FORNECEDOR_PRODUTO " +
                              "                                      GROUP BY  FORNECEDOR_KEY" +
                              "                                ) FO ON FO.FORNECEDOR_KEY = PS.PESSOA_KEY " +
                              "                    LEFT JOIN   (     SELECT    FABRICANTE_KEY        AS FABRICANTE_KEY" +
                              "                                      FROM      PRODUTO_D" +
                              "                                      GROUP BY  FABRICANTE_KEY" +
                              "                                ) FA ON FA.FABRICANTE_KEY = PS.PESSOA_KEY " +
                              "                    LEFT JOIN   (     SELECT    PESSOA_KEY        AS CLIENTE_KEY " +
                              "                                            ,   cast(CASE WHEN COALESCE(STATUS,'INATIVO') = 'INATIVO' THEN 0 ELSE 1 END as int) AS bluesoftclientestatus " +
                              "                                            ,   COALESCE(credito_limite,0)       AS bluesoftcliente_creditolimite_valor " +
                              "                                            ,   COALESCE(credito_usado,0)        AS bluesoftcliente_creditolimite_valor_reservado " +
                              "                                            ,   COALESCE(status_credito,0)       AS bluesoftcliente_creditostatus_cd " +
                              "                                            ,   COALESCE(ramo_atividade_key,0)   AS bluesoftcliente_ramoatividade_cd " +
                              "                                      FROM      CLIENTE" +

                              "                                ) CL ON CL.CLIENTE_KEY = PS.PESSOA_KEY " +
                              "                    LEFT JOIN   (   select VENDEDOR_EXTERNO_KEY  as VENDEDOR_EXTERNO_KEY FROM GRUPO_ECONOMICO_COMISSAO GROUP BY VENDEDOR_EXTERNO_KEY ) VE ON VE.VENDEDOR_EXTERNO_KEY = PS.PESSOA_KEY " +
                              "                    LEFT JOIN  ( SELECT      PS.PESSOA_KEY                   AS CLIENTE_KEY " +
                              "                                         ,   CG.GRUPO_ECONOMICO_KEY          AS GRUPO_ECONOMICO_KEY " +
                              "                                         ,   MIN(GM.VENDEDOR_EXTERNO_KEY)    AS VENDEDOR_EXTERNO_KEY " +
                              "                                 FROM        PESSOA  PS " +
                              "                                 INNER JOIN  CLIENTE_GRUPO_ECONOMICO     CG ON CG.CLIENTE_KEY = PS.PESSOA_KEY " +
                              "                                 INNER JOIN  GRUPO_ECONOMICO_COMISSAO    GM ON GM.CLIENTE_GRUPO_ECONOMICO_KEY = CG.CLIENTE_GRUPO_ECONOMICO_KEY " +
                              "                                 GROUP BY    PS.PESSOA_KEY " +
                              "                                         ,   CG.GRUPO_ECONOMICO_KEY " +
                              "                               ) CLIENTE ON CLIENTE.CLIENTE_KEY = PS.PESSOA_KEY " +
                              "                    LEFT JOIN  ( SELECT       PS.PESSOA_KEY                   AS CLIENTE_KEY " +
                              "                                          ,   CG.GRUPO_ECONOMICO_KEY          AS GRUPO_ECONOMICO_KEY " +
                              "                                 FROM        PESSOA  PS " +
                              "                                 INNER JOIN  CLIENTE_GRUPO_ECONOMICO     CG ON CG.CLIENTE_KEY = PS.PESSOA_KEY " +
                              "                                 GROUP BY    PS.PESSOA_KEY                                          ,   CG.GRUPO_ECONOMICO_KEY " +
                              "                                ) GRUPO_ECONOMICO ON GRUPO_ECONOMICO.CLIENTE_KEY = PS.PESSOA_KEY     " +
                              "                     WHERE 1 = 1 " +
                              "                       AND ps.pessoa_key <> 0 " +
                              "                       AND coalesce( ps.cpf_cnpj, '') != '' " +
                              "                       AND coalesce( ps.cpf_cnpj, '') != '0' " +
                              "                       AND coalesce( ps.cpf_cnpj, '') != '00000000000000' " +
                              "                       AND coalesce( ps.cpf_cnpj, '') != '00000000000' " +
                              "                     ORDER BY PS.PESSOA_KEY ASC ";
            return SQL;


        }
        private static string PostGre_DBInsert(        
            BDCommandTypes BDCommnadType,
            ModelParticipante ITEM
            )
        {

            string SQL_POSTGRE = "";
            try
            {
                SQL_POSTGRE =
                         "SELECT * FROM " + F0011_90_Participante_BlueSoft_Integ._VERSION() +
                         " (   sqlcommand:= '" + BDCommnadType.ToString() + "' " +
                         "  , vcdpessoabluesoft:= " + ITEM.cdpessoabluesoft.ToString() +
                         "  , vcpf_cnpj:= '" + ITEM.cpf_cnpj.ToString() + "' " +
                         "  , vnome_razao:= '" + ITEM.nome_razao.ToString() + "' " +
                         "  , vpessoajuridica:= " + ITEM.pessoajuridica.ToString() +
                         "  , vemail_main:= '" + ITEM.email_main.ToString() + "' " +
                         "  , vnome_abreviado:= '" + ITEM.nome_abreviado.ToString() + "' " +
                         "  , vpf_sexo:= '" + ITEM.ParticipantePf.pf_sexo.ToString() + "' " +
                         "  , vpf_data_nascimento:= '" + ITEM.ParticipantePf.pf_data_nascimento.ToString("yyyy-MM-d") + "' " +
                         "  , vendereco_cep:= " + ITEM.ListParticipanteEndereco[0].endereco_cep.ToString() +
                         "  , vendereco_logradouro:= '" + ITEM.ListParticipanteEndereco[0].endereco_logradouro.ToString().Replace("'", "`") + "' " +
                         "  , vendereco_numero:= '" + ITEM.ListParticipanteEndereco[0].endereco_numero.ToString().Replace("'", "`") + "' " +
                         "  , vendereco_complemento:= '" + ITEM.ListParticipanteEndereco[0].endereco_complemento.ToString().Replace("'", "`") + "' " +
                         "  , vendereco_bairro:= '" + ITEM.ListParticipanteEndereco[0].endereco_bairro.ToString().Replace("'", "`") + "' " +
                         "  , vendereco_municipio:= '" + ITEM.ListParticipanteEndereco[0].endereco_municipio.ToString().Replace("'", "`") + "' " +
                         "  , vendereco_uf:= '" + ITEM.ListParticipanteEndereco[0].endereco_uf.ToString().Replace("'", "`") + "' " +
                         "  , vendereco_latitude:= " + ITEM.ListParticipanteEndereco[0].endereco_latitude.ToString("0.00").Replace(",", ".") +
                         "  , vendereco_longitude:=" + ITEM.ListParticipanteEndereco[0].endereco_longitude.ToString("0.00").Replace(",", ".") +
                         "  , vbluesoft_pessoa_status:= " + ITEM.ParticipanteBlueSoft.bluesoft_pessoa_status.ToString() +
                         "  , vbluesoft_pessoa_data_cadastro:= '" + ITEM.ParticipanteBlueSoft.bluesoft_pessoa_data_cadastro.ToString("yyyy-MM-dd") + "' " +
                         "  , vbluesoftcliente:= " + ITEM.ParticipanteBlueSoft.bluesoftcliente.ToString() +
                         "  , vbluesoftvendedor:= " + ITEM.ParticipanteBlueSoft.bluesoftvendedor.ToString() +
                         "  , vbluesoftfornecedor:= " + ITEM.ParticipanteBlueSoft.bluesoftfornecedor.ToString() +
                         "  , vbluesoftfabricante:= " + ITEM.ParticipanteBlueSoft.bluesoftfabricante.ToString() +
                         "  , vbluesoftmotorista:= " + ITEM.ParticipanteBlueSoft.bluesoftmotorista.ToString() +
                         "  , vcdgrupoeconomico:= " + ITEM.ParticipanteBlueSoft.cdgrupoeconomico.ToString() +
                         "  , vcdpessoabluesoft_vendedor:= " + ITEM.ParticipanteBlueSoft.cdpessoabluesoft_vendedor.ToString() +
                         "  , vbluesoftclientestatus:= " + ITEM.ParticipanteBlueSoft.bluesoftclientestatus.ToString() +
                         "  , vbluesoftcliente_creditolimite_valor:= " + ITEM.ParticipanteBlueSoft.bluesoftcliente_creditolimite_valor.ToString("0.00").Replace(",", ".") +
                         "  , vbluesoftcliente_creditolimite_valor_reservado:= " + ITEM.ParticipanteBlueSoft.bluesoftcliente_creditolimite_valor_reservado.ToString("0.00").Replace(",", ".") +
                         "  , vbluesoftcliente_creditostatus_cd:= " + ITEM.ParticipanteBlueSoft.bluesoftcliente_creditostatus_cd.ToString() +
                         "  , vbluesoftcliente_ramoatividade_cd:= " + ITEM.ParticipanteBlueSoft.bluesoftcliente_ramoatividade_cd.ToString() +
                         ")";

                return SQL_POSTGRE;

            }
            catch (Exception ex)
            {
                throw new Exception(" Participante_BlueSoft \n PostGre_DBInsert \n " + ex.Message + "\n Script SQL INSERT" + SQL_POSTGRE);
            }

        }

    }
}
