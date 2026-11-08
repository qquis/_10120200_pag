import { clsTools, clsBase} from '../../../model/modelbase'
import tbcrm_sorteio_cupom from '../tbs/tbcrm_sorteio_cupom';


/*
    Tabelas relacionadas
*/

import modelzanthus_cupom from 'src/modules/m0055_faturamento_zanthus/model/modelzanthus_cupom';
import f0090_10_crm_sorteio_cupom_crud from '../script/f0090_10_crm_sorteio_cupom_crud';


export default class modelcrm_sorteio_cupom extends tbcrm_sorteio_cupom {

    constructor() { 
        super();
        
        
    }

    calcular_qtde_numero_sorteio(valor_minimo: number): number { 

        let qtde_numeros : number = 0;
        
        if (valor_minimo > 0) { 
            qtde_numeros = Math.floor(this.valor /  valor_minimo);
        }

        return qtde_numeros;
    }

    script_insert_cupom_zanthus(crm_so_temp_cd: number, crm_so_temp_valor_minimo: number, CumpoZanthus : modelzanthus_cupom) : string {

        let x = clsTools._datemomentDateToStr(CumpoZanthus.data, 'YYYY-MM-DD') + ' ' + CumpoZanthus.hora_ini
        

        this.crm_so_temp_cd = crm_so_temp_cd;
        this.numero_cupom = CumpoZanthus.numero_cupom;''
        this.numero_pedido = 0;
        this.sat_ecf = CumpoZanthus.ecf;
        this.data_emissao = CumpoZanthus.data;
        this.data_emissao_hora = clsTools._datemomentDatStrToDate(x, 'YYYY-MM-DD HH:mm:ss');
        

        this.nf_numero = CumpoZanthus.nf_numero;
        this.nf_data_emissao = CumpoZanthus.data;
        this.nf_chave = CumpoZanthus.nf_chave;

        this.valor = CumpoZanthus.valor;
        this.cpf_cnpj = this.myTools.document.formatdb(CumpoZanthus.cpf_cnpj);
        this.crm_so_cpf = '';
        this.cdparticipante = 0;
        this.crm_so_qtde_numero_sorteio = this.calcular_qtde_numero_sorteio(crm_so_temp_valor_minimo);
        
        return this.script_insert();


    }


    script_insert(): string { 

        let sql : string = f0090_10_crm_sorteio_cupom_crud.get(this)
        return sql;

        /*
        let sql : string = `
        
        insert into tbcrm_sorteio_cupom 
			(
	
				     	crm_so_temp_cd				
                    ,	numero_cupom				
                    ,	numero_pedido 				
                    ,	data_emissao				
                    ,   sat_ecf						
                    ,	nf_numero					
                    ,	nf_data_emissao				
                    ,	nf_chave					
                    ,	valor						
                    ,	cpf_cnpj					
                    ,   crm_so_cpf					
                    ,   cdparticipante				
                    ,   crm_so_qtde_numero_sorteio
			
			)
                    SELECT ${this.crm_so_temp_cd} 
                         , ${this.numero_cupom}
                         , ${this.numero_pedido}
                         , '${this.myTools._datemomentDateToStr(this.data_emissao, `YYYY-MM-DD`)}'
                         , ${this.sat_ecf}
                         , ${this.nf_numero}
                         , '${this.myTools._datemomentDateToStr(this.nf_data_emissao, `YYYY-MM-DD`)}'
                         , '${this.nf_chave}'
                         , ${this.valor}
                         , '${this.myTools.document.formatdb(this.cpf_cnpj)}'
                         , '${this.crm_so_cpf}'
                         , ${this.cdparticipante}
                         , ${this.crm_so_qtde_numero_sorteio}

                    WHERE NOT EXISTS (
                        SELECT 1 
                        FROM   tbcrm_sorteio_cupom 
                        WHERE  1 = 1 
                        AND    nf_chave = '${this.nf_chave}'
                    );
        
        `;*/

   }


   async registrar_cupom() : Promise<modelcrm_sorteio_cupom> { 
        try  { 

            const modeldb = new clsBase();
            let sql = `UPDATE tbcrm_sorteio_cupom 
                      set crm_so_cpf = '${clsTools.document.formatdb(this.crm_so_cpf)}'
                        , crm_so_registrado = 1
                        , crm_so_log_registro = current_timestamp
                      WHERE 1 = 1
                      and   nf_chave = '${this.nf_chave}'
                      and   crm_so_cpf = ''
                      and   ( 
                                cpf_cnpj = '${clsTools.document.formatdb(this.cpf_cnpj)}'
                                or cpf_cnpj = ''
                            );
            `
            await modeldb.myDataBase.pag.Execute(sql);
            await this.consultar({ nf_chave: this.nf_chave });


        } catch (e) { 
            clsTools.PagErrorException(`modelcrm_sorteio_cupom`,`registrar_cupom`, e);  


        } finally { 
            return this;
        }
   }

   async consultar(parametros: any) : Promise<void> { 
       try {
           const modeldb = new clsBase();
           let sql = `SELECT * 
                      FROM tbcrm_sorteio_cupom 
                      WHERE 1 = 1
                      AND  nf_chave = '${parametros.nf_chave}'
                    `;
           let result = await modeldb.myDataBase.pag.DataGet(sql)
           this.binding( await modeldb.myDataBase.RecordItem(result, 0));
       } catch (e) {
           clsTools.PagErrorException(`modelcrm_sorteio_cupom`,`consultar`, e);
       }
   }

 }


