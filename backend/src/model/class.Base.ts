class clsBaseTb {
    constructor() {
    }

    script_insert(): string {
        return ''
    }

    script_update(): string {
        return ''
    }

    script_CRUD(): string {
        return this.script_insert() + '\n' + this.script_update()
    }
}


export { clsBaseTb }