using System.ComponentModel.DataAnnotations;

namespace Administrator.Contract
{
    #region ViewModel necesario para el formulario de autenticacion

    public class ViewModelsAuth
    {
        [Display(Name = "Correo del usuario:")]
        [Required(ErrorMessage = "* El campo de Correo es obligatorio")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Dirección de Correo electrónico incorrecta.")]
        [DataType(DataType.EmailAddress)]
        [StringLength(80, ErrorMessage = "Longitud máxima 80", MinimumLength = 6)]
        public string Email { get; set; }

        [Display(Name = "Contraseña del usuario:")]
        [Required(ErrorMessage = "* El campo de Contraseña es obligatorio")]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "Longitud entre 6 y 15 caracteres.", MinimumLength = 7)]
        public string Password { get; set; }

        [Display(Name = "Recuerdame:")]
        public bool Rememberme { get; set; }
    }

    #endregion

    #region ViewModel para el transporte de claims

    public class ViewModelClaims
    {
        public string Identificador { get; set; }
        public string Fullname { get; set; }
        public string MainUser { get; set; }
        public string Email { get; set; }
        public int TypeUser { get; set; }
    }

    #endregion
}
