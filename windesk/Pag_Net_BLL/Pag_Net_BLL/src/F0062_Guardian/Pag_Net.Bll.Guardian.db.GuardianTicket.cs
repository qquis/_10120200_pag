using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0062_Guardian
{
    public class tbguardianticket
    {
        public string   gtk_uuid                   { get; set; }
        public int      gtk_seq                    { get; set; }
        public int      gtk_numero                 { get; set; }
        public string   gtk_placa                  { get; set; }
        public DateTime gtk_data                   { get; set; }
        public DateTime gtk_pesagemInicialHora      { get; set; }
        public DateTime gtk_pesagemFinalHora        { get; set; }
        public Double   gtk_pesagemInicialPeso      { get; set; }
        public Double   gtk_pesagemFinalPeso        { get; set; }
        public Double   gtk_pesagemPesoLiquido      { get; set; }
        public tbguardianticket() 
        {
            gtk_uuid = "";
            gtk_data = DateTime.Now;
            gtk_pesagemInicialHora = DateTime.Now;
            gtk_pesagemFinalHora = DateTime.Now;
            gtk_placa = "";
            gtk_pesagemInicialPeso = 0;
            gtk_pesagemFinalPeso = 0;
            gtk_pesagemPesoLiquido = 0;
        }

        public tbguardianticket(
             string   _gtk_uuid 
          ,  int      _gtk_seq                 
          ,  int      _gtk_numero              
          ,  string   _gtk_placa               
          ,  DateTime _gtk_data                
          ,  DateTime _gtk_pesagemInicialHora   
          ,  DateTime _gtk_pesagemFinalHora     
          ,  Double   _gtk_pesagemInicialPeso   
          ,  Double   _gtk_pesagemFinalPeso     
          ,  Double   _gtk_pesagemPesoLiquido   

           
            ) 
        {
            gtk_uuid                  =  _gtk_uuid;
            gtk_seq                   =  _gtk_seq;                 
            gtk_numero                =  _gtk_numero;
            gtk_placa                 =  _gtk_placa;
            gtk_data                  =  _gtk_data;
            gtk_pesagemInicialHora    =  _gtk_pesagemInicialHora;
            gtk_pesagemFinalHora      =  _gtk_pesagemFinalHora;
            gtk_pesagemInicialPeso    =  _gtk_pesagemInicialPeso;
            gtk_pesagemFinalPeso      =  _gtk_pesagemFinalPeso;
            gtk_pesagemPesoLiquido = _gtk_pesagemPesoLiquido;
        }

        public tbguardianticket(DataRow i )
        {
            gtk_uuid              = i["gtk_uuid"].ToString();
            gtk_seq               = Convert.ToInt32(i["gtk_seq"]);
            gtk_numero            = Convert.ToInt32(i["gtk_numero"]);
            gtk_placa             = i["gtk_placa"].ToString();
            gtk_data              = Convert.ToDateTime(i["gtk_data"].ToString());
            gtk_pesagemInicialHora = Convert.ToDateTime(i["gtk_pesagemInicialHora"].ToString());
            gtk_pesagemFinalHora   = Convert.ToDateTime(i["gtk_pesagemFinalHora"].ToString());
            gtk_pesagemInicialPeso = Convert.ToDouble(i["gtk_pesagemInicialPeso"].ToString());
            gtk_pesagemFinalPeso = Convert.ToDouble(i["gtk_pesagemFinalPeso"].ToString());
            gtk_pesagemPesoLiquido = Convert.ToDouble(i["gtk_pesagemPesoLiquido"].ToString());

        }
        public object _PostAPI()
        {
            return new
            {
                gtk_uuid                = "",
                gtk_seq                 = 0,
                gtk_numero              = gtk_numero,
                gtk_placa               = gtk_placa.ToString(),
                gtk_data                = gtk_data.ToString("dd/MM/yyyy HH:mm:ss"),
                gtk_pesagemInicialHora  = gtk_pesagemInicialHora.ToString("dd/MM/yyyy HH:mm:ss"),
                gtk_pesagemFinalHora    = gtk_pesagemFinalHora.ToString("dd/MM/yyyy HH:mm:ss"),
                gtk_pesagemInicialPeso  = gtk_pesagemInicialPeso.ToString(),
                gtk_pesagemFinalPeso    = gtk_pesagemFinalPeso.ToString(),
                gtk_pesagemPesoLiquido  = gtk_pesagemPesoLiquido.ToString()
            };
        }
    
    }
}
