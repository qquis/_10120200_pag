import { clsBase, clsTools } from "../../../model/modelbase"


const myBase = new clsBase()

export default class serviceSistemPassWord { 
    static async generate (passwordString : string) { 
        return myBase.criptString(passwordString)
    }
}