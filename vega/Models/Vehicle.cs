using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace vega.Models
{
    [Table("vehicles")]
    public class Vehicle
    {
        public int Id { get; set; }

        public int ModelId { get; set; }

        [Required]
        public Model Model { get; set; }

        public bool IsRegistered { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string ContactName { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string ContactPhone { get; set; }


    
        public string ContactEmail { get; set; }

        public string MoreInfo { get; set; }

        public ICollection<VehicleFeature> VehicleFeatures { get; set; }

        public Vehicle()
        {
            this.VehicleFeatures = new List<VehicleFeature>();
        }

        public DateTime LastUpdated { get; set; }
    }
}
