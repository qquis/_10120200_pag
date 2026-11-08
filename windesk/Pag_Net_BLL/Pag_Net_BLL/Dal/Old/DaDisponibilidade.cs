using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Xml;
using System.IO;
using System.Linq;
using Pag_Net.Models;
using Pag_Net.Dal;
using System.Reflection;

namespace Pag_Net.Dal
{
    public class DaDisponibilidade
    {
        public static TbDisponibilidadeEmpresa[] GetListDisponibilidadeEmpresa(modelSistemaUsuario myconnect, int _CdEmpresa,
                                                                                                                          int _CdOperacao,
                                                                                                                          int _CdDepartamento,
                                                                                                                          int _CdSecao,
                                                                                                                          int _CdLinha,
                                                                                                                          string _CdProduto,
                                                                                                                          string _DescricaoProduto,
                                                                                                                          string _CdBarra,
                                                                                                                          int _CdEquipeRepositor
                                                                                                                          )
        {
            SqlCommand _SqlCommand = new SqlCommand("PrDisponibilidade");
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "CdEmpresa", _CdEmpresa, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "CdOperacao", _CdOperacao, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "CdDepartamento", _CdDepartamento, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "CdSecao", _CdSecao, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "CdLinha", _CdLinha, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "CdProduto", _CdProduto, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.VarChar, "DescricaoProduto", _DescricaoProduto, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Decimal, "CdBarra", _CdBarra, true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.Int, "CdEquipeRepositor", _CdEquipeRepositor, true, _SqlCommand);
            dalConnectX _dalConnectX = new dalConnectX(myconnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
            SqlDataReader _SqlDataReader = _dalConnectX.SqlDataReader_Select();
            List<TbDisponibilidadeEmpresa> _list = new List<TbDisponibilidadeEmpresa>();
            while (_SqlDataReader.Read())
            {
                TbDisponibilidadeEmpresa x = new TbDisponibilidadeEmpresa();
                x.CdProduto = Convert.ToInt32(_SqlDataReader["CdProduto"].ToString());
                x.DescricaoProduto = _SqlDataReader["DescricaoProduto"].ToString();
                x.UndEst = _SqlDataReader["UndEst"].ToString();
                x.UndCmp = _SqlDataReader["UndCmp"].ToString();
                //x.Fator = Convert.ToInt32(_SqlDataReader["Fator"].ToString());
                x.Qtde = Convert.ToInt32(_SqlDataReader["EstoqueAtual"].ToString());
                _list.Add(x);
            }
            _SqlDataReader.Close();
            return _list.ToArray();
        }
    }
}
