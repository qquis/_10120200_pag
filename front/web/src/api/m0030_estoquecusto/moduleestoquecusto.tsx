import moduleUserConnect from "../m0001_sistema/moduleUserConnect"
import moduleDefault from '../module.default'

import jsPDF from 'jspdf'
import autoTable from 'jspdf-autotable'


class exportPdf { 
    static async AnaliseToInventario (List: any[], user : moduleUserConnect) : Promise<void> {
        if (!List || List.length === 0) {
            alert('Nao ha dados para exportar.')
            return
        }

        const doc = new jsPDF({
            orientation: 'landscape',
            unit: 'mm',
            format: 'a4'
        })

        const dataGeracao = new Date()
        const dataTexto = dataGeracao.toLocaleDateString('pt-BR')
        const horaTexto = dataGeracao.toLocaleTimeString('pt-BR')

        doc.setFontSize(12)
        doc.text('PRIME | Estoque/Custo | Analise de Estoque para Contagem de Inventário', 14, 12)

        doc.setFontSize(9)
        doc.text('Gerado em: ' + dataTexto + ' ' + horaTexto, 14, 17)
        doc.text('Total de registros: ' + List.length, 280, 17, { align: 'right' })

        const head = [[
            'Cd Blue',
            'Descricao',
            'Est. em CX',
            'Fator',
            'Estoque',
            'Ult. Venda',
            'Ult. Compra',
            'EAN/DUN',
            'Qtde Contagem'
        ]]

        const body = List.map((item) => [
            
            String(item.prb_cdprodutobluesoft ?? ''),
            item.pr_descricao || '',
            user.formatNumber(item.ec_embalagemcompra_qtde, 2),
            String(item.fator ?? ''),
            user.formatNumber(item.ec_embalagemestoque_qtde, 2),
            item.data_ultima_venda ? user.formatDateDDMMYYYY(item.data_ultima_venda) : '-',
            item.data_ultima_compra ? user.formatDateDDMMYYYY(item.data_ultima_compra) : '-',
            item.prb_cdbarra_principal || '-', 
            ``
        ])

        autoTable(doc, {
            startY: 22,
            head,
            body,
            theme: 'grid',
            styles: {
                fontSize: 7,
                cellPadding: 1.4,
                lineColor: [209, 213, 219],
                lineWidth: 0.1
            },
            headStyles: {
                fillColor: [30, 64, 175],
                textColor: 255,
                fontStyle: 'bold'
            },
            alternateRowStyles: {
                fillColor: [248, 250, 252]
            },
            columnStyles: {

                0: { halign: 'right', cellWidth: 18 },
                1: { halign: 'left', cellWidth: 58 },
                2: { halign: 'right', cellWidth: 16 },
                3: { halign: 'right', cellWidth: 12 },
                4: { halign: 'right', cellWidth: 16 },
                5: { halign: 'left', cellWidth: 16 },
                6: { halign: 'left', cellWidth: 16 },
                7: { halign: 'left', cellWidth: 24 },
                8: { halign: 'left', cellWidth: 24 }
            },
            didDrawPage: (data) => {
                const pageSize = doc.internal.pageSize
                const pageHeight = pageSize.getHeight()
                const pageWidth = pageSize.getWidth()
                const pageNumber = doc.getNumberOfPages()

                doc.setFontSize(8)
                doc.text('Pagina ' + pageNumber, pageWidth - 14, pageHeight - 6, { align: 'right' })

                if (data.pageNumber > 1) {
                    doc.setFontSize(10)
                    doc.text('Estoque/Custo | Analise de Estoque (continua)', 14, 12)
                }
            }
        })

        const nomeArquivo = `${user.formatDateTimeNowToStrNameFile()}_Operacional-AnaliseEstoque-Inv.pdf`
        doc.save(nomeArquivo)
    }
    
}

class moduleEstoqueCusto extends moduleDefault { 
    static export = exportPdf


    constructor(user: moduleUserConnect, sis_ac_cd: number) { 
        super(user, '/estoquecusto', sis_ac_cd)   



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

    async getAnaliseEstoque(parametro: any) : Promise<any> {
            try {
                let url =  `/report/analise-estoque?filter=1`



                if (parametro.dataFaturamento_filter == 1) { 
                    if (parametro.dataFaturamento_ini) { 
                        url += `&dataFaturamento_ini=${parametro.dataFaturamento_ini}`
                    }    
                }

                if (parametro.fatormediavenda) {
                    url += `&fatormediavenda=${parametro.fatormediavenda}`
                }
                if (parametro.cdparticipante_fabricante) {
                    url += `&cdparticipante_fabricante=${parametro.cdparticipante_fabricante}`
                }

                if (parametro.filtrarEstoque) {
                    url += `&filtrarEstoque=${parametro.filtrarEstoque}`
                    url += `&qtdeinicial=${parametro.qtdeinicial}`
                    url += `&qtdefinal=${parametro.qtdefinal}`
                }

                if (parametro.prd_cddepartamento) {
                    url += `&prd_cddepartamento=${parametro.prd_cddepartamento}`
                }

                if (parametro.prs_cdsecao) {
                    url += `&prs_cdsecao=${parametro.prs_cdsecao}`
                }

                if (parametro.venda_externa) {
                    url += `&venda_externa=${parametro.venda_externa}`
                }

                if (parametro.prb_status) {
                    url += `&prb_status=${parametro.prb_status}`
                }

                if (parametro.DataUltimaVendaFiltrar) {
                    url += `&DataUltimaVendaFiltrar=${parametro.DataUltimaVendaFiltrar}`
                    url += `&DataUltimaVendaIni=${parametro.DataUltimaVendaIni}`
                    url += `&DataUltimaVendaFim=${parametro.DataUltimaVendaFim}`
                }

                if (parametro.DataUltimaCompraFiltrar) {
                    url += `&DataUltimaCompraFiltrar=${parametro.DataUltimaCompraFiltrar}`
                    url += `&DataUltimaCompraIni=${parametro.DataUltimaCompraIni}`
                    url += `&DataUltimaCompraFim=${parametro.DataUltimaCompraFim}`
                }
                let result = await this._getAPI<any>(url)
                return result

            } catch(e) {
                throw new Error(`API ERROR: ${e}`); 
            }
    }   


}




export { moduleEstoqueCusto}


