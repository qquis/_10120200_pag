'use client';

export default function Footer() {
  return (
    <footer style={{
      background: 'linear-gradient(135deg, #1e3a8a 0%, #1e40af 100%)',
      color: 'white',
      padding: '3rem 0 1rem 0',
      marginTop: 'auto'
    }}>
      {/* Informações da Empresa */}
      <div style={{
        maxWidth: '1200px',
        margin: '0 auto',
        padding: '0 1rem'
      }}>
        <div style={{
          textAlign: 'center',
          marginBottom: '2rem'
        }}>
          <h3 style={{
            fontSize: '1.8rem',
            fontWeight: '700',
            marginBottom: '1rem',
            background: 'linear-gradient(45deg, #fbbf24, #f97316)',
            WebkitBackgroundClip: 'text',
            WebkitTextFillColor: 'transparent'
          }}>
            🏢 OXAN ATACADISTA LTDA
          </h3>
          
          <div style={{
            background: 'rgba(255, 255, 255, 0.1)',
            borderRadius: '20px',
            padding: '2rem',
            marginBottom: '2rem',
            backdropFilter: 'blur(10px)',
            border: '1px solid rgba(255, 255, 255, 0.2)'
          }}>
            <div style={{
              display: 'grid',
              gridTemplateColumns: 'repeat(auto-fit, minmax(280px, 1fr))',
              gap: '1.5rem',
              alignItems: 'center',
              textAlign: 'left'
            }}>
              {/* CNPJ e Inscrição */}
              <div>
                <div style={{ marginBottom: '0.5rem' }}>
                  <strong>📋 CNPJ MATRIZ:</strong><br/>
                  57.895.328/0001-30
                </div>
                <div>
                  <strong>🏛️ Inscrição Estadual:</strong><br/>
                  111.878.420.117
                </div>
              </div>

              {/* Endereço */}
              <div>
                <strong>📍 ENDEREÇO:</strong><br/>
                Avenida Rio das Pedras, 729<br/>
                Jardim Vila Formosa<br/>
                São Paulo/SP – CEP 03453-000
              </div>

              {/* Contato */}
              <div style={{ textAlign: 'center' }}>
                <div style={{
                  background: 'linear-gradient(45deg, #f97316, #fb923c)',
                  borderRadius: '15px',
                  padding: '1rem',
                  cursor: 'pointer',
                  transition: 'all 0.3s ease'
                }}
                onMouseOver={(e) => {
                  const target = e.target as HTMLDivElement;
                  target.style.transform = 'scale(1.05)';
                }}
                onMouseOut={(e) => {
                  const target = e.target as HTMLDivElement;
                  target.style.transform = 'scale(1)';
                }}
                onClick={() => {
                  // Aqui você pode adicionar a lógica de contato (WhatsApp, telefone, etc.)
                  alert('📞 Entre em contato conosco!\n\nEm breve você será redirecionado para nossos canais de atendimento.');
                }}
                >
                  <span style={{ fontSize: '1.5rem' }}>📞</span><br/>
                  <strong>ENTRE EM CONTATO</strong>
                </div>
              </div>
            </div>
          </div>
        </div>

        {/* Linha separadora */}
        <div style={{
          height: '1px',
          background: 'linear-gradient(90deg, transparent, rgba(255,255,255,0.3), transparent)',
          margin: '2rem 0'
        }}></div>

        {/* Copyright e informações legais */}
        <div style={{
          display: 'grid',
          gridTemplateColumns: 'repeat(auto-fit, minmax(250px, 1fr))',
          gap: '1rem',
          alignItems: 'center',
          fontSize: '0.9rem',
          opacity: '0.9'
        }}>
          <div style={{ textAlign: 'center' }}>
            © 2025 OXAN Atacadista<br/>
            <span style={{ fontSize: '0.8rem', opacity: '0.8' }}>
              Desenvolvimento oxansupermercados.com.br
            </span>
          </div>
          
          <div style={{
            textAlign: 'center',
            fontSize: '0.8rem',
            lineHeight: '1.4'
          }}>
            🍪 Esse website utiliza Cookies para garantir um melhor serviço.<br/>
            Utilizando o nosso website aceita essa utilização.
          </div>
        </div>
      </div>

      {/* Estilo responsivo */}
      <style jsx>{`
        @media (max-width: 768px) {
          footer h3 {
            font-size: 1.4rem !important;
          }
          
          footer > div > div:first-child > div:first-child > div {
            grid-template-columns: 1fr !important;
            text-align: center !important;
            gap: 1rem !important;
          }
          
          footer > div > div:last-child {
            grid-template-columns: 1fr !important;
            gap: 1.5rem !important;
          }
        }
        
        @media (max-width: 480px) {
          footer {
            padding: 2rem 0 1rem 0 !important;
          }
          
          footer h3 {
            font-size: 1.2rem !important;
          }
          
          footer > div > div:first-child > div:first-child {
            padding: 1.5rem !important;
          }
        }
      `}</style>
    </footer>
  );
}