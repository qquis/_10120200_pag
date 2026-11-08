

import { useEffect, useState } from "react";
import { useAuth } from "@/app/context/context";


import { moduleParticipante } from "@/api/m0011_Participante/moduleParticipante";
import moduleUserConnect from "@/api/m0001_sistema/moduleUserConnect";







type cmbProps = {
    user: moduleUserConnect
    onChange: (value: string) => void;
    value: string;
}



export default function CmbParticipanteTipo({ user, onChange, value }: cmbProps) {

    
    const [List, setList] = useState<any[]>([]);

    const handleChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
        onChange(event.target.value);
    };

    useEffect(() => {
    const fetchData = async () => {
        try {
            const myModule = new moduleParticipante(user, 0);
            const ListApi = await myModule.getParticipanteTipoList()
            setList(ListApi);
        } catch (error) {
            console.error("Erro ao buscar dados do sistema:", error);
        }
    };

    fetchData();
}, []);

    return (
        <select
            value={value}
            onChange={handleChange}
            className="w-full px-2 py-2 border text-black border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-transparent"
        >
            <option value="0">Selecione um sistema</option>
            {List && List.length > 0 && List.map((item) => (
                <option key={item.participante_tipo_cd} value={item.participante_tipo_cd}>
                    {item.participante_tipo_descricao}
                </option>
            ))}
        </select>
    );
}   
