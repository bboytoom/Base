'use strict';

class Usuarios extends Strategy {
    constructor(ID, USUARIO) {
        super(ID, USUARIO);
    }

    crear() {
        LoadModalUser('crear', 0, this._USUARIO);
    }

    actualizar() {  
        LoadModalUser('actualizar', this._ID, this._USUARIO);
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
                if (result.value) {
                    Swal.fire({
                        type: 'error',
                        title: 'Eliminado correctamente',
                        preConfirm: () => {
                            var URL = 'http://localhost:50851/wsuserdelete.svc/user/delete';

                            $.ajax({
                                method: "POST",
                                url: URL,
                                data: JSON.stringify({ 'Id': this._ID, HighUser: this._USUARIO }),
                                contentType: "application/json",
                                dataType: "json"
                            })
                                .done(function (data, textStatus, xhr) {
                                    if (data.status === 200)
                                        return true;
                                })
                                .fail(function (data, textStatus, xhr) {
                                    if (data.status === 400)
                                        Swal.showValidationMessage(data.responseJSON.ErrorDetails);

                                    if (data.status === 404)
                                        Swal.showValidationMessage(data.responseJSON.ErrorDetails);
                                });
                        }
                    });
                }
            });
    }
}

function LoadModalUser(TIPO, ID, USUARIO) {
    $.ajax({
        url: "/usuarios/form/?Id=" + ID + "&Tipo=" + TIPO,
        dataType: 'html',
        success: function (data) {
            Swal.fire({
                confirmButtonText: 'Guardar',
                cancelButtonText: 'Cancelar',
                showCancelButton: true,
                allowEscapeKey: false,
                allowOutsideClick: false,
                width: '65rem',
                html: data,
                preConfirm: () => {
                    petitionsUser(ID, USUARIO);                    
                }
            })
                .then((result) => {
                    if (result.value)
                        Swal.fire({
                            type: 'success',
                            confirmButtonText: 'Cerrar'
                        });
                });
        }
    });
}

function petitionsUser(ID, USUARIO) {
    var URL = '';
    var photo = document.getElementById("user_imagen").files[0];
    
    var check_array = {
        'Id': ID,
        'Idgroup': document.getElementById('user_group').value,
        'Typeuser': document.getElementById('user_type').value,
        'Email': document.getElementById('user_correo').value,
        'Name': document.getElementById('user_nombre').value,
        'Lnamep': document.getElementById('user_apaterno').value,
        'Lnamem': document.getElementById('user_amaterno').value,
        'Status': document.getElementById('user_estado').value,
        'Password': document.getElementById('user_password').value,
        'HighUser': USUARIO
    };
    
    if (ID === 0)
        URL = 'http://localhost:50851/wsusercreate.svc/user/create';
    else
        URL = 'http://localhost:50851/wsuserupdate.svc/user/update';
    
    $.ajax({
        method: "POST",
        url: URL,
        data: JSON.stringify({ 'Data': check_array}),
        contentType: "application/json",
        dataType: "json"
    })
        .done(function (data, textStatus, xhr) {
            if (typeof photo !== 'undefined') 
                ImageBit(ID, photo.name, photo);
               
            return true;
        })
        .fail(function (data) {
            if (data.status === 400)
                Swal.showValidationMessage(data.responseJSON.ErrorDetails);
            if (data.status === 404)
                Swal.showValidationMessage(data.responseJSON.ErrorDetails);
            if (data.status === 410)
                Swal.showValidationMessage(data.responseJSON.ErrorDetails);
        });
}

function ImageBit(ID, NAME, FILE) {
    var reader = new FileReader();

    reader.onload = function (e) {
        var image_upload = {
            'Id': ID,
            'Name': NAME,
            'Image': e.target.result
        };
        
        $.ajax({
            method: "POST",
            url: 'http://localhost:50851/wsupload.svc/images/upload',
            data: JSON.stringify({ 'File': image_upload }),
            contentType: "application/json",
            dataType: "json"
        });
    };
    
    reader.readAsDataURL(FILE);
}