using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle
{
    public class model_controle_reg : TbControle_Reg
    {


        /*Fildes --------------------------------------------------------------------------------------------*/
        public DateTime dtlog_insert { get; set; }
        public DateTime dtlog_update { get; set; }
        public string MODEL_controle_descricao
        {
            get
            {
                return Controle.controle_descricao;
            }
            set
            {
                Controle.controle_descricao = value.ToString();
            }
        }
        public string controle_status_descricao { get; set; }
        public string controle_status_pgto_descricao { get; set; }
        public int controle_reg_etapa_seq_atual { get; set; }
        public int controle_etapa_cd_atual { get; set; }
        public string controle_etapa_descricao_atual { get; set; }
        public int controle_etapa_cd_final { get; set; }
        public int Local_controle_reg_etapa_seq_proxima { get; set; }
        public int Local_controle_etapa_cd_proxima { get; set; }
        public string Local_controle_etapa_descricao_proxima { get; set; }






        /*Objects ------------------------------------------------------------------------------------------*/
        public model_controle Controle;
        public model_controle_reg_fila Fila;
        public model_controle_reg_pessoa[] Pessoas;
        public model_controle_reg_Etapa[] Etapas;
        public model_controle_reg_documentofiscal_etapa[] DocumentoFiscais_Etapa;
        public model_controle_reg_fin[] Financeiro_Lancamentos;
        public model_controle_reg_obs[] Controle_Reg_Obs;

        public double Financeiro_Total_Debito
        {
            get
            {
                try
                {
                    double ValorTotalDebito = 0;
                    foreach (model_controle_reg_fin item in Financeiro_Debitos)
                        ValorTotalDebito += item.controle_reg_fin_valor;
                    return ValorTotalDebito;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public double Financeiro_Total_Credito
        {
            get
            {
                try
                {
                    double ValorTotalDebito = 0;
                    foreach (model_controle_reg_fin item in Financeiro_Creditos)
                        ValorTotalDebito += item.controle_reg_fin_valor;
                    return ValorTotalDebito;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public double Financeiro_Total_Saldo
        {
            get
            {
                return Financeiro_Total_Credito + Financeiro_Total_Debito;
            }
        }
        public model_controle_reg_fin[] Financeiro_Debitos
        {
            get
            {
                return Controle_Fin_Get("D");
            }
        }
        public model_controle_reg_fin[] Financeiro_Creditos
        {
            get
            {
                return Controle_Fin_Get("C");
            }
        }

        /*Declare---------------------------------------------------------------------------------------------------------------------------------*/
        public model_controle_reg(int __controle_cd)
            : base()
        {


            Controle = new model_controle(__controle_cd, "");





            Fila = new model_controle_reg_fila();
            Fila.controle_fila_cd = 0;
            Fila.controle_fila_descricao = "FILA NÃO DEFINIDA";
            Fila.controle_reg_fila_seq = 0;
            this.controle_reg_data = DateTime.Now;




        }
        public model_controle_reg(int _controle_cd, int _controle_reg_numero, DateTime _controle_reg_data, int _controle_reg_seq, int _controle_status_cd, int _controle_status_pgto_cd)
        {

            controle_cd = _controle_cd;
            controle_reg_numero = _controle_reg_numero;
            controle_reg_data = _controle_reg_data;
            controle_reg_seq = _controle_reg_seq;
            controle_status_cd = _controle_status_cd;
            controle_status_pgto_cd = _controle_status_pgto_cd;
            proc_log_seq = 0;

        }
        public model_controle_reg(DataRow i) : base(i) { }

        /*Admin Etapas-------------------------------------------------------------------------------------------------------------------------*/
        public model_controle_reg_Etapa Etapa_Atual_Get()
        {
            try
            {
                foreach (model_controle_reg_Etapa item_etap in Etapas)
                {
                    if (item_etap.controle_etapa_em_execucao == 1)
                    {
                        this.controle_etapa_cd_atual = item_etap.controle_etapa_cd;
                        this.controle_reg_etapa_seq_atual = item_etap.controle_reg_etapa_seq;
                        this.controle_etapa_descricao_atual = item_etap.controle_etapa_descricao;
                        return item_etap;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public model_controle_reg_Etapa Etapa_Proxima_Get()
        {
            model_controle_reg_Etapa __ProximaEtapa = new model_controle_reg_Etapa();
            try
            {


                int _Etapa_Atual_CD = Etapa_Atual_Get().controle_etapa_cd;
                if (_Etapa_Atual_CD == this.controle_etapa_cd_final)
                {
                    __ProximaEtapa = Etapa_Atual_Get();
                }
                else
                {
                    foreach (model_controle_reg_Etapa i in this.Etapas)
                    {
                        if (i.controle_etapa_cd == _Etapa_Atual_CD + 1)
                            __ProximaEtapa = i;
                    }
                }
                this.Local_controle_etapa_cd_proxima = __ProximaEtapa.controle_etapa_cd;
                this.Local_controle_etapa_descricao_proxima = __ProximaEtapa.controle_etapa_descricao;
                this.Local_controle_reg_etapa_seq_proxima = __ProximaEtapa.controle_reg_etapa_seq;
                return __ProximaEtapa;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }


        }


        /*Admin Fila-------------------------------------------------------------------------------------------------------------------------*/
        public void Set_Fila(TbControle_Fila FILA)
        {
            this.Fila.controle_fila_cd = FILA.controle_fila_cd;
            this.Fila.controle_fila_descricao = FILA.controle_fila_descricao;
        }
        public tbcontrole_reg_fin Set_Fin_Add(Pag_Net.Models.modelSistemaUsuario MyConnect, string Descritivo, int fin_tipo_lancamento_cd, Pag_Net.src.F0080_Financeiro.tbs.TbFin_Forma_Pgto Fin_Forma_Pgto, int autpgto_seq, double valor)
        {
            try
            {


                MyConnect.SEQUENCIAL_DE_PROCESSO = Pag_Net.Bll.R0010.Select.Proc_Log_Seq(MyConnect, 30103);

                F0130_Controle.tbcontrole_reg_fin local_Controle_Reg_Fin = new tbcontrole_reg_fin();
                local_Controle_Reg_Fin.proc_log_seq = MyConnect.SEQUENCIAL_DE_PROCESSO;
                local_Controle_Reg_Fin.controle_reg_seq = this.controle_reg_seq;
                local_Controle_Reg_Fin.controle_reg_fin_descritivo = Descritivo;
                local_Controle_Reg_Fin.controle_reg_fin_data = DateTime.Now;
                local_Controle_Reg_Fin.fin_forma_pgto_cd = Fin_Forma_Pgto.fin_forma_pgto_cd;
                local_Controle_Reg_Fin.autpgto_seq = autpgto_seq;
                local_Controle_Reg_Fin.controle_reg_fin_valor = valor;
                local_Controle_Reg_Fin.fin_tipo_lancamento_cd = fin_tipo_lancamento_cd;

                return new tbcontrole_reg_fin(BDCommand.get_DataTable(MyConnect, F0130_35_Controle_Reg_Fin_CRUD.Post(MyConnect, Models.BDCommandTypes.DBINSERT, local_Controle_Reg_Fin)).Rows[0]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*SAVE---------------------------------------------------------------------------------------------------------------------------------*/
        public void Update(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                /* Quando não temos o SEQ é porque estamos inserindo um Novo CONTROLE */
                if (this.controle_reg_seq == 0)
                {
                    /* Sequencial de PROCESSO LOG */
                    MyConnect.SEQUENCIAL_DE_PROCESSO = Pag_Net.Bll.R0010.Select.Proc_Log_Seq(MyConnect, 30201);
                    model_controle_reg NEW_CONTROLE = new model_controle_reg(BDCommand.get_DataTable(MyConnect,
                        F0130_31_Controle_Reg_CRUD.Post(MyConnect,
                                                        Models.BDCommandTypes.DBINSERT,
                                                        this)).Rows[0]);

                    this.proc_log_seq = MyConnect.SEQUENCIAL_DE_PROCESSO;
                    this.controle_reg_seq = NEW_CONTROLE.controle_reg_seq;
                    this.controle_reg_numero = NEW_CONTROLE.controle_reg_numero;
                    /*Atualizando a Fila*/
                    this.Fila.controle_reg_seq = this.controle_reg_seq;
                    this.Fila.Save(MyConnect);
                    /*Atualizando as Etapas*/
                    foreach (model_controle_reg_Etapa _item_etapa in this.Etapas)
                    {
                        _item_etapa.controle_reg_seq = this.controle_reg_seq;
                        _item_etapa.controle_reg_fila_seq = this.Fila.controle_reg_fila_seq;
                        _item_etapa.proc_log_seq = this.proc_log_seq;
                        _item_etapa.Save(MyConnect, this);
                    }
                    /*Atualizando as Pessoas*/
                    foreach (model_controle_reg_pessoa _item_pessoa in this.Pessoas)
                    {
                        _item_pessoa.controle_reg_seq = this.controle_reg_seq;
                        _item_pessoa.Save(MyConnect);
                        if (_item_pessoa.CartaoAcesso.cartao_acesso_seq != 0)
                        {

                            _item_pessoa.CartaoAcesso._Open_Register(MyConnect, _item_pessoa.controle_reg_pessoa_seq);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void Update_Etapa(Pag_Net.Models.modelSistemaUsuario MyConnect, int Controle_Etapa_cd_a_finalizar, int controle_etapa_cd_a_considerar, int controle_status_cd)
        {
            try
            {
                MyConnect.SEQUENCIAL_DE_PROCESSO = Pag_Net.Bll.R0010.Select.Proc_Log_Seq(MyConnect, 30202);
                BDCommand.Post(MyConnect, F0130_10_Controle_Reg_Etapa_Alterar.Post(MyConnect, this, Controle_Etapa_cd_a_finalizar, controle_etapa_cd_a_considerar, controle_status_cd));

                if (controle_etapa_cd_a_considerar == this.controle_etapa_cd_final)
                {
                    foreach (model_controle_reg_pessoa i in this.Pessoas)
                    {
                        if (i.CartaoAcesso.Registro.cartao_acesso_reg_seq != 0)
                            i.CartaoAcesso._Closed_Register(MyConnect);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public tbcontrole_status_pgto Update_Status_Pgto(Pag_Net.Models.modelSistemaUsuario MyConnect, int controle_status_pgto_cd_new)
        {
            try
            {
                return new tbcontrole_status_pgto(BDCommand.get_DataTable(MyConnect, F0130_40_Status_Pgto_Update.Post(0, this.controle_reg_seq, controle_status_pgto_cd_new)).Rows[0]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




        /*Binding------------------------------------------------------------------------------------------------------------------------------*/
        public void Binding(Pag_Net.Models.modelSistemaUsuario MyConnect, model_controle TIPO_CONTROLE)
        {
            try
            {

                if (this.controle_reg_seq == 0) /*Processo de Inclusão de Um novo Controle*/
                {
                    if (TIPO_CONTROLE == null) throw new Exception("Informe o Tipo de Controle para Iniciar um Novo Controle");

                    this.Controle = TIPO_CONTROLE;
                    this.Controle.Binding(MyConnect);


                }
                Binding_Controle(MyConnect, this.Controle);
                Binding_Etapas(MyConnect, this.Controle);
                Binding_Pessoas(MyConnect, this.Controle);
                Binding_OBS(MyConnect);

                this.controle_etapa_cd_atual = this.Etapa_Atual_Get().controle_etapa_cd;
                this.controle_etapa_descricao_atual = this.Etapa_Atual_Get().controle_etapa_descricao.ToString();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Binding_Controle(Pag_Net.Models.modelSistemaUsuario MyConnect, model_controle TIPO_CONTROLE)
        {
            try
            {
                if (this.controle_reg_seq != 0)
                {
                    //Pesquisando o SEQ CONTROLE informado
                    DataTable DataTableBinding = BDCommand.get_DataTable(MyConnect,
                            F0130_50_Controle_Reg_Consultar.Post(MyConnect, this));

                    if (DataTableBinding.Rows.Count <= 0)
                    {
                        throw new Exception(string.Format("Controle N. {0} Não encontrado", this.controle_reg_seq.ToString()));
                    }

                    //CONTROLE -----------------------------------------------------------------------------------------------------------------------------
                    DataRow i = DataTableBinding.Rows[0];
                    controle_cd = Convert.ToInt32(i["controle_cd"]);
                    controle_reg_numero = Convert.ToInt32(i["controle_reg_numero"]);
                    controle_reg_data = Convert.ToDateTime(i["controle_reg_data"]);
                    controle_reg_seq = Convert.ToInt32(i["controle_reg_seq"]);
                    controle_status_cd = Convert.ToInt32(i["controle_status_cd"]);
                    proc_log_seq = Convert.ToInt32(i["proc_log_seq"]);
                    controle_status_pgto_cd = 0; //Convert.ToInt32(i["controle_status_pgto_cd"]);
                    this.MODEL_controle_descricao = i["controle_descricao"].ToString();
                    this.controle_status_descricao = i["controle_status_descricao"].ToString();
                    this.controle_etapa_cd_atual = Convert.ToInt32(i["controle_etapa_cd_atual"].ToString());
                    this.controle_etapa_descricao_atual = i["controle_etapa_descricao_atual"].ToString();
                    this.controle_reg_etapa_seq_atual = Convert.ToInt32(i["controle_reg_etapa_seq_atual"].ToString());
                    this.Fila.controle_fila_cd = Convert.ToInt32(i["controle_fila_cd"].ToString());
                    this.Fila.controle_reg_fila_seq = Convert.ToInt32(i["controle_reg_fila_seq"].ToString());
                    this.Fila.controle_fila_descricao = i["controle_fila_descricao"].ToString();
                    this.controle_etapa_cd_final = Convert.ToInt32(i["controle_etapa_cd_final"].ToString());
                    this.controle_status_pgto_cd = Convert.ToInt32(i["controle_status_pgto_cd"].ToString());
                    this.controle_status_pgto_descricao = i["controle_status_pgto_descricao"].ToString();
                }
                else
                {
                    //TIPO_CONTROLE.Binding(MyConnect);
                    this.controle_cd = TIPO_CONTROLE.controle_cd;
                    this.MODEL_controle_descricao = TIPO_CONTROLE.controle_descricao;
                    this.controle_status_cd = TIPO_CONTROLE.controle_status_cd_inicial;
                    this.controle_status_descricao = "Inicial";
                    //this.controle_status_cd_inicial = CONTROLE.controle_status_cd_inicial;
                    this.controle_status_pgto_cd = TIPO_CONTROLE.controle_status_pgto_cd_inicial;



                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void Binding_Etapas(Pag_Net.Models.modelSistemaUsuario MyConnect, model_controle TIPO_CONTROLE)
        {
            try
            {
                if (this.controle_reg_seq != 0)
                {
                    //ETAPAS--------------------------------------------------------------------------------------------------------------------------------
                    DataTable DataTableBinding_Etapas =
                        BDCommand.get_DataTable(MyConnect,
                                                F0130_52_Controle_Reg_Etapa_List.Post(MyConnect, this)
                                                );
                    List<model_controle_reg_Etapa> list_tbcontrole_reg_etapa = new List<model_controle_reg_Etapa>();
                    foreach (DataRow n in DataTableBinding_Etapas.Rows)
                    {
                        model_controle_reg_Etapa x = new model_controle_reg_Etapa();

                        x.controle_reg_seq = Convert.ToInt32(n["controle_reg_seq"].ToString());
                        x.controle_reg_fila_seq = Convert.ToInt32(n["controle_reg_fila_seq"].ToString());
                        x.controle_reg_etapa_seq = Convert.ToInt32(n["controle_reg_etapa_seq"].ToString());
                        x.controle_etapa_cd = Convert.ToInt32(n["controle_etapa_cd"].ToString());
                        x.controle_etapa_descricao = n["controle_etapa_descricao"].ToString();
                        x.controle_etapa_em_execucao = Convert.ToInt32(n["controle_etapa_em_execucao"].ToString());
                        x.controle_etapa_inicio = Convert.ToDateTime(n["controle_etapa_inicio"].ToString());
                        x.controle_etapa_fim = Convert.ToDateTime(n["controle_etapa_fim"].ToString());
                        x.user_name = n["user_name"].ToString();
                        list_tbcontrole_reg_etapa.Add(x);
                    }
                    Etapas = list_tbcontrole_reg_etapa.ToArray();
                    DataTableBinding_Etapas.Dispose();
                }
                else
                {

                    List<model_controle_reg_Etapa> _ListControle_Etapa = new List<model_controle_reg_Etapa>();
                    int primeiro_item = 1;
                    foreach (TbControle_Etapa i in TIPO_CONTROLE.Etapas)
                    {
                        model_controle_reg_Etapa etapa_item = new model_controle_reg_Etapa();
                        etapa_item.controle_etapa_cd = i.controle_etapa_cd;
                        etapa_item.controle_etapa_descricao = i.controle_etapa_descricao.ToString();


                        if (primeiro_item == 1)
                        {
                            etapa_item.controle_etapa_em_execucao = 1;
                            etapa_item.controle_etapa_inicio = DateTime.Now;
                        }
                        else
                        {
                            etapa_item.controle_etapa_em_execucao = 0;
                        }
                        primeiro_item = 0;
                        etapa_item.user_name = MyConnect.user_name.ToString();
                        _ListControle_Etapa.Add(etapa_item);
                    }
                    Etapas = _ListControle_Etapa.ToArray();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Binding_Pessoas(Pag_Net.Models.modelSistemaUsuario MyConnect, model_controle TIPO_CONTROLE)
        {
            try
            {
                List<model_controle_reg_pessoa> _list_reg_pessoas = new List<model_controle_reg_pessoa>();
                if (this.controle_reg_seq != 0)
                {
                    DataTable DataTableBinding_Pessoas =
                        BDCommand.get_DataTable(MyConnect,
                                                F0130_53_Controle_Reg_Pessoa_Consultar.Post(MyConnect, this.controle_reg_seq, 0, ""));

                    foreach (DataRow RowControlePessoas in DataTableBinding_Pessoas.Rows)
                    {
                        model_controle_reg_pessoa _Item = new model_controle_reg_pessoa(RowControlePessoas);
                        _list_reg_pessoas.Add(_Item);
                    }
                    Pessoas = _list_reg_pessoas.ToArray();
                    DataTableBinding_Pessoas.Dispose();
                }
                else
                {

                    foreach (TbControle_Pessoa Item in TIPO_CONTROLE.Pessoas)
                    {
                        _list_reg_pessoas.Add(new model_controle_reg_pessoa(this.controle_reg_seq, Item.controle_pessoa_cd, Item.controle_pessoa_descricao));
                    }
                    Pessoas = _list_reg_pessoas.ToArray();
                }

            }

            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }
        public void Binding_Fin(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {

                DataTable local_DataTable_controle_reg_fin = BDCommand.get_DataTable(MyConnect, F0130_61_Controle_Reg_Fin_List.Get(this.controle_reg_seq, this.controle_reg_data, DateTime.Now));
                List<model_controle_reg_fin> local_List_model_controle_reg_fin = new List<model_controle_reg_fin>();
                foreach (DataRow i in local_DataTable_controle_reg_fin.Rows)
                {
                    local_List_model_controle_reg_fin.Add(new model_controle_reg_fin(i));

                }

                Financeiro_Lancamentos = local_List_model_controle_reg_fin.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Binding_OBS(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {

                DataTable local_DataTable_controle_reg_fin = BDCommand.get_DataTable(MyConnect, F0130_62_Controle_Reg_OBS_List.Get(this.controle_reg_seq));
                List<model_controle_reg_obs> local_List_model_controle_reg_obs = new List<model_controle_reg_obs>();
                foreach (DataRow i in local_DataTable_controle_reg_fin.Rows)
                {
                    local_List_model_controle_reg_obs.Add(new model_controle_reg_obs(i));

                }

                Controle_Reg_Obs = local_List_model_controle_reg_obs.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public model_controle_reg_fin[] Controle_Fin_Get(string fin_tipo_lancamento)
        {

            try
            {
                List<model_controle_reg_fin> localList_model_Controle_Reg_FIN = new List<model_controle_reg_fin>();
                foreach (model_controle_reg_fin item in Financeiro_Lancamentos)
                {
                    if (item.fin_tipo_lancamento == fin_tipo_lancamento)
                        localList_model_Controle_Reg_FIN.Add(item);
                }
                return localList_model_Controle_Reg_FIN.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public model_controle_reg_pessoa Pessoa_Get(int controle_pessoa_cd)
        {
            try
            {
                model_controle_reg_pessoa pessoa = new model_controle_reg_pessoa(this.controle_reg_seq, controle_pessoa_cd, "Pessoa Não Localizada na lista de Tipos de Pessoas");
                foreach (model_controle_reg_pessoa item in Pessoas)
                {
                    if (item.controle_pessoa_cd == controle_pessoa_cd)
                    {
                        pessoa = item;
                    }
                }
                return pessoa;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
