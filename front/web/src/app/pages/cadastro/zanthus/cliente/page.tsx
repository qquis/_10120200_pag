'use client'

import { useMemo, useState } from 'react'
import { useAuth } from '@/app/context/context'

import HeaderMain from '@/app/components/divs/headerMain'
import ButtonPag from '@/app/components/Buttons/button'
import { moduleZanthus } from '@/api/external/zanthus'

type Cliente = {
  cod_cliente: string
  des_cliente: string
  des_fantasia: string
  num_cgc: string
  flg_empresa: string
  flg_enviar_carga: string
  loja_cadastro: string
  status_cliente: string
  origem_cadastro: string
  flg_fidelidade: string
  senha_pdv: string
  situacao_cadastro: string
  flg_habilitado_compra: string
  flg_revenda: string
  des_endereco: string
  id_municipio: string
  numero: string
  des_bairro: string
  compl_endereco: string
  cod_pais: string
  des_cidade: string
  num_cep: string
  des_sigla: string
  num_insc_est: string
  dta_alteracao: string
  dta_cadastro: string
}

export default function ClientePage() {
  const { user } = useAuth()

  const moduloZanthus = useMemo(
    () => new moduleZanthus(user),
    [user]
  )

  const [codCliente, setCodCliente] = useState('0')

  const [filtrarDataAlteracao, setFiltrarDataAlteracao] = useState(true)
  const [dataAlteracaoIni, setDataAlteracaoIni] = useState('2026-08-01')
  const [dataAlteracaoFim, setDataAlteracaoFim] = useState('2026-09-30')

  const [filtrarDataCadastro, setFiltrarDataCadastro] = useState(false)
  const [dataCadastroIni, setDataCadastroIni] = useState('2026-08-01')
  const [dataCadastroFim, setDataCadastroFim] = useState('2026-08-01')

  const [desCliente, setDesCliente] = useState('')

  const [clientes, setClientes] = useState<Cliente[]>([])
  const [loading, setLoading] = useState(false)
  const [erro, setErro] = useState<string | null>(null)

  const formatarData = (valor?: string) => {
    if (!valor) return ''

    const data = new Date(valor)

    if (Number.isNaN(data.getTime())) {
      return valor
    }

    return data.toLocaleDateString('pt-BR')
  }

  const consultarClientes = async () => {
    setLoading(true)
    setErro(null)

    const parametros: any = {
      cod_cliente: codCliente ? Number(codCliente) : 0,
      filtrar_data_alteracao: filtrarDataAlteracao ? '1' : '0',
      data_alteracao_ini: dataAlteracaoIni,
      data_alteracao_fim: dataAlteracaoFim,
      filtrar_data_cadastro: filtrarDataCadastro ? '1' : '0',
      data_cadastro_ini: dataCadastroIni,
      data_cadastro_fim: dataCadastroFim, 
      des_cliente: desCliente,
    }

    try {
      const resposta = await moduloZanthus.getlistTabCliente(parametros)

      setClientes(Array.isArray(resposta) ? resposta : [])
    } catch (e) {
      console.error('Erro ao consultar clientes:', e)
      setClientes([])
      setErro('Não foi possível consultar a listagem de clientes.')
    } finally {
      setLoading(false)
    }
  }

  return (
    <div className="min-h-screen bg-gray-50 p-6">
      <div className="mx-auto max-w-7xl">
        <HeaderMain
          tipo="_PAGE"
          ActionStatus={loading ? 1 : 0}
          header_title="Zanthus | Tab Cliente"
        >
          <div className="flex space-x-2">
            <ButtonPag
              TypeButton="_BUTTON_HEADER"
              label={loading ? 'Consultando...' : 'Pesquisar'}
              TypeIcon="_PESQUISAR"
              title="Pesquisar clientes"
              onClick={consultarClientes}
            />
          </div>
        </HeaderMain>

        <div className="mb-6 rounded-lg border border-purple-100 bg-white p-6 shadow-md">
          <div className="grid grid-cols-1 gap-4 md:grid-cols-2 lg:grid-cols-4">
            <div>
              <label
                htmlFor="cod-cliente"
                className="mb-1 block text-sm font-medium text-gray-700"
              >
                Código do cliente
              </label>

              <input
                id="cod-cliente"
                type="number"
                min="0"
                className="w-full rounded-md border border-gray-300 p-2 text-black focus:border-transparent focus:ring-2 focus:ring-purple-500"
                value={codCliente}
                onChange={(e) => setCodCliente(e.target.value)}
              />
            </div>
            <div>
              <label
                htmlFor="des-cliente"
                className="mb-1 block text-sm font-medium text-gray-700"
              >
                Descrição do cliente
              </label>

              <input
                id="des-cliente"
                type="text"
                className="w-full rounded-md border border-gray-300 p-2 text-black focus:border-transparent focus:ring-2 focus:ring-purple-500"
                placeholder="Informe o nome ou descrição do cliente"
                value={desCliente}
                onChange={(e) => setDesCliente(e.target.value)}
              />
            </div>
          </div>

          <div className="mt-6">
            <div className="mb-3">
              <input
                id="filtrar-data-alteracao"
                type="checkbox"
                className="h-4 w-4 rounded border-gray-300 text-purple-600 focus:ring-purple-500"
                checked={filtrarDataAlteracao}
                onChange={(e) =>
                  setFiltrarDataAlteracao(e.target.checked)
                }
              />

              <label
                htmlFor="filtrar-data-alteracao"
                className="ml-2 text-sm font-semibold text-gray-700"
              >
                Filtrar por data de alteração
              </label>
            </div>

            <div className="grid grid-cols-1 gap-4 md:grid-cols-2">
              <div>
                <label
                  htmlFor="data-alteracao-ini"
                  className="mb-1 block text-sm font-medium text-gray-700"
                >
                  Alteração inicial
                </label>

                <input
                  id="data-alteracao-ini"
                  type="date"
                  className="w-full rounded-md border border-gray-300 p-2 text-black focus:border-transparent focus:ring-2 focus:ring-purple-500"
                  value={dataAlteracaoIni}
                  disabled={!filtrarDataAlteracao}
                  onChange={(e) => setDataAlteracaoIni(e.target.value)}
                />
              </div>

              <div>
                <label
                  htmlFor="data-alteracao-fim"
                  className="mb-1 block text-sm font-medium text-gray-700"
                >
                  Alteração final
                </label>

                <input
                  id="data-alteracao-fim"
                  type="date"
                  className="w-full rounded-md border border-gray-300 p-2 text-black focus:border-transparent focus:ring-2 focus:ring-purple-500"
                  value={dataAlteracaoFim}
                  disabled={!filtrarDataAlteracao}
                  onChange={(e) => setDataAlteracaoFim(e.target.value)}
                />
              </div>
            </div>
          </div>

          <div className="mt-6">
            <div className="mb-3">
              <input
                id="filtrar-data-cadastro"
                type="checkbox"
                className="h-4 w-4 rounded border-gray-300 text-purple-600 focus:ring-purple-500"
                checked={filtrarDataCadastro}
                onChange={(e) =>
                  setFiltrarDataCadastro(e.target.checked)
                }
              />

              <label
                htmlFor="filtrar-data-cadastro"
                className="ml-2 text-sm font-semibold text-gray-700"
              >
                Filtrar por data de cadastro
              </label>
            </div>

            <div className="grid grid-cols-1 gap-4 md:grid-cols-2">
              <div>
                <label
                  htmlFor="data-cadastro-ini"
                  className="mb-1 block text-sm font-medium text-gray-700"
                >
                  Cadastro inicial
                </label>

                <input
                  id="data-cadastro-ini"
                  type="date"
                  className="w-full rounded-md border border-gray-300 p-2 text-black focus:border-transparent focus:ring-2 focus:ring-purple-500"
                  value={dataCadastroIni}
                  disabled={!filtrarDataCadastro}
                  onChange={(e) => setDataCadastroIni(e.target.value)}
                />
              </div>

              <div>
                <label
                  htmlFor="data-cadastro-fim"
                  className="mb-1 block text-sm font-medium text-gray-700"
                >
                  Cadastro final
                </label>

                <input
                  id="data-cadastro-fim"
                  type="date"
                  className="w-full rounded-md border border-gray-300 p-2 text-black focus:border-transparent focus:ring-2 focus:ring-purple-500"
                  value={dataCadastroFim}
                  disabled={!filtrarDataCadastro}
                  onChange={(e) => setDataCadastroFim(e.target.value)}
                />
              </div>
            </div>
          </div>
        </div>

        {erro && (
          <div className="mb-6 rounded-md border border-red-200 bg-red-50 p-4 text-sm text-red-700">
            {erro}
          </div>
        )}

        <div className="overflow-hidden rounded-lg border border-purple-100 bg-white shadow-md">
          <div className="max-h-[650px] overflow-auto">
            <table className="min-w-[2600px] divide-y divide-gray-200">
              <thead className="sticky top-0 z-10 bg-gray-100">
                <tr>
                  <th className="px-3 py-3 text-left text-xs font-medium uppercase text-purple-700">
                    Código
                  </th>
                  <th className="px-3 py-3 text-left text-xs font-medium uppercase text-purple-700">
                    Cliente
                  </th>
                  <th className="px-3 py-3 text-left text-xs font-medium uppercase text-purple-700">
                    CNPJ
                  </th>
                  <th className="px-3 py-3 text-left text-xs font-medium uppercase text-purple-700">
                    Endereço
                  </th>
                 <th className="px-3 py-3 text-left text-xs font-medium uppercase text-purple-700">
                    Status
                  </th>
                 <th className="px-3 py-3 text-left text-xs font-medium uppercase text-purple-700">
                    Revenda
                  </th>

                  <th className="px-3 py-3 text-left text-xs font-medium uppercase text-purple-700">
                    Data cadastro
                  </th>
                  <th className="px-3 py-3 text-left text-xs font-medium uppercase text-purple-700">
                    Data alteração
                  </th>
                </tr>
              </thead>

              <tbody className="divide-y divide-gray-200 bg-white">
                {clientes.length > 0 ? (
                  clientes.map((cliente) => (
                    <tr
                      key={`${cliente.cod_cliente}-${cliente.loja_cadastro}`}
                      className="hover:bg-gray-50"
                    >
                      <td className="whitespace-nowrap px-3 py-2 text-sm text-gray-700">
                        {cliente.cod_cliente}
                      </td>
                      <td className="px-3 py-2 text-sm text-gray-700">
                        {cliente.des_cliente}
                      </td>
                      <td className="px-3 py-2 text-sm text-gray-700">
                        CNPJ: {cliente.num_cgc} / IE {cliente.num_insc_est == '' ? 'Isento' : cliente.num_insc_est} <br />
                        Nome Fantasia: {cliente.des_fantasia} <br />
                        
                        
                      </td>

                     <td className="px-3 py-2 text-sm text-gray-700">
                        Endereço {cliente.des_endereco}, {cliente.numero} | Bairro: {cliente.des_bairro} <br />
                        Município: {cliente.des_cidade} - {cliente.des_sigla} | CEP {cliente.num_cep}
                      </td>
                     <td className="px-3 py-2 text-sm text-gray-700">
                        {cliente.status_cliente? 'Ativo' : 'Inativo'}
                      </td>
                      <td className="px-3 py-2 text-sm text-gray-700">
                        {cliente.flg_revenda}
                      </td>

                      <td className="whitespace-nowrap px-3 py-2 text-sm text-gray-700">
                        {formatarData(cliente.dta_cadastro)}
                      </td>
                      <td className="whitespace-nowrap px-3 py-2 text-sm text-gray-700">
                        {formatarData(cliente.dta_alteracao)}
                      </td>
                    </tr>
                  ))
                ) : (
                  <tr>
                    <td
                      colSpan={18}
                      className="px-6 py-8 text-center text-sm text-gray-500"
                    >
                      Nenhum cliente encontrado.
                    </td>
                  </tr>
                )}
              </tbody>
            </table>
          </div>
        </div>

        <div className="flex items-center justify-between border-b border-gray-200 bg-gray-50 px-6 py-4">
          <h3 className="font-medium text-gray-500">
            Total de registros
          </h3>

          <span className="inline-flex items-center rounded-full bg-purple-100 px-3 py-1 text-sm font-medium text-purple-800">
            {clientes.length}{' '}
            {clientes.length === 1 ? 'cliente' : 'clientes'}
          </span>
        </div>
      </div>
    </div>
  )
}