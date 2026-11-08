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
    public static class DaOperacaoSacOperadoresAtivos
    {
        public static TbOperacoesSacOperadoresAtivos[] Select(ModelSysUserInfo MyConnect, DateTime _dataOperacao)
        {
            SqlCommand _SqlCommand = new SqlCommand("PrOperacaoSacStatus");
            _SqlCommand.CommandType = CommandType.StoredProcedure;
            dalUtil.SqlParameterCreatorAdd(SqlDbType.VarChar, "TipoRelatorio", "OPERADORES_ATIVOS", true, _SqlCommand);
            dalUtil.SqlParameterCreatorAdd(SqlDbType.SmallDateTime, "DataOperacao", _dataOperacao, true, _SqlCommand);
            dalConnectX _SqldalConnectXInsert = new dalConnectX(MyConnect, DataBaseName.DBAMAINADM, _SqlCommand, IsolationLevel.Unspecified);
            SqlDataReader _SqlDataReader = _SqldalConnectXInsert.SqlDataReader_Select();
            List<TbOperacoesSacOperadoresAtivos> _list = new List<TbOperacoesSacOperadoresAtivos>();
            while (_SqlDataReader.Read())
            {
                TbOperacoesSacOperadoresAtivos _tboperacaosacoperadoresativos = new TbOperacoesSacOperadoresAtivos();
                _tboperacaosacoperadoresativos.NomeOperador = _SqlDataReader["NomeOperador"].ToString();
                _tboperacaosacoperadoresativos.CdOperador = Convert.ToInt32(_SqlDataReader["CodigoOperador"].ToString());
                _tboperacaosacoperadoresativos.ECF = Convert.ToInt32(_SqlDataReader["ECF"].ToString());
                _tboperacaosacoperadoresativos.HoraInicial = _SqlDataReader["HI"].ToString();
                _tboperacaosacoperadoresativos.HoraFinal = _SqlDataReader["HF"].ToString();
                _tboperacaosacoperadoresativos.Registros = Convert.ToInt32(_SqlDataReader["Registros"].ToString());
                _tboperacaosacoperadoresativos.ValorEntrada = Convert.ToDouble(_SqlDataReader["ValorEntrada"].ToString());
                _tboperacaosacoperadoresativos.ValorFaturamentoDinheiro = Convert.ToDouble(_SqlDataReader["ValorFaturamentoDinheiro"].ToString());
                _tboperacaosacoperadoresativos.ValorSangria = Convert.ToDouble(_SqlDataReader["ValorSangria"].ToString());
                _tboperacaosacoperadoresativos.ValorReforco = Convert.ToDouble(_SqlDataReader["ValorReforco"].ToString());
                _list.Add(_tboperacaosacoperadoresativos);

            }
            return _list.ToArray();

        }
    }
}
