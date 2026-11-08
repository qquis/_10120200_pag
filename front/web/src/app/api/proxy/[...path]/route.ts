import { NextRequest, NextResponse } from 'next/server'
import axios from 'axios'

export async function GET(request: NextRequest, { params }: { params: { path: string[] } }) {
    return handleRequest(request, params, 'GET')
}

export async function POST(request: NextRequest, { params }: { params: { path: string[] } }) {
    return handleRequest(request, params, 'POST')
}

export async function PUT(request: NextRequest, { params }: { params: { path: string[] } }) {
    return handleRequest(request, params, 'PUT')
}

export async function DELETE(request: NextRequest, { params }: { params: { path: string[] } }) {
    return handleRequest(request, params, 'DELETE')
}

async function handleRequest(request: NextRequest, params: { path: string[] }, method: string) {
    try {
        // Construir o path da API
        const apiPath = params.path.join('/')
        
        // URL completa para a API externa (usando o .env)
        const fullUrl = `${process.env.API_URL}/${apiPath}`
        
        // Extrair query parameters
        const searchParams = request.nextUrl.searchParams
        const queryParams = Object.fromEntries(searchParams.entries())

        // Headers base
        const headers: any = {
            'Content-Type': 'application/json',
            'Accept': 'application/json',
            'x-customtoken': process.env.API_CUSTOM_TOKEN,
        }


        const API_SIS_CD = process.env.API_SIS_CD || '5' // Valor padrão caso a variável de ambiente não esteja definida
        headers['sis-cd'] = API_SIS_CD


        // Adicionar usuario_login_uuid se existir nos headers da requisição
        const userLoginUuid = request.headers.get('usuario-login-uuid')
        if (userLoginUuid) {
            headers['usuario-login-uuid'] = userLoginUuid
        }
       
        const user_name = request.headers.get('user-name')
        if (user_name) {
            headers['user-name'] = user_name
        }
       
        const user_credential = request.headers.get('user-credential')
        if (user_credential) {
            headers['user-credential'] = user_credential
        }

        const sis_ac_cd = request.headers.get('sis-ac-cd')
        if (sis_ac_cd) {
            headers['sis-ac-cd'] = sis_ac_cd
        }

        const sis_cd = request.headers.get('sis-cd')
        if (sis_cd) {
            headers['sis-cd'] = sis_cd
        }

        // Preparar body para POST/PUT
        let data = undefined
        if (method === 'POST' || method === 'PUT') {
            data = await request.json().catch(() => undefined)
        }

        // Fazer requisição para API externa
        const response = await axios({
            method: method,
            url: fullUrl,
            headers: headers,
            data: data,
            params: queryParams,
            timeout: 0
        })

        return NextResponse.json(response.data, { status: response.status })

    } catch (error) {
        
        if (axios.isAxiosError(error)) {
            return NextResponse.json(
                { error: error.response?.data || 'Erro na API externa' },
                { status: error.response?.status || 500 }
            )
        } else {
            return NextResponse.json(
                { error: 'Erro interno do servidor' },
                { status: 500 }
            )
        }
    }
}