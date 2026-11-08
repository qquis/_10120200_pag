'use client';

import { useState, useEffect } from 'react';
import { useAuth } from '@/app/context/context';
import { moduleFaturamentoBluesoft } from '@/api/m0050_faturamentoBluesoft/moduleFaturamentoBluesoft';
import HeaderMain from '@/app/components/divs/headerMain';
import ButtonPag from '@/app/components/Buttons/button';

interface ModalFaturamentoBluesoftProps {
  numeropedido: number;
  numeropedido_fv: number;
  op_cdoperacao: number;
  onClose: () => void;
}

export default function ModalFaturamentoBluesoft({
  numeropedido,
  numeropedido_fv,
  op_cdoperacao,
  onClose,
}: ModalFaturamentoBluesoftProps) {
  const __SIS_AC_CD: number = 3210;

  const { user } = useAuth();
  const [ActionStatus, setActionStatus] = useState(0);
  const [pedido, setPedido] = useState<any>(null);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const carregar = async () => {
      try {
        setActionStatus(1);
        setError(null);
        const myMODULE = new moduleFaturamentoBluesoft(user, __SIS_AC_CD);
        const resultado = await myMODULE.getFaturamentoBluesoftConsultar({
          op_cdoperacao,
          numeropedido,
          numeropedido_fv,
        });
        setPedido(resultado);
      } catch (err) {
        setError('Erro ao carregar dados do pedido.');
      } finally {
        setActionStatus(0);
      }
    };
    carregar();
  }, [numeropedido, numeropedido_fv, op_cdoperacao]);

  return (
    <div className="p-4">
      <HeaderMain
        tipo="_PAGE"
        ActionStatus={ActionStatus}
        header_title={`Faturamento Bluesoft | Pedido ${numeropedido}`}
      >
        <div className="flex space-x-2">
          <ButtonPag
            TypeButton="_BUTTON_HEADER"
            label="Fechar"
            TypeIcon="_VOLTAR"
            title="Fechar consulta"
            onClick={onClose}
          />
        </div>
      </HeaderMain>

      {error && (
        <div className="bg-red-50 border border-red-200 rounded-lg p-3 mb-4">
          <span className="text-red-700 text-sm">{error}</span>
        </div>
      )}

      {pedido && (
        <>
          {/* Card de Cabeçalho */}
          <div className="bg-white rounded-lg shadow-md border border-purple-100 p-4 mb-4">
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">

              {/* Empresa / Operação */}
              <div className="bg-gray-50 rounded-lg p-3 border">
                <label className="block text-xs font-medium text-gray-500 mb-1">Empresa / Operação</label>
                <div className="text-sm font-semibold text-gray-800">
                  {pedido.em_descricao} / {pedido.op_descricao}
                </div>
              </div>

              {/* Número do Pedido */}
              <div className="bg-gray-50 rounded-lg p-3 border">
                <label className="block text-xs font-medium text-gray-500 mb-1">Nº Pedido / Nº FV</label>
                <div className="text-sm font-semibold text-gray-800">
                  {pedido.numeropedido} / {pedido.numeropedido_fv}
                </div>
              </div>

              {/* Status Faturamento */}
              <div className="bg-gray-50 rounded-lg p-3 border">
                <label className="block text-xs font-medium text-gray-500 mb-1">Status Faturamento</label>
                <span className="inline-flex px-2 py-1 text-xs font-medium rounded-full bg-yellow-100 text-yellow-800">
                  {pedido.statusfaturamento_descricao}
                </span>
              </div>

              {/* Tipo + Status Bluesoft + Origem (agrupado) */}
              <div className="bg-gray-50 rounded-lg p-3 border lg:col-span-3">
                <div className="flex flex-wrap items-center gap-2 mb-2">


                  <span className="inline-flex px-2 py-1 text-xs font-medium rounded-full bg-blue-100 text-blue-800">
                    Origem: {pedido.origem_pedido || '-'}
                  </span>

                  <span className="inline-flex px-2 py-1 text-xs font-medium rounded-full bg-blue-100 text-blue-800">
                    Tipo: {pedido.fat_blue_tipo_descricao}
                  </span>
                  <span className="inline-flex px-2 py-1 text-xs font-medium rounded-full bg-purple-100 text-purple-800">
                    Status Bluesoft: {pedido.fat_blue_status_descricao}
                  </span>



                  <span className="inline-flex px-2 py-1 text-xs font-medium rounded-full bg-blue-100 text-blue-800">
                    Tab.: {pedido.fv_tabelapreco_descricao} [Versão : {pedido.tabelapreco_versao_cd}]
                  </span>

                  <span className="inline-flex px-2 py-1 text-xs font-medium rounded-full bg-blue-100 text-blue-800">
                    Prazo: {pedido.fv_prazopgto_descricao}
                  </span>


                  <span className="inline-flex px-2 py-1 text-xs font-medium rounded-full bg-blue-100 text-blue-800">
                    Transportadora: {pedido.transportadora_descricao || '—'}  {pedido.transportadora_placaveiculo ? ` | ${pedido.transportadora_placaveiculo}` : ''}
                  </span>

                </div>
              </div>


            </div>
          </div>

          {/* Card do Cliente (compacto) */}
          <div className="bg-white rounded-lg shadow-md border border-purple-100 p-3 mb-4">
            <h2 className="text-sm font-semibold text-purple-700 mb-2">Cliente</h2>

            <div className="bg-gray-50 rounded-lg border p-2">
              <div className="flex flex-wrap items-center gap-x-4 gap-y-1 text-sm">
                <div>
                  <span className="text-gray-500">Cód. Bluesoft:</span>{' '}
                  <span className="font-semibold text-gray-800">
                    {pedido.cdpessoabluesoft_cliente}
                  </span>
                </div>
                <div>
                  <span className="text-gray-500">CPF/CNPJ:</span>{' '}
                  <span className="font-semibold text-gray-800">
                    {pedido.cpf_cnpj_cliente}
                  </span>
                </div>

                <span className="text-gray-500">Nome/Razão:</span>{' '}
                <span className="font-semibold text-gray-800">
                  {pedido.cliente_nome_razao}
                </span>
              </div>
            </div>
          </div>

          {/* Card do Vendedor (compacto, igual ao cliente) */}
          <div className="bg-white rounded-lg shadow-md border border-purple-100 p-3 mb-4">
            <h2 className="text-sm font-semibold text-purple-700 mb-2">Vendedor</h2>

            <div className="bg-gray-50 rounded-lg border p-2">
              <div className="flex flex-wrap items-center gap-x-4 gap-y-1 text-sm">
                <div>
                  <span className="text-gray-500">Cód. Bluesoft:</span>{' '}
                  <span className="font-semibold text-gray-800">
                    {pedido.cdpessoabluesoft_vendedor}
                  </span>
                </div>

              <div className="mt-1 text-sm">
                <span className="text-gray-500">Nome:</span>{' '}
                <span className="font-semibold text-gray-800">
                  {pedido.vendedor_nome_razao}
                </span>
              </div>

              </div>


            </div>
          </div>

          {/* Card Financeiro */}
          <div className="bg-white rounded-lg shadow-md border border-purple-100 p-4 mb-4">
            <h2 className="text-sm font-semibold text-purple-700 mb-3">Dados do Pedido</h2>
            <div className="grid grid-cols-2 md:grid-cols-5 gap-4">
              {/* Data Emissão */}
              <div className="bg-blue-50 rounded-lg p-3 border text-center">
                <label className="block text-xs font-medium text-gray-500 mb-1">Data Emissão</label>
                <div className="text-sm font-semibold text-gray-800">
                  {user.formatDateDDMMYYYY(pedido.data_emissao)}
                </div>
              </div>

              <div className="bg-gray-50 rounded-lg p-3 border text-center">
                <label className="block text-xs font-medium text-gray-500 mb-1">Nº Itens</label>
                <div className="text-lg font-bold text-gray-800">{pedido.numero_itens}</div>
              </div>
              <div className="bg-green-50 rounded-lg p-3 border text-center">
                <label className="block text-xs font-medium text-gray-500 mb-1">Valor Pedido</label>
                <div className="text-lg font-bold text-green-700">
                  {user.formatNumber(pedido.valor_pedido, 2, true)}
                </div>
              </div>

              {/* Data Faturamento */}
              <div className="bg-blue-50 rounded-lg p-3 border text-center">
                <label className="block text-xs font-medium text-gray-500 mb-1">Data Faturamento</label>
                <div className="text-sm font-semibold text-gray-800">
                  {user.formatDateDDMMYYYY(pedido.data_faturamento)}
                </div>
              </div>

              <div className="bg-blue-50 rounded-lg p-3 border text-center">
                <label className="block text-xs font-medium text-gray-500 mb-1">Valor Faturado</label>
                <div className="text-lg font-bold text-blue-700">
                  {user.formatNumber(pedido.valor_faturamento, 2, true)}
                </div>
              </div>
           </div>
          </div>

          {/* Tabela de Itens */}
          <div className="bg-white rounded-lg shadow-md border border-purple-100 overflow-hidden">
            <div className="px-4 py-3 bg-purple-50 border-b border-purple-100">
              <h2 className="text-sm font-semibold text-purple-700">Itens do Pedido</h2>
            </div>
            <div className="overflow-x-auto max-h-[400px] overflow-y-auto">
              <table className="min-w-full divide-y divide-gray-200">
                <thead className="bg-gray-100 sticky top-0 z-10">
                  <tr>
                    <th className="px-3 py-2 text-left text-xs font-medium text-purple-700 tracking-wider">Cód. Produto</th>
                    <th className="px-3 py-2 text-left text-xs font-medium text-purple-700 tracking-wider">Embalagem</th>
                    <th className="px-3 py-2 text-right text-xs font-medium text-purple-700 tracking-wider">Qtde Sol.</th>
                    <th className="px-3 py-2 text-right text-xs font-medium text-purple-700 tracking-wider">Qtde Fat.</th>
                    <th className="px-3 py-2 text-right text-xs font-medium text-purple-700 tracking-wider">Custo</th>
                    <th className="px-3 py-2 text-right text-xs font-medium text-purple-700 tracking-wider">Preço Tabela</th>
                    <th className="px-3 py-2 text-right text-xs font-medium text-purple-700 tracking-wider">Preço Aplicado</th>
                    <th className="px-3 py-2 text-right text-xs font-medium text-purple-700 tracking-wider">Verba</th>
                    <th className="px-3 py-2 text-right text-xs font-medium text-purple-700 tracking-wider">Total NF</th>
                  </tr>
                </thead>
                <tbody className="bg-white divide-y divide-gray-200">
                  {pedido.itens && pedido.itens.length > 0 ? (
                    pedido.itens.map((item: any, index: number) => (
                      <tr key={index} className="hover:bg-gray-50">
                        <td className="px-3 py-2 text-xs text-gray-700 whitespace-nowrap">
                          {item.prb_cdprodutobluesoft} 
                        </td>
                        <td className="px-3 py-2 text-xs text-gray-700 whitespace-nowrap">
                          {item.prb_descricao} 
                        </td>
                        <td className="px-3 py-2 text-xs text-gray-700 whitespace-nowrap text-right">
                          {user.formatNumber(item.qtde_solicitada, 2, false)}
                        </td>
                      <td
                        className={`px-3 py-2 text-xs whitespace-nowrap text-right ${
                          pedido.statusfaturamento_descricao?.toUpperCase() === 'FATURADO' &&
                          Number(item.qtde_faturada) !== Number(item.qtde_solicitada)
                            ? 'bg-red-200 text-red-900 font-semibold'
                            : 'text-gray-700'
                        }`}
                      >
                        {user.formatNumber(item.qtde_faturada, 2, false)}
                      </td>
                        <td className="px-3 py-2 text-xs text-gray-700 whitespace-nowrap text-right">
                          {user.formatNumber(item.valor_custo, 2, true)}
                        </td>
                        <td className="px-3 py-2 text-xs text-gray-700 whitespace-nowrap text-right">
                          {user.formatNumber(item.valor_preco_tabela, 2, true)}
                        </td>
                        <td className="px-3 py-2 text-xs text-gray-700 whitespace-nowrap text-right">
                          {user.formatNumber(item.valor_preco_aplicado, 2, true)}
                        </td>
                        <td className="px-3 py-2 text-xs text-gray-700 whitespace-nowrap text-right">
                          {user.formatNumber(item.valor_verba_calculada, 2, true)}
                        </td>
                        <td className="px-3 py-2 text-xs text-gray-700 whitespace-nowrap text-right">
                          {user.formatNumber(item.valor_nf_item, 2, true)}
                        </td>
                      </tr>
                    ))
                  ) : (
                    <tr>
                      <td colSpan={9} className="px-6 py-4 text-center text-sm text-gray-500">
                        Nenhum item encontrado
                      </td>
                    </tr>
                  )}
                </tbody>
              </table>
            </div>
            <div className="px-4 py-2 bg-gray-50 border-t">
              <span className="inline-flex items-center px-3 py-1 rounded-full text-xs font-medium bg-purple-100 text-purple-800">
                Total de itens: {pedido.itens?.length ?? 0}
              </span>
            </div>
          </div>
        </>
      )}
    </div>
  );
}