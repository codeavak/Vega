using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vega.Models
{
    public class Model
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }

        public Make Make { get; set; }
        public int MakeId { get; set; }

        public ICollection<ModelFeature> ModelFeatures { get;  }

        public Model()
        {
            this.ModelFeatures = new List<ModelFeature>();
        }
        
    }
}