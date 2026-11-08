'use client';

import { useState } from 'react';
import { useRouter } from 'next/navigation';
import { useAuth } from '../../context/context';

export default function LoginPage() {
  const [processologin, setProcessologin] = useState(false);
  const [email, setEmail] = useState('');
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');
  const [attempts, setAttempts] = useState(0);
  const router = useRouter();
  const { user, login, login_getcredentialnumber } = useAuth();

  // Rate limiting client-side
  const MAX_ATTEMPTS = 5;
  const COOLDOWN_TIME = 300000; // 5 minutos

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    
    if (!email) {
      setError('Por favor, digite seu e-mail');
      return;
    }

    // Validação de email mais rigorosa
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(email)) {
      setError('Por favor, digite um e-mail válido');
      return;
    }

    // Rate limiting
    if (attempts >= MAX_ATTEMPTS) {
      setError('Muitas tentativas. Tente novamente em 5 minutos.');
      return;
    }

    setLoading(true);
    setError('');

    try {
      setProcessologin(true);
      await login_getcredentialnumber(email);
      
        // Navegar para página de verificação de código
        router.push(`/pages/logincode?email=${encodeURIComponent(email)}`);
      
    } catch (error: any) {
      setAttempts(prev => prev + 1);
      
      // Não expor detalhes do erro
      if (error?.response?.status === 429) {
        setError('Muitas tentativas. Tente novamente mais tarde.');
      } else if (error?.response?.status === 404) {
        setError('E-mail não encontrado');
      } else {
        setError('Erro ao processar solicitação. Tente novamente.');
      }
    } finally {
      setLoading(false);
      setProcessologin(false);
    }
  };

  return (
    <div className="min-h-screen bg-gradient-to-br from-red-600 to-blue-800 flex items-center justify-center p-8">
      <div className="bg-white rounded-3xl p-12 max-w-md w-full shadow-2xl">
        {/* Header */}
        <div className="text-center mb-8">
          <div className="w-20 h-20 rounded-2xl flex items-center justify-center mx-auto mb-4 shadow-lg shadow-blue-800/30 overflow-hidden">
            <img 
                src="/LOGO.png" 
                alt="Logo" 
                className="w-25 h-25 object-cover rounded-2xl"

            />
          </div>
          <h1 className="text-3xl font-bold text-blue-800 mb-2">Acesso ao Portal</h1>
          <p className="text-gray-600 text-base">Digite seu e-mail para receber o código de acesso</p>
        </div>
        
        {/* Form */}
        <form className="space-y-6" onSubmit={handleSubmit}>
          <div className="space-y-2">
            <label htmlFor="email" className="block text-sm font-semibold text-black">
              📧 E-mails { processologin ? 'em processamento' : 'não processados' }
            </label>
            <input
              type="email"
              id="email"
              className="w-full px-4 py-3 border-2 border-gray-200 rounded-xl text-black transition-all duration-300 focus:outline-none focus:border-blue-800 focus:shadow-lg focus:shadow-blue-800/10 disabled:opacity-50 disabled:cursor-not-allowed"
              placeholder="seu@email.com"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              required
              disabled={loading}
            />
          </div>
          
          {error && (
            <div className="text-red-600 text-sm text-center bg-red-50 p-3 rounded-lg border border-red-200">
              {error}
            </div>
          )}
          
          <button 
            type="submit" 
            className="w-full bg-gradient-to-r from-red-600 to-blue-800 text-white border-none py-4 px-8 rounded-xl text-lg font-semibold cursor-pointer transition-all duration-300 hover:shadow-xl hover:shadow-black/20 hover:-translate-y-1 disabled:opacity-70 disabled:cursor-not-allowed disabled:transform-none disabled:shadow-none relative overflow-hidden"
            disabled={loading}
          >
            {loading && (
              <span className="inline-block w-5 h-5 border-2 border-white border-t-transparent rounded-full animate-spin mr-2"></span>
            )}
            {loading ? 'Enviando...' : 'Enviar Código'}
          </button>
        </form>
        
        {/* Back Link */}
        <a 
          href="/" 
          className="block text-center mt-6 text-gray-600 text-sm hover:text-blue-800 transition-colors duration-300"
        >
          ← Voltar ao início
        </a>
      </div>
    </div>
  );
}