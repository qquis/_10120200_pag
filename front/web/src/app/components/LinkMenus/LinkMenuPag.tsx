'use client'
import React from 'react';
import { useTabNavigation } from '@/app/hooks/useTabNavigation';

interface LinkMenuPagProps {

    href: string 
    description: string 
    info: string
    menuItem?: any // Objeto completo do menu para salvar contexto
}

const LinkMenuPag = ({href, description, info, menuItem}: LinkMenuPagProps) => { 
    const { navigateWithTab } = useTabNavigation();

    const handleClick = (e: React.MouseEvent) => {
        e.preventDefault();
        navigateWithTab(href, description, menuItem);
    };

    return (
        <div
            onClick={handleClick}
            className="cursor-pointer border border-gray-100 bg-slate-300 w-full max-w-[500px] justify-self-right px-3 py-2 rounded-md shadow-md hover:shadow-[0_4px_12px_rgba(59,130,246,0.70)] transition-shadow"
        >
            <h2 className="text-x1 text-black font-light">{description}</h2>
            <p className="text-gray-600 mt-1">{info}</p>
        </div>
    );
}

export default LinkMenuPag