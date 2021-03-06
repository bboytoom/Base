﻿using System.ComponentModel.DataAnnotations;

namespace Administrator.Contract
{
    #region ViewModel que realiza el despliegue de los grupos

    public class ViewModelReadGroup
    {
        public int Id { get; set; }

        [Display(Name = "Nombre de grupo")]
        public string Group { get; set; }

        [Display(Name = "Descripcion")]
        public string Description { get; set; }

        [Display(Name = "Estatus")]
        public bool Status { get; set; }
    }

    #endregion

    #region ViewModel necesario para el formulario de grupos para el usuario

    public class ViewModelGroupUser
    {
        public int Id { get; set; }

        [Display(Name = "Nombre de grupo:")]
        [Required(ErrorMessage = "* El campo de nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Longitud máxima 80", MinimumLength = 4)]
        public string Group { get; set; }

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

        [Display(Name = "Estatus:")]

        public bool Status { get; set; }

        public int HighUser { get; set; }

        public int Main { get; set; }
    }

    #endregion

    #region ViewModel necesario para el formulario de grupos para el usuario root

    public class ViewModelGroupRoot
    {
        public int Id { get; set; }

        [Display(Name = "Nombre de grupo:")]
        [Required(ErrorMessage = "* El campo de nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Longitud máxima 80", MinimumLength = 4)]
        public string Group { get; set; }

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

        [Display(Name = "Mostrar permiso:")]
        public bool Readpermission { get; set; }

        [Display(Name = "Crear permiso:")]
        public bool Createpermission { get; set; }

        [Display(Name = "Actualizar permiso:")]
        public bool Updatepermission { get; set; }

        [Display(Name = "Eliminar permiso:")]
        public bool Deletepermission { get; set; }

        [Display(Name = "Estatus:")]

        public bool Status { get; set; }

        public int HighUser { get; set; }

        public int Main { get; set; }
    }

    #endregion
}
