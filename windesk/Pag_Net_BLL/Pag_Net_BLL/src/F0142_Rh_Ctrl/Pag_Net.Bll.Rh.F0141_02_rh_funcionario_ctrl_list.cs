using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pag_Net.Bll.F0141_Rh._03_funcionario_ctrl_list
{
    public class filter
    {
        public DateTime rh_funcionario_ctrl_data_ini    {get; set; }
        public DateTime rh_funcionario_ctrl_data_fim    {get; set; }
        public string   rh_funcionario_nome             {get; set; }
        public int      rh_funcionario_ctrl_tipo        {get; set; }
        public int      controle_status_cd              {get; set; }
        public int      controle_etapa_cd               { get; set; }
        public filter() 
        {
            rh_funcionario_ctrl_data_ini = DateTime.Now;
            rh_funcionario_ctrl_data_fim = DateTime.Now;
            rh_funcionario_nome = "";
            rh_funcionario_ctrl_tipo = 0;
            controle_status_cd = 0;
            controle_etapa_cd = 0;
        }
        public filter(
            
         DateTime    _rh_funcionario_ctrl_data_ini  ,
         DateTime    _rh_funcionario_ctrl_data_fim  ,
         string      _rh_funcionario_nome           ,
         int         _rh_funcionario_ctrl_tipo      ,
         int         _controle_status_cd            ,
         int         _controle_etapa_cd             
            
            ) { 
        
        this.rh_funcionario_ctrl_data_ini    =          _rh_funcionario_ctrl_data_ini  ;
        this.rh_funcionario_ctrl_data_fim    =          _rh_funcionario_ctrl_data_fim  ;
        this.rh_funcionario_nome             =          _rh_funcionario_nome           ;
        this.rh_funcionario_ctrl_tipo        =          _rh_funcionario_ctrl_tipo      ;
        this.controle_status_cd              =          _controle_status_cd            ;
        this.controle_etapa_cd = _controle_etapa_cd;
        }
    }

    public static class RedShift
    {
        public static string get()     
        {
            return "";
        }
    }

    public static class Postgre
    {

        public static string Get(Pag_Net.Bll.F0141_Rh._03_funcionario_ctrl_list.filter _filtro)
        {
            try
            {
               string _PostGre = string.Format("SELECT * FROM " +
                   Pag_Net.Bll.BDCommand.ScriptSQL(BDCommand.Name.F0141_03_rh_funcionario_ctrl_list)
                                + "( '{0}', '{1}', '{2}', {3}, {4}, {5} ) ", 
                                _filtro.rh_funcionario_ctrl_data_ini.ToString("yyyy-MM-dd"),
                                _filtro.rh_funcionario_ctrl_data_fim.ToString("yyyy-MM-dd"), 
                                _filtro.rh_funcionario_nome.ToString().Replace("'",""), 
                                _filtro.rh_funcionario_ctrl_tipo.ToString(), 
                                _filtro.controle_status_cd.ToString(), 
                                _filtro.controle_etapa_cd.ToString()
                   
                   );
               return _PostGre;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }

}
