'use client'

import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";
import { moduleFatutamentoZanthus } from '@/api/m0055_faturamentoZanthus/moduleFaturamentoZanthus';
import HeaderMain from "@/app/components/divs/headerMain";

// Tipo para os itens do cupom
type tpCupomItem = {
  data: string;
  numero_cupom: string;
  ecf: number;
  cod_mercadoria: string;
  descricao: string;
  valor: string;
  valor_desconto: string;
  valor_liquido: string;
  qtde: string;
  pre_embalagem?: string;
  pr_cdproduto?: number;
  pr_descricao?: string;
  prb_cdprodutobluesoftunitario?: number;
  prb_cdprodutobluesoft?: number;
  pre_fatorestoque?: string;
  pre_fatorpreco?: string;
  pre_status?: boolean;
  pre_embalagem_descricao?: string;
  preg_cdbarra?: string;
}

// Props do componente modal
interface CupomModalProps {
  isOpen: boolean;
  onClose: (status: boolean) => void;
  ecf: number;
  numeroCupom: string;
  dataCupom: string;
}

export default function CupomModal({ isOpen, onClose, ecf, numeroCupom, dataCupom }: CupomModalProps) {
  const { user } = useAuth();

  const [itensCupom, setItensCupom] = useState<tpCupomItem[]>([]);
  const [ActionStatus, setActionStatus] = useState<number>(0);

  let moduleFaturamentoZanthus = new moduleFatutamentoZanthus(user!);

  useEffect(() => { 
    if (isOpen && ecf && numeroCupom && dataCupom) {
      ConsultarItensCupom();
    }
  }, [isOpen, ecf, numeroCupom, dataCupom])

  const ConsultarItensCupom = async () => {
    try {
      setActionStatus(1); // Carregando
      const parametros = {
        ecf: ecf,
        filtrar_data_cupom: 1,
        numero_cupom: numeroCupom,
        data_cupom_ini: dataCupom,
        data_cupom_fim: dataCupom
      };
      
      let itensConsultados = await moduleFaturamentoZanthus.getCupomItem(parametros);
      setItensCupom(itensConsultados || []);
      setActionStatus(0); // Carregado
    } catch (e) {
      console.log(`Erro ao consultar itens do cupom: ${e}`);
      setActionStatus(0);
    }
  };

  const formatCurrency = (value: string | number) => {
    const numValue = typeof value === 'string' ? parseFloat(value) : value;
    if (isNaN(numValue)) return '0,00';
    
    return new Intl.NumberFormat('pt-BR', {
      minimumFractionDigits: 2,
      maximumFractionDigits: 2
    }).format(numValue);
  };

  const formatQuantity = (qtde: string) => {
    const numValue = parseFloat(qtde);
    if (isNaN(numValue)) return '0,000';
    
    return new Intl.NumberFormat('pt-BR', {
      minimumFractionDigits: 3,
      maximumFractionDigits: 3
    }).format(numValue);
  };

  const formatarData = (data: string) => {
    return new Date(data).toLocaleDateString('pt-BR');
  };

  // Calcular totais
  const totais = itensCupom.reduce((acc, item) => {
    const valor = parseFloat(item.valor) || 0;
    const valorDesconto = parseFloat(item.valor_desconto) || 0;
    const valorLiquido = parseFloat(item.valor_liquido) || 0;
    const qtde = parseFloat(item.qtde) || 0;

    return {
      totalItens: acc.totalItens + 1,
      totalQuantidade: acc.totalQuantidade + qtde,
      totalValor: acc.totalValor + valor,
      totalDesconto: acc.totalDesconto + valorDesconto,
      totalLiquido: acc.totalLiquido + valorLiquido
    };
  }, {
    totalItens: 0,
    totalQuantidade: 0,
    totalValor: 0,
    totalDesconto: 0,
    totalLiquido: 0
  });

  if (!isOpen) return null;

  return (
    <div className="fixed inset-0 bg-black bg-opacity-75 flex items-center justify-center z-[9999]">
      <div className="bg-white rounded-lg shadow-xl max-w-6xl w-full mx-4 max-h-[80vh] flex flex-col">
        {/* Header - FIXO */}
        <HeaderMain tipo={"_MODAL"} ActionStatus={ActionStatus} header_title={`Itens do Cupom ${numeroCupom} - ECF ${ecf}`}>
          <div className="flex space-x-2">
            <button onClick={() => onClose(false)} className="text-white hover:text-gray-200 text-2xl font-bold"> × </button>
          </div>              
        </HeaderMain>

        {/* Content Container */}
        <div className="flex flex-col flex-1 min-h-0">
          {/* Loading State */}
          {ActionStatus === 1 ? (
            <div className="flex-1 flex items-center justify-center p-6">
              <div className="text-center">
                <div className="animate-spin rounded-full h-12 w-12 border-b-2 border-purple-600 mx-auto mb-4"></div>
                <p className="text-gray-600 text-lg font-medium">Carregando itens do cupom...</p>
                <p className="text-gray-400 text-sm mt-2">Aguarde, estamos buscando os dados</p>
              </div>
            </div>
          ) : (
            <>
              {/* Informações do Cupom - FIXO */}
              <div className="p-6 pb-0 flex-shrink-0">
                <div className="border border-gray-200 rounded-lg p-4">
                  <h3 className="text-lg font-semibold text-white mb-4 pb-2 px-3 py-2 bg-slate-400 rounded-t-lg -mx-4 -mt-4">
                    Informações do Cupom
                  </h3>
                  <div className="grid grid-cols-1 md:grid-cols-4 gap-4 mt-4">
                    <div>
                      <label className="block text-sm font-medium text-gray-600 mb-1">ECF:</label>
                      <p className="text-gray-800 font-medium bg-gray-50 p-2 rounded border">
                        {ecf}
                      </p>
                    </div>
                    <div>
                      <label className="block text-sm font-medium text-gray-600 mb-1">Número do Cupom:</label>
                      <p className="text-gray-800 font-medium bg-gray-50 p-2 rounded border text-lg">
                        {numeroCupom}
                      </p>
                    </div>
                    <div>
                      <label className="block text-sm font-medium text-gray-600 mb-1">Data:</label>
                      <p className="text-gray-800 bg-gray-50 p-2 rounded border">
                        {itensCupom.length > 0 ? formatarData(itensCupom[0].data) : formatarData(dataCupom)}
                      </p>
                    </div>
                    <div>
                      <label className="block text-sm font-medium text-gray-600 mb-1">Total de Itens:</label>
                      <p className="text-gray-800 bg-gray-50 p-2 rounded border font-medium">
                        {totais.totalItens}
                      </p>
                    </div>
                  </div>
                </div>
              </div>
                            {/* Resumo de Totais - FIXO */}
              {itensCupom.length > 0 && (
                <div className="px-6 pb-4 flex-shrink-0">
                  <div className="bg-blue-50 border border-blue-200 rounded-lg p-4">
                    <h4 className="text-sm font-semibold text-blue-700 mb-3">Resumo</h4>
                    <div className="grid grid-cols-2 md:grid-cols-5 gap-4 text-sm">
                      <div className="text-center">
                        <div className="font-medium text-blue-600">{totais.totalItens}</div>
                        <div className="text-blue-500">Itens</div>
                      </div>
                      <div className="text-center">
                        <div className="font-medium text-blue-600">{formatQuantity(totais.totalQuantidade.toString())}</div>
                        <div className="text-blue-500">Quantidade</div>
                      </div>
                      <div className="text-center">
                        <div className="font-medium text-blue-600">R$ {formatCurrency(totais.totalValor)}</div>
                        <div className="text-blue-500">Valor Bruto</div>
                      </div>
                      <div className="text-center">
                        <div className="font-medium text-red-600">R$ {formatCurrency(totais.totalDesconto)}</div>
                        <div className="text-red-500">Desconto</div>
                      </div>
                      <div className="text-center">
                        <div className="font-medium text-green-600">R$ {formatCurrency(totais.totalLiquido)}</div>
                        <div className="text-green-500">Valor Líquido</div>
                      </div>
                    </div>
                  </div>
                </div>
              )}

              {/* Tabela de Itens - SCROLLABLE */}
              <div className="flex-1 p-6 pt-4">
                <div className="border border-gray-200 rounded-lg">
                  <h3 className="text-lg font-semibold text-white mb-0 pb-2 px-3 py-2 bg-slate-400 rounded-t-lg">
                    Itens do Cupom ({itensCupom.length} itens)
                  </h3>
                  
                  {itensCupom.length > 0 ? (
              <div className="bg-white rounded-lg shadow-md overflow-hidden border border-purple-100">
                <div className="max-h-[350px] overflow-y-auto">
                  <table className="min-w-full divide-y divide-gray-200">
                          <thead className="bg-gray-100 sticky top-0 z-20 shadow-sm">
                            <tr>
                              <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                                Código
                              </th>
                              <th className="px-4 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                                Descrição
                              </th>
                              <th className="px-4 py-3 text-right text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                                Qtde
                              </th>
                              <th className="px-4 py-3 text-right text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                                Vlr Unit.
                              </th>
                              <th className="px-4 py-3 text-right text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                                Vlr Total
                              </th>
                              <th className="px-4 py-3 text-right text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                                Desconto
                              </th>
                              <th className="px-4 py-3 text-right text-xs font-medium text-gray-500 uppercase tracking-wider border-b">
                                Vlr Líquido
                              </th>
                            </tr>
                          </thead>
                          <tbody className="bg-white divide-y divide-gray-200">
                            {itensCupom.map((item, index) => {
                              const valorUnitario = (parseFloat(item.valor) || 0) / (parseFloat(item.qtde) || 1);
                              const temDesconto = parseFloat(item.valor_desconto) > 0;
                              
                              return (
                                <tr 
                                  key={`item-${index}-${item.cod_mercadoria}`} 
                                  className={`${temDesconto ? 'bg-red-50 hover:bg-red-100' : 'hover:bg-gray-50'}`}
                                >
                                  <td className="px-4 py-2 whitespace-nowrap text-sm font-medium text-gray-900">
                                    <div>{item.cod_mercadoria}</div>
                                    {item.preg_cdbarra && (
                                      <div className="text-xs text-gray-500">
                                        EAN: {item.preg_cdbarra.trim()}
                                      </div>
                                    )}
                                    {item.pr_cdproduto && (
                                      <div className="text-xs text-gray-500">
                                        Cód. Prod.: {item.pr_cdproduto}
                                      </div>
                                    )}
                                  </td>
                                  <td className="px-4 py-2 text-sm text-gray-900">
                                    <div className="font-medium">{item.descricao}</div>
                                    {item.pr_descricao && item.pr_descricao !== item.descricao && (
                                      <div className="text-xs text-gray-600 mt-1">
                                        {item.pr_descricao}
                                      </div>
                                    )}
                                    {item.pre_embalagem_descricao && (
                                      <div className="text-xs text-blue-600 mt-1">
                                        {item.pre_embalagem_descricao}
                                      </div>
                                    )}
                                  </td>
                                  <td className="px-4 py-2 whitespace-nowrap text-sm text-gray-900 text-right">
                                    <div>{formatQuantity(item.qtde)}</div>
                                    {item.pre_embalagem && (
                                      <div className="text-xs text-gray-500">
                                        {item.pre_embalagem}
                                      </div>
                                    )}
                                    {item.pre_fatorestoque && item.pre_fatorestoque !== "1.0000" && (
                                      <div className="text-xs text-orange-600">
                                        Fator: {parseFloat(item.pre_fatorestoque).toFixed(4)}
                                      </div>
                                    )}
                                  </td>
                                  <td className="px-4 py-2 whitespace-nowrap text-sm text-gray-900 text-right">
                                    <div>{formatCurrency(valorUnitario)}</div>

                                  </td>
                                  <td className="px-4 py-2 whitespace-nowrap text-sm text-gray-900 text-right">
                                    {formatCurrency(item.valor)}
                                  </td>
                                  <td className="px-4 py-2 whitespace-nowrap text-sm text-gray-900 text-right">
                                    {formatCurrency(item.valor_desconto)}
                                  </td>
                                  <td className="px-4 py-2 whitespace-nowrap text-sm font-medium text-gray-900 text-right">
                                    <div>{formatCurrency(item.valor_liquido)}</div>
                                    {item.pre_status === false && (
                                      <div className="text-xs text-red-600">
                                        Inativo
                                      </div>
                                    )}
                                  </td>
                                </tr>
                              );
                            })}
                          </tbody>
                        </table>
                      </div>
                    </div>
                  ) : (
                    <div className="flex-1 flex items-center justify-center p-8">
                      <div className="text-center">
                        <p className="text-gray-500 text-lg">Nenhum item encontrado</p>
                        <p className="text-gray-400 text-sm mt-2">Não há itens para este cupom</p>
                      </div>
                    </div>
                  )}
                </div>
              </div>


            </>
          )}
        </div>

        {/* Footer - FIXO */}
        <div className="bg-gray-50 px-6 py-4 rounded-b-lg flex justify-end flex-shrink-0">
          <button
            onClick={() => onClose(false)}
            className="bg-blue-500 hover:bg-blue-600 text-white px-4 py-2 rounded-md transition-colors"
          >
            Fechar
          </button>
        </div>
      </div>
    </div>
  );
}