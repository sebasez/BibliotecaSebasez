using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BibliotecaSebasez.Models
{
    public class Autor : Entity
    {
        [Required(ErrorMessage = "Se requiere el nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Se requiere el apellido")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Se requiere la fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        public string NombreCompleto
        {
            get
            {
                return $"{Nombre} {Apellidos}".ToUpper();
            }
        }
    }
}
