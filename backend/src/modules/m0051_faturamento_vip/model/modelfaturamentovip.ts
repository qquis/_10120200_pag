import { clsTools } from "../../../model/modelbase";
import tbfaturamentovip from "../tbs/tbfaturamentoVip";
import f0051_10_FaturamentoVip_CRUD from "../scripts/pg.f0051_10_faturamento_vip_crud";



export default class modelfaturamentovip extends tbfaturamentovip {

    getCrudSql() { 
       return f0051_10_FaturamentoVip_CRUD.get(this)
    }

}