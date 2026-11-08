/*
 * _https://oxan.acelerato.com/tickets/20283 | Implementações 
*/


using System;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Pag_Net.Models;



namespace Pag_Net.Models
{
    public enum BDCommandTypes
    {
        DBUPDATE,
        DBINSERT,
        DBSELECT,
        DBDELETE,
        BDEXECUTE,
        DBDELETEALL, 
        CRUD,
        DBCRUD
    }

    public static class PagInfo
    {
        /*
         * Versao 1.01
         * Implementações 20.08
         * Correção: 310
         
        */

        
        /*VERSAO COR*/
        public static string VERSAO_ECOSYSTEM { get { return "2020";  } }

        /*VERSAO AGREGATIVA*/
        public static string VERSAO { get { return "0"; } }

        /*VERSAO PAG DESKTOP*/
        public static string VERSAO_COMMIT { get { return "00"; } }

        public static string VERSAO_DESKTOP_REVISION { get { return "10"; } }

        public static string Version_description { get { return "Version " + VERSAO_ECOSYSTEM + "." + VERSAO + "." + VERSAO_COMMIT + "- DESK TOP - " + VERSAO_DESKTOP_REVISION; } }
        

        public static string GetPathConfig { get { return @System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("Pag_Net_Mod.dll", "") + @"Configs"; } }
        public static string GetPathIco { get { return @System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Replace("Pag_Net_Mod.dll", "") + @"Ico"; } }
    }

    public class PagSystemProgressInf : EventArgs
    {
        public string MetodoExecute { get; set; }
        public int ValorInicial { get; set; }

        private bool _changed;
        public bool Changed
        {
            get
            {
                return _changed;
            }
        }

        private int _ValorFinal;
        public int ValorFinal
        {
            get
            {

                return _ValorFinal;
            }
            set
            {
                _ValorFinal = value;
            }

        }
        

        private int[] vl_etapa;
        private int index;


        public int ProgressBarSteps = 10;


        private int _ValorAtual;
        public int ValorAtual
        {
            get
            {
                return _ValorAtual;
            }
            set
            {
                _ValorAtual = value;
                if (_ValorAtual > vl_etapa[index])
                {
                    if (index < 9)
                    {
                        index = index + 1;
                    }
                    else
                    {
                        index = 9;
                    }
                    _changed = true;
                }
                else
                {
                    _changed = false;
                }

            }
        }
        public int ValorEtapa
        {
            get
            {

                return vl_etapa[index];
            }
            //set;

        }

        public PagSystemProgressInf()
        {

        }


        public PagSystemProgressInf(string __MetodoExecute, int __ValorInicial, int __ValorFinal)
        {

            Set(__MetodoExecute, __ValorInicial, __ValorFinal);


            //ValorAtual = _ValorAtual;

        }

        public void Set(string __MetodoExecute, int __ValorInicial, int __ValorFinal)
        {

            MetodoExecute = __MetodoExecute;
            ValorInicial = __ValorInicial;
            _ValorFinal = __ValorFinal;

            index = 0;

            vl_etapa = new int[10];
            for (int i = 0; i < vl_etapa.Length; i++)
            {
                double result = Convert.ToDouble(_ValorFinal / 10 * (i + 1));
                vl_etapa[i] = Convert.ToInt32(Math.Round(result, 0));
            }
        }
    }
    public static class pag_cnpj_cpf
    {

        public static string get(string VALUE)
        {
            if ((Pag_Net.Models.BDTools.DocCPF_CNPJ_Validar(VALUE)))
            {
                return string.Concat(Enumerable.Repeat("0", 14 - VALUE.Length)) + VALUE.Trim();
            }
            else
            {
                throw new Exception("CNPJ/CPF Inválido");
            }

        }
    }
    public static class BDTools
    {
        public static string SqlCommandType(Pag_Net.Models.BDCommandTypes _Type)
        {
            string SqlCommand = "DBUPDATE";
            switch (_Type)
            {
                case Pag_Net.Models.BDCommandTypes.DBDELETE:
                    SqlCommand = "DBDELETE";
                    break;
                case Pag_Net.Models.BDCommandTypes.DBDELETEALL:
                    SqlCommand = "DBDELETEALL";
                    break;
                case Pag_Net.Models.BDCommandTypes.DBINSERT:
                    SqlCommand = "DBINSERT";
                    break;

                case Pag_Net.Models.BDCommandTypes.DBSELECT:
                    SqlCommand = "DBSELECT";
                    break;
                case Pag_Net.Models.BDCommandTypes.DBUPDATE:
                    SqlCommand = "DBUPDATE";
                    break;
                case Pag_Net.Models.BDCommandTypes.BDEXECUTE:
                    SqlCommand = "DBEXECUTE";
                    break;
            }
            return SqlCommand;
        }
        public static bool boolColumnResult(string i)
        {
            bool resultado = false;
            switch (i.ToUpper())
            {
               case "0":
                    resultado = false;
                    break;
               case "1":
                    resultado = true;
                    break;
               case "FALSE":
                    resultado = false;
                    break;
               case "TRUE":
                    resultado = true;
                    break;
               default:
                    resultado = false;
                    break;
            }
            return resultado;
        }

