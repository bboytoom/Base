using System.ComponentModel.DataAnnotations;

namespace Administrator.Contract
{
    #region ViewModel que realiza el despliegue de los usuarios

    public class ViewModelReadUser
    {
        public int Id { get; set; }

        [Display(Name = "Foto de usuario")]
        public string Photo { get; set; }

        [Display(Name = "Correo del usuario")]
        public string Email { get; set; }

        [Display(Name = "Nombre")]
        public string FullName { get; set; }

        [Display(Name = "Estatus")]
        public bool Status { get; set; }
    }

    #endregion

    #region ViewModel necesario para el formulario del usuario

    public class ViewModelUser
    {
        public int Id { get; set; }

        [Display(Name = "Grupo:")]
        [Required(ErrorMessage = "* El campo de grupo es obligatorio")]
        public int Idgroup { get; set; }

        [Display(Name = "Tipo de usuario:")]
        [Required(ErrorMessage = "* El campo de tipo de usuario es obligatorio")]
        public int Type { get; set; }

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

        [Display(Name = "Foto de usuario:")]
        public string Photo { get; set; }

        [Display(Name = "Estatus:")]
        public bool Status { get; set; }
        public int HighUser { get; set; }
        public int MainUser { get; set; }
    }

    #endregion
}
