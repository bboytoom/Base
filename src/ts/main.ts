import { LoginClass } from "./LoginClass";

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
    let validCheckLogin = validClassLogin.checkLogin();
    
    if (validCheckLogin == 400) {
        console.log('La contraseña no contiene la longitud correcta o se encuentra vacio el campo');
    }

    if (validCheckLogin == 415) {
        console.log('El correo proporcionado no es valido');
    }

    if (validCheckLogin == 200) {
        validClassLogin.RequestLogin(url).then(function (result) {
            let response = JSON.parse(result);
            console.log(response.LoginResult);
            console.log(response.ErrorStatus);
        });
    }

});