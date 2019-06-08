export namespace Interfaces {

    export interface ICheckEmail {
        _email: string
    }

    export interface IGroup {
        _Id: number,
        _Name: string,
        _Description: string,
        _Readuser: boolean,
        _Createuser: boolean,
        _Updateuser: boolean,
        _Deleteuser: boolean,
        _Readgroup: boolean,
        _Creategroup: boolean,
        _Updategroup: boolean,
        _Deletegroup: boolean,
        _Readpermission: boolean,
        _Createpermission: boolean,
        _Updatepermission: boolean,
        _Deletepermission: boolean,
        _Reademail: boolean,
        _Createemail: boolean,
        _Updateemail: boolean,
        _Deleteemail: boolean,
        _Status: boolean,
        _HighUser: string
    }
}



