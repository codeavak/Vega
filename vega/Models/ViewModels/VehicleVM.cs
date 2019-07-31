using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vega.Models.ViewModels
{
    public class VehicleVM
    {
    

        public int ModelId { get; set; }

        public bool IsRegistered { get; set; }

       
        public string ContactName { get; set; }

        
        public string ContactPhone { get; set; }



        public string ContactEmail { get; set; }

        public string MoreInfo { get; set; }

        public List<int> VehicleFeatures { get; set; }
    }
}
