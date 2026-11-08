import { mdoReport, modelReport } from '../../../model/model';
import myTools from "../../../tools/Tools";
import reportPrecoFilter from '../interfaces'
import f0045_11_preco_agendado_list from '../pgscripts/f0045_11_preco_agendado_list';





export default class reportPrecoAgendamento extends mdoReport { 
    Filtros : reportPrecoFilter

    constructor() {
        super()

        this.Filtros  = {
            tipo_relatorio : "PERSONALIZADO", 
            tab_pre_cd : 0, 
            data_log_filter : 0 , 
            data_log_ini : myTools.pagDateTime_getDate(), 
            data_log_fim : myTools.pagDateTime_getDate(),
            pr_cdproduto : 0, 
            prb_cdprodutobluesoft_unitario : 0, 
            prb_cdprodutobluesoft : 0, 
            pr_descricao : "", 
            prb_descricao : "",
            tipo_produto : "UNITARIO", 
            data_agendamento_filter:  0,
            data_agendamento_inicial:  myTools.pagDateTime_getDate(), 
            data_agendamento_final: myTools.pagDateTime_getDate()
            
        }

    }

    filterset(request: any)  {
        try {

            let tipo_relatorio : string = `INTEGRACAO_BLUESOFT_PENDENTE`
            let tab_pre_cd : number = 0
            let data_log_filter	: number = 0
            let data_log_ini: Date = myTools.pagDateTime_getDate();
            let data_log_fim: Date = myTools.pagDateTime_getDate();
            let pr_cdproduto : number = 0 
            let prb_cdprodutobluesoft_unitario : number = 0
            let prb_cdprodutobluesoft : number = 0
            let pr_descricao : string = `` 
            let prb_descricao : string = `` 
            let tipo_produto : string = `UNITARIO` 

            let data_agendamento_filter: number =  0
            let data_agendamento_inicial: Date =  myTools.pagDateTime_getDate()
            let data_agendamento_final: Date =  myTools.pagDateTime_getDate()

            if (request) {
                if (request.body !== undefined)
                {
                    tipo_relatorio = request.body.tipo_relatorio? request.body.tipo_relatorio : "LOG_BLUE_D1"
                    tab_pre_cd = request.body.tab_pre_cd? request.body.tab_pre_cd : 0
                    data_log_filter = request.body.data_log_filter? parseInt(request.body.data_log_filter) : 0 
                    data_log_ini = request.body.data_log_ini? myTools.Date_br_new(`${request.body?.data_log_ini}`) : myTools.pagDateTime_getDate()
                    data_log_fim = request.body.data_log_fim? myTools.Date_br_new(`${request.body?.data_log_fim}`) : myTools.pagDateTime_getDate()
                    pr_cdproduto = request.body.pr_cdproduto? parseInt(request.body.pr_cdproduto): 0
                    prb_cdprodutobluesoft_unitario = request.body.prb_cdprodutobluesoft_unitario? parseInt(request.body.prb_cdprodutobluesoft_unitario): 0 
                    prb_cdprodutobluesoft = request.body.prb_cdprodutobluesoft? parseInt(request.body.prb_cdprodutobluesoft) : 0
                    pr_descricao = request.body.pr_descricao? request.body.pr_descricao: `` 
                    prb_descricao = request.body.prb_descricao? request.body.pr_descricao: `` 
                    tipo_produto = request.body.tipo_produto? request.body.tipo_produto: `` 
                }
            }
        this.Filtros  = {
            tipo_relatorio, 
            tab_pre_cd, 
            data_log_filter, 
            data_log_ini, 
            data_log_fim, 
            pr_cdproduto, 
            prb_cdprodutobluesoft_unitario, 
            prb_cdprodutobluesoft, 
            pr_descricao, 
            prb_descricao,
            tipo_produto , 
            data_agendamento_filter, 
            data_agendamento_inicial, 
            data_agendamento_final
        }
        } catch (e) {
            throw Error(`Report | Filter_Get Error ${e}`)
        }
    }

    async dataPag_get(request: any) : Promise<object> {
        try {
            if (request)
                this.filterset(request)

            const result = await super.dataPag_get(f0045_11_preco_agendado_list.SELECT(this.Filtros))

            return result; 

        } catch (e) {
            myTools.pagConsoleLog(`Reports | Error \n ${e}`)
            return [];

        }
    }
  
}