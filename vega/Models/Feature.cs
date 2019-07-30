using System.Collections.Generic;

namespace vega.Models
{
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ModelFeature> ModelFeatures { get; set; }
        public Feature()
        {
            this.ModelFeatures = new List<ModelFeature>();
        }

    }

}