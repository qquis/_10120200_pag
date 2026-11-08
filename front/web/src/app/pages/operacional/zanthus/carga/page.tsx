'use client'

import { useMemo, useState } from 'react'
import { useAuth } from '@/app/context/context'

import ConfirmDialog from '@/app/components/DialogConfirm/confirmDialog'
import HeaderMain from '@/app/components/divs/headerMain'
import ButtonPag from '@/app/components/Buttons/button'
import { moduleZanthus } from '@/api/m0085_zanthus/moduleZanthus' 


export default function CargaPage() {
  const { user } = useAuth()

  const moduloZanthus = useMemo(() => new moduleZanthus(user, 85), [user])

  const hoje = new Date().toISOString().substring(0, 10)
  const [dataIni, setDataIni] = useState(hoje)
  const [dataFim, setDataFim] = useState(hoje)

  const [cargas, setCargas] = useState<any[]>([])
  const [loading, setLoading] = useState(false)
  const [erro, setErro] = useState<string | null>(null)

  const formatarData = (valor?: string) => {
    if (!valor) return ''
    const data = new Date(valor)
    if (Number.isNaN(data.getTime())) return valor
    return data.toLocaleDateString('pt-BR')
  }

  const formatarHora = (valor?: string) => {
    if (!valor) return ''
    const data = new Date(valor)
    if (Number.isNaN(data.getTime())) return valor
    return data.toLocaleTimeString('pt-BR')
  }

  const [confirmOpen, setConfirmOpen] = useState(false)

  const enviarCarga = async () => {
    setConfirmOpen(true)
    
    
    try {
      if (!confirmOpen) { 
        return
      }
      setErro(null)
      setLoading(true)
      setConfirmOpen(false )
      await moduloZanthus.postCarga({ carga_tipo_cd: 1 })
      await consultarCargas()
    } catch (e) {
      console.error('Erro ao enviar carga:', e)
      setErro('Não foi possível enviar a carga.')
    } finally {
      setLoading(false)
    }
  }

  const consultarCargas = async () => {
    setLoading(true)
    setErro(null)

    // Nomes dos parâmetros: confirmar com o endpoint /zanthus/report/carga
    const parametros: any = {
      data_carga_ini: dataIni,
      data_carga_fim: dataFim,
    }

    try {
      const resposta = await moduloZanthus.getReportCarga(parametros)
      setCargas(Array.isArray(resposta) ? resposta : [])
    } catch (e) {
      console.error('Erro ao consultar cargas:', e)
      setCargas([])
      setErro('Não foi possível consultar o relatório de cargas.')
    } finally {
      setLoading(false)
    }
  }

  const th =
    'px-3 py-3 text-left text-xs font-medium uppercase text-purple-700'
  const td = 'whitespace-nowrap px-3 py-2 text-sm text-gray-700'
  const input =
    'w-full rounded-md border border-gray-300 p-2 text-black focus:border-transparent focus:ring-2 focus:ring-purple-500'

  return (
    <div className="min-h-screen bg-gray-50 p-6">
      <div className="mx-auto max-w-7xl">
        <HeaderMain
          tipo="_PAGE"
          ActionStatus={loading ? 1 : 0}
          header_title="Zanthus | Processamento de Carga"
        >
          <div className="flex space-x-2">
            <ButtonPag
              TypeButton="_BUTTON_HEADER"
              label={loading ? 'Enviando...' : 'Enviar carga'}
              TypeIcon="_SALVAR"
              title="Enviar carga"
              onClick={enviarCarga}
              ActionStatus={loading ? 1 : 0}
            />
            <ButtonPag
              TypeButton="_BUTTON_HEADER"
              label={loading ? 'Consultando...' : 'Pesquisar'}
              TypeIcon="_PESQUISAR"
              title="Pesquisar cargas"
              onClick={consultarCargas}
              ActionStatus={loading ? 1 : 0}
            />
          </div>
        </HeaderMain>

        <div className="mb-6 rounded-lg border border-purple-100 bg-white p-6 shadow-md">
          <div className="grid grid-cols-1 gap-4 md:grid-cols-2">
            <div>
              <label
                htmlFor="data-ini"
                className="mb-1 block text-sm font-medium text-gray-700"
              >
                Data inicial
              </label>
              <input
                id="data-ini"
                type="date"
                disabled={loading}
                className={input}
                value={dataIni}
                onChange={(e) => setDataIni(e.target.value)}
              />
            </div>

            <div>
              <label
                htmlFor="data-fim"
                className="mb-1 block text-sm font-medium text-gray-700"
              >
                Data final
              </label>
              <input
                id="data-fim"
                type="date"
                disabled={loading}
                className={input}
                value={dataFim}
                onChange={(e) => setDataFim(e.target.value)}
              />
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
            <table className="min-w-full divide-y divide-gray-200">
              <thead className="sticky top-0 z-10 bg-gray-100">
                <tr>
                  <th className={th}>Registro</th>
                  <th className={th}>Tipo</th>
                  <th className={th}>Seq.</th>
                  <th className={th}>Data</th>
                  <th className={th}>Início</th>
                  <th className={th}>Fim</th>
                  <th className={th}>Status</th>
                  <th className={th}>Usuário</th>
                  <th className={`${th} text-right`}>Qtde Códigos Unitários</th>
                  <th className={`${th} text-right`}>Qtde Embalagens</th>
                  <th className={`${th} text-right`}>Qtde EANS</th>
                </tr>
              </thead>

              <tbody className="divide-y divide-gray-200 bg-white">
                {cargas.length > 0 ? (
                  cargas.map((carga) => (
                    <tr key={carga.carga_uuid} className="hover:bg-gray-50">
                      <td className={td}>{carga.carga_uuid}</td>
                      <td className={td}>
                        {carga.carga_tipo_cd} - {carga.carga_tipo_descricao}
                      </td>
                      <td className={td}>{carga.carga_seq}</td>
                      <td className={td}>{formatarData(carga.carga_data)}</td>
                      <td className={td}>{formatarHora(carga.carga_hora_ini)}</td>
                      <td className={td}>{formatarHora(carga.carga_hora_fim)}</td>
                      <td className={td}>{carga.carga_status_descricao}</td>
                      <td className={td}>{carga.usuario_nome_razao}</td>
                      <td className={`${td} text-right`}>{carga.qtd_unitario}</td>
                      <td className={`${td} text-right`}>{carga.qtd_bluesoft}</td>
                      <td className={`${td} text-right`}>{carga.qtd_mercadoria}</td>
                    </tr>
                  ))
                ) : (
                  <tr>
                    <td
                      colSpan={11}
                      className="px-6 py-8 text-center text-sm text-gray-500"
                    >
                      Nenhuma carga encontrada.
                    </td>
                  </tr>
                )}
              </tbody>
            </table>
          </div>
        </div>

        <div className="flex items-center justify-between border-b border-gray-200 bg-gray-50 px-6 py-4">
          <h3 className="font-medium text-gray-500">Total de registros</h3>

          <span className="inline-flex items-center rounded-full bg-purple-100 px-3 py-1 text-sm font-medium text-purple-800">
            {cargas.length} {cargas.length === 1 ? 'carga' : 'cargas'}
          </span>
        </div>
      </div>
      <ConfirmDialog
        open={confirmOpen}
        title="Zanthus | Enviar carga"
        message="Deseja realmente enviar a carga?"
        confirmLabel="Enviar"
        onConfirm={enviarCarga}
        onCancel={() => setConfirmOpen(false)}
      />
    </div>
  )
}