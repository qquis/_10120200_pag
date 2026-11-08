FROM node:18-slim

# Instalar dependências necessárias para o Puppeteer e Chrome
RUN apt-get update && apt-get install -y \
    wget \
    gnupg \
    ca-certificates \
    procps \
    libxss1 \
    libgconf-2-4 \
    libxrandr2 \
    libasound2 \
    libpangocairo-1.0-0 \
    libatk1.0-0 \
    libcairo-gobject2 \
    libgtk-3-0 \
    libgdk-pixbuf2.0-0 \
    libxcomposite1 \
    libxcursor1 \
    libxdamage1 \
    libxext6 \
    libxfixes3 \
    libxi6 \
    libxrender1 \
    libxtst6 \
    libxss1 \
    libglib2.0-0 \
    libnss3 \
    libnspr4 \
    libatk-bridge2.0-0 \
    libdrm2 \
    libxkbcommon0 \
    libatspi2.0-0 \
    libx11-6 \
    libxcb1 \
    xdg-utils \
    curl \
    && rm -rf /var/lib/apt/lists/*

# Instalar Google Chrome
RUN wget -q -O - https://dl.google.com/linux/linux_signing_key.pub | apt-key add - \
    && echo "deb [arch=amd64] http://dl.google.com/linux/chrome/deb/ stable main" >> /etc/apt/sources.list.d/google-chrome.list \
    && apt-get update \
    && apt-get install -y google-chrome-stable \
    && rm -rf /var/lib/apt/lists/*

# Definir diretório de trabalho
WORKDIR /app

# Copiar estrutura necessária (tools e front)
COPY tools/ ./tools/
COPY front/ ./front/

# Definir diretório de trabalho para a aplicação específica
WORKDIR /app/front/ms_adm

# Instalar dependências
RUN npm install

# Criar diretório para sessão do WhatsApp
RUN mkdir -p .wwebjs_auth logs

# Definir variáveis de ambiente
ENV NODE_ENV=production
ENV PUPPETEER_SKIP_CHROMIUM_DOWNLOAD=true
ENV PUPPETEER_EXECUTABLE_PATH=/usr/bin/google-chrome-stable

# Criar usuário não-root para segurança
RUN groupadd -r nodeuser && useradd -r -g nodeuser -s /bin/false nodeuser
RUN chown -R nodeuser:nodeuser /app
USER nodeuser

# Comando para iniciar a aplicação (sem porta fixa)
CMD ["node", "f-ms_adm.js"]