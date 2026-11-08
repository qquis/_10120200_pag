'use client'

import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";
import { moduleProduto, TpProduto } from '@/api/m0020_produto/moduleproduto';

import HeaderMain from "@/app/components/divs/headerMain";

import gtinModal from '@/app/pages/cadastro/gtin/modalEmbalagemGtin';
import modalzanthusMercadoria from '../../zanthus/mercadoria/modalzanthusMercadoria';

interface ProdutoModalProps {
  isOpen: boolean;
  onClose: () => void;
  produtoId: number | null;
}

export default function ProdutoModal({ isOpen, onClose, produtoId }: ProdutoModalProps) {
  const { user } = useAuth();
  const [produto, setProduto] = useState<any | null>(null);
  const [embalagens, setEmbalagens] = useState<any[]>([]);
  const [gtins, setGtins] = useState<any[]>([]);
  const [precoLoja, setPrecoLoja] = useState<any[]>([]);
  const [composicao, setComposicao] = useState<any[]>([]);
  const [loading, setLoading] = useState(false);

  const GtinModal = gtinModal;
  const ZanthusModal = modalzanthusMercadoria;


  const [ActionStatus, setActionStatus] = useState<number>(0);
  const [gtinBasePagModalOPEN, setGtinBasePagModalOPEN] = useState(false);
  const [gtinBaseZanthusModalOPEN, setGtinBaseZanthusModalOPEN] = useState(false);
  const [gtinSelecionado, setGtinSelecionado] = useState<string>('0');  





  useEffect(() => {
    if (isOpen && produtoId) {
      consultarProduto();

    }
  }, [isOpen, produtoId]);

  const consultarProduto = async () => {
    if (!produtoId) return;
    
    setLoading(true);
    setActionStatus(1); // Carregando
    try {
      const myModuleProduto = new moduleProduto(user);
      const produtoData = await myModuleProduto.getProduto(produtoId);
      setProduto(produtoData);

      if (produtoData && produtoData.embalagens) {
          setEmbalagens(produtoData.embalagens);
        } else {
          setEmbalagens([]);
        }
      if (produtoData && produtoData.embalagensGtins) {
          setGtins(produtoData.embalagensGtins);
        } else {
          setGtins([]);  
      }
      if (produtoData && produtoData.precoLoja) {
          setPrecoLoja(produtoData.precoLoja);
        } else {
          setPrecoLoja([]);
      }
      if (produtoData && produtoData.composicao) {
          setComposicao(produtoData.composicao);
        } else {
          setComposicao([]);
      }
      setActionStatus(0); // Carregando

    } catch (error) {
      console.error('Erro ao consultar produto:', error);
    } finally {
      setLoading(false);
    }
  };

    // Função para abrir o modal de gtin base pag
  const MODALBasePagGtin = (status: boolean, gtin: any) => {
    if (status) { 
      setGtinSelecionado(gtin);
      setGtinBasePagModalOPEN(status);
    } else {
      setGtinBasePagModalOPEN(status);
    }
  };


    // Função para abrir o modal de zanthus
  const MODALZanthusGtin = (status: boolean, gtin: string) => {
    if (status) {
      setGtinSelecionado(gtin);
      setGtinBaseZanthusModalOPEN(status); 
    } else { 
      setGtinBaseZanthusModalOPEN(status);
    }
  };







  if (!isOpen) return null;

  return (
    <>
      {/* Modal Principal do Produto */}
      <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50">
        <div className="bg-white rounded-lg shadow-xl max-w-6xl w-full mx-4 max-h-[90vh] flex flex-col">
          {/* Header - Fixo */}

           <HeaderMain tipo={"_MODAL"} ActionStatus={ActionStatus} header_title="Produto - Listagem Básica (Base unitária - PAG)" >
             <div className="flex space-x-2">
                 <button onClick={onClose} className="text-white hover:text-gray-200 text-2xl font-bold" > × </button>
             </div>              
           </HeaderMain>



          {/* Loading ou conteúdo */}
          {loading ? (
            <div className="flex items-center justify-center py-8 flex-1">
              <div className="animate-spin rounded-full h-8 w-8 border-b-2 border-purple-600"></div>
              <span className="ml-2 text-gray-600">Carregando produto...</span>
            </div>
          ) : produto ? (
            <>
              {/* Descrição - Fixa */}
              <div className="flex-shrink-0 p-6 pb-0">
                <div className="bg-gradient-to-r from-purple-50 to-blue-50 border-l-4 border-purple-500 p-6 rounded-lg shadow-sm">
                  <div className="flex items-start space-x-4">
                    <div className="flex-shrink-0">
                      <div className="w-12 h-12 bg-purple-100 rounded-full flex items-center justify-center">
                        <svg className="w-6 h-6 text-purple-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                          <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M20 7l-8-4-8 4m16 0l-8 4m8-4v10l-8 4m0-10L4 7m8 4v10M4 7v10l8 4" />
                        </svg>
                      </div>
                    </div>
                    <div className="flex-1">
                      <h3 className="text-sm font-medium text-purple-600 uppercase tracking-wide mb-1">
                        Descrição 
                      </h3>
                      <p className="text-xl font-semibold text-gray-900 leading-relaxed">
                        {produto.pr_descricao}
                      </p>
                    </div>
                  </div>
                </div>
              </div>

              {/* Conteúdo com scroll - Flexível */}
              <div className="flex-1 overflow-y-auto px-6 pb-6">
                <div className="space-y-6 pt-6">
                  {/* Informações básicas com grid */}
                  <div className="bg-gray-50 p-4 rounded-lg">
                    <div className="grid grid-cols-10 gap-2 mb-1 ">
                      <div className="col-span-1">
                        <label className="block text-xs font-medium text-gray-600 text-left">Cd Pag</label>
                      </div>
                      <div className="col-span-1">
                        <label className="block text-xs font-medium text-gray-600 text-left">Cd Blue Unit</label>
                      </div>
                      <div className="col-span-2">
                        <label className="block text-xs font-medium text-gray-600 text-left">Status Pag</label>
                      </div>
                      <div className="col-span-2">
                        <label className="block text-xs font-medium text-gray-600 text-left">Venda Externa</label>
                      </div>
                      <div className="col-span-1">
                        <label className="block text-xs font-medium text-gray-600 text-left">Emb Unit</label>
                      </div>                  
                      <div className="col-span-1">
                        <label className="block text-xs font-medium text-gray-600 text-left">Emb Cmp</label>
                      </div>                                    
                      <div className="col-span-1">
                        <label className="block text-xs font-medium text-gray-600 text-left">Emb F</label>
                      </div>                                                      
                    </div>
                    
                    {/* Dados em outra linha */}
                    <div className="grid grid-cols-10 gap-2">
                      <div className="col-span-1">
                        <p className="text-sm text-gray-800 text-right font-medium">{produto.pr_cdproduto}</p>
                      </div>
                      <div className="col-span-1">
                        <p className="text-sm text-gray-800 text-right font-medium">{produto.prb_cdprodutobluesoft}</p>
                      </div>
                      <div className="col-span-2 flex justify-center">
                        <span className={`inline-flex px-2 py-1 rounded-full text-xs font-medium ${
                          produto.pr_status === 1 ? 'bg-green-100 text-green-800' : 'bg-red-100 text-red-800'
                        }`}>
                          {produto.pr_status === 1 ? 'Ativo' : 'Inativo'}
                        </span>
                      </div>
                      <div className="col-span-2 flex justify-center">
                        <span className={`inline-flex px-2 py-1 rounded-full text-xs font-medium ${
                          produto.prb_vendaexterna === 1 ? 'bg-blue-100 text-blue-800' : 'bg-gray-100 text-gray-800'
                        }`}>
                          {produto.prb_vendaexterna === 1 ? 'Sim' : 'Não'}
                        </span>
                      </div>
                      <div className="col-span-1">
                        <p className="text-sm text-gray-800 truncate">{produto.pr_embalagemestoque}</p>
                      </div>
                      <div className="col-span-1">
                        <p className="text-sm text-gray-800 truncate">{produto.pr_embalagemcompra}</p>
                      </div>
                      <div className="col-span-1">
                        <p className="text-sm text-gray-800 truncate">{user.formatNumber(produto.pr_embalagemcompra_fator, 1)}</p>
                      </div>
                    </div>
                  </div>

                  {/* Grid de Embalagens */}
                  <div className="bg-gray-50 p-4 rounded-lg">
                    <h3 className="text-lg font-semibold text-gray-800 mb-4">
                      Embalagens do Produto - Base NFCE{' '}
                      <span className="text-xs font-normal">(tbfc_regrafiscal_nfce_produto padrão Consumidor PDV)</span>
                    </h3>
                    {embalagens.length > 0 ? (
                      <div className="overflow-x-auto">
                        <table className="min-w-full bg-white border border-gray-200 rounded-lg">
                          <thead className="bg-gray-100">
                            <tr>
                              <th className="px-4 py-2 text-left text-xs font-medium text-gray-600 tracking-wider border-b">
                                Cd Unit Pag
                              </th>
                              <th className="px-4 py-2 text-left text-xs font-medium text-gray-600 tracking-wider border-b">
                                Cd Bluesoft
                              </th>
                              <th className="px-4 py-2 text-left text-xs font-medium text-gray-600 tracking-wider border-b">
                                Descrição da Embalagem
                              </th>
                              <th className="px-4 py-2 text-left text-xs font-medium text-gray-600 tracking-wider border-b">
                                Emb
                              </th>                          
                              <th className="px-4 py-2 text-right text-xs font-medium text-gray-600 tracking-wider border-b">
                                F. Preço
                              </th>
                              <th className="px-4 py-2 text-right text-xs font-medium text-gray-600 tracking-wider border-b">
                                F. Estoque
                              </th>
                              <th className="px-4 py-2 text-right text-xs font-medium text-gray-600 tracking-wider border-b">
                                Dt Up Pag
                              </th>  
                              <th className="px-4 py-2 text-right text-xs font-medium text-gray-600 tracking-wider border-b">
                                Dt Up Blue
                              </th> 
                              <th className="px-4 py-2 text-right text-xs font-medium text-gray-600 tracking-wider border-b">
                                Dt Up Blue Api
                              </th>  
                              <th className="px-4 py-2 text-right text-xs font-medium text-gray-600 tracking-wider border-b">
                                Icms
                              </th>
                              <th className="px-4 py-2 text-right text-xs font-medium text-gray-600 tracking-wider border-b">
                                Icms Aliq
                              </th>      
                              <th className="px-4 py-2 text-right text-xs font-medium text-gray-600 tracking-wider border-b">
                                Icms Red
                              </th>     
                              <th className="px-4 py-2 text-right text-xs font-medium text-gray-600 tracking-wider border-b">
                                Pis
                              </th>
                              <th className="px-4 py-2 text-right text-xs font-medium text-gray-600 tracking-wider border-b">
                                PIS Aliq
                              </th> 
                              <th className="px-4 py-2 text-right text-xs font-medium text-gray-600 tracking-wider border-b">
                                Cofins
                              </th>
                              <th className="px-4 py-2 text-right text-xs font-medium text-gray-600 tracking-wider border-b">
                                COFINS Aliq
                              </th> 
                              <th className="px-4 py-2 text-right text-xs font-medium text-gray-600 tracking-wider border-b">
                                Dt Up NFCE
                              </th>                                                                                                                                                                                                                                                 
                            </tr>
                          </thead>
                          <tbody className="divide-y divide-gray-200">
                            {embalagens.map((embalagem: any, index) => (
                              <tr key={index} className="hover:bg-gray-50">
                                <td className="px-4 py-2 text-sm text-gray-800 border-b">
                                  {embalagem.pr_cdproduto}
                                </td>
                                <td className="px-4 py-2 text-sm text-gray-800 border-b">
                                  {embalagem.prb_cdprodutobluesoft}
                                </td>
                                <td className="px-4 py-2 text-sm text-gray-800 border-b">
                                  {embalagem.pre_embalagem_descricao}
                                </td>                            

                                <td className="px-4 py-2 text-sm text-gray-800 border-b">
                                  {embalagem.pre_embalagem}
                                </td>                            
                                <td className="px-4 py-2 text-sm text-gray-800 text-right border-b">
                                  {user.formatNumber(embalagem.pre_fatorpreco, 4)}
                                </td>
                                <td className="px-4 py-2 text-sm text-gray-800 text-right border-b">
                                  {user.formatNumber(embalagem.pre_fatorestoque, 4)}
                                </td>
                                <td className="px-4 py-2 text-sm text-gray-800 text-right border-b">
                                  {embalagem.dtlog_update ? new Date(embalagem.dtlog_update).toLocaleDateString() : 'N/A'}
                                </td>        
                                <td className="px-4 py-2 text-sm text-gray-800 text-right border-b">
                                  {embalagem.pb_dtlog_update ? new Date(embalagem.pb_dtlog_update).toLocaleDateString() : 'N/A'}
                                </td>   
                                <td className="px-4 py-2 text-sm text-gray-800 text-right border-b">
                                  {embalagem.prb_dtupdate_from_api ? new Date(embalagem.prb_dtupdate_from_api).toLocaleDateString() : 'N/A'}
                                </td>            
                                <td className="px-4 py-2 text-sm text-gray-800 border-b">
                                  {embalagem.icms_codigo_tributacao}
                                </td>   

                                <td className="px-4 py-2 text-sm text-gray-800 text-right border-b">
                                  {user.formatNumber(embalagem.icms_aliquota, 2)}
                                </td>  
                                <td className="px-4 py-2 text-sm text-gray-800 text-right border-b">
                                  {user.formatNumber(embalagem.icms_reducao, 2)}
                                </td> 

                                <td className="px-4 py-2 text-sm text-gray-800 border-b">
                                  {embalagem.pis_cst}
                                </td> 
                                <td className="px-4 py-2 text-sm text-gray-800 text-right border-b">
                                  {user.formatNumber(embalagem.pis_aliquota, 2)}
                                </td>      

                                <td className="px-4 py-2 text-sm text-gray-800 border-b">
                                  {embalagem.cofins_cst}
                                </td> 
                                <td className="px-4 py-2 text-sm text-gray-800 text-right border-b">
                                  {user.formatNumber(embalagem.cofins_aliquota, 2)}
                                </td>   
                                <td className="px-4 py-2 text-sm text-gray-800 text-right border-b">
                                  {embalagem.prb_dtupdate_from_api ? new Date(embalagem.dtlog_update_nfce).toLocaleString('pt-BR', {
                                    day: '2-digit',
                                    month: '2-digit',
                                    year: 'numeric',
                                    hour: '2-digit',
                                    minute: '2-digit',
                                    second: '2-digit'
                                  }) : 'N/A'}
                                </td>                                                                                                                                                                               
                              </tr>
                            ))}
                          </tbody>
                        </table>
                      </div>
                    ) : (
                      <div className="text-center py-4">
                        <p className="text-sm text-gray-600">Nenhuma embalagem encontrada para este produto.</p>
                      </div>
                    )}
                  </div>
                  {/* Grid de Embalagens */}
                  <div className="bg-gray-50 p-4 rounded-lg">
                    <h3 className="text-lg font-semibold text-gray-800 mb-4">Gtins - Base PAG</h3>
                    {gtins.length > 0 ? (
                      <div className="overflow-x-auto">
                        <table className="min-w-full bg-white border border-gray-200 rounded-lg">
                          <thead className="bg-gray-100">
                            <tr>
                              <th className="px-4 py-2 text-left text-xs font-medium text-gray-600 tracking-wider border-b">
                                Cd Bluesoft
                              </th>
                              <th className="px-4 py-2 text-left text-xs font-medium text-gray-600 tracking-wider border-b">
                                Descrição da Embalagem
                              </th>
                              <th className="px-4 py-2 text-left text-xs font-medium text-gray-600 tracking-wider border-b">
                                Emb
                              </th>                          
                              <th className="px-4 py-2 text-right text-xs font-medium text-gray-600 tracking-wider border-b">
                                Gtin
                              </th>
                              <th className="px-4 py-2 text-center text-xs font-medium text-gray-600 tracking-wider border-b">
                                Detalhe
                              </th>
                            </tr>
                          </thead>
                          <tbody className="divide-y divide-gray-200">
                            {gtins.map((gtin, index) => (
                              <tr key={index} className="hover:bg-gray-50">
                                <td className="px-4 py-2 text-sm text-gray-800 border-b">
                                  {gtin.prb_cdprodutobluesoft}
                                </td>
                                <td className="px-4 py-2 text-sm text-gray-800 border-b">
                                  {gtin.pre_embalagem_descricao}
                                </td>  
                                <td className="px-4 py-2 text-sm text-gray-800 border-b">
                                  {gtin.pre_embalagem}
                                </td>
                                <td className="px-4 py-2 text-sm text-gray-800 border-b text-right">
                                  {gtin.preg_cdbarra}
                                </td>                            
                                <td className="px-4 py-2 text-sm border-b text-center">
                                  <button
                                    onClick={() => MODALBasePagGtin(true,gtin.preg_cdbarra)}
                                    className="bg-blue-500 hover:bg-blue-600 text-white px-3 py-1 rounded text-xs transition-colors"
                                    title="Ver detalhes do código de barras"
                                  >
                                    Pag
                                  </button>

                                  <button
                                    onClick={() => MODALZanthusGtin(true,gtin.preg_cdbarra)}
                                    className="bg-blue-500 hover:bg-blue-600 text-white px-3 py-1 rounded text-xs transition-colors"
                                    title="Ver detalhes do código de barras"
                                  >
                                    Zanthus
                                  </button>
                                </td>                                
                              </tr>
                            ))}
                          </tbody>
                        </table>
                      </div>
                    ) : (
                      <div className="text-center py-4">
                        <p className="text-sm text-gray-600">Nenhum GTIN encontrado para este produto.</p>
                      </div>
                    )}
                  </div>
                  {/* Outras Informações */}
                  <div className="bg-gray-50 p-4 rounded-lg">
                    <h3 className="text-lg font-semibold text-gray-800 mb-4">Informações Fiscais (Base Pag Integrada)</h3>
                    <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                      <div>
                        <label className="block text-sm font-medium text-gray-600">Figura Fiscal vinculada ao Código Unitário:</label>
                        <p className="text-gray-800">{produto.fc_figurafiscal_cd || 'N/A'}</p>
                      </div>                      
                      <div>
                        <label className="block text-sm font-medium text-gray-600">Figura Fiscal vinculada ao Código Unitário:</label>
                        <p className="text-gray-800">{produto.fc_figurafiscal_descricao || 'N/A'}</p>
                      </div>
                      <div>
                        <label className="block text-sm font-medium text-gray-600">Código Unitário possui NFCE:</label>
                        <p className="text-gray-800">{produto.regrafiscal_nfce  === 1 ? 'Sim' : 'Não'}</p>
                      </div>                      
                    </div>
                  </div>

                  {/* Lista de Preços */}
                  <div className="bg-gray-50 p-4 rounded-lg">
                    <h3 className="text-lg font-semibold text-gray-800 mb-4">Lista de Preços (PAG / LOJA)</h3>
                    {precoLoja.length > 0 ? (
                      <div className="overflow-x-auto">
                        <table className="min-w-full bg-white border border-gray-200 rounded-lg">
                          <thead className="bg-gray-100">
                            <tr>
                              <th className="px-4 py-2 text-left text-xs font-medium text-gray-600 tracking-wider border-b">
                                Tabela de Preço
                              </th>
                              <th className="px-4 py-2 text-left text-xs font-medium text-gray-600 tracking-wider border-b">
                                Cd Bluesoft
                              </th>
                              <th className="px-4 py-2 text-left text-xs font-medium text-gray-600 tracking-wider border-b">
                                Embalagem
                              </th>                          
                              <th className="px-4 py-2 text-right text-xs font-medium text-gray-600 tracking-wider border-b">
                                Valor
                              </th>
                            </tr>
                          </thead>
                          <tbody className="divide-y divide-gray-200">
                            {precoLoja.map((preco, index) => (
                              <tr key={index} className="hover:bg-gray-50">
                                <td className="px-4 py-2 text-sm text-gray-800 border-b">
                                  <span className="inline-flex px-2 py-1 text-xs font-semibold rounded-full bg-blue-100 text-blue-800">
                                    {preco.tab_pre_descricao}
                                  </span>
                                </td>
                                <td className="px-4 py-2 text-sm text-gray-800 border-b">
                                  {preco.prb_cdprodutobluesoft}
                                </td>
                                <td className="px-4 py-2 text-sm text-gray-800 border-b">
                                  <span className="inline-flex px-2 py-1 text-xs font-semibold rounded-full bg-green-100 text-green-800">
                                    {preco.pre_embalagem}
                                  </span>
                                </td>
                                <td className="px-4 py-2 text-sm text-gray-800 border-b text-right">
                                  <span className="font-semibold text-green-600">
                                    R$ {user.formatNumber(parseFloat(preco.prc_valor), 2)}
                                  </span>
                                </td>
                              </tr>
                            ))}
                          </tbody>
                        </table>
                      </div>
                    ) : (
                      <div className="text-center py-4">
                        <p className="text-sm text-gray-600">Nenhum preço encontrado para este produto.</p>
                      </div>
                    )}
                  </div>

                  {/* Composição do Produto (Cesta) */}
                  <div className="bg-gray-50 p-4 rounded-lg">
                    <h3 className="text-lg font-semibold text-gray-800 mb-4">Composição do Produto (Cesta)</h3>
                    {composicao.length > 0 ? (
                      <div className="overflow-x-auto">
                        <table className="min-w-full bg-white border border-gray-200 rounded-lg">
                          <thead className="bg-gray-100">
                            <tr>
                              <th className="px-3 py-2 text-left text-xs font-medium text-gray-600 tracking-wider border-b">
                                Cd Blue Unit
                              </th>
                              <th className="px-3 py-2 text-left text-xs font-medium text-gray-600 tracking-wider border-b">
                                Cd Bluesoft
                              </th>
                              <th className="px-3 py-2 text-left text-xs font-medium text-gray-600 tracking-wider border-b">
                                Descrição Produto
                              </th>
                              <th className="px-3 py-2 text-left text-xs font-medium text-gray-600 tracking-wider border-b">
                                Código de Barras
                              </th>
                              <th className="px-3 py-2 text-right text-xs font-medium text-gray-600 tracking-wider border-b">
                                Qtde
                              </th>
                              <th className="px-3 py-2 text-right text-xs font-medium text-gray-600 tracking-wider border-b">
                                % Comp
                              </th>
                              <th className="px-3 py-2 text-right text-xs font-medium text-gray-600 tracking-wider border-b">
                                % Qtde
                              </th>
                              <th className="px-3 py-2 text-center text-xs font-medium text-gray-600 tracking-wider border-b">
                                Fig Fiscal
                              </th>
                              <th className="px-3 py-2 text-center text-xs font-medium text-gray-600 tracking-wider border-b">
                                NFCE <span className="text-xs font-normal">(Padrão Consumidor PDV)</span>
                              </th>
                              <th className="px-3 py-2 text-center text-xs font-medium text-gray-600 tracking-wider border-b">
                                Consulta 
                              </th>                              
                            </tr>
                          </thead>
                          <tbody className="divide-y divide-gray-200">
                            {composicao.map((item, index) => (
                              <tr key={index} className="hover:bg-gray-50">
                                <td className="px-3 py-2 text-sm text-gray-800 border-b">
                                  <span className="inline-flex px-2 py-1 text-xs font-semibold rounded-full bg-blue-100 text-blue-800">
                                    {item.prb_cdprodutobluesoft_unitario}
                                  </span>
                                </td>
                                <td className="px-3 py-2 text-sm text-gray-800 border-b">
                                  <span className="inline-flex px-2 py-1 text-xs font-semibold rounded-full bg-purple-100 text-purple-800">
                                    {item.prb_cdprodutobluesoft}
                                  </span>
                                </td>
                                <td className="px-3 py-2 text-sm text-gray-800 border-b max-w-xs truncate" title={item.prb_descricao}>
                                  {item.prb_descricao}
                                </td>
                                <td className="px-3 py-2 text-sm text-gray-800 border-b">
                                  <span className="inline-flex px-2 py-1 text-xs font-medium rounded bg-yellow-100 text-yellow-800">
                                    {item.prb_cdbarra_principal?.trim()}
                                  </span>
                                </td>
                                <td className="px-3 py-2 text-sm text-gray-800 border-b text-right">
                                  <span className="font-semibold text-green-600">
                                    {user.formatNumber(parseFloat(item.prc_qtde), 4)}
                                  </span>
                                </td>
                                <td className="px-3 py-2 text-sm text-gray-800 border-b text-right">
                                  <span className="font-semibold text-orange-600">
                                    {user.formatNumber(parseFloat(item.prc_percentual_composicao), 4)}%
                                    
                                  </span>
                                </td>
                                <td className="px-3 py-2 text-sm text-gray-800 border-b text-right">
                                  <span className="font-semibold text-cyan-600">
                                    {user.formatNumber(parseFloat(item.prc_percentual_composicao_qtde), 4)}%
                                  </span>
                                </td>
                                <td className="px-3 py-2 text-sm text-gray-800 border-b text-center">
                                  {item.fc_figurafiscal_cd ? (
                                    <span className="inline-flex px-2 py-1 text-xs font-semibold rounded-full bg-indigo-100 text-indigo-800">
                                      {item.fc_figurafiscal_cd}
                                    </span>
                                  ) : (
                                    <span className="text-gray-400 text-xs">N/A</span>
                                  )}
                                </td>
                                <td className="px-3 py-2 text-sm border-b text-center">
                                  {item.regrafiscal_nfce !== null ? (
                                    <span className={`inline-flex px-2 py-1 text-xs font-medium rounded-full ${
                                      item.regrafiscal_nfce === 1 
                                        ? 'bg-green-100 text-green-800' 
                                        : 'bg-red-100 text-red-800'
                                    }`}>
                                      {item.regrafiscal_nfce === 1 ? 'Sim' : 'Não'}
                                    </span>
                                  ) : (
                                    <span className="text-gray-400 text-xs">N/A</span>
                                  )}
                                </td>
                                <td className="px-4 py-2 text-sm border-b text-center">

                                  <button
                                    onClick={() => MODALZanthusGtin(true, item.prb_cdbarra_principal?.trim())}
                                    className="bg-blue-500 hover:bg-blue-600 text-white px-3 py-1 rounded text-xs transition-colors"
                                    title="Ver detalhes do código de barras"
                                  >
                                    Zanthus
                                  </button>      
                                  </td>
                              </tr>



                            ))}
                          </tbody>
                        </table>
                        {/* Rodapé com totais */}
                        <div className="bg-gray-100 px-4 py-3 border-t">
                          <div className="flex justify-between text-sm font-medium text-gray-700">
                            <span>Total de itens: {composicao.length}</span>
                            <span>
                              Qtde total da composição: {composicao.length > 0 ? user.formatNumber(parseFloat(composicao[0].prc_composicao_qtde_total), 4) : '0'}
                            </span>
                          </div>
                        </div>
                      </div>
                    ) : (
                      <div className="text-center py-4">
                        <p className="text-sm text-gray-600">Este produto não possui composição (não é uma cesta).</p>
                      </div>
                    )}
                  </div>
                  

                    <div className="bg-gray-50 p-4 rounded-lg">
                    <h3 className="text-lg font-semibold text-gray-800 mb-4">Outras Informações</h3>
                    <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                      <div className="md:col-span-2">
                        <label className="block text-sm font-medium text-gray-600">Fornecedor:</label>
                        <p className="text-gray-800">{produto.fornecedor_nome_razao || 'N/A'}</p>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </>
          ) : (
            <div className="text-center py-8 flex-1 flex items-center justify-center">
              <p className="text-gray-600">Produto não encontrado.</p>
            </div>
          )}

          {/* Footer - Fixo */}
          <div className="bg-gray-50 px-6 py-4 rounded-b-lg flex justify-end flex-shrink-0">
            <button
              onClick={onClose}
              className="bg-gray-500 hover:bg-gray-600 text-white px-4 py-2 rounded-md transition-colors"
            >
              Fechar
            </button>
          </div>
        </div>
      </div>

      {/* Modal BASE PAG */}
      {gtinBasePagModalOPEN && (
        <GtinModal
          isOpen={gtinBasePagModalOPEN}
          onClose={MODALBasePagGtin}
          gtin={gtinSelecionado}
        />
      )}


      {/* Modal BASE ZANTHUS */}
      {gtinBaseZanthusModalOPEN && (
        <ZanthusModal
          isOpen={gtinBaseZanthusModalOPEN}
          onClose={MODALZanthusGtin}
          gtin={gtinSelecionado}
        />
      )}
    </>
  );
}