import moduleUserConnect from "../m0001_sistema/moduleUserConnect"
import moduleDefault from '../module.default'



type tpFaturamentoStatus = { 
    statusfaturamento: number
    statusfaturamento_descricao: string
}


class moduleFaturamentoTools { 
    user : moduleUserConnect
    constructor(user: moduleUserConnect) { 
        this.user = user;
    }
    async ExportFaturamentoTxtAnaliseBI(listData: any[], datafaturamento: string) : Promise<void> {
        try {
            // 1. Definir colunas e converter para CSV com ;
            const colunas = [
                    'faturamento_controle_seq',
                    'numero_nf',
                    'tipo_documento_fiscal',
                    'dataemissao',
                    'datafaturamento',
                    'statusfaturamento',
                    'statusfaturamento_descricao',
                    'em_cdempresa',
                    'em_descricao',
                    'op_cdoperacao',
                    'op_descricao',
                    'cdparticipantevendedor',
                    'cdpessoabluesoft_vendedor',
                    'cpf_cnpj_vendedor',
                    'nome_razao_vendedor',
                    'cdparticipantecliente',
                    'cdpessoabluesoft_cliente',
                    'cpf_cnpj_cliente',
                    'nome_razao_cliente',
                    'cdgrupoeconomico',
                    'grupoeconomico',
                    'pr_cdproduto',
                    'prb_cdprodutobluesoft',
                    'pr_descricao',
                    'pr_embalagemestoque',
                    'pr_embalagemcompra_fator',
                    'pr_embalagemcompra',
                    'prb_cdbarra_principal',
                    'embalagemestoqueqtde',
                    'embalagemcompraqtde',
                    'valortotalfaturamentobase',
                    'valortotalsubsidioscorrentes',
                    'valortotalfaturamento',
                    'valortotaldescontofinanceiro',
                    'valortotalsubsidiosaplicados',
                    'valortotalfaturamentoliquido',
                    'fv_fabricante_descricao',
                    'numeropedido',
                    'numeronfe', 
                    'tipo_cliente'
                    , 
                    ];

            const camposNumericos = new Map<string, number>([
                ['embalagemestoqueqtde', 3],
                ['embalagemcompraqtde', 3],
                ['valortotalfaturamentobase', 2],
                ['valortotalsubsidioscorrentes', 3],
                ['valortotalfaturamento', 3],
                ['valortotaldescontofinanceiro', 3],
                ['valortotalsubsidiosaplicados', 3],
                ['valortotalfaturamentoliquido', 3],
            ]);                    

            // Header
            let conteudo = colunas.join(';') + '\n';
            
            // Linhas de dados
            listData.forEach((item: any) => {
                const linha = colunas.map(col => {
                    if (col === 'dataemissao' || col === 'datafaturamento') {
                        return this.user.formatDateToStringYYYMMDD(item[col]);
                    }

                    const casasDecimais = camposNumericos.get(col);

                    if (casasDecimais !== undefined) {
                        return this.user.formatNumber(item[col], casasDecimais);
                    }

                    return item[col] || '';
                }).join(';');
                conteudo += linha + '\n';
            });

            await this.user.exportTxt(`${this.user.formatDateTimeNowToStrNameFile()}_PagFaturamentoTxtAnaliseBI_${datafaturamento}_.txt`, conteudo);





        } catch (e) {
            throw new Error(`Erro ao exportar faturamento para TXT: ${e}`);
        }
    }
}


class moduleFaturamentoContrato  extends moduleDefault { 
    user : moduleUserConnect
    constructor(user: moduleUserConnect, sis_ac_cd: number) { 
        super(user, '/faturamento', sis_ac_cd)   
        this.user = user;
    }

    async tipoContratoConsultar(parametros: any) : Promise<any[]> { 
        let result : any = {}
        try {
            let url =  `/report/tipoContrato?filter=1`
            result = await this._getAPI<any>(url, parametros)
            return result
        } catch(e) {
            throw new Error(`API ERROR: ${e}`); 
        }
    }
    async contratoList(parametros: any) : Promise<any[]> {
        let result : any = {}
        try {
            let url =  `/report/contrato?filter=1`
            result = await this._getAPI<any>(url, parametros)
            return result
        } catch(e) {
            throw new Error(`API ERROR: ${e}`); 
        }
    }
    async consultarProdutosContratoOuFornecedor(parametros: any) : Promise<any[]> {
        let result : any = {}
        try {
            let url =  `/model/contrato/produto-list`
            result = await this._getAPI<any>(url, parametros)
            return result
        } catch(e) {
            throw new Error(`API ERROR: ${e}`); 
        }
    }
    async contratoIncluir(parametros: any) : Promise<any> {
        let result : any = {}
        try {
            let url =  `/model/contrato`
            result = await this._postAPI(url, parametros)
            return result
        } catch(e) {
            throw new Error(`API ERROR: ${e}`); 
        }
    }
    async contratoConsultar(parametros: any) : Promise<any> {
        let result : any = {}
        try {
            let url =  `/model/contrato`
            result = await this._getAPI<any>(url, parametros)
            return result
        } catch(e) {
            throw new Error(`API ERROR: ${e}`); 
        }
    }

