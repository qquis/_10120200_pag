using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Xml;
using System.IO;
using System.Linq;
using Pag_Net.Models.ModeloBase;
using Pag_Net.Models;
using Pag_Net.Dal;
using System.Reflection;

namespace Pag_Net.Dal
{
    public class DaStatusProdutoPreco
    {
        public enum TipoProcessamento { StatusServidores = 1, StatusErp = 2 }




        public static Models.ModeloBase.TbStatusProdutoPreco[] GetList(modelSistemaUsuario _myConnect)
        {
            return GetList(_myConnect, TipoProcessamento.StatusServidores);
        }
        public static Models.ModeloBase.TbStatusProdutoPreco[] GetList(modelSistemaUsuario MyConnect, TipoProcessamento _tipoProcessamento)
        {
            string _strcommand = "prStatusZanthusProdutoPreco";
            DataBaseName _database = DataBaseName.DBAMAINADM;

            if (_tipoProcessamento == TipoProcessamento.StatusErp)
            {
                _strcommand = "prStatusProdutoPreco";
                _database = DataBaseName.DBAMAINERP;
            }

            SqlCommand _SqlCommand = new SqlCommand(_strcommand);
            _SqlCommand.CommandType = CommandType.StoredProcedure;





            dalConnectX _dalConnectX = new dalConnectX(MyConnect, _database, _SqlCommand, IsolationLevel.Unspecified);
            SqlDataReader _sqlDataReader = _dalConnectX.SqlDataReader_Select();
            List<Models.ModeloBase.TbStatusProdutoPreco> _list = new List<Models.ModeloBase.TbStatusProdutoPreco>();
            while (_sqlDataReader.Read())
            {
                Models.ModeloBase.TbStatusProdutoPreco item = new Models.ModeloBase.TbStatusProdutoPreco();

                item.Codigo = Convert.ToInt32(_sqlDataReader["Codigo"]);
                item.Descricao = _sqlDataReader["Descricao"].ToString();
                item.Cadastro = Convert.ToDateTime(_sqlDataReader["Cadastro"].ToString());
                item.CodigoBarra = Convert.ToString(_sqlDataReader["CodigoBarra"].ToString());
                item.Unidade = _sqlDataReader["Unidade"].ToString();
                item.PrecoOn = Convert.ToDouble( _sqlDataReader["PrecoOn"].ToString());
                item.PrecoOx = Convert.ToDouble( _sqlDataReader["PrecoOx"].ToString());
                item.PrecoZanthus = Convert.ToDouble( _sqlDataReader["PrecoZn"].ToString());
                item.EstoqueAtual = Convert.ToDouble(_sqlDataReader["Qtde"].ToString());
                item.Situacao = _sqlDataReader["Situacao"].ToString();

                _list.Add(item);
            }
            return _list.ToArray();
        }
    }
}
