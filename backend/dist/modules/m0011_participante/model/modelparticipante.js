"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __asyncValues = (this && this.__asyncValues) || function (o) {
    if (!Symbol.asyncIterator) throw new TypeError("Symbol.asyncIterator is not defined.");
    var m = o[Symbol.asyncIterator], i;
    return m ? m.call(o) : (o = typeof __values === "function" ? __values(o) : o[Symbol.iterator](), i = {}, verb("next"), verb("throw"), verb("return"), i[Symbol.asyncIterator] = function () { return this; }, i);
    function verb(n) { i[n] = o[n] && function (v) { return new Promise(function (resolve, reject) { v = o[n](v), settle(resolve, reject, v.done, v.value); }); }; }
    function settle(resolve, reject, d, v) { Promise.resolve(v).then(function(v) { resolve({ value: v, done: d }); }, reject); }
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const modelbase_1 = require("../../../model/modelbase");
/*Tabela Principal de Participante */
const tbparticipante_1 = __importDefault(require("../tbs/tbparticipante"));
const f0011_01_ParticipanteBlueSoft_CRUD_1 = __importDefault(require("../script/f0011_01_ParticipanteBlueSoft_CRUD"));
/*reports*/
const reportParticipanteRhList_1 = __importDefault(require("../report/reportParticipanteRhList"));
const reportParticipanteVipList_1 = __importDefault(require("../report/reportParticipanteVipList"));
const reportParticipanteBlueSoftList_1 = __importDefault(require("../report/reportParticipanteBlueSoftList"));
/*services*/
const serviceSistemaPermissao_1 = __importDefault(require("../../m0001_sistema/service/serviceSistemaPermissao"));
/*Tipos de Participantes*/
const dataManager = new modelbase_1.clsBase();
class modelParticipante extends tbparticipante_1.default {
    constructor(filter) {
        super();
        this.listInfo = [];
        this.listEnderecos = [];
        this.filter = filter;
        this.dados = {};
        this.contatos = [];
    }
    Consultar() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                yield this.ConsultarListInfo();
                yield this.ConsultarParticipantePag();
                if (this.cdparticipante && this.cdparticipante > 0) {
                    yield this.ConsultarParticipanteRh();
                    yield this.ConsultarParticipanteVIP();
                    yield this.ConsultarParticipanteBlueSoft();
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("modelParticipante", "dataBinding", e);
            }
        });
    }
    ConsultarListInfo() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                this.listInfo = [
                    { info: "BLUE", resume: "Informações BlueSoft" },
                    { info: "VIP", resume: "Informações VIP/E-commerce" }
                ];
                /* CONFERE SE O USUÁRIO TEM PERMISSÃO PARA VER INFORMAÇÕES RH / DATAMACE */
                if (yield serviceSistemaPermissao_1.default.getFindPermissaoTarefa(this.filter, 99915100)) {
                    this.listInfo.push({ info: "RH", resume: "Informações RH / DATAMACE" });
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("modelParticipante", "dataBindingListInfo", e);
            }
        });
    }
    ConsultarParticipantePag() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let sql = `select 	cdparticipante 
                        ,	nome_razao 
                        ,	email_main
                        ,	celular_dd
                        ,	celular_numero
                    from tbparticipante t
                    where 1 = 1
                    and   t.cdparticipante = ${this.cdparticipante}
                    `;
                if (this.cdparticipante && this.cdparticipante > 0) {
                    let dataItem = yield dataManager.myDataBase.RecordItem(yield dataManager.myDataBase.pag.DataGet(sql), 0);
                    if (dataItem) {
                        this.bindingFromRedShift(dataItem);
                    }
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("modelParticipante", "dataBindingBase", e);
            }
        });
    }
    ConsultarParticipanteRh() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (this.cdparticipante && this.cdparticipante > 0) {
                    this.infoRh = yield reportParticipanteRhList_1.default.get({ cdparticipante: this.cdparticipante });
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("modelParticipante", "dataBindingRh", e);
            }
        });
    }
    ConsultarParticipanteVIP() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (this.cdparticipante && this.cdparticipante > 0) {
                    this.infoVip = yield reportParticipanteVipList_1.default.get({ cdparticipante: this.cdparticipante });
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("modelParticipante", "dataBindingVip", e);
            }
        });
    }
    ConsultarParticipanteBlueSoft() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                if (this.cdparticipante && this.cdparticipante > 0) {
                    this.infoBlueSoft = yield reportParticipanteBlueSoftList_1.default.get({ cdparticipante: this.cdparticipante });
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("modelParticipante", "dataBindingBlueSoft", e);
            }
        });
    }
    ObterDadosAPIBlueSoft(item) {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_1, _b, _c, _d, e_2, _e, _f;
            var _g, _h;
            let result = null;
            try {
                if (item) {
                    yield this.bindingFromBlueSoftAPI(item);
                    this.dados.tipocliente = item.tipoCliente;
                    this.dados.data_nascimento = item.dataNascimento ? modelbase_1.clsTools._datemomentDateToStr(modelbase_1.clsTools._datemomentDatStrToDate(item.dataNascimento, "DD/MM/YYYY"), "YYYY-MM-DD") : "1900-01-01";
                    this.dados.dataNascimento = item.dataNascimento;
                    this.dados.bluesoftclientestatus = (item === null || item === void 0 ? void 0 : item.clienteStatus) ? (item === null || item === void 0 ? void 0 : item.clienteStatus) == 'ATIVO' ? 1 : 0 : 0;
                    this.dados.bluesoft_pessoa_status = 1;
                    this.dados.bluesoft_pessoa_data_cadastro = (item === null || item === void 0 ? void 0 : item.dataCadastro) ? modelbase_1.clsTools._datemomentDateToStr(modelbase_1.clsTools._datemomentDatStrToDate(item.dataCadastro, "DD/MM/YYYY HH:mm"), "YYYY-MM-DD") : "1900-01-01";
                    /*
                     
                    1	"CREDITO OK"	"CREDITO_OK"
                    2	"BLOQUEADO"	"BLOQUEADO"
                    3	"DEVEDOR"	"DEVEDOR"
                    4	"PROTESTADO"	"PROTESTADO"
                    5	"EM ANALISE"	"EM_ANALISE"
                    
                    */
                    if (item === null || item === void 0 ? void 0 : item.saldosDoCliente) {
                        if ((_g = item === null || item === void 0 ? void 0 : item.saldosDoCliente) === null || _g === void 0 ? void 0 : _g.statusCredito) {
                            let statusCreditoBlue = (_h = item === null || item === void 0 ? void 0 : item.saldosDoCliente) === null || _h === void 0 ? void 0 : _h.statusCredito;
                            switch (statusCreditoBlue) {
                                case 'CREDITO_OK':
                                    this.dados.bluesoftcliente_creditostatus_cd = 1;
                                    break;
                                case 'BLOQUEADO':
                                    this.dados.bluesoftcliente_creditostatus_cd = 2;
                                    break;
                                case 'DEVEDOR':
                                    this.dados.bluesoftcliente_creditostatus_cd = 3;
                                    break;
                                case 'PROTESTADO':
                                    this.dados.bluesoftcliente_creditostatus_cd = 4;
                                    break;
                                case 'EM_ANALISE':
                                    this.dados.bluesoftcliente_creditostatus_cd = 5;
                                    break;
                            }
                        }
                    }
                    if (item.enderecos && item.enderecos.length > 0) {
                        try {
                            for (var _j = true, _k = __asyncValues(item.enderecos), _l; _l = yield _k.next(), _a = _l.done, !_a; _j = true) {
                                _c = _l.value;
                                _j = false;
                                const endereco = _c;
                                /*Selecionar qualquer tipo de endereço*/
                                let itemEndereco = {};
                                itemEndereco.descricaobluesoft_api = endereco.tipoDeEndereco;
                                itemEndereco.ibge_municipio_cd = (endereco === null || endereco === void 0 ? void 0 : endereco.codigoDoMunicipioNoIBGE) ? endereco === null || endereco === void 0 ? void 0 : endereco.codigoDoMunicipioNoIBGE : '';
                                itemEndereco.endereco_cep = (endereco === null || endereco === void 0 ? void 0 : endereco.cep) ? endereco === null || endereco === void 0 ? void 0 : endereco.cep.replace("-", "") : '00000000';
                                itemEndereco.endereco_logradouro = (endereco === null || endereco === void 0 ? void 0 : endereco.rua) ? endereco === null || endereco === void 0 ? void 0 : endereco.rua.replace("'", "").toUpperCase() : '';
                                itemEndereco.endereco_bairro = (endereco === null || endereco === void 0 ? void 0 : endereco.bairro) ? endereco === null || endereco === void 0 ? void 0 : endereco.bairro.replace("'", "").toUpperCase() : '';
                                itemEndereco.endereco_municipio = (endereco === null || endereco === void 0 ? void 0 : endereco.cidade) ? endereco === null || endereco === void 0 ? void 0 : endereco.cidade.replace("'", "").toUpperCase().replace("Ç", "C").replace("Á", "A").replace("É", "E").replace("Í", "I").replace("Ó", "O").replace("Ú", "U") : '';
                                itemEndereco.endereco_numero = (endereco === null || endereco === void 0 ? void 0 : endereco.numero) ? endereco === null || endereco === void 0 ? void 0 : endereco.numero.replace("'", "").toUpperCase() : '';
                                itemEndereco.endereco_uf = (endereco === null || endereco === void 0 ? void 0 : endereco.uf) ? endereco === null || endereco === void 0 ? void 0 : endereco.uf.toUpperCase() : '';
                                itemEndereco.endereco_longitude = (endereco === null || endereco === void 0 ? void 0 : endereco.longitude) ? endereco === null || endereco === void 0 ? void 0 : endereco.longitude : '0';
                                itemEndereco.endereco_latitude = (endereco === null || endereco === void 0 ? void 0 : endereco.latitude) ? endereco === null || endereco === void 0 ? void 0 : endereco.latitude : '0';
                                itemEndereco.endereco_complemento = (endereco === null || endereco === void 0 ? void 0 : endereco.complemento) ? endereco === null || endereco === void 0 ? void 0 : endereco.complemento.replace("'", "").toUpperCase() : '';
                                this.listEnderecos.push(itemEndereco);
                                if (endereco.tipoDeEndereco === "FATURAMENTO") {
                                    this.dados = Object.assign(Object.assign({}, this.dados), itemEndereco);
                                }
                            }
                        }
                        catch (e_1_1) { e_1 = { error: e_1_1 }; }
                        finally {
                            try {
                                if (!_j && !_a && (_b = _k.return)) yield _b.call(_k);
                            }
                            finally { if (e_1) throw e_1.error; }
                        }
                    }
                    if (this.dados.endereco_cep == undefined || !this.dados.endereco_cep || this.dados.endereco_cep == '') {
                        let itemEndereco = {};
                        itemEndereco.descricaobluesoft_api = 'FATURAMENTO';
                        itemEndereco.endereco_cep = '03453000';
                        itemEndereco.endereco_logradouro = 'AV. RIO DAS PEDRAS';
                        itemEndereco.endereco_bairro = 'JARDIM ARICANDUVA';
                        itemEndereco.endereco_municipio = 'SAO PAULO';
                        itemEndereco.endereco_numero = '729';
                        itemEndereco.endereco_uf = 'SP';
                        itemEndereco.endereco_longitude = -23.562537;
                        itemEndereco.endereco_latitude = -23.501337;
                        itemEndereco.endereco_complemento = '';
                        itemEndereco.descricaobluesoft_api = '3550308';
                        this.dados = Object.assign(Object.assign({}, this.dados), itemEndereco);
                    }
                    if (item.contatos && item.contatos.length > 0) {
                        let itemContato = {};
                        try {
                            for (var _m = true, _o = __asyncValues(item.contatos), _p; _p = yield _o.next(), _d = _p.done, !_d; _m = true) {
                                _f = _p.value;
                                _m = false;
                                const contato = _f;
                                if ((contato === null || contato === void 0 ? void 0 : contato.tipoContato) == `EMAIL_NOTA_FISCAL_ELETRONICA`) {
                                    itemContato.contato_tipo_cd = 3;
                                    itemContato.contato_tipo_descricao = ``;
                                    itemContato.contato_tipo_bluesoft_api = (contato === null || contato === void 0 ? void 0 : contato.tipoContato) ? contato === null || contato === void 0 ? void 0 : contato.tipoContato : '';
                                    itemContato.contato_email = (contato === null || contato === void 0 ? void 0 : contato.valor) ? contato === null || contato === void 0 ? void 0 : contato.valor : '';
                                    break;
                                }
                            }
                        }
                        catch (e_2_1) { e_2 = { error: e_2_1 }; }
                        finally {
                            try {
                                if (!_m && !_d && (_e = _o.return)) yield _e.call(_o);
                            }
                            finally { if (e_2) throw e_2.error; }
                        }
                        this.contatos.push(itemContato);
                    }
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("modelParticipante", "ObterDadosAPIBlueSoft", e);
            }
            finally {
                return result;
            }
        });
    }
    ObterDadosRedShift(item) {
        return __awaiter(this, void 0, void 0, function* () {
            let result = null;
            try {
                if (item) {
                    yield this.bindingFromRedShift(item);
                    this.dados.bluesoft_pessoa_status = item === null || item === void 0 ? void 0 : item.bluesoftpessoastatus;
                    this.dados.bluesoftclientestatus = item === null || item === void 0 ? void 0 : item.bluesoftclientestatus;
                    this.dados.bluesoft_pessoa_data_cadastro = modelbase_1.clsTools._datemomentDateToStr(modelbase_1.clsTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.bluesoftpessoa_data_cadastro, "YYYY-MM-DDTHH:mm:ss"), "YYYY-MM-DD");
                    this.dados.email_main = item === null || item === void 0 ? void 0 : item.email_main;
                    this.dados.sexo = item === null || item === void 0 ? void 0 : item.sexo;
                    this.dados.data_nascimento = modelbase_1.clsTools._datemomentDateToStr(modelbase_1.clsTools._datemomentDatStrToDate(item === null || item === void 0 ? void 0 : item.data_nascimento, "YYYY-MM-DDTHH:mm:ss"), "YYYY-MM-DD");
                    this.dados.endereco_cep = (item === null || item === void 0 ? void 0 : item.endereco_cep) ? `${item === null || item === void 0 ? void 0 : item.endereco_cep}`.replace("-", "") : "0";
                    this.dados.endereco_logradouro = (item === null || item === void 0 ? void 0 : item.endereco_logradouro) ? item === null || item === void 0 ? void 0 : item.endereco_logradouro.replace("'", "") : "";
                    this.dados.endereco_numero = (item === null || item === void 0 ? void 0 : item.endereco_numero) ? item === null || item === void 0 ? void 0 : item.endereco_numero.replace("'", "") : "";
                    this.dados.endereco_complemento = (item === null || item === void 0 ? void 0 : item.endereco_complemento) ? item === null || item === void 0 ? void 0 : item.endereco_complemento.replace("'", "") : "";
                    this.dados.endereco_bairro = (item === null || item === void 0 ? void 0 : item.endereco_bairro) ? item === null || item === void 0 ? void 0 : item.endereco_bairro.replace("'", "") : "";
                    this.dados.endereco_municipio = (item === null || item === void 0 ? void 0 : item.endereco_municipio) ? item === null || item === void 0 ? void 0 : item.endereco_municipio.replace("'", "") : "";
                    this.dados.endereco_uf = (item === null || item === void 0 ? void 0 : item.endereco_uf) ? item === null || item === void 0 ? void 0 : item.endereco_uf.replace("'", "") : "";
                    this.dados.endereco_latitude = item === null || item === void 0 ? void 0 : item.endereco_latitude;
                    this.dados.endereco_longitude = item === null || item === void 0 ? void 0 : item.endereco_longitude;
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("modelParticipante", "ObterDadosRedShift", e);
            }
            finally {
                return result;
            }
        });
    }
    ScriptIncluirParticipanteFromRedShift(item) {
        return __awaiter(this, void 0, void 0, function* () {
            return this.ScriptCRUD("REDSHIFT");
        });
    }
    ScriptIncluirParticipanteFromAPI() {
        return __awaiter(this, void 0, void 0, function* () {
            var _a, e_3, _b, _c;
            let sql = "";
            try {
                sql = this.ScriptCRUD("API");
                try {
                    for (var _d = true, _e = __asyncValues(this.listEnderecos), _f; _f = yield _e.next(), _a = _f.done, !_a; _d = true) {
                        _c = _f.value;
                        _d = false;
                        const endereco = _c;
                        sql += `insert into tbparticipante_endereco 
                        (       endereco_tipo_cd 
                            ,   cdparticipante 
                            ,   endereco_cep 
                            ,   endereco_logradouro
                            ,   endereco_numero 
                            ,   endereco_complemento
                            ,   endereco_bairro
                            ,   endereco_municipio
                            ,   endereco_uf
                            ,   endereco_latitude
                            ,   endereco_longitude
                            ,   ibge_municipio_cd
                        )
                        select 
                               t.endereco_tipo_cd
                            ,  p.cdparticipante
                            , '${endereco.endereco_cep}'
                            , '${endereco.endereco_logradouro}'
                            , '${endereco.endereco_numero}'
                            , '${endereco.endereco_complemento}'
                            , '${endereco.endereco_bairro}'
                            , '${endereco.endereco_municipio}'
                            , '${endereco.endereco_uf}'
                            , ${endereco.endereco_latitude}
                            , ${endereco.endereco_longitude}
                            , '${endereco.ibge_municipio_cd}'
                        from   tbparticipante p, tbparticipante_endereco_tipo t
                        where  p.cdpessoabluesoft = ${this.cdpessoabluesoft}
                          and  t.descricaobluesoft_api = '${endereco.descricaobluesoft_api}'
                          and  not exists (select 1 
                                            from        tbparticipante_endereco e 
                                            where       e.cdparticipante = p.cdparticipante 
                                              and       e.endereco_tipo_cd = t.endereco_tipo_cd
                                          );
                        update tbparticipante_endereco e
                        set    endereco_cep = '${endereco.endereco_cep}',
                               endereco_logradouro = '${endereco.endereco_logradouro}',
                               endereco_numero = '${endereco.endereco_numero}',
                               endereco_complemento = '${endereco.endereco_complemento}',
                               endereco_bairro = '${endereco.endereco_bairro}',
                               endereco_municipio = '${endereco.endereco_municipio}',
                               endereco_uf = '${endereco.endereco_uf}',
                               endereco_latitude = ${endereco.endereco_latitude},
                               endereco_longitude = ${endereco.endereco_longitude},
                               ibge_municipio_cd = '${endereco.ibge_municipio_cd}',
                               dtlog_update = current_timestamp
                        from   tbparticipante p, tbparticipante_endereco_tipo t
                        where  e.cdparticipante = p.cdparticipante
                          and  e.endereco_tipo_cd = t.endereco_tipo_cd
                          and  p.cdpessoabluesoft = ${this.cdpessoabluesoft}
                          and  t.descricaobluesoft_api = '${endereco.descricaobluesoft_api}';



                        `;
                    }
                }
                catch (e_3_1) { e_3 = { error: e_3_1 }; }
                finally {
                    try {
                        if (!_d && !_a && (_b = _e.return)) yield _b.call(_e);
                    }
                    finally { if (e_3) throw e_3.error; }
                }
                if (this.contatos && this.contatos.length > 0) {
                    for (const contato of this.contatos) {
                        if ((contato === null || contato === void 0 ? void 0 : contato.contato_tipo_cd) == 3) {
                            sql += `insert into tbparticipante_contato (cdparticipante, contato_tipo_cd, contato_email)
                                select p.cdparticipante, ${contato.contato_tipo_cd}, '${contato.contato_email}'
                                from tbparticipante p
                                where p.cdpessoabluesoft = ${this.cdpessoabluesoft}
                                  and not exists (
                                      select 1
                                      from tbparticipante_contato c
                                      where c.cdparticipante = p.cdparticipante
                                        and c.contato_tipo_cd = ${contato.contato_tipo_cd}
                                  );
                                update tbparticipante_contato x
                                set contato_email = '${contato.contato_email}'
                                  , dtlog_update = current_timestamp
                                from tbparticipante p
                                where x.cdparticipante = p.cdparticipante
                                  and x.contato_tipo_cd = ${contato.contato_tipo_cd}
                                  and p.cdpessoabluesoft = ${this.cdpessoabluesoft};
                                
                                `;
                        }
                    }
                }
            }
            catch (e) {
                modelbase_1.clsTools.PagErrorException("modelParticipante", "ScriptIncluirParticipanteFromAPI", e);
            }
            finally {
                return sql;
            }
        });
    }
    ScriptCRUD(TipoScript) {
        let sql = "";
        let registro = Object.assign(Object.assign({}, this), this.dados);
        return f0011_01_ParticipanteBlueSoft_CRUD_1.default.get(registro, TipoScript);
    }
}
exports.default = modelParticipante;
