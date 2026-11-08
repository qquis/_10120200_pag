const Tools = require ("../../../tools/index")
const {ApiGet, ApiPost} = require("../src/Api/pag")

class m0055_faturamento {
    
    url_processarfaturamentoZanthus () {
        return '/faturamento/filter/integrate'
    }
    url_processarfaturamentoZanthuspendente () {
        return '/faturamento/filter/integratependente'
    }
     constructor() {
        

        this.data = {
            filter: 
                            {
                                    seqfaturamento: 0,
                                    seqfaturamentoorigem: 0,
                                    datafaturamento_ini: Tools.pagDateTime_getDateStringShortBrBarra(Tools.Date_br_current()),
                                    datafaturamento_fim: Tools.pagDateTime_getDateStringShortBrBarra(Tools.Date_br_current()),
                                    sat_ecf: 0,
                                    cupom_fiscal: 0,
                                    cdparticipantecliente: 0,
                                    cdparticipantevendedor: 0
                            }, 
            post_integracao: 
                {
                    integracao_tipo: "ZANTHUS",
                    integracao_registro: "PENDENTE"
                },
            get_zanthus: {
                           zanthus_base: "Zanthus", 
                           zanthus_tipo: "ctrlcupom" 
                    }
            }
       
    }

    async faturamento_zanthus_integrate () {
        try {
        const dados = await ApiGet(`${this.url_processarfaturamentoZanthus()}`, this.data)
        const list = dados.data
        return list
        } catch (e) {
            throw Error(e)
        }
    }

    async faturamento_zanthus_integrate_pendente () {
        try {
        const dados = await ApiGet(`${this.url_processarfaturamentoZanthuspendente()}`, this.data)
        const list = dados.data
        return list
        } catch (e) {
            throw Error(e)
        }
    }
}

module.exports = m0055_faturamento;
