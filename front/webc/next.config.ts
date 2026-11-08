/** @type {import('next').NextConfig} */
const nextConfig = {
  // Habilitar compressão
  compress: true,
  
  // Otimizar imagens
  images: {
    formats: ['image/webp', 'image/avif'],
    minimumCacheTTL: 31536000, // 1 ano
  },
  
  // Gerar páginas estáticas
  output: 'export',
  trailingSlash: true,
  
  // Otimizações de build
  swcMinify: true,
  
  // Headers de cache
  async headers() {
    return [
      {
        source: '/(.*)',
        headers: [
          {
            key: 'Cache-Control',
            value: 'public, max-age=31536000, immutable',
          },
        ],
      },
    ];
  },
}
