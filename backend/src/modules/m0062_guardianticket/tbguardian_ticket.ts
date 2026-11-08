import { v4 as uuidv4 } from 'uuid';

export default class tbguardian_ticket {
         gtk_uuid: string 
         gtk_seq: number
         gtk_numero: number
         gtk_placa: string 					
         gtk_data: Date					
         gtk_pesagemInicialHora: Date							
         gtk_pesagemFinalHora: Date								
         gtk_pesagemInicialPeso: number		
         gtk_pesagemFinalPeso: number			
         gtk_pesagemPesoLiquido: number	

   public constructor(

             gtk_numero: number
        ,    gtk_placa: string 					
        ,    gtk_data: Date					
        ,    gtk_pesagemInicialHora: Date							
        ,    gtk_pesagemFinalHora: Date								
        ,    gtk_pesagemInicialPeso: number		
        ,    gtk_pesagemFinalPeso: number			
        ,    gtk_pesagemPesoLiquido: number	

       )
    {  

        try {

        this.gtk_uuid = uuidv4();
        this.gtk_seq = 0;
        this.gtk_numero = gtk_numero;
        this.gtk_placa = gtk_placa;
        this.gtk_data = gtk_data;
        this.gtk_pesagemInicialHora = gtk_pesagemInicialHora;
        this.gtk_pesagemFinalHora 	= gtk_pesagemFinalHora;
        this.gtk_pesagemInicialPeso = gtk_pesagemInicialPeso;
        this.gtk_pesagemFinalPeso	= gtk_pesagemFinalPeso;
        this.gtk_pesagemPesoLiquido = gtk_pesagemPesoLiquido;
        }
        catch (e)
        {
            this.gtk_uuid = '';
            this.gtk_seq = 0;
            this.gtk_numero = 0;
            this.gtk_placa = 'ERROR';
            this.gtk_data = new Date();
            this.gtk_pesagemInicialHora = new Date();
            this.gtk_pesagemFinalHora 	= new Date();
            this.gtk_pesagemInicialPeso = 0;
            this.gtk_pesagemFinalPeso	= 0;
            this.gtk_pesagemPesoLiquido = 0;
        }
    }

}