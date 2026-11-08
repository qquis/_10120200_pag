'use client'
import React, { createContext, useContext, useState, ReactNode } from 'react';
import { Tab } from '@/types/tabs';

interface TabsContextType {
  tabs: Tab[];
  activeTabId: string | null;
  addTab: (menuItem: any, path: string, title: string) => void;
  removeTab: (tabId: string) => void;
  setActiveTab: (tabId: string) => void;
  closeAllTabs: () => void;
  getTabByPath: (path: string) => Tab | undefined;
}

const TabsContext = createContext<TabsContextType | undefined>(undefined);

export function TabsProvider({ children }: { children: ReactNode }) {
  const [tabs, setTabs] = useState<Tab[]>([]);
  const [activeTabId, setActiveTabId] = useState<string | null>(null);

  const addTab = (menuItem: any, path: string, title: string) => {
    // Verifica se já existe uma guia com o mesmo path
    const existingTab = tabs.find(tab => tab.path === path);
    if (existingTab) {
      setActiveTab(existingTab.id);
      return;
    }

    const id = `tab-${Date.now()}-${Math.random()}`;
    const newTab: Tab = {
      id,
      title,
      path,
      menuItem,
      isActive: true,
      canClose: true,
      timestamp: Date.now(),
    };

    setTabs(prev => [...prev.map(t => ({ ...t, isActive: false })), newTab]);
    setActiveTabId(id);
  };

  const removeTab = (tabId: string, shouldClearState = true) => {
    setTabs(prev => {
      const tabToRemove = prev.find(tab => tab.id === tabId);
      const newTabs = prev.filter(tab => tab.id !== tabId);
      
      // Opcionalmente limpa o estado da página removida
      if (shouldClearState && tabToRemove && typeof window !== 'undefined') {
        // Envia evento customizado para limpar estado da página
        window.dispatchEvent(new CustomEvent('clearPageState', {
          detail: { path: tabToRemove.path }
        }));
      }
      
      // Se não sobrou nenhuma guia, apenas limpa o estado
      if (newTabs.length === 0) {
        setActiveTabId(null);
        return newTabs;
      }
      
      // Se a guia ativa foi removida, ativa a última guia
      if (activeTabId === tabId) {
        const lastTab = newTabs[newTabs.length - 1];
        setActiveTabId(lastTab.id);
        newTabs.forEach(tab => {
          tab.isActive = tab.id === lastTab.id;
        });
      }
      
      return newTabs;
    });
  };

  const setActiveTab = (tabId: string) => {
    setTabs(prev => prev.map(tab => ({ 
      ...tab, 
      isActive: tab.id === tabId 
    })));
    setActiveTabId(tabId);
  };

  const closeAllTabs = () => {
    // Limpa estados de todas as guias
    if (typeof window !== 'undefined') {
      window.dispatchEvent(new CustomEvent('clearAllPageStates'));
    }
    
    setTabs([]);
    setActiveTabId(null);
  };

  const getTabByPath = (path: string) => {
    return tabs.find(tab => tab.path === path);
  };

  return (
    <TabsContext.Provider value={{
      tabs,
      activeTabId,
      addTab,
      removeTab,
      setActiveTab,
      closeAllTabs,
      getTabByPath,
    }}>
      {children}
    </TabsContext.Provider>
  );
}

export const useTabs = () => {
  const context = useContext(TabsContext);
  if (!context) {
    throw new Error('useTabs must be used within TabsProvider');
  }
  return context;
};
