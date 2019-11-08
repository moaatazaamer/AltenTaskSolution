using System;
using System.Collections.Generic;
using System.Text;

namespace Alten.VehicleStatus.Data.Models
{
   public class Vehicle
    {
        public int id { get; set; }
        public string identifire { get; set; }
        public string regNr { get; set; }
        public string status { get; set; }
        public Customer owner { get; set; }
    }
}
