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

        $.ajax({
            method: "POST",
            url: "/usuarios/read",
            data: JSON.stringify({ 'Id': this._ID }),
            contentType: "application/json",
            dataType: 'json',
            success: function (data) {
                if (data.Status == 200) {
                    var datos = data.Respuesta[0];

                    console.log(datos);

                    /*LoadModalUser(ID, USUARIO);

                    setTimeout(function () {
                        document.getElementById('user_foto').value = datos.Photo;
                        document.getElementById('user_idgrupo').value = datos.Idgroup;
                        document.getElementById('user_nombre').value = datos.Name;
                        document.getElementById('user_apaterno').value = datos.Lnamep;
                        document.getElementById('user_amaterno').value = datos.Lnamem;
                        document.getElementById('user_correo').value = datos.Email;
                    }, 600); */
                } else {
                    Swal.fire({
                        type: 'error',
                        text: 'Error al realizar la peticion',
                        confirmButtonText: 'Cerrar'
                    });
                }
            }
        });
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
        url: "/usuarios/form/?Id=" + USUARIO,
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