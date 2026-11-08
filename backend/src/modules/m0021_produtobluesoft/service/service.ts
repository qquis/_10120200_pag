import { clsBase, clsTools } from '../../../model/modelbase';

import serviceProdutoBluesoftApiImportar from './serviceProdutoBluesoftApiImportar';
import serviceProdutoBluesoftProcessarImportacoes from './serviceProdutoBluesoftProcessarImportacoes';

export default class serviceProdutoBluesoft  {
    static ProcessarImportacoes = serviceProdutoBluesoftProcessarImportacoes
    static Importar = serviceProdutoBluesoftApiImportar

}