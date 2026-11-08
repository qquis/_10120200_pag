'use client'

import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";



/*Modules*/
import { moduleSistemaBatchService } from '@/api/m9030_sistemaBatchService/moduleSistemaBatchService';
import { moduleNotificacao } from '@/api/m0210_notificacao/moduleNotificacao';

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";





// Interface para o modal de serviço
interface ServiceModalProps {
  isOpen: boolean;
  onClose: () => void;
  serviceId: number;
}

// Tipos para o WhatsApp QR
type WhatsAppStatus = {
    status: 'waiting' | 'qrcode' | 'ready' | 'error' | 'restarting';
    message: string;
    qrcode?: string;
};

type WhatsAppMessageTeste = { 
  notificacao_send_tipo_cd: number
  notificacao_celular_dd_numero: number
  notificacao_send_message: string
}

export default function ServiceModal({ isOpen, onClose, serviceId }: ServiceModalProps) {
  const { user } = useAuth();

  const [serviceData, setServiceData] = useState<any>({});
  const [ActionStatus, setActionStatus] = useState<number>(0);

  // Estados para WhatsApp QR Code
  const [whatsappStatus, setWhatsappStatus] = useState<WhatsAppStatus>({
      status: 'waiting',
      message: 'Carregando...'
  });
  const [showQRCode, setShowQRCode] = useState(false);
  const [isRestarting, setIsRestarting] = useState(false);
  const [whatsappMessageTeste, setWhatsappMessageTeste] = useState<WhatsAppMessageTeste>({
    notificacao_send_tipo_cd: 0,
    notificacao_celular_dd_numero: 0,
    notificacao_send_message: `Teste de envio de mensagem via WhatsApp ${new Date().toLocaleString()}`
  });
  



  let myModuleSistemaBatchService = new moduleSistemaBatchService(user!);

  useEffect(() => { 
    if (isOpen && serviceId) {
        consultarDadosService();
    }
  }, [isOpen, serviceId])

  // Novo useEffect para abrir automaticamente o QR Code para serviços WhatsApp
  useEffect(() => {
    if (serviceData.sis_batch_service_tipo_cd === 2) {
      setShowQRCode(true);
    }
  }, [serviceData.sis_batch_service_tipo_cd]);

  const consultarDadosService = async () => {
    try {
      setActionStatus(1); // Carregando
      let serviceConsultado = await myModuleSistemaBatchService.getService(serviceId);
      setServiceData(serviceConsultado);
      setActionStatus(0); // Carregado
    } catch (e) {
      console.log(`Erro ao consultar Service: ${e}`);
      setActionStatus(0);
    }
  };

  // Funções para WhatsApp
  const fetchWhatsAppQR = async () => {
    if (!serviceData.sis_batch_service_host) {
        setWhatsappStatus({
            status: 'error',
            message: 'Host não informado para este serviço'
        });
        return;
    }

    try {
        const response = await fetch(`${serviceData.sis_batch_service_host}/api/qrcode`);
        const data = await response.json();
        setWhatsappStatus(data);
    } catch (error) {
        setWhatsappStatus({
            status: 'error',
            message: 'Erro ao conectar com o servidor WhatsApp'
        });
    }
  };

  const checkWhatsAppStatus = async () => {
    if (!serviceData.sis_batch_service_host) {
        return { isReady: false, hasQRCode: false, isRestarting: false };
    }

    try {
        const response = await fetch(`${serviceData.sis_batch_service_host}/api/status`);
        const data = await response.json();
        return data;
    } catch (error) {
        return { isReady: false, hasQRCode: false, isRestarting: false };
    }
  };

  // Nova função para reinicializar o WhatsApp
  const restartWhatsApp = async () => {
    console.log('🔄 Iniciando reinicialização do WhatsApp...');
    console.log('📍 Host do serviço:', serviceData.sis_batch_service_host);

    if (!serviceData.sis_batch_service_host) {
        console.log('❌ Erro: Host não informado');
        setWhatsappStatus({
            status: 'error',
            message: 'Host não informado para este serviço'
        });
        return;
    }

    try {
        console.log('🚀 Configurando estado de reinicialização...');
        setIsRestarting(true);
        setWhatsappStatus({
            status: 'restarting',
            message: 'Reinicializando WhatsApp...'
        });

        const url = `${serviceData.sis_batch_service_host}/api/restart`;
        console.log('🌐 URL da requisição:', url);

        const response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            }
        });

        console.log('📡 Status da resposta:', response.status);
        console.log('📡 Response OK:', response.ok);

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        const result = await response.json();
        console.log('📋 Resultado da API:', result);

        if (result.success) {
            console.log('✅ Reinicialização bem-sucedida');
            setWhatsappStatus({
                status: 'waiting',
                message: 'WhatsApp reinicializado! Aguardando nova conexão...'
            });
            
            // Aguardar um pouco e então começar a verificar o status
            console.log('⏰ Aguardando 3 segundos para buscar novo QR Code...');
            setTimeout(() => {
                console.log('🔍 Buscando novo QR Code...');
                fetchWhatsAppQR();
            }, 3000);
        } else {
            console.log('❌ Falha na reinicialização:', result.message);
            setWhatsappStatus({
                status: 'error',
                message: result.message || 'Erro ao reinicializar WhatsApp'
            });
        }
    } catch (error) {
        console.log('💥 Erro na requisição:', error);
        setWhatsappStatus({
            status: 'error',
            message: 'Erro ao conectar com o servidor para reinicializar'
        });
    } finally {
        console.log('🏁 Finalizando processo de reinicialização...');
        setIsRestarting(false);
    }
  };

  // Nova função para logout
  const logoutWhatsApp = async () => {
    if (!serviceData.sis_batch_service_host) {
        setWhatsappStatus({
            status: 'error',
            message: 'Host não informado para este serviço'
        });
        return;
    }

    try {
        const response = await fetch(`${serviceData.sis_batch_service_host}/api/logout`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            }
        });

        const result = await response.json();

        if (result.success) {
            setWhatsappStatus({
                status: 'waiting',
                message: 'Logout realizado! Aguardando nova conexão...'
            });
            
            setTimeout(() => {
                fetchWhatsAppQR();
            }, 2000);
        } else {
            setWhatsappStatus({
                status: 'error',
                message: result.message || 'Erro ao fazer logout'
            });
        }
    } catch (error) {
        setWhatsappStatus({
            status: 'error',
            message: 'Erro ao conectar com o servidor para logout'
        });
    }
  };

  // Effect para atualizar QR Code automaticamente
  useEffect(() => {
      let interval: NodeJS.Timeout;
      
      if (showQRCode && serviceData.sis_batch_service_host && !isRestarting) {
          // Buscar imediatamente
          fetchWhatsAppQR();
          
          // Configurar atualização automática a cada 3 segundos
          interval = setInterval(fetchWhatsAppQR, 3000);
      }

      return () => {
          if (interval) clearInterval(interval);
      };
  }, [showQRCode, serviceData.sis_batch_service_host, isRestarting]);

  const getStatusColor = (status: string) => {
      switch (status) {
          case 'ready': return 'text-green-600 bg-green-50 border-green-200';
          case 'qrcode': return 'text-blue-600 bg-blue-50 border-blue-200';
          case 'waiting': return 'text-yellow-600 bg-yellow-50 border-yellow-200';
          case 'restarting': return 'text-orange-600 bg-orange-50 border-orange-200';
          case 'error': return 'text-red-600 bg-red-50 border-red-200';
          default: return 'text-gray-600 bg-gray-50 border-gray-200';
      }
  };

  const getStatusIcon = (status: string) => {
      switch (status) {
          case 'ready': return '✅';
          case 'qrcode': return '📱';
          case 'waiting': return '⏳';
          case 'restarting': return '🔄';
          case 'error': return '❌';
          default: return '⚪';
      }
  };

  const handleQRCodeAction = () => {
      if (showQRCode && whatsappStatus.status === 'ready') {
          fetchWhatsAppQR();
      } else if (showQRCode && whatsappStatus.status !== 'ready') {
          fetchWhatsAppQR();
      } else {
          setShowQRCode(true);
          fetchWhatsAppQR();
      }
  };

  const handleVerifyStatus = async () => {
      try {
          const statusData = await checkWhatsAppStatus();
          
          if (statusData.isRestarting) {
              setWhatsappStatus({
                  status: 'restarting',
                  message: 'WhatsApp sendo reinicializado...'
              });
          } else if (statusData.isReady) {
              setWhatsappStatus({
                  status: 'ready',
                  message: 'WhatsApp conectado e pronto!'
              });
          } else if (statusData.hasQRCode) {
              setWhatsappStatus({
                  status: 'qrcode',
                  message: 'QR Code disponível para escaneamento'
              });
              fetchWhatsAppQR();
          } else {
              setWhatsappStatus({
                  status: 'waiting',
                  message: 'Aguardando conexão...'
              });
          }
      } catch (error) {
          setWhatsappStatus({
              status: 'error',
              message: 'Erro ao verificar status'
          });
      }
  };

  const NotificacaoWhatsTeste = () => { 
    let myModuleNotificacao = new moduleNotificacao(user!, 1001);

    myModuleNotificacao.postTeste({ 
      notificacao_send_tipo_cd: whatsappMessageTeste.notificacao_send_tipo_cd,
      notificacao_celular_dd_numero: whatsappMessageTeste.notificacao_celular_dd_numero,
      notificacao_send_message: `*Prime* WHATS TESTE - ${new Date().toLocaleString()} -> ` + whatsappMessageTeste.notificacao_send_message 
      
    })
  
  };

  // Verificar se é serviço WhatsApp
  const isWhatsAppService = serviceData.sis_batch_service_tipo_cd === 2;

  if (!isOpen) return null;

  return (
    <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50">
      <div className="bg-white rounded-lg shadow-xl max-w-6xl w-full mx-4 max-h-[90vh] flex flex-col">
        {/* Header - FIXO */}
        <HeaderMain tipo={"_MODAL"} ActionStatus={ActionStatus} header_title="Sistema Batch Service - Detalhes do Serviço" >
          <div className="flex space-x-2">
            <button onClick={onClose} className="text-white hover:text-gray-200 text-2xl font-bold" > × </button>
          </div>              
        </HeaderMain>

        {/* Content Container */}
        <div className="flex flex-col flex-1 min-h-0">
          {/* Loading State */}
          {ActionStatus === 1 ? (
            <div className="flex-1 flex items-center justify-center p-6">
              <div className="text-center">
                <div className="animate-spin rounded-full h-12 w-12 border-b-2 border-purple-600 mx-auto mb-4"></div>
                <p className="text-gray-600 text-lg font-medium">Consultando dados do Service...</p>
                <p className="text-gray-400 text-sm mt-2">Aguarde, estamos buscando as informações</p>
              </div>
            </div>
          ) : (
            <div className="p-6 flex-1 overflow-y-auto">
              {/* 1. Informações do Service */}
              <div className="border border-gray-200 rounded-lg p-4 mb-6">
                <h3 className="text-lg font-semibold text-white mb-4 pb-2 px-3 py-2 bg-slate-400 rounded-t-lg -mx-4 -mt-4">
                  Informações do Service
                </h3>
                <div className="grid grid-cols-1 md:grid-cols-2 gap-4 mt-4">
                  <div>
                    <label className="block text-sm font-medium text-gray-600 mb-1">Código do Service:</label>
                    <p className="text-gray-800 font-medium bg-gray-50 p-2 rounded border">
                      {serviceData.sis_batch_service_cd}
                    </p>
                  </div>
                  <div>
                    <label className="block text-sm font-medium text-gray-600 mb-1">Tipo (Código):</label>
                    <p className="text-gray-800 font-medium bg-gray-50 p-2 rounded border">
                      {serviceData.sis_batch_service_tipo_cd}
                    </p>
                  </div>
                  <div>
                    <label className="block text-sm font-medium text-gray-600 mb-1">Tipo (Descrição):</label>
                    <p className="text-gray-800 bg-gray-50 p-2 rounded border">
                      {serviceData.sis_batch_service_tipo_descricao}
                    </p>
                  </div>
                  <div>
                    <label className="block text-sm font-medium text-gray-600 mb-1">Host:</label>
                    <p className={`text-gray-800 bg-gray-50 p-2 rounded border ${!serviceData.sis_batch_service_host ? 'text-red-600' : ''}`}>
                      {serviceData.sis_batch_service_host || 'Host não informado'}
                    </p>
                  </div>
                </div>
                
                <div className="mt-4">
                  <label className="block text-sm font-medium text-gray-600 mb-1">Descrição do Service:</label>
                  <p className="text-gray-800 bg-gray-50 p-2 rounded border">
                    {serviceData.sis_batch_service_descricao}
                  </p>
                </div>

                {/* WhatsApp QR Code - logo abaixo da descrição para serviços tipo 2 */}
                {isWhatsAppService && (
                  <div className="mt-6 border-t pt-4">
                    <h4 className="text-lg font-semibold text-gray-800 mb-4">WhatsApp QR Code</h4>
                    
                    {/* Status */}
                    <div className={`inline-flex items-center px-3 py-2 rounded-md text-sm font-medium border mb-4 ${getStatusColor(whatsappStatus.status)}`}>
                      <span className="mr-2">{getStatusIcon(whatsappStatus.status)}</span>
                      {whatsappStatus.message}
                    </div>

                    {/* QR Code Display */}
                    <div className="flex justify-center items-center min-h-[300px] border-2 border-dashed border-gray-300 rounded-lg bg-gray-50">
                      {whatsappStatus.status === 'ready' ? (
                        <div className="text-center">
                          <div className="text-6xl mb-4">✅</div>
                          <div className="text-xl text-green-600 font-semibold">WhatsApp Conectado!</div>
                          <div className="text-sm text-gray-600 mt-2">Sistema pronto para enviar mensagens</div>
                        </div>
                      ) : whatsappStatus.qrcode ? (
                        <div className="text-center">
                          <img 
                            src={whatsappStatus.qrcode} 
                            alt="QR Code WhatsApp" 
                            className="max-w-full max-h-[280px] mx-auto rounded-lg shadow-sm"
                          />
                          <div className="text-sm text-gray-600 mt-3">
                            Escaneie o código com seu WhatsApp
                          </div>
                        </div>
                      ) : whatsappStatus.status === 'waiting' ? (
                        <div className="text-center">
                          <div className="animate-spin rounded-full h-12 w-12 border-b-2 border-purple-600 mx-auto mb-4"></div>
                          <div className="text-gray-600">Aguardando QR Code...</div>
                        </div>
                      ) : (
                        <div className="text-center">
                          <div className="text-4xl mb-4">❌</div>
                          <div className="text-red-600">
                            {!serviceData.sis_batch_service_host ? 'Host não informado' : 'Erro de conexão'}
                          </div>
                          {serviceData.sis_batch_service_host && (
                            <button
                              onClick={fetchWhatsAppQR}
                              className="mt-3 px-4 py-2 bg-purple-600 text-white rounded-md hover:bg-purple-700 text-sm"
                            >
                              Tentar Novamente
                            </button>
                          )}
                        </div>
                      )}
                    </div>

                    {/* Botões de ação */}
                    {serviceData.sis_batch_service_host && (
                      <div className="flex justify-center space-x-3 mt-6">
                        {/* Botão Atualizar QR Code - só aparece quando não está conectado */}
                        {whatsappStatus.status !== 'ready' && (
                          <button
                            onClick={fetchWhatsAppQR}
                            disabled={isRestarting || whatsappStatus.status === 'restarting' || whatsappStatus.status === 'error'}
                            className="px-4 py-2 bg-blue-600 text-white rounded-md hover:bg-blue-700 text-sm font-medium disabled:bg-gray-400 disabled:cursor-not-allowed"
                          >
                            🔄 Atualizar QR Code
                          </button>
                        )}
                        
                        <button
                          onClick={handleVerifyStatus}
                          disabled={isRestarting || whatsappStatus.status === 'restarting' || whatsappStatus.status === 'error'}
                          className="px-4 py-2 bg-gray-600 text-white rounded-md hover:bg-gray-700 text-sm font-medium disabled:bg-gray-400 disabled:cursor-not-allowed"
                        >
                          📊 Verificar Status
                        </button>
                        
                        <button
                          onClick={() => {
                            restartWhatsApp();
                          }}
                          disabled={isRestarting || whatsappStatus.status === 'restarting' || whatsappStatus.status === 'error'}
                          className="px-4 py-2 bg-orange-600 text-white rounded-md hover:bg-orange-700 text-sm font-medium disabled:bg-gray-400 disabled:cursor-not-allowed"
                        >
                          {isRestarting || whatsappStatus.status === 'restarting' ? '🔄 Reinicializando...' : '🔄 Reinicializar WhatsApp'}
                        </button>
                        
                        <button
                          onClick={logoutWhatsApp}
                          disabled={isRestarting || whatsappStatus.status === 'restarting' || whatsappStatus.status === 'error'}
                          className="px-4 py-2 bg-red-600 text-white rounded-md hover:bg-red-700 text-sm font-medium disabled:bg-gray-400 disabled:cursor-not-allowed"
                        >
                          🚪 Logout
                        </button>
                      </div>
                    )}
                  </div>
                )}

                
                
                <div className="mt-4 bg-blue-50 p-3 rounded-lg border-l-4 border-blue-500">
                  <div className="flex items-center">
                    <div className="flex-shrink-0">
                      <svg className="w-4 h-4 text-blue-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
                      </svg>
                    </div>
                    <div className="ml-2">
                      <p className="text-sm text-blue-700">
                        Service do tipo <strong>{serviceData.sis_batch_service_tipo_descricao}</strong>
                        {!isWhatsAppService && (
                          <span> com <strong>{serviceData.batchs?.length || 0}</strong> batch(s) associado(s)</span>
                        )}
                      </p>
                    </div>
                  </div>
                </div>
              </div>

              {/* 2. Batchs Associados em Tabela - apenas para serviços que não são WhatsApp */}
              {!isWhatsAppService && (
                <div className="border border-gray-200 rounded-lg p-4">
                  <h3 className="text-lg font-semibold text-white mb-4 pb-2 px-3 py-2 bg-slate-400 rounded-t-lg -mx-4 -mt-4">
                    Batchs Associados ({serviceData.batchs?.length || 0})
                  </h3>
                  
                  {serviceData.batchs && serviceData.batchs.length > 0 ? (
                    <div className="mt-4 overflow-x-auto">
                      <table className="min-w-full divide-y divide-gray-200">
                        <thead className="bg-gray-50">
                          <tr>
                            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                              Código do Batch
                            </th>
                            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                              Módulo
                            </th>
                            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                              Status
                            </th>
                            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                              Descrição do Batch
                            </th>
                          </tr>
                        </thead>
                        <tbody className="bg-white divide-y divide-gray-200">
                          {serviceData.batchs.map((batch: any, index: number) => (
                            <tr key={batch.sis_batch_cd} className={index % 2 === 0 ? 'bg-white' : 'bg-gray-50'}>
                              <td className="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900">
                                {batch.sis_batch_cd}
                              </td>
                              <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">
                                <span className="inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium bg-gray-100 text-gray-800">
                                  {batch.module_cd}
                                </span>
                              </td>
                              <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">
                                <span className={`inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium ${
                                  batch.sis_batch_status === 1 
                                    ? 'bg-green-100 text-green-800' 
                                    : 'bg-red-100 text-red-800'
                                }`}>
                                  {batch.sis_batch_status === 1 ? 'Ativo' : 'Inativo'}
                                </span>
                              </td>
                              <td className="px-6 py-4 text-sm text-gray-900">
                                {batch.sis_batch_descricao}
                              </td>
                            </tr>
                          ))}
                        </tbody>
                      </table>
                    </div>
                  ) : (
                    <div className="mt-4 text-center py-6 bg-gray-50 rounded-lg">
                      <svg className="w-12 h-12 text-gray-400 mx-auto mb-2" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M9 12h6m-6 4h6m2 5H7a2 2 0 01-2-2V5a2 2 0 012-2h5.586a1 1 0 01.707.293l5.414 5.414a1 1 0 01.293.707V19a2 2 0 01-2 2z" />
                      </svg>
                      <p className="text-gray-500 text-sm">Nenhum batch associado a este service</p>
                    </div>
                  )}
                </div>
              )}

 {/* WhatsApp QR Code - logo abaixo da descrição para serviços tipo 2 */}
                {isWhatsAppService && (
                  <div className="mt-6 border border-gray-200 rounded-lg p-4 bg-gray-50">
                    <h4 className="text-lg font-semibold text-gray-800 mb-4">Mensagem de Teste</h4>

                    <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
                      <div>
                        <label className="block text-sm font-medium text-gray-700 mb-1">Codigo do perfil</label>
                        <select
                          className="w-full p-2 border border-gray-300 rounded-md text-black"
                          value={whatsappMessageTeste.notificacao_send_tipo_cd}
                          onChange={(e) =>
                            setWhatsappMessageTeste((prev) => ({
                              ...prev,
                              notificacao_send_tipo_cd: Number(e.target.value)
                            }))
                          }
                        >
                          <option value={100}>100 - WHATS ADM</option>
                          <option value={200}>200 - WHATS PORTARIA</option>
                        </select>
                      </div>

                      <div>
                        <label className="block text-sm font-medium text-gray-700 mb-1">DD e numero</label>
                        <input
                          type="text"
                          className="w-full p-2 border border-gray-300 rounded-md text-black"
                          placeholder="11999998888"
                          value={whatsappMessageTeste.notificacao_celular_dd_numero || ''}
                          onChange={(e) =>
                            setWhatsappMessageTeste((prev) => ({
                              ...prev,
                              notificacao_celular_dd_numero: Number(e.target.value.replace(/\D/g, '') || 0)
                            }))
                          }
                        />
                      </div>

                      <div className="md:col-span-1">
                        <label className="block text-sm font-medium text-gray-700 mb-1">Mensagem</label>
                        <input
                          type="text"
                          className="w-full p-2 border border-gray-300 rounded-md text-black"
                          value={whatsappMessageTeste.notificacao_send_message}
                          maxLength={10}
                          onChange={(e) =>
                            setWhatsappMessageTeste((prev) => ({
                              ...prev,
                              notificacao_send_message: e.target.value || ''
                            }))
                          }
                        />
                      </div>
                    </div>

                    <div className="mt-4 flex justify-end">
                      <button
                        onClick={NotificacaoWhatsTeste}
                        disabled={!whatsappMessageTeste.notificacao_celular_dd_numero}
                        className="px-4 py-2 bg-green-600 text-white rounded-md hover:bg-green-700 disabled:bg-gray-400 disabled:cursor-not-allowed"
                      >
                        Enviar mensagem teste
                      </button>
                    </div>
                  </div>
                )}



            </div>
          )}
        </div>

        {/* Footer - FIXO */}
        <div className="bg-gray-50 px-6 py-4 rounded-b-lg flex justify-end flex-shrink-0 border-t border-gray-200">
          <button
            onClick={onClose}
            className="bg-blue-500 hover:bg-blue-600 text-white px-4 py-2 rounded-md transition-colors"
          >
            Fechar
          </button>
        </div>
      </div>
    </div>
  );
}
