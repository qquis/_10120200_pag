const fs = require('fs');
const path = require('path');

// Captura a versão do argumento da linha de comando
const newVersion = process.argv[2];

if (!newVersion) {
    console.error('❌ Erro: Versão não informada!');
    console.log('📝 Uso: node update_version.js <versão>');
    console.log('📝 Exemplo: node update_version.js 20.17.01.03');
    process.exit(1);
}

const projectRoot = path.resolve(__dirname, '../');
const targetDirs = ['backend', 'front', 'service']; // Diretórios específicos

function updatePackageJson(dir) {
    const packageJsonPath = path.join(dir, 'package.json');
    
    if (fs.existsSync(packageJsonPath)) {
        try {
            const packageJson = JSON.parse(fs.readFileSync(packageJsonPath, 'utf8'));
            const oldVersion = packageJson.version;
            packageJson.version = newVersion;
            
            fs.writeFileSync(packageJsonPath, JSON.stringify(packageJson, null, 2) + '\n');
            console.log(`✓ ${path.relative(projectRoot, dir)}: ${oldVersion} → ${newVersion}`);
        } catch (error) {
            console.error(`✗ Erro em ${dir}:`, error.message);
        }
    }
}

function searchRecursively(dir) {
    const packageJsonPath = path.join(dir, 'package.json');
    if (fs.existsSync(packageJsonPath)) {
        updatePackageJson(dir);
    }
    
    try {
        const items = fs.readdirSync(dir, { withFileTypes: true });
        for (const item of items) {
            if (item.isDirectory() && 
                !item.name.startsWith('.') && 
                item.name !== 'node_modules' &&
                item.name !== 'dist' &&
                item.name !== 'build') {
                searchRecursively(path.join(dir, item.name));
            }
        }
    } catch (error) {
        // Ignora erros de acesso
    }
}

console.log(`🔍 Atualizando versão para ${newVersion}...`);
console.log(`📁 Raiz do projeto: ${projectRoot}\n`);

// Buscar em diretórios específicos
targetDirs.forEach(dirName => {
    const dirPath = path.join(projectRoot, dirName);
    if (fs.existsSync(dirPath)) {
        console.log(`📂 Processando: ${dirName}`);
        searchRecursively(dirPath);
    } else {
        console.log(`⚠️ Diretório não encontrado: ${dirName}`);
    }
});

console.log(`\n🎉 Processo concluído!`);