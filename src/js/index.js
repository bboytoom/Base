"use strict";

var login_section = document.getElementById('section-login');
var input_TextEmail = document.getElementById('TextEmail');
var input_TextPassword = document.getElementById("TextPassword");
var btn_BtnLogin = document.getElementById("BtnLogin");
var icon_loader = document.getElementById('search_email_loader');

icon_loader.classList.add('fa-envelope-square');
input_TextPassword.disabled = true;
btn_BtnLogin.disabled = true;

function validEmail(InputEmail) {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(InputEmail).toLowerCase());
}

function cleanInput(InputEmail) {
    return String(InputEmail).replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/"/g, '&quot;');
}

function checkEmail(InputEmail) {
    var clean_input = cleanInput(InputEmail);

    if (clean_input.length > 6 && clean_input.length < 79)
        return validEmail(clean_input);

    return false;
}

function AjaxEmail(URL, InputEmail) {
    var clean_input = cleanInput(InputEmail);

    $.ajax({
        method: "POST",
        url: URL,
        data: JSON.stringify({ 'Email': clean_input }),
        contentType: "application/json",
        dataType: "json"
    })
        .done(function (data) {
            var response = JSON.parse(data.CheckEmailResult);

            if (response.Status === 404)
                icon_loader.classList.add('fa-times-circle');

            if (response.Status === 401) {
                icon_loader.classList.add('fa-times-circle');
                document.cookie = '_inactiva=1';
                window.location.href = '/lockout';
            }

            if (response.Status === 200) {
                icon_loader.classList.remove('fa-times-circle');
                icon_loader.classList.add('fa-check-square');
                input_TextPassword.disabled = false;
                btn_BtnLogin.disabled = false;
            }
        }).fail(function (data) {
            if (data.status === 400) {
                alert('Error en la peticion');
            }
        });
}

function petitionsEmail(InputEmail) {
    var clean_input = cleanInput(InputEmail);

    if (checkEmail(clean_input) === true) {
        icon_loader.classList.remove('fa-envelope-square');
        icon_loader.classList.remove('fa-times-circle');
        icon_loader.classList.add('fa-spinner');
        icon_loader.classList.add('fa-pulse');

        setTimeout(function () {
            icon_loader.classList.remove('fa-spinner');
            icon_loader.classList.remove('fa-pulse');

            var url = 'http://localhost:50851/wscheckemail.svc/auth/checkemail';

            AjaxEmail(url, clean_input);
        }, 4000);
    } else {
        icon_loader.classList.add('fa-envelope-square');
        input_TextPassword.disabled = true;
        btn_BtnLogin.disabled = true;
    }
}

function LoginSuccess(data) {
    if (data.Status === 404) {
        AlertLogin(data.Respuesta);
    }

    if (data.Status === 415) {
        AlertLogin(data.Respuesta);
    }

    if (data.Status === 401) {
        Swal.fire({
            type: 'error',
            text: data.Respuesta,
            allowOutsideClick: false,
            allowEscapeKey: false,
            confirmButtonText: 'Cerrar'
        }).then((result) => {
            if (result.value) {
                window.location.href = '/lockout';
            }
        });
    }

    if (data.Status === 403) {
        Swal.fire({
            type: 'error',
            text: data.Respuesta,
            allowOutsideClick: false,
            allowEscapeKey: false,
            confirmButtonText: 'Cerrar'
        }).then((result) => {
            if (result.value) {
                window.location.href = '/bloqueado';
            }
        });
    }

    if (data.Status === 203) {
        Swal.fire({
            type: 'error',
            text: data.Respuesta,
            allowOutsideClick: false,
            allowEscapeKey: false,
            confirmButtonText: 'Cerrar'
        }).then((result) => {
            if (result.value) {
                input_TextPassword.reset();
            }
        });
    }

    if (data.Status === 200) {
        if (data.Respuesta === 3 || data.Respuesta === 4)
            window.location.href = '/inicio';

        if (data.Respuesta === 1 || data.Respuesta === 2)
            window.location.href = '/super/panel';
    }
}

function AlertLogin(Respuesta) {
    Swal.fire({
        type: 'error',
        text: Respuesta,
        allowOutsideClick: false,
        allowEscapeKey: false,
        confirmButtonText: 'Cerrar'
    });
}

function LoginFail(data) {
    console.log(data);
}

login_section.addEventListener('load', function () {
    window.history.forward();
});

input_TextEmail.addEventListener('keyup', function (e) {
    if (e.keyCode !== 9) {
        petitionsEmail(this.value);
    }
}, false);