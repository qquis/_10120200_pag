"use client"
import { useState, useEffect } from 'react';
import { useAuth } from "../context/context";
import { useTabs } from "../context/TabsContext";
import Link from 'next/link';
import { useRouter } from 'next/navigation';
import OpenTabsMenu from './OpenTabsMenu';
import packageInfo from '../../../package.json';

const PagMenu: React.FC = () => {
  const { user, logout } = useAuth();
  const { addTab, tabs, closeAllTabs } = useTabs();
  const [isOpen, setIsOpen] = useState(false);
  const [isOpenTabsMenuOpen, setIsOpenTabsMenuOpen] = useState(false);
  const router = useRouter();

  useEffect(() => {
    // Escuta o evento de logout para fechar todas as guias

    const handleLogout = () => {
      closeAllTabs();
      // Pequeno delay para garantir que as guias sejam fechadas antes do redirecionamento
      setTimeout(() => {
        router.push('/login');
      }, 100);
    };
    
    window.addEventListener('userLogout', handleLogout);
    
    return () => {
      window.removeEventListener('userLogout', handleLogout);
    };
  }, [closeAllTabs]);

  const functionIsOpen = () => {
    // Sua lógica aqui
    setIsOpen(!isOpen)
  };

  const handleMenuClick = (menu: any, e: React.MouseEvent) => {
    e.preventDefault();
    const path = `/pages/${menu.sis_ac_modulo_menu_descricao.toLowerCase()}`;
    
    // Verifica se é uma página que tem submenus (gerencial, cadastro, etc.)
    const pagesWithSubmenus = ['gerencial', 'cadastro','sistema', 'operacional', 'crm', 'controller'];
    const isSubmenuPage = pagesWithSubmenus.includes(menu.sis_ac_modulo_menu_descricao.toLowerCase());
    
    if (isSubmenuPage) {
      // Para páginas com submenus, apenas navega sem criar guia
      // As guias serão criadas quando clicar nos submenus específicos
      router.push(path);
    } else {
      // Para páginas diretas, cria a guia normalmente
      const title = menu.sis_ac_gmenu;
      addTab(menu, path, title);
      router.push(path);
    }
  };

  const handleOpenTabsClick = () => {
    setIsOpenTabsMenuOpen(!isOpenTabsMenuOpen);
  };

  return (
   <nav className={`p-5 ${user?.ambiente === 'DES' ? 'bg-red-900' : 'bg-gray-800'}`}>
    <div className="container mx-auto flex justify-between items-center flex-wrap md:flex-nowrap">
      <div className="text-white text-xl flex-shrink-0">
        <div className="flex flex-col">
          <span className="flex items-center space-x-2">
            Oxan Prime |  {user?.ambiente === "DES" ? "DES" : ""}
            {user?.nome_razao && (
              <span className="inline-flex items-center justify-center w-8 h-8 rounded-full bg-purple-600 text-white font-bold text-sm ml-2">
                {(() => {
                  const partes = user.nome_razao.trim().split(' ').filter(Boolean);
                  const primeira = partes[0]?.charAt(0) ?? '';
                  let segundoNome = partes[1];
                  if (segundoNome && segundoNome.length === 2 && partes[2]) {
                    segundoNome = partes[2];
                  }
                  const segunda = segundoNome?.charAt(0) ?? '';
                  return (primeira + segunda).toUpperCase();
                })()}
              </span>
            )}
          </span>
          <span className="text-xs text-gray-300">v{packageInfo.version}</span>
        </div>
      </div>

      {!user?.user_name ? 
      ( // NÃO LOGADO
        <div className="text-white">Login</div>
      ) : 
      ( // LOGADO
        <> 
            <div
              className={`${
                isOpen ? "block" : "hidden md:flex"
              } flex-col md:flex-row md:items-center md:flex-nowrap w-full md:w-auto md:space-x-4 text-white`}
            >
              {user?.MenusList.map((menu) => (
                <button
                  key={menu.sis_ac_modulo_menu_descricao}
                  onClick={(e) => handleMenuClick(menu, e)}
                  className="block md:inline-block px-4 py-2 hover:bg-gray-700 text-left md:whitespace-nowrap"
                >
                  {menu.sis_ac_modulo_menu_descricao}
                </button>
              ))}

              {/* Menu de Acessos Abertos */}
              <div className="relative md:inline-block">
                <button
                  onClick={handleOpenTabsClick}
                  className="flex items-center px-4 py-2 hover:bg-gray-700 text-white md:whitespace-nowrap"
                >
                  <span>Acessos Abertos</span>
                  {tabs.length > 0 && (
                    <span className="ml-2 bg-purple-500 text-white text-xs rounded-full px-2 py-1 min-w-[1.5rem] h-6 flex items-center justify-center">
                      {tabs.length}
                    </span>
                  )}
                  <svg 
                    className={`ml-1 w-4 h-4 transition-transform ${isOpenTabsMenuOpen ? 'rotate-180' : ''}`} 
                    fill="none" 
                    stroke="currentColor" 
                    viewBox="0 0 24 24"
                  >
                    <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M19 9l-7 7-7-7" />
                  </svg>
                </button>
                
                <OpenTabsMenu 
                  isOpen={isOpenTabsMenuOpen} 
                  onClose={() => setIsOpenTabsMenuOpen(false)} 
                />
              </div>
            </div>

            <div className="flex-shrink-0">
              <button
                className="text-white focus:outline-none px-4 py-2 hover:bg-gray-700 whitespace-nowrap"
                onClick={() => logout()}
              >
                Sair 
              </button>
            </div>

            <div className="block md:hidden">
              <button
                className="text-white focus:outline-none"
                onClick={() => setIsOpen(!isOpen)}
              >
                <svg
                  className="w-6 h-6"
                  fill="none"
                  stroke="currentColor"
                  viewBox="0 0 24 24"
                  xmlns="http://www.w3.org/2000/svg"
                >
                  <path
                    strokeLinecap="round"
                    strokeLinejoin="round"
                    strokeWidth="2"
                    d={isOpen ? "M6 18L18 6M6 6l12 12" : "M4 6h16M4 12h16m-7 6h7"}
                  ></path>
                </svg>
              </button>
            </div>
        </>
      )}
    </div>
  </nav>
)};

export default PagMenu