# IMAGEM BASICA im_node_base
FROM node:20-slim AS im_node_base

    # Instalar as dependências basicas + Python e build tools
    RUN apt-get update && apt-get install -y \
        wget \
        gnupg \
        ca-certificates \
        procps \
        curl \
        python3 \
        python3-pip \
        build-essential \
        make \
        g++ \
        unixodbc-dev \
        && rm -rf /var/lib/apt/lists/*

    # Criar link simbólico para python
    RUN ln -s /usr/bin/python3 /usr/bin/python

    # Criar usuário não-root para segurança
    RUN groupadd -r nodeuser && useradd -r -g nodeuser -s /bin/false nodeuser

# IMAGEM BACKEND
FROM im_node_base AS base_im_backend
WORKDIR /app

# Copiar apenas projetos complementares
COPY ../tools/ ./tools/
COPY ../front/Api/ ./front/Api/

# Configurar variáveis para node-gyp
ENV PYTHON=/usr/bin/python3
ENV npm_config_python=/usr/bin/python3

# Ajustar permissões
RUN chown -R nodeuser:nodeuser /app
USER nodeuser