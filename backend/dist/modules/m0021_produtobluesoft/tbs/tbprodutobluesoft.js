"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const model_1 = require("../../../model/model");
const F0021_01_ProdutoBlueSoft_CRUD_1 = __importDefault(require("../scriptpg/F0021_01_ProdutoBlueSoft_CRUD"));
const Tools_1 = __importDefault(require("../../../tools/Tools"));
class tbprodutobluesoft extends model_1.modelTb {
    constructor() {
        super();
        this.prb_cdprodutobluesoft_pk = 0;
        this.prb_cdprodutobluesoftunitario = 0;
        this.prb_descricao = "";
        this.prb_embalagemestoque = "";
        this.prb_fatorestoque = 0;
        this.prb_status_embalagemcaixa = false;
        this.prb_embalagemcompra = "";
        this.prb_embalagemcompra_qtdeunitaria = 0;
        this.prb_cdbarra_principal = "";
        this.prb_cdprodutobluesoft_controleestoque = 0;
        this.prb_cdprodutobluesoft_controlepreco = 0;
        this.prb_cdsubgrupo = 0;
        this.prb_dt_cadastro = this.__defaultDateNow;
        this.prb_dt_ultimaalteracao = this.__defaultDateNow;
        this.prb_cdpessoabluesoft_fabricante = 0;
        this.prb_vendaexterna = false;
        this.prb_status = false;
        this.prb_dtupdate_from_api = this.__defaultDateNow;
        this.prb_descricao_fiscal = "";
        this.prb_cdproduto_compra_padrao = 0;
        this.prb_tipo_composicao_cd = 0;
        this.prb_descricao_gondola = "";
        this.prb_descricao_cupom = "";
        this.prb_descricao_balanca = "";
        this.prb_cdpessoabluesoft_fornecedor = 0;
        this.prb_cdpessoabluesoft_troca = 0;
        this.prb_pesobruto = 0;
        this.prb_pesoliquido = 0;
        this.prbf_seq = 0;
        this.prb_blue_fc_cbenef_cd = "";
        this.prb_altura = 0;
        this.prb_largura = 0;
        this.prb_pesoaproximado = 0;
        this.prb_comprimento = 0;
        this.prb_ncm = "";
        this.prb_cest = "";
    }
    _Db_Pg_script(_stringCommand, parametro = {}, command_api = 'true') {
        let sql = ``;
        //let _vcommand_api : string = 'true'
        //if (_stringCommand == `DBINSERT`)
        //_vcommand_api = `false`
        try {
            sql = `SELECT ${F0021_01_ProdutoBlueSoft_CRUD_1.default.sqlScript_VERSION()}
                    ( sqlcommand:= '${_stringCommand}',
                      vprb_cdprodutobluesoft_pk:= ${this.prb_cdprodutobluesoft_pk},
                      vprb_cdprodutobluesoftunitario:= ${this.prb_cdprodutobluesoftunitario},
                      vprb_descricao:= '${this.prb_descricao.replace(`'`, ``)}',
                      vprb_embalagemestoque:= '${this.prb_embalagemestoque}',
                      vprb_fatorestoque:= ${this.prb_fatorestoque},
                      vprb_status_embalagemcaixa:= '${this.prb_status_embalagemcaixa}',
                      vprb_embalagemcompra:= 'XX',
                      vprb_embalagemcompra_qtdeunitaria:= 0.00,
                      vprb_cdbarra_principal:= '${this.prb_cdbarra_principal}',
                      vprb_cdprodutobluesoft_controleestoque:= 0,
                      vprb_cdprodutobluesoft_controlepreco:= 0,
                      vprb_cdsubgrupo:= ${this.prb_cdsubgrupo},						
                      vprb_dt_cadastro:= '${Tools_1.default._dataformatgetDATEtoSTR(this.prb_dt_cadastro, "YYYY-MM-DD")}',
                      vprb_dt_ultimaalteracao:= '${Tools_1.default._dataformatgetDATEtoSTR(this.prb_dt_ultimaalteracao, "YYYY-MM-DD")}',
                      vprb_cdpessoabluesoft_fabricante:= ${this.prb_cdpessoabluesoft_fabricante},
                      vprb_vendaexterna:= '0',
                      vprb_descricao_fiscal:= '${this.prb_descricao_fiscal.replace(`'`, ``)}',
                      vprb_cdproduto_compra_padrao:= 0,
                      vprbf_seq:= 0,
                      vprb_status:= '${this.prb_status}', 
                      vprb_tipo_composicao_cd:= 0, 
                      vprb_descricao_gondola:= '${this.prb_descricao_gondola.replace(`'`, ``)}', 
                      vprb_descricao_cupom:= '${this.prb_descricao_cupom.replace(`'`, ``)}', 
                      vprb_descricao_balanca:= '${this.prb_descricao_balanca.replace(`'`, ``)}', 
                      vprb_cdpessoabluesoft_fornecedor:= 0,
                      vprb_cdpessoabluesoft_fornecedor_troca:= 0,
                      vprb_pesobruto:= ${this.prb_pesobruto},
                      vprb_pesoliquido:= ${this.prb_pesoliquido},
                      vprb_largura:= ${this.prb_largura},
                      vprb_altura:= ${this.prb_altura},
                      vprb_pesoaproximado:= ${this.prb_pesoaproximado},
                      vprb_comprimento:= ${this.prb_comprimento},
                      vprb_blue_fc_cbenef_cd:= '${this.prb_blue_fc_cbenef_cd}',                      
                      vcommand_api:= '${command_api}',
                      vatualizalog:= ${parametro.AtualizaLog ? parametro.AtualizaLog : 0},
                      vprb_ncm:= '${this.prb_ncm}',
                      vprb_cest:= '${this.prb_cest}'
                      ) ;`.toString();
            return sql;
        }
        catch (e) {
            throw new Error(` Classe modelProdutoBluesoft ERROR SQL
                     ${sql}
                    -----------------------------------------------------------
                    Error ${e} \n 
                  `);
        }
    }
}
exports.default = tbprodutobluesoft;
