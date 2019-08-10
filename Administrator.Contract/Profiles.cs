using System.ComponentModel.DataAnnotations;

namespace Administrator.Contract
{
    #region ViewModel de autenticacion de cambios

    public class ViewModelPassword
    {
        [Display(Name = "Nueva contraseña:")]
        [Required(ErrorMessage = "* El campo es obligatorio")]
        [DataType(DataType.Password)]
        [StringLength(19, ErrorMessage = "Longitud entre 6 y 15 caracteres.", MinimumLength = 7)]
        public string Password { get; set; }
    }

    #endregion

    #region ViewModel necesario para restablecer el correo del usuario

    public class ViewModelChangeEmail
    {
        [Display(Name = "Ingresa el nuevo correo:")]
        [Required(ErrorMessage = "* El campo de Correo es obligatorio")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Dirección de Correo electrónico incorrecta.")]
        [DataType(DataType.EmailAddress)]
        [StringLength(80, ErrorMessage = "Longitud máxima 80", MinimumLength = 6)]
        public string EmailNew { get; set; }

        [Display(Name = "Repite el nuevo correo:")]
        [Required(ErrorMessage = "* El campo de Correo es obligatorio")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Dirección de Correo electrónico incorrecta.")]
        [DataType(DataType.EmailAddress)]
        [StringLength(80, ErrorMessage = "Longitud máxima 80", MinimumLength = 6)]
        public string EmailRepeat { get; set; }
    }

    #endregion

    #region ViewModel necesario para restablecer la contrseña del usuario

    public class ViewModelChangePassword
    {
        [Display(Name = "Nueva contraseña:")]
        [Required(ErrorMessage = "* El campo es obligatorio")]
        [DataType(DataType.Password)]
        [StringLength(19, ErrorMessage = "Longitud entre 6 y 15 caracteres.", MinimumLength = 7)]
        public string PasswordNew { get; set; }

        [Display(Name = "Repite la nueva contraseña:")]
        [Required(ErrorMessage = "* El campo es obligatorio")]
        [DataType(DataType.Password)]
        [StringLength(19, ErrorMessage = "Longitud entre 6 y 15 caracteres.", MinimumLength = 7)]
        public string PasswordRepeat { get; set; }
    }

    #endregion

    #region ViewModel que despliega el perfil del usuario

    public class ViewModelReadProfile
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de usuario")]
        public string Type { get; set; }

        [Display(Name = "Nombre de grupo")]
        public string Group { get; set; }

        [Display(Name = "Foto de usuario")]
        public string Photo { get; set; }

        [Display(Name = "Correo del usuario")]
        public string Email { get; set; }

        [Display(Name = "Nombre")]
        public string FullName { get; set; }

        [Display(Name = "Creado por")]
        public string MainUser { get; set; }

        [Display(Name = "Estatus")]
        public bool Status { get; set; }
    }

    #endregion
}
