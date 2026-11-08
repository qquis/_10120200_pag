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
const model_faturamento_controle_1 = __importDefault(require("../model/model_faturamento_controle"));
const pg_f0070_20_faturamentocontrole_processar_1 = __importDefault(require("../scriptdb/pg.f0070_20_faturamentocontrole_processar"));
const pg_f0070_21_faturamentoprocessar_1 = __importDefault(require("../scriptdb/pg.f0070_21_faturamentoprocessar"));
const pg_f0070_22_faturamentoorigem_processar_1 = __importDefault(require("../scriptdb/pg.f0070_22_faturamentoorigem_processar"));
/*  VARIAVEIS DEFAULT --------------------------------------------------------------------------*/
const SISTEMA_NUCLEO_PRC_CD = 100700010;
const FLG_DEBUG_CONSOLE_LOG = true;
const FLG_MODULO = "M0070-FATURAMENTO | Faturamento Bluesoft Processamento";
const FLG_DEBUG_FILE_CONSOLE_LOG = ``;
/*  ------------------------------------------------------------------------------------------- */
class serviceFaturamentoBluesoftProcessar {
    static start(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield this._log(`Iniciando processamento para data: ${parametro.data_processamento}`);
                yield this.IntegrarHeaderGerarMovimentoPendente(parametro);
                yield this.ProcessamentoPendente(parametro);
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException("serviceFaturamentoBluesoftProcessar", "start", e);
                throw new Error(`serviceFaturamento | processarFaturamento \n Error ${e}`);
            }
        });
    }
    static IntegrarHeaderGerarMovimentoPendente(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (!parametro.data_processamento) {
                    throw new Error(`Parâmetro data_processamento é obrigatório`);
                }
                const myDatabase = new modelbase_1.clsBase();
                let vdata_processamento = modelbase_1.clsTools._datemomentDatStrToDate(parametro.data_processamento, "YYYY-MM-DD");
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Processando Headers - CONTROLE FATURAMENTO`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield myDatabase.myDataBase.pag.Execute(pg_f0070_20_faturamentocontrole_processar_1.default.get(parametro));
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Processando Headers - TBFATURAMENTO`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield myDatabase.myDataBase.pag.Execute(pg_f0070_21_faturamentoprocessar_1.default.get(parametro));
                yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Processando Headers - TBFATURAMENTO ORIGEM`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                yield myDatabase.myDataBase.pag.Execute(pg_f0070_22_faturamentoorigem_processar_1.default.get(parametro));
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, "IntegrarHeaderGerarMovimentoPendente", e);
            }
        });
    }
    static ProcessamentoPendente(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            let listAProcessar = [];
            try {
                const myDatabase = new modelbase_1.clsBase();
                let sqlProcessamentoPendente = `    
                    SELECT 		CAST(ct.seqfaturamento_uuid AS VARCHAR(40))
                            ,	ct.faturamento_controle_seq
                            ,	ct.op_cdoperacao 
                            ,	ct.dataemissao						
                            ,	ct.datafaturamento					
                            ,	ct.numeropedido 
                            ,   ct.numeropedido_fv					
                            ,	ct.df_nf_seq_blue
                            , 	ct.sat_ecf 						
                            ,	ct.cupomfiscal 					
                            ,	ct.cdpessoabluesoft_cliente
                            ,	ct.cdpessoabluesoft_vendedor
                            ,	CAST(ct.fat_controle_tipo_cd AS INT)
                            ,	ct.seqfaturamento 
                            ,	ct.seqfaturamentoorigem			
                    FROM 	    tbfaturamento_controle ct
                    LEFT JOIN   tbdocumentofiscal nf on nf.df_nf_seq_blue = ct.df_nf_seq_blue 
                    where   processamento_pendente = 1

   
                    
            `;
                //and     numeropedido = 512013
                let result = yield myDatabase.myDataBase.pag.DataGet(sqlProcessamentoPendente);
                let RegistroTotal = result.length;
                let Registroitem = 0;
                modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Número de registros a processar: ${RegistroTotal}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                for (let row of result) {
                    let itemFaturamento = model_faturamento_controle_1.default.faturamentoControleBindingGet(row);
                    yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | Processando item de faturamento: ${itemFaturamento.numeropedido} | Item ${Registroitem}/${RegistroTotal}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
                    yield myDatabase.myDataBase.pag.Execute(model_faturamento_controle_1.default.sqlProcessarFaturamentoPorControle(itemFaturamento));
                    Registroitem++;
                }
            }
            catch (e) {
                yield modelbase_1.clsTools.PagErrorException(FLG_MODULO, "ObterFaturamentoProcessamentoPendente", e);
                throw new Error(`serviceFaturamento | ObterFaturamentoProcessamentoPendente \n Error ${e}`);
            }
            finally {
                return listAProcessar;
            }
        });
    }
    static _log(message) {
        return __awaiter(this, void 0, void 0, function* () {
            yield modelbase_1.clsTools.pagConsole(`${FLG_MODULO} | ${message}`, FLG_DEBUG_CONSOLE_LOG, false, FLG_DEBUG_FILE_CONSOLE_LOG);
        });
    }
}
exports.default = serviceFaturamentoBluesoftProcessar;
