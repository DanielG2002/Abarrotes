using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace Abarrotes.Models
{
    public class AbarrotesModels : IEnumerable
    {
 
 
              public int ID { get; set; }
        public int Id_Usuario  { get; set; }
        public int id_venta { get; set; }

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
         
        public IEnumerator GetEnumerator()
        {
            yield return this;
        }
    }
}