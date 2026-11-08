using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0035_Ativo;

namespace Pag_Net.Bll.F0035_Ativo.Models
{
    public class Model_TbAtivo : TbAtivo
    {
      

        public TbAtivoVeiculo Veiculo;
        public Model_TbAtivoRegistro Registro; 
        


        public bool m_bool_at_status
        {
            get
            {
                if (base.at_status == 0)
                    return false;
                else
                    return true;
            }
        }

        public Model_TbAtivo(): base() 
        {
            _Modelconstructor();
        }

        public void _Modelconstructor()
        {
            this._constructor();
            this.Veiculo = new TbAtivoVeiculo();
            this.Registro = new Model_TbAtivoRegistro();
        }

        public void __ModelConsultar(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            this.__Consultar(MyConnect);
            this.Registro.at_seq = this.at_seq;
            if (this.at_tipo_cd == 200) __ModelConsultarVeiculo(MyConnect);
        }
        public void __ModelSalvar(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            this.__ModelValidar();
            base.__Atualizar(MyConnect);
            Veiculo.at_seq = base.at_seq;

            Veiculo.__Atualizar(MyConnect);
            __ModelConsultar(MyConnect);
        }
        
        
        public void __ModelConsultarVeiculo(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            Veiculo._constructor();
            if (this.at_seq != 0)
            {
                Veiculo.at_seq = this.at_seq;
                Veiculo.__Consultar(MyConnect);
            }
        }

       

        public void __ModelRegistros_Incluir (Pag_Net.Models.modelSistemaUsuario MyConnect, 
            int controle_reg_etapa_seq,
            enumTipoMovimentacao TipoMovimentaca, 
            string RegistroDescricao
            
            )
        {
            try
            {

                int TipoMovimentacaoCod = 90;

                switch (TipoMovimentaca)
                {
                    case enumTipoMovimentacao.COMPRA:
                        TipoMovimentacaoCod = 10;
                        break;
                    case enumTipoMovimentacao.VENDA:
                        TipoMovimentacaoCod = 20;
                        break;
                    case enumTipoMovimentacao.SAIDA:
                        TipoMovimentacaoCod = 30;
                        break;
                    case enumTipoMovimentacao.ENTRADA:
                        TipoMovimentacaoCod = 40;
                        break;
                    case enumTipoMovimentacao.OUTRAS:
                        TipoMovimentacaoCod = 90;
                        break;
                }
                Registro.at_seq = this.at_seq;
                Registro.controle_reg_etapa_seq = controle_reg_etapa_seq;
                Registro.at_reg_tipo_cd = TipoMovimentacaoCod;
                Registro.at_reg_data = DateTime.Now;
                Registro.at_reg_descricao = RegistroDescricao;
                Registro.__Atualizar(MyConnect);
                if (this.at_tipo_cd == 200)
                {
                    if (Registro.RegistroVeiculo.at_reg_veiculo_km == 0)
                        resource.PagException(PagExceptionType.Error, new Exception("Informe o KM"));

                    Registro.RegistroVeiculo.at_reg_seq = Registro.at_reg_seq;
                    Registro.RegistroVeiculo.__Atualizar(MyConnect);
                }
                
            }
            catch (Exception ex)
            {
                resource.PagException(PagExceptionType.Error, ex);
            }
        }
        



        public void __ModelValidar()
        {
            if (this.at_descricao == "")
                resource.PagException(PagExceptionType.Info, "Informe a DESCRIÇÃO do Veículo"); 
            if (this.at_tipo_cd == 200)
            {
                if (this.Veiculo.at_veiculo_placa == "")
                    resource.PagException(PagExceptionType.Info, "Informe a placa do Veículo");
                if (this.Veiculo.at_veiculo_placa.Length < 7)
                    resource.PagException(PagExceptionType.Info, "Placa do Veículo Inválida"); 
            }
            
        }


    }
}
