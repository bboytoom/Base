using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administrator.Manager.Helpers
{
    public class ViewModelGroup
    {
        public int Id { get; set; }
        [Display(Name = "Nombre de grupo:")]
        [Required(ErrorMessage = "* El campo de nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Longitud máxima 80", MinimumLength = 4)]
        public string Name { get; set; }
        [Display(Name = "Descripcion:")]
        [StringLength(200, ErrorMessage = "Longitud máxima 80", MinimumLength = 4)]
        public string Description { get; set; }
        [Display(Name = "Mostrar usuario:")]
        public bool Readuser { get; set; }
        [Display(Name = "Crear usuario:")]
        public bool Createuser { get; set; }
        [Display(Name = "Actualizar usuario:")]
        public bool Updateuser { get; set; }
        [Display(Name = "Eliminar usuario:")]
        public bool Deleteuser { get; set; }
        [Display(Name = "Mostrar grupo:")]
        public bool Readgroup { get; set; }
        [Display(Name = "Crear grupo:")]
        public bool Creategroup { get; set; }
        [Display(Name = "Actualizar grupo:")]
        public bool Updategroup { get; set; }
        [Display(Name = "Eliminar grupo:")]
        public bool Deletegroup { get; set; }
        [Display(Name = "Mostrar permiso:")]
        public bool Readpermission { get; set; }
        [Display(Name = "Crear permiso:")]
        public bool Createpermission { get; set; }
        [Display(Name = "Actualizar permiso:")]
        public bool Updatepermission { get; set; }
        [Display(Name = "Eliminar permiso:")]
        public bool Deletepermission { get; set; }
        [Display(Name = "Mostrar email:")]
        public bool Reademail { get; set; }
        [Display(Name = "Mostrar crear:")]
        public bool Createemail { get; set; }
        [Display(Name = "Actualizar email:")]
        public bool Updateemail { get; set; }
        [Display(Name = "Eliminar email:")]
        public bool Deleteemail { get; set; }
        [Display(Name = "Estatus:")]
        public bool Status { get; set; }
        public int HighUser { get; set; }
        public int Main { get; set; }
    }

    public class ViewModelEmail
    {
        public int Id { get; set; }
        public int Iduser { get; set; }
        public int Typeuser { get; set; }

        [Display(Name = "Correo del usuario:")]
        [Required(ErrorMessage = "* El campo de Correo es obligatorio")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Dirección de Correo electrónico incorrecta.")]
        [DataType(DataType.EmailAddress)]
        [StringLength(80, ErrorMessage = "Longitud máxima 80", MinimumLength = 6)]
        public string Email { get; set; }

        [Display(Name = "Descripcion:")]
        [StringLength(200, ErrorMessage = "Longitud máxima 80", MinimumLength = 4)]
        public string Description { get; set; }
        public bool Status { get; set; }
        public int HighUser { get; set; }
    }

    public class ViewModelUser
    {
        public int Id { get; set; }

        [Display(Name = "Grupo:")]
        [Required(ErrorMessage = "* El campo de grupo es obligatorio")]
        public int Idgroup { get; set; }

        [Display(Name = "Tipo de usuario:")]
        [Required(ErrorMessage = "* El campo de tipo de usuario es obligatorio")]
        public int Typeuser { get; set; }

        [Display(Name = "Correo del usuario:")]
        [Required(ErrorMessage = "* El campo de Correo es obligatorio")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Dirección de Correo electrónico incorrecta.")]
        [DataType(DataType.EmailAddress)]
        [StringLength(80, ErrorMessage = "Longitud máxima 80", MinimumLength = 6)]
        public string Email { get; set; }

        [Display(Name = "Contraseña del usuario:")]
        [Required(ErrorMessage = "* El campo de Contraseña es obligatorio")]
        [DataType(DataType.Password)]
        [StringLength(19, ErrorMessage = "Longitud entre 6 y 15 caracteres.", MinimumLength = 7)]
        public string Password { get; set; }

        [Display(Name = "Nombre de usuario:")]
        [Required(ErrorMessage = "* El campo de nombrea es obligatorio")]
        [StringLength(50, ErrorMessage = "Longitud entre 50 y 3 caracteres.", MinimumLength = 3)]
        public string Name { get; set; }

        [Display(Name = "Apellido paterno:")]
        [Required(ErrorMessage = "* El campo de apellido paterno es obligatorio")]
        [StringLength(30, ErrorMessage = "Longitud entre 50 y 3 caracteres.", MinimumLength = 4)]
        public string Lnamep { get; set; }

        [Display(Name = "Apellido materno:")]
        [StringLength(30, ErrorMessage = "Longitud entre 50 y 3 caracteres.", MinimumLength = 4)]
        public string Lnamem { get; set; }
        public string Nameimg { get; set; }
        public bool Status { get; set; }
        public int HighUser { get; set; }
        public int MainUser { get; set; }
    }

    public class ViewModelUploadImg
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }

    public class ViewModelsLogin
    {
        [Display(Name = "Correo del usuario:")]
        [Required(ErrorMessage = "* El campo de Correo es obligatorio")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Dirección de Correo electrónico incorrecta.")]
        [DataType(DataType.EmailAddress)]
        [StringLength(80,  ErrorMessage = "Longitud máxima 80", MinimumLength = 6)]
        public string Email { get; set; }

        [Display(Name = "Contraseña del usuario:")]
        [Required(ErrorMessage = "* El campo de Contraseña es obligatorio")]
        [DataType(DataType.Password)]
        [StringLength(19, ErrorMessage = "Longitud entre 6 y 15 caracteres.", MinimumLength = 7)]
        public string Password { get; set; }

        [Display(Name = "Recuerdame:")]
        public bool Rememberme { get; set; }
    }
}
