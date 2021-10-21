using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taxi_app.Models;

namespace Taxi_app.Models
{
    public class Driver : Person
    {
        public ICollection<Ride> Rides { get; set; }
        public ICollection<Vehicle> OwnedVehicles { get; set; }
    }
}