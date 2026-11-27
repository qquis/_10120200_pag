'use client'
    const __SIS_AC_CD : number = 3090 
    
import { useEffect, useState } from 'react';
import { useAuth } from "@/app/context/context";

/*Componentes*/
import HeaderMain from "@/app/components/divs/headerMain";

import ButtonPag from "@/app/components/Buttons/button";
import CmbOperacao from '@/app/pages/cadastro/_components/CmbOperacao/page';
import { moduleFaturamento } from '@/api/m0070_faturamento/moduleFaturamento';
import {moduleforcavendameta} from '@/api/m0005_forcaVendaMeta/moduleforcavendameta';



let myModule: moduleFaturamento;
let myModuleForcaVendaMeta: moduleforcavendameta;

export default function FaturamentoInterface() {

    /* USER */
    const { user } = useAuth();

    /* STATES SCREEN */
    const [ActionStatus, setActionStatus] = useState<number>(0);
    const [ListMetaFabricante, setListMetaFabricante] = useState<any[]>([])
    const [selectedMetaKey, setSelectedMetaKey] = useState<string | null>(null);
   

    useEffect(() => {
            const hoje = new Date();
            myModule = new moduleFaturamento(user, __SIS_AC_CD);
            myModuleForcaVendaMeta = new moduleforcavendameta(user, __SIS_AC_CD);

            const fetchMetaFabricante = async () => {
                try {
                    const result = await myModuleForcaVendaMeta.fabricante.getListMetaFabricante({ competencia_cd: 202610 });
                    setListMetaFabricante(result);
                } catch (e) {
                    console.error(e);
                }
            }
            fetchMetaFabricante();


    }, []);


    


 
    return (

        <div className="min-h-screen bg-gray-50 p-6">
            <div className="max-w-7xl mx-auto">
                <HeaderMain tipo={"_PAGE"} ActionStatus={ActionStatus} header_title="Meta de Interfaces de Fabricantes">
                  <></>
                </HeaderMain>

                <section className="mt-4 overflow-hidden rounded-xl border border-gray-200 bg-white shadow-sm">
    <div className="overflow-x-auto">
        <table className="min-w-full divide-y divide-gray-200 text-sm">
            <thead className="bg-gray-50 text-left text-xs font-semibold uppercase text-gray-600">
                <tr>
                    <th className="px-4 py-3" scope="col">Selecionar</th>
                    <th className="px-4 py-3" scope="col">Fabricante</th>
                    <th className="px-4 py-3" scope="col">Código da meta</th>
                    <th className="px-4 py-3" scope="col">Descrição</th>
                    <th className="px-4 py-3" scope="col">Tipo</th>
                    <th className="px-4 py-3" scope="col">Data inicial</th>
                    <th className="px-4 py-3" scope="col">Data final</th>
                </tr>
            </thead>
            <tbody className="divide-y divide-gray-100 text-gray-800">
                {ListMetaFabricante.map((item) => {
                    const rowKey =
                        `${item.fv_fabricante_cdpessoabluesoft}-${item.fv_fab_meta_cd}`;

                    return (
                        <tr
                            key={rowKey}
                            className={selectedMetaKey === rowKey ? "bg-indigo-50" : "hover:bg-gray-50"}
                        >
                            <td className="px-4 py-2">
                                <input
                                    type="radio"
                                    name="metaFabricanteSelecionada"
                                    value={rowKey}
                                    checked={selectedMetaKey === rowKey}
                                    onChange={() => setSelectedMetaKey(rowKey)}
                                    aria-label={`Selecionar meta ${item.fv_fab_meta_cd}`}
                                />
                            </td>
                            <td className="px-4 py-2">{item.nome_razao ?? "-"}</td>
                            <td className="px-4 py-2">{item.fv_fab_meta_cd}</td>
                            <td className="px-4 py-2">{item.fv_fab_meta_descricao ?? "-"}</td>
                            <td className="px-4 py-2">{item.fv_fab_meta_tipo ?? "-"} - {item.fv_fab_meta_tipo_descricao ?? "-"}</td>
                            <td className="px-4 py-2">{user.formatDateDDMMYYYY(item.fv_fab_data_ini) ?? "-"}</td>
                            <td className="px-4 py-2">{user.formatDateDDMMYYYY(item.fv_fab_data_fim) ?? "-"}</td>
                        </tr>
                    );
                })}
                {ListMetaFabricante.length === 0 && (
                    <tr>
                        <td colSpan={8} className="px-4 py-6 text-center text-gray-500">
                            Nenhuma meta encontrada.
                        </td>
                    </tr>
                )}
            </tbody>
        </table>
    </div>
</section>
          
                <section className="mt-4 rounded-xl border border-gray-200 bg-white p-4 shadow-sm">
                    <h2 className="mb-3 text-base font-semibold text-gray-800">Relatórios</h2>
                    <div className="flex flex-col items-end gap-2">
                        <ButtonPag
                            TypeButton="_BUTTON_HEADER"
                            label="Vendedor / Grupo Mix Principais"
                            TypeIcon="_NO_ICON"
                            title="Abrir Vendedor / Grupo Mix Principais"
                        />

                        <ButtonPag
                            TypeButton="_BUTTON_HEADER"
                            label="Vendedor / Clientes"
                            TypeIcon="_NO_ICON"
                            title="Vendedor / Clientes — indisponível"
                            ActionStatus={1}
                        />
                    </div>
                </section>
          
            </div>

        </div>
    );
}