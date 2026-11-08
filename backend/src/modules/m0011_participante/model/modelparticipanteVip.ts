import { clsTools, clsBase} from '../../../model/modelbase'
import tbparticipanteVip from '../tbs/tbparticipanteVip'
import f0011_15_ParticipanteVip_CRUD from '../script/f0011_15_ParticipanteVip_CRUD'
import apiVip from '../../Apis/vipApi/api';

export default class modelparticipanteVip extends tbparticipanteVip {
    constructor() {
        super()
    }

    
    async getApi(id: number) : Promise<void> {
        try { 

            let ClienteVipApi = await apiVip.clientes.get({id: id, page: 1})
            this.dataBindingAPI(ClienteVipApi)
            let myData = new clsBase()

            await myData.myDataBase.pag.Execute(this.vip_getSqlCrud())


        } catch (e: any) {
            clsTools.PagErrorException(`F0011 - Participante`, `modelparticipante_vip.getApi()`, e, true);
            throw new Error(`modules | Participante | Error ${e.message}`);
        }

    }

    dataBindingAPI (item: any): void {
        if (item) {
            this.vip_id = item?.id
            this.vip_cliente_id = item?.vipcommerce_cliente_id
            this.vip_cpf_cnpj = item?.cpf_cnpj ? item?.cnpj : item?.cpf
            this.vip_data_nascimento = clsTools._datemomentDatStrToDate(item?.data_nascimento, "YYYY-MM-DD")
            this.vip_nome = item?.nome
            this.vip_sobre_nome = item?.sobrenome
            this.vip_nome_completo = item?.nome_completo
            this.vip_telefone_celular = item?.telefone_celular
            this.vip_email = item?.email
        }
    }
    vip_binding_api (item: any): void {
        this.vip_cpf_cnpj = item?.cpf_cnpj ? item?.cnpj : item?.cpf
        this.dataBindingAPI(item)
    }

    vip_getSqlCrud(): string {
        let parametros : any = { 
            vip_id: this.vip_id,
            vip_cliente_id: this.vip_cliente_id,
            vvip_cpf_cnpj: this.vip_cpf_cnpj,
            vvip_nome_completo: this.vip_nome_completo,
            vvip_data_nascimento: this.vip_data_nascimento,
            vvip_cpf: this.vip_cpf,
            vvip_cnpj: this.vip_cnpj,
            vcdparticipante: 0,
            vvip_nome: this.vip_nome,
            vvip_sobre_nome: this.vip_sobre_nome,
            vvip_email: this.vip_email,
            vvip_telefone_celular: this.vip_telefone_celular
        }
        return f0011_15_ParticipanteVip_CRUD.get(parametros)
    }
    
}