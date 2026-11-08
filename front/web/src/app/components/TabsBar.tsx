'use client'
import { useTabs } from '@/app/context/TabsContext';
import { useRouter, usePathname } from 'next/navigation';
import { useEffect } from 'react';

export default function TabsBar() {
  const { tabs, activeTabId, setActiveTab, removeTab } = useTabs();
  const router = useRouter();
  const pathname = usePathname();

  // Sincroniza a guia ativa com a rota atual
  useEffect(() => {
    const currentTab = tabs.find(tab => tab.path === pathname);
    if (currentTab && currentTab.id !== activeTabId) {
      setActiveTab(currentTab.id);
    }
  }, [pathname, tabs, activeTabId, setActiveTab]);

  if (tabs.length === 0) {
    return null;
  }

  const handleTabClick = (tab: any) => {
    setActiveTab(tab.id);
    router.push(tab.path);
  };

  const handleCloseTab = (e: React.MouseEvent, tabId: string) => {
    e.stopPropagation();
    
    const tabToRemove = tabs.find(tab => tab.id === tabId);
    const isActiveTab = tabToRemove?.isActive;
    const isLastTab = tabs.length === 1;
    
    if (isLastTab) {
      // Se for a última guia, remove e navega para home
      removeTab(tabId);
      router.push('/pages');
    } else if (isActiveTab) {
      // Se for a guia ativa mas não a última, navega para a próxima antes de remover
      const remainingTabs = tabs.filter(tab => tab.id !== tabId);
      const nextActiveTab = remainingTabs[remainingTabs.length - 1];
      
      // Navega primeiro, depois remove
      router.push(nextActiveTab.path);
      setTimeout(() => {
        removeTab(tabId);
      }, 100);
    } else {
      // Se não for a guia ativa, apenas remove
      removeTab(tabId);
    }
  };

  return (
    <div className="bg-gray-100 border-b border-gray-200">
      <div className="flex overflow-x-auto">
        {tabs.map((tab) => (
          <div
            key={tab.id}
            onClick={() => handleTabClick(tab)}
            className={`
              flex items-center gap-2 px-4 py-2 border-r border-gray-300 cursor-pointer min-w-0 max-w-xs whitespace-nowrap
              ${tab.isActive 
                ? 'bg-white border-b-2 border-b-purple-500 text-purple-600' 
                : 'bg-gray-50 hover:bg-gray-200 text-gray-700'
              }
            `}
          >
            <span className="truncate text-sm font-medium">{tab.title}</span>
            {tab.canClose && (
              <button
                onClick={(e) => handleCloseTab(e, tab.id)}
                className="p-1 hover:bg-gray-300 rounded-full text-gray-400 hover:text-red-600 flex-shrink-0"
                title="Fechar guia"
              >
                <svg className="w-3 h-3" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M6 18L18 6M6 6l12 12" />
                </svg>
              </button>
            )}
          </div>
        ))}
      </div>
    </div>
  );
}
