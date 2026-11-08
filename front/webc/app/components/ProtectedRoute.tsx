'use client';
import { useEffect, useState } from 'react';
import { useRouter, usePathname } from 'next/navigation';
import { useAuth } from '@/app/context/context';

interface ProtectedRouteProps {
  children: React.ReactNode;
}

const ProtectedRoute = ({ children }: ProtectedRouteProps) => {
  const { user, check, logout } = useAuth();
  const router = useRouter();
  const pathname = usePathname();
  const [isLoading, setIsLoading] = useState(true);
  const [isAuthenticated, setIsAuthenticated] = useState(false);

  // Rotas públicas que não precisam de autenticação
  const publicRoutes = ['/', '/pages/login', '/pages/logincode'];

  // Função para verificar se o JWT existe e não está expirado
  const checkJWTFromCookie = (): boolean => {
    if (typeof document === 'undefined') return false;
    
    const cookies = document.cookie.split(';');
    const userCredentialCookie = cookies.find(cookie => 
      cookie.trim().startsWith('user_credential=')
    );
    
    return !!userCredentialCookie && userCredentialCookie.split('=')[1]?.trim() !== '';
  };

  useEffect(() => {
    const verifyAuth = async () => {
      // Se estiver em uma rota pública, permitir acesso
      if (publicRoutes.includes(pathname)) {
        setIsAuthenticated(true);
        setIsLoading(false);
        return;
      }

      // Verificar se existe JWT no cookie
      const hasValidJWT = checkJWTFromCookie();
      
      if (!hasValidJWT) {
        console.log('JWT não encontrado ou expirado no cookie');
        logout(); // Limpar sessão
        router.push('/pages/login');
        setIsLoading(false);
        return;
      }

      // Verificar se o usuário está logado
      if (user.autorizado === 0) {
        router.push('/pages/login');
        setIsLoading(false);
        return;
      }

      // Verificar a sessão no servidor
      try {
        const isValid = await check();
        console.log('Resultado da verificação de sessão:', isValid);
        if (!isValid) {
          console.log('JWT inválido no servidor');
          router.push('/pages/login');
        } else {
          setIsAuthenticated(true);
        }
      } catch (error) {
        console.error('Erro ao verificar autenticação:', error);
        logout(); // Limpar sessão em caso de erro
        router.push('/pages/login');
      } finally {
        setIsLoading(false);
      }
    };

    verifyAuth();
  }, [pathname, user.autorizado, check, router, logout]);

  // Verificação periódica do JWT (a cada 2 minutos)
  useEffect(() => {
    if (!publicRoutes.includes(pathname) && isAuthenticated) {
      const interval = setInterval(() => {
        const hasValidJWT = checkJWTFromCookie();
        if (!hasValidJWT) {
          console.log('JWT expirou durante a sessão');
          logout();
          router.push('/pages/login');
        }
      }, 120000); // 2 minutos

      return () => clearInterval(interval);
    }
  }, [pathname, isAuthenticated, logout, router]);

  // Loading state
  if (isLoading) {
    return (
      <div style={{
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        minHeight: '50vh',
        flexDirection: 'column',
        gap: '20px'
      }}>
        <div className="w-8 h-8 border-4 border-blue-800 border-t-transparent rounded-full animate-spin"></div>
        <div className="text-gray-600">Verificando acesso...</div>
      </div>
    );
  }

  // Se não estiver autenticado e não for rota pública, não renderizar
  if (!isAuthenticated && !publicRoutes.includes(pathname)) {
    return null;
  }

  return <>{children}</>;
};

export default ProtectedRoute;