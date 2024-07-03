using System;
using System.ComponentModel.DataAnnotations;

namespace Abarrotes.Models
{
    public class AbarrotesModels
    {



        [Required]
        public string? Usuario { get; set; }
        [Required]
        public string? Password { get; set; }


        [Required]
        public string? Producto { get; set; }

        [Required]
        public string? Descripcion { get; set; }

        [Required]
        public string? Marca { get; set; }
        [Required]
        public string? Precio { get; set; }

        [Required]
        public string? Imagen { get; set; }

    }
}
