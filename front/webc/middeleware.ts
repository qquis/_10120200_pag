import { NextResponse } from 'next/server';
import type { NextRequest } from 'next/server';


function ResponseAutorizado () : () => NextResponse { 
    return () => {
        const response = NextResponse.next();
        response.headers.set('X-Content-Type-Options', 'nosniff');
        response.headers.set('X-Frame-Options', 'DENY');
        response.headers.set('X-XSS-Protection', '1; mode=block');
        response.headers.set('Referrer-Policy', 'strict-origin-when-cross-origin');
        response.headers.set('Permissions-Policy', 'camera=(), microphone=(), geolocation=()');
        
        // CSP (Content Security Policy)
        response.headers.set(
          'Content-Security-Policy',
          "default-src 'self'; script-src 'self' 'unsafe-eval' 'unsafe-inline'; style-src 'self' 'unsafe-inline'; img-src 'self' data: https:; font-src 'self'"
        );
        
        return response;
    }
}



export function middleware(request: NextRequest) {
  const { pathname } = request.nextUrl;

  

  const responseAutorizado = ResponseAutorizado()

  
 
  // Rotas públicas que não precisam de autenticação
  const publicRoutes = ['/', '/pages/login', '/pages/logincode'];
  
  // Se for rota pública, permitir acesso
  if (publicRoutes.includes(pathname)) {
    console.log(`✅ Rota pública permitida: ${pathname}`);
    //return NextResponse.next();
    return responseAutorizado
  }

  // Verificar se tem JWT no cookie
  const userCredential = request.cookies.get('user_credential')?.value;
  
  if (!userCredential || userCredential.trim() === '') {
    //console.log(`❌ JWT não encontrado no middleware para rota: ${pathname}`);
    //console.log(`🔄 Redirecionando para /pages/login`);
    
    // Redirecionar para login se não tiver JWT
    return NextResponse.redirect(new URL('/pages/login', request.url));
  }

  //console.log(`✅ JWT encontrado, permitindo acesso à rota: ${pathname}`);
  //return NextResponse.next();
  return responseAutorizado
}

// Configuração do middleware - define quais rotas ele deve interceptar
export const config = {
  matcher: [
    /*
     * Intercepta todas as rotas EXCETO:
     * - api (rotas da API)
     * - _next/static (arquivos estáticos do Next.js)
     * - _next/image (otimização de imagens)
     * - favicon.ico (ícone do site)
     */
    '/((?!api|_next/static|_next/image|favicon.ico).*)',
  ],
};

