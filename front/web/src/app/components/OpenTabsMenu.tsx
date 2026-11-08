'use client'
import { useTabs } from '@/app/context/TabsContext';
import { useRouter } from 'next/navigation';

interface OpenTabsMenuProps {
  isOpen: boolean;
  onClose: () => void;
}

export default function OpenTabsMenu({ isOpen, onClose }: OpenTabsMenuProps) {
  const { tabs, activeTabId, setActiveTab, removeTab, closeAllTabs } = useTabs();
  const router = useRouter();

  if (!isOpen || tabs.length === 0) {
    return null;
  }

  const handleTabClick = (tab: any) => {
    setActiveTab(tab.id);
    router.push(tab.path);
    onClose();
  };

  const handleCloseTab = (e: React.MouseEvent, tabId: string) => {
    e.stopPropagation();
    
    const isLastTab = tabs.length === 1;
    
    if (isLastTab) {
      // Se for a última guia, fecha o menu, navega para home e depois remove
      onClose();
      router.push('/pages');
      setTimeout(() => {
        removeTab(tabId);
      }, 100);
    } else {
      removeTab(tabId);
    }
  };

  const handleCloseAll = () => {
    // Fecha o menu, navega para home e depois fecha todas as guias
    onClose();
    router.push('/pages');
    setTimeout(() => {
      closeAllTabs();
    }, 100);
  };

  const getTabCategory = (path: string) => {
    if (path.includes('/gerencial/')) return 'Gerencial';
    if (path.includes('/cadastro/')) return 'Cadastro';
    if (path.includes('/relatorio/')) return 'Relatório';
    return 'Outros';
  };

  return (
    <div className="absolute top-full left-0 mt-2 w-80 bg-white rounded-lg shadow-lg border border-gray-200 z-50">
      <div className="p-3 border-b border-gray-200 flex justify-between items-center">
        <h3 className="text-sm font-semibold text-gray-700">Acessos Abertos ({tabs.length})</h3>
        {tabs.length > 0 && (
          <button
            onClick={handleCloseAll}
            className="text-xs text-red-600 hover:text-red-800 font-medium"
          >
            Fechar Todos
          </button>
        )}
      </div>
      
      <div className="max-h-64 overflow-y-auto">
        {tabs.map((tab) => (
          <div
            key={tab.id}
            onClick={() => handleTabClick(tab)}
            className={`
              flex items-center justify-between p-3 border-b border-gray-100 cursor-pointer hover:bg-gray-50
              ${tab.isActive ? 'bg-purple-50 border-l-4 border-l-purple-500' : ''}
            `}
          >
            <div className="flex-1 min-w-0">
              <div className="text-sm font-medium text-gray-900 truncate">
                {tab.title}
              </div>
              <div className="text-xs text-gray-500 truncate">
                <span className="bg-gray-100 px-2 py-1 rounded text-xs mr-1">
                  {getTabCategory(tab.path)}
                </span>
                {tab.path}
              </div>
            </div>
            
            <div className="flex items-center gap-2">
              {tab.isActive && (
                <span className="w-2 h-2 bg-purple-500 rounded-full"></span>
              )}
              {tab.canClose && (
                <button
                  onClick={(e) => handleCloseTab(e, tab.id)}
                  className="p-1 hover:bg-red-100 rounded-full text-gray-400 hover:text-red-600"
                  title="Fechar guia"
                >
                  <svg className="w-3 h-3" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M6 18L18 6M6 6l12 12" />
                  </svg>
                </button>
              )}
            </div>
          </div>
        ))}
      </div>
      
      {tabs.length === 0 && (
        <div className="p-8 text-center text-gray-500">
          <div className="text-sm">Nenhum acesso aberto</div>
          <div className="text-xs text-gray-400 mt-1">
            Clique em um menu para abrir uma nova guia
          </div>
        </div>
      )}
    </div>
  );
}
