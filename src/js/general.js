'use strict';

function Delete(ValorId, Tipo) {
    var usuario = parseInt(document.getElementById('infohidde').value);
    var estrategia = new Contexto(Tipo, ValorId, usuario);

    estrategia.EliminarInterface();
}

function Edit(ValorId, Tipo) {
    var usuario = parseInt(document.getElementById('infohidde').value);
    var main = parseInt(document.getElementById('mainhidde').value);
    var estrategia = new Contexto(Tipo, ValorId, usuario, main);

    estrategia.ActualizarInterface();
}

function ChangePasword(ValorId) {
    $.ajax({
        url: "/perfil/password",
        dataType: 'html',
        success: function (data) {
            Swal.fire({
                confirmButtonText: 'Aceptar',
                cancelButtonText: 'Cancelar',
                showCancelButton: true,
                allowEscapeKey: false,
                allowOutsideClick: false,
                width: '25rem',
                html: data,
                preConfirm: () => {
                    var Input_password = cleanInput(document.getElementById('perfil_password').value);
                    var label_password = document.getElementById('label_perfil_pass');

                    if (Input_password !== "" && Input_password.length > 6 && Input_password.length < 16) {
                        fetch("/perfil/check/?Id=" + ValorId + "&Password=" + Input_password)
                            .then((response) => { return response.json(); })
                            .then((data) => {
                                if (!data.Respuesta) {
                                    label_password.textContent = 'La contraseña es incorrecta';

                                    setTimeout(function () {
                                        label_password.textContent = '';
                                    }, 4000);

                                    return false;
                                }
                            }); 
                    } else {
                        label_password.textContent = 'La contraseña requiere un minimo de caracteres';

                        setTimeout(function () {
                            label_password.textContent = '';
                        }, 4000);

                        return false;
                    }
                }
            }).then((result) => {
                if (result.value) {
                    console.log('hola');
                }
            });
        }
    });
}

document.getElementById('add_btn').addEventListener('click', () => {
    var usuario = parseInt(document.getElementById('infohidde').value);
    var main = parseInt(document.getElementById('mainhidde').value);
    var estrategia = new Contexto(add_btn.name, 0, usuario, main);

    estrategia.CrearInterface();
});

