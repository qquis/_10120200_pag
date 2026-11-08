

import { useEffect, useState } from "react";
import { useAuth } from "@/app/context/context";



import moduleUserConnect from "@/api/m0001_sistema/moduleUserConnect";
import { moduleFinanceiro } from "@/api/m0080_financeiro/modulefinanceiro"







type cmbProps = {
    user: moduleUserConnect
    onChange: (value: string) => void;
    value: string;
    sis_ac_cd: number
    onLoadComplete?: () => void;
}



export default function CmbFormaPgtoBluesoft({ user, onChange, value,sis_ac_cd, onLoadComplete }: cmbProps) {

    
    const [List, setList] = useState<any[]>([]);

    const handleChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
        onChange(event.target.value);
    };

    useEffect(() => {
    let active = true;
    const fetchData = async () => {
        try {
            const myModule = new moduleFinanceiro(user);
            const ListApi = await myModule.moduleBluesoft.CadastroFormaPgtoList(0)
            if (active) setList(ListApi);
        } catch (error) {
            console.error("Erro ao buscar dados do sistema:", error);
        } finally {
            if (active) onLoadComplete?.();
        }
    };

    fetchData();
    return () => { active = false; };
}, []);
useEffect(() => {
    if (List.length === 1) {
        onChange(List[0].forma_pgto_cd);
    }
}, [List]);

    return (
        <select
            value={value}
            onChange={handleChange}
            className="w-full px-2 py-2 border text-black border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-transparent"
        >
            {List && List.length > 1 && <option value="0">Selecione a forma de pagamento</option>}
            {List && List.length > 0 && List.map((item) => (
            <option key={item.forma_pgto_cd} value={item.forma_pgto_cd}>
                {item.forma_pgto_descricao}
            </option>
            ))}
        </select>
    );
}   
