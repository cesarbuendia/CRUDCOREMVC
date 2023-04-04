﻿using System.ComponentModel.DataAnnotations;

namespace CRUDCOREMVC.Models
{
    public class ContactoModel
    {
        public int IdContacto { get; set; }

        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo Telefono es obligatorio")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        public string? Correo { get; set; }


    }
}
