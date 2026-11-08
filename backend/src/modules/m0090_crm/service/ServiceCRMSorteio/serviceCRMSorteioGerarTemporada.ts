

import { clsBase, clsTools } from "../../../../model/modelbase";

import reportCRM from "../../report/reportCRM";
import modelcrm_sorteio_temporada from "../../model/modelcrm_soterio_temporada";

interface NumeroSorteio {
    ordem_numero: number;
    numero_aleatorio: string;
}

export default class serviceCrmSorteioGerarTemporada { 



    static async start() : Promise<void> { 
        try { 
                const list = this.criar_numero_sorteios();
                await this.registrar(list);

        } catch (error) {
            throw error;
        }
    }

        static async registrar(list: NumeroSorteio[]) : Promise<void> { 
        try { 
            
                const myBase = new clsBase();
                let imodelcrm_sorteio_temporada : modelcrm_sorteio_temporada = await reportCRM.sorteio.Temporada.getTemporadaAtiva();
                

                let i: number = 0;
                let iNumberMaxInsert: number = 250;
                let sqlinsert: string = '';
                for await( const item of list ) {
                     let sql = `
                                insert into tbcrm_sorteio_numero
                                (
                                    	crm_so_temp_cd				
                                    ,	crm_so_numero_ordem			
                                    ,	numero						    
                                )
                                SELECT  ${imodelcrm_sorteio_temporada.crm_so_temp_cd}
                                    ,	${item.ordem_numero}
                                    ,	${item.numero_aleatorio}
                                WHERE NOT EXISTS (Select 1 from tbcrm_sorteio_numero where crm_so_temp_cd = ${imodelcrm_sorteio_temporada.crm_so_temp_cd} and numero = ${item.numero_aleatorio})
                                ;
                            `;
                    sqlinsert += sql;
                    i++;
                    if (i >= iNumberMaxInsert) {
                        await myBase.myDataBase.pag.Execute(sqlinsert);
                        sqlinsert = '';
                        i = 0;
                    }
                }

                if (sqlinsert != '') { 
                    await myBase.myDataBase.pag.Execute(sqlinsert);
                }
        } catch (error) {
            clsTools.PagErrorException("M0090_CRM", "modelcrm_sorteio_temporada - registrar", error);
            throw error;
        }
    }

        static criar_numero_sorteios(): NumeroSorteio[] { 
        try { 
            const numerosGerados = new Set<string>();
            const arrayNumeros: NumeroSorteio[] = [];
            let ordem = 1;

            while (numerosGerados.size < 99999) {
                // 1) Criar os dois primeiros dígitos aleatoriamente (10-99)
                const primeiros2Digitos = Math.floor(Math.random() * 90) + 10;
                
                // 2) Criar os últimos 5 dígitos aleatoriamente (00000-99999)
                const ultimos5Digitos = Math.floor(Math.random() * 100000);
                
                // 3) Formatar os últimos 5 dígitos com zeros à esquerda
                const ultimos5DigitosFormatados = ultimos5Digitos.toString().padStart(5, '0');
                
                // 4) Juntar os dois primeiros com os 5 dígitos
                const numeroCompleto = primeiros2Digitos.toString() + ultimos5DigitosFormatados;
                
                // 5) Verificar se o número já existe (não repetir)
                if (!numerosGerados.has(numeroCompleto)) {
                    numerosGerados.add(numeroCompleto);
                    
                    // 6) Adicionar ao array com ordem
                    arrayNumeros.push({
                        ordem_numero: ordem,
                        numero_aleatorio: numeroCompleto
                    });
                    
                    ordem++;
                }
            }

            return arrayNumeros;

        } catch (error) {
            clsTools.PagErrorException("M0090_CRM", "modelcrm_sorteio_temporada - criar_numero_sorteios", error);
            throw error;
        }
    }

    // Método auxiliar para gerar um único número (caso precise)
    static gerar_numero_unico(numerosExistentes: Set<string>): string {
        let numeroGerado: string;
        let tentativas = 0;
        const maxTentativas = 1000;

        do {
            // Primeiros 2 dígitos (10-99)
            const primeiros2 = Math.floor(Math.random() * 90) + 10;
            
            // Últimos 5 dígitos (00000-99999)
            const ultimos5 = Math.floor(Math.random() * 100000).toString().padStart(5, '0');
            
            numeroGerado = primeiros2.toString() + ultimos5;
            tentativas++;

            if (tentativas > maxTentativas) {
                throw new Error('Não foi possível gerar número único após muitas tentativas');
            }

        } while (numerosExistentes.has(numeroGerado));

        return numeroGerado;
    }

    // Método para validar se um número está no formato correto
    static validar_numero_formato(numero: string): boolean {
        // Deve ter exatamente 7 dígitos
        if (numero.length !== 7) return false;
        
        // Deve conter apenas números
        if (!/^\d{7}$/.test(numero)) return false;
        
        // Os dois primeiros dígitos devem ser >= 10
        const primeiros2 = parseInt(numero.substring(0, 2));
        if (primeiros2 < 10) return false;
        
        return true;
    }

    // Método para ordenar os números gerados
    static ordenar_numeros(numeros: NumeroSorteio[], tipo: 'ordem' | 'numero' = 'ordem'): NumeroSorteio[] {
        return numeros.sort((a, b) => {
            if (tipo === 'ordem') {
                return a.ordem_numero - b.ordem_numero;
            } else {
                return a.numero_aleatorio.localeCompare(b.numero_aleatorio);
            }
        });
    }

}