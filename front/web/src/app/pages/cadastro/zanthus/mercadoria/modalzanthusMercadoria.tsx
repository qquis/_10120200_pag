'use client'

import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";
//import { moduleProduto, TpProduto } from '@/api/m0020_produto/moduleproduto';
import { moduleZanthus } from '@/api/external/zanthus';

import ComponenteZanthusTabMercadoria from '../componentes/componenteZanthusTabMercadoria';
import ComponenteTabRegrasICMS from '../componentes/componenteZanthusTabRegrasICMS';
import ComponenteTabTipoVenda from '../componentes/componenteZanthusTabTipoVenda';
import ComponenteMercadoriaVoucher from '../componentes/componenteZanthusMercadoriaVoucher';
import ComponenteZanthusComposicao from '../componentes/componenteZanthusComposicao';

import HeaderMain from "@/app/components/divs/headerMain";

// Novo componente para o modal de código de barras
interface CodigoBarraModalProps {
  isOpen: boolean;
  onClose: (status: boolean, gtin: string) => void;
  gtin: string;
}

export default function modalzanthusMercadoria({ isOpen, onClose, gtin }: CodigoBarraModalProps) {
  const { user } = useAuth();
  const [infoExternalZanthusMercadoria, setInfoExternalZanthusMercadoria] = useState<any>(null);
  const [ActionStatus, setActionStatus] = useState<number>(0);

  let moduleExternalZanthus = new moduleZanthus(user!);

  useEffect(() => { 
    if (isOpen && gtin) {
        consultarGtinZanthus();
    }

  }, [isOpen, gtin])

  const consultarGtinZanthus = async () => {
    try {
      setActionStatus(1); // Carregando
      let mercadoriaInfo = await moduleExternalZanthus.getInfoAllMercadoria(gtin);
      setInfoExternalZanthusMercadoria(mercadoriaInfo);
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

          <HeaderMain tipo={"_MODAL"} ActionStatus={ActionStatus} header_title={`Dados na Base de Dados ZANTHUS do GTIN: ${gtin}`} >
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
                <p className="text-gray-600 text-lg font-medium">Consultando dados na base Zanthus...</p>
                <p className="text-gray-400 text-sm mt-2">Aguarde, estamos buscando as informações completas do GTIN {gtin}</p>
              </div>
            </div>
          ) : (
            /* 2. Informações BASE ZANTHUS - ROLÁVEL */
            <div className="px-6 pb-6 pt-6 flex-1 overflow-y-auto">

                
                {/* 2.1 Mercadoria */}
                <div className="mb-6 mt-4">
                <h3 className="text-lg font-semibold text-white mb-4 pb-2 px-3 py-2 bg-slate-400 rounded-t-lg -mx-4 -mt-4">Mercadoria</h3>
                  <ComponenteZanthusTabMercadoria infoExternalZanthusMercadoria={infoExternalZanthusMercadoria} />
                </div>
                {/* 2.2 Regra ICMS */}
                <div className="mb-6">
                  <h3 className="text-lg font-semibold text-white mb-4 pb-2 px-3 py-2 bg-slate-400 rounded-t-lg -mx-4 -mt-4">Regras Fiscais (tab_regras_icms)</h3>
                  <ComponenteTabRegrasICMS listregraICMS={infoExternalZanthusMercadoria?.regrasIcms || []} />

                </div>            

                {/* 2.3 Preço */}
                <div className="mb-6">
                  <h3 className="text-lg font-semibold text-white mb-4 pb-2 px-3 py-2 bg-slate-400 rounded-t-lg -mx-4 -mt-4">Preço</h3>
                  <ComponenteTabTipoVenda listTipoVenda={infoExternalZanthusMercadoria?.tipoVenda || []} />
                </div>

                {/* 2.4 Voucher */}
                <div className="mb-6">
                  <h3 className="text-lg font-semibold text-white mb-4 pb-2 px-3 py-2 bg-slate-400 rounded-t-lg -mx-4 -mt-4">Voucher</h3>
                  <ComponenteMercadoriaVoucher listVouchers={infoExternalZanthusMercadoria?.voucherList || []} />
                </div>

                {/* 2.5 Insumos */}
                <div className="mb-6">
                                  <h3 className="text-lg font-semibold text-white mb-4 pb-2 px-3 py-2 bg-slate-400 rounded-t-lg -mx-4 -mt-4">Composição e Insumos</h3>
                  <ComponenteZanthusComposicao composicao={infoExternalZanthusMercadoria?.composicao || {}} />

                </div>

            </div>
          )}
        </div>

        {/* Footer - FIXO */}
        <div className="bg-gray-50 px-6 py-4 rounded-b-lg flex justify-end flex-shrink-0">
          <button
            onClick={() => onClose(false, "0")}
            className="bg-blue-500 hover:bg-blue-600 text-white px-4 py-2 rounded-md transition-colors"
          >
            Fechar
          </button>
        </div>
      </div>
    </div>
  );
}