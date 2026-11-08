import { NextRequest, NextResponse } from 'next/server';

const API_URL = process.env.API_URL; // Agora será privada
const CUSTOM_TOKEN = process.env.CUSTOM_TOKEN; // Agora será privada

export async function GET(
  request: NextRequest,
  { params }: { params: Promise<{ path: string[] }> }
) {
  try {
    const { path } = await params; // Await nos params
    const searchParams = request.nextUrl.searchParams;
    
    // Reconstrói a URL da API
    const apiUrl = `${API_URL}/${path.join('/')}`;
    const url = new URL(apiUrl);
    
    // Adiciona query parameters se existirem
    searchParams.forEach((value, key) => {
      url.searchParams.append(key, value);
    });

    // Headers para a API backend
    const headers: HeadersInit = {
      'Content-Type': 'application/json',
      'Accept': 'application/json',
      'x-customtoken': CUSTOM_TOKEN || '',
    };

    // Adiciona headers customizados vindos da requisição
    const userLoginUuid = request.headers.get('usuario_login_uuid');
    if (userLoginUuid) {
      headers['usuario_login_uuid'] = userLoginUuid;
    }

    const response = await fetch(url.toString(), {
      method: 'GET',
      headers,
    });

    if (!response.ok) {
      throw new Error(`API Error: ${response.status} ${response.statusText}`);
    }

    const data = await response.json();
    
    return NextResponse.json(data);
  } catch (error) {
    console.error('Proxy GET Error:', error);
    return NextResponse.json(
      { error: 'Internal Server Error' },
      { status: 500 }
    );
  }
}

export async function POST(
  request: NextRequest,
  { params }: { params: Promise<{ path: string[] }> }
) {
  try {
    const { path } = await params; // Await nos params
    
    // Reconstrói a URL da API
    const apiUrl = `${API_URL}/${path.join('/')}`;

    // Obtém o body da requisição
    const body = await request.json();

    // Headers para a API backend
    const headers: HeadersInit = {
      'Content-Type': 'application/json',
      'Accept': 'application/json',
      'x-customtoken': CUSTOM_TOKEN || '',
    };

    // Adiciona headers customizados vindos da requisição
    const userLoginUuid = request.headers.get('usuario_login_uuid');
    if (userLoginUuid) {
      headers['usuario_login_uuid'] = userLoginUuid;
    }

    const response = await fetch(apiUrl, {
      method: 'POST',
      headers,
      body: JSON.stringify(body),
    });

    if (!response.ok) {
      throw new Error(`API Error: ${response.status} ${response.statusText}`);
    }

    const data = await response.json();
    
    return NextResponse.json(data);
  } catch (error) {
    console.error('Proxy POST Error:', error);
    return NextResponse.json(
      { error: 'Internal Server Error' },
      { status: 500 }
    );
  }
}

export async function PUT(
  request: NextRequest,
  { params }: { params: Promise<{ path: string[] }> }
) {
  try {
    const { path } = await params; // Await nos params
    const apiUrl = `${API_URL}/${path.join('/')}`;
    const body = await request.json();

    const headers: HeadersInit = {
      'Content-Type': 'application/json',
      'Accept': 'application/json',
      'x-customtoken': CUSTOM_TOKEN || '',
    };

    const userLoginUuid = request.headers.get('usuario_login_uuid');
    if (userLoginUuid) {
      headers['usuario_login_uuid'] = userLoginUuid;
    }

    const response = await fetch(apiUrl, {
      method: 'PUT',
      headers,
      body: JSON.stringify(body),
    });

    if (!response.ok) {
      throw new Error(`API Error: ${response.status} ${response.statusText}`);
    }

    const data = await response.json();
    
    return NextResponse.json(data);
  } catch (error) {
    console.error('Proxy PUT Error:', error);
    return NextResponse.json(
      { error: 'Internal Server Error' },
      { status: 500 }
    );
  }
}

export async function DELETE(
  request: NextRequest,
  { params }: { params: Promise<{ path: string[] }> }
) {
  try {
    const { path } = await params; // Await nos params
    const apiUrl = `${API_URL}/${path.join('/')}`;

    const headers: HeadersInit = {
      'Content-Type': 'application/json',
      'Accept': 'application/json',
      'x-customtoken': CUSTOM_TOKEN || '',
    };

    const userLoginUuid = request.headers.get('usuario_login_uuid');
    if (userLoginUuid) {
      headers['usuario_login_uuid'] = userLoginUuid;
    }

    const response = await fetch(apiUrl, {
      method: 'DELETE',
      headers,
    });

    if (!response.ok) {
      throw new Error(`API Error: ${response.status} ${response.statusText}`);
    }

    const data = await response.json();
    
    return NextResponse.json(data);
  } catch (error) {
    console.error('Proxy DELETE Error:', error);
    return NextResponse.json(
      { error: 'Internal Server Error' },
      { status: 500 }
    );
  }
}