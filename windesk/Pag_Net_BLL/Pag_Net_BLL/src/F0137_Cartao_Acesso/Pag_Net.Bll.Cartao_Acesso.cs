using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0137_CartaoAcesso;
using System.Data;

namespace Pag_Net.Bll.F0137_CartaoAcesso
{
    public class Wk
    {
        public Pag_Net.Models.modelSistemaUsuario MyConnect;
        public TbCartaoAcessoTipo[] CartaoAcessoTipoList;
        public F0137_30_CartaoAcessoList FilterCartaoList;
        public F0137_31_CartaoAcessoRegistroList FilterCartaoAcessoRegistroList;
        public model_cartao_acesso CartaAcessoItem;
        public Wk (Pag_Net.Models.modelSistemaUsuario _MyConnect) 
        {
            MyConnect = _MyConnect;
            FilterCartaoList = new F0137_30_CartaoAcessoList();
            FilterCartaoAcessoRegistroList = new F0137_31_CartaoAcessoRegistroList();
            CartaAcessoItem = new model_cartao_acesso();
            CartaoAcessoTipoList_Publish();
        }
        public void FilterCartaoList_Clear()
        {
             FilterCartaoList = new F0137_30_CartaoAcessoList();
        }

        public void FilterCartaoAcessoRegistroList_Clear()
        {
            FilterCartaoAcessoRegistroList = new F0137_31_CartaoAcessoRegistroList();
        }

