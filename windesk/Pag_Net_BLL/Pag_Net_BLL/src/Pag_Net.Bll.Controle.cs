using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.Controle
{
    public class wkControle
    {
        Pag_Net.Models.modelSistemaUsuario MyConnect;
        public wkControle(Pag_Net.Models.modelSistemaUsuario _MyConnect)
        {
            MyConnect = _MyConnect;
        }

        public tbcontrole_status[] Controle_Status_List (int controle_cd)
        {
            DataTable Dt_Controle_Status = Pool.TbControle_Status_Consultar(MyConnect, controle_cd);
            List<tbcontrole_status> _list = new List<tbcontrole_status>();
            foreach(DataRow item in Dt_Controle_Status.Rows)
            {
                _list.Add(new tbcontrole_status(item));
            }
            Dt_Controle_Status.Dispose();
            return _list.ToArray();
        }

    }

    public static class Comercial_PrePedido
    {
        public static tbcontrole _Inserir_Novo_Controle(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            tbcontrole _TbControle = new tbcontrole(0, 0, Convert.ToDateTime("1900-01-01"), 0, 0, 0);

            try
            {
                MyConnect.SEQUENCIAL_DE_PROCESSO = Pag_Net.Bll.R0010.Select.Proc_Log_Seq(MyConnect, 30201);
                Pool.Controle_Inserir(MyConnect, MyConnect.SEQUENCIAL_DE_PROCESSO, DateTime.Now, 11 /*Tipo de Controle 1010*/);
                _TbControle = Pool.TbControle_Consultar(MyConnect, MyConnect.SEQUENCIAL_DE_PROCESSO);
                _TbControle.proc_log_seq = MyConnect.SEQUENCIAL_DE_PROCESSO;
                Pool.Fila_Inserir(MyConnect, _TbControle, 1101);
                Pool.Etapas_Inserir(MyConnect, _TbControle, Pool.Controle_Fila_Consultar(MyConnect, _TbControle.controle_reg_seq, 1101));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            return _TbControle;
        }
        public static DataTable _Status_de_pedido(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                return Pool.TbControle_Status_Consultar(MyConnect, 11);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    public static class Recebimento_Mercadoria
    {
        public static tbcontrole Registro(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            tbcontrole _TbControle = new tbcontrole(0, 0, Convert.ToDateTime("1900-01-01"), 0, 0, 0);

            try
            {
                MyConnect.SEQUENCIAL_DE_PROCESSO = Pag_Net.Bll.R0010.Select.Proc_Log_Seq(MyConnect, 30101);
                Pool.Controle_Inserir(MyConnect, 0, DateTime.Now, 10 /*Tipo de Controle 1010*/);
                _TbControle = Pool.TbControle_Consultar(MyConnect, MyConnect.SEQUENCIAL_DE_PROCESSO);

                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _TbControle;
        }
        public static void Abertura(Pag_Net.Models.modelSistemaUsuario MyConnect, tbcontrole _Controle, int _fila, tbcontrole_dados _controle_dados, Pag_Net.Bll.Veiculo.TbVeiculo _veiculo)
        {
            try
            {
                Pool.Fila_Inserir(MyConnect, _Controle, _fila);
                Pool.Etapas_Inserir(MyConnect, _Controle, Pool.Controle_Fila_Consultar(MyConnect, _Controle.controle_reg_seq, _fila));
                _controle_dados.veiculo_seq = Pag_Net.Bll.Veiculo.Pool.New(MyConnect, _veiculo).veiculo_seq;
                Pool.Controle_Dados_Inserir(MyConnect, _Controle, _controle_dados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable List_Pendentes(Pag_Net.Models.modelSistemaUsuario MyConnect, int controle_fila_cd, DateTime Data_Recebimento)
        {
            return Pool.Controle_etapa_atual_list(MyConnect, 10, controle_fila_cd, 0, 0, 0, Data_Recebimento,"1,2,3,4,5,6,7,8,9");
        }
        public static DataTable List(Pag_Net.Models.modelSistemaUsuario MyConnect, int controle_fila_cd, DateTime Data_Recebimento)
        {
            return Pool.Controle_etapa_atual_list(MyConnect, 10, controle_fila_cd, 0, 0, 0, Data_Recebimento);
        }
        public static DataTable List_Aguardando_Entrada(Pag_Net.Models.modelSistemaUsuario MyConnect, int controle_fila_cd, DateTime Data_Recebimento)
        {
            return Pool.Controle_etapa_atual_list(MyConnect, 10, controle_fila_cd, 2, 0, 0, Data_Recebimento);
        }
        public static DataTable List_Autorizacao_Portaria_PenciasGerais(Pag_Net.Models.modelSistemaUsuario MyConnect, int controle_fila_cd, DateTime Data_Recebimento)
        {
            return Pool.Controle_etapa_atual_list(MyConnect, 10, controle_fila_cd, 0, 0, 0, Data_Recebimento, "4,8,9");
        }        
        public static DataTable List_Autorizacao_Entrada_Portaria(Pag_Net.Models.modelSistemaUsuario MyConnect, int controle_fila_cd, DateTime Data_Recebimento)
        {
            return Pool.Controle_etapa_atual_list(MyConnect, 10, controle_fila_cd,4, 0, 0, Data_Recebimento);
        }
        public static DataTable List_Aguardando_Conferencia_de_Saida(Pag_Net.Models.modelSistemaUsuario MyConnect, int controle_fila_cd, DateTime Data_Recebimento)
        {
            return Pool.Controle_etapa_atual_list(MyConnect, 10, controle_fila_cd, 8, 0, 0, Data_Recebimento);
        }
        public static DataTable List_Aguardando_Saida(Pag_Net.Models.modelSistemaUsuario MyConnect, int controle_fila_cd, DateTime Data_Recebimento)
        {
            return Pool.Controle_etapa_atual_list(MyConnect, 10, controle_fila_cd, 9, 0, 0, Data_Recebimento);
        }        
        public static DataTable Historico_Entrada(Pag_Net.Models.modelSistemaUsuario MyConnect, string _CNPJ_CPF)
        {
            try
            {
                return Pag_Net.Bll.BDCommand.get_DataTable(MyConnect, BDCommand.Name.R0130_04_controle_dados_historico, string.Format("'{0}'", _CNPJ_CPF));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static  int Proximo_Numero_Recebimento(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            return Pool.controle_reg_numero_proximo(MyConnect, 10, DateTime.Now);
        }

        
    }

    public static class Pool
    {

        public static DataTable TbControle_Status_Consultar(Pag_Net.Models.modelSistemaUsuario MyConnect, int controle_cd)
        {

            try
            {
                DataTable DT;
                DT = BDCommand.get_DataTable(MyConnect, BDCommand.Name.F0130_09_controle_status_consultar, string.Format("{0}", controle_cd));
                return DT;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static tbcontrole TbControle_Consultar(Pag_Net.Models.modelSistemaUsuario MyConnect, int SEQUENCIAL_DE_PROCESSO)
        {
            tbcontrole _TbControle = new tbcontrole(0, 0, Convert.ToDateTime("1900-01-01"), 0, 0, 0);
            try
            {
                DataTable DtTable_CONTROLE = Pag_Net.Bll.R0130_01.Postgre.get(MyConnect, MyConnect.SEQUENCIAL_DE_PROCESSO);
                _TbControle = new tbcontrole(DtTable_CONTROLE.Rows[0]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _TbControle;
        }
        public static tbcontrole_dados TbControle_dados_consultar (Pag_Net.Models.modelSistemaUsuario MyConnect, int controle_reg_seq)
        {
               
            try
            {
                DataTable DT;
                DT = BDCommand.get_DataTable(MyConnect, BDCommand.Name.F0130_07_controle_dados_consultar, controle_reg_seq.ToString());
                return new tbcontrole_dados(DT.Rows[0]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static tbcontrole_fila Controle_Fila_Consultar(Pag_Net.Models.modelSistemaUsuario MyConnect, int controle_reg_seq, int controle_fila_cd)
        {
            try
            {
                DataSet DT = new DataSet();
                DT = DbSelect.GetDataSet(MyConnect, DataBaseName.ODBCOXAN, Pag_Net.Bll.BDCommand.ScriptSql_Get(BDCommand.Name.R0130_02, string.Format("{0}, {1}", controle_reg_seq, controle_fila_cd)), "");
                return new tbcontrole_fila(DT.Tables[0].Rows[0]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void Controle_Inserir(Pag_Net.Models.modelSistemaUsuario MyConnect,	int  controle_reg_numero, DateTime controle_reg_data, int controle_cd)
        {
            try
            {
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                BDExecute.Execute(Pag_Net.Bll.F0130_01.Postgres.post(MyConnect, controle_reg_numero	,controle_reg_data	, controle_cd ), null, DataBaseName.ODBCOXAN);
                BDExecute.Close(DataBaseName.ODBCOXAN);
                BDExecute.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void Fila_Inserir(Pag_Net.Models.modelSistemaUsuario MyConnect, tbcontrole _Controle, int _fila)
        {
            try
            {
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                BDExecute.Execute(Pag_Net.Bll.BDCommand.ScriptSql_POST(BDCommand.Name.F0130_02, string.Format(" 'DBINSERT', {0}, {1}", _Controle.controle_reg_seq, _fila)), null, DataBaseName.ODBCOXAN);
                BDExecute.Close(DataBaseName.ODBCOXAN);
                BDExecute.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("\n Comercial_PrePedido.pool.Fila_Inserir : " + ex.Message);
            }
        }
        public static void Etapas_Inserir(Pag_Net.Models.modelSistemaUsuario MyConnect, tbcontrole _Controle, tbcontrole_fila _controle_fila)
        {
            try
            {
                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                BDExecute.Execute(Pag_Net.Bll.BDCommand.ScriptSql_POST(BDCommand.Name.F0130_03, string.Format(" 'DBINSERT', {0}, {1}", _Controle.controle_reg_seq, _controle_fila.controle_reg_fila_seq)), null, DataBaseName.ODBCOXAN);
                BDExecute.Close(DataBaseName.ODBCOXAN);
                BDExecute.Dispose();
            }
                   
            catch (Exception ex)
            {
                throw new Exception("\n Comercial_PrePedido.pool.Etapas_Inserir : " + ex.Message);
            }

        }
        public static void Controle_Dados_Inserir (Pag_Net.Models.modelSistemaUsuario MyConnect, tbcontrole _Controle, tbcontrole_dados _controle_dados)
        {
            try
            {
                Pag_Net.Bll.BDCommand.Post(MyConnect,
                        BDCommand.Name.F0130_04,
                        string.Format(" 'DBINSERT', {0}, {1}, '{2}', '{3}', {4}, '{5}', '{6}', '{7}', {8}, {9}, '{10}', {11}, {12} ",
                        _Controle.controle_reg_seq.ToString(),
                        _controle_dados.controle_reg_transportadora_cdpessoa.ToString(),
                        _controle_dados.controle_reg_transportadora_cnpj.ToString(),
                        _controle_dados.controle_reg_transportadora_razao_social.ToString(),
                        _controle_dados.controle_reg_motorista_cdpessoa.ToString(),
                        _controle_dados.controle_reg_motorista_cpf.ToString(),
                        _controle_dados.controle_reg_motorista_documento_cnh.ToString() == null ? "" : _controle_dados.controle_reg_motorista_documento_cnh.ToString(),
                        _controle_dados.controle_reg_motorista_documento_cnh_vencimento.ToString("yyyy-MM-dd"), 
                        _controle_dados.veiculo_seq.ToString(), 
                        _controle_dados.controle_reg_numero_pallet.ToString(),
                        _controle_dados.controle_reg_motorista_Nome.ToString(), 
                        _controle_dados.controle_reg_numero_celular_dd.ToString(),
                        _controle_dados.controle_reg_numero_celular_numero.ToString()
                        ));
            }
            catch (Exception ex)
            {
                throw new  Exception (ex.Message);
            }
        }
        public static DataTable Controle_etapa_atual_list(Pag_Net.Models.modelSistemaUsuario MyConnect, int controle_cd, int controle_fila_cd, int controle_etapa_cd, int controle_reg_seq, int controle_reg_fila_seq, DateTime data_movimento)
        {
            return Controle_etapa_atual_list(MyConnect, controle_cd, controle_fila_cd, controle_etapa_cd, controle_reg_seq, controle_reg_fila_seq, data_movimento, "");
        }
        public static DataTable Controle_etapa_atual_list(Pag_Net.Models.modelSistemaUsuario MyConnect, int controle_cd, int controle_fila_cd, int controle_etapa_cd, int controle_reg_seq, int controle_reg_fila_seq, DateTime data_movimento, string controle_etapa_cd_list)
        {
            try
            {
                DataSet DT = new DataSet();
                DT = DbSelect.GetDataSet(MyConnect, DataBaseName.ODBCOXAN, Pag_Net.Bll.BDCommand.ScriptSql_Get(BDCommand.Name.F0130_10_controle_reg_list, string.Format("{0}, {1}, {2}, {3}, {4}, '{5}', '{6}' ", controle_cd, controle_fila_cd, controle_etapa_cd, controle_reg_seq, controle_reg_fila_seq, data_movimento.ToString("yyyy-MM-dd"), controle_etapa_cd_list)), "");
                return DT.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Controle_etapa_lista(Pag_Net.Models.modelSistemaUsuario MyConnect, int controle_reg_seq, int controle_reg_fila_seq)
        {

            try
            {

                return Pag_Net.Bll.BDCommand.get_DataTable(MyConnect,  BDCommand.Name.R0130_05_controle_reg_etapa_list, string.Format("{0}, {1}", controle_reg_seq, controle_reg_fila_seq));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static void Controle_etapa_finalizar(Pag_Net.Models.modelSistemaUsuario MyConnect, int vcontrole_reg_seq, int	vcontorle_reg_fila_seq, int vcontrole_etapa_cd_a_finalizar, int vcontrole_etapa_cd_a_considerar, int vcontrole_status_cd)
        {
            {
                try
                {
                    DbUpdate BDExecute;
                    BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                    MyConnect.SEQUENCIAL_DE_PROCESSO = Pag_Net.Bll.R0010.Select.Proc_Log_Seq(MyConnect, 30102);
                    BDExecute.Execute(Pag_Net.Bll.BDCommand.ScriptSql_POST(BDCommand.Name.F0130_05_controle_etapa_finalizar, string.Format("{0}, {1}, {2}, {3}, {4}, {5}", MyConnect.SEQUENCIAL_DE_PROCESSO, vcontrole_reg_seq, vcontorle_reg_fila_seq, vcontrole_etapa_cd_a_finalizar, vcontrole_etapa_cd_a_considerar, vcontrole_status_cd)), null, DataBaseName.ODBCOXAN);
                    BDExecute.Close(DataBaseName.ODBCOXAN);
                    BDExecute.Dispose();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public static int controle_reg_numero_proximo(Pag_Net.Models.modelSistemaUsuario MyConnect, int vcontrole_cd, DateTime vcontrole_reg_data)
        {
            try
            {
                int NUMERO_PROXIMO = Convert.ToInt32(BDCommand.get_DataTable(MyConnect, BDCommand.Name.R0130_06_controle_reg_numero_proximo, string.Format("{0}, '{1}'", vcontrole_cd, vcontrole_reg_data.ToString("yyyy-MM-dd"))).Rows[0][0].ToString()) ;
                return NUMERO_PROXIMO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static tbcontrole_reg_pgto Controle_Pgto_Registrar(Pag_Net.Models.modelSistemaUsuario MyConnect, tbcontrole_reg_pgto _controle_reg_pgto)
        {
            try
            {
                string SQL = string.Format(" 'DBINSERT', {0}, {1}, {2}, {3}, {4}, {5}",
                            _controle_reg_pgto.controle_reg_seq.ToString(),
                            _controle_reg_pgto.controle_reg_pgto_seq.ToString(),
                            _controle_reg_pgto.controle_reg_numero_pallet,
                            _controle_reg_pgto.controle_reg_numero_pallet_vl_unit.ToString("0.00").Replace(",", "."),
                            _controle_reg_pgto.controle_reg_numero_pallet_vl_total.ToString("0.00").Replace(",", "."),
                            _controle_reg_pgto.controle_reg_numero_pallet_vl_recebido.ToString("0.00").Replace(",", ".")
                    );



                DbUpdate BDExecute;
                BDExecute = new DbUpdate(MyConnect, DataBaseName.ODBCOXAN);
                BDExecute.Execute(Pag_Net.Bll.BDCommand.ScriptSql_POST(BDCommand.Name.F0130_06_controle_reg_pgto, SQL), null, DataBaseName.ODBCOXAN);
                BDExecute.Close(DataBaseName.ODBCOXAN);
                BDExecute.Dispose();

                return TbControle_Reg_Pgto_Consultar(MyConnect, _controle_reg_pgto.controle_reg_seq);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        public static tbcontrole_reg_pgto TbControle_Reg_Pgto_Consultar(Pag_Net.Models.modelSistemaUsuario MyConnect, int _controle_reg_pgto)
        {
            try
            {
                return new tbcontrole_reg_pgto( Pag_Net.Bll.BDCommand.get_DataTable(MyConnect, BDCommand.Name.F0130_08_controle_reg_pgto_consultar, string.Format("{0}", _controle_reg_pgto)).Rows[0]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        ///public static void Etapa_Inserir()
    }

    public class tbcontrole
    {
        public int controle_cd { get; set; }
        public int controle_reg_numero { get; set; }
        public DateTime controle_reg_data { get; set; }
        public int controle_reg_seq { get; set; }
        public int controle_status_cd { get; set; }
        public int controle_status_pgto_cd { get; set; }
        public int proc_log_seq { get; set; }
        public tbcontrole(

             int _controle_cd,
             int _controle_reg_numero,
             DateTime _controle_reg_data,
             int _controle_reg_seq,
             int _controle_status_cd,
             int _controle_status_pgto_cd
            )
        {

            controle_cd             = _controle_cd;
            controle_reg_numero     = _controle_reg_numero;
            controle_reg_data       = _controle_reg_data;
            controle_reg_seq        = _controle_reg_seq;
            controle_status_cd      = _controle_status_cd;
            controle_status_pgto_cd = _controle_status_pgto_cd;
            proc_log_seq = 0;

        }


        public tbcontrole( DataRow i )
        {
            controle_cd             = Convert.ToInt32(i["controle_cd"]);
            controle_reg_numero     = Convert.ToInt32(i["controle_reg_numero"]);
            controle_reg_data       = Convert.ToDateTime(i["controle_reg_data"]);
            controle_reg_seq        = Convert.ToInt32(i["controle_reg_seq"]);
            controle_status_cd      = Convert.ToInt32(i["controle_status_cd"]);
            controle_status_pgto_cd = Convert.ToInt32(i["controle_status_pgto_cd"]);
            proc_log_seq = 0;
        }

   

    }
    public class tbcontrole_fila
    {
        public int controle_reg_fila_seq { get; set; }
        public int controle_reg_seq { get; set; }
        public int controle_fila_cd { get; set; }
        public string controle_fila_descricao { get; set; }
        public tbcontrole_fila() { }
        public tbcontrole_fila(
            int _controle_reg_fila_seq,
            int _controle_reg_seq,
            int _controle_fila_cd,
            string _controle_fila_descricao
            )
        {
            controle_reg_fila_seq = _controle_reg_fila_seq;
            controle_reg_seq = _controle_reg_seq;
            controle_fila_cd = _controle_fila_cd;
            controle_fila_descricao = _controle_fila_descricao;
        }
        public tbcontrole_fila(DataRow i)
        {
            controle_reg_fila_seq = Convert.ToInt32(i["controle_reg_fila_seq"].ToString());
            controle_reg_seq = Convert.ToInt32(i["controle_reg_seq"].ToString());
            controle_fila_cd = Convert.ToInt32(i["controle_fila_cd"].ToString());
            controle_fila_descricao = i["controle_fila_descricao"].ToString();
        }
    }
    public class tbcontrole_etapa
    {
        public int      controle_cd                 { get; set; }
        public int      controle_reg_numero         { get; set; }
        public DateTime controle_reg_data           { get; set; }
        public int      controle_fila_cd            { get; set;  }
        public int      controle_reg_seq            { get; set; }
        public int      controle_reg_etapa_seq      { get; set; }
        public DateTime controle_reg_etapa_data     { get; set; }
        public int      controle_etapa_cd           { get; set; }


        public tbcontrole_etapa (
            
             int _controle_cd ,
             int _controle_reg_numero ,
             DateTime _controle_reg_data , 
             int _controle_fila_cd ,
             int _controle_reg_seq ,
             int _controle_reg_etapa_seq ,
             DateTime _controle_reg_etapa_data ,
             int _controle_etapa_cd 
            )
        {

            controle_cd                     =   _controle_cd;
            controle_reg_numero             =   _controle_reg_numero;
            controle_reg_data               =   _controle_reg_data;
            controle_fila_cd                =   _controle_fila_cd;        
            controle_reg_seq                =   _controle_reg_seq;        
            controle_reg_etapa_seq          =   _controle_reg_etapa_seq;  
            controle_reg_etapa_data         =   _controle_reg_etapa_data;
            controle_etapa_cd = _controle_etapa_cd;

        }

    }
    public class tbcontrole_dados
    {

        public int      controle_reg_seq	                                { get; set;}
		public int      controle_reg_transportadora_cdpessoa				{ get; set;}


        private string  _controle_reg_transportadora_cnpj;
        public string   controle_reg_transportadora_cnpj 					
        {
            get
            {
                return _controle_reg_transportadora_cnpj;
            } 
            set 
            {
                if (value.ToString() != "0")
                {
                    if (Pag_Net.Models.BDTools.DocCPF_CNPJ_Validar(value))
                    {
                        _controle_reg_transportadora_cnpj = value;
                    }
                    else
                    {
                        _controle_reg_transportadora_cnpj = "";
                        throw new Exception("Cnpj/CPF Incorreto");

                    }
                }
                else
                {
                    _controle_reg_transportadora_cnpj = "0";
                }
            }
        
        }
		public string   controle_reg_transportadora_razao_social			{ get; set;}
		public int      controle_reg_motorista_cdpessoa						{ get; set;}

        private string _controle_reg_motorista_cpf;
        public string controle_reg_motorista_cpf
        {
            get
            {
                return _controle_reg_motorista_cpf;
            }
            set
            {
                if (value.ToString() != "0")
                {
                    if (Pag_Net.Models.BDTools.DocCPF_CNPJ_Validar(value))
                    {
                        _controle_reg_motorista_cpf = value;
                    }
                    else
                    {
                        _controle_reg_motorista_cpf = "";
                        throw new Exception("Cnpj/CPF Incorreto");

                    }
                }
                else
                {
                    _controle_reg_motorista_cpf = "0";
                }
            }

        }


        public string   controle_reg_motorista_Nome                         { get; set; }

        private string __controle_reg_motorista_documento_cnh = "";
        public string   controle_reg_motorista_documento_cnh				
        { 
            set {
                if (!String.IsNullOrEmpty(value)) 
                {
                    __controle_reg_motorista_documento_cnh = value;
                }
                else
                {
                    __controle_reg_motorista_documento_cnh = "";
                }
            }
            get
            {
                return __controle_reg_motorista_documento_cnh;
            }

        }
		
        
        public DateTime controle_reg_motorista_documento_cnh_vencimento		{ get; set;}
        
        public int      veiculo_seq                                         { get; set; }
        public int      controle_reg_numero_pallet                          { get; set; }

        public int      controle_reg_numero_celular_dd                      { get; set; }
        public int      controle_reg_numero_celular_numero                  { get; set; } 

        public tbcontrole_dados (DataRow i)
        {

            controle_reg_seq = Convert.ToInt32(i["controle_reg_seq"]);
            controle_reg_transportadora_cdpessoa = Convert.ToInt32(i["controle_reg_transportadora_cdpessoa"]);
            controle_reg_transportadora_cnpj = i["controle_reg_transportadora_cnpj"].ToString();
            controle_reg_transportadora_razao_social = i["controle_reg_transportadora_razao_social"].ToString();
            controle_reg_motorista_cdpessoa = Convert.ToInt32(i["controle_reg_motorista_cdpessoa"]);
            controle_reg_motorista_cpf = i["controle_reg_motorista_cpf"].ToString();
            controle_reg_motorista_Nome = i["controle_reg_motorista_nome"].ToString();
            controle_reg_motorista_documento_cnh = i["controle_reg_motorista_documento_cnh"].ToString();
            controle_reg_motorista_documento_cnh_vencimento = Convert.ToDateTime(i["controle_reg_motorista_documento_cnh_vencimento"].ToString());
            controle_reg_numero_celular_dd = Convert.ToInt32(i["controle_reg_numero_celular_dd"].ToString());
            controle_reg_numero_celular_numero = Convert.ToInt32(i["controle_reg_numero_celular_numero"].ToString());

            veiculo_seq = Convert.ToInt32(i["veiculo_seq"]);

        }
        public tbcontrole_dados()
        {
            controle_reg_motorista_documento_cnh_vencimento = Convert.ToDateTime("1900-01-01");
            controle_reg_numero_celular_dd = 11;
            controle_reg_numero_celular_numero = 0;
            controle_reg_numero_pallet = 0;
        }
        public tbcontrole_dados(
        

                        int          _controle_reg_seq	                            
            ,           int          _controle_reg_transportadora_cdpessoa			
            ,           string       _controle_reg_transportadora_cnpj 				
            ,           string       _controle_reg_transportadora_razao_social		
            ,           int          _controle_reg_motorista_cdpessoa
            ,           string       _controle_reg_motorista_Nome
            ,           string       _controle_reg_motorista_cpf						
            ,           string       _controle_reg_motorista_documento_cnh			
            ,           DateTime     _controle_reg_motorista_documento_cnh_vencimento	
            ,           int          _veiculo_seq
            ,           int          _controle_reg_numero_pallet
            ,           int          _controle_reg_numero_celular_dd
            ,           int          _controle_reg_numero_celular_numero

            )
        {

            controle_reg_numero_celular_dd = 11;
            controle_reg_numero_celular_numero = 0;
            controle_reg_seq	                                       =         _controle_reg_seq	                            ;
            controle_reg_transportadora_cdpessoa			           =         _controle_reg_transportadora_cdpessoa			;
            controle_reg_transportadora_cnpj 				           =         _controle_reg_transportadora_cnpj 				;
            controle_reg_transportadora_razao_social		           =         _controle_reg_transportadora_razao_social		;
            controle_reg_motorista_cdpessoa					           =         _controle_reg_motorista_cdpessoa				;
            controle_reg_motorista_Nome                                =         _controle_reg_motorista_Nome;
            controle_reg_motorista_cpf						           =         _controle_reg_motorista_cpf					;
            controle_reg_motorista_documento_cnh = String.IsNullOrEmpty(_controle_reg_motorista_documento_cnh) ? "" : _controle_reg_motorista_documento_cnh;
            controle_reg_motorista_documento_cnh_vencimento	           =         _controle_reg_motorista_documento_cnh_vencimento;
            veiculo_seq = _veiculo_seq;
            controle_reg_numero_pallet = _controle_reg_numero_pallet;

        }
    }
    public class tbcontrole_reg_pgto
    {
      	public int      controle_reg_seq                                 {get;set;}					
		public int      controle_reg_pgto_seq			                {get;set;}					
		public int      controle_reg_numero_pallet				        {get;set;}					
		public double   controle_reg_numero_pallet_vl_unit		    {get;set;}					
		public double   controle_reg_numero_pallet_vl_total           {get;set;}
        public double   controle_reg_numero_pallet_vl_recebido        { get; set; }
        public int controle_status_cd { get; set; }
        public int controle_status_pgto_cd { get; set; }

        public tbcontrole_reg_pgto(){}

        public tbcontrole_reg_pgto(
            int _controle_reg_seq,
            int _controle_reg_pgto_seq,
            int _controle_reg_numero_pallet,
            int _controle_reg_numero_pallet_vl_unit,
            int _controle_reg_numero_pallet_vl_total,
            int _controle_reg_numero_pallet_vl_recebido, 
            int _controle_status_cd, 
            int _controle_status_pgto_cd 
            
            ) 
        {
            controle_reg_seq = _controle_reg_seq;
            controle_reg_pgto_seq			            =         _controle_reg_pgto_seq;
            controle_reg_numero_pallet				    =         _controle_reg_numero_pallet;
            controle_reg_numero_pallet_vl_unit		    =         _controle_reg_numero_pallet_vl_unit;
            controle_reg_numero_pallet_vl_total         =         _controle_reg_numero_pallet_vl_total;
            controle_reg_numero_pallet_vl_recebido      =         _controle_reg_numero_pallet_vl_recebido  ;
            controle_status_cd = _controle_status_cd;
            controle_status_pgto_cd = _controle_status_pgto_cd; 
            
        }


        public tbcontrole_reg_pgto(DataRow i)
        {
            
             controle_reg_seq                               = Convert.ToInt32(i["controle_reg_seq"].ToString());
             controle_reg_pgto_seq			                = Convert.ToInt32(i["controle_reg_pgto_seq"].ToString());
             controle_reg_numero_pallet				        = Convert.ToInt32(i["controle_reg_numero_pallet"].ToString());
             controle_reg_numero_pallet_vl_unit		        = Convert.ToDouble(i["controle_reg_numero_pallet_vl_unit"].ToString());
             controle_reg_numero_pallet_vl_total            = Convert.ToDouble(i["controle_reg_numero_pallet_vl_total"].ToString());
             controle_reg_numero_pallet_vl_recebido         = Convert.ToDouble(i["controle_reg_numero_pallet_vl_recebido"].ToString());
             controle_status_cd                             = Convert.ToInt32(i["controle_status_cd"].ToString());
             controle_status_pgto_cd                        = Convert.ToInt32(i["controle_status_pgto_cd"].ToString());
            
        }

    }
    public class tbcontrole_status
    {
        public int controle_status_cd {get; set; }
        public string controle_status_descricao {get; set; }
        public int controle_cd {get; set;}
        public tbcontrole_status () {}
        public tbcontrole_status (
                int _controle_status_cd , 
                string _controle_status_descricao, 
                int _controle_cd
            ) 
        {
                this.controle_cd = _controle_cd ;
                this.controle_status_cd = _controle_status_cd ;
                this.controle_status_descricao = _controle_status_descricao ;
        }
        public tbcontrole_status(DataRow i) 
        {
            this.controle_cd = Convert.ToInt32(i["controle_cd"].ToString());
            this.controle_status_cd = Convert.ToInt32(i["controle_status_cd"].ToString());
            this.controle_status_descricao = i["controle_status_descricao"].ToString();
        }
    }


}
