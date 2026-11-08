import * as XLSX from 'xlsx';
import { saveAs } from 'file-saver';

export interface ExportColumn {
  key: string;
  header: string;
  width?: number;
  format?: (value: any) => string;
}

export default class ExcelExporter {
  
  /**
   * Exporta dados para Excel com configuração customizável
   */
  static exportToExcel(
    data: any[],
    columns: ExportColumn[],
    options: {
      fileName?: string;
      sheetName?: string;
      title?: string;
      includeHeader?: boolean;
      formatUserUtils?: any;
    } = {}
  ) {
    const {
      fileName = `export_${new Date().toISOString().slice(0,19).replace(/[-:T]/g, '')}.xlsx`,
      sheetName = 'Dados',
      title,
      includeHeader = true,
      formatUserUtils
    } = options;

    if (data.length === 0) {
      alert('Não há dados para exportar');
      return;
    }

    // Preparar dados para exportação
    const dataForExport = data.map(item => {
      const exportItem: any = {};
      columns.forEach(column => {
        let value = item[column.key];
        
        // Aplicar formatação se definida
        if (column.format) {
          value = column.format(value);
        }
        
        exportItem[column.header] = value || '';
      });
      return exportItem;
    });

    let ws: any;
    
    // Adicionar cabeçalho com informações se especificado
    if (includeHeader && title) {
      const headerInfo = [
        [title],
        [`Data de Geração: ${new Date().toLocaleString('pt-BR')}`],
        [`Total de Registros: ${data.length}`],
        [''], // linha vazia
      ];

      // Criar worksheet começando com o cabeçalho
      ws = XLSX.utils.aoa_to_sheet(headerInfo);
      
      // Adicionar os dados a partir da linha 6 (A6)
      XLSX.utils.sheet_add_json(ws, dataForExport, { 
        origin: 'A6', 
        skipHeader: false 
      });
    } else {
      // Criar worksheet diretamente com os dados
      ws = XLSX.utils.json_to_sheet(dataForExport);
    }

    // Configurar larguras das colunas
    if (columns.some(col => col.width)) {
      ws['!cols'] = columns.map(col => ({ wch: col.width || 15 }));
    }

    // Criar workbook e adicionar worksheet
    const wb = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, sheetName);

    // Exportar arquivo
    const excelBuffer = XLSX.write(wb, { bookType: 'xlsx', type: 'array' });
    const blob = new Blob([excelBuffer], { 
      type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' 
    });
    saveAs(blob, fileName);
  }

  /**
   * Configuração específica para produtos fiscais
   */
  static exportProdutosFiscais(produtosList: any[], userUtils?: any) {
    const columns: ExportColumn[] = [
      { key: 'pr_cdproduto', header: 'Código', width: 8 },
      { key: 'prb_cdprodutobluesoft', header: 'Blue Unit', width: 12 },
      { key: 'prb_cdprodutobluesoft_pk', header: 'Cod Blue', width: 12 },
      { key: 'prb_descricao', header: 'Descrição Blue', width: 30 },
      { key: 'prb_descricao_fiscal', header: 'Descrição Fiscal', width: 40 },
      { key: 'pr_embalagemestoque', header: 'Estoque', width: 8 },
      { 
        key: 'prb_status', 
        header: 'Status', 
        width: 8,
        format: (value) => value === 1 ? "Ativo" : "Inativo"
      },
      { 
        key: 'prb_vendaexterna', 
        header: 'Venda Externa', 
        width: 12,
        format: (value) => value === 1 ? "Sim" : "Não"
      },
      { key: 'fc_figurafiscal_descricao', header: 'Figura Fiscal', width: 20 },
      { key: 'status_regra_nfce', header: 'Regra NFCE', width: 12 },
      { 
        key: 'prb_dt_cadastro', 
        header: 'Data Cadastro', 
        width: 12,
        format: (value) => userUtils ? userUtils.formatDateDDMMYYYY(value) : value
      },
      { key: 'fornecedor_nome_razao', header: 'Fornecedor', width: 25 },
      { key: 'ncm_codigo', header: 'NCM', width: 12 },
      { key: 'pis_cst', header: 'PIS CST', width: 8 },
      { 
        key: 'pis_aliquota', 
        header: 'PIS Alíquota', 
        width: 10,
        format: (value) => userUtils ? userUtils.formatNumber(value) : value
      },
      { key: 'cofins_cst', header: 'COFINS CST', width: 8 },
      { 
        key: 'cofins_aliquota', 
        header: 'COFINS Alíquota', 
        width: 10,
        format: (value) => userUtils ? userUtils.formatNumber(value) : value
      },
      { key: 'cst', header: 'ICMS CST', width: 8 },
      { 
        key: 'icms_aliquota', 
        header: 'ICMS Alíquota', 
        width: 10,
        format: (value) => userUtils ? userUtils.formatNumber(value) : value
      },
      { 
        key: 'icms_reducao', 
        header: 'ICMS Redução', 
        width: 10,
        format: (value) => userUtils ? userUtils.formatNumber(value) : value
      },
      
      { key: 'rt_codigo_cst_ibs_cbs', header: 'Reforma CST', width: 12 },
      
      { 
        key: 'rt_codigo_class_trib_ibs_cbs', 
        header: 'Class Trib', 
        width: 10,
        format: (value) => userUtils ? userUtils.formatNumber(value) : value
      },
            
      
      { 
        key: 'ibs_mun_aliquota', 
        header: 'IBS Mun', 
        width: 10,
        format: (value) => userUtils ? userUtils.formatNumber(value) : value
      },
      { 
        key: 'ibs_mun_percentual_reducao', 
        header: 'IBS Mun Redução', 
        width: 10,
        format: (value) => userUtils ? userUtils.formatNumber(value) : value
      },
      
      
      { 
        key: 'ibs_aliquota', 
        header: 'IBS Alíquota', 
        width: 10,
        format: (value) => userUtils ? userUtils.formatNumber(value) : value
      },
      { 
        key: 'ibs_percentual_reducao', 
        header: 'IBS Redução', 
        width: 10,
        format: (value) => userUtils ? userUtils.formatNumber(value) : value
      },


      { 
        key: 'cbs_aliquota', 
        header: 'CBS Alíquota', 
        width: 10,
        format: (value) => userUtils ? userUtils.formatNumber(value) : value
      },
      { 
        key: 'cbs_percentual_reducao', 
        header: 'CBS Redução', 
        width: 10,
        format: (value) => userUtils ? userUtils.formatNumber(value) : value
      }      
    ];

    const now = new Date();
    const fileName = `produtos_regra_fiscal_${now.getFullYear()}${(now.getMonth()+1).toString().padStart(2,'0')}${now.getDate().toString().padStart(2,'0')}_${now.getHours().toString().padStart(2,'0')}${now.getMinutes().toString().padStart(2,'0')}.xlsx`;

    this.exportToExcel(produtosList, columns, {
      fileName,
      sheetName: 'Produtos',
      title: 'Relatório de Produtos - Regra Fiscal NFCE',
      includeHeader: true,
      formatUserUtils: userUtils
    });
  }
}