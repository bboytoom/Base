using System;
using System.ComponentModel.DataAnnotations;

namespace Administrator.Contract
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
}
