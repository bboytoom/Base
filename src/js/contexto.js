'use strict';

function cleanInput(InputEmail) {
    return String(InputEmail).replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/"/g, '&quot;');
}

function valid_Name(Input_name) {
    var clean_input = cleanInput(Input_name);

    if (Input_name === "")
        return false;

    if (clean_input.length > 3 && clean_input.length < 29)
        return true;

    return false;
}

class Contexto {
    constructor(TIPO, ID, USUARIO, MAIN) {
        if (TIPO === 'Grupos') {
            this.estrategia = new Grupos(ID, USUARIO, MAIN);
        }

        if (TIPO === 'Usuarios') {
            this.estrategia = new Usuarios(ID, USUARIO, MAIN);
        }
    }

    CrearInterface() {
        this.estrategia.crear();
    }

    ActualizarInterface() {
        this.estrategia.actualizar();
    }

    EliminarInterface() {
        this.estrategia.eliminar();
    }
}