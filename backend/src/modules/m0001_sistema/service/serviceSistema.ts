import { clsBase } from "../../../model/modelbase"
import f0001_01_sistema_backend_start from "../scriptdb/f0001_01_sistema_start"
import serviceNotificacao from '../../m0210_notificacao/service/_serviceNotificacao';

import serviceSistemaNotificacao from "./serviceSistemaNotificacao";
import serviceSistemaLogin from "./serviceSistemaLogin";
import serviceSistemPassWord from "./servicesistemaPassWord";
import serviceSistemaBackendStart from "./serviceSistemaBackendStart";


export default class serviceSistema { 
    static Notificacao = serviceSistemaNotificacao
    static Login = serviceSistemaLogin
    static PassWord = serviceSistemPassWord
    static BackendStart = serviceSistemaBackendStart


}