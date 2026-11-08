"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.clsBaseTb = void 0;
class clsBaseTb {
    constructor() {
    }
    script_insert() {
        return '';
    }
    script_update() {
        return '';
    }
    script_CRUD() {
        return this.script_insert() + '\n' + this.script_update();
    }
}
exports.clsBaseTb = clsBaseTb;
