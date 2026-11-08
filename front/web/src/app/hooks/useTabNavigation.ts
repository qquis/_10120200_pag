'use client'
import { useTabs } from '@/app/context/TabsContext';
import { useRouter } from 'next/navigation';

export const useTabNavigation = () => {
  const { addTab, tabs } = useTabs();
  const router = useRouter();

  const navigateWithTab = (href: string, title: string, menuItem?: any) => {
    // Cria a guia com as informações do submenu
    addTab(menuItem || { href, title }, href, title);
    
    // Navega para a página
    router.push(href);
  };

  const navigateToHome = () => {
    router.push('/pages');
  };

  const isOnHomePage = () => {
    return typeof window !== 'undefined' && 
           (window.location.pathname === '/pages' || 
            window.location.pathname === '/pages/');
  };

  return { 
    navigateWithTab, 
    navigateToHome, 
    isOnHomePage,
    hasOpenTabs: tabs.length > 0
  };
};