        public static string DoCPF_CNPJ_Get_FormatZERO(string VALUE) { return string.Concat(Enumerable.Repeat("0", 14 - VALUE.Length)) + VALUE.Trim(); }
        public static string DoCPF_CNPJ_Get(string VALUE)
        {
            string CPFCPNPJ = DoCPF_CNPJ_Get_FormatZERO(VALUE);
            if (!DocCPF_CNPJ_Validar(CPFCPNPJ))
            {
                if (DocCPF_Validar(CPFCPNPJ.Substring(3,11)))
                {
                    return CPFCPNPJ;
                }
                else
                {
                    throw new Exception("CPNJ/CPF Inválido: " + CPFCPNPJ);
                }
            }
            else
            {
                return CPFCPNPJ;
            }
        }
        public static bool DocCPF_CNPJ_Validar(string _numero)
        {
            bool retorno = false;
            if (_numero == null)
            {
                retorno = false;
            }
            else
            {
                switch (_numero.Length)
                {
                    case 14:
                        retorno = DocCNPJ_Validar(_numero);
                        break;
                    case 11:
                        retorno = DocCPF_Validar(_numero);
                        break;
                }
            }
            return retorno;

        }
        public static bool DocCPF_Validar(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }
        public static bool DocCNPJ_Validar(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;

            tempCnpj = cnpj.Substring(0, 12);

            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }
        public static string uf_sigla(int _codigo_uf_numero)
        {
            string sigla_estado = "SP";
            switch(_codigo_uf_numero)
            {
                case 11: sigla_estado = "RO"; break;
                case 12: sigla_estado = "AC"; break;
                case 13: sigla_estado = "AM"; break;
                case 14: sigla_estado = "RR"; break;
                case 15: sigla_estado = "PA"; break;
                case 16: sigla_estado = "AP"; break;
                case 17: sigla_estado = "TO"; break;
                case 21: sigla_estado = "MA"; break;
                case 22: sigla_estado = "PI"; break;
                case 23: sigla_estado = "CE"; break;
                case 24: sigla_estado = "RN"; break;
                case 25: sigla_estado = "PB"; break;
                case 26: sigla_estado = "PE"; break;
                case 27: sigla_estado = "AL"; break;
                case 28: sigla_estado = "SE"; break;
                case 29: sigla_estado = "BA"; break;
                case 31: sigla_estado = "MG"; break;
                case 32: sigla_estado = "ES"; break;
                case 33: sigla_estado = "RJ"; break;
                case 35: sigla_estado = "SP"; break;
                case 41: sigla_estado = "PR"; break;
                case 42: sigla_estado = "SC"; break;
                case 43: sigla_estado = "RS"; break;
                case 50: sigla_estado = "MS"; break;
                case 51: sigla_estado = "MT"; break;
                case 52: sigla_estado = "GO"; break;
                case 53: sigla_estado = "DF"; break;

            }
            return sigla_estado;


        }
        public static bool nfe_chave_validar(string numero_chave)
        {
            if (numero_chave.Length != 44)
                return false;
            else
                return true;

            /*
            string chave = numero_chave;
            int digito = Convert.ToInt32(numero_chave.Substring(43, 1));

            int soma = 0; // Vai guardar a Soma
            int mod = -1; // Vai guardar o Resto da divisão
            int dv = -1;  // Vai guardar o DigitoVerificador
            int pesso = 2; // vai guardar o pesso de multiplicacao

            //percorrendo cada caracter da chave da direita para esquerda para fazer os calculos com o pesso
            for (int i = chave.Length - 1; i != -1; i--)
            {
                int ch = Convert.ToInt32(chave[i].ToString());
                soma += ch * pesso;
                //sempre que for 9 voltamos o pesso a 2
                if (pesso < 9)
                    pesso += 1;
                else
                    pesso = 2;
            }

            //Agora que tenho a soma vamos pegar o resto da divisão por 11
            mod = soma % 11;
            //Aqui temos uma regrinha, se o resto da divisão for 0 ou 1 então o dv vai ser 0
            if (mod == 0 || mod == 1)
                dv = 0;
            else
                dv = 11 - mod;

            if ( dv != digito)
            {
                return false; 
            }
            else 
            {
                return true;
            }
            */

        }
    }
    
