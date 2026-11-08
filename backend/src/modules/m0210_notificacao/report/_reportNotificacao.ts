import {ifilter} from '../interfaces'
import {clsBase} from '../../../model/modelbase'
import rptNotificacaoSendMessage from './rptNotificacaoSendMessage';


class ReportNotificacaox extends clsBase {
    constructor () {
        super()
    }

    public async rptNotificacaoSendMessageGet(filter: ifilter): Promise<rptNotificacaoSendMessage> {
        let rpt = new rptNotificacaoSendMessage()
        try {
            let result = await this.myDataBase.pag.DataGet(rpt.sql(filter))
            if (result) {

                await rpt.dataBinding(result)
            }
        } catch (e) {
            this.myTools.PagErrorException('ReportNotificacaox', 'rptNotificacaoSendMessageGet', e)
        } finally { 
            return rpt
        }
    }

}

export default ReportNotificacaox