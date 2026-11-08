
using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace Pag_Net.Bll.F0135_Trasnporte_Ctrl
{


    public class Wk_Transporte_Ctrl: Pag_Net.Bll.F0130_Controle.iWK_Controle
    {




        /*Class Works*/
        private Pag_Net.Bll.F0131_Veiculo.Wk WKVeiculo;

        /*Arrays */
        public Pag_Net.Bll.F0131_Veiculo.TbVeiculoModelo[] Modelos_Veiculos;

        /*MyConnect */
        public Pag_Net.Models.modelSistemaUsuario MyConnect;

        /*Model*/
        public Model_Transporte_Ctrl Transporte_Ctrl;

        /*Public */
        public Wk_Transporte_Ctrl(Pag_Net.Models.modelSistemaUsuario _MyConnect): base(_MyConnect, 10)
        {
            MyConnect = _MyConnect;

            /*Assinaturas*/
            WKVeiculo = new F0131_Veiculo.Wk(MyConnect);
            
            /*Tipos Locais*/
            Modelos_Veiculos = WKVeiculo.VeiculoModelos_Get();

            /*Assinatura de Models*/
            Transporte_Ctrl = new Model_Transporte_Ctrl();

            
            Transporte_Ctrl.Binding(MyConnect);

        }

        public override void Binding()
        {
            Transporte_Ctrl.Binding(MyConnect);
        }

        public override void Save()
        {
            Transporte_Ctrl.Save(MyConnect);
        }



    }
    public class Model_Transporte_Ctrl : TbTransporte_Ctrl
    {
        public Pag_Net.Bll.F0130_Controle.model_controle_reg Controle_Reg;
        public Pag_Net.Bll.F0131_Veiculo.TbVeiculo Veiculo;
        public Pag_Net.Bll.F0130_Controle.model_controle_reg_pessoa Motorista;
        public Pag_Net.Bll.F0130_Controle.model_controle_reg_pessoa Transportadora;
        public Pag_Net.Bll.F0135_Trasnporte_Ctrl.Model_Transporte_Ctrl_DocumentosFiscais[] DocumentosFiscais;

        public Pag_Net.Bll.F0060_DocumentoFiscal.ModelDocumentoFiscalRegistro Transporte_Ctrl_DocumentoFiscal_Lancamento { get; set; }


        public Model_Transporte_Ctrl(): base()
        {

            Model_Constructor();
            //Transportadora = new F0130_Controle.model_controle_reg_pessoa(0, 91001, "Fornecedor");
            //Motorista = new F0130_Controle.model_controle_reg_pessoa(0, 91002, "Motorista");
            

        }

        public void Model_Constructor()
        {
            this.controle_reg_seq = 0;
            this.pallet_qtde = 0;
            this.pallet_valor_unitario = 0;
            this.tranporte_Ctrl_Seq = 0;
            this.veiculo_seq = 0;
            Veiculo = new F0131_Veiculo.TbVeiculo();
            Controle_Reg = new F0130_Controle.model_controle_reg(10);
        }
        public Model_Transporte_Ctrl(int _controle_reg_seq, int _transporte_ctrl_seq, int _veiculo_seq, int _pallet_qtde, double _pallet_valor_unitario)
            : base(_controle_reg_seq, _transporte_ctrl_seq, _veiculo_seq, _pallet_qtde, _pallet_valor_unitario) 
        { 
        
            
        
        }

        public Model_Transporte_Ctrl(DataRow i) : base(i) { }

        public void NEW(Pag_Net.Models.modelSistemaUsuario MyConnect, string _Transporte_Ctrl_DocumentoFiscal_Lancamento)
        {
            Transporte_Ctrl_DocumentoFiscal_Lancamento.dfr_nf_chave = _Transporte_Ctrl_DocumentoFiscal_Lancamento;
            
        }

        public void Binding(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                Controle_Reg.Binding(MyConnect, Controle_Reg.Controle);

                if (Controle_Reg.controle_reg_seq != 0)
                {

                    DataTable DataTable_Transporte_CTRL = BDCommand.get_DataTable(MyConnect, F0135_10_Transporte_Ctrl_Consultar.Get(this.Controle_Reg.controle_reg_seq, 0));
                    this.pallet_qtde = Convert.ToInt32(DataTable_Transporte_CTRL.Rows[0]["pallet_qtde"].ToString());
                    this.pallet_valor_unitario = Convert.ToDouble(DataTable_Transporte_CTRL.Rows[0]["pallet_valor_unitario"].ToString());
                    this.veiculo_seq = Convert.ToInt32(DataTable_Transporte_CTRL.Rows[0]["veiculo_seq"].ToString());
                    this.Veiculo.veiculo_placa = DataTable_Transporte_CTRL.Rows[0]["veiculo_placa"].ToString();
                    this.Veiculo.veiculo_seq = Convert.ToInt32(DataTable_Transporte_CTRL.Rows[0]["veiculo_seq"].ToString());
                }


                
                Transportadora = Controle_Reg.Pessoa_Get(91001);
                Motorista = Controle_Reg.Pessoa_Get(91002);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

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


                Controle_Reg.Update(MyConnect);
                this.controle_reg_seq = Controle_Reg.controle_reg_seq;

                BDCommand.get_DataTable(MyConnect,
                    F0135_01_Transporte_Ctrl_CRUD.Post(MyConnect,
                                                            Models.BDCommandTypes.DBINSERT, this));
                
                Update_DocumentosFiscais_Etapa_list(MyConnect);


                

                /*Lancamento de Cobrança de Serviço Inicial */
                if (this.pallet_qtde > 0 && this.pallet_valor_unitario > 0)
                {
                    this.Controle_Reg.Set_Fin_Add(MyConnect, string.Format("Operação com o Controle N. {0}", this.Controle_Reg.controle_reg_seq.ToString()), 1, new Pag_Net.src.F0080_Financeiro.tbs.TbFin_Forma_Pgto(0), 0, this.pallet_qtde * this.pallet_valor_unitario); 
                }


                if (Controle_Reg.Etapa_Atual_Get().controle_etapa_cd == 10001)
                {
                    Notificar(MyConnect, 10001, 1);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update_DocumentosFiscais_Etapa_list(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            foreach (Model_Transporte_Ctrl_DocumentosFiscais TransporteDocumentoFiscal in DocumentosFiscais)
            {
                try
                {
                    Model_Transporte_Ctrl_DocumentoFiscal_Etapa ItemDocumentoFiscal = new Model_Transporte_Ctrl_DocumentoFiscal_Etapa();


                    ItemDocumentoFiscal.controle_reg_seq = this.Controle_Reg.controle_reg_seq;
                    ItemDocumentoFiscal.controle_reg_etapa_seq = Controle_Reg.Etapa_Atual_Get().controle_reg_etapa_seq;
                    ItemDocumentoFiscal.dfr_seq = TransporteDocumentoFiscal.dfr_seq;
                    ItemDocumentoFiscal.dfr_nf_numero = TransporteDocumentoFiscal.dfr_nf_numero;
                    ItemDocumentoFiscal.dfr_nf_serie = TransporteDocumentoFiscal.dfr_nf_serie;
                    ItemDocumentoFiscal.dfr_data_registro = TransporteDocumentoFiscal.dfr_data_registro;
                    ItemDocumentoFiscal.Save(MyConnect);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void DocumentoFiscal_add(Pag_Net.Models.modelSistemaUsuario MyConnect, Pag_Net.Bll.F0060_DocumentoFiscal.ModelDocumentoFiscalRegistro _DocumentoFiscalRegistro)
        {
            try
            {

                _DocumentoFiscalRegistro.DbInsert(MyConnect);
                if (_DocumentoFiscalRegistro.dfr_seq == 0)
                {
                    throw new Exception("Erro: Erro na inclusão da Nota Fiscal \n Function DocumentoFiscal_add");
                }

                List<Model_Transporte_Ctrl_DocumentosFiscais> _ListDocumentoFiscalEtapa = new List<Model_Transporte_Ctrl_DocumentosFiscais>();
                if (DocumentosFiscais != null)
                {
                    foreach (Model_Transporte_Ctrl_DocumentosFiscais itemDocumentoFiscal_Etapa in DocumentosFiscais)
                    {
                        _ListDocumentoFiscalEtapa.Add(itemDocumentoFiscal_Etapa);
                    }
                }

                Pag_Net.Bll.F0130_Controle.model_controle_reg_Etapa Etapa_Atual = Controle_Reg.Etapa_Atual_Get();

                Model_Transporte_Ctrl_DocumentosFiscais DocumentoExiste = _ListDocumentoFiscalEtapa.Find(x => x.dfr_seq == _DocumentoFiscalRegistro.dfr_seq);
                if (DocumentoExiste == null)
                {
                    _ListDocumentoFiscalEtapa.Add(new Model_Transporte_Ctrl_DocumentosFiscais(_DocumentoFiscalRegistro.dfr_seq, this.Controle_Reg.controle_reg_seq, Etapa_Atual.controle_reg_etapa_seq));
                }


                DocumentosFiscais = _ListDocumentoFiscalEtapa.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Controle_Ctrl_Update_Etapa_Step(Pag_Net.Models.modelSistemaUsuario MyConnect, int Etapa_a_CONSIDERAR)
        {
            try
            {
                Controle_Reg.Etapa_Atual_Get();
                Controle_Reg.Etapa_Proxima_Get();

                int status_ctrl_transporte = this.Controle_Reg.controle_status_cd;

                if (Etapa_a_CONSIDERAR == 0)
                    Etapa_a_CONSIDERAR = this.Controle_Reg.Local_controle_etapa_cd_proxima;

                if (Etapa_a_CONSIDERAR > this.Controle_Reg.controle_etapa_cd_final)
                {
                    throw new Exception("Não há mais etapa a ser processada");

                }

                if (Etapa_a_CONSIDERAR == 10010) 
                {
                    if (status_ctrl_transporte == 1)
                        status_ctrl_transporte = 2;
                }
                
                this.Controle_Reg.Update_Etapa(MyConnect, this.Controle_Reg.controle_etapa_cd_atual, Etapa_a_CONSIDERAR, status_ctrl_transporte);

                Notificar(MyConnect, Etapa_a_CONSIDERAR, status_ctrl_transporte);
                
                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Controle_Ctrl_Update_Negar(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                Controle_Reg.Etapa_Atual_Get();
                Controle_Reg.Etapa_Proxima_Get();

                if (Controle_Ctrl_Update_Validar(MyConnect, 10009, 4))
                {
                    this.Controle_Reg.Update_Etapa(MyConnect, this.Controle_Reg.controle_etapa_cd_atual, 10009, 4);
                    Notificar(MyConnect, 10009, 4);
                }
                else
                {
                    throw new Exception("Erro: Registro não Pode ser Negado, favor fazer nova consulta");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Controle_Ctrl_Update_Negar_Recebimento(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                Controle_Reg.Etapa_Atual_Get();
                Controle_Reg.Etapa_Proxima_Get();

                if (Controle_Ctrl_Update_Validar(MyConnect, 10009, 5))
                {
                    this.Controle_Reg.Update_Etapa(MyConnect, this.Controle_Reg.controle_etapa_cd_atual, 10009, 5);
                    Notificar(MyConnect, 10009, 5);
                }
                else
                {
                    throw new Exception("Erro: Registro não Pode ser Negado, favor fazer nova consulta");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Controle_Ctrl_Update_Status_Pgto(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {

                int controle_status_cd = 3; //ISENTO
                if (this.Controle_Reg.Financeiro_Total_Debito != 0)
                {
                    controle_status_cd = 1;
                }

                if (this.Controle_Reg.Financeiro_Total_Saldo == 0 && this.Controle_Reg.Financeiro_Total_Debito != 0)
                {
                    controle_status_cd = 2;
                }
                this.Controle_Reg.Update_Status_Pgto(MyConnect, controle_status_cd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public bool Controle_Ctrl_Update_Validar(Pag_Net.Models.modelSistemaUsuario MyConnect, int Controle_Etapa_CD_NEW, int Controle_Status_cd_NEW)
        {

            try
            {
                bool __Processo_Permitido = false;

                int CONTROLE_STATUS_ATUAL = Controle_Reg.controle_status_cd;
                int CONTROLE_ETAPA_CD_ATUAL = Controle_Reg.Etapa_Atual_Get().controle_etapa_cd;


                if (CONTROLE_STATUS_ATUAL > 1)
                {
                    __Processo_Permitido = false;
                }
                else
                {

                    if (CONTROLE_STATUS_ATUAL == 1 && CONTROLE_ETAPA_CD_ATUAL == 10002 && Controle_Status_cd_NEW == 1) __Processo_Permitido = true;
                    if (CONTROLE_STATUS_ATUAL == 1 && CONTROLE_ETAPA_CD_ATUAL == 10003 && Controle_Status_cd_NEW == 1) __Processo_Permitido = true;
                    if (CONTROLE_STATUS_ATUAL == 1 && CONTROLE_ETAPA_CD_ATUAL == 10004 && Controle_Status_cd_NEW == 1) __Processo_Permitido = true;
                    if (CONTROLE_STATUS_ATUAL == 1 && CONTROLE_ETAPA_CD_ATUAL == 10005 && Controle_Status_cd_NEW == 1) __Processo_Permitido = true;
                    if (CONTROLE_STATUS_ATUAL == 1 && CONTROLE_ETAPA_CD_ATUAL == 10006 && Controle_Status_cd_NEW == 1) __Processo_Permitido = true;
                    if (CONTROLE_STATUS_ATUAL == 1 && CONTROLE_ETAPA_CD_ATUAL == 10007 && Controle_Status_cd_NEW == 1) __Processo_Permitido = true;
                    if (CONTROLE_STATUS_ATUAL == 1 && CONTROLE_ETAPA_CD_ATUAL == 10008 && Controle_Status_cd_NEW == 1) __Processo_Permitido = true;
                    if (CONTROLE_STATUS_ATUAL == 1 && CONTROLE_ETAPA_CD_ATUAL == 10009 && Controle_Status_cd_NEW == 1) __Processo_Permitido = true;
                    if (CONTROLE_STATUS_ATUAL == 1 && CONTROLE_ETAPA_CD_ATUAL == 10010 && Controle_Status_cd_NEW == 1) __Processo_Permitido = false;

                    if (CONTROLE_STATUS_ATUAL == 1 && CONTROLE_ETAPA_CD_ATUAL == 10002 && Controle_Status_cd_NEW == 4) __Processo_Permitido = true;
                    if (CONTROLE_STATUS_ATUAL == 1 && CONTROLE_ETAPA_CD_ATUAL == 10006 && Controle_Status_cd_NEW == 5) __Processo_Permitido = true;
                }

                return __Processo_Permitido;
            }

            catch (Exception ex)
            {
                return false;
            }

        }

        public bool Validar()
        {
            bool Validado = false;
            try
            {
                if (Controle_Reg.controle_cd == 0) { throw new Exception("Tipo de Controle NÃO informado"); }
                if (Controle_Reg.Fila.controle_fila_cd == 0) { throw new Exception ( "Fila NÃO informada"); }
                if (Transportadora.nome_razao == "") { throw new Exception("Razão Social da Transportadora NÃO informada"); }
                if (Transportadora.cpf_cnpj == "") { throw new Exception("CNPJ da Transportadora  NÃO informada"); }
                if (Motorista.nome_razao == "") { throw new Exception("Nome do Motorista não informado"); }
                if (Motorista.cpf_cnpj == "") { throw new Exception("CPF do Motorista  NÃO informada"); }
                if (DocumentosFiscais == null) { throw new Exception("Tabela de Documentos Fiscais não preenchida"); }
                if (DocumentosFiscais.Count() < 1) { throw new Exception("Tabela de Documentos Fiscais não preenchida"); }
                Validado = true;
                return Validado;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Model_Transporte_Ctrl_DocumentosFiscais[] DocumentosFiscaisLancados(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                List<Model_Transporte_Ctrl_DocumentosFiscais> listModel_Transporte_Ctrl_DocumentoFiscal_Etapa = new List<Model_Transporte_Ctrl_DocumentosFiscais>();

                DataTable dttableModel_Transporte_Ctrl_DocumentoFiscal_Etapa = BDCommand.get_DataTable(MyConnect,
                       F0135_20_Transporte_Ctrl_Documentofiscal_list.Get(0, this.Controle_Reg.controle_reg_seq, 0));
 
                foreach(DataRow i in dttableModel_Transporte_Ctrl_DocumentoFiscal_Etapa.Rows )
                {
                    listModel_Transporte_Ctrl_DocumentoFiscal_Etapa.Add(new Model_Transporte_Ctrl_DocumentosFiscais(i));
                }

                DocumentosFiscais = listModel_Transporte_Ctrl_DocumentoFiscal_Etapa.ToArray();

                return DocumentosFiscais;

                //return BDCommand.get_DataTable(MyConnect,
                  //     F0135_20_Transporte_Ctrl_Documentofiscal_list.Get(0, this.Controle_Reg.controle_reg_seq, 0));


            }
            catch (Exception EX)
            {
                throw new Exception(EX.Message);
            }
            
        }

        public void ImprimirRecibo_DarumaDR700(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {

                this.Controle_Reg.Binding_Fin(MyConnect);
                if (this.Controle_Reg.Financeiro_Total_Debito == 0)
                    throw new Exception("Impressão do Recibo não permitida - Não Existe Lançamentos de Serviços/Produtos");

                if (this.Controle_Reg.Financeiro_Total_Saldo < 0 && this.Controle_Reg.Financeiro_Total_Debito != 0)
                    throw new Exception("Impressão do Recibo não permitida - Pagamentos insuficientes");

                string crlf = Convert.ToChar(13).ToString() + Convert.ToChar(10).ToString();
                string command = "<W>_____________________________________________" + crlf +
                                 "OXAN Atacadista Ltda | 57.895.328/0001-30 " + crlf +
                                 DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + crlf +
                                 "------------------------------------------------" + crlf +
                                "Av. Rio das Pedras, 729" + crlf +
                                "Bairro: Jd. Aricanduva" + crlf +
                                "Sao Paulo - CEP 03453000" + crlf +
                                "------------------------------------------------" + crlf +
                                "Controle de Recebimentos N. " + this.Controle_Reg.controle_reg_seq.ToString() + crlf +
                                "------------------------------------------------" + crlf +
                                "" + crlf +
                                "Fornecedor: " + this.Transportadora.nome_razao.ToString() + crlf +
                                "CNPJ......: " + this.Transportadora.cpf_cnpj.ToString() + crlf +
                                "------------------------------------------------" + crlf +
                                "" + crlf +
                                "-> DOCUMENTOS FISCAIS" + crlf;
                                

                  foreach (Model_Transporte_Ctrl_DocumentosFiscais ITEMR in this.DocumentosFiscaisLancados(MyConnect))
                  {
                      command += "N. NF " + ITEMR.dfr_nf_numero.ToString() + crlf;
                  }


                  command += crlf +
                              "------------------------------------------------" + crlf +
                              "" + crlf +
                              "-> EXTRATO DE LANCAMENTOS" + crlf;



                foreach (F0130_Controle.model_controle_reg_fin localITEM_Controle_reg_fin in this.Controle_Reg.Financeiro_Debitos)
                {
                    string localStr_Descritivo = localITEM_Controle_reg_fin.controle_reg_fin_descritivo;
                    if (localStr_Descritivo.Length > 24)
                        localStr_Descritivo = localStr_Descritivo.Substring(0, 24);
                    command += "(" + localITEM_Controle_reg_fin.controle_reg_fin_valor.ToString("000.00") + ") _ " + localStr_Descritivo.ToUpper().Replace("Ç", "C").Replace("Ã", "A") + crlf;
                }
                command += "" + crlf;

                command += "------------------------------------------------" + crlf;
                


                command += "-> PAGAMENTOS" + crlf; ;

                foreach (F0130_Controle.model_controle_reg_fin localITEM_Controle_reg_fin in this.Controle_Reg.Financeiro_Creditos)
                {
                    string localStr_Descritivo = localITEM_Controle_reg_fin.fin_forma_pgto_descricao;
                    if (localStr_Descritivo.Length > 24)
                        localStr_Descritivo = localStr_Descritivo.Substring(0, 24);
                    command += localITEM_Controle_reg_fin.controle_reg_fin_valor.ToString("000.00") + " _ " + localStr_Descritivo.ToUpper().Replace("Ç", "C").Replace("Ã", "A").Replace("É", "E") + crlf;
                }
                command += "" + crlf;
                command += "------------------------------------------------" + crlf;
                command += "Valor Total Recebido...............: R$" + this.Controle_Reg.Financeiro_Total_Credito.ToString("###,##0.00") + crlf;

                command += "________________________________________________" + crlf;
                command += Pag_Net.Tools.Calculo.NumberText.toExtenso(Convert.ToDecimal(this.Controle_Reg.Financeiro_Total_Credito)) + crlf; ;

                command += "Assinatura / Carimbo" + crlf;
                command += "" + crlf;
                command += "" + crlf; 
                command += "_____________________FIM________________________" + crlf;
                command += Pag_Net.Models.PagInfo.VERSAO.ToString() + crlf;
                command += "" + crlf;
                command += "" + crlf;
                command += "" + crlf;
                command += ".</W>" + crlf;
                Pag_Net.Tools.PrinterLpt1.Print(MyConnect.User_environment, command, "LPT3");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Notificar(Pag_Net.Models.modelSistemaUsuario MyConnect, int ETAPA, int STATUS)
        {
            try
            {
                try
                {
                    bool MessageEnviar = false;
                    string Message = "";

                    string NOME_MOTORISTA = "Motorista";
                    if (this.Motorista.nome_razao.Trim() != "")
                    {
                         NOME_MOTORISTA = this.Motorista.nome_razao;
                    }

                    if (NOME_MOTORISTA.IndexOf(" ") > 0)
                    NOME_MOTORISTA = NOME_MOTORISTA.Remove(NOME_MOTORISTA.IndexOf(" "));

                    int CONTROLE_REG_SEQ = this.Controle_Reg.controle_reg_seq;
                    int CONTROLE_REG_NUMERO = Controle_Reg.controle_reg_numero;




                    if (ETAPA == 10001 && STATUS == 1)
                    {
                        Message = string.Format("*OXAN Entrega {1} N. Ordem {2}* \n Olá {0}, \n " +
                                           "Já realizamos o registro de sua entrega em nosso sistema. " +
                                           "À partir desse momento nossa equipe está empenhada para realizar todos os procedimentos pré recebimento. " +
                                           "*Pedimos a gentileza de aguardar as próximas instruções através deste mesmo canal.* \n" 
                                             ,
                                                           NOME_MOTORISTA,
                                                           CONTROLE_REG_SEQ.ToString(),
                                                           CONTROLE_REG_NUMERO.ToString()
                                                           );
                        MessageEnviar = true;
                    }
                    if (ETAPA == 10005 && STATUS == 1)
                    {
                        Message = string.Format("*OXAN Entrega {1} N. Ordem {2}* \n Ola {0} Retornamos com boas notícias, sua entrega foi aprovada e nossa equipe de recebimento já está lhe aguardando. \n " +
                                                     "*Por gentileza, dirija-se com seu veículo até nossa portaria, lá eles irão lhe auxiliar.* ",
                                                           NOME_MOTORISTA,
                                                           CONTROLE_REG_SEQ.ToString(),
                                                           CONTROLE_REG_NUMERO.ToString()
                                                           );
                        MessageEnviar = true;
                    }

                    if (ETAPA == 10009 && STATUS == 4)
                    {
                        Message = string.Format("*OXAN Entrega {1} N. Ordem {2}* \n Ola {0} Poxa, algo deu errado com sua entrega. \n " +
                            "*Por gentileza dirija-se a nossa portaria sem o seu veículo para maiores esclarecimentos*",
                                                           NOME_MOTORISTA,
                                                           CONTROLE_REG_SEQ.ToString(),
                                                           CONTROLE_REG_NUMERO.ToString()
                                                           );
                        MessageEnviar = true;
                    }

                    if (ETAPA == 10009 && STATUS == 1)
                    {
                        Message = string.Format("*OXAN Entrega {1} N. Ordem {2}* \n Ola {0}. # Show !!! \n " +
                                              "*Seu processo de entrega de mercadoria foi finalizado com sucesso.* O Oxan agradece pela parceria, até a próxima. \n Boa viagem",
                                                           NOME_MOTORISTA,
                                                           CONTROLE_REG_SEQ.ToString(),
                                                           CONTROLE_REG_NUMERO.ToString()
                                                           );
                        MessageEnviar = true;
                    }

                    if (MessageEnviar)
                    {
                        int marketing_cd = 0;

                        if (ETAPA == 10001) marketing_cd = 1;
                        if (ETAPA == 10009) marketing_cd = 2;

                            Pag_Net.src.F0210_Notificacao.Notificacao.startWhatsAPP(MyConnect, 1100135005, Pag_Net.src.F0210_Notificacao.TipoMensagem.PortariaWhats, Motorista.celular_dd, Motorista.celular_numero, Message, marketing_cd);


                    }
                }
                catch (Exception ex) 
                {
                    throw new Exception("Transporte CTL | Notificação " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    public class Model_Transporte_Ctrl_DocumentoFiscal_Etapa: Tbtransporte_Ctrl_DocumentoFiscal_Etapa
    {
        public int dfr_nf_numero {get;set; }
        public int dfr_nf_serie {get;set; }
        public DateTime dfr_nf_data_emissao {get;set; }
        public DateTime dfr_data_registro { get; set; }

        public Model_Transporte_Ctrl_DocumentoFiscal_Etapa () 
        {
            this.controle_reg_seq = 0;
        }

        public Model_Transporte_Ctrl_DocumentoFiscal_Etapa(int _dfr_seq, int _transporte_ctrl_seq, int _controle_reg_etapa_seq) : base( _dfr_seq, _transporte_ctrl_seq, _controle_reg_etapa_seq) {}

        public Model_Transporte_Ctrl_DocumentoFiscal_Etapa(DataRow i) : base(i) 
        {
            this.dfr_seq = Convert.ToInt32(i["dfr_seq"].ToString());
            this.controle_reg_etapa_seq = Convert.ToInt32(i["controle_reg_etapa_seq"].ToString());
            this.controle_reg_seq = Convert.ToInt32(i["transporte_ctrl_seq"].ToString());
        }

        public void Save(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                BDCommand.get_DataTable(MyConnect,
                    F0135_02_Transporte_Ctrl_Documentofiscal_Etapa_CRUD.Post(MyConnect,
                                                            Models.BDCommandTypes.DBINSERT, this));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
    public class Model_Transporte_Ctrl_DocumentosFiscais: Pag_Net.Bll.F0060_DocumentoFiscal.ModelDocumentoFiscalRegistro
    {
        /*public int dfr_seq { get; set;  }
        public int controle_reg_seq { get; set;  }
        public int dfr_nf_numero { get; set;  }
        public int dfr_nf_serie { get; set;  }
        public DateTime dfr_nf_data_emissao { get; set;  }
        public DateTime dfr_data_registro { get; set;  }
        public string dfr_nf_chave { get; set;  }*/
        public int etapa_count { get; set;  }
        public int controle_reg_etapa_seq { get; set;  }

        public Model_Transporte_Ctrl_DocumentosFiscais() { }
        public Model_Transporte_Ctrl_DocumentosFiscais
            (
                int _dfr_seq ,
                int _controle_reg_seq,
                int _controle_reg_etapa_seq
            ) 
        {
            this.dfr_seq = _dfr_seq;
            controle_reg_seq = _controle_reg_seq;
            controle_reg_etapa_seq = _controle_reg_etapa_seq;
        
        }
        public Model_Transporte_Ctrl_DocumentosFiscais(DataRow i) 
        {
            dfr_seq = Convert.ToInt32(i["dfr_seq"].ToString());
            controle_reg_seq =Convert.ToInt32( i["controle_reg_seq"].ToString());
            dfr_nf_numero = Convert.ToInt32(i["dfr_nf_numero"].ToString());
            dfr_nf_serie =Convert.ToInt32( i["dfr_nf_serie"].ToString());
            dfr_nf_data_emissao = Convert.ToDateTime(i["dfr_nf_data_emissao"].ToString());
            dfr_data_registro = Convert.ToDateTime(i["dfr_data_registro"].ToString());
            dfr_nf_chave = i["dfr_nf_chave"].ToString();
            etapa_count = Convert.ToInt32(i["etapa_count"].ToString());

        }
    }
}
