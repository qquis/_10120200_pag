'use client'
const __SIS_AC_CD: number = 3090

import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";
import { moduleforcavendameta } from '@/api/m0005_forcaVendaMeta/moduleforcavendameta';

import HeaderMain from "@/app/components/divs/headerMain";
import ButtonPag from "@/app/components/Buttons/button";

interface ModalMetaFabricanteVendedorProps {
  isOpen: boolean;
  onClose: () => void;
  fv_fab_meta_cd: number | null;
}

export default function ModalMetaFabricanteVendedor({ 
  isOpen, 
  onClose, 
  fv_fab_meta_cd 
}: ModalMetaFabricanteVendedorProps) {
  
  const { user } = useAuth();
  const [ActionStatus, setActionStatus] = useState<number>(0);
  const [loading, setLoading] = useState(false);
  const [seqinterface, setSeqinterface] = useState<string>('0');
  const [listResultadoVendedor, setListResultadoVendedor] = useState<any[]>([]);
  const [metaDescricao, setMetaDescricao] = useState<string>('');
  
  const myModuleForcaVendaMeta = new moduleforcavendameta(user, __SIS_AC_CD);

  const interfaceOptions = [
    { value: '0', label: 'DADOS OXAN' },
    { value: '1', label: 'DADOS JOHNSON' }
  ];

  useEffect(() => {
    if (isOpen && fv_fab_meta_cd) {
      carregarMetaDescricao();
      consultarResultadoVendedor();
    }
  }, [isOpen, fv_fab_meta_cd, seqinterface]);

  const carregarMetaDescricao = async () => {
    if (!fv_fab_meta_cd) return;
    
    try {
      const result = await myModuleForcaVendaMeta.fabricante.getListMetaFabricante({ competencia_cd: 202610 });
      const meta = result.find((item: any) => item.fv_fab_meta_cd === fv_fab_meta_cd);
      if (meta) {
        setMetaDescricao(meta.fv_fab_meta_descricao || `Meta ${fv_fab_meta_cd}`);
      }
    } catch (error) {
      console.error('Erro ao buscar descrição da meta:', error);
      setMetaDescricao(`Meta ${fv_fab_meta_cd}`);
    }
  };

  const consultarResultadoVendedor = async () => {
    if (!fv_fab_meta_cd) return;
    
    setLoading(true);
    setActionStatus(1);
    
    try {
      const result = await myModuleForcaVendaMeta.fabricante.getListMetaFabricanteResultadoVendedor({
        fv_fab_meta_cd: fv_fab_meta_cd,
        seqinterface: parseInt(seqinterface)
      });
      setListResultadoVendedor(result);
      setActionStatus(0);
    } catch (error) {
      console.error('Erro ao buscar resultado vendedor:', error);
      setListResultadoVendedor([]);
      setActionStatus(0);
    } finally {
      setLoading(false);
    }
  };

  if (!isOpen) return null;

  return (
    <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50">
      <div className="bg-white rounded-lg shadow-xl max-w-5xl w-full mx-4 max-h-[90vh] flex flex-col">
        
        {/* Header */}
        <HeaderMain 
          tipo={"_MODAL"} 
          ActionStatus={ActionStatus} 
          header_title={metaDescricao || "Resultado por Vendedor"}
        >
          <button 
            onClick={onClose} 
            className="text-white hover:text-gray-200 text-2xl font-bold"
          >
            ×
          </button>
        </HeaderMain>

        {/* Content */}
        <div className="flex-1 overflow-y-auto px-6 py-6">
          
          {/* Filtros */}
          <div className="bg-gray-50 p-4 rounded-lg mb-4">
            <div className="grid grid-cols-1 gap-4">
              <div>
                <label className="block text-xs font-medium text-gray-600 mb-2">
                  Fonte de Dados
                </label>
                <select
                  value={seqinterface}
                  onChange={(e) => setSeqinterface(e.target.value)}
                  className="w-full px-3 py-2 border border-gray-300 rounded-md text-black focus:outline-none focus:ring-2 focus:ring-blue-500"
                >
                  {interfaceOptions.map((option) => (
                    <option key={option.value} value={option.value}>
                      {option.label}
                    </option>
                  ))}
                </select>
              </div>
            </div>
          </div>

          {/* Botão Pesquisar */}
          <div className="mb-4 flex justify-end">
            <ButtonPag
              TypeButton="_BUTTON_HEADER"
              label="Pesquisar"
              TypeIcon="_NO_ICON"
              title="Pesquisar dados"
              onClick={consultarResultadoVendedor}
            />
          </div>

          {/* Loading */}
          {loading && (
            <div className="flex items-center justify-center py-8">
              <div className="animate-spin rounded-full h-8 w-8 border-b-2 border-purple-600"></div>
              <span className="ml-2 text-gray-600">Carregando dados...</span>
            </div>
          )}

          {/* Tabela de Resultados */}
          {!loading && (
            <div className="overflow-hidden rounded-lg border border-gray-200">
              <table className="min-w-full divide-y divide-gray-200 text-xs">
                <thead className="bg-gray-50 text-left text-xs font-semibold uppercase text-gray-600">
                  <tr>
                    <th className="px-3 py-2">Código Meta</th>
                    <th className="px-3 py-2">Fonte</th>
                    <th className="px-3 py-2">Vendedor</th>
                    <th className="px-3 py-2 text-right">MIX 02</th>
                    <th className="px-3 py-2 text-right">MIX 07</th>
                    <th className="px-3 py-2 text-right">MIX 17</th>
                    <th className="px-3 py-2 text-right">MIX 28</th>
                  </tr>
                </thead>
                <tbody className="divide-y divide-gray-100 text-gray-800">
                  {listResultadoVendedor.length > 0 ? (
                    listResultadoVendedor.map((item, index) => (
                      <tr key={index} className="hover:bg-gray-50">
                        <td className="px-3 py-1 font-medium">{item.fv_fab_meta_cd}</td>
                        <td className="px-3 py-1">
                          {item.seqinterface === 0 ? 'DADOS OXAN' : 'DADOS JOHNSON'}
                        </td>
                        <td className="px-3 py-1">{item.nome_razao} | Cod. ({item.cdparticipantevendedor})</td>
                        <td className="px-3 py-1 text-right">
                          {user.formatNumber(item.mix02 || 0, 2)}
                        </td>
                        <td className="px-3 py-1 text-right">
                          {user.formatNumber(item.mix07 || 0, 2)}
                        </td>
                        <td className="px-3 py-1 text-right">
                          {user.formatNumber(item.mix17 || 0, 2)}
                        </td>
                        <td className="px-3 py-1 text-right">
                          {user.formatNumber(item.mix28 || 0, 2)}
                        </td>
                      </tr>
                    ))
                  ) : (
                    <tr>
                      <td colSpan={7} className="px-3 py-4 text-center text-gray-500">
                        Nenhum dado encontrado.
                      </td>
                    </tr>
                  )}
                </tbody>
              </table>
            </div>
          )}
        </div>

        {/* Footer */}
        <div className="border-t border-gray-200 px-6 py-4 flex justify-end">
          <ButtonPag
            TypeButton="_BUTTON_INFO"
            label="Fechar"
            TypeIcon="_NO_ICON"
            title="Fechar modal"
            onClick={onClose}
          />
        </div>
      </div>
    </div>
  );
}