    async contratoProcessarApurar(parametros: any) : Promise<any> {
        let result : any = {}
        try {
            let url =  `/service/contrato-processar-apurar`
            result = await this._postAPI(url, parametros)
            return result
        } catch(e) {
            throw new Error(`API ERROR: ${e}`); 
        }
    }    
    async contratoInativar(parametros: any) : Promise<any> {
        let result : any = {}
        try {
            let url =  `/model/contrato/inativar`
            result = await this._postAPI(url, parametros)
            return result
        } catch(e) {
            throw new Error(`API ERROR: ${e}`); 
        }
    }
}

class moduleFaturamentoControle  extends moduleDefault {
    user : moduleUserConnect
    constructor(user: moduleUserConnect, sis_ac_cd: number) { 
        super(user, '/faturamento', sis_ac_cd)   
        this.user = user;
    }
    async Consultar(parametros: any) : Promise<any[]> {
        let result : any = {}
        try {
            let url =  `/model/faturamento?filter=1`
            result = await this._getAPI<any>(url, parametros)
            console.log(result)
            return result
        } catch(e) {
            throw new Error(`API ERROR: ${e}`); 
        }
    }
}



class moduleFaturamento extends moduleDefault { 
    contrato : moduleFaturamentoContrato
    controle : moduleFaturamentoControle
    listFaturamentoStatus : tpFaturamentoStatus[]
    tools : moduleFaturamentoTools

    constructor(user: moduleUserConnect, sis_ac_cd: number) { 
        super(user, '/faturamento', sis_ac_cd)   

        this.listFaturamentoStatus = []

        this.contrato = new moduleFaturamentoContrato(user, sis_ac_cd);
        this.controle = new moduleFaturamentoControle(user, sis_ac_cd);
        this.tools = new moduleFaturamentoTools(user);

        
    }

    async BindingFaturamentoStatus() : Promise<void> {
            try {
                const result = await this.getFaturamentoStatusList();
                this.listFaturamentoStatus = Array.isArray(result)
                    ? result.map((item: any) => ({
                        statusfaturamento: Number(item.statusfaturamento),
                        statusfaturamento_descricao: String(item.statusfaturamento_descricao)
                    }))
                    : [];
            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }

    }

    async getFaturamentoStatusList() : Promise<any> {
            try {
                let url =  `/report/statusList?filter=1`
                let result = await this._getAPI<any>(url)
                return result

            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }
    }

    async getFaturamentoOperacaoConferencia(parametro: any) : Promise<any> {
            try {
                let url =  `/report/operacaoconferencia?filter=1`
                if (parametro.op_cdoperacao) {
                    url += `&op_cdoperacao=${parametro.op_cdoperacao}`
                }

                if (parametro.dataFaturamento_filter == 1) { 
                    if (parametro.dataFaturamento_ini) { 
                        url += `&dataFaturamento_ini=${parametro.dataFaturamento_ini}`
                    }    
                    if (parametro.dataFaturamento_fim) {
                        url += `&dataFaturamento_fim=${parametro.dataFaturamento_fim}`
                    }
                }

                if (parametro.statusfaturamentoFiltrar == 1) {
                    if (parametro.statusfaturamento) {
                        url += `&statusfaturamento=${parametro.statusfaturamento}`
                    }
                }

                let result = await this._getAPI<any>(url)
                return result

            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }
    }   
    
    async getExport(parametro: any) : Promise<any> {
            try {
                let url =  `/report/export?filter=1`
                if (parametro.dataFaturamento_ini && parametro.dataFaturamento_fim) {
                    url += `&dataFaturamento_ini=${parametro.dataFaturamento_ini}&dataFaturamento_fim=${parametro.dataFaturamento_fim}`
                }


                let result = await this._getAPI<any>(url)
                return result

            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }
    }   
    
    async postProcessarVendasBluesoft(parametro: any) : Promise<any> {
            try {
                let url =  `/service/processar?filter=1`
                if (parametro.op_cdoperacao) {
                    url += `&op_cdoperacao=${parametro.op_cdoperacao}`
                }

                if (parametro.dataFaturamento_filter == 1) { 
                    url += `&dataFaturamento_filter=1`

                    if (parametro.dataFaturamento_ini) { 
                        url += `&dataFaturamento_ini=${parametro.dataFaturamento_ini}`
                    }    
                    if (parametro.dataFaturamento_fim) {
                        url += `&dataFaturamento_fim=${parametro.dataFaturamento_fim}`
                    }
                }
                else {
                    url += `&dataFaturamento_filter=0`
                }

                url += `&statusfaturamentoFiltrar=1`
                url += `&statusfaturament=1`
                url += `&data_processamento=${parametro.data_processamento}`


                let result = await this._postAPI(url, parametro)
                return result

            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }
    }


    async getList(parametro: any) : Promise<any> {
            try {
                let url =  `/report/list?filter=1`
             
                let result = await this._getAPI<any>(url, parametro)
                return result

            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }
    }  

}




export { moduleFaturamento, moduleFaturamentoControle, type tpFaturamentoStatus }


