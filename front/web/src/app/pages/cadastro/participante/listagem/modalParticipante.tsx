'use client'
const __SIS_AC_CD = 1011

import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";
import { moduleParticipante } from '@/api/m0011_Participante/moduleParticipante';

import HeaderMain from "@/app/components/divs/headerMain";
import Card from '@/app/components/card/card';
import ButtonPag from "@/app/components/Buttons/button";

interface ParticipanteModalProps {
  isOpen: boolean;
  onClose: () => void;
  participanteId: number | null;
}

export default function ParticipanteModal({ isOpen, onClose, participanteId }: ParticipanteModalProps) {
  const { user } = useAuth();
  const [participante, setParticipante] = useState<any | null>(null);
  
  const [loading, setLoading] = useState(false);
  const [ActionStatus, setActionStatus] = useState<number>(0);

  const myModuleParticipante = new moduleParticipante(user, __SIS_AC_CD);


  useEffect(() => {
    if (isOpen && participanteId) {
      consultarParticipante();
    }
    // eslint-disable-next-line
  }, [isOpen, participanteId]);

  const consultarParticipante = async () => {
    if (!participanteId) return;
    setLoading(true);
    setActionStatus(1);
    try {
      
      const participanteData = await myModuleParticipante.getParticipante({ cdparticipante: participanteId });
      setParticipante(participanteData);
      setActionStatus(0);
    } catch (error) {
      setParticipante(null);
      setActionStatus(0);
    } finally {
      setLoading(false);
    }
  };
  const AtualizarDadosBluesoft = async (cdpessoabluesoft: number) => {
    try { 
      setLoading(true);
      setActionStatus(1);
      await myModuleParticipante.postOperacaoBluesoftApiImport(
        { cdpessoabluesoft: cdpessoabluesoft }
      );
      
      setActionStatus(0);
    } catch (error) {
      setActionStatus(0);
    } finally {
      setLoading(false);
    }
  }

  if (!isOpen) return null;

  return (
    <>
      {/* Modal Principal do Participante */}
      <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50">
        <div className="bg-white rounded-lg shadow-xl max-w-2xl w-full mx-4 max-h-[90vh] flex flex-col">
          {/* Header */}
          <HeaderMain tipo={"_MODAL"} ActionStatus={ActionStatus} header_title="Participante - Dados Principais" >
            <div className="flex space-x-2">
              <button onClick={onClose} className="text-white hover:text-gray-200 text-2xl font-bold"> × </button>
            </div>
            
          </HeaderMain>

          {/* Loading ou conteúdo */}
          {loading ? (
            <div className="flex items-center justify-center py-8 flex-1">
              <div className="animate-spin rounded-full h-8 w-8 border-b-2 border-purple-600"></div>
              <span className="ml-2 text-gray-600">Carregando participante...</span>
            </div>
          ) : participante ? (
            <div className="flex-1 overflow-y-auto px-6 pb-6">
              <div className="space-y-6 pt-6">
                {/* Informações principais */}
                <div className="bg-gray-50 p-4 rounded-lg">
                  <div className="grid grid-cols-2 gap-4">
                    <div>
                      <label className="block text-xs font-medium text-gray-600">Código</label>
                      <p className="text-sm text-gray-800 font-semibold">{participante.cdparticipante}</p>
                    </div>
                    <div>
                      <label className="block text-xs font-medium text-gray-600">Nome/Razão</label>
                      <p className="text-sm text-gray-800 font-semibold">{participante.nome_razao}</p>
                    </div>
                    <div>
                      <label className="block text-xs font-medium text-gray-600">E-mail principal</label>
                      <p className="text-sm text-gray-800">{participante.email_main}</p>
                    </div>
                    <div>
                      <label className="block text-xs font-medium text-gray-600">Celular</label>
                      <p className="text-sm text-gray-800">
                        ({participante.celular_dd}) {participante.celular_numero}
                      </p>
                    </div>
                  </div>
                </div>
                {/* Outras informações principais podem ser adicionadas aqui */}

                {participante.listInfo && participante.listInfo.length > 0 && (
                  <div style={{ display: 'block', width: '100%', maxWidth: 500, marginLeft: '0 auto' }}>
                    {participante.listInfo.map((item: any) => (
                      <Card key={item.info} title={item.resume}>
                        {item.info === "RH" && participante.infoRh && participante.infoRh.length > 0 ? (
                          <table
                            style={{
                              width: '100%',
                              fontSize: 14,
                              borderCollapse: 'collapse',
                              marginTop: 8,
                              background: '#fafafa',
                              borderRadius: 8,
                              overflow: 'hidden',
                            }}
                          >
                            <thead>
                              <tr style={{ background: '#f1f5f9' }}>
                                <th style={{ padding: '8px', borderBottom: '2px solid #e5e7eb', textAlign: 'left', fontWeight: 600, color: '#374151' }}>Funcionário</th>
                                <th style={{ padding: '8px', borderBottom: '2px solid #e5e7eb', textAlign: 'left', fontWeight: 600, color: '#374151' }}>Admissão</th>
                                <th style={{ padding: '8px', borderBottom: '2px solid #e5e7eb', textAlign: 'left', fontWeight: 600, color: '#374151' }}>Rescisão</th>
                                <th style={{ padding: '8px', borderBottom: '2px solid #e5e7eb', textAlign: 'left', fontWeight: 600, color: '#374151' }}>Status</th>
                                <th style={{ padding: '8px', borderBottom: '2px solid #e5e7eb', textAlign: 'left', fontWeight: 600, color: '#374151' }}>Setor</th>
                                <th style={{ padding: '8px', borderBottom: '2px solid #e5e7eb', textAlign: 'left', fontWeight: 600, color: '#374151' }}>Contrato</th>
                              </tr>
                            </thead>
                            <tbody>
                              {participante.infoRh.map((rh: any, i: number) => (
                                <tr key={rh.rh_funcionario_cd} style={{ background: i % 2 === 0 ? '#fff' : '#f9fafb' }}>
                                  <td style={{ padding: '8px', borderBottom: '1px solid #e5e7eb' }}>{rh.rh_funcionario_cd}</td>
                                  <td style={{ padding: '8px', borderBottom: '1px solid #e5e7eb' }}>{new Date(rh.data_admissao).toLocaleDateString()}</td>
                                  <td style={{ padding: '8px', borderBottom: '1px solid #e5e7eb' }}>{new Date(rh.data_rescisao).toLocaleDateString()}</td>
                                  <td style={{ padding: '8px', borderBottom: '1px solid #e5e7eb' }}>{rh.rh_status}</td>
                                  <td style={{ padding: '8px', borderBottom: '1px solid #e5e7eb' }}>{rh.rh_setor_operacional_cd}</td>
                                  <td style={{ padding: '8px', borderBottom: '1px solid #e5e7eb' }}>{rh.rh_tipo_contrato_cd}</td>
                                </tr>
                              ))}
                            </tbody>
                          </table>
                        ) : null}
                        {item.info === "VIP" && participante.infoVip && participante.infoVip.length > 0 ? (
                          <div style={{ marginTop: 8 }}>
                            {participante.infoVip.map((vip: any, idx: number) => (
                              <div key={idx} className="mb-4 p-3 bg-gray-100 rounded">
                                <div className="grid grid-cols-2 gap-2">
                                  <div>
                                    <label className="block text-xs font-medium text-gray-600">Código</label>
                                    <p className="text-sm text-gray-800 font-semibold">{vip.cdparticipante}</p>
                                  </div>
                                  <div>
                                    <label className="block text-xs font-medium text-gray-600">CPF/CNPJ</label>
                                    <p className="text-sm text-gray-800">{vip.vip_cpf_cnpj}</p>
                                  </div>
                                  <div>
                                    <label className="block text-xs font-medium text-gray-600">CPF</label>
                                    <p className="text-sm text-gray-800">{vip.vip_cpf}</p>
                                  </div>
                                  <div>
                                    <label className="block text-xs font-medium text-gray-600">CNPJ</label>
                                    <p className="text-sm text-gray-800">{vip.vip_cnpj}</p>
                                  </div>
                                  <div>
                                    <label className="block text-xs font-medium text-gray-600">Nome</label>
                                    <p className="text-sm text-gray-800">{vip.vip_nome}</p>
                                  </div>
                                  <div>
                                    <label className="block text-xs font-medium text-gray-600">Sobrenome</label>
                                    <p className="text-sm text-gray-800">{vip.vip_sobre_nome}</p>
                                  </div>
                                  <div className="col-span-2">
                                    <label className="block text-xs font-medium text-gray-600">E-mail</label>
                                    <p className="text-sm text-gray-800">{vip.vip_email}</p>
                                  </div>
                                  <div className="col-span-2">
                                    <label className="block text-xs font-medium text-gray-600">Data de Nascimento</label>
                                    <p className="text-sm text-gray-800">{vip.vip_data_nascimento ? new Date(vip.vip_data_nascimento).toLocaleDateString() : ''}</p>
                                  </div>
                                </div>
                              </div>
                            ))}
                          </div>
                        ) : null}

                        {item.info === "BLUE" && participante.infoBlueSoft && participante.infoBlueSoft.length > 0 ? (
                          <div style={{ marginTop: 8 }}>
                            {participante.infoBlueSoft.map((blue: any, idx: number) => (
                              <div key={idx} className="mb-4 p-3 bg-blue-50 rounded">
                                <div className="grid grid-cols-2 gap-2">
                                  <div>
                                    <label className="block text-xs font-medium text-gray-600">Código Participante</label>
                                    <p className="text-sm text-gray-800 font-semibold">{blue.cdparticipante}</p>
                                  </div>
                                  <div>
                                    <label className="block text-xs font-medium text-gray-600">Código Pessoa Bluesoft</label>
                                    <p className="text-sm text-gray-800">{blue.cdpessoabluesoft}</p>
                                  </div>
                                  <div>
                                    <label className="block text-xs font-medium text-gray-600">CPF/CNPJ</label>
                                    <p className="text-sm text-gray-800">{blue.cpf_cnpj}</p>
                                  </div>
                                  <div>
                                    <label className="block text-xs font-medium text-gray-600">Pessoa Jurídica</label>
                                    <p className="text-sm text-gray-800">{blue.pessoajuridica === 1 ? 'Sim' : 'Não'}</p>
                                  </div>
                                  <div>
                                    <label className="block text-xs font-medium text-gray-600">Data Cadastro</label>
                                    <p className="text-sm text-gray-800">{blue.bluesoft_pessoa_data_cadastro ? new Date(blue.bluesoft_pessoa_data_cadastro).toLocaleDateString() : ''}</p>
                                  </div>
                                  <div>
                                    <label className="block text-xs font-medium text-gray-600">Status Pessoa</label>
                                    <span className={`inline-block w-3 h-3 rounded-full ${blue.bluesoft_pessoa_status === 1 ? 'bg-green-500' : 'bg-red-500'}`}></span>
                                  </div>
                                  <div>
                                    <label className="block text-xs font-medium text-gray-600">Nome/Razão</label>
                                    <p className="text-sm text-gray-800">{blue.nome_razao}</p>
                                  </div>
                                  <div>
                                    <label className="block text-xs font-medium text-gray-600">Nome Abreviado</label>
                                    <p className="text-sm text-gray-800">{blue.nome_abreviado}</p>
                                  </div>
                                  <div>
                                    <label className="block text-xs font-medium text-gray-600">Cliente Bluesoft</label>
                                    <span className={`inline-block w-3 h-3 rounded-full ${blue.bluesoftcliente === 1 ? 'bg-green-500' : 'bg-red-500'}`}></span>
                                  </div>
                                  <div>
                                    <label className="block text-xs font-medium text-gray-600">Status Cliente Bluesoft</label>
                                    <span className={`inline-block w-3 h-3 rounded-full ${blue.bluesoftclientestatus === 1 ? 'bg-green-500' : 'bg-red-500'}`}></span>
                                  </div>
                                  <div>
                                    <label className="block text-xs font-medium text-gray-600">Grupo Econômico</label>
                                    <p className="text-sm text-gray-800">{blue.cdgrupoeconomico} - {blue.descricao}</p>
                                  </div>
                                  <div>
                                    <label className="block text-xs font-medium text-gray-600">Código Vendedor Bluesoft</label>
                                    <p className="text-sm text-gray-800">{blue.cdpessoabluesoft_vendedor} - {blue.nome_vendedor}</p>
                                    
                                  </div>
                                  <div>
                                    <label className="block text-xs font-medium text-gray-600">Vendedor Bluesoft</label>
                                    <span className={`inline-block w-3 h-3 rounded-full ${blue.bluesoftvendedor === 1 ? 'bg-green-500' : 'bg-red-500'}`}></span>
                                  </div>
                                  <div>
                                    <label className="block text-xs font-medium text-gray-600">Fornecedor Bluesoft</label>
                                    <span className={`inline-block w-3 h-3 rounded-full ${blue.bluesoftfornecedor === 1 ? 'bg-green-500' : 'bg-red-500'}`}></span>
                                  </div>
                                  <div>
                                    <label className="block text-xs font-medium text-gray-600">Fabricante Bluesoft</label>
                                    <span className={`inline-block w-3 h-3 rounded-full ${blue.bluesoftfabricante === 1 ? 'bg-green-500' : 'bg-red-500'}`}></span>
                                  </div>
                                  <div>
                                    <label className="block text-xs font-medium text-gray-600">Motorista Bluesoft</label>
                                    <span className={`inline-block w-3 h-3 rounded-full ${blue.bluesoftmotorista === 1 ? 'bg-green-500' : 'bg-red-500'}`}></span>
                                  </div>

                                  <div>

                                  <button
                                      type="button"
                                      className="flex items-center px-4 py-2 bg-green-600 hover:bg-green-700 text-white rounded shadow transition disabled:opacity-70 disabled:cursor-not-allowed"
                                      title="Importar Pessoas Bluesoft Redshift via API"
                                      onClick={() => AtualizarDadosBluesoft(blue.cdpessoabluesoft)}
                                      disabled={ActionStatus === 1}
                                      >
                                      {ActionStatus === 1 ? (
                                          <svg className="w-5 h-5 mr-2 animate-spin" fill="none" viewBox="0 0 24 24">
                                              <circle className="opacity-25" cx="12" cy="12" r="10" stroke="white" strokeWidth="4" />
                                              <path className="opacity-75" fill="white" d="M4 12a8 8 0 018-8v8z" />
                                          </svg>
                                      ) : (
                                          <svg className="w-5 h-5 mr-2" fill="none" stroke="currentColor" strokeWidth={2} viewBox="0 0 24 24">
                                              <path strokeLinecap="round" strokeLinejoin="round" d="M12 4v16m8-8H4" />
                                          </svg>
                                      )}
                                      Atualizar dados Bluesoft
                                  </button>


                                  </div>

                                </div>
                              </div>
                            ))}
                          </div>
                        ) : null}                        

                      </Card>
                    ))}
                  </div>
                )}


              </div>


            </div>
            
            
          ) : (
            <div className="text-center py-8 flex-1 flex items-center justify-center">
              <p className="text-gray-600">Participante não encontrado.</p>
            </div>
          )}

          {/* Footer */}
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
    </>
  );
}