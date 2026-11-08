import moduleUserConnect from "../m0001_sistema/moduleUserConnect"
import moduleDefault from '../module.default'


class moduleInterfaceDIAL extends moduleDefault { 
    message: string[] 
    constructor(user: moduleUserConnect, sis_ac_cd: number) { 
        super(user, '/interface', sis_ac_cd)
        this.message = []
    }




    async downloadfiles(parametros: any) : Promise<string[]> {
            try {

                if (parametros.tipo === 'sales' || parametros.tipo === 'all')
                    await this.downloadSales(parametros)
                if (parametros.tipo === 'client' || parametros.tipo === 'all')
                    await this.downloadClient(parametros)

                if (parametros.tipo === "stock" || parametros.tipo === 'all') {
                    await this.downloadStock(parametros)
                }

            } catch(e) {
                this.__addMessageinfo(`Erro ao baixar arquivos: ${e}`);
            }
            return this.message;
    }

    async downloadSales(parametros: any) : Promise<void> {
        try {

            let result_sales = await this.getSALES(parametros)
            await this.processarArquivo(`DIALSALES01BR_${parametros.data_processamento_ini}-${parametros.data_processamento_fim}`, result_sales as any[])

        } catch(e) {
            this.__addMessageinfo(`Erro ao processar arquivo de vendas: ${e}`);
        }
    }

    async downloadStock(parametros: any) : Promise<void> {
        try {

            let result_sales = await this.getEstoque(parametros)
            await this.processarArquivo(`DIALSTOCKS01BR_${parametros.data_processamento_ini}-${parametros.data_processamento_fim}`, result_sales as any[])

        } catch(e) {
            this.__addMessageinfo(`Erro ao processar arquivo de vendas: ${e}`);
        }
    }


    async downloadClient(parametros: any) : Promise<void> {
        try {

            let result_client = await this.getCLIENT(parametros)

            await this.processarArquivo(`DIALCLIENT01BR_${parametros.data_processamento_ini}-${parametros.data_processamento_fim}`, result_client as any[])

        } catch(e) {
            this.__addMessageinfo(`Erro ao processar arquivo de clientes: ${e}`);
        }
    }

    async processarArquivo(nomeArquivo: string, list: any) : Promise<any[]> {
        let rows: any[] = []
        
        try { 
            rows = Array.isArray(list?.data) ? list.data : (Array.isArray(list) ? list : []);
                        if (rows.length === 0) {
                this.__addMessageinfo("Nenhum registro encontrado para o período.");
            } else {
                const conteudo = rows
                            .map(r =>
                                String(r.linha ?? "")
                                    .normalize("NFD")
                                    .replace(/[\u0300-\u036f]/g, "")
                                    .replace(/['’‘`´]/g, "")
                            )
                            .join("\r\n");
                this.__addMessageinfo(`Arquivo gerado com ${rows.length} linhas.`);
                const blob = new Blob([conteudo], { type: 'text/plain;charset=utf-8;' });
                const url = URL.createObjectURL(blob);
                const a = document.createElement('a');
                a.href = url;
                a.download = `${nomeArquivo}.txt`;
                document.body.appendChild(a);
                a.click();
                document.body.removeChild(a);
                URL.revokeObjectURL(url);
            }





        } catch(e) {
            throw new Error(`API ERROR: ${e}`); 
        }
        finally {
            return rows
        }
    }



    async getSALES(parametros: any) : Promise<any> {
            try {
 
                let result = await this._getAPI<any>(`/report/interface-dial-venda`, parametros)
                return result

            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }
    }

    async getCLIENT(parametros: any) : Promise<any> {
            try {

                let result = await this._getAPI<any>(`/report/interface-dial-cliente`, parametros)
                return result

            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }
    }    

    async getEstoque(parametros: any) : Promise<any> {
            try {

                let result = await this._getAPI<any>(`/report/interface-dial-estoque`, parametros)
                return result

            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }
    }    

    __addMessageinfo(msg: string) {
        this.message.push(msg);
    }

}

class moduleInterfaceFaturamentoItem extends moduleDefault { 
    constructor(user: moduleUserConnect, sis_ac_cd: number) { 
        super(user, '/interface', sis_ac_cd)
    }
    async getInterfaceFaturamentoItem(parametros: any) : Promise<any> {
            try {

                let result = await this._getAPI<any>(`/report/interface-faturamento-item`, parametros)
                return result

            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }
    }
    async postInterfaceFaturamentoProcessar(parametros: any) : Promise<any> {
            try {

                let url = `/service/interface-faturamento-processar?filtro=1&data_processamento_ini=${parametros.data_processamento_ini}&data_processamento_fim=${parametros.data_processamento_fim}`
                console.log(url)
                let result = await this._postAPI(url, {})
                return result

            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }
    }
}


class moduleInterface extends moduleDefault { 
    dial: moduleInterfaceDIAL
    interfacefaturamentoItem: moduleInterfaceFaturamentoItem
    constructor(user: moduleUserConnect, sis_ac_cd: number) { 
        super(user, '/interface', sis_ac_cd)
        this.dial = new moduleInterfaceDIAL(user, sis_ac_cd)
        this.interfacefaturamentoItem = new moduleInterfaceFaturamentoItem(user, sis_ac_cd)

    }
}






export { moduleInterface }


