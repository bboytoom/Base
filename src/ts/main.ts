import { LoginClass } from "./LoginClass";
import Swal from "sweetalert2";

const login_section = <HTMLInputElement>document.getElementById('section-login');
const input_TextEmail = <HTMLInputElement>document.getElementById('TextEmail');
const input_TextPassword = (<HTMLInputElement>document.getElementById("TextPassword"));
const btn_BtnLogin = (<HTMLInputElement>document.getElementById("BtnLogin"));
let icon_loader = <HTMLInputElement>document.getElementById('search_email_loader');

icon_loader.classList.add('fa-envelope-square');
input_TextPassword.disabled = true;
btn_BtnLogin.disabled = true;


login_section.addEventListener('load', () => {
    window.history.forward();
});

input_TextEmail.addEventListener('keyup', () => {
    
    let input = new LoginClass.CheckEmail(input_TextEmail.value);
    let url = 'http://localhost:50851/wscheckemail.svc/auth/checkemail';
   
    if (input.checkEmail()) {
        icon_loader.classList.remove('fa-envelope-square');
        icon_loader.classList.remove('fa-times-circle');
        icon_loader.classList.add('fa-spinner');
        icon_loader.classList.add('fa-pulse');

        setTimeout(() => {
            icon_loader.classList.remove('fa-spinner');
            icon_loader.classList.remove('fa-pulse');

            input.RequestEmail(url).then(function (result) {
                let response = JSON.parse(result);

                if (response.Status == 404) 
                    icon_loader.classList.add('fa-times-circle');
                
                if (response.Status == 401) {
                    icon_loader.classList.add('fa-times-circle');
                    document.cookie = '_inactiva=1';
                    window.location.href = '/lockout';
                }

                if (response.Status == 200) {
                    icon_loader.classList.remove('fa-times-circle');
                    icon_loader.classList.add('fa-check-square');
                    input_TextPassword.disabled = false;
                    btn_BtnLogin.disabled = false;
                }
            });
        }, 4000);
    } else {
        icon_loader.classList.add('fa-envelope-square');
        input_TextPassword.disabled = true;
        btn_BtnLogin.disabled = true;
    }
});

