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
        _HighUser: string;

        constructor(Id: number, Name: string, Description: string, Readuser: boolean, Createuser: boolean, Updateuser: boolean, Deleteuser: boolean,
            Readgroup: boolean, Creategroup: boolean, Updategroup: boolean, Deletegroup: boolean,
            Readpermission: boolean, Createpermission: boolean, Updatepermission: boolean, Deletepermission: boolean,
            Reademail: boolean, Createemail: boolean, Updateemail: boolean, Deleteemail: boolean, Status: boolean, HighUser: string) {

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

            if (this._HighUser == "" && this._Name == "")
                return 'datarequired';
            
            input_name = Validation.cleanInput(this._Name);
            input_description = Validation.cleanInput(this._Description);

            if (input_name.length > 4 && input_name.length < 30)
                return 'succes';
            
            return 'fail';
        }
    }
}