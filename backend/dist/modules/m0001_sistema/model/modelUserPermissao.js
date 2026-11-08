"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class ModelUserPermissao {
    constructor() {
        this.sis_ac_gmenu_cd = 0;
        this.sis_ac_gmenu = '';
        this.sis_ac_gmenu_sub = '';
        this.sis_ac_gmenu_sub_item = '';
        this.sis_ac_href = '';
        this.sis_ac_modulo_menu_cd = 0;
        this.sis_ac_modulo_menu_descricao = '';
        this.sis_us_seq = 0;
        this.sis_fc_cd = 0;
        this.sis_ac_cd = 0;
        this.sis_ac_descricao = '';
        this.sis_ac_menu = '';
        this.sis_ta_cd = 0;
        this.sis_ta_descricao = '';
        this.sis_cd = 0;
        this.sis_descricao = ``;
        this.sis_ac_modulo_menu_cd = 0;
        this.sis_ac_modulo_menu_descricao = '';
    }
    binding(item) {
        try {
            if (item) {
                this.sis_cd = item.sis_cd;
                this.sis_descricao = item.sis_descricao;
                this.sis_us_seq = item.sis_us_seq;
                this.sis_fc_cd = item.sis_fc_cd;
                this.sis_ac_cd = item.sis_ac_cd;
                this.sis_ac_descricao = item.sis_ac_descricao;
                this.sis_ac_menu = item.sis_ac_menu;
                this.sis_ta_cd = item.sis_ta_cd;
                this.sis_ta_descricao = item.sis_ta_descricao;
                this.sis_ac_gmenu_cd = item.sis_ac_gmenu_cd;
                this.sis_ac_gmenu = item.sis_ac_gmenu;
                this.sis_ac_gmenu_sub = item.sis_ac_gmenu_sub;
                this.sis_ac_gmenu_sub_item = item.sis_ac_gmenu_sub_item;
                this.sis_ac_href = item.sis_ac_href ? item.sis_ac_href : '';
                this.sis_ac_modulo_menu_cd = item.sis_ac_modulo_menu_cd;
                this.sis_ac_modulo_menu_descricao = item.sis_ac_modulo_menu_descricao;
            }
        }
        catch (e) {
            console.log(e);
        }
    }
}
exports.default = ModelUserPermissao;
