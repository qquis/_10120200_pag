import pagToolsDate from '../../tools/pagToolsDate'
const F0132_04_TbComercialPrePedido_List = {
     get_Postgre: (     str_to_Date_inicio: string
                    ,   str_to_Date_Fim: string
                    ,   fabricante_cdpessoabluesoft: number 
                    ,   controle_status_pedido: number 
        ): string => {

            const data_inicio = new Date(pagToolsDate.getDateFromString(str_to_Date_inicio))
            const data_fim = new Date(pagToolsDate.getDateFromString(str_to_Date_Fim))

            return `select * from f0132_04_1011872_tbcomercial_pre_pedido_list ('${pagToolsDate.str_yyyymmdd(data_inicio)}', '${pagToolsDate.str_yyyymmdd(data_fim)}', ${fabricante_cdpessoabluesoft}, ${controle_status_pedido} )`
    }
}
export default F0132_04_TbComercialPrePedido_List