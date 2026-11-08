import { clsBase, clsTools } from "../../../model/modelbase";

import rptEnterpriseCompetenciaList from './rptEnterpriseCompetenciaListGet';
import rptEnterpriseEmpresaOperacaoList from "./rptEnterpriseEmpresaOperacao";

export default class reportEnterprise {
    static Competencia = rptEnterpriseCompetenciaList
    static EmpresaOperacao = rptEnterpriseEmpresaOperacaoList
}