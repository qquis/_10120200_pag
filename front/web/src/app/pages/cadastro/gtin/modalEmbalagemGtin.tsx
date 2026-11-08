'use client'

import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";
import { moduleProduto } from '@/api/m0020_produto/moduleproduto';
import HeaderMain from "@/app/components/divs/headerMain";




// Novo componente para o modal de código de barras
interface CodigoBarraModalProps {
  isOpen: boolean;
  onClose: (status: boolean, gtin: string) => void;
  gtin: string;
}

export default function gtinModal({ isOpen, onClose, gtin }: CodigoBarraModalProps) {
  const { user } = useAuth();

  const [embalagemGtinSelecionado, setEmbalagemGtinSelecionado] = useState<any>({});
  const [ActionStatus, setActionStatus] = useState<number>(0);

  let myModuleProduto = new moduleProduto(user!);

  useEffect(() => { 
    if (isOpen && gtin) {
        ConsultarDadosGtinBasePag();
    }

  }, [isOpen, gtin])

  const ConsultarDadosGtinBasePag = async () => {
    try {
      setActionStatus(1); // Carregando
      let embalagemGtinConsultado = await myModuleProduto.getEmbalagemGtin(gtin);
      setEmbalagemGtinSelecionado(embalagemGtinConsultado);
      setActionStatus(0); // Carregado
    } catch (e) {
      console.log(`Erro ao consultar GTIN na Zanthus: ${e}`);
    }
  };

  if (!isOpen) return null;

  return (
    <div className="fixed inset-0 bg-black bg-opacity-75 flex items-center justify-center z-[9999]">
      <div className="bg-white rounded-lg shadow-xl max-w-4xl w-full mx-4 max-h-[80vh] flex flex-col">
        {/* Header - FIXO */}
           <HeaderMain tipo={"_MODAL"} ActionStatus={ActionStatus} header_title="Produto - Listagem Básica (Base unitária - PAG)" >
             <div className="flex space-x-2">
                 <button onClick={() => onClose(false, '0')} className="text-white hover:text-gray-200 text-2xl font-bold" > × </button>
             </div>              
           </HeaderMain>

        {/* Content Container */}
        <div className="flex flex-col flex-1 min-h-0">
          {/* Loading State */}
          {ActionStatus === 1 ? (
            <div className="flex-1 flex items-center justify-center p-6">
              <div className="text-center">
                <div className="animate-spin rounded-full h-12 w-12 border-b-2 border-purple-600 mx-auto mb-4"></div>
                <p className="text-gray-600 text-lg font-medium">Consultando dados do GTIN...</p>
                <p className="text-gray-400 text-sm mt-2">Aguarde, estamos buscando as informações na base PAG</p>
              </div>
            </div>
          ) : (
            /* 1. Informações do GTIN - FIXO */
            <div className="p-6 pb-0 flex-shrink-0">
              <div className="border border-gray-200 rounded-lg p-4">
                <h3 className="text-lg font-semibold text-white mb-4 pb-2 px-3 py-2 bg-slate-400 rounded-t-lg -mx-4 -mt-4">
                  Informações do GTIN (BASE PAG)
                </h3>
                <div className="grid grid-cols-1 md:grid-cols-2 gap-4 mt-4">
                  <div>
                    <label className="block text-sm font-medium text-gray-600 mb-1">Código Bluesoft:</label>
                    <p className="text-gray-800 font-medium bg-gray-50 p-2 rounded border">
                      {embalagemGtinSelecionado.prb_cdprodutobluesoft}
                    </p>
                  </div>
                  <div>
                    <label className="block text-sm font-medium text-gray-600 mb-1">GTIN/Código de Barras:</label>
                    <p className="text-gray-800 font-medium bg-gray-50 p-2 rounded border text-lg">
                      {embalagemGtinSelecionado.preg_cdbarra}
                    </p>
                  </div>
                  <div>
                    <label className="block text-sm font-medium text-gray-600 mb-1">Embalagem:</label>
                    <p className="text-gray-800 bg-gray-50 p-2 rounded border">
                      {embalagemGtinSelecionado.pre_embalagem}
                    </p>
                  </div>
                  <div>
                    <label className="block text-sm font-medium text-gray-600 mb-1">Descrição da Embalagem (Tab Blue):</label>
                    <p className="text-gray-800 bg-gray-50 p-2 rounded border">
                      {embalagemGtinSelecionado.prbg_embalagemdescricao}
                    </p>
                  </div>
                </div>
                
                <div className="mt-4 bg-blue-50 p-3 rounded-lg border-l-4 border-blue-500">
                  <div className="flex items-center">
                    <div className="flex-shrink-0">
                      <svg className="w-4 h-4 text-blue-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
                      </svg>
                    </div>
                    <div className="ml-2">
                      <p className="text-sm text-blue-700">
                        Este código de barras está vinculado à embalagem <strong>{embalagemGtinSelecionado.pre_embalagem}</strong>
                      </p>
                    </div>
                  </div>
                </div>
              </div>

              







                <div className="border border-gray-200 rounded-lg p-4">
                <h3 className="text-lg font-semibold text-white mb-4 pb-2 px-3 py-2 bg-slate-400 rounded-t-lg -mx-4 -mt-4">
                  Base de Tributação PAG/ZANTHUS - NFCE (tbzanthus_tributacao_nfce)
                </h3>
                <div className="grid grid-cols-1 md:grid-cols-2 gap-4 mt-4">
                  <div>
                    <label className="block text-sm font-medium text-gray-600 mb-1">NCM</label>
                    <p className="text-gray-800 font-medium bg-gray-50 p-2 rounded border">
                      {embalagemGtinSelecionado.ncm_codigo}
                    </p>
                  </div>
                  <div>
                    <label className="block text-sm font-medium text-gray-600 mb-1">CEST</label>
                    <p className="text-gray-800 font-medium bg-gray-50 p-2 rounded border text-lg">
                      {embalagemGtinSelecionado.cest}
                    </p>
                  </div>
                  <div>
                    <label className="block text-sm font-medium text-gray-600 mb-1">PIS:</label>
                    <p className="text-gray-800 bg-gray-50 p-2 rounded border">
                      {embalagemGtinSelecionado.pis_cst}
                    </p>
                  </div>
                  <div>
                    <label className="block text-sm font-medium text-gray-600 mb-1">PIS Aliquota:</label>
                    <p className="text-gray-800 bg-gray-50 p-2 rounded border">
                      {embalagemGtinSelecionado.pis_aliquota}
                    </p>
                  </div>       
                  <div>
                    <label className="block text-sm font-medium text-gray-600 mb-1">COFINS:</label>
                    <p className="text-gray-800 bg-gray-50 p-2 rounded border">
                      {embalagemGtinSelecionado.cofins_cst}
                    </p>
                  </div>
                  <div>
                    <label className="block text-sm font-medium text-gray-600 mb-1">COFINS Aliquota:</label>
                    <p className="text-gray-800 bg-gray-50 p-2 rounded border">
                      {embalagemGtinSelecionado.cofins_aliquota}
                    </p>
                  </div>       

                  <div>
                    <label className="block text-sm font-medium text-gray-600 mb-1">ICMS CST:</label>
                    <p className="text-gray-800 bg-gray-50 p-2 rounded border">
                      {embalagemGtinSelecionado.icms_cst}
                    </p>
                  </div>                  

                  <div>
                    <label className="block text-sm font-medium text-gray-600 mb-1">ICMS Aliquota:</label>
                    <p className="text-gray-800 bg-gray-50 p-2 rounded border">
                      {embalagemGtinSelecionado.icms_aliquota}
                    </p>
                  </div>      


                  <div>
                    <label className="block text-sm font-medium text-gray-600 mb-1">ICMS Redução:</label>
                    <p className="text-gray-800 bg-gray-50 p-2 rounded border">
                      {embalagemGtinSelecionado.icms_reducao}
                    </p>
                  </div> 


                  <div>
                    <label className="block text-sm font-medium text-gray-600 mb-1">ICMS Aliquota FInal:</label>
                    <p className="text-gray-800 bg-gray-50 p-2 rounded border">
                      {embalagemGtinSelecionado.icms_aliquota_final}
                    </p>
                  </div> 

                </div>
                
                <div className="mt-4 bg-blue-50 p-3 rounded-lg border-l-4 border-blue-500">
                  <div className="flex items-center">
                    <div className="flex-shrink-0">
                      <svg className="w-4 h-4 text-blue-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
                      </svg>
                    </div>
                    <div className="ml-2">
                      <p className="text-sm text-blue-700">
                        Este código de barras está vinculado à embalagem <strong>{embalagemGtinSelecionado.pre_embalagem}</strong>
                      </p>
                    </div>
                  </div>
                </div>
              </div>
            </div>


      )}
        </div>

        {/* Footer - FIXO */}
        <div className="bg-gray-50 px-6 py-4 rounded-b-lg flex justify-end flex-shrink-0">
          <button
            onClick={() => onClose(false, '0')}
            className="bg-blue-500 hover:bg-blue-600 text-white px-4 py-2 rounded-md transition-colors"
          >
            Fechar
          </button>
        </div>
      </div>
    </div>
  );
}