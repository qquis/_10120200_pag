//import postgre_pool from '../../database/postgre'
import F0132_04_TbComercialPrePedido_List from './F0132_04_TbComercialPrePedido_List'
import TbPedidoCompra from './TbPedidoCompra'

import DataBase from '../../database/DataBase'


const myDataBase : DataBase = new DataBase();

let pedidoCompra : TbPedidoCompra[] = []

const comercial = {
    PedidosPendentes: async () : Promise<TbPedidoCompra[]> => {
        //pedidoCompra =  await postgre_pool.DataGet(F0132_04_TbComercialPrePedido_List.get_Postgre('2022-01-01', '2022-04-29',0,0)) as  TbPedidoCompra[]   
        pedidoCompra =  await myDataBase.pag.DataGet(F0132_04_TbComercialPrePedido_List.get_Postgre('2022-01-01', '2022-04-29',0,0)) as  TbPedidoCompra[]   

        return pedidoCompra
   },


}

export default comercial;