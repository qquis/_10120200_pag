using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0130_Controle
{
    public class model_controle : TbControle
    {

        public TbControle_Fila[] Filas;
        public TbControle_Pessoa[] Pessoas;
        public TbControle_Etapa[] Etapas;
        public model_controle()
        {
            controle_cd = 0;
            controle_descricao = "";
        }
        public model_controle(

             int _controle_cd,
             string _controle_descricao
            )
        {

            controle_cd = _controle_cd;
            controle_descricao = _controle_descricao;


        }
        public model_controle(DataRow i)
        {
            controle_cd = Convert.ToInt32(i["controle_cd"]);
            controle_descricao = i["controle_descricao"].ToString();
        }

        public void Binding(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {


                if (this.controle_cd == 0)
                {
                    throw new Exception("Código do Tipo de Controle (Controle_cd) não informado \n <Binding ModelControl>");

                }

                DataTable _DataTableCONTROLES = BDCommand.get_DataTable(MyConnect, F0130_01_Controle_Consultar.Get(MyConnect, this.controle_cd));
                this.controle_descricao = _DataTableCONTROLES.Rows[0]["controle_descricao"].ToString();
                this.controle_etapa_final = Convert.ToInt32(_DataTableCONTROLES.Rows[0]["controle_etapa_final"].ToString());
                this.controle_status_cd_inicial = Convert.ToInt32(_DataTableCONTROLES.Rows[0]["controle_status_cd_inicial"].ToString());
                this.controle_status_pgto_cd_inicial = Convert.ToInt32(_DataTableCONTROLES.Rows[0]["controle_status_pgto_cd_inicial"].ToString());

                /* ----------------------- FILA ----------------------------------- */
                DataTable _DATATABLES_FILA = BDCommand.get_DataTable(MyConnect, F0130_02_Controle_Fila_Consultar.Get(MyConnect, this.controle_cd));
                List<TbControle_Fila> _Controle_Fila = new List<TbControle_Fila>();
                if (_DATATABLES_FILA.Rows.Count > 1)
                    _Controle_Fila.Add(new TbControle_Fila(0, 0, "SELECIONE A FILA"));
                foreach (DataRow i in _DATATABLES_FILA.Rows)
                {
                    _Controle_Fila.Add(new TbControle_Fila(i));
                }
                Filas = _Controle_Fila.ToArray();
                _DATATABLES_FILA.Dispose();

                /* ----------------------- TIPO DE PESSOA <TBCONTROLE_PESSOA ----------------------------------- */
                DataTable _DATATABLES_PESSOA = BDCommand.get_DataTable(MyConnect, F0130_03_Controle_Pessoa_Consultar.Get(MyConnect, this.controle_cd));
                List<TbControle_Pessoa> _Controle_Pessoa = new List<TbControle_Pessoa>();
                foreach (DataRow i in _DATATABLES_PESSOA.Rows)
                {
                    _Controle_Pessoa.Add(new TbControle_Pessoa(i));
                }
                Pessoas = _Controle_Pessoa.ToArray();


                /* ----------------------- TIPOS DE ETAPAS DISPONÍVEIS ---------------------------------------- */
                DataTable _DATATABLES_TBCONTROLE_ETAPA = BDCommand.get_DataTable(MyConnect, F0130_04_Controle_Etapa_Consultar.Get(MyConnect, this.controle_cd));
                List<TbControle_Etapa> _LIST_Controle_Etapa = new List<TbControle_Etapa>();
                foreach (DataRow i in _DATATABLES_TBCONTROLE_ETAPA.Rows)
                {
                    _LIST_Controle_Etapa.Add(new TbControle_Etapa(i));
                }
                Etapas = _LIST_Controle_Etapa.ToArray();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
