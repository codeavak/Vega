using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vega.Models
{
    public class ModelFeature
    {
        public int ModelId { get; set; }
        public Model Model { get; set; }

        public int FeatureId { get; set; }
        public Feature Feature { get; set; }

    }
}
