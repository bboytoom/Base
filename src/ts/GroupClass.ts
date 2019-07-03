import { Interfaces } from "./interfaces";
import { Validation } from "./helpers";

export namespace GroupClass {

    export class InsertGroup implements Interfaces.IGroup {
        _Id: number;
        _Name: string;
        _Description: string;
        _Readuser: boolean;
        _Createuser: boolean;
        _Updateuser: boolean;
        _Deleteuser: boolean;
        _Readgroup: boolean;
        _Creategroup: boolean;
        _Updategroup: boolean;
        _Deletegroup: boolean;
        _Readpermission: boolean;
        _Createpermission: boolean;
        _Updatepermission: boolean;
        _Deletepermission: boolean;
        _Reademail: boolean;
        _Createemail: boolean;
        _Updateemail: boolean;
        _Deleteemail: boolean;
        _Status: boolean;
        _HighUser: number;

        constructor(Id: number, Name: string, Description: string, Readuser: boolean, Createuser: boolean, Updateuser: boolean, Deleteuser: boolean,
            Readgroup: boolean, Creategroup: boolean, Updategroup: boolean, Deletegroup: boolean,
            Readpermission: boolean, Createpermission: boolean, Updatepermission: boolean, Deletepermission: boolean,
            Reademail: boolean, Createemail: boolean, Updateemail: boolean, Deleteemail: boolean, Status: boolean, HighUser: number) {

            this._Id = Id, this._Name = Name, this._Description = Description,
                this._Readuser = Readuser, this._Createuser = Createuser, this._Updateuser = Updateuser, this._Deleteuser = Deleteuser,
                this._Readgroup = Readgroup, this._Creategroup = Creategroup, this._Updategroup = Updategroup, this._Deletegroup = Deletegroup,
                this._Readpermission = Readpermission, this._Createpermission = Createpermission, this._Updatepermission = Updatepermission, this._Deletepermission = Deletepermission,
                this._Reademail = Reademail, this._Createemail = Createemail, this._Updateemail = Updateemail, this._Deleteemail = Deleteemail,
                this._Status = Status, this._HighUser = HighUser
        }

        validInsertGroup(): string {
            let input_name;
            let input_description;

            if (this._HighUser == 0 && this._Name == "")
                return 'datarequired';
            
            input_name = Validation.cleanInput(this._Name);
            input_description = Validation.cleanInput(this._Description);

            if (input_name.length > 4 && input_name.length < 30)
                return 'succes';
            
            return 'fail';
        }

        Insert(url: string): Promise<string> {
            let input_name = Validation.cleanInput(this._Name);
            let input_description = Validation.cleanInput(this._Description);

            let insert = {
                Data: {
                    'Id': this._Id,
                    'Name': input_name,
                    'Description': input_description,
                    'Readuser': this._Readuser,
                    'Createuser': this._Createuser,
                    'Updateuser': this._Updateuser,
                    'Deleteuser': this._Deleteuser,
                    'Readgroup': this._Readgroup,
                    'Creategroup': this._Creategroup,
                    'Updategroup': this._Updategroup,
                    'Deletegroup': this._Deletegroup,
                    'Readpermission': this._Readpermission,
                    'Createpermission': this._Createpermission,
                    'Updatepermission': this._Updatepermission,
                    'Deletepermission': this._Deletepermission,
                    'Reademail': this._Reademail,
                    'Createemail': this._Createemail,
                    'Updateemail': this._Updateemail,
                    'Deleteemail': this._Deleteemail,
                    'Status': this._Status,
                    'HighUser': this._HighUser
                }
            };

            return fetch(url, {
                method: 'POST',
                body: JSON.stringify(insert),
                headers: {
                    'Content-Type': 'application/json'
                }
            })
            .then(response => response.json())
            .catch(error => console.error(error))
            .then(response => {
                return response;
            });
        }
    }
}