'use client';
import Protect from "../protect"
import { useState, useEffect } from "react";
import { useAuth } from "../context/context";
import { useTabs } from "../context/TabsContext";

export default function Home() {

  const { login, user } = useAuth()
  const { tabs } = useTabs();

  const getGreeting = () => {
    const hour = new Date().getHours();
    if (hour < 12) return "Bom dia";
    if (hour < 18) return "Boa tarde";
    return "Boa noite";
  };

  return (
      <Protect>
      <div className="container mx-auto p-6">
        <div className="bg-white rounded-lg shadow-md p-8">
          <div className="text-center">
            <h1 className="text-3xl font-bold text-gray-800 mb-4">
              {getGreeting()}, {user?.user_name || 'Usuário'}!
            </h1>
            
            <div className="grid grid-cols-1 md:grid-cols-3 gap-6 mt-8">
              <div className="bg-blue-50 p-6 rounded-lg border border-blue-200">
                <h3 className="text-lg font-semibold text-blue-800 mb-2">Acessos Disponíveis</h3>
                <p className="text-2xl font-bold text-blue-600">{user?.NumeroDeAcesssos || 0}</p>
                <p className="text-sm text-blue-600 mt-1">Módulos liberados</p>
              </div>
              
              <div className="bg-purple-50 p-6 rounded-lg border border-purple-200">
                <h3 className="text-lg font-semibold text-purple-800 mb-2">Guias Abertas</h3>
                <p className="text-2xl font-bold text-purple-600">{tabs.length}</p>
                <p className="text-sm text-purple-600 mt-1">Páginas ativas</p>
              </div>
              
              <div className="bg-green-50 p-6 rounded-lg border border-green-200">
                <h3 className="text-lg font-semibold text-green-800 mb-2">Status</h3>
                <p className="text-lg font-bold text-green-600">Online</p>
                <p className="text-sm text-green-600 mt-1">Sistema ativo</p>
              </div>
            </div>

            {tabs.length === 0 ? (
              <div className="mt-8 p-6 bg-gray-50 rounded-lg border border-gray-200">
                <h3 className="text-lg font-semibold text-gray-700 mb-2">Começar a trabalhar</h3>
                <p className="text-gray-600 mb-4">
                  Utilize o menu superior para acessar os módulos disponíveis.
                  Suas páginas abertas aparecerão como guias para facilitar a navegação.
                </p>
                <div className="flex justify-center space-x-4 text-sm text-gray-500">
                  <span>🏠 Página inicial</span>
                  <span>📋 Menus no topo</span>
                  <span>📑 Guias automáticas</span>
                </div>
              </div>
            ) : (
              <div className="mt-8 p-6 bg-purple-50 rounded-lg border border-purple-200">
                <h3 className="text-lg font-semibold text-purple-700 mb-2">Guias Ativas</h3>
                <p className="text-purple-600 mb-4">
                  Você tem {tabs.length} página{tabs.length > 1 ? 's' : ''} aberta{tabs.length > 1 ? 's' : ''}.
                  Use o menu "Acessos Abertos" ou as guias no topo para navegar.
                </p>
              </div>
            )}
          </div>
        </div>
      </div>
    </Protect>
  );
}
