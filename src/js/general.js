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
    Swal.fire({     
        text: '* Inserte la contraseña actual',
        input: 'password',
        inputPlaceholder: 'Contraseña actual',
        inputAttributes: {
            maxlength: 16,
            autocapitalize: 'on',
            autocorrect: 'off'
        },
        confirmButtonText: 'Aceptar',
        cancelButtonText: 'Cancelar',
        showCancelButton: true,
        allowEscapeKey: false,
        allowOutsideClick: false,
        focusConfirm: false,
        width: '25rem',
        preConfirm: (Input_pass) => {    
            return fetch('/perfil/check/?Id=' + ValorId + '&Password=' + cleanInput(Input_pass))
                .then(response => {
                    if (!response.ok) {
                        throw new Error(response.statusText);
                    }

                    return response.json();
                })
                .then(data => {
                    if (Input_pass.length < 6 || Input_pass.length > 16) {
                        Swal.showValidationMessage('La contraseña necesita un minimo de caracteres');
                    } else {
                        if (!data.Respuesta)
                            Swal.showValidationMessage('La contraseña no es correcta');
                    }

                    return data.Respuesta;
                })
                .catch(error => {
                    Swal.showValidationMessage(`Request failed: ${error}`);
                });       
        }
    }).then((result) => {
        if (result.value) {
            Swal.fire({
                title: 'Ingrese la nueva contraseña',
                type: 'question',
                confirmButtonText: 'Guardar',
                cancelButtonText: 'Cancelar',
                showCancelButton: true,
                allowEscapeKey: false,
                allowOutsideClick: false,
                html:
                    '<input type="password" id="input_pass_uno" class="swal2-input" placeholder="Nueva contraseña" maxlength="16">' +
                    '<input type="password" id="input_pass_dos" class="swal2-input" placeholder="Repita la nueva contraseña" maxlength="16">',
                focusConfirm: false,
                width: '25rem',
                preConfirm: () => {
                    var inputUno = cleanInput(document.getElementById('input_pass_uno').value);
                    var inputDos = cleanInput(document.getElementById('input_pass_dos').value);

                    if (inputUno !== inputDos)
                        Swal.showValidationMessage('Las contraseñas no son iguales');

                    return fetch('/perfil/change', {
                        method: 'POST',
                        body: JSON.stringify({ 'Id': ValorId, 'PasswordUno': inputUno, 'PasswordDos': inputDos }),
                        headers: {
                            'Content-Type': 'application/json'
                        }
                    })
                        .then(response => {
                            if (!response.ok) {
                                throw new Error(response.statusText);
                            }

                            return response.json();
                        })
                        .then(data => {                            
                            if (!data.Respuesta) 
                                Swal.showValidationMessage('Error al actualizar las contraseñas');

                            return data.Respuesta;
                        });
                }
            })
                .then((result) => {
                    if (result.value) {
                        Swal.insertQueueStep({
                            type: 'success',
                            text: 'Contraseña guardada'
                        });
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

