using Pag_Net.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.Veiculo
{
    public static class Modelos
    {
        public static DataTable Obter_lista(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                return Pag_Net.Bll.BDCommand.get_DataTable(MyConnect, BDCommand.Name.R0131_03, "");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    
    public static class Pool
    {
        public static TbVeiculo New(Pag_Net.Models.modelSistemaUsuario MyConnect, TbVeiculo _veiculo)
        {
            try
            {
                Veiculo_Inserir(MyConnect, _veiculo);
                return Veiculo_Consultar(MyConnect, _veiculo.veiculo_placa);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public static void Veiculo_Inserir(Pag_Net.Models.modelSistemaUsuario MyConnect, TbVeiculo _veiculo )
        {
            try
            {
                Pag_Net.Bll.BDCommand.Post(MyConnect,
                        BDCommand.Name.F0131_01,
                        string.Format(" 'DBINSERT', {0}, '{1}', {2}, '{3}', {4}",
                        _veiculo.veiculo_seq.ToString(), 
                        _veiculo.veiculo_placa.ToString(),
                        _veiculo.veiculo_modelo_cd.ToString(),
                        _veiculo.veiculo_observacao.ToString(),
                        _veiculo.veiculo_ano.ToString()
                        ));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
        public static TbVeiculo Veiculo_Consultar(Pag_Net.Models.modelSistemaUsuario MyConnect, string _placa)
        {
            TbVeiculo _Veiculo_Consultar_Retorno = new TbVeiculo();
            try
            {
                DataTable _DataTable_Veiculo_Consulta = BDCommand.get_DataTable(MyConnect, BDCommand.Name.R0131_01_Veiculo_Consulta, string.Format("'{0}'", _placa));
                if (_DataTable_Veiculo_Consulta.Rows.Count > 0 )
                {
                    _Veiculo_Consultar_Retorno = new TbVeiculo(_DataTable_Veiculo_Consulta.Rows[0]);
                }
                return _Veiculo_Consultar_Retorno;

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }

    public class TbVeiculo
    {
        public int      veiculo_seq             {get;set;}
		public string   veiculo_placa           {get;set;}
		public int      veiculo_modelo_cd       {get;set;}
		public string   veiculo_observacao      {get;set;}
        public int      veiculo_ano             {get;set;}
        public string veiculo_modelo_descricao { get; set; }
        
        public TbVeiculo() {
            veiculo_seq = 0;
            veiculo_placa = "";
            veiculo_modelo_cd = 0;
            veiculo_observacao = "SEM OBSERVAÇÃO";
            veiculo_ano = 0;
        }
        public TbVeiculo
        (

            int      _veiculo_seq,          
            string   _veiculo_placa,        
            int      _veiculo_modelo_cd,    
            string   _veiculo_observacao,   
            int      _veiculo_ano         

        )
        {


            veiculo_seq = 0;
            veiculo_placa = "";
            veiculo_modelo_cd = 0;
            veiculo_observacao = "SEM OBSERVAÇÃO";
            veiculo_ano = 0;


                
            veiculo_seq              =       _veiculo_seq;         
            veiculo_placa            =       _veiculo_placa;
            veiculo_modelo_cd        =       _veiculo_modelo_cd != 0 ?  _veiculo_modelo_cd: 0;
            veiculo_observacao       =       _veiculo_observacao != ""? _veiculo_observacao: "";
            veiculo_ano              =       _veiculo_ano > 0 ? _veiculo_ano: 0;          


        }

        public TbVeiculo(DataRow i)
        {






            veiculo_seq              =  Convert.ToInt32(i["veiculo_seq"]);
            veiculo_placa            =  i["veiculo_placa"].ToString();
            veiculo_modelo_cd        =  Convert.ToInt32(i["veiculo_modelo_cd"].ToString());
            veiculo_observacao       =  i["veiculo_observacao"].ToString();
            veiculo_ano              =  Convert.ToInt32(i["veiculo_ano"].ToString());
            veiculo_modelo_descricao = i["veiculo_modelo_descricao"].ToString();
        }

    }

}
