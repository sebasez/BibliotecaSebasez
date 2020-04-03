using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BibliotecaSebasez.Models
{
    public class Categoria : Entity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
