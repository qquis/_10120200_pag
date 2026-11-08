import { useEffect } from "react";
import { tpFaturamentoStatus } from "@/api/m0070_faturamento/moduleFaturamento";

type cmbProps = {
    onChange: (value: string) => void;
    value: number | string;
    ListFaturamentoStatus: tpFaturamentoStatus[]
    disabled?: boolean
}

export default function CmbStatusFaturamento({ onChange, value, ListFaturamentoStatus, disabled = false }: cmbProps) {

    useEffect(() => {
        const statusList = ListFaturamentoStatus || [];
        const hasSelectedStatus = statusList.some(
            (item) => String(item.statusfaturamento) === String(value)
        );

        if (statusList.length > 0 && !hasSelectedStatus) {
            onChange(String(statusList[0].statusfaturamento));
        }
    }, [ListFaturamentoStatus, onChange, value]);

    return (
        <select
            value={value}
            onChange={(event) => onChange(event.target.value)}
            disabled={disabled}
            className="w-full px-2 py-2 border text-black border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-transparent"
        >
            {(ListFaturamentoStatus || []).map((item) => (
                <option key={item.statusfaturamento} value={item.statusfaturamento}>
                    {item.statusfaturamento_descricao}
                </option>
            ))}
        </select>
    );
}
