import { Interfaces } from "./interfaces";
import { Validation } from "./helpers";

export namespace LoginClass {

    export class CheckEmail implements Interfaces.ICheckEmail {
        _email: string;

        constructor(email: string) {
            this._email = email;
        }

        checkEmail(): boolean {
            let input_email = Validation.cleanInput(this._email);

            if (input_email.length > 6 && input_email.length < 79) 
                return Validation.validEmail(input_email);
            
            return false;
        }

        RequestEmail(url: string): Promise<string> {
            let input_email = Validation.cleanInput(this._email);
          
            return fetch(url, {
                method: 'POST',
                body: JSON.stringify({ 'Email': Validation.cleanInput(input_email) }),
                headers: {
                    'Content-Type': 'application/json'
                }
            })
            .then(response => response.json())
            .catch(error => console.error(error))
            .then(response => {
                return response.CheckEmailResult;                   
            });
        }
    }

    export class CheckLogin implements Interfaces.ICheckLogin {
        _email: string;
        _password: string;

        constructor(email: string, password: string) {
            this._email = email;
            this._password = password;
        }

        checkLogin(): Number {
            let input_email = Validation.cleanInput(this._email);

            if (input_email.length == 0 && this._password.length == 0)
                return 450;

            if (this._password.length < 7 && this._password.length > 18)
                return 400;

            if (!Validation.validEmail(input_email))
                return 415;
            
            return 200;
        }

        RequestLogin(url: string): Promise<string> {
            let input_email = Validation.cleanInput(this._email);

            return fetch(url, {
                method: 'POST',
                body: JSON.stringify({ 'Email': Validation.cleanInput(input_email), 'Password': this._password }),
                headers: {
                    'Content-Type': 'application/json'
                }
            })
            .then(response => response.json())
            .catch(error => console.error(error))
            .then(response => {                
                return JSON.stringify(response);
            });
        }
    }
}