        public model_cartao_acesso Cartao_status_disponivel_get(string codigo_barra)
        {
            try
            {
                model_cartao_acesso CartaoAcessoItem = new model_cartao_acesso();
                model_cartao_acesso[] ListDisponivel = CartaoStatusDisponivelList_Get(codigo_barra);
                if (ListDisponivel.Count() > 0 )
                {
                    CartaoAcessoItem = ListDisponivel[0];
                }
                return CartaoAcessoItem;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public model_cartao_acesso[] CartaoStatusDisponivelList_Get(string codigo_barra)
        {
            try
            {
                List<model_cartao_acesso> __List = new List<model_cartao_acesso>();
                F0137_30_CartaoAcessoList FILTRO = new F0137_30_CartaoAcessoList();
                FILTRO.cartao_acesso_reg_status = 0;
                FILTRO.cartao_acesso_cdbr = codigo_barra;
                FILTRO.cartao_acesso_reg_status_filter = true; /* FILTRAR O STATUS DE REGISTRO*/
                FILTRO.cartao_acesso_reg_status = 0;  /* APENAS CARTAO COM STATUS LIVRE PARA USO*/

                DataTable DataTableCartaoAcessoList = BD.CartaoAcessoList_DataTable_Get(MyConnect, FILTRO);
                if (DataTableCartaoAcessoList.Rows.Count > 1)
                    __List.Add(new model_cartao_acesso());

                foreach ( DataRow x in BD.CartaoAcessoList_DataTable_Get(MyConnect, FILTRO).Rows)
                {
                    __List.Add(new model_cartao_acesso(x));
                }
                return __List.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void CartaoAcessoTipoList_Publish()
        {
            try
            {
                
                List<TbCartaoAcessoTipo> TbCartaoAcessoTipoArraylist = new List<TbCartaoAcessoTipo>();
                TbCartaoAcessoTipoArraylist.Add(new TbCartaoAcessoTipo());
                foreach (DataRow i in BD.CartaoAcessoTipoList_DataTable_Get(MyConnect).Rows)
                {
                    TbCartaoAcessoTipoArraylist.Add(new TbCartaoAcessoTipo(i));
                }
                CartaoAcessoTipoList = TbCartaoAcessoTipoArraylist.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public model_cartao_acesso[] CartaoAcessoList_Get()
        {
            try
            {
                List<model_cartao_acesso> TbCartaoAcessoArraylist = new List<model_cartao_acesso>();
                foreach (DataRow i in BD.CartaoAcessoList_DataTable_Get(MyConnect, FilterCartaoList).Rows)
                {
                    TbCartaoAcessoArraylist.Add(new model_cartao_acesso(i));
                }
                return TbCartaoAcessoArraylist.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public model_cartao_acesso_registro[] CartaoAcessoRegistroList_Get()
        {
            try
            {
                DataTable DataTableCartaoAcessoRegistroList = BD.CartaoAcessoRegistroList_DataTable_Get(MyConnect, FilterCartaoAcessoRegistroList);
                List<model_cartao_acesso_registro> ListModelCartaoAcessoRegistro = new List<model_cartao_acesso_registro>();
                foreach(DataRow i in DataTableCartaoAcessoRegistroList.Rows)
                {
                    model_cartao_acesso_registro x = new model_cartao_acesso_registro();
                    x.Binding(i);
                    ListModelCartaoAcessoRegistro.Add(x);
                }
                return ListModelCartaoAcessoRegistro.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }

    public static class BD
    {
        public static DataTable CartaoAcessoTipoList_DataTable_Get(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, new f0137_20_CartaoAcessoTipoList().PostGre_Get_Function());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable CartaoAcessoList_DataTable_Get(Pag_Net.Models.modelSistemaUsuario MyConnect, F0137_30_CartaoAcessoList filter)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, filter.PostGre_Get_Function());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable CartaoAcessoRegistroList_DataTable_Get(Pag_Net.Models.modelSistemaUsuario MyConnect, F0137_31_CartaoAcessoRegistroList filter)
        {
            try
            {
                return BDCommand.get_DataTable(MyConnect, filter.PostGre_Get_Function());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    public class model_cartao_acesso: tbcartao_acesso
    {

        public model_cartao_acesso_registro Registro { get; set;  }
        public model_cartao_acesso_registro[] RegistroLogs { get; set; }

        public Pag_Net.Tools.CodigoBarra.Ean13 EAN;
        public string cartao_acesso_tipo_descricao { get; set; }
        public string  LOCAL_DESCRICAO_cartao_acesso_status
        {
            get
            {
                if (base.cartao_acesso_status == 0)
                    return "Inativo";
                else
                    return "Ativo";
            }
        }

        public model_cartao_acesso() : base() 
        {

            Registro = new model_cartao_acesso_registro();
        }

        public model_cartao_acesso(DataRow i) : base(i)
        {
            cartao_acesso_tipo_descricao = i["cartao_acesso_tipo_descricao"].ToString();
        }

        public void _DbInsert(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                BDCommand.Execute(MyConnect, F0136_02_CartaoAcesso_CRUD.Post(MyConnect, Models.BDCommandTypes.DBINSERT, this));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void _DbUpdate(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                BDCommand.Execute(MyConnect, F0136_02_CartaoAcesso_CRUD.Post(MyConnect, Models.BDCommandTypes.DBUPDATE, this));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void _Binding(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                model_cartao_acesso item = new model_cartao_acesso(BD.CartaoAcessoList_DataTable_Get(MyConnect, new F0137_30_CartaoAcessoList(this.cartao_acesso_seq, 0, "", 0, 0, DateTime.Now, DateTime.Now, 0, 0, 0, 0,false,0)).Rows[0]);
                this.cartao_acesso_status = item.cartao_acesso_status;
                this.cartao_acesso_numero = item.cartao_acesso_numero;
                this.cartao_acesso_cdbr = item.cartao_acesso_cdbr;
                this.cartao_acesso_data = item.cartao_acesso_data;
                this.cartao_acesso_tipo_descricao = item.cartao_acesso_tipo_descricao; 
                this.cartao_acesso_validade_ini = item.cartao_acesso_validade_ini;
                this.cartao_acesso_validade_fim = item.cartao_acesso_validade_fim;


            }

            catch (Exception ex)
            {
                new Exception(ex.Message);
            }
        }

        public void _Binding_CodigoBarraNew(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                string NUMERO_SEQ = (Convert.ToInt32(BDCommand.get_DataTable(MyConnect, new F0137_70_Cartao_Acesso_Visitante_Numero().PostGre_Get_Function()).Rows[0][0].ToString())).ToString();
                int NUMERO_SEQ_length = NUMERO_SEQ.Length;
                switch (NUMERO_SEQ_length )
                {
                    case 1: 
                        NUMERO_SEQ = "0000" + NUMERO_SEQ;
                        break;
                    case 2: 
                        NUMERO_SEQ = "000" + NUMERO_SEQ;
                        break;
                    case 3: 
                        NUMERO_SEQ = "00" + NUMERO_SEQ;
                        break;
                    case 4:
                        NUMERO_SEQ = "0" + NUMERO_SEQ;
                        break;
                }

                EAN = new Pag_Net.Tools.CodigoBarra.Ean13("57", "89520",NUMERO_SEQ);
                EAN.CalculateChecksumDigit();
                this.cartao_acesso_numero = Convert.ToInt32(this.cartao_acesso_tipo_cd + NUMERO_SEQ);
                this.cartao_acesso_cdbr = "5789520" + NUMERO_SEQ + EAN.ChecksumDigit;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void _Binding_EAN()
        {
            try
            {
                EAN = null;
                string c = this.cartao_acesso_cdbr.Substring(0, 2);
                string x = this.cartao_acesso_cdbr.Substring(2, 5);
                string a = this.cartao_acesso_cdbr.Substring(7, 5);
                EAN = new Pag_Net.Tools.CodigoBarra.Ean13(c, x, a);
                EAN.CalculateChecksumDigit();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void _Open_Register(Pag_Net.Models.modelSistemaUsuario MyConnect, int _controle_reg_pessoa_seq)
        {
            try
            {
                Registro = new model_cartao_acesso_registro();
                if (this.cartao_acesso_seq == 0)
                    throw new Exception("Cartão Não identifcado: Registro de uso não pode ser inicializado");
                Registro.cartao_acesso_seq = this.cartao_acesso_seq;
                Registro.cartao_acesso_data = DateTime.Now;
                Registro.controle_reg_pessoa_seq = _controle_reg_pessoa_seq;
                Registro = new model_cartao_acesso_registro( BDCommand.get_DataTable(MyConnect, F0136_03_CartaoAcessoRegistroCRUD.Post(MyConnect,  Models.BDCommandTypes.DBINSERT, Registro)).Rows[0]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void _Closed_Register(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                if (this.Registro.cartao_acesso_reg_seq == 0)
                    throw new Exception("Registro de Log não encontrado para ser finalizado <cartao_acesso_reg_seq is null>");

                Registro.cartao_acesso_reg_status = 0;
                BDCommand.get_DataTable(MyConnect, F0136_03_CartaoAcessoRegistroCRUD.Post(MyConnect, Models.BDCommandTypes.DBUPDATE, Registro));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }


    public class model_cartao_acesso_registro: tbcartao_acesso_registro
    {

        public int controle_pessoa_cd { get; set;  }
        public int cdpessoabluesoft { get; set;  }
        public int rh_funcionario_cd { get; set;  }
        public string cpf_cnpj { get; set;  }
        public string nome_razao { get; set;  }
        public string controle_pessoa_descricao { get; set;  }
        public int controle_reg_seq { get; set;  }
        public string controle_descricao { get; set;  }
        public string LOCAL_cartao_acesso_reg_status
        {
            get
            {
                if (cartao_acesso_reg_status == 0)
                    return "";
                else
                    return "Em Uso";
            }
        }

        public model_cartao_acesso_registro () : base() {}
        public model_cartao_acesso_registro(DataRow i) : base(i) {}


        public void Binding(DataRow i)
        {

            cartao_acesso_data = Convert.ToDateTime(i["cartao_acesso_data"].ToString());
            cartao_acesso_reg_seq = Convert.ToInt32(i["cartao_acesso_reg_seq"].ToString());
            cartao_acesso_seq = Convert.ToInt32(i["cartao_acesso_seq"].ToString());
            controle_reg_pessoa_seq = Convert.ToInt32(i["controle_reg_pessoa_seq"].ToString());
            cartao_acesso_reg_status = Convert.ToInt32(i["cartao_acesso_reg_status"].ToString());
            
            controle_pessoa_cd = Convert.ToInt32(i["controle_pessoa_cd"].ToString());
            cdpessoabluesoft = Convert.ToInt32(i["cdpessoabluesoft"].ToString());
            rh_funcionario_cd = Convert.ToInt32(i["rh_funcionario_cd"].ToString());
            cpf_cnpj = i["cpf_cnpj"].ToString();
            nome_razao = i["nome_razao"].ToString();
            controle_pessoa_descricao = i["controle_pessoa_descricao"].ToString();
            controle_reg_seq = Convert.ToInt32(i["controle_reg_seq"].ToString());
            controle_descricao = i["controle_descricao"].ToString();
        }
    }
}
