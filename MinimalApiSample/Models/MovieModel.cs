using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerModel.Models
{
    public class MovieModel
    {
        [Key]
        public Guid Id { get; set; }
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        
        //[Column(TypeName = "decimal(5, 2)")]
        //public decimal Price { get; set; }
    }
}
