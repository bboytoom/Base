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
                body: JSON.stringify({ 'Email': input_email }),
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
}

