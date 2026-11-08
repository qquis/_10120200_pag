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
const report_1 = __importDefault(require("../../m0001_sistema/report/report"));
const myBase = new modelbase_1.clsBase();
class serviceFaturamentoBluesoft_Processo_Registrar {
    static start(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.Processo_TIPO_N20_FaturamentoComCorteClienteVarejo(parametro);
            yield this.Processo_TIPO_N30_FaturamentoComCorteClienteTop(parametro);
        });
    }
    static Processo_TIPO_N20_FaturamentoComCorteClienteVarejo(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                /*      PERMISSÃO VENDEDORES NA TABELA tbnotificacao_vendedor
                        NOTIFICAÇÃO APENAS VAREJO
                        NOTIFICAÇÃO COM VALOR DE CORTE ACIMA DO PARAMETRO 100500010
    
                */
                let PARAMETRO_VALOR_MINIMO_VAREJO = yield report_1.default.Parametro.getParametroValue(100500010);
                if (!PARAMETRO_VALOR_MINIMO_VAREJO || PARAMETRO_VALOR_MINIMO_VAREJO == '') {
                    PARAMETRO_VALOR_MINIMO_VAREJO = "0.05";
                }
                let dataInicial = modelbase_1.clsTools._datemomentDatStrToDate(`${parametro.dataInicial}`, `YYYY-MM-DD`);
                let dataFinal = modelbase_1.clsTools._datemomentDatStrToDate(`${parametro.dataFinal}`, `YYYY-MM-DD`);
                let script_registro_processo = `
                        insert into tbfaturamento_bluesoft_processo
                                    (		op_cdoperacao 
                                        ,	numeropedido
                                        ,	numeropedido_fv
                                        ,	fat_blue_status_cd
                                        ,	fat_blue_processo_tipo_cd
                                    )
                                        
                                SELECT 		f.op_cdoperacao 
                                    ,		f.numeropedido
                                    ,		f.numeropedido_fv
                                    ,		f.fat_blue_status_cd
                                    ,		20
                                FROM 		tbfaturamento_bluesoft  f
                                
                                inner join 	tbfaturamento_bluesoft_status s on s.fat_blue_status_cd = f.fat_blue_status_cd 
                                inner join  tbparticipante_bluesoft pb on pb.cdpessoabluesoft = f.cdpessoabluesoft_vendedor 
                                inner join  tbnotificacao_permissao np on np.cdparticipante = pb.cdparticipante and np.notificacao_cd = 1005000010 
                                INNER JOIN  tbparticipante_bluesoft cb on cb.cdpessoabluesoft = f.cdpessoabluesoft_cliente
                                INNER JOIN  tbgrupoeconomico        ge on ge.cdgrupoeconomico = cb.cdgrupoeconomico and coalesce(ge.johnson_cliente_top,0) = 0
                                where	1 = 1
                                and		f.data_emissao >= '${modelbase_1.clsTools._datemomentDateToStr(dataInicial, `YYYY-MM-DD`)}'
                                and		f.data_emissao <= '${modelbase_1.clsTools._datemomentDateToStr(dataFinal, `YYYY-MM-DD`)}'
                                and		f.op_cdoperacao = 1
                                and		s.fat_blue_status_cd in (55, 70)
                                AND		F.VALOR_PEDIDO > F.VALOR_FATURAMENTO 
                                AND     (F.VALOR_PEDIDO - F.VALOR_FATURAMENTO) >= ${PARAMETRO_VALOR_MINIMO_VAREJO}
                                and     not exists (select 1 
                                                    from 	tbfaturamento_bluesoft_processo xx
                                                    where	xx.op_cdoperacao = f.op_cdoperacao 
                                                    and   xx.numeropedido = f.numeropedido 
                                                    and   xx.numeropedido_fv = f.numeropedido_fv 
                                                    and   xx.fat_blue_status_cd = f.fat_blue_status_cd
                                                    
                                                    )
                                and coalesce(ge.johnson_cliente_top,0) = 0
                      `;
                /*INSERE OS ITENS QUE DEVERÃO SER ENVIADAS AS MENSAGENS*/
                yield myBase.myDataBase.pag.Execute(script_registro_processo);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("serviceFaturamentoBluesoft_Processo", "ForcaVendaRegistrarCortes", e);
            }
        });
    }
    static Processo_TIPO_N30_FaturamentoComCorteClienteTop(parametro) {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                /*      PERMISSÃO VENDEDORES NA TABELA tbnotificacao_vendedor
                        NOTIFICAÇÃO APENAS CLIENTE TOP
    
                */
                let dataInicial = modelbase_1.clsTools._datemomentDatStrToDate(`${parametro.dataInicial}`, `YYYY-MM-DD`);
                let dataFinal = modelbase_1.clsTools._datemomentDatStrToDate(`${parametro.dataFinal}`, `YYYY-MM-DD`);
                let script_registro_processo = `
                        insert into tbfaturamento_bluesoft_processo
                                    (		op_cdoperacao 
                                        ,	numeropedido
                                        ,	numeropedido_fv
                                        ,	fat_blue_status_cd
                                        ,	fat_blue_processo_tipo_cd
                                    )
                                        
                                SELECT 		f.op_cdoperacao 
                                    ,		f.numeropedido
                                    ,		f.numeropedido_fv
                                    ,		f.fat_blue_status_cd
                                    ,		30
                                FROM 		tbfaturamento_bluesoft  f
                                
                                inner join 	tbfaturamento_bluesoft_status s on s.fat_blue_status_cd = f.fat_blue_status_cd 
                                inner join  tbparticipante_bluesoft pb on pb.cdpessoabluesoft = f.cdpessoabluesoft_vendedor 
                                inner join  tbnotificacao_permissao np on np.cdparticipante = pb.cdparticipante and np.notificacao_cd = 1005000010 
                                INNER JOIN  tbparticipante_bluesoft cb on cb.cdpessoabluesoft = f.cdpessoabluesoft_cliente
                                INNER JOIN  tbgrupoeconomico        ge on ge.cdgrupoeconomico = cb.cdgrupoeconomico and coalesce(ge.johnson_cliente_top,0) = 1
                                where	1 = 1
                                and		f.data_emissao >= '${modelbase_1.clsTools._datemomentDateToStr(dataInicial, `YYYY-MM-DD`)}'
                                and		f.data_emissao <= '${modelbase_1.clsTools._datemomentDateToStr(dataFinal, `YYYY-MM-DD`)}'
                                and		f.op_cdoperacao = 1
                                and		s.fat_blue_status_cd in (55, 70)
                                AND		F.VALOR_PEDIDO > F.VALOR_FATURAMENTO 
                                and     not exists (select 1 
                                                    from 	tbfaturamento_bluesoft_processo xx
                                                    where	xx.op_cdoperacao = f.op_cdoperacao 
                                                    and   xx.numeropedido = f.numeropedido 
                                                    and   xx.numeropedido_fv = f.numeropedido_fv 
                                                    and   xx.fat_blue_status_cd = f.fat_blue_status_cd
                                                    
                                                    )
                                and coalesce(ge.johnson_cliente_top,0) = 1
                      `;
                /*INSERE OS ITENS QUE DEVERÃO SER ENVIADAS AS MENSAGENS*/
                yield myBase.myDataBase.pag.Execute(script_registro_processo);
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("serviceFaturamentoBluesoft_Processo", "ForcaVendaRegistrarCortes", e);
            }
        });
    }
}
exports.default = serviceFaturamentoBluesoft_Processo_Registrar;
