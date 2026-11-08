'use client'

import { useState } from "react";
import LinkMenuPag from "@/app/components/LinkMenus/LinkMenuPag";
import moduleUserConnect from "@/api/m0001_sistema/moduleUserConnect";

type MenuItem = moduleUserConnect["Menu_Operacional"][number];

interface PagSubMenuProps {
  title: string;
  items?: MenuItem[];
  info?: string;
  gridClassName?: string;
  groupTitleClassName?: string;
}

export default function PagSubMenu({
  title,
  items = [],
  info = "Clique para acessar",
  gridClassName = "grid grid-cols-1 gap-2",
  groupTitleClassName = "text-lg font-semibold mb-4 text-gray-700 border-b border-gray-300 pb-2",
}: PagSubMenuProps) {
  const groupedMenus = items.reduce<Record<string, MenuItem[]>>((groups, link) => {
    const groupKey = link.sis_ac_gmenu || "Sem Grupo";

    if (!groups[groupKey]) {
      groups[groupKey] = [];
    }

    groups[groupKey].push(link);
    return groups;
  }, {});

  // Todos começam fechados por padrão
  const [openGroups, setOpenGroups] = useState<Record<string, boolean>>(() => {
    const initial: Record<string, boolean> = {};
    Object.keys(groupedMenus).forEach((groupName) => {
      initial[groupName] = false;
    });
    return initial;
  });

  const toggleGroup = (groupName: string) => {
    setOpenGroups((prev) => ({
      ...prev,
      [groupName]: !prev[groupName],
    }));
  };

  return (
    <div className="container mx-auto p-6 max-w-4xl">
      <div className="mb-6 rounded-xl border border-gray-100 bg-slate-200 px-4 py-4 shadow-sm">
        <div className="flex flex-col gap-2 sm:flex-row sm:items-end sm:justify-between">
          <div>
            <h1 className="text-2xl font-semibold tracking-tight text-purple-700">
              {title}
            </h1>
            <p className="mt-1 text-sm text-gray-600">
              Clique para acessar os menus disponíveis
            </p>
          </div>

          <div className="inline-flex items-center gap-2 rounded-full bg-slate-100 px-3 py-1 text-sm text-gray-700">
            <span className="font-medium">Acessos</span>
            <span className="rounded-full bg-slate-300 px-2.5 py-0.5 text-xs font-semibold text-gray-900">
              {items.length}
            </span>
          </div>
        </div>
      </div>

      {/* Removido o 'mx-auto' para alinhar à esquerda, mantendo max-w-2xl para controlar a largura */}
      <div className="flex flex-col gap-4 max-w-2xl">
        {Object.entries(groupedMenus).map(([groupName, links]) => {
          const isOpen = openGroups[groupName] ?? false;

          return (
            <div 
              key={groupName} 
              className="rounded-xl border border-gray-200 bg-white shadow-sm overflow-hidden transition-all duration-200 w-full"
            >
              {/* Cabeçalho do Card clicável */}
              <button
                onClick={() => toggleGroup(groupName)}
                className="w-full flex items-center justify-between gap-3 px-5 py-4 bg-gray-50 hover:bg-gray-100 transition-colors cursor-pointer text-left"
                type="button"
              >
                <div className="flex items-center gap-3">
                  <h2 className="text-lg font-light tracking-tight text-purple-700">
                    {groupName}
                  </h2>
                  <span className="rounded-full bg-purple-100 px-2.5 py-0.5 text-xs font-medium text-purple-700">
                    {links.length} {links.length === 1 ? 'item' : 'itens'}
                  </span>
                </div>

                {/* Ícone de seta giratória */}
                <svg
                  className={`w-5 h-5 text-gray-500 transform transition-transform duration-200 ${
                    isOpen ? "rotate-180" : ""
                  }`}
                  fill="none"
                  viewBox="0 0 24 24"
                  stroke="currentColor"
                >
                  <path
                    strokeLinecap="round"
                    strokeLinejoin="round"
                    strokeWidth={2}
                    d="M19 9l-7 7-7-7"
                  />
                </svg>
              </button>

              {/* Conteúdo do Card */}
              {isOpen && (
                <div className="p-5 border-t border-gray-100 bg-white">
                  <div className={gridClassName}>
                    {links.map((link) => (
                      <LinkMenuPag
                        key={link.sis_ac_cd}
                        href={link.sis_ac_href}
                        description={link.sis_ac_descricao}
                        info={info}
                        menuItem={link}
                      />
                    ))}
                  </div>
                </div>
              )}
            </div>
          );
        })}
      </div>
    </div>
  );
}