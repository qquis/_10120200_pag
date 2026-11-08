using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Pag_Net.Bll.F0131_Veiculo
{

    public class TbVeiculo
    {
        public int veiculo_seq { get; set; }
        
        
        private string __veiculo_placa = ""; 
        public string veiculo_placa 
        { 
            get 
            {
                return __veiculo_placa;
            } 
          
            set 
            {
                if (value != "")
                {

                    __veiculo_placa = value.Replace("-", "").Trim();
                    /*
                    if (ValidarPlaca(value))
                    {
                        __veiculo_placa = value.Replace("-", "").Trim();
                    }
                    else
                    {
                        throw new Exception("Placa Inválida!");
                    }*/
                }
                else 
                {
                    __veiculo_placa = "";
                }
            } 
        }
        
        public int veiculo_modelo_cd { get; set; }
        public string veiculo_observacao { get; set; }
        public int veiculo_ano { get; set; }
        public string veiculo_modelo_descricao { get; set; }

        public TbVeiculo()
        {
            __veiculo_placa = "";
            veiculo_seq = 0;
            veiculo_placa = "";
            veiculo_modelo_cd = 0;
            veiculo_observacao = "SEM OBSERVAÇÃO";
            veiculo_ano = 0;
        }
        public TbVeiculo
        (

            int _veiculo_seq,
            string _veiculo_placa,
            int _veiculo_modelo_cd,
            string _veiculo_observacao,
            int _veiculo_ano

        )
        {


            veiculo_seq = 0;
            veiculo_placa = "";
            veiculo_modelo_cd = 0;
            veiculo_observacao = "SEM OBSERVAÇÃO";
            veiculo_ano = 0;



            veiculo_seq = _veiculo_seq;
            veiculo_placa = _veiculo_placa;
            veiculo_modelo_cd = _veiculo_modelo_cd != 0 ? _veiculo_modelo_cd : 0;
            veiculo_observacao = _veiculo_observacao != "" ? _veiculo_observacao : "";
            veiculo_ano = _veiculo_ano > 0 ? _veiculo_ano : 0;


        }

        public TbVeiculo(DataRow i)
        {

            veiculo_seq = Convert.ToInt32(i["veiculo_seq"].ToString());
            veiculo_placa = i["veiculo_placa"].ToString();
            veiculo_modelo_cd = Convert.ToInt32(i["veiculo_modelo_cd"].ToString());
            veiculo_observacao = i["veiculo_observacao"].ToString();
            veiculo_ano = Convert.ToInt32(i["veiculo_ano"].ToString());
            veiculo_modelo_descricao = i["veiculo_modelo_descricao"].ToString();
        }


            
        
        private static bool ValidarPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa)) { return false; }

            if (placa.Length > 8) { return false; }

            placa = placa.Replace("-", "").Trim();

            /*
             *  Verifica se o caractere da posição 4 é uma letra, se sim, aplica a validação para o formato de placa do Mercosul,
             *  senão, aplica a validação do formato de placa padrão.
             */
            if (char.IsLetter(placa, 4))
            {
                /*
                 *  Verifica se a placa está no formato: três letras, um número, uma letra e dois números.
                 */
                var padraoMercosul = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");
                return padraoMercosul.IsMatch(placa);
            }
            else
            {
                // Verifica se os 3 primeiros caracteres são letras e se os 4 últimos são números.
                var padraoNormal = new Regex("[a-zA-Z]{3}[0-9]{4}");
                return padraoNormal.IsMatch(placa);
            }
        }
    
    }


}
