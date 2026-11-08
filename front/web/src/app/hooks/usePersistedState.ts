'use client'
import { useEffect, useState, useCallback } from 'react';
import { usePageState } from '@/app/context/PageStatesContext';
import { usePathname } from 'next/navigation';

export const usePersistedState = <T>(key: string, initialValue: T) => {
  const { getPageState, setPageState } = usePageState();
  const pathname = usePathname();
  
  // Recupera o estado salvo ou usa o valor inicial
  const savedState = getPageState(pathname);
  const [state, setState] = useState<T>(() => {
    return savedState?.[key] !== undefined ? savedState[key] : initialValue;
  });

  // Salva o estado sempre que ele mudar
  const setPersistedState = useCallback((newState: T | ((prev: T) => T)) => {
    setState(prev => {
      const updatedState = typeof newState === 'function' ? (newState as (prev: T) => T)(prev) : newState;
      
      // Salva no context da página
      setPageState(pathname, { [key]: updatedState });
      
      return updatedState;
    });
  }, [key, pathname, setPageState]);

  // Carrega o estado quando a página muda
  useEffect(() => {
    const savedPageState = getPageState(pathname);
    if (savedPageState?.[key] !== undefined) {
      setState(savedPageState[key]);
    }
  }, [pathname, key, getPageState]);

  return [state, setPersistedState] as const;
};
