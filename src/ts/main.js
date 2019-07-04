"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var LoginClass_1 = require("./LoginClass");
var login_section = document.getElementById('section-login');
var input_TextEmail = document.getElementById('TextEmail');
var input_TextPassword = document.getElementById("TextPassword");
var btn_BtnLogin = document.getElementById("BtnLogin");
var icon_loader = document.getElementById('search_email_loader');
icon_loader.classList.add('fa-envelope-square');
input_TextPassword.disabled = true;
btn_BtnLogin.disabled = true;
login_section.addEventListener('load', function () {
    window.history.forward();
});
input_TextEmail.addEventListener('keyup', function () {
    var input = new LoginClass_1.LoginClass.CheckEmail(input_TextEmail.value);
    var url = 'http://localhost:50851/wscheckemail.svc/auth/checkemail';
    if (input.checkEmail()) {
        icon_loader.classList.remove('fa-envelope-square');
        icon_loader.classList.remove('fa-times-circle');
        icon_loader.classList.add('fa-spinner');
        icon_loader.classList.add('fa-pulse');
        setTimeout(function () {
            icon_loader.classList.remove('fa-spinner');
            icon_loader.classList.remove('fa-pulse');
            input.RequestEmail(url).then(function (result) {
                var response = JSON.parse(result);
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
    }
    else {
        icon_loader.classList.add('fa-envelope-square');
        input_TextPassword.disabled = true;
        btn_BtnLogin.disabled = true;
    }
});
//# sourceMappingURL=main.js.map