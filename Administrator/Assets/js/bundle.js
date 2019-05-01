(function(){function r(e,n,t){function o(i,f){if(!n[i]){if(!e[i]){var c="function"==typeof require&&require;if(!f&&c)return c(i,!0);if(u)return u(i,!0);var a=new Error("Cannot find module '"+i+"'");throw a.code="MODULE_NOT_FOUND",a}var p=n[i]={exports:{}};e[i][0].call(p.exports,function(r){var n=e[i][1][r];return o(n||r)},p,p.exports,r,e,n,t)}return n[i].exports}for(var u="function"==typeof require&&require,i=0;i<t.length;i++)o(t[i]);return o}return r})()({1:[function(require,module,exports){
"use strict";

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

Object.defineProperty(exports, "__esModule", { value: true });
var helpers_1 = require("./helpers");
var LoginClass;
(function (LoginClass) {
    var CheckEmail = function () {
        function CheckEmail(email) {
            _classCallCheck(this, CheckEmail);

            this._email = email;
        }

        _createClass(CheckEmail, [{
            key: "checkEmail",
            value: function checkEmail() {
                var input_email = helpers_1.Validation.cleanInput(this._email);
                if (input_email.length > 6 && input_email.length < 79) return helpers_1.Validation.validEmail(input_email);
                return false;
            }
        }, {
            key: "RequestEmail",
            value: function RequestEmail(url) {
                var input_email = helpers_1.Validation.cleanInput(this._email);
                return fetch(url, {
                    method: 'POST',
                    body: JSON.stringify({ 'Email': helpers_1.Validation.cleanInput(input_email) }),
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }).then(function (response) {
                    return response.json();
                }).catch(function (error) {
                    return console.error(error);
                }).then(function (response) {
                    return response.CheckEmailResult;
                });
            }
        }]);

        return CheckEmail;
    }();

    LoginClass.CheckEmail = CheckEmail;
})(LoginClass = exports.LoginClass || (exports.LoginClass = {}));

},{"./helpers":2}],2:[function(require,module,exports){
"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
var Validation;
(function (Validation) {
    function validEmail(InputEmail) {
        var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(String(InputEmail).toLowerCase());
    }
    Validation.validEmail = validEmail;
    function cleanInput(InputEmail) {
        return String(InputEmail).replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/"/g, '&quot;');
    }
    Validation.cleanInput = cleanInput;
})(Validation = exports.Validation || (exports.Validation = {}));

},{}],3:[function(require,module,exports){
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
                if (response.Status == 404) icon_loader.classList.add('fa-times-circle');
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

},{"./LoginClass":1}]},{},[3])

//# sourceMappingURL=bundle.js.map
