import React, { MouseEvent, ReactNode } from 'react';
import IconeButton from '../Icons/IconButtons';

interface ButtonProps {
    type? : "button" | "submit" | "reset";
    form? : string 
    title: string 
    label: string 
    onClick?: () => void;
    parametros?: any[];
    TypeButton: "_BUTTON_HEADER" | "_BUTTON_ICON" | "_BUTTON_INFO"
    TypeIcon : "_NO_ICON" | "_SELECT" | "_UPDATE" | "_NEW" | "_EDIT" | "_SALVAR" | "_VOLTAR" | "_PESQUISAR" | "_VOLTAR";
    ActionStatus?: Number
}

const ButtonPag = ({title, label, onClick, TypeIcon, TypeButton, ...ButtonProps}: ButtonProps) => { 

    let className = "bg-purple-600 text-white px-4 py-2 rounded hover:bg-purple-700 disabled:bg-gray-400 disabled:cursor-not-allowed disabled:hover:bg-gray-400" 
    switch(TypeButton) {
        case "_BUTTON_HEADER":
            className = `
                flex items-center bg-[#8B5CF6] hover:bg-purple-700 text-white font-medium 
                py-1.5 px-2 rounded-full text-sm transition-colors duration-300 
                disabled:bg-gray-400 disabled:cursor-not-allowed disabled:hover:bg-gray-400
                sm:py-1 sm:px-2 sm:text-xs
            `.replace(/\s+/g, ' ');
            break;
        case "_BUTTON_ICON":
            className = `
                text-gray-600 hover:text-blue-600 transition-colors p-1 rounded 
                hover:bg-gray-100 disabled:bg-gray-400 disabled:cursor-not-allowed disabled:hover:bg-gray-400
                sm:p-0.5
            `.replace(/\s+/g, ' ');
            break;            
    }    

    return (
        <>
        <button
            type={(ButtonProps.type)? ButtonProps.type : "button"}
            form={ButtonProps.form}
            onClick={onClick}
            disabled={ButtonProps.ActionStatus === 1}
            className={className}
            title={title}>
            { (TypeIcon !== "_NO_ICON")? <IconeButton tipo={TypeIcon}/> : ""}
            {(label)? <span>{label}</span> : ""}
        </button>
    </>
    )
}

export default ButtonPag