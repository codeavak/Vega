using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace vega.Models
{
    public class Make
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="varchar(255)")]
        public string Name { get; set; }
        public ICollection<Model> Models { get; set; }

        public Make()
        {
            Models = new List<Model>();
        }
    }
}
