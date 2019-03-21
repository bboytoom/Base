using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionUsuarios.Helpers
{
    public class ViewModelGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Readuser { get; set; }
        public bool Createuser { get; set; }
        public bool Updateuser { get; set; }
        public bool Deleteuser { get; set; }
        public bool Readgroup { get; set; }
        public bool Creategroup { get; set; }
        public bool Updategroup { get; set; }
        public bool Deletegroup { get; set; }
        public bool Readpermission { get; set; }
        public bool Createpermission { get; set; }
        public bool Updatepermission { get; set; }
        public bool Deletepermission { get; set; }
        public bool Reademail { get; set; }
        public bool Createemail { get; set; }
        public bool Updateemail { get; set; }
        public bool Deleteemail { get; set; }
        public bool Status { get; set; }
        public int HighUser { get; set; }
    }

    public class ViewModelUser
    {
        public int Id { get; set; }
        public int Idemail { get; set; }
        public int Idgroup { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public bool Initemail { get; set; }
        public string Descriptionemail { get; set; }
        public string Password { get; set; }
        public string Curp { get; set; }
        public string Rfc { get; set; }
        public string Name { get; set; }
        public string Lnamep { get; set; }
        public string Lnamem { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Status { get; set; }
        public int HighUser { get; set; }
    }

    public class ViewModelEmail
    {
        public int Id { get; set; }
        public int Iduser { get; set; }
        public bool Mainemail { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public int HighUser { get; set; }
    }
}