using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pag_Net.Bll.F0035_Ativo;

namespace Pag_Net.Bll.F0035_Ativo.Models
{
    public class Model_TbAtivoRegistro : TbAtivoRegistro
    {
        public TbAtivoRegistroVeiculo RegistroVeiculo;

        public Model_TbAtivoRegistro()
            : base() 
        {
            _Modelconstructor();
        }

        public void _Modelconstructor()
        {
            this._constructor();
            this.RegistroVeiculo = new TbAtivoRegistroVeiculo();
        }

        public void _Salvar(Pag_Net.Models.modelSistemaUsuario MyConnect)
        {
            try
            {
                this.__Atualizar(MyConnect);
                this.RegistroVeiculo.at_reg_seq = this.at_reg_seq;
                this.RegistroVeiculo.__Atualizar(MyConnect);
            }
            catch (Exception ex)
            {
                resource.PagException(PagExceptionType.Error, ex);
            }
        }
        public void _Registrar_Saida(Pag_Net.Models.modelSistemaUsuario MyConnect) {this.at_reg_tipo_cd = 30; _Salvar(MyConnect);}
        public void _Registrar_Entrada(Pag_Net.Models.modelSistemaUsuario MyConnect) { this.at_reg_tipo_cd = 40; _Salvar(MyConnect); }

    }
}
