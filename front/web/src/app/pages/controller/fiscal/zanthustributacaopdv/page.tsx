// app/pages/controller/fiscal/zanthustributacaopdv/page.tsx
'use client'
import { useState } from 'react';
import { useAuth } from "@/app/context/context";
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";
import { modulefiscal } from '@/api/m0040_fiscal/modulefiscal';

let myModuleFiscal: modulefiscal;

const SIS_AC_CD = 4720; 

export default function ZanthusTributacaoIcmsPdvList() {
  const { user } = useAuth();
  const [ActionStatus, setActionStatus] = useState<number>(0);

  const [comProdutosFilter, setComProdutosFilter] = useState(false);
  const [comProdutoSemTributacaoPDVFilter, setComProdutoSemTributacaoPDVFilter] = useState(false);
  const [codigoTributacaoFilter, setCodigoTributacaoFilter] = useState('');

  myModuleFiscal = new modulefiscal(user, SIS_AC_CD);

  const [tributacaoList, setTributacaoList] = useState<any[]>([]);

  const consultarTributacao = async () => {
    setActionStatus(1);
    setTributacaoList([]);
    const parametro: any = {
      codigotributacao: codigoTributacaoFilter !== '' ? Number(codigoTributacaoFilter) : 0,
      ComProdutos: comProdutosFilter? 1:0,
      SemTributacaoPDV: comProdutoSemTributacaoPDVFilter? 1:0,
    };
    
    const response = await myModuleFiscal.getZanthusTributacaoIcmsPdv(parametro);

    setTributacaoList(response);
    setActionStatus(0);
  };

  return (
    <div className="min-h-screen bg-gray-50 p-6">
      <div className="max-w-7xl mx-auto">
        <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Tributação ICMS PDV - Zanthus">
          <div className="flex space-x-2">
            <ButtonPag TypeButton="_BUTTON_HEADER" label="Pesquisar" TypeIcon="_PESQUISAR" title="Pesquisar" onClick={consultarTributacao} ActionStatus={ActionStatus} />
          </div>
        </HeaderMain>
        <div className="bg-white rounded-lg shadow-md p-6 mb-6 border border-purple-100">
          <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Com Produtos</label>
              <input
                type="checkbox"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                checked={comProdutosFilter}
                onChange={(e) => setComProdutosFilter(e.target.checked)}
              />
            </div>
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Com Produto Sem Tributação PDV</label>
              <input
                type="checkbox"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                checked={comProdutoSemTributacaoPDVFilter}
                onChange={(e) => setComProdutoSemTributacaoPDVFilter(e.target.checked)}
              />
            </div>
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Código Tributação</label>
              <input
                type="text"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                placeholder="Filtrar por código de tributação"
                value={codigoTributacaoFilter}
                onChange={(e) => setCodigoTributacaoFilter(e.target.value)}
              />
            </div>
          </div>
        </div>

        <div className="bg-white rounded-lg shadow-md overflow-hidden border border-purple-100">
          <div className="max-h-[500px] overflow-y-auto">
            <table className="min-w-full divide-y divide-gray-200">
              <thead className="bg-gray-100 sticky top-0 z-10">
                <tr>
                  <th className="px-4 py-2 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Código ICMS</th>
                  <th className="px-4 py-2 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Descrição</th>
                  <th className="px-4 py-2 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Alíquota</th>
                  <th className="px-4 py-2 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Redução</th>
                  <th className="px-4 py-2 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Código Tributação</th>
                  <th className="px-4 py-2 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Código Origem</th>
                  <th className="px-4 py-2 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Cód. Tributação PDV</th>
                  <th className="px-4 py-2 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Qtde Produto</th>
                  <th className="px-4 py-2 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">TributaçãO PRIME</th>
                </tr>
              </thead>
              <tbody className="bg-white divide-y divide-gray-200">
                {tributacaoList.length > 0 ? (
                  tributacaoList.map((item) => (
                    <tr key={item.icms_cd} className="hover:bg-gray-50">
                      <td className="px-4 py-2 whitespace-nowrap text-sm text-gray-700 text-right">{item.icms_cd}</td>
                      <td className="px-4 py-2 whitespace-nowrap text-sm text-gray-700">{item.icms_descricao}</td>
                      <td className="px-4 py-2 whitespace-nowrap text-sm text-gray-700 text-right">{item.aliquota}</td>
                      <td className="px-4 py-2 whitespace-nowrap text-sm text-gray-700 text-right">{item.reducao}</td>
                      <td className="px-4 py-2 whitespace-nowrap text-sm text-gray-700 text-right">{item.codigotributacao}</td>
                      <td className="px-4 py-2 whitespace-nowrap text-sm text-gray-700 text-right">{item.codigoorigem}</td>
                      <td className="px-4 py-2 whitespace-nowrap text-sm text-gray-700 text-right">{item.cod_tributacao_pdv}</td>
                      <td className="px-4 py-2 whitespace-nowrap text-sm text-gray-700 text-right">{item.qtde_produto}</td>
                      <td className="px-4 py-2 whitespace-nowrap text-sm text-gray-700 text-left">{item.tributacao_icms_pdv_descricao}</td>
                      
                    </tr>
                  ))
                ) : (
                  <tr>
                    <td colSpan={8} className="px-6 py-4 text-center text-sm text-gray-500">
                      Nenhum registro encontrado.
                    </td>
                  </tr>
                )}
              </tbody>
            </table>
          </div>
        </div>

        <div className="px-6 py-4 bg-gray-50 border-b border-gray-200">
          <div className="flex justify-between items-center">
            <h3 className="text-mg font-medium text-gray-500">Total de Registros</h3>
            <span className="inline-flex items-center px-3 py-1 rounded-full text-sm font-medium bg-purple-100 text-purple-800">
              {tributacaoList.length} registro{tributacaoList.length !== 1 ? 's' : ''}
            </span>
          </div>
        </div>
      </div>
    </div>
  );
}