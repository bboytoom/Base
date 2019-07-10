'use strict';

class Grupos extends Strategy {
    constructor(ID, USUARIO) {
        super(ID, USUARIO);
    }

    crear() {
        LoadModalGroup(0, this._USUARIO);
    }

    actualizar() {
        var ID = this._ID;
        var USUARIO = this._USUARIO;

        $.ajax({
            method: "POST",
            url: "/grupos/read",
            data: JSON.stringify({ 'Id': this._ID }),
            contentType: "application/json",
            dataType: 'json',
            success: function (data) {
                if (data.Status == 200) {
                    var datos = data.Respuesta[0];

                    LoadModalGroup(ID, USUARIO);

                    setTimeout(function () {
                        document.getElementById('group_name').value = datos.Name;
                        document.getElementById('group_description').value = datos.Description;
                        document.getElementById('create_group').checked = datos.Creategroup;
                        document.getElementById('update_group').checked = datos.Updategroup;
                        document.getElementById('delete_group').checked = datos.Deletegroup;
                        document.getElementById('read_group').checked = datos.Readgroup;
                        document.getElementById('create_user').checked = datos.Createuser;
                        document.getElementById('update_user').checked = datos.Updateuser;
                        document.getElementById('delete_user').checked = datos.Deleteuser;
                        document.getElementById('read_user').checked = datos.Readuser;
                        document.getElementById('create_permission').checked = datos.Createpermission;
                        document.getElementById('update_permission').checked = datos.Updatepermission;
                        document.getElementById('delete_permission').checked = datos.Deletepermission;
                        document.getElementById('read_permission').checked = datos.Readpermission;
                        document.getElementById('create_email').checked = datos.Createemail;
                        document.getElementById('update_email').checked = datos.Updateemail;
                        document.getElementById('delete_email').checked = datos.Deleteemail;
                        document.getElementById('read_email').checked = datos.Reademail;
                        document.getElementById('group_status').checked = datos.Status;
                    }, 300);
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
                if (result.value) {
                    Swal.fire({
                        type: 'error',
                        title: 'Eliminado correctamente',
                        preConfirm: () => {
                            var URL = 'http://localhost:50851/wsgroupdelete.svc/group/delete';

                            $.ajax({
                                method: "POST",
                                url: URL,
                                data: JSON.stringify({ 'Id': this._ID, HighUser: this._USUARIO }),
                                contentType: "application/json",
                                dataType: "json",
                            })
                                .done(function (data, textStatus, xhr) {
                                    if (data.status == 200)
                                        return true;
                                })
                                .fail(function (data, textStatus, xhr) {
                                    if (data.status == 400)
                                        Swal.showValidationMessage(data.responseJSON.ErrorDetails);

                                    if (data.status == 404)
                                        Swal.showValidationMessage(data.responseJSON.ErrorDetails);
                                });
                        }
                    })
                }
            });
    }
}

function LoadModalGroup(ID, USUARIO) {
    $.ajax({
        url: "/grupos/form",
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
                    var Input_name = cleanInput(document.getElementById('group_name').value);
                    var label_name = document.getElementById('lable_name');

                    if (valid_Name(Input_name)) {
                        petitionsGroup(Input_name, ID, USUARIO);
                    } else {
                        label_name.style.display = 'block';

                        setTimeout(function () {
                            label_name.style.display = 'none';
                        }, 4000);

                        return false;
                    }
                },
                allowOutsideClick: () => !Swal.isLoading()
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

function petitionsGroup(INPUT, ID, USUARIO) {
    var serializer_form_check = document.getElementsByClassName('ckeck__group');
    var URL = '';

    var check_array = {
        'HighUser': USUARIO,
        'Name': INPUT,
        'Description': document.getElementById('group_description').value,
        'Id': ID
    };

    for (var i = 0; i < serializer_form_check.length; i++)
        check_array[serializer_form_check[i].name] = serializer_form_check[i].checked;

    if (ID == 0)
        URL = 'http://localhost:50851/wsgroupcreate.svc/group/create';
    else
        URL = 'http://localhost:50851/wsgroupupdate.svc/group/update';

    $.ajax({
        method: "POST",
        url: URL,
        data: JSON.stringify({ 'Data': check_array }),
        contentType: "application/json",
        dataType: "json",
    })
        .done(function (data, textStatus, xhr) {
            if (data.status == 200)
                return true;
        })
        .fail(function (data, textStatus, xhr) {
            if (data.status == 400)
                Swal.showValidationMessage(data.responseJSON.ErrorDetails);

            if (data.status == 404)
                Swal.showValidationMessage(data.responseJSON.ErrorDetails);

            if (data.status == 410)
                Swal.showValidationMessage(data.responseJSON.ErrorDetails);
        });
}