    public enum Command
    {
        Insert,
        Update,
        Delete,
        Select
    }
    public enum ModelEnumTypeProcess
    {
        Read,
        Write,
        List
    }

    public partial class Parametros
    {
        public Command Command { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(sender, e);
            }
        }
    }
    public class ParameterQuey
    {
        public string ParametroNome { get; set; }
        public SqlDbType ParametroTipo { get; set; }
        public DbType ParametroTipoComum { get; set; }
        public bool ParametroNull { get; set; }
        public object Valor { get; set; }
        public ParameterQuey() { }

        public ParameterQuey(string _parametroNome, SqlDbType _parametroTipo, bool _parametroNull, object _valor)
        {
            this.ParametroNome = _parametroNome;
            this.ParametroTipo = _parametroTipo;
            this.ParametroNull = _parametroNull;
            this.Valor = _valor;
        }

        public ParameterQuey(string _parametroNome, DbType _parametrotipoComum, SqlDbType _parametroTipo, bool _parametroNull, object _valor)
        {
            this.ParametroNome = _parametroNome;
            this.ParametroTipo = _parametroTipo;
            this.ParametroNull = _parametroNull;
            this.ParametroTipoComum = _parametrotipoComum;
            this.Valor = _valor;

        }
    }



    public class TbSysTbTipos
    {
        public string DescricaoTipo { get; set; }
        public int SeqTipo { get; set; }
        public string ObservacaoTipo { get; set; }
        public string CdTipo { get; set; }
        public string Tabela { get; set; }
        public string Campo { get; set; }
        public string Cd_Parametro { get; set; }
        public TbSysTbTipos()
        {

        }
    }
    public class TbSysTbOperacoes
    {

        public int CdEmpresa { get; set; }
        public int CdOperacao { get; set; }
        public string DescricaoOperacao { get; set; }
        public int SeqTipoOperacao { get; set; }
        public string DescricaoTipoOperacao { get; set; }
        public string CdTipo { get; set; }
        public int Cd_Tarefa { get; set; }
        public int Cd_Form_Proc { get; set; }
        public string Menu { get; set; }
        public string Formulario { get; set; }



    }


    public class TbStatusNfe
    {
        public int statusNfe_id { get; set;  }
        public string statusNfe_descricao { get; set; }
        public TbStatusNfe(int _statusNfe_id , string _statusNfe_descricao)
        {
            statusNfe_id = _statusNfe_id;
            statusNfe_descricao = _statusNfe_descricao;
        }
        
    }
    public static class ListStatusNfe
    {
    
        public static TbStatusNfe[] get()
        {
            List<TbStatusNfe> _list = new List<TbStatusNfe>();
            _list.Add(new TbStatusNfe(0, "Todos"));
            _list.Add(new TbStatusNfe(1, "Sem Manifestação"));
            _list.Add(new TbStatusNfe(2, "Confirmação da Operação"));
            _list.Add(new TbStatusNfe(3, "Ciência da Operação"));
            _list.Add(new TbStatusNfe(4, "Desconhecimento da Operação"));
            _list.Add(new TbStatusNfe(5, "Operação Não Realizada"));
            return _list.ToArray();
        }
    
    }

    public static class Model_info
    {
        public static object TipoSexo()
        {

            var items = new[] { 
                new { Text = "MASCULINO", Value = "M" }, 
                new { Text = "FEMININO", Value = "F" }, 
                

            };

            return items;
            
        }

    }




}
