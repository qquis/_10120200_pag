"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
const tbcrm_sorteio_cupom_1 = __importDefault(require("../tbs/tbcrm_sorteio_cupom"));
const f0090_10_crm_sorteio_cupom_crud_1 = __importDefault(require("../script/f0090_10_crm_sorteio_cupom_crud"));
class modelcrm_sorteio_cupom extends tbcrm_sorteio_cupom_1.default {
    constructor() {
        super();
    }
    calcular_qtde_numero_sorteio(valor_minimo) {
        let qtde_numeros = 0;
        if (valor_minimo > 0) {
            qtde_numeros = Math.floor(this.valor / valor_minimo);
        }
        return qtde_numeros;
    }
    script_insert_cupom_zanthus(crm_so_temp_cd, crm_so_temp_valor_minimo, CumpoZanthus) {
        let x = modelbase_1.clsTools._datemomentDateToStr(CumpoZanthus.data, 'YYYY-MM-DD') + ' ' + CumpoZanthus.hora_ini;
        this.crm_so_temp_cd = crm_so_temp_cd;
        this.numero_cupom = CumpoZanthus.numero_cupom;
        '';
        this.numero_pedido = 0;
        this.sat_ecf = CumpoZanthus.ecf;
        this.data_emissao = CumpoZanthus.data;
        this.data_emissao_hora = modelbase_1.clsTools._datemomentDatStrToDate(x, 'YYYY-MM-DD HH:mm:ss');
        this.nf_numero = CumpoZanthus.nf_numero;
        this.nf_data_emissao = CumpoZanthus.data;
        this.nf_chave = CumpoZanthus.nf_chave;
        this.valor = CumpoZanthus.valor;
        this.cpf_cnpj = this.myTools.document.formatdb(CumpoZanthus.cpf_cnpj);
        this.crm_so_cpf = '';
        this.cdparticipante = 0;
        this.crm_so_qtde_numero_sorteio = this.calcular_qtde_numero_sorteio(crm_so_temp_valor_minimo);
        return this.script_insert();
    }
    script_insert() {
        let sql = f0090_10_crm_sorteio_cupom_crud_1.default.get(this);
        return sql;
        /*
        let sql : string = `
        
        insert into tbcrm_sorteio_cupom
            (
    
                        crm_so_temp_cd
                    ,	numero_cupom
                    ,	numero_pedido
                    ,	data_emissao
                    ,   sat_ecf
                    ,	nf_numero
                    ,	nf_data_emissao
                    ,	nf_chave
                    ,	valor
                    ,	cpf_cnpj
                    ,   crm_so_cpf
                    ,   cdparticipante
                    ,   crm_so_qtde_numero_sorteio
            
            )
                    SELECT ${this.crm_so_temp_cd}
                         , ${this.numero_cupom}
                         , ${this.numero_pedido}
                         , '${this.myTools._datemomentDateToStr(this.data_emissao, `YYYY-MM-DD`)}'
                         , ${this.sat_ecf}
                         , ${this.nf_numero}
                         , '${this.myTools._datemomentDateToStr(this.nf_data_emissao, `YYYY-MM-DD`)}'
                         , '${this.nf_chave}'
                         , ${this.valor}
                         , '${this.myTools.document.formatdb(this.cpf_cnpj)}'
                         , '${this.crm_so_cpf}'
                         , ${this.cdparticipante}
                         , ${this.crm_so_qtde_numero_sorteio}

                    WHERE NOT EXISTS (
                        SELECT 1
                        FROM   tbcrm_sorteio_cupom
                        WHERE  1 = 1
                        AND    nf_chave = '${this.nf_chave}'
                    );
        
        `;*/
    }
    registrar_cupom() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                const modeldb = new modelbase_1.clsBase();
                let sql = `UPDATE tbcrm_sorteio_cupom 
                      set crm_so_cpf = '${modelbase_1.clsTools.document.formatdb(this.crm_so_cpf)}'
                        , crm_so_registrado = 1
                        , crm_so_log_registro = current_timestamp
                      WHERE 1 = 1
                      and   nf_chave = '${this.nf_chave}'
                      and   crm_so_cpf = ''
                      and   ( 
                                cpf_cnpj = '${modelbase_1.clsTools.document.formatdb(this.cpf_cnpj)}'
                                or cpf_cnpj = ''
                            );
            `;
                yield modeldb.myDataBase.pag.Execute(sql);
                yield this.consultar({ nf_chave: this.nf_chave });
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`modelcrm_sorteio_cupom`, `registrar_cupom`, e);
            }
            finally {
                return this;
            }
        });
    }
    consultar(parametros) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                const modeldb = new modelbase_1.clsBase();
                let sql = `SELECT * 
                      FROM tbcrm_sorteio_cupom 
                      WHERE 1 = 1
                      AND  nf_chave = '${parametros.nf_chave}'
                    `;
                let result = yield modeldb.myDataBase.pag.DataGet(sql);
                this.binding(yield modeldb.myDataBase.RecordItem(result, 0));
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException(`modelcrm_sorteio_cupom`, `consultar`, e);
            }
        });
    }
}
exports.default = modelcrm_sorteio_cupom;
