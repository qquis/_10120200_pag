using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace Pag_Net.Bll.Operacionais.Varejo.Execucao
{
    public class UspEtiquetaGondola: Bll.USPDataContext
    {
        public EtiquetaFiltros Filtros;
        public UspEtiquetaGondola(Models.modelSistemaUsuario _myConnect)
            : base(_myConnect)
        {
            Filtros = new EtiquetaFiltros();
        }
        public void Select()
        {
            try
            {
                List<UVWEtiquetaGondola> L = new List<UVWEtiquetaGondola>();
                base.Select();
                int index = 0;
                foreach (DataRow i in base.DataTableResult.Rows)
                {

                    UVWEtiquetaGondola l = new UVWEtiquetaGondola();
                    l.CdProduto  = Convert.ToInt32(i["CdProduto"]);
                    l.Descricao = i["Descricao"].ToString();
                    l.Embalagem = i["Embalagem"].ToString();
                    l.EmbalagemDescricao = i["EmbalagemDescricao"].ToString();
                    l.ValorPreco = Convert.ToDouble( i["ValorPreco"].ToString());
                    l.AtacadoValorPreco  = Convert.ToDouble(i["AtacadoValorPreco"].ToString());
                    l.AtacadoQtdeMinima= Convert.ToDouble(i["AtacadoQtdeMinima"].ToString());
                    l.AtacadoQtdePromocional = Convert.ToDouble(i["AtacadoQtdePromocional"].ToString());
                    l.CodigoBarra = i["CodigoBarra"].ToString();
                    l.TipoCodigoBarra = i["TipoCodigoBarra"].ToString();
                    l.AtacadoEmbalagem = i["AtacadoEmbalagem"].ToString();
                    l.AtacadoCodigoBarra = i["AtacadoCodigoBarra"].ToString();
                    l.ImpressaoPadrao = Convert.ToBoolean(i["ImpressaoPadrao"].ToString());


                    L.Add(l);
                    index = index + 1;
                }
                base.ViewData = L.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public override Models.ParameterQuey[] ListParametros()
        {
            List<Models.ParameterQuey> ListParameters = new List<Models.ParameterQuey>();

            ListParameters.Add(new Models.ParameterQuey("CdProdutoDepartamento", SqlDbType.VarChar, true, this.Filtros.CdProdutoDepartamento ));
            ListParameters.Add(new Models.ParameterQuey("CdProdutoSecao", SqlDbType.VarChar, true, this.Filtros.CdProdutoSecao));
            ListParameters.Add(new Models.ParameterQuey("CdProdutoLinha", SqlDbType.VarChar, true, this.Filtros.CdProdutoLinha));
            ListParameters.Add(new Models.ParameterQuey("Descricao", SqlDbType.VarChar, true, this.Filtros.Descricao));
            ListParameters.Add(new Models.ParameterQuey("Codigos", SqlDbType.VarChar, true, this.Filtros.Codigos));
            ListParameters.Add(new Models.ParameterQuey("SequenciaisProcessamentos", SqlDbType.VarChar, true, this.Filtros.SequenciaisProcessamentos));
            ListParameters.Add(new Models.ParameterQuey("CodigoBarra", SqlDbType.VarChar, true, this.Filtros.CodigoBarra));

            
            
            return ListParameters.ToArray();
                
        }
        public override string SQLCommnad()
        {
            /*09/04/2021 _ #13708 - DESENVOLVIMENTO PAG | Pag_1.01.173 - Implantação UNIFICAÇÃO DO CADASTRO DE PRODUTO */ 
            //return "SPP0072_EtiquetaGondola";
            return "UspEtiquetaGondola";
            
        }

    }

    public class UVWEtiquetaGondola
    {
        

        public int      CdProduto                    { get; set; }
        public string   Descricao                 { get; set; }
        public string   Embalagem                 { get; set; }
        public string   EmbalagemDescricao        { get; set; }
        public double   ValorPreco                { get; set; }
        public string   CodigoBarra               { get; set; }
        public string   TipoCodigoBarra           { get; set; }
        public string   AtacadoEmbalagem          { get; set; }
        public double   AtacadoValorPreco         { get; set; }
        public double   AtacadoQtdeMinima         { get; set; }
        public double   AtacadoQtdePromocional    { get; set; }
        public string   AtacadoCodigoBarra        { get; set; }
        public bool     ImpressaoPadrao             { get; set; }

        public UVWEtiquetaGondola() { }
        public UVWEtiquetaGondola(
                 int    _CdProduto                    
            ,    string _Descricao                 
            ,    string _Embalagem                 
            ,    string _EmbalagemDescricao        
            ,    double _ValorPreco                
            ,    string _CodigoBarra               
            ,    string _TipoCodigoBarra           
            ,    string _AtacadoEmbalagem          
            ,    double _AtacadoValorPreco         
            ,    double _AtacadoQtdeMinima         
            ,    double _AtacadoQtdePromocional    
            ,    string _AtacadoCodigoBarra        
            ,    bool   _ImpressaoPadrao             
            )
        {
            
            CdProduto                 =         _CdProduto                      ;                 
            Descricao                 =         _Descricao                      ;
            Embalagem                 =         _Embalagem                      ;
            EmbalagemDescricao        =         _EmbalagemDescricao             ;
            ValorPreco                =         _ValorPreco                     ;
            CodigoBarra               =         _CodigoBarra                    ;
            TipoCodigoBarra           =         _TipoCodigoBarra                ;
            AtacadoEmbalagem          =         _AtacadoEmbalagem               ;
            AtacadoValorPreco         =         _AtacadoValorPreco              ;
            AtacadoQtdeMinima         =         _AtacadoQtdeMinima              ;
            AtacadoQtdePromocional    =         _AtacadoQtdePromocional         ;
            AtacadoCodigoBarra        =         _AtacadoCodigoBarra             ;
            ImpressaoPadrao           =         _ImpressaoPadrao;





        
        }

    }

    public class EtiquetaFiltros
    {
        public bool DataCadastro { get; set; }
        public DateTime DataCadastroInicial { get; set; }
        public DateTime DataCadastroFinal { get; set; }
        public string CdProdutoDepartamento { get; set; }
        public string CdProdutoSecao { get; set; }
        public string CdProdutoLinha { get; set; }
        public string Descricao { get; set; }
        public string Codigos { get; set; }
        public string SequenciaisProcessamentos { get; set; }
        public string CodigoBarra { get; set; }

    }

}
