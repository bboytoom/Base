import { LoginClass } from "./LoginClass";
import Swal from "sweetalert2";

const input_TextEmail = <HTMLInputElement>document.getElementById('TextEmail');
const input_TextPassword = (<HTMLInputElement>document.getElementById("TextPassword"));
const btn_BtnLogin = (<HTMLInputElement>document.getElementById("BtnLogin"));

input_TextPassword.disabled = true;
btn_BtnLogin.disabled = true;

input_TextEmail.addEventListener('keyup', () => {
    let icon_loader = <HTMLInputElement>document.getElementById('search_email_loader');
    let input = new LoginClass.CheckEmail(input_TextEmail.value);
    let url = 'http://localhost:51099/wscheckemail.svc/auth/checkemail';
   
    if (input.checkEmail()) {
        icon_loader.classList.remove('fa-envelope-square');
        icon_loader.classList.add('fa-spinner');
        icon_loader.classList.add('fa-pulse');

        setTimeout(() => {
            icon_loader.classList.add('fa-envelope-square');
            icon_loader.classList.remove('fa-spinner');
            icon_loader.classList.remove('fa-pulse');

            input.RequestEmail(url).then(function (result) {
                let response = JSON.parse(result);

                if (response.Respuesta) {
                    input_TextEmail.disabled = true;
                    input_TextPassword.disabled = false;
                    btn_BtnLogin.disabled = false;
                } else {
                    input_TextPassword.disabled = true;
                    btn_BtnLogin.disabled = true;
                }
            });
        }, 3000);
    }
});

btn_BtnLogin.addEventListener('click', () => {
    let url = 'http://localhost:51099/wslogin.svc/auth/login';
    let validClassLogin = new LoginClass.CheckLogin(input_TextEmail.value, input_TextPassword.value);

    if (validClassLogin.checkLogin()) {
        validClassLogin.RequestLogin(url).then(function (result) {
            let response = JSON.parse(result);

            if (response.ErrorStatus == 404) {
                Swal.fire({
                    type: 'error',
                    title: 'Oops...',
                    text: response.ErrorDetails,
                    showConfirmButton: false
                })
            }

            if (response.ErrorStatus == 400) {
                Swal.fire({
                    type: 'error',
                    title: 'Oops...',
                    text: response.ErrorDetails,
                    showConfirmButton: false
                })
            }

            if (response.ErrorStatus == 415) {
                Swal.fire({
                    type: 'error',
                    title: 'Oops...',
                    text: response.ErrorDetails,
                    showConfirmButton: false
                })
            }

            if (typeof response.LoginResult !== 'undefined') {
                console.log('Entro');
            }
        });
    } else {
        Swal.fire({
            type: 'error',
            title: 'Oops...',
            text: 'el campo de contraseña y/o correo se encuentran vacios',
            showConfirmButton: false,
            html: true
        })
    }    
});