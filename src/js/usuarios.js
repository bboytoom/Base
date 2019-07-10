'use strict';

class Usuarios extends Strategy {
    constructor(ID, USUARIO) {
        super(ID, USUARIO);
    }

    crear() {
        LoadModalUser(0, this._USUARIO);
    }

    actualizar() {
        var ID = this._ID;
        var USUARIO = this._USUARIO;

    }

    eliminar() {
        Swal.fire({
            type: 'question',
            text: 'Estas seguro que deseas eliminar el grupo',
            showCloseButton: true,
            showCancelButton: true,
            confirmButtonText: 'Aceptar',
            cancelButtonText: 'Cancelar'
        })
            .then((result) => {
                
            });
    }
}

function LoadModalUser(ID, USUARIO) {
    $.ajax({
        url: "/usuarios/form",
        dataType: 'html',
        success: function (data) {
            Swal.fire({
                confirmButtonText: 'Guardar',
                cancelButtonText: 'Cancelar',
                showCancelButton: true,
                allowEscapeKey: false,
                allowOutsideClick: false,
                width: '65rem',
                html: data
            })
                .then((result) => {
                    
                });
        }
    });
}

function petitionsGroup(ID, USUARIO) {

}