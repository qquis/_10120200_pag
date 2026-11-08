import React, { ReactNode, useEffect, useRef, useState } from 'react';

interface HeaderMainProps {
  tipo: "_PAGE" | "_MODAL"
  children: ReactNode;
  className?: string;
  header_title?: string;
  ActionStatus?: number;
}

const HeaderMain: React.FC<HeaderMainProps> = ({ 
  tipo = "_PAGE",
  children, 
  className = '', 
  header_title = '', 
  ActionStatus 
}) => {
 const underlineRef = useRef<HTMLDivElement>(null);
  const [isAnimating, setIsAnimating] = useState(false);
  const animationTimeoutRef = useRef<NodeJS.Timeout>();

  useEffect(() => {
    if (ActionStatus === 1) {
      setIsAnimating(true);
      // Limpa qualquer timeout anterior
      if (animationTimeoutRef.current) {
        clearTimeout(animationTimeoutRef.current);
      }
    } else if (isAnimating) {
      // Se ActionStatus não é 1 mas está animando, espera 1s para parar
      animationTimeoutRef.current = setTimeout(() => {
        setIsAnimating(false);
      }, 1000);
    }

    return () => {
      if (animationTimeoutRef.current) {
        clearTimeout(animationTimeoutRef.current);
      }
    };
  }, [ActionStatus, isAnimating]);

    const getIcone = () => {
        switch(tipo) {
            case "_PAGE":
                    return (
                        <div className={`flex justify-between bg-gray-200 rounded-lg shadow-md p-2 mb-2 border border-purple-100 ${className}`}>
                        <div className="flex flex-col w-full">
                            <h1 className="text-xl font-bold text-purple-700 mb-1 relative">
                            {header_title}
                            {ActionStatus === 1 && (
                                <div 
                                ref={underlineRef}
                                className="absolute bottom-0 left-0 h-0.5 bg-red-500 origin-left"
                                style={{
                                    width: '100%',
                                    transform: 'scaleX(0)',
                                    animation: 'grow 2s infinite'
                                }}
                                />
                            )}
                                {ActionStatus === 1 && (
                                <div
                                    role="status"
                                    aria-live="polite"
                                    className="absolute right-4 top-full mt-3 z-50 flex min-w-[280px] items-center gap-3 rounded-xl border border-blue-200 bg-slate-600 px-6 py-4 shadow-xl"
                                >
                                    <svg className="h-6 w-6 animate-spin text-red-500" viewBox="0 0 24 24" fill="none">
                                    <circle className="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="4" />
                                    <path className="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8v4a4 4 0 00-4 4H4z" />
                                    </svg>
                                    <span className="text-base font-semibold text-blue-50">Aguarde, processando...</span>
                                </div>
                                )}
                            </h1>
                        </div>
                        <div className="flex space-x-2">
                            {children}
                        </div>

                        <style jsx>{`
                            @keyframes grow {
                            0% {
                                transform: scaleX(0);
                            }
                            50% {
                                transform: scaleX(1);
                            }
                            100% {
                                transform: scaleX(0);
                            }
                            }
                        `}</style>
                        </div>
                        );
            case "_MODAL":
                    return (
                        <div className={`sticky top-0 bg-gradient-to-r from-purple-600 to-indigo-600 p-4 border-b flex justify-between items-center rounded-t-lg ${className}`}>
                        <h2 className="text-xl font-bold text-white">{header_title}</h2>
                        <h1 className="text-xl font-bold text-purple-700 mb-1 relative">
                            {ActionStatus === 1 && (
                                <div 
                                ref={underlineRef}
                                className="absolute bottom-0 left-0 h-0.5 bg-red-500 origin-left"
                                style={{
                                    width: '100%',
                                    transform: 'scaleX(0)',
                                    animation: 'grow 2s infinite'
                                }}
                                />
                            )}
                        </h1>
                        <div className="flex space-x-2">
                            {children}
                        </div>

                        <style jsx>{`
                            @keyframes grow {
                            0% {
                                transform: scaleX(0);
                            }
                            50% {
                                transform: scaleX(1);
                            }
                            100% {
                                transform: scaleX(0);
                            }
                            }
                        `}</style>
                        </div>
                        );

            default:
                return null;
        }
    };

    return getIcone();                
};

export default HeaderMain;