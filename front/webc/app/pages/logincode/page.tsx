'use client';

import { useState, useEffect, useRef } from 'react';
import { useRouter, useSearchParams } from 'next/navigation';
import { useAuth } from '../../context/context';
import { moduleParticipanteCrm, TpParticipanteCRM } from '@/app/api/m0011_participante/moduleparticipante';


export default function LoginCodePage() {
  const [code, setCode] = useState('');
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');
  const [email, setEmail] = useState('');
  const [attempts, setAttempts] = useState(0);
  const [isBlocked, setIsBlocked] = useState(false);
  const [timeLeft, setTimeLeft] = useState(0);
  const [resendAttempts, setResendAttempts] = useState(0);
  const [isWaiting, setIsWaiting] = useState(false);
  const [waitTimeLeft, setWaitTimeLeft] = useState(0);
  
  const router = useRouter();
  const { user, login_getcredentialnumber, login } = useAuth();
  const blockTimeoutRef = useRef<NodeJS.Timeout | null>(null);
  const waitTimeoutRef = useRef<NodeJS.Timeout | null>(null);

  // Configurações de segurança
  const MAX_ATTEMPTS = 5;
  const MAX_RESEND_ATTEMPTS = 3;
  const BLOCK_TIME = 300000; // 5 minutos
  const CODE_EXPIRY_TIME = 600000; // 10 minutos
  
  // Delays progressivos por tentativa (em segundos)
  const WAIT_DELAYS = [0, 3, 5, 10, 15, 30]; // 0s, 3s, 5s, 10s, 15s, 30s

  useEffect(() => {
    setEmail(user.email_main);
    
    // Verificar se há bloqueio ativo no localStorage
    const blockData = localStorage.getItem('loginBlock');
    if (blockData) {
      const { blockUntil, attempts: savedAttempts } = JSON.parse(blockData);
      const now = Date.now();
      
      if (now < blockUntil) {
        setIsBlocked(true);
        setAttempts(savedAttempts);
        setTimeLeft(Math.ceil((blockUntil - now) / 1000));
        startCountdown(blockUntil);
      } else {
        localStorage.removeItem('loginBlock');
      }
    }

    // Verificar se há espera ativa
    const waitData = localStorage.getItem('loginWait');
    if (waitData) {
      const { waitUntil, attempts: savedAttempts } = JSON.parse(waitData);
      const now = Date.now();
      
      if (now < waitUntil) {
        setIsWaiting(true);
        setAttempts(savedAttempts);
        setWaitTimeLeft(Math.ceil((waitUntil - now) / 1000));
        startWaitCountdown(waitUntil);
      } else {
        localStorage.removeItem('loginWait');
      }
    }

    // Verificar tentativas de reenvio
    const resendData = localStorage.getItem('resendAttempts');
    if (resendData) {
      const { count, timestamp } = JSON.parse(resendData);
      const hoursPassed = (Date.now() - timestamp) / (1000 * 60 * 60);
      
      if (hoursPassed < 1) {
        setResendAttempts(count);
      } else {
        localStorage.removeItem('resendAttempts');
      }
    }
  }, []);

  const startCountdown = (blockUntil: number) => {
    const updateTimer = () => {
      const now = Date.now();
      const remaining = Math.ceil((blockUntil - now) / 1000);
      
      if (remaining <= 0) {
        setIsBlocked(false);
        setTimeLeft(0);
        setAttempts(0);
        localStorage.removeItem('loginBlock');
        if (blockTimeoutRef.current) {
          clearInterval(blockTimeoutRef.current);
        }
      } else {
        setTimeLeft(remaining);
      }
    };

    blockTimeoutRef.current = setInterval(updateTimer, 1000);
    updateTimer();
  };

  const startWaitCountdown = (waitUntil: number) => {
    const updateTimer = () => {
      const now = Date.now();
      const remaining = Math.ceil((waitUntil - now) / 1000);
      
      if (remaining <= 0) {
        setIsWaiting(false);
        setWaitTimeLeft(0);
        localStorage.removeItem('loginWait');
        if (waitTimeoutRef.current) {
          clearInterval(waitTimeoutRef.current);
        }
      } else {
        setWaitTimeLeft(remaining);
      }
    };

    waitTimeoutRef.current = setInterval(updateTimer, 1000);
    updateTimer();
  };

  const handleWait = (attemptNumber: number) => {
    const waitSeconds = WAIT_DELAYS[Math.min(attemptNumber, WAIT_DELAYS.length - 1)];
    
    if (waitSeconds > 0) {
      const waitUntil = Date.now() + (waitSeconds * 1000);
      setIsWaiting(true);
      setWaitTimeLeft(waitSeconds);
      
      localStorage.setItem('loginWait', JSON.stringify({
        waitUntil,
        attempts: attemptNumber
      }));
      
      startWaitCountdown(waitUntil);
    }
  };

  const handleBlock = () => {
    const blockUntil = Date.now() + BLOCK_TIME;
    setIsBlocked(true);
    
    localStorage.setItem('loginBlock', JSON.stringify({
      blockUntil,
      attempts: attempts + 1
    }));
    
    startCountdown(blockUntil);
  };

  const formatTime = (seconds: number) => {
    const minutes = Math.floor(seconds / 60);
    const secs = seconds % 60;
    return `${minutes}:${secs.toString().padStart(2, '0')}`;
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    
    if (isBlocked) {
      setError(`Acesso bloqueado. Tente novamente em ${formatTime(timeLeft)}`);
      return;
    }

    if (isWaiting) {
      setError(`Aguarde ${waitTimeLeft} segundos antes da próxima tentativa`);
      return;
    }

    if (!code) {
      setError('Por favor, digite o código de acesso');
      return;
    }

    // Validação do formato do código
    if (!/^\d{6}$/.test(code)) {
      setError('O código deve conter 6 dígitos');
      return;
    }

    setLoading(true);
    setError('');

    try {
      // LOGIN com timeout
      const loginPromise = await login(code);
      const timeoutPromise = new Promise((_, reject) => 
        setTimeout(() => reject(new Error('Timeout')), 10000)
      );

      await Promise.race([loginPromise, timeoutPromise]);

      if (user.autorizado ===1) {
        // Limpar todas as tentativas e bloqueios em caso de sucesso
        localStorage.removeItem('loginBlock');
        localStorage.removeItem('loginWait');
        localStorage.removeItem('resendAttempts');
        


        if (user.autorizado === 1) {
          router.push(`/pages/home?email=${encodeURIComponent(user.email_main)}`);
        } else {
          router.push('/pages/home/perfil');
        }
      } else {
        throw new Error('Login failed');
      }
      
    } catch (error: any) {
      const newAttempts = attempts + 1;
      setAttempts(newAttempts);
      
      if (newAttempts >= MAX_ATTEMPTS) {
        handleBlock();
        setError(`Muitas tentativas inválidas. Acesso bloqueado por ${formatTime(BLOCK_TIME / 1000)}`);
      } else {
        // Implementar delay antes da próxima tentativa
        handleWait(newAttempts);
        
        const waitSeconds = WAIT_DELAYS[Math.min(newAttempts, WAIT_DELAYS.length - 1)];
        
        // Não expor detalhes do erro
        if (error?.message === 'Timeout') {
          setError('Tempo limite excedido. Tente novamente.');
        } else {
          const waitMessage = waitSeconds > 0 ? ` Aguarde ${waitSeconds} segundos para tentar novamente.` : '';
          setError(`Código inválido ou expirado. Tentativa ${newAttempts} de ${MAX_ATTEMPTS}.${waitMessage}`);
        }
      }
      
      // Limpar o código em caso de erro
      setCode('');
    } finally {
      setLoading(false);
    }
  };

  const handleResendCode = async () => {
    if (isBlocked) {
      setError(`Acesso bloqueado. Tente novamente em ${formatTime(timeLeft)}`);
      return;
    }

    if (isWaiting) {
      setError(`Aguarde ${waitTimeLeft} segundos antes de reenviar`);
      return;
    }

    if (resendAttempts >= MAX_RESEND_ATTEMPTS) {
      setError('Limite de reenvios atingido. Tente novamente em 1 hora.');
      return;
    }

    setLoading(true);
    setError('');
    
    try {
      const resendPromise = login_getcredentialnumber(email);
      const timeoutPromise = new Promise((_, reject) => 
        setTimeout(() => reject(new Error('Timeout')), 10000)
      );

      await Promise.race([resendPromise, timeoutPromise]);
      
      const newResendAttempts = resendAttempts + 1;
      setResendAttempts(newResendAttempts);
      
      localStorage.setItem('resendAttempts', JSON.stringify({
        count: newResendAttempts,
        timestamp: Date.now()
      }));
      
      showNotification('Novo código enviado para seu e-mail!', 'success');
      
    } catch (error: any) {
      if (error?.message === 'Timeout') {
        setError('Tempo limite excedido. Tente novamente.');
      } else {
        setError('Erro ao reenviar código. Tente novamente.');
      }
    } finally {
      setLoading(false);
    }
  };

  const showNotification = (message: string, type: 'success' | 'error') => {
    const notification = document.createElement('div');
    notification.className = `fixed top-5 right-5 ${type === 'success' ? 'bg-green-600' : 'bg-red-600'} text-white px-6 py-4 rounded-xl shadow-lg z-50 font-semibold transform translate-x-full opacity-0 transition-all duration-300`;
    notification.textContent = message;
    document.body.appendChild(notification);
    
    setTimeout(() => {
      notification.classList.remove('translate-x-full', 'opacity-0');
    }, 100);
    
    setTimeout(() => {
      notification.classList.add('translate-x-full', 'opacity-0');
      setTimeout(() => notification.remove(), 300);
    }, 3000);
  };

  // Limpeza na desmontagem do componente
  useEffect(() => {
    return () => {
      if (blockTimeoutRef.current) {
        clearInterval(blockTimeoutRef.current);
      }
      if (waitTimeoutRef.current) {
        clearInterval(waitTimeoutRef.current);
      }
    };
  }, []);

  return (
    <div className="min-h-screen bg-gradient-to-br from-red-600 to-blue-800 flex items-center justify-center p-8">
      <div className="bg-white rounded-3xl p-12 max-w-md w-full shadow-2xl">
        {/* Header */}
        <div className="text-center mb-8">
          <div className="w-20 h-20 bg-gradient-to-r from-green-600 to-green-500 rounded-2xl flex items-center justify-center mx-auto mb-4 text-white text-4xl shadow-lg shadow-green-600/30">
            📧
          </div>
          <h1 className="text-3xl font-bold text-blue-800 mb-2">Verificar Código</h1>
          <p className="text-gray-600 text-base mb-2">Digite o código enviado para:</p>
          <div className="bg-gray-100 px-4 py-2 rounded-lg text-blue-800 font-semibold text-sm">
            {email}
          </div>
          
          {/* Status de tentativas */}
          {attempts > 0 && !isBlocked && !isWaiting && (
            <div className="mt-3 text-orange-600 text-sm">
              Tentativas: {attempts}/{MAX_ATTEMPTS}
            </div>
          )}
          
          {isBlocked && (
            <div className="mt-3 text-red-600 text-sm font-semibold">
              Bloqueado por: {formatTime(timeLeft)}
            </div>
          )}

          {isWaiting && (
            <div className="mt-3 text-yellow-600 text-sm font-semibold">
              ⏳ Aguarde: {waitTimeLeft} segundos
            </div>
          )}
        </div>
        
        {/* Form */}
        <form className="space-y-6" onSubmit={handleSubmit}>
          <div className="space-y-2">
            <label htmlFor="code" className="block text-sm font-semibold text-blue-800">
              🔐 Código de Acesso
            </label>
            <input
              type="text"
              id="code"
              className="w-full px-4 py-4 text-black border-2 border-gray-200 rounded-xl text-2xl text-center tracking-widest font-bold transition-all duration-300 focus:outline-none focus:border-blue-800 focus:shadow-lg focus:shadow-blue-800/10 disabled:opacity-50 disabled:cursor-not-allowed"
              placeholder="000000"
              value={code}
              onChange={(e) => setCode(e.target.value.replace(/\D/g, '').slice(0, 6))}
              maxLength={6}
              required
              disabled={loading || isBlocked || isWaiting}
              autoComplete="one-time-code"
            />
          </div>
          
          {error && (
            <div className="text-red-600 text-sm text-center bg-red-50 p-3 rounded-lg border border-red-200">
              {error}
            </div>
          )}
          
          <button 
            type="submit" 
            className="w-full bg-gradient-to-r from-red-600 to-blue-800 text-white border-none py-4 px-8 rounded-xl text-lg font-semibold cursor-pointer transition-all duration-300 hover:shadow-xl hover:shadow-black/20 hover:-translate-y-1 disabled:opacity-70 disabled:cursor-not-allowed disabled:transform-none disabled:shadow-none"
            disabled={loading || isBlocked || isWaiting}
          >
            {loading && (
              <span className="inline-block w-5 h-5 border-2 border-white border-t-transparent rounded-full animate-spin mr-2"></span>
            )}
            {loading ? 'Verificando...' : 
             isBlocked ? `Bloqueado (${formatTime(timeLeft)})` : 
             isWaiting ? `Aguarde (${waitTimeLeft}s)` : 
             'Acessar Portal'}
          </button>
        </form>
        
        {/* Resend Section */}
        <div className="mt-6 pt-6 border-t border-gray-200 text-center">
          <p className="text-gray-600 text-sm mb-4">Não recebeu o código?</p>
          <button 
            type="button" 
            className="border-2 border-blue-800 text-blue-800 bg-transparent px-6 py-3 rounded-xl font-semibold cursor-pointer transition-all duration-300 hover:bg-blue-800 hover:text-white disabled:opacity-50 disabled:cursor-not-allowed"
            onClick={handleResendCode}
            disabled={loading || isBlocked || isWaiting || resendAttempts >= MAX_RESEND_ATTEMPTS}
          >
            {resendAttempts >= MAX_RESEND_ATTEMPTS 
              ? 'Limite atingido' 
              : `Reenviar Código (${resendAttempts}/${MAX_RESEND_ATTEMPTS})`
            }
          </button>
        </div>
        
        {/* Back Link */}
        <a 
          href="/pages/login" 
          className="block text-center mt-6 text-gray-600 text-sm hover:text-blue-800 transition-colors duration-300"
        >
          ← Voltar ao login
        </a>
      </div>
    </div>
  );
}