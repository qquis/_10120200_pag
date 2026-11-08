'use client'

import { useState, useEffect, useRef } from 'react'
import { Html5QrcodeScanner, Html5Qrcode, Html5QrcodeScanType } from 'html5-qrcode'

import { moduleParticipanteCrm, TpParticipanteCRM } from '@/app/api/m0011_participante/moduleparticipante';
import { moduleCRM, TpCrmSorteioCupom, TpCrmSorteioTemporada, TpCrmSorteioNumero } from '@/app/api/m0090_sorteio/modulesorteio'
import { useAuth } from '@/app/context/context'

export default function SorteioPage() {
  const [SorteioTemporada, setTemporadaAtiva] = useState<TpCrmSorteioTemporada | null>(null)
  const [ListNumeros, setListNumeros] = useState<TpCrmSorteioNumero[]>([])

  const [Cupom, setCupom] = useState<TpCrmSorteioCupom | null>(null)
  const [nf_chave_filter, setNfChaveFilter] = useState<string>('')
  const [loadingCupom, setLoadingCupom] = useState(false)
  const [tipoConsulta, setTipoConsulta] = useState<'chave' | 'dados'>('chave')

  const [loading, setLoading] = useState(true)
  const [ErrorMessage, setError] = useState<string | null>(null)
  const [initialized, setInitialized] = useState(false)

    const [nf_numero_filter, setNfNumeroFilter] = useState<string>('')
  const [nf_data_filter, setNfDataFilter] = useState<string>('')
  const [nf_pdv_filter, setNfPdvFilter] = useState<string>('')
  const [permiteLancarCupom, setPermiteLancarCupom] = useState<boolean>(true)
  
  // Estado para o popup de sucesso
  const [showSuccessPopup, setShowSuccessPopup] = useState(false)

  // Estados para QR Code Scanner
  const [isMobile, setIsMobile] = useState(false)
  const [showQrScanner, setShowQrScanner] = useState(false)
  const [qrScanner, setQrScanner] = useState<Html5QrcodeScanner | null>(null)
  const qrCodeRegionId = "qr-reader"
  
  // Estado para verificar se o contexto está carregando
  const [authLoading, setAuthLoading] = useState(true)
  
  const { user, cliente } = useAuth()

  // Inicializar módulos apenas uma vez
  const moduleRef = useRef<moduleCRM | null>(null)
  moduleRef.current = new moduleCRM(user)
  moduleRef.current.cpf_user = cliente?.cpf || ''
  

  // Aguardar o contexto de autenticação carregar completamente
  useEffect(() => {
    const timer = setTimeout(() => {
      setAuthLoading(false)
    }, 1000) // Aguarda 1 segundo para o contexto carregar

    return () => clearTimeout(timer)
  }, [])

  useEffect(() => {
    if (user && !moduleRef.current) {
      moduleRef.current = new moduleCRM(user)
    }
  }, [user])

  // Detectar se é dispositivo móvel
  useEffect(() => {
    const checkMobile = () => {
      const userAgent = navigator.userAgent || navigator.vendor || (window as any).opera;
      const isMobileDevice = /android|iphone|ipad|ipod|blackberry|iemobile|opera mini/i.test(userAgent.toLowerCase()) ||
                            window.innerWidth <= 768;
      setIsMobile(isMobileDevice);
    };

    checkMobile();
    window.addEventListener('resize', checkMobile);
    
    return () => window.removeEventListener('resize', checkMobile);
  }, []);

  // Inicializar apenas uma vez quando user estiver disponível e auth não estiver carregando
  useEffect(() => {
    if (!authLoading && user && !initialized && moduleRef.current) {
      setInitialized(true)
      consultarTemporadaAtiva()
    }
  }, [user, initialized, authLoading])

  // Função para extrair chave NFe do QR Code
  const extractNFeKeyFromQRCode = (qrCodeText: string): string => {
    try {
      // QR Code da NFe geralmente tem o formato:
      // https://www.sefaz.rs.gov.br/NFCE/consulta?chNFe=CHAVE44DIGITOS&nVersao=100&tpAmb=1
      // ou apenas a chave de 44 dígitos

      // Tentar extrair chave de URL
      const urlMatch = qrCodeText.match(/chNFe=([0-9]{44})/);
      if (urlMatch) {
        return urlMatch[1];
      }

      // Verificar se é uma chave de 44 dígitos diretamente
      const directKeyMatch = qrCodeText.match(/^[0-9]{44}$/);
      if (directKeyMatch) {
        return qrCodeText;
      }

      // Tentar encontrar sequência de 44 dígitos em qualquer lugar do texto
      const anyKeyMatch = qrCodeText.match(/[0-9]{44}/);
      if (anyKeyMatch) {
        return anyKeyMatch[0];
      }

      throw new Error('Chave NFe não encontrada no QR Code');
    } catch (e) {
      throw new Error('QR Code inválido ou não contém chave de NFe');
    }
  };

  // Função para verificar e solicitar permissões de câmera - VERSÃO MELHORADA
  const requestCameraPermission = async (): Promise<boolean> => {
    try {
      // Verificar se estamos em um contexto seguro (HTTPS ou localhost)
      const isSecureContext = window.isSecureContext || 
                             window.location.protocol === 'https:' || 
                             window.location.hostname === 'localhost' ||
                             window.location.hostname === '127.0.0.1' || 
                             window.location.hostname === "10.0.1.2";
      
      if (!isSecureContext) {
        setError('A câmera só funciona em conexões seguras (HTTPS). Verifique se o site está acessível via HTTPS.');
        return false;
      }

      // Verificar se navigator está disponível
      if (typeof navigator === 'undefined') {
        setError('Navigator não disponível neste ambiente.');
        return false;
      }

      // Verificar se mediaDevices está disponível
      if (!navigator.mediaDevices) {
        setError('API de mídia não suportada neste navegador. Tente um navegador mais recente.');
        return false;
      }

      // Verificar se getUserMedia está disponível
      if (!navigator.mediaDevices.getUserMedia) {
        setError('Acesso à câmera não suportado neste navegador. Tente Chrome, Firefox ou Safari mais recentes.');
        return false;
      }

      console.log('Solicitando acesso à câmera...');

      // Solicitar acesso à câmera com configurações mais flexíveis
      const constraints = {
        video: {
          facingMode: { ideal: 'environment' }, // Preferir câmera traseira, mas não obrigatório
          width: { ideal: 640 },
          height: { ideal: 480 }
        }
      };

      const stream = await navigator.mediaDevices.getUserMedia(constraints);
      
      // Verificar se o stream foi criado com sucesso
      if (!stream || stream.getTracks().length === 0) {
        setError('Não foi possível acessar a câmera. Verifique se há uma câmera conectada.');
        return false;
      }

      // Parar o stream imediatamente (só queríamos a permissão)
      stream.getTracks().forEach(track => {
        track.stop();
        console.log('Track parado:', track.kind);
      });
      
      console.log('Permissão de câmera concedida com sucesso');
      return true;
      
    } catch (error: any) {
      console.error('Erro ao solicitar permissão de câmera:', error);
      
      let errorMessage = 'Erro desconhecido ao acessar a câmera.';
      
      switch (error.name) {
        case 'NotAllowedError':
          errorMessage = 'Permissão de câmera negada. Por favor, permita o acesso à câmera nas configurações do navegador e recarregue a página.';
          break;
        case 'NotFoundError':
          errorMessage = 'Nenhuma câmera encontrada no dispositivo. Conecte uma câmera e tente novamente.';
          break;
        case 'NotSupportedError':
          errorMessage = 'Câmera não suportada neste navegador. Tente Chrome, Firefox ou Safari.';
          break;
        case 'NotReadableError':
          errorMessage = 'Câmera está sendo usada por outro aplicativo. Feche outros apps que usam a câmera e tente novamente.';
          break;
        case 'OverconstrainedError':
          errorMessage = 'Configurações de câmera não compatíveis com o dispositivo.';
          break;
        case 'SecurityError':
          errorMessage = 'Erro de segurança. Certifique-se de estar acessando via HTTPS.';
          break;
        case 'TypeError':
          errorMessage = 'Erro de tipo. Navegador pode não suportar esta funcionalidade.';
          break;
        default:
          if (error.message) {
            errorMessage = `Erro ao acessar câmera: ${error.message}`;
          }
      }
      
      setError(errorMessage);
      return false;
    }
  };

  // Função alternativa usando input de arquivo para dispositivos sem câmera
  const handleFileUpload = (event: React.ChangeEvent<HTMLInputElement>) => {
    const file = event.target.files?.[0];
    if (!file) return;

    // Verificar se é uma imagem
    if (!file.type.startsWith('image/')) {
      setError('Por favor, selecione um arquivo de imagem.');
      return;
    }

    // Usar Html5Qrcode para ler QR code de arquivo
    const html5QrCode = new Html5Qrcode('qr-file-reader');
    
    html5QrCode.scanFile(file, true)
      .then((decodedText) => {
        try {
          console.log('QR Code detectado no arquivo:', decodedText);
          const nfeKey = extractNFeKeyFromQRCode(decodedText);
          setNfChaveFilter(nfeKey);
          setError(null);
          
          // Auto consultar após scan bem sucedido
          setTimeout(() => {
            if (cliente) {
              CupomConsultar(nfeKey);
            }
          }, 500);
          
        } catch (e: any) {
          console.error('Erro ao processar QR Code do arquivo:', e);
          setError(e.message || 'Erro ao processar QR Code do arquivo');
        }
      })
      .catch((error) => {
        console.error('Erro ao ler QR Code do arquivo:', error);
        setError('Nenhum QR Code encontrado na imagem. Certifique-se de que a imagem contém um QR Code válido.');
      });
  };

  // Inicializar QR Code Scanner - VERSÃO COM FALLBACK
  const startQrScanner = async () => {
    try {
      // Limpar erros anteriores
      setError(null);
      
      // Parar scanner anterior se existir
      if (qrScanner) {
        stopQrScanner();
      }

      console.log('Verificando suporte à câmera...');
      
      // Verificar se a API de mídia é suportada
      const isMediaSupported = typeof navigator !== 'undefined' && 
                               navigator.mediaDevices && 
                               navigator.mediaDevices.getUserMedia;
      

      if (!isMediaSupported) {
        // Fallback: mostrar opção de upload de arquivo
        setError('Câmera não suportada neste navegador. Use a opção "Selecionar Imagem" abaixo.');
        return;
      }

      // Solicitar permissão de câmera
      const hasPermission = await requestCameraPermission();
      
      if (!hasPermission) {
        console.log('Permissão de câmera negada ou não disponível');
        return;
      }

      console.log('Permissão concedida, inicializando scanner...');
      
      // Mostrar o modal do scanner
      setShowQrScanner(true);
      
      // Aguardar o DOM ser atualizado antes de inicializar o scanner
      setTimeout(() => {
        try {
          const scanner = new Html5QrcodeScanner(
            qrCodeRegionId,
            {
              fps: 10,
              qrbox: { width: 250, height: 250 },
              aspectRatio: 1.0,
              showTorchButtonIfSupported: true,
              showZoomSliderIfSupported: true,
              defaultZoomValueIfSupported: 1,
              // Configurações para melhor compatibilidade
              rememberLastUsedCamera: true,
              supportedScanTypes: [Html5QrcodeScanType.SCAN_TYPE_CAMERA],
              // Configurações menos restritivas
              experimentalFeatures: {
                useBarCodeDetectorIfSupported: false
              }
            },
            false
          );

          scanner.render(
            (decodedText) => {
              try {
                console.log('QR Code detectado:', decodedText);
                const nfeKey = extractNFeKeyFromQRCode(decodedText);
                setNfChaveFilter(nfeKey);
                stopQrScanner();
                setError(null);
                
                // Auto consultar após scan bem sucedido
                setTimeout(() => {
                  if (cliente) {
                    CupomConsultar(nfeKey);
                  }
                }, 500);
                
              } catch (e: any) {
                console.error('Erro ao processar QR Code:', e);
                setError(e.message || 'Erro ao processar QR Code');
              }
            },
            (errorMessage) => {
              // Silenciar erros de scan contínuo que são normais
              if (!errorMessage.includes('NotFoundException') && 
                  !errorMessage.includes('NotFoundError')) {
                console.log('QR Scan Error:', errorMessage);
              }
            }
          );

          setQrScanner(scanner);
          console.log('Scanner inicializado com sucesso');
          
        } catch (initError: any) {
          console.error('Erro ao inicializar scanner:', initError);
          setError('Erro ao inicializar leitor de QR Code. Tente a opção "Selecionar Imagem".');
          setShowQrScanner(false);
        }
      }, 300);
      
    } catch (error: any) {
      console.error('Erro geral no startQrScanner:', error);
      setError('Erro ao iniciar leitor de QR Code. Tente a opção "Selecionar Imagem".');
      setShowQrScanner(false);
    }
  };

  // Parar QR Code Scanner
  const stopQrScanner = () => {
    if (qrScanner) {
      qrScanner.clear().catch((error) => {
        console.log('Erro ao limpar scanner:', error);
      });
      setQrScanner(null);
    }
    setShowQrScanner(false);
  };

  const consultarTemporadaAtiva = async () => {
    if (!moduleRef.current ) {
      console.log('Módulos não inicializados ainda')
      return
    }

    try {
      setLoading(true)
      setError(null)

      // Depois, consultar temporada ativa
      const responseTemporada = await moduleRef.current.ConsultarTemporadaAtiva({})
      if (!responseTemporada) {
        throw new Error('Erro ao consultar temporada ativa')
      }
      setTemporadaAtiva(responseTemporada)
    
    } catch (e: any) {
      setError(e.message || 'Erro desconhecido ao consultar temporada ativa')
    } finally {
      setLoading(false)
    }
  }

  const CupomConsultar = async (chaveOverride?: string) => { 
    setPermiteLancarCupom(false)
    if (!moduleRef.current) {
      setError('Sistema não inicializado')
      return
    }

    const chaveParaConsultar = chaveOverride || nf_chave_filter

    try { 
      if (!cliente || !cliente.cpf) {
        throw new Error('Participante ou CPF não informado para consulta de cupons do sorteio')
      }

      if (tipoConsulta === 'chave' && (!chaveParaConsultar || chaveParaConsultar.length !== 44)) {
        throw new Error('Chave da NFe deve ter exatamente 44 dígitos')
      }

      setLoadingCupom(true)
      setError(null)
      
      const listCupons = await moduleRef.current.ConsultarCupomDisponivel(
        { nf_chave: chaveParaConsultar,
          nf_numero: nf_numero_filter.trim() ? nf_numero_filter.trim() : undefined,
          data_emissao: nf_data_filter.trim() ? nf_data_filter.trim() : undefined,
          sat_ecf: nf_pdv_filter.trim() ? nf_pdv_filter.trim() : undefined


        })
      
      if (listCupons.length === 0) {
        throw new Error('Chave não encontrada ou não disponível para o seu CPF')
      }
      
      setCupom(listCupons[0])
        if (listCupons.length > 0) {

        console.log('Cupom encontrado:', listCupons[0]?.crm_so_cpf, cliente?.cpf)
        
        if (listCupons[0]?.crm_so_cpf.padStart(14, '0') === cliente?.cpf.padStart(14, '0')) {
          throw new Error('Este cupom já foi registrado para o sorteio com o seu CPF')
        } else { 
          setPermiteLancarCupom(true)
        }
      }

    } catch (e: any) {
      setError(e.message || 'Erro desconhecido ao consultar cupons do sorteio')
      setCupom(null)
    } finally {
      setLoadingCupom(false)
    }
  }

  const CupomLimpar = () => { 
    setCupom(null)
    setNfChaveFilter('')
    setError(null)
  }

    const formatarData = (value: string) => {
    // Remove tudo que não é número
    const numbers = value.replace(/\D/g, '')
    
    // Aplica a máscara DD/MM/AAAA
    if (numbers.length <= 2) {
      return numbers
    } else if (numbers.length <= 4) {
      return `${numbers.slice(0, 2)}/${numbers.slice(2)}`
    } else {
      return `${numbers.slice(0, 2)}/${numbers.slice(2, 4)}/${numbers.slice(4, 8)}`
    }
  }

  const podeConsultar = () => {
    if (tipoConsulta === 'chave') {
      return nf_chave_filter.trim() && nf_chave_filter.length === 44
    } else {
      return nf_numero_filter.trim() && nf_data_filter.trim() && nf_pdv_filter.trim() && nf_data_filter.length === 10
    }
  }

  const registrarCupomParaSorteio = async() => { 
    if (!moduleRef.current) {
      setError('Sistema não inicializado')
      return
    }

    try { 
      if (!Cupom?.nf_numero) {
        throw new Error('Nenhum cupom selecionado para registro')
      }

      setLoadingCupom(true)
      setError(null)
      
      const cupomParaRegistrar = {...Cupom}
      cupomParaRegistrar.crm_so_cpf =  cliente?.cpf || ''
      
      await moduleRef.current.RegistrarCupom(cupomParaRegistrar)
      
      // Mostrar popup de sucesso
      setShowSuccessPopup(true)
      
      // Aguardar 2 segundos e depois limpar tudo
      setTimeout(() => {
        setShowSuccessPopup(false)
        CupomLimpar()
      }, 2000)

    } catch(e: any) {
      setError(e.message || 'Erro desconhecido ao registrar cupom para o sorteio')
      console.log('Erro ao registrar cupom para o sorteio', e)  
    } finally { 
      setLoadingCupom(false)
    }
  }

  const NumeroSorteioConsultar = async () => {
    if (!moduleRef.current) {
      setError('Sistema não inicializado')
      return
    }

    try { 
      if (!cliente || !cliente.cpf) {
        throw new Error('Cliente ou CPF não informado para consulta de números do sorteio')
      }

      const listNumeros = await moduleRef.current.consultarNumero({crm_so_cpf: cliente?.cpf || ''})
      setListNumeros(listNumeros)
      setError(null)
    } catch (e: any) {
      setError(e.message || 'Erro desconhecido ao consultar números do sorteio')
    }
  }

  // Se o contexto de autenticação ainda está carregando
  if (authLoading) {
    return (
      <div className="min-h-screen bg-gradient-to-br from-purple-50 to-blue-50 flex items-center justify-center">
        <div className="text-center">
          <div className="animate-spin rounded-full h-12 w-12 border-4 border-purple-500 border-t-transparent mx-auto mb-4"></div>
          <p className="text-gray-600 font-medium">Carregando autenticação...</p>
          <p className="text-gray-500 text-sm mt-2">Aguarde um momento</p>
        </div>
      </div>
    )
  }

  // Se ainda não foi inicializado, mostrar loading
  if (!initialized || !user) {
    return (
      <div className="min-h-screen bg-gradient-to-br from-purple-50 to-blue-50 flex items-center justify-center">
        <div className="text-center">
          <div className="animate-spin rounded-full h-12 w-12 border-4 border-purple-500 border-t-transparent mx-auto mb-4"></div>
          <p className="text-gray-600 font-medium">Inicializando sistema...</p>
          <p className="text-gray-500 text-sm mt-2">
            {!user ? 'Verificando autenticação...' : 'Carregando módulos...'}
          </p>
        </div>
      </div>
    )
  }

 return (
    <div className="min-h-screen bg-gradient-to-br from-purple-50 to-blue-50">
      
      {/* ...existing popups... */}

      {/* ...existing header... */}

      <main className="max-w-7xl mx-auto px-4 py-8 space-y-8">
        
        {/* ======================================= */}
        {/* SEÇÃO 2: CONSULTA E LANÇAMENTO CUPOM   */}
        {/* ======================================= */}
        <section className="bg-white rounded-xl shadow-lg border">
          <div className="bg-gradient-to-r from-blue-600 to-purple-600 text-white p-6 rounded-t-xl">
            <div className="flex items-center space-x-3">
              <div className="bg-white bg-opacity-20 rounded-full p-3">
                <span className="text-2xl">🎫</span>
              </div>
              <div>
                <h2 className="text-2xl font-bold">Consultar e Registrar Cupom</h2>
                <p className="text-blue-100">
                  {tipoConsulta === 'chave' 
                    ? (isMobile ? "Digite a chave ou escaneie o QR Code da NFe" : "Digite a chave da NFe para verificar elegibilidade")
                    : "Informe o número, data e PDV da Nota Fiscal"
                  }
                </p>
              </div>
            </div>
          </div>
          
          <div className="p-6">
            {/* Seletor de Tipo de Consulta */}
            <div className="mb-6">
              <label className="block text-sm font-medium text-gray-700 mb-3">
                Escolha o método de consulta: (Atual: {tipoConsulta})
              </label>
              <div className="flex flex-wrap gap-4">
                <button
                  onClick={() => {
                    setTipoConsulta('chave')
                    CupomLimpar()
                  }}
                  className={`px-6 py-3 rounded-lg font-medium transition-colors flex items-center space-x-2 min-w-max ${
                    tipoConsulta === 'chave'
                      ? 'bg-blue-600 text-white shadow-lg'
                      : 'bg-gray-100 text-gray-700 hover:bg-gray-200'
                  }`}
                >
                  <span>🔗</span>
                  <span>Chave da NFe</span>
                </button>
                <button
                  onClick={() => {
                    setTipoConsulta('dados')
                    CupomLimpar()
                  }}
                  className={`px-6 py-3 rounded-lg font-medium transition-colors flex items-center space-x-2 min-w-max ${
                    tipoConsulta === 'dados'
                      ? 'bg-purple-600 text-white shadow-lg'
                      : 'bg-gray-100 text-gray-700 hover:bg-gray-200'
                  }`}
                >
                  <span>📋</span>
                  <span>Dados da NFe</span>
                </button>
              </div>
            </div>

            {/* Formulário por Chave */}
            {tipoConsulta === 'chave' && (
              <div className="grid grid-cols-1 lg:grid-cols-12 gap-4 items-end mb-6">
                <div className="lg:col-span-8">
                  <label htmlFor="nf_chave" className="block text-sm font-medium text-gray-700 mb-2">
                    Chave da Nota Fiscal (44 dígitos)
                  </label>
                  <input
                    type="text"
                    id="nf_chave"
                    className="w-full px-4 py-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 font-mono text-sm text-black"
                    placeholder="Digite a chave da NFe (44 dígitos)"
                    value={nf_chave_filter}
                    onChange={(e) => setNfChaveFilter(e.target.value.replace(/\D/g, '').slice(0, 44))}
                    disabled={loadingCupom}
                    maxLength={44}
                  />
                  <p className="text-xs text-gray-500 mt-1">
                    {nf_chave_filter.length}/44 dígitos
                  </p>
                </div>
                
                <div className="lg:col-span-4 flex space-x-2">
                  {/* Botão QR Code (apenas mobile) */}
                  {isMobile && (
                    <button
                      onClick={startQrScanner}
                      disabled={loadingCupom}
                      className="bg-purple-600 hover:bg-purple-700 disabled:bg-gray-400 text-white px-4 py-3 rounded-lg flex items-center justify-center space-x-2 transition-colors"
                      title="Escanear QR Code - Requer permissão de câmera"
                    >
                      <span>📱</span>
                      <span className="hidden sm:inline">QR Code</span>
                    </button>
                  )}
                  
                  <button
                    onClick={() => CupomConsultar()}
                    disabled={loadingCupom || !podeConsultar()}
                    className="flex-1 bg-blue-600 hover:bg-blue-700 disabled:bg-gray-400 text-white px-4 py-3 rounded-lg flex items-center justify-center space-x-2 transition-colors"
                  >
                    {loadingCupom ? (
                      <>
                        <div className="animate-spin rounded-full h-4 w-4 border-2 border-white border-t-transparent"></div>
                        <span>Consultando...</span>
                      </>
                    ) : (
                      <>
                        <span>🔍</span>
                        <span>Consultar</span>
                      </>
                    )}
                  </button>
                  
                  <button
                    disabled={loadingCupom}
                    className="px-4 py-3 border border-gray-300 bg-white hover:bg-gray-50 text-gray-700 rounded-lg transition-colors"
                    title="Limpar consulta"
                    onClick={CupomLimpar}
                  >
                    <span>🗑️</span>
                  </button>
                </div>
              </div>
              
            )}
                        {/* Mensagem de Erro */}
            {ErrorMessage && (
              <div className="bg-red-50 border border-red-200 rounded-lg p-4 mb-6">
                <div className="flex items-start space-x-3">
                  <span className="text-red-500 text-xl flex-shrink-0">❌</span>
                  <div className="flex-1">
                    <h3 className="text-red-800 font-medium mb-1">Erro</h3>
                    <p className="text-red-700 text-sm leading-relaxed">{ErrorMessage}</p>
                  </div>
                  <button
                    onClick={() => setError(null)}
                    className="text-red-400 hover:text-red-600 transition-colors flex-shrink-0"
                    title="Fechar mensagem"
                  >
                    <span className="text-lg">✕</span>
                  </button>
                </div>
              </div>
            )}
          {/* Formulário por Dados */}
            {tipoConsulta === 'dados' && (
              <div className="space-y-4 mb-6">
                <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
                  <div>
                    <label htmlFor="nf_numero" className="block text-sm font-medium text-gray-700 mb-2">
                      Número da Nota Fiscal *
                    </label>
                    <input
                      type="text"
                      id="nf_numero"
                      className="w-full px-4 py-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-purple-500 focus:border-purple-500 text-black"
                      placeholder="Ex: 123456"
                      value={nf_numero_filter}
                      onChange={(e) => setNfNumeroFilter(e.target.value.replace(/\D/g, ''))}
                      disabled={loadingCupom}
                    />
                  </div>
                  <div>
                    <label htmlFor="nf_pdv" className="block text-sm font-medium text-gray-700 mb-2">
                      Série (N. Pdv) *
                    </label>
                    <input
                      type="text"
                      id="nf_pdv"
                      className="w-full px-4 py-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-purple-500 focus:border-purple-500 text-black"
                      placeholder="Ex: 001"
                      value={nf_pdv_filter}
                      onChange={(e) => setNfPdvFilter(e.target.value.replace(/\D/g, ''))}
                      disabled={loadingCupom}
                    />
                  </div>                  
                  
                  <div>
                    <label htmlFor="nf_data" className="block text-sm font-medium text-gray-700 mb-2">
                      Data da Venda *
                    </label>
                    <input
                      type="text"
                      id="nf_data"
                      className="w-full px-4 py-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-purple-500 focus:border-purple-500 text-black"
                      placeholder="DD/MM/AAAA"
                      value={nf_data_filter}
                      onChange={(e) => setNfDataFilter(formatarData(e.target.value))}
                      disabled={loadingCupom}
                      maxLength={10}
                    />
                  </div>
                  

                </div>
                
                <div className="flex justify-end space-x-4">
                  <button
                    disabled={loadingCupom}
                    className="px-6 py-3 border border-gray-300 bg-white hover:bg-gray-50 text-gray-700 rounded-lg transition-colors flex items-center space-x-2"
                    onClick={CupomLimpar}
                  >
                    <span>🗑️</span>
                    <span>Limpar</span>
                  </button>
                  
                  <button
                    onClick={() => CupomConsultar()}
                    disabled={loadingCupom || !podeConsultar()}
                    className="bg-purple-600 hover:bg-purple-700 disabled:bg-gray-400 text-white px-6 py-3 rounded-lg flex items-center justify-center space-x-2 transition-colors"
                  >
                    {loadingCupom ? (
                      <>
                        <div className="animate-spin rounded-full h-4 w-4 border-2 border-white border-t-transparent"></div>
                        <span>Consultando...</span>
                      </>
                    ) : (
                      <>
                        <span>🔍</span>
                        <span>Consultar Cupom</span>
                      </>
                    )}
                  </button>
                </div>
              </div>
            )}


            {Cupom && permiteLancarCupom && (
              <div className="bg-green-50 border border-green-200 rounded-lg p-6">
                <div className="flex items-center justify-between mb-4">
                  <div className="flex items-center space-x-2">
                    <span className="text-green-600 text-xl">✅</span>
                    <h3 className="text-xl font-bold text-green-800">Cupom Válido Encontrado</h3>
                  </div>
                  <button
                    onClick={registrarCupomParaSorteio}
                    disabled={loadingCupom}
                    className="bg-green-600 hover:bg-green-700 disabled:bg-gray-400 text-white px-6 py-2 rounded-lg flex items-center space-x-2 transition-colors font-medium"
                  >
                    {loadingCupom ? (
                      <>
                        <div className="animate-spin rounded-full h-4 w-4 border-2 border-white border-t-transparent"></div>
                        <span>Consultando</span>
                      </>
                    ) : (
                      <>
                        <span>📝</span>
                        <span>Registrar para Sorteio</span>
                      </>
                    )}
                  </button>
                </div>
                
                              <div className="grid grid-cols-2 md:grid-cols-5 gap-4">
                  <div className="bg-white rounded-lg p-4 border border-green-200">
                    <label className="block text-sm font-medium text-gray-600 mb-1">Número NF</label>
                    <p className="text-lg font-bold text-gray-800">
                      {Cupom.nf_numero || '-'}
                    </p>
                  </div>
                  
                  <div className="bg-white rounded-lg p-4 border border-green-200">
                    <label className="block text-sm font-medium text-gray-600 mb-1">Data de Emissão</label>
                    <p className="text-lg font-bold text-gray-800">
                      {Cupom.nf_data_emissao 
                        ? new Date(Cupom.nf_data_emissao).toLocaleDateString('pt-BR')
                        : '-'
                      }
                    </p>
                  </div>
                  
                  <div className="bg-white rounded-lg p-4 border border-green-200">
                    <label className="block text-sm font-medium text-gray-600 mb-1">Valor</label>
                    <p className="text-xl font-bold text-green-600">
                      R$ {Cupom.valor && !isNaN(Number(Cupom.valor)) 
                        ? Number(Cupom.valor).toLocaleString('pt-BR', { minimumFractionDigits: 2 })
                        : '0,00'
                      }
                    </p>
                  </div>
                  
                  <div className="bg-white rounded-lg p-4 border border-green-200">
                    <label className="block text-sm font-medium text-gray-600 mb-1">CPF/CNPJ</label>
                    <p className="text-sm font-mono text-gray-800">
                      {Cupom.cpf_cnpj || '-'}
                    </p>
                  </div>

                  <div className="bg-white rounded-lg p-4 border border-green-200">
                    <label className="block text-sm font-medium text-gray-600 mb-1">Série/ECF</label>
                    <p className="text-sm font-mono text-gray-800">
                      {Cupom.sat_ecf || '-'}
                    </p>
                  </div>
                </div>
              </div>
              )}

  

            {/* Dica baseada no tipo de consulta */}
            <div className="bg-blue-50 border border-blue-200 rounded-lg p-4 mb-6">
              <div className="flex items-center space-x-2">
                <span className="text-blue-600 text-xl">💡</span>
                <div>
                  <p className="text-blue-800 font-medium">
                    {tipoConsulta === 'chave' ? 'Consulta por Chave' : 'Consulta por Dados'}
                  </p>
                  <p className="text-blue-700 text-sm">
                    {tipoConsulta === 'chave' 
                      ? isMobile 
                        ? 'Digite a chave de 44 dígitos ou use o botão QR Code para escanear automaticamente!'
                        : 'Digite a chave de 44 dígitos da sua nota fiscal encontrada no QR Code.'
                      : 'Preencha o número da nota, data de emissão (DD/MM/AAAA) e número do PDV. Estas informações estão no cabeçalho da sua nota fiscal.'
                    }
                  </p>
                </div>
              </div>
            </div>
            
            {/* ...existing resultado da consulta e error... */}

          </div>
        </section>
        <section className="bg-white rounded-xl shadow-lg border">
          <div className="bg-gradient-to-r from-purple-600 to-blue-600 text-white p-6 rounded-t-xl">
            <div className="flex items-center justify-between">
              <div className="flex items-center space-x-3">
                <div className="bg-white bg-opacity-20 rounded-full p-3">
                  <span className="text-2xl">🎲</span>
                </div>
                <div>
                  <h2 className="text-2xl font-bold">Meus Números da Sorte</h2>
                  <p className="text-purple-100">Números gerados a partir dos seus cupons registrados</p>
                </div>
              </div>
              
              <div className="flex items-center space-x-4">
                <span className="bg-blue-600 bg-opacity-20 text-white px-4 py-2 rounded-full text-sm font-medium">
                  {ListNumeros.length} número(s)
                </span>
                <button
                  onClick={NumeroSorteioConsultar}
                  disabled={loading || !cliente}
                  className="bg-blue-600 hover:bg-blue-700 disabled:bg-gray-400 text-white px-4 py-3 rounded-lg flex items-center justify-center space-x-2 transition-colors"
                >
                  <span>🔄</span>
                  <span>Atualizar</span>
                </button>
              </div>
            </div>
          </div>
          
          <div className="p-6">
            {ListNumeros.length > 0 ? (
              (() => {
                // Agrupar números por dados duplicados
                const gruposNumeros = ListNumeros.reduce((grupos, numero) => {
                  const chave = `${numero.valor}_${numero.nf_data_emissao}_${numero.nf_numero}_${numero.cpf_cnpj}_${numero.nf_chave}`;
                  if (!grupos[chave]) {
                    grupos[chave] = {
                      dadosComuns: numero,
                      numeros: []
                    };
                  }
                  grupos[chave].numeros.push(numero.numero);
                  return grupos;
                }, {} as any);

                return (
                  <div className="overflow-x-auto">
                    <table className="w-full">
                      <thead className="bg-gradient-to-r from-purple-600 to-blue-600 text-white">
                        <tr>
                          <th className="px-6 py-4 text-left text-xs font-medium uppercase tracking-wider">
                            Valor
                          </th>
                          <th className="px-6 py-4 text-left text-xs font-medium uppercase tracking-wider">
                            Data NF
                          </th>
                          <th className="px-6 py-4 text-left text-xs font-medium uppercase tracking-wider">
                            NF
                          </th>
                          <th className="px-6 py-4 text-left text-xs font-medium uppercase tracking-wider">
                            CPF/CNPJ
                          </th>
                          <th className="px-6 py-4 text-left text-xs font-medium uppercase tracking-wider">
                            Números da Sorte
                          </th>
                        </tr>
                      </thead>
                      <tbody className="divide-y divide-gray-200">
                        {Object.values(gruposNumeros).map((grupo: any, index: number) => (
                          <tr 
                            key={index}
                            className={`hover:bg-gradient-to-r hover:from-purple-50 hover:to-blue-50 transition-colors ${
                              index % 2 === 0 ? 'bg-white' : 'bg-gray-50'
                            }`}
                          >
                            <td className="px-6 py-4 whitespace-nowrap">
                              <span className="font-bold text-green-600 bg-green-50 px-3 py-1 rounded-full">
                                R$ {grupo.dadosComuns.valor && !isNaN(Number(grupo.dadosComuns.valor)) ? Number(grupo.dadosComuns.valor).toFixed(2) : '0,00'}
                              </span>
                            </td>
                            <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-900 font-medium">
                              {grupo.dadosComuns.nf_data_emissao 
                                ? new Date(grupo.dadosComuns.nf_data_emissao).toLocaleDateString('pt-BR')
                                : '-'
                              }
                            </td>
                            <td className="px-6 py-4 whitespace-nowrap">
                              {grupo.dadosComuns.nf_numero ? (
                                <span className="bg-blue-50 text-blue-800 px-3 py-1 rounded-full text-sm font-medium">
                                  {grupo.dadosComuns.nf_numero}
                                </span>
                              ) : '-'}
                            </td>
                            <td className="px-6 py-4 whitespace-nowrap text-xs text-gray-900 font-mono">
                              {grupo.dadosComuns.cpf_cnpj || '-'}
                            </td>
                            <td className="px-6 py-4">
                              <div className="grid grid-cols-3 gap-2 max-w-md">
                                {grupo.numeros.map((numero: number, idx: number) => (
                                  <div 
                                    key={idx}
                                    className="text-lg font-bold text-white bg-gradient-to-r from-purple-500 to-blue-500 rounded-lg px-3 py-2 text-center shadow-md"
                                  >
                                    {String(numero).padStart(6, '0')}
                                  </div>
                                ))}
                              </div>
                              <div className="text-xs text-gray-500 mt-2 font-medium">
                                🎯 {grupo.numeros.length} número(s) gerado(s)
                              </div>
                            </td>
                          </tr>
                        ))}
                      </tbody>
                    </table>
                  </div>
                );
              })()
            ) : (
              <div className="text-center py-16">
                <div className="text-gray-300 text-8xl mb-6">🎫</div>
                <h3 className="text-xl font-bold text-gray-600 mb-2">Nenhum número encontrado</h3>
                <p className="text-gray-500 text-lg mb-4">
                  Você ainda não possui números para esta temporada de sorteio.
                </p>
                <p className="text-gray-400">
                  Registre seus cupons fiscais para gerar números da sorte!
                </p>
              </div>
            )}
          </div>
        </section>

      </main>
    </div>
  )
}