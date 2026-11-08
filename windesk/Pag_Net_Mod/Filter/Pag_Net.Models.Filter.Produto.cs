using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Models.Filter
{
    /*
    public class Produto
    {
        public Produto() { }
        public Produto(int _pr_cdproduto)
        {
            CdProduto = _pr_cdproduto.ToString();
        }
    


        private string _vcdproduto = "0";
        public string CdProduto
        {
            get { return _vcdproduto; }
            set { try { if (Convert.ToInt32(value) > 0) _vcdproduto = value.ToString(); else _vcdproduto = "0"; } catch (Exception ex) { throw new Exception("Valor inválido: " + ex.Message); } }
        }


        private string vcdprodutobluesoft = "0";
        public string CdProdutoBluesoft
        {
            get { return vcdprodutobluesoft; }
            set { try { if (Convert.ToInt32(value) > 0) vcdprodutobluesoft = value.ToString(); else vcdprodutobluesoft = "0"; } catch (Exception ex) { throw new Exception("Valor inválido: " + ex.Message); } }
        }


        private string _vdescricao = "";
        public string Descricao
        {
            get { return _vdescricao; }
            set { try { if (value != string.Empty) _vdescricao = value.ToString().Replace("'", "").ToUpper(); else _vdescricao = ""; } catch (Exception ex) { throw new Exception("Valor inválido: " + ex.Message); } }
        }


        private string _vdescricao_fiscal = "";
        public string Descricao_Fiscal
        {
            get { return _vdescricao; }
            set { try { if (value != string.Empty) _vdescricao_fiscal = value.ToString().Replace("'", "").ToUpper(); else _vdescricao_fiscal = ""; } catch (Exception ex) { throw new Exception("Valor inválido: " + ex.Message); } }
        }

        public DateTime Dt_cadastro_ini { get; set; }
        public DateTime Dt_cadastro_fim { get; set; }

        public bool Seleciona_Data_Cadastro { get; set; }

        public bool Status_Ativo { get; set; }
        public bool Status_Inativo { get; set; }


        public int Prd_cddepartamento { get; set; }
        public int Prd_cdsecao { get; set; }
        public int Prd_cdgrupo { get; set; }
        public int Prd_subcdgrupo { get; set; }

        private string _Codigo_de_Barra = "";
        public string Codigo_de_Barra
        {
            get { return _Codigo_de_Barra; }
            set {
                try
                {
                    if (value.Where(c => char.IsLetter(c)).Count() > 0)
                    {
                        throw new Exception("Valor inválido");
                    }
                    else
                    {
                        _Codigo_de_Barra = value.Trim();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

        }

        public void _ValidarFiltros()
        {
            int validate_cdproduto = Convert.ToInt32(CdProduto);
            int validate_cdprodutobluesoft = Convert.ToInt32(CdProdutoBluesoft);
            string validate_descricao = Descricao;
            DateTime validate_dt_cadastro_ini = DateTime.Now;
            DateTime validate_dt_cadastro_fim = DateTime.Now;
            if (Seleciona_Data_Cadastro)
            {
                if (Dt_cadastro_ini > Dt_cadastro_fim)
                {
                    throw new Exception("Período informado para a busca pela data de cadatro incorreto: Data inicial maior que a final");
                }
            }
            else
            {
                Dt_cadastro_ini = DateTime.Now;
                Dt_cadastro_fim = DateTime.Now;
            }
        }

  
    }
     */
}
