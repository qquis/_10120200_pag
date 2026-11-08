import tbcrm_sorteio_numero from '../tbs/tbcrm_sorteio_numero';

export default class modelcrm_sorteio_numero extends tbcrm_sorteio_numero { 

    numero_cupom: number;
    numero_pedido: number;
    nf_data_emissao: Date;
    nf_numero: number;
    nf_chave: string
    valor: number;
    cpf_cnpj: string;
    crm_so_cpf: string;
    

    constructor() { 
        super();
        this.numero_cupom = 0;
        this.numero_pedido = 0;
        this.nf_data_emissao = this.__dataZERO;
        this.nf_numero = 0;
        this.nf_chave = '';
        this.valor = 0;
        this.cpf_cnpj = '';
        this.crm_so_cpf = '';
        

    }

    model_biding(item: any) : void {
        {
            super.binding(item);
            
            this.numero_cupom = item?.numero_cupom; 
            this.numero_pedido = item?.numero_pedido;
            this.nf_data_emissao = item?.nf_data_emissao;
            this.nf_numero = item?.nf_numero;
            this.nf_chave = item?.nf_chave;
            this.valor = item?.valor;
            this.cpf_cnpj = item?.cpf_cnpj;
            this.crm_so_cpf = item?.crm_so_cpf;
            
        }
    }



}