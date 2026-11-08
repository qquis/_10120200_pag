"use strict";
/*
import { version } from "uuid";
import pagToolsDate from "../../tools/pagToolsDate"
import {Tools_pagDateTime_getDateStringShort} from "../../tools/Tools_Log";
import TbSistemaLog from "./TbSistemaLog";


export default class f9010_01_sistema_log_Crud {

    private static sqlScript_VERSION(): string {return `f9010_01_1011891_sistema_log`}

    static sqlScript_INSERT(item: TbSistemaLog ): string{return this.sqlScriptPg("DBINSERT", item)}
    
    static sqlScript_UPDATE(item: TbSistemaLog ): string{return this.sqlScriptPg("DBUPDATE", item)}

    private static sqlScriptPg(_stringCommand: string, item: TbSistemaLog): string
    {
        const script: string = `Select * from ${this.sqlScript_VERSION()}
        (  '${_stringCommand}',
                ${item.sis_log_seq} ,
                ${item.proc_log_seq} ,
                '${item.sis_log_tag}' ,
                '${item.sis_log_info}' ,
            )`
            return script;
    
    }

 

}*/ 
