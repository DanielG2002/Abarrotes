using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Abarrotes.Models
{
    public class AbarrotesModels : IEnumerable
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
        [DataType(DataType.Upload)]
        public string? Imagen { get; set; }

        // Implementación de la interfaz IEnumerable
        public IEnumerator GetEnumerator()
        {
            yield return this;
        }
    }
}