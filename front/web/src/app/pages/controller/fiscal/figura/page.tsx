// app/pages/controller/fiscal/figura/page.tsx
'use client'
import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";
import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";
import { modulefiscal } from '@/api/m0040_fiscal/modulefiscal';

let myModuleFiscal: modulefiscal;

export default function FiguraFiscalList() {
  const { user } = useAuth();
  const [ActionStatus, setActionStatus] = useState<number>(0);
  
  const [descricaoFilter, setDescricaoFilter] = useState('');
  const [codigoFilter, setCodigoFilter] = useState('');

  const [filterQtdeRegraFiscal, setFilterQtdeRegraFiscal] = useState(false);
  const [filterQtdeRegraFiscalIni, setFilterQtdeRegraFiscalIni] = useState(0);
  const [filterQtdeRegraFiscalFim, setFilterQtdeRegraFiscalFim] = useState(0);
  
  myModuleFiscal = new modulefiscal(user,4213);

  const [figurasList, setFigurasList] = useState<any[]>([]);

  const AtualizaListFiguraRegraFiscal = async () => {
    setActionStatus(1);
    const success = await myModuleFiscal.atualizarListFiguraRegraFiscal();
    if (success) {
      alert('Base de Figura Fiscal atualizada com sucesso.');
    } else {
      alert('Erro ao atualizar a base de Figura Fiscal. Verifique o console para mais detalhes.');
    }
    await consultarFiguras();
    setActionStatus(0);
  };

  const AtualizaFiguraFiscalPorProdutoUnitario = async () => {
    setActionStatus(1);
    const success = await myModuleFiscal.atualizarFiguraFiscalPorProdutoUnitario();
    if (success) {
      alert('Base Fiscal dos Produtos atualizada com sucesso.');
    } else {
      alert('Erro ao atualizar a Base Fiscal dos Produtos. Verifique o console para mais detalhes.');
    }
    await consultarFiguras();
    setActionStatus(0);
  };

  const AtualizaFiguraProdutoNfce = async () => {
    setActionStatus(1);
    const success = await myModuleFiscal.atualizarFiguraProdutoNfce();
    if (success) {
      alert('Base Fiscal dos Produtos NFCE atualizada com sucesso.');
    } else {
      alert('Erro ao atualizar a Base Fiscal dos Produtos NFCE. Verifique o console para mais detalhes.');
    }
    await consultarFiguras();
    setActionStatus(0);
  };


  const AtualizaFiguraProdutoNfe = async () => {
    setActionStatus(1);
    const success = await myModuleFiscal.atualizarFiguraProdutoNfe();
    if (success) {
      alert('Base Fiscal dos Produtos NFE atualizada com sucesso.');
    } else {
      alert('Erro ao atualizar a Base Fiscal dos Produtos NFE. Verifique o console para mais detalhes.');
    }
    await consultarFiguras();
    setActionStatus(0);
  };

  const consultarFiguras = async () => {
    setActionStatus(1);
    setFigurasList([]);
    const parametro: any = {
      fc_figurafiscal_cd: codigoFilter !== '' ? Number(codigoFilter) : 0,
      fc_figurafiscal_descricao: descricaoFilter
    };

    if (filterQtdeRegraFiscal) {
        parametro.filterQtdeRegraFiscal = 1;
        parametro.filterQtdeRegraFiscalIni = filterQtdeRegraFiscalIni;
        parametro.filterQtdeRegraFiscalFim = filterQtdeRegraFiscalFim;
    } else {
        parametro.filterQtdeRegraFiscal = 0;
    }



    const response = await myModuleFiscal.getListfigura(parametro);
    setFigurasList(response);
    setActionStatus(0);
  };

  return (
    <div className="min-h-screen bg-gray-50 p-6">
      <div className="max-w-7xl mx-auto">
        <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Figuras Fiscais - Base Geral">
          <div className="flex space-x-2">
            <ButtonPag TypeButton="_BUTTON_HEADER" label="Atualizar" TypeIcon="_UPDATE" title="Atualizar" onClick={AtualizaListFiguraRegraFiscal} ActionStatus={ActionStatus} />
            <ButtonPag TypeButton="_BUTTON_HEADER" label="Pesquisar" TypeIcon="_PESQUISAR" title="Pesquisar" onClick={consultarFiguras} ActionStatus={ActionStatus} />
          </div>
        </HeaderMain>
        <div className="bg-white rounded-lg shadow-md p-6 mb-6 border border-purple-100">
          <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Código</label>
              <input
                type="text"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                placeholder="Filtrar por código"
                value={codigoFilter}
                onChange={(e) => setCodigoFilter(e.target.value)}
              />
            </div>
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Descrição</label>
              <input
                type="text"
                className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                placeholder="Filtrar por descrição"
                value={descricaoFilter}
                onChange={(e) => setDescricaoFilter(e.target.value)}
              />
            </div>
            <div className="flex items-center space-x-2 mt-2">
              <input
                id="filterQtdeRegraFiscal"
                type="checkbox"
                checked={filterQtdeRegraFiscal}
                onChange={e => setFilterQtdeRegraFiscal(e.target.checked)}
                className="h-4 w-4 text-purple-600 border-gray-300 rounded"
              />
              <label htmlFor="filterQtdeRegraFiscal" className="text-sm font-medium text-gray-700">
                Filtrar por Operações de Saída
              </label>
              <div className="flex items-center space-x-2 mt-2 ml-6">
                <input
                  type="number"
                  min={0}
                  disabled={!filterQtdeRegraFiscal}
                  value={filterQtdeRegraFiscalIni}
                  onChange={e => setFilterQtdeRegraFiscalIni(Number(e.target.value))}
                  className="w-20 p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                  placeholder="De"
                />
                <span className="text-gray-500">a</span>
                <input
                  type="number"
                  min={0}
                  disabled={!filterQtdeRegraFiscal}
                  value={filterQtdeRegraFiscalFim}
                  onChange={e => setFilterQtdeRegraFiscalFim(Number(e.target.value))}
                  className="w-20 p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-purple-500 focus:border-transparent text-black"
                  placeholder="Até"
                />
              </div>
            </div>
          </div>
        </div>
        {/* Centraliza o grid */}
        <div className="bg-white rounded-lg shadow-md overflow-hidden border border-purple-100">
          <div className="max-h-[500px] overflow-y-auto">
            <table className="min-w-full divide-y divide-gray-200">
                    <thead className="bg-gray-100 sticky top-0 z-10">
                <tr>
                  <th className="px-4 py-2 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Código</th>
                  <th className="px-4 py-2 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Descrição</th>
                  <th className="px-4 py-2 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Regras de Entrada</th>
                  <th className="px-4 py-2 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Regras de Saída</th>                  
                  <th className="px-4 py-2 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Operações de Saídas Vinculadas</th>
                  <th className="px-4 py-2 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Código Figura</th>
                  <th className="px-4 py-2 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Versão</th>
                  <th className="px-4 py-2 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Base</th>

                  <th className="px-4 py-2 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Criado em</th>
                  <th className="px-4 py-2 text-left text-xs font-medium text-purple-700 uppercase tracking-wider">Atualizado em</th>
                </tr>
              </thead>
              <tbody className="bg-white divide-y divide-gray-200">
                {figurasList.length > 0 ? (
                  figurasList.map((figura) => (
                    <tr key={figura.fc_figurafiscal_cd} className="hover:bg-gray-50">
                      <td className="px-4 py-2 whitespace-nowrap text-sm text-gray-700 text-right">{figura.fc_figurafiscal_cd}</td>
                      <td className="px-4 py-2 whitespace-nowrap text-sm text-gray-700">{figura.fc_figurafiscal_descricao}</td>
                      <td className="px-4 py-2 whitespace-nowrap text-sm text-gray-700 text-right">{figura.entrada_qtde}</td>
                      <td className="px-4 py-2 whitespace-nowrap text-sm text-gray-700 text-right">{figura.saida_qtde}</td>
                      <td className="px-4 py-2 whitespace-nowrap text-sm text-gray-700 text-right">{figura.saida_operacao_qtde}</td>                      
                      <td className="px-4 py-2 whitespace-nowrap text-sm text-gray-700">{figura.fc_figurafiscal_codigo}</td>
                      <td className="px-4 py-2 whitespace-nowrap text-sm text-gray-700 text-right">{figura.fc_figurafiscal_versao}</td>
                      <td className="px-4 py-2 whitespace-nowrap text-sm text-gray-700 text-right">{figura.fc_figurafiscal_base}</td>
                      <td className="px-4 py-2 whitespace-nowrap text-sm text-gray-700">{figura.dtlog_insert ? new Date(figura.dtlog_insert).toLocaleString() : ''}</td>
                      <td className="px-4 py-2 whitespace-nowrap text-sm text-gray-700">{figura.dtlog_update ? new Date(figura.dtlog_update).toLocaleString() : ''}</td>
                    </tr>
                  ))
                ) : (
                  <tr>
                    <td colSpan={8} className="px-6 py-4 text-center text-sm text-gray-500">
                      Nenhuma figura fiscal encontrada.
                    </td>
                  </tr>
                )}
              </tbody>
            </table>
          </div>
        </div>
        {/* Fim centralização do grid */}
        <div className="px-6 py-4 bg-gray-50 border-b border-gray-200">
          <div className="flex justify-between items-center">
            <h3 className="text-mg font-medium text-gray-500">Total de Registros</h3>
            <span className="inline-flex items-center px-3 py-1 rounded-full text-sm font-medium bg-purple-100 text-purple-800">
              {figurasList.length} figura{figurasList.length !== 1 ? 's' : ''}
            </span>
          </div>
        </div>
      



      <div className="bg-white border border-gray-200 rounded-xl shadow-sm p-4">
        <div className="flex items-center gap-4">
          <h2 className="text-base font-semibold text-gray-800">
            Atualizar Base de Figura / Regras (Sem itens)
          </h2>
          <ButtonPag TypeButton="_BUTTON_HEADER" label="" TypeIcon="_UPDATE" title="Importar Base NFCE" onClick={AtualizaListFiguraRegraFiscal} ActionStatus={ActionStatus}
          />
        </div>
      </div>


      <div className="bg-white border border-gray-200 rounded-xl shadow-sm p-4">
        <div className="flex items-center gap-4">
          <h2 className="text-base font-semibold text-gray-800">
            Atualizar Base Fiscal por Produto Unitário 
          </h2>
          <ButtonPag TypeButton="_BUTTON_HEADER" label="" TypeIcon="_UPDATE" title="Produto/Figura" onClick={AtualizaFiguraFiscalPorProdutoUnitario} ActionStatus={ActionStatus}
          />
        </div>
      </div>


            <div className="bg-white border border-gray-200 rounded-xl shadow-sm p-4">
        <div className="flex items-center gap-4">
          <h2 className="text-base font-semibold text-gray-800">
            Atualizar Produto / Figura Fiscal NFCE
          </h2>
          <ButtonPag TypeButton="_BUTTON_HEADER" label="" TypeIcon="_UPDATE" title="Importar Base NFCE" onClick={AtualizaFiguraProdutoNfce} ActionStatus={ActionStatus}
          />
        </div>
      </div>

                  <div className="bg-white border border-gray-200 rounded-xl shadow-sm p-4">
        <div className="flex items-center gap-4">
          <h2 className="text-base font-semibold text-gray-800">
            Atualizar Produto / Figura Fiscal NFE
          </h2>
          <ButtonPag TypeButton="_BUTTON_HEADER" label="" TypeIcon="_UPDATE" title="Importar Base NFE" onClick={AtualizaFiguraProdutoNfe} ActionStatus={ActionStatus}
          />
        </div>
      </div>

      </div>
    </div>
  );
}
