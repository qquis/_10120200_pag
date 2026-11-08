'use client'
import React, { createContext, useContext, useState, ReactNode, useEffect } from 'react';

interface PageState {
  [key: string]: any; // Estado genérico da página
}

interface PageStatesContextType {
  getPageState: (path: string) => PageState | undefined;
  setPageState: (path: string, state: PageState) => void;
  clearPageState: (path: string) => void;
  clearAllPageStates: () => void;
}

const PageStatesContext = createContext<PageStatesContextType | undefined>(undefined);

export function PageStatesProvider({ children }: { children: ReactNode }) {
  const [pageStates, setPageStates] = useState<{ [path: string]: PageState }>({});

  // Escuta eventos de limpeza de estado
  useEffect(() => {
    const handleClearPageState = (event: CustomEvent) => {
      const { path } = event.detail;
      clearPageState(path);
    };

    const handleClearAllPageStates = () => {
      clearAllPageStates();
    };

    if (typeof window !== 'undefined') {
      window.addEventListener('clearPageState', handleClearPageState as EventListener);
      window.addEventListener('clearAllPageStates', handleClearAllPageStates);
    }

    return () => {
      if (typeof window !== 'undefined') {
        window.removeEventListener('clearPageState', handleClearPageState as EventListener);
        window.removeEventListener('clearAllPageStates', handleClearAllPageStates);
      }
    };
  }, []);

  const getPageState = (path: string): PageState | undefined => {
    return pageStates[path];
  };

  const setPageState = (path: string, state: PageState) => {
    setPageStates(prev => ({
      ...prev,
      [path]: { ...prev[path], ...state }
    }));
  };

  const clearPageState = (path: string) => {
    setPageStates(prev => {
      const newStates = { ...prev };
      delete newStates[path];
      return newStates;
    });
  };

  const clearAllPageStates = () => {
    setPageStates({});
  };

  return (
    <PageStatesContext.Provider value={{
      getPageState,
      setPageState,
      clearPageState,
      clearAllPageStates,
    }}>
      {children}
    </PageStatesContext.Provider>
  );
}

export const usePageState = () => {
  const context = useContext(PageStatesContext);
  if (!context) {
    throw new Error('usePageState must be used within PageStatesProvider');
  }
  return context;
